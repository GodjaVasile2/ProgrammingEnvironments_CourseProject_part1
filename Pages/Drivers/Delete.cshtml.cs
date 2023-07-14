using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TruckAplication.Data;
using TruckAplication.Models;

namespace TruckAplication.Pages.Drivers
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
        private readonly TruckAplication.Data.TruckAplicationContext _context;

        public DeleteModel(TruckAplication.Data.TruckAplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Driver Driver { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Driver == null)
            {
                return NotFound();
            }

            var driver = await _context.Driver.FirstOrDefaultAsync(m => m.ID == id);

            if (driver == null)
            {
                return NotFound();
            }
            else 
            {
                Driver = driver;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Driver == null)
            {
                return NotFound();
            }
            var driver = await _context.Driver.FindAsync(id);

            if (driver != null)
            {
                Driver = driver;
                _context.Driver.Remove(Driver);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
