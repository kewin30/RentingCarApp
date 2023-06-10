using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentingCarsApi.ControllerServices.Member;
using RentingCarsApi.DTO.GetDtos;
using RentingCarsApi.DTO.PostPut_Dtos;
using RentingCarsApi.Extensions;

namespace RentingCarsApi.Controllers
{
    [Authorize(Policy = "RequireMemberRole")]
    public class MemberController : BaseApiController
    {
        private readonly IMemberService _memberService;

        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetCarsForMemberDto>>> GetAllCars()
        {
            return Ok(await _memberService.GetAll());
        }
        [HttpPut("{vin}")]
        public async Task<ActionResult<CarDto>> ReserveCar([FromRoute]string vin)
        {
            int id = User.GetUserId();
            ReserveCarForMemberDto dto = new ReserveCarForMemberDto() { Vin = vin, UserId = id };
            return Ok(await _memberService.ReserveCar(dto));
        }
    }
}
