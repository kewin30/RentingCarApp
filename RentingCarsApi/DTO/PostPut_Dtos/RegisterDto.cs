using System.ComponentModel.DataAnnotations;

namespace RentingCarsApi.DTO.PostPut_Dtos
{
    public class RegisterDto
    {
        [Required] public string Login { get; set; }
        [Required] public string Gender { get; set; }
        [Required] public DateOnly? DateOfBirth { get; set; }
        [Required] public string City { get; set; }
        [Required] public string Country { get; set; }
        [Required] public string Street { get; set; }
        [Required] public string HouseNumber { get; set; }
        [Required] public string ZipCode { get; set; }
        [Required] public string IdNumber { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Pesel { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 4)]
        public string Password { get; set; }
    }
}
