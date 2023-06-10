using AutoMapper;
using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentingCarsApi.ControllerServices.Account;
using RentingCarsApi.DTO.GetDtos;
using RentingCarsApi.DTO.PostPut_Dtos;
using RentingCarsApi.Entity;
using RentingCarsApi.Services;

namespace RentingCarsApi.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register([FromBody] RegisterDto registerDto)
        {
            return await _accountService.RegisterUser(registerDto);
        }
        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login([FromBody] LoginDto loginDto)
        {
            return await _accountService.LoginUser(loginDto);
        }
    }
}
