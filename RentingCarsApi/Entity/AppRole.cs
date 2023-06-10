using Microsoft.AspNetCore.Identity;

namespace RentingCarsApi.Entity
{
    public class AppRole : IdentityRole<int>
    {
        public ICollection<AppUserRole> UserRoles { get; set; }  
    }
}
