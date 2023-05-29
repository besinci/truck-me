using Microsoft.AspNetCore.Mvc;
using TruckMe.API.Models;

namespace TruckMe.API.Controllers;

[ApiController]
[Route("[controller]")]
public class VehicleController : ControllerBase
{
    private static readonly List<Brand> brands = new List<Brand>()
    {
        new Brand() { Id = 1, Name = "Honda"},
        new Brand() { Id = 2, Name = "BMW Motorrad"},
    };

    private static readonly List<Vehicle> _vehicles = new List<Vehicle>()
    {
        new Vehicle() { Id = 1, Brand = brands[0], Model = "CRF 250L"},
        new Vehicle() { Id = 2, Brand = brands[0], Model = "NC 750X"},
        new Vehicle() { Id = 3, Brand = brands[1], Model = "1250 GS"},
        new Vehicle() { Id = 4, Brand = brands[0], Model = "Transalp"}
    };

    [HttpGet(Name = "GetVehicles")]
    public IEnumerable<Vehicle> Get()
    {
        return _vehicles;
    }

}

