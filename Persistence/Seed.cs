using Domain;
using Domain.Enum;
using Microsoft.AspNetCore.Identity;

namespace Persistence;

public class Seed
{
    public static async Task SeedData(DataContext context, 
        UserManager<AppUser> userManager)
    {
        await SeedUsers(userManager);
        await SeedFuelTypes(context);
        await SeedManufacturers(context);
        await SeedVehicles(context);
        await SeedUserVehicles(context, userManager);
        
        await context.SaveChangesAsync();
    }


    private static async Task SeedUsers(UserManager<AppUser> userManager)
    {
        if (userManager.Users.Any() is false)
        {
            var users = new List<AppUser>
            {
                new AppUser
                {
                    DisplayName = "Ali Besinci",
                    UserName = "ali",
                    Email = "alibesinci@pm.me"
                },
                new AppUser
                {
                    DisplayName = "Tom",
                    UserName = "tom",
                    Email = "tom@test.com"
                }
            };

            foreach (var user in users)
                await userManager.CreateAsync(user, "Pa$$w0rd");
        }
    }

    private static async Task SeedFuelTypes(DataContext context)
    {
        if (context.FuelTypes.Any() is false)
        {
            var fuelTypes = new List<FuelType>
            {
                new FuelType
                {
                    Id = 1,
                    Name = "Diesel"
                },
                new FuelType
                {
                    Id = 2,
                    Name = "Gasoline"
                },
                new FuelType
                {
                    Id = 3,
                    Name = "LPG"
                }
            };
            await context.FuelTypes.AddRangeAsync(fuelTypes);
        }
    }

    private static async Task SeedManufacturers(DataContext context)
    {
        if (context.Manufacturers.Any() is false)
        {
            var manufacturers = new List<Manufacturer>
            {
                new Manufacturer
                {
                    Id = 1,
                    Name = "Honda"
                },
                new Manufacturer
                {
                    Id = 2,
                    Name = "Yamaha"
                },
                new Manufacturer
                {
                    Id = 3,
                    Name = "Mercedes"
                }
            };

            await context.Manufacturers.AddRangeAsync(manufacturers);
        }
    }
    
    private static async Task SeedVehicles(DataContext context)
    {
        if (context.Vehicles.Any() is false)
        {
            var vehicles = new List<Vehicle>
            {
                new Vehicle
                {
                    Id = 1,
                    Name = "NC 750X",
                    VehicleType = VehicleType.Motorcycle,
                    ManufacturerId = 1
                },
                new Vehicle
                {
                    Id = 2,
                    Name = "CBF 250",
                    VehicleType = VehicleType.Motorcycle,
                    ManufacturerId = 1
                },
                new Vehicle
                {
                    Id = 3,
                    Name = "Tenere 700",
                    VehicleType = VehicleType.Motorcycle,
                    ManufacturerId = 2
                },
                new Vehicle
                {
                    Id = 4,
                    Name = "E 200",
                    VehicleType = VehicleType.Car,
                    ManufacturerId = 3
                },
            };
        }
    }

    private static async Task SeedUserVehicles(DataContext context, UserManager<AppUser> userManager)
    {
        if (context.UserVehicles.Any() is false)
        {
            var userVehicles = new List<UserVehicle>
            {
                new UserVehicle
                {
                    Id = 1,
                    UserId = userManager.FindByNameAsync("ali").Id,
                    FuelCapacity = 14.1f,
                    FuelType = 2,
                    Odometer = 18467,
                    Year = 2018,
                    LicencePlate = "34AAA123",
                    VehicleId = 1,
                    VehicleName = "Touring bike"
                }
            };

            await context.UserVehicles.AddRangeAsync(userVehicles);
        }
    }
}