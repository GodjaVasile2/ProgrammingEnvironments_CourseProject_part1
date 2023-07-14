using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TruckAplication.Data;
using TruckAplication.Migrations;
using TruckAplication.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace TruckAplication.Pages.Trucks
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : TruckCategoriesPageModel

    {
        private readonly TruckAplication.Data.TruckAplicationContext _context;

        public CreateModel(TruckAplication.Data.TruckAplicationContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["DriverID"] = new SelectList(_context.Set<Models.Driver>(), "ID", "DriverName");

            var truck = new Truck();
            truck.TruckCategories = new List<Models.TruckCategory>();
            PopulateAssignedCategoryData(_context, truck);

            return Page();
        }

        [BindProperty]
        public Truck Truck { get; set; }


        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newTruck = new Truck();
            if (selectedCategories != null)
            {

                if (!string.IsNullOrEmpty(Truck.Picture))
                {
                    string imagesFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images");
                    string imagePath = Path.Combine(imagesFolder, Truck.Picture);
                    if (!System.IO.File.Exists(imagePath))
                    {
                        ModelState.AddModelError("Truck.Picture", "The specified image does not exist.");
                    }
                }

                newTruck.TruckCategories = new List<Models.TruckCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new Models.TruckCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newTruck.TruckCategories.Add(catToAdd);
                }
            }
            Truck.TruckCategories = newTruck.TruckCategories;
            _context.Truck.Add(Truck);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
       

    }
}
