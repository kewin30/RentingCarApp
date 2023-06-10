using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RentingCarsApi.DTO.GetDtos;
using RentingCarsApi.DTO.PostPut_Dtos;
using RentingCarsApi.Entity;
using RentingCarsApi.Exceptions;
using RentingCarsApi.Services;

namespace RentingCarsApi.ControllerServices.Account
{
    public interface IAccountService
    {
        Task<UserDto> RegisterUser(RegisterDto dto);
        Task<UserDto> LoginUser(LoginDto dto);
    }
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public AccountService(UserManager<AppUser> userManager, ITokenService tokenService, IMapper mapper)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _mapper = mapper;
            var userValidator = _userManager.UserValidators.FirstOrDefault(v => v.GetType() == typeof(UserValidator<AppUser>));
        }

        public async Task<UserDto> RegisterUser(RegisterDto dto)
        {
            if (await UserDataExists(dto)) throw new BadRequestException("Some of the data is taken");

            AppUser user = _mapper.Map<AppUser>(dto);

            user.UserName = dto.Login.ToLower();
            user.Email = dto.Email.ToLower();
            user.Gender = dto.Gender.ToLower();

            var result = await _userManager.CreateAsync(user, dto.Password);
            string errors = result.Errors.ToString();
            if (!result.Succeeded) throw new BadRequestException(errors);

            var roleResult = await _userManager.AddToRoleAsync(user, "Member");

            if (!roleResult.Succeeded) throw new BadRequestException(errors);

            return new UserDto
            {
                Login = user.UserName,
                Username = user.UserName,
                LastName = user.LastName,
                Token = await _tokenService.CreateToken(user),
                Gender = user.Gender,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
            };
        }

        public async Task<UserDto> LoginUser(LoginDto dto)
        {
            var user = await _userManager.Users
                        .FirstOrDefaultAsync(x => x.UserName == dto.Login.ToLower());
            if (user is null) throw new UnauthorizedException("Invalid login");
            var result = await _userManager.CheckPasswordAsync(user, dto.Password);

            if (!result) throw new UnauthorizedException("Invalid Password");

            UserDto userDto = new UserDto
            {
                Login = user.UserName,
                Username = user.UserName,
                LastName = user.LastName,
                Token = await _tokenService.CreateToken(user),
                Gender = user.Gender,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
            };
            return userDto;
        }

        private async Task<bool> UserDataExists(RegisterDto dto)
        {
            return await _userManager.Users.AnyAsync(x =>
                        x.Email == dto.Email.ToLower() ||
                        x.Pesel == dto.Pesel.ToLower() ||
                        x.IdNumber == dto.IdNumber.ToLower() ||
                        x.UserName == dto.Login.ToLower());
        }
    }
}
