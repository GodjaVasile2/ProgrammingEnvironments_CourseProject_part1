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

namespace TruckAplication.Pages.Trucks
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
      public Truck Truck { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Truck == null)
            {
                return NotFound();
            }

            var truck = await _context.Truck.FirstOrDefaultAsync(m => m.ID == id);

            if (truck == null)
            {
                return NotFound();
            }
            else 
            {
                Truck = truck;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Truck == null)
            {
                return NotFound();
            }
            var truck = await _context.Truck.FindAsync(id);

            if (truck != null)
            {
                Truck = truck;
                _context.Truck.Remove(Truck);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
