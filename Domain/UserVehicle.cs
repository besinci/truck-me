namespace Domain;

public class UserVehicle
{
    public int Id { get; set; }
    public float FuelCapacity { get; set; }
    
    public ushort? Year { get; set; }
    public double? Odometer { get; set; }
    public string? LicencePlate { get; set; }
    public string? VehicleName { get; set; }

    public int UserId { get; set; }
    public int VehicleId { get; set; }
    public int? FuelType { get; set; }
}