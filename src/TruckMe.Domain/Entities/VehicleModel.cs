namespace TruckMe.Domain.Entities
{
    public class VehicleModel
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
    }
}
