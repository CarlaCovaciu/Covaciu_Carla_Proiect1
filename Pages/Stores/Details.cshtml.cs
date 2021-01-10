using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Covaciu_Carla_Proiect1.Data;
using Covaciu_Carla_Proiect1.Models;

namespace Covaciu_Carla_Proiect1.Pages.Stores
{
    public class DetailsModel : PageModel
    {
        private readonly Covaciu_Carla_Proiect1.Data.Covaciu_Carla_Proiect1Context _context;

        public DetailsModel(Covaciu_Carla_Proiect1.Data.Covaciu_Carla_Proiect1Context context)
        {
            _context = context;
        }

        public Store Store { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Store = await _context.Store.FirstOrDefaultAsync(m => m.ID == id);

            if (Store == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
