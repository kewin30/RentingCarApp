using AutoMapper;
using RentingCarsApi.DTO.GetDtos;
using RentingCarsApi.DTO.PostPut_Dtos;
using RentingCarsApi.Entity;

namespace RentingCarsApi.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<RegisterDto, AppUser>()
          .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth.Value))
          .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
          .ForMember(dest => dest.Address, opt => opt.MapFrom(src => new Address
          {
              City = src.City,
              Country = src.Country,
              Street = src.Street,
              HouseNumber = src.HouseNumber,
              ZipCode = src.ZipCode
          }));
            CreateMap<Cars, CarDto>();
            CreateMap<Cars, GetCarsForMemberDto>()
                .ForMember(dest => dest.Url, opt => opt.MapFrom(src => src.Photo.Url));
            CreateMap<Cars, GetPaymentFromCar>();
            CreateMap<CarDto, Cars>();
            CreateMap<AppUser, GetUserBeforeDto>()
                .ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address));
            CreateMap<AppUser, GetWholeUser>()
            .ForMember(dest => dest.Cars, opt => opt.MapFrom(src => src.Cars))
            .ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.UserName));
            CreateMap<Cars, GetCarWithPhoto>()
              .ForMember(dest => dest.Url, opt => opt.MapFrom(src => src.Photo.Url))
              .ForMember(dest => dest.User, opt => opt.MapFrom(src => new GetUserDto
              {
                  Login = src.User.UserName,
                  Username = src.User.UserName,
                  LastName = src.User.LastName,
                  Gender = src.User.Gender,
                  Email = src.User.Email,
                  PhoneNumber = src.User.PhoneNumber,
              }));


        }

    }
}
