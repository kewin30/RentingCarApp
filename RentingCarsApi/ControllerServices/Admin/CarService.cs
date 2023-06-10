using AutoMapper;
using Humanizer;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RentingCarsApi.Data;
using RentingCarsApi.DTO.GetDtos;
using RentingCarsApi.DTO.PostPut_Dtos;
using RentingCarsApi.Entity;
using RentingCarsApi.Exceptions;
using RentingCarsApi.Helpers;

namespace RentingCarsApi.ControllerServices.Admin
{
    public interface ICarService
    {
        Task AddNewCar();
        Task<GetCarWithPhoto> GetCar(string vin);
        Task<GetPaymentFromCar> GetPayment(string vin);
        Task<GetWholeUser> GetUser(int id);
        Task<GetUserBeforeDto> GetUserBefore(string vin);
        Task<GetPaymentFromCar> PayForTheCar(string vin);
        Task<GetPaymentFromCar> RentTheCar(RentTheCarDto dto);
    }
    public class CarService : ICarService
    {
        private readonly ICarManagerDependencies _carDependencies;

        public CarService(ICarManagerDependencies carDependencies)
        {
            _carDependencies = carDependencies;
        }
        public async Task AddNewCar()
        {
            IFormCollection form = await _carDependencies.Request.ReadFormAsync();
            string dtoJson = form["dto"];
            CarDto dto = JsonConvert.DeserializeObject<CarDto>(dtoJson);
            IFormFile file = form.Files.FirstOrDefault();

            Photo photo = await _carDependencies.PhotoFactory.NewPhoto(file);
            await _carDependencies.CatchCarExceptions.CatchExceptions(dto, _carDependencies.Context);
            Cars cars = _carDependencies.Mapper.Map<Cars>(dto);
            cars.Availability = true;
            cars.Place = cars.Place.ToLower();

            await _carDependencies.Context.Photos.AddAsync(photo);
            await _carDependencies.Context.Cars.AddAsync(cars);
            await _carDependencies.Context.SaveChangesAsync();
            cars.PhotoId = photo.Id;
            photo.CarsVin = cars.Vin;
            await _carDependencies.Context.SaveChangesAsync();
        }

        public async Task<GetCarWithPhoto> GetCar(string vin)
        {
            Cars car = await _carDependencies.Context.Cars
                .Include(x => x.User)
                .Include(x => x.Photo)
                .FirstOrDefaultAsync(x => x.Vin == vin);
            if (car is null)
            {
                throw new NotFoundException("Car not found! ");
            }
            GetCarWithPhoto mappedCar = _carDependencies.Mapper.Map<GetCarWithPhoto>(car);

            return mappedCar;
        }

        public async Task<GetPaymentFromCar> GetPayment(string vin)
        {
            Cars car = await _carDependencies.Context.Cars.FirstOrDefaultAsync(x => x.Vin == vin);
            if (car is null)
            {
                throw new NotFoundException($"Car not found with VIN: {vin}");
            }
            int totalDays = car.RentedTo.DayNumber - car.RentedFrom.DayNumber;

            int weeks = totalDays / 7;
            int remainingDays = totalDays % 7;

            double prize = weeks * car.PrizeForWeek + remainingDays * car.PrizeForDay;

            GetPaymentFromCar mappedCar = _carDependencies.Mapper.Map<GetPaymentFromCar>(car);
            mappedCar.Prize = prize;
            return mappedCar;
        }

        public async Task<GetWholeUser> GetUser(int id)
        {
            AppUser user = await _carDependencies.Context.Users
                .Include(x => x.Address)
                .Include(x => x.Cars)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (user is null)
            {
                throw new NotFoundException("Couldn't find the user! ");
            }
            GetWholeUser mappedUser = _carDependencies.Mapper.Map<GetWholeUser>(user);
            return mappedUser;
        }

        public async Task<GetUserBeforeDto> GetUserBefore(string vin)
        {
            Cars car = await _carDependencies.Context.Cars
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Vin == vin);
            if (car is null)
            {
                throw new NotFoundException("Couldn't find the car! ");
            }
            AppUser user = await _carDependencies.Context.Users
                .Include(x => x.Address)
                .FirstOrDefaultAsync(x => x.Id == car.UserBeforeId);
            if (user is null)
            {
                throw new NotFoundException("This car didn't have previous user!");
            }
            GetUserBeforeDto mappedUser = _carDependencies.Mapper.Map<GetUserBeforeDto>(user);
            return mappedUser;
        }

        public async Task<GetPaymentFromCar> PayForTheCar(string vin)
        {
            GetPaymentFromCar payment = await GetPayment(vin);
            Cars car = await _carDependencies.Context.Cars.FirstOrDefaultAsync(x => x.Vin == vin);
            car.UserBeforeId = (int)car.UserId;
            car.UserId = null;
            car.HasBeenPaid = true;
            car.Availability = true;
            car.RentedFrom = new DateOnly(1, 1, 1);
            car.RentedTo = new DateOnly(1, 1, 1);
            await _carDependencies.Context.SaveChangesAsync();
            return payment;
        }

        public async Task<GetPaymentFromCar> RentTheCar(RentTheCarDto dto)
        {
            Cars car = await _carDependencies.Context.Cars.FirstOrDefaultAsync(x => x.Vin == dto.Vin);
            if(car is null)
            {
                throw new NotFoundException($"Car not found with VIN: {dto.Vin}");
            }
            car.RentedFrom = dto.RentedFrom;
            car.RentedTo = dto.RentedTo;
            car.Availability = false;
            car.IsReserved = false;
            car.UserId = car.UserReservationId;
            car.UserReservationId = null;
            await _carDependencies.Context.SaveChangesAsync();
            GetPaymentFromCar payment = await GetPayment(dto.Vin);
            return payment;

        }
    }
}
