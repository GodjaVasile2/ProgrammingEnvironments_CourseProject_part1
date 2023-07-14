using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TruckAplication.Data;
using TruckAplication.Models;

namespace TruckAplication.Pages.Requests
{
    public class CreateModel : PageModel
    {
        private readonly TruckAplication.Data.TruckAplicationContext _context;

        public CreateModel(TruckAplication.Data.TruckAplicationContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var truckList = _context.Truck
                .Include(b => b.Driver)
                .Select(x => new { x.ID, TruckFullName = x.Model + " - " + x.Driver.DriverName });
            ViewData["TruckID"] = new SelectList(truckList, "ID", "TruckFullName");
            ViewData["ClientID"] = new SelectList(_context.Client, "ID", "FullName");
        
            return Page();
        }

        [BindProperty]
        public Request Request { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Request.Add(Request);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
