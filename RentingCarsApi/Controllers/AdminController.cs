using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using RentingCarsApi.ControllerServices.Admin;
using RentingCarsApi.Data;
using RentingCarsApi.DTO.GetDtos;
using RentingCarsApi.DTO.PostPut_Dtos;
using RentingCarsApi.Entity;
using RentingCarsApi.Exceptions;
using RentingCarsApi.Helpers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RentingCarsApi.Controllers
{

    [Authorize(Policy = "RequireAdminRole")]
    public class AdminController : BaseApiController
    {
        private readonly ICarService _carService;

        public AdminController(ICarService carService)
        {
            _carService = carService;
        }
        [HttpPost("add-car-with-photo")]
        public async Task<ActionResult> AddNewCar()
        {
            await _carService.AddNewCar();
            return Ok("Car has been succesfully added to the database");
        }
        [HttpGet("{vin}")]
        public async Task<ActionResult<GetCarWithPhoto>> GetCar([FromRoute] string vin)
        {
            return Ok(await _carService.GetCar(vin));
        }
        [HttpGet("user/{id}")]
        public async Task<ActionResult<GetWholeUser>> GetWholeUser(int id)
        {
            return Ok(await _carService.GetUser(id));
        }
        [HttpGet("payment/{vin}")]
        public async Task<ActionResult<GetPaymentFromCar>> GetPayment(string vin)
        {
            return Ok(await _carService.GetPayment(vin));
        }
        [HttpGet("userBefore/{vin}")]
        public async Task<ActionResult<GetUserBeforeDto>> GetUserBefore(string vin)
        {
            return Ok(await _carService.GetUserBefore(vin));
        }
        [HttpPut("pay-for-the-car/{vin}")]
        public async Task<ActionResult<GetPaymentFromCar>> PayForTheCar(string vin)
        {
            return Ok(await _carService.PayForTheCar(vin));
        }
        [HttpPut("rent-the-car")]
        public async Task<ActionResult<GetPaymentFromCar>> RentTheCar([FromBody] RentTheCarDto dto)
        {
            return Ok(await _carService.RentTheCar(dto));
        }

    }
}
