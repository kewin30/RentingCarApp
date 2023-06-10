using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RentingCarsApi.Data;
using RentingCarsApi.Entity;
using System.Text.Json;

namespace RentingCarsApi.Helpers
{
    public class Seed
    {
        public static async Task SeedCars(RentingDbContext dbContext)
        {
            List<Cars> carList = new List<Cars>
            {
                new Cars
                {
                    Vin = "ABCD1234",
                    GpsEnabled = true,
                    Plate = "GWE51243",
                    Model = "Tesla Model S",
                    CarYear = 2023,
                    Color = "Red",
                    Weight = 2000,
                    PrizeForDay = 100,
                    PrizeForWeek = 600,
                    Availability = true,
                    Place = "Alcudia",
                    IsReserved = false,
                    Photo = new Photo
                    {
                        Url = "https://res.cloudinary.com/dgvkufgtr/image/upload/v1686415663/da-net7/qxmulm8wy8lbob67dqi6.jpg",
                        PublicId = "da-net7/aiw9ndrp0usevh0fe2sk"
                    }
                },
                new Cars
                {
                    Vin = "AGHA1234",
                    GpsEnabled = true,
                    Plate = "GDA51243",
                    Model = "Tesla Model X",
                    CarYear = 2023,
                    Color = "White",
                    Weight = 2000,
                    PrizeForDay = 150,
                    PrizeForWeek = 900,
                    Availability = true,
                    Place = "Alcudia",
                    IsReserved = false,
                    Photo = new Photo
                    {
                        Url = "https://res.cloudinary.com/dgvkufgtr/image/upload/v1686415682/da-net7/hnqfsbxk4fzvnf6bizrs.jpg",
                        PublicId = "da-net7/aiw9ndrp0usevhjaka01"
                    }
                },
                new Cars
                {
                    Vin = "AGLK01924",
                    GpsEnabled = true,
                    Plate = "GDA51243",
                    Model = "Tesla Model 3",
                    CarYear = 2023,
                    Color = "White",
                    Weight = 2400,
                    PrizeForDay = 200,
                    PrizeForWeek = 1200,
                    Availability = true,
                    Place = "Alcudia",
                    IsReserved = false,
                    Photo = new Photo
                    {
                        Url = "https://res.cloudinary.com/dgvkufgtr/image/upload/v1686415751/da-net7/cbdt2pq302c8r50rc694.jpg",
                        PublicId = "da-net7/aiw9n0ajdka12usevhjaka01"
                    }
                }
            };


            if (!await dbContext.Cars.AnyAsync())
            {
                await dbContext.Cars.AddRangeAsync(carList);

                await dbContext.SaveChangesAsync();
            }

        }

        public static async Task SeedUsers(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {

            var roles = new List<AppRole>
            {
                new AppRole{Name = "Member"},
                new AppRole{Name = "Admin"}
            };

            foreach (var role in roles)
            {
                await roleManager.CreateAsync(role);
            }

            var admin = new AppUser
            {
                UserName = "admin",
                Name = "admin",
                Gender = "male",
                Pesel = "Admin",
                IdNumber = "Admin",
                LastName = "Admin",
                PhoneNumber = "Admin",
                Address = new Address()
                {
                    ZipCode = "Admin",
                    Country = "Admin",
                    City = "Admin",
                    Street = "Admin",
                    HouseNumber = "Admin"
                }
            };
            var user = new AppUser
            {
                UserName = "Kewin",
                Name = "Kewin",
                Gender = "male",
                Pesel = "10293847561",
                IdNumber = "MVC",
                LastName = "Patelczyk",
                PhoneNumber = "123456789",
                Address = new Address()
                {
                    ZipCode = "50-875",
                    Country = "Poland",
                    City = "Gdynia",
                    Street = "Polna",
                    HouseNumber = "90/5B"
                }
            };

            await userManager.CreateAsync(admin, "Pa$$w0rd");
            await userManager.CreateAsync(user, "Pa$$w0rd");
            await userManager.AddToRolesAsync(admin, new[] { "Admin" });
            await userManager.AddToRolesAsync(user, new[] { "Member" });
        }
    }
}
