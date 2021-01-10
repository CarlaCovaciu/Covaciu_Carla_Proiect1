using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Covaciu_Carla_Proiect1.Data;

namespace Covaciu_Carla_Proiect1.Models
{
    public class LaptopCategoriesPageModel : PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(Covaciu_Carla_Proiect1Context context, Laptop Laptop)
        {
            var allCategories = context.Category;
            var laptopCategories = new HashSet<int>(Laptop.LaptopCategories.Select(c => c.LaptopID));
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = laptopCategories.Contains(cat.ID)
                });
            }
        }
        public void UpdateLaptopCategories(Covaciu_Carla_Proiect1Context context,
        string[] selectedCategories, Laptop LaptopToUpdate)
        {
            if (selectedCategories == null)
            {
                LaptopToUpdate.LaptopCategories = new List<LaptopCategory>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var laptopCategories = new HashSet<int>
            (LaptopToUpdate.LaptopCategories.Select(c => c.Category.ID));
            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!laptopCategories.Contains(cat.ID))
                    {
                        LaptopToUpdate.LaptopCategories.Add(
                        new LaptopCategory
                        {
                            LaptopID = LaptopToUpdate.ID,
                            CategoryID = cat.ID
                        });
                    }
                }
                else
                {
                    if (laptopCategories.Contains(cat.ID))
                    {
                        LaptopCategory courseToRemove = LaptopToUpdate.LaptopCategories.SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
