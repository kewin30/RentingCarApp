using RentingCarsApi.Entity;

namespace RentingCarsApi.DTO.GetDtos
{
    public class GetWholeUser
    {
        public DateOnly DateOfBirth { get; set; }
        public string Login { get; set; }
        public string Gender { get; set; }
        public string Pesel { get; set; }
        public string IdNumber { get; set; }
        public string LastName { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public List<CarDto> Cars { get; set; }
    }
}
