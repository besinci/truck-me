using System.Collections;
using System.Collections.Generic;

namespace TruckMe.Core
{
    public class Brand
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Href { get; set; }
        public ICollection<Model> Models { get; set; }
    }
}
