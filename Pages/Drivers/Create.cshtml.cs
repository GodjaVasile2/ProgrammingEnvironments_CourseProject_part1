using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TruckAplication.Data;
using TruckAplication.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace TruckAplication.Pages.Drivers
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly TruckAplication.Data.TruckAplicationContext _context;

        public CreateModel(TruckAplication.Data.TruckAplicationContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Driver Driver { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(Driver.Picture))
                {
                    string imagesFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images");
                    string imagePath = Path.Combine(imagesFolder, Driver.Picture);
                    if (!System.IO.File.Exists(imagePath))
                    {
                        ModelState.AddModelError("Driver.Picture", "The specified image does not exist.");
                    }
                }
                return Page();
            }

            _context.Driver.Add(Driver);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
