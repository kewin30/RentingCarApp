using Microsoft.AspNetCore.Identity;

namespace RentingCarsApi.Entity
{
    public class AppUser : IdentityUser<int>
    {
        public DateOnly DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Pesel { get; set; }
        public string IdNumber { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public List<Cars> Cars { get; set; }
        public Cars ReservedCar { get; set; }

        public ICollection<AppUserRole> UserRoles { get; set; }
    }
}
