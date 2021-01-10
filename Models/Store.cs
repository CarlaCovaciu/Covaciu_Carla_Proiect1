using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covaciu_Carla_Proiect1.Models
{
    public class Store
    {
        public int ID { get; set; }
        public string StoreName { get; set; }
        public ICollection<Laptop> Laptops{ get; set; }
    }
}
