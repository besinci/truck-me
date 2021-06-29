using System.ComponentModel.DataAnnotations.Schema;

namespace TruckMe.Core
{
    public class Model
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        
        [ForeignKey("BrandId")]
        public Brand Brand { get; set; }

        public string Name { get; set; }
    }
}
