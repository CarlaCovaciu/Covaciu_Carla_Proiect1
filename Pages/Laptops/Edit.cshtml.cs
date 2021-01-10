using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Covaciu_Carla_Proiect1.Data;
using Covaciu_Carla_Proiect1.Models;

namespace Covaciu_Carla_Proiect1.Pages.Laptops
{
    public class EditModel : LaptopCategoriesPageModel
    {
        private readonly Covaciu_Carla_Proiect1.Data.Covaciu_Carla_Proiect1Context _context;

        public EditModel(Covaciu_Carla_Proiect1.Data.Covaciu_Carla_Proiect1Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Laptop Laptop { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Laptop = await _context.Laptop
            .Include(b => b.Store)
            .Include(b => b.LaptopCategories).ThenInclude(b => b.Category)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.ID == id);
            if (Laptop == null)
            {
                return NotFound();
            }

            PopulateAssignedCategoryData(_context, Laptop);
            ViewData["StoreID"] = new SelectList(_context.Store, "ID", "StoreName");
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var laptopToUpdate = await _context.Laptop
            .Include(i => i.Store)
            .Include(i => i.LaptopCategories)
            .ThenInclude(i => i.Category)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (laptopToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Laptop>(
            laptopToUpdate,
            "Laptop",
            i => i.Brand, i => i.Model,
            i => i.Price, i => i.ReleaseDate, i => i.Store))
            {
                UpdateLaptopCategories(_context, selectedCategories, laptopToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            UpdateLaptopCategories(_context, selectedCategories, laptopToUpdate);
            PopulateAssignedCategoryData(_context, laptopToUpdate);
            return Page();
        }
    }
}

