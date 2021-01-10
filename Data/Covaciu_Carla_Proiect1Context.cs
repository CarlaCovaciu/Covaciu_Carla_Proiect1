using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Covaciu_Carla_Proiect1.Models;

namespace Covaciu_Carla_Proiect1.Data
{
    public class Covaciu_Carla_Proiect1Context : DbContext
    {
        public Covaciu_Carla_Proiect1Context (DbContextOptions<Covaciu_Carla_Proiect1Context> options)
            : base(options)
        {
        }

        public DbSet<Covaciu_Carla_Proiect1.Models.Laptop> Laptop { get; set; }

        public DbSet<Covaciu_Carla_Proiect1.Models.Store> Store { get; set; }

        public DbSet<Covaciu_Carla_Proiect1.Models.LaptopCategory> LaptopCategory { get; set; }

        public DbSet<Covaciu_Carla_Proiect1.Models.Category> Category { get; set; }
    }
}
