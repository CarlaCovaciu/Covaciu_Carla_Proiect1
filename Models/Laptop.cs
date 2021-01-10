using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Covaciu_Carla_Proiect1.Models
{
    public class Laptop
    {
        public int ID { get; set; }

        [Required, StringLength(150, MinimumLength = 3)]
        [Display(Name = "Brand Name")]
        public string Brand { get; set; }
        public string Model { get; set; }

        [Range(1, 30000)]
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        public int StoreID { get; set; }
        public Store Store { get; set; }

        public ICollection<LaptopCategory> LaptopCategories { get; set; }

    }
}
