using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using RentingCarsApi.Data;
using RentingCarsApi.DTO.Configurations;
using RentingCarsApi.Services;
using RentingCarsApi.Middleware;
using RentingCarsApi.ControllerServices.Admin;
using RentingCarsApi.ControllerServices.Member;
using RentingCarsApi.DTO.PostPut_Dtos;
using RentingCarsApi.DTO.GetDtos;
using RentingCarsApi.ControllerServices.Account;

namespace RentingCarsApi.Helpers
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config) 
        {
            services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();

            services.AddTransient<IValidator<RegisterDto>, RegisterDtoValidator>();
            services.AddTransient<IValidator<CarDto>, CarDtoValidator>();
            services.Configure<CloudinarySettings>(config.GetSection("CloudinarySettings"));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddDbContext<RentingDbContext>(opt => { opt.UseSqlServer(config.GetConnectionString("DefaultConnection"), x => x.UseDateOnlyTimeOnly()); });
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IPhotoFactory, PhotoFactory>();
            services.AddScoped<IPhotoService, PhotoService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IMemberService, MemberService>();
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<ICatchCarExceptions, CatchCarExceptions>();
            services.AddScoped<ErrorHandlingMiddleware>();
            services.AddScoped<ICarManagerDependencies, CarManagerDependencies>();


            return services;
        }
    }
}
