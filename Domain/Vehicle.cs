using Domain.Enum;

namespace Domain;
public class Vehicle
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int ManufacturerId { get; set; }
    public VehicleType VehicleType { get; set; }
}