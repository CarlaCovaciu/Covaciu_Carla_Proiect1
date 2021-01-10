using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covaciu_Carla_Proiect1.Models
{
    public class LaptopCategory
    {
        public int ID { get; set; }
        public int LaptopID { get; set; }
        public Laptop Laptop { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
