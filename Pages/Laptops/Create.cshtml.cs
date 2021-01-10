using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Covaciu_Carla_Proiect1.Data;
using Covaciu_Carla_Proiect1.Models;

namespace Covaciu_Carla_Proiect1.Pages.Laptops
{
    public class CreateModel : LaptopCategoriesPageModel
    {
        private readonly Covaciu_Carla_Proiect1.Data.Covaciu_Carla_Proiect1Context _context;

        public CreateModel(Covaciu_Carla_Proiect1.Data.Covaciu_Carla_Proiect1Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["StoreID"] = new SelectList(_context.Set<Store>(), "ID", "StoreName");
            var laptop = new Laptop();
            laptop.LaptopCategories = new List<LaptopCategory>();
            PopulateAssignedCategoryData(_context, laptop);
            return Page();
        }

        [BindProperty]
        public Laptop Laptop { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newLaptop = new Laptop();
            if (selectedCategories != null)
            {
                newLaptop.LaptopCategories = new List<LaptopCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new LaptopCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newLaptop.LaptopCategories.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Laptop>(
            newLaptop,
            "Laptop",
            i => i.Brand, i => i.Model,
            i => i.Price, i => i.ReleaseDate, i => i.StoreID))
            {
                _context.Laptop.Add(newLaptop);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCategoryData(_context, newLaptop);
            return Page();
        }
    }
}
