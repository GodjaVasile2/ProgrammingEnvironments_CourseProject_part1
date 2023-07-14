using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TruckAplication.Data;
using TruckAplication.Models;

namespace TruckAplication.Pages.Trucks
{
    public class DetailsModel : PageModel
    {
        private readonly TruckAplication.Data.TruckAplicationContext _context;

        public DetailsModel(TruckAplication.Data.TruckAplicationContext context)
        {
            _context = context;
        }

      public Truck Truck { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Truck == null)
            {
                return NotFound();
            }

            var truck = await _context.Truck
                .Include(b => b.Driver)
                .FirstOrDefaultAsync(m => m.ID == id);
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
    }
}
