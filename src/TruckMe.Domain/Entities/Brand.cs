namespace TruckMe.Domain.Entities
{
    using System.Collections.Generic;

    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<VehicleModel> Vehicles { get; private set; } = new List<VehicleModel>();
    }
}
