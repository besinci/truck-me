namespace TruckMe.API.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public required Brand Brand { get; set; }
        public required string Model { get; set; }
    }

    public class Brand
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }

    public class UserVehicle
    {
        public int Id { get; set; }
        public List<Vehicle>? Vehicles { get; set; }
        public required string UserName { get; set; }
    }
}
