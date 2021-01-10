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
    public class IndexModel : PageModel
    {
        private readonly Covaciu_Carla_Proiect1.Data.Covaciu_Carla_Proiect1Context _context;

        public IndexModel(Covaciu_Carla_Proiect1.Data.Covaciu_Carla_Proiect1Context context)
        {
            _context = context;
        }

        public IList<Store> Store { get;set; }

        public async Task OnGetAsync()
        {
            Store = await _context.Store.ToListAsync();
        }
    }
}
