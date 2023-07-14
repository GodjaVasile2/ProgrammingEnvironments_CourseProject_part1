using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TruckAplication.Data;
using TruckAplication.Models;

namespace TruckAplication.Pages.Drivers
{
    public class DetailsModel : PageModel
    {
        private readonly TruckAplication.Data.TruckAplicationContext _context;

        public DetailsModel(TruckAplication.Data.TruckAplicationContext context)
        {
            _context = context;
        }

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
    }
}
