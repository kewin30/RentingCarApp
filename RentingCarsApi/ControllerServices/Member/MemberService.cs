using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RentingCarsApi.Data;
using RentingCarsApi.DTO.GetDtos;
using RentingCarsApi.DTO.PostPut_Dtos;
using RentingCarsApi.Entity;
using RentingCarsApi.Exceptions;

namespace RentingCarsApi.ControllerServices.Member
{
    public interface IMemberService
    {
        Task<List<GetCarsForMemberDto>> GetAll();
        Task<CarDto> ReserveCar(ReserveCarForMemberDto dto);
    }
    public class MemberService : IMemberService
    {
        private readonly RentingDbContext _context;
        private readonly IMapper _mapper;

        public MemberService(RentingDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<GetCarsForMemberDto>> GetAll()
        {
            List<Cars> cars = await _context.Cars
                         .Include(x => x.Photo)
                         .Where(x => x.UserId == null && x.IsReserved == false)
                         .ToListAsync();
            if (cars.Count == 0)
            {
                throw new NotFoundException("Cars not found! ");
            }
            List<GetCarsForMemberDto> mappedCar = _mapper.Map<List<GetCarsForMemberDto>>(cars);
            return mappedCar;
        }
        public async Task<CarDto> ReserveCar(ReserveCarForMemberDto dto)
        {
            Cars car = await _context.Cars.FirstOrDefaultAsync(x => x.Vin == dto.Vin);
            if(car.IsReserved || car.UserReservationId != null)
            {
                throw new BadRequestException("This car is reserved! ");
            }
            car.UserReservationId = dto.UserId;
            car.IsReserved = true;
            await _context.SaveChangesAsync();
            CarDto mappedCar = _mapper.Map<CarDto>(car);

            return mappedCar;
        }
    }
}
