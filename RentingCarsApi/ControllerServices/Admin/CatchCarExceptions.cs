using Microsoft.EntityFrameworkCore;
using RentingCarsApi.Data;
using RentingCarsApi.DTO.GetDtos;
using RentingCarsApi.Exceptions;

namespace RentingCarsApi.ControllerServices.Admin
{
    public interface ICatchCarExceptions
    {
        Task CatchExceptions(CarDto dto, RentingDbContext _context);
    }
    public class CatchCarExceptions : ICatchCarExceptions
    {
        public async Task CatchExceptions(CarDto dto, RentingDbContext _context)
        {
            bool carExists = await _context.Cars.AnyAsync(x => x.Vin == dto.Vin || x.Plate == dto.Plate);
            if (carExists)
            {
                throw new BadRequestException($"Car with this ID or Plate exists!! {dto.Vin} | {dto.Plate}");
            }
            if (dto.PrizeForDay > dto.PrizeForWeek)
            {
                throw new BadRequestException("The prize for one day can't be higher than prize for one week! ");
            }
            if (dto.CarYear < 2018)
            {
                throw new BadRequestException($"This car can't be that young! ");
            }
            if (dto.CarYear > DateTime.Now.Year + 1)
            {
                throw new BadRequestException($"This car can't be from the future!");
            }
        }
    }
}
