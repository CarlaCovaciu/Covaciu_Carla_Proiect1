using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Covaciu_Carla_Proiect1.Data;
using Covaciu_Carla_Proiect1.Models;

namespace Covaciu_Carla_Proiect1.Pages.Laptops
{
    public class IndexModel : PageModel
    {
        private readonly Covaciu_Carla_Proiect1.Data.Covaciu_Carla_Proiect1Context _context;

        public IndexModel(Covaciu_Carla_Proiect1.Data.Covaciu_Carla_Proiect1Context context)
        {
            _context = context;
        }

        public IList<Laptop> Laptop { get; set; }

        public LaptopData LaptopD { get; set; }
        public int LaptopID { get; set; }
        public int CategoryID { get; set; }
        public async Task OnGetAsync(int? id, int? categoryID)
        {
            LaptopD = new LaptopData();
            LaptopD.Laptops = await _context.Laptop
            .Include(b => b.Store)
            .Include(b => b.LaptopCategories)
            .ThenInclude(b => b.Category)
            .AsNoTracking()
            .OrderBy(b => b.Brand)
            .ToListAsync();
            if (id != null)
            {
                LaptopID = id.Value;
                Laptop laptop = LaptopD.Laptops
                .Where(i => i.ID == id.Value).Single();
                LaptopD.Categories = laptop.LaptopCategories.Select(s => s.Category);
            }
        }
    }
}
