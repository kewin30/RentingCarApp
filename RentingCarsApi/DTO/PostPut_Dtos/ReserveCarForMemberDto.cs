using System.ComponentModel.DataAnnotations;

namespace RentingCarsApi.DTO.PostPut_Dtos
{
    public class ReserveCarForMemberDto
    {
        [Required]
        public string Vin { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
