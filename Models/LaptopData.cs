using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covaciu_Carla_Proiect1.Models
{
    public class LaptopData
    {
        public IEnumerable<Laptop> Laptops { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<LaptopCategory> LaptopCategories { get; set; }
    }
}
