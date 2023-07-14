using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TruckAplication.Data;
using TruckAplication.Models;

namespace TruckAplication.Pages.Requests
{
    public class IndexModel : PageModel
    {
        private readonly TruckAplication.Data.TruckAplicationContext _context;

        public IndexModel(TruckAplication.Data.TruckAplicationContext context)
        {
            _context = context;
        }

        public IList<Request> Request { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Request != null)
            {
                Request = await _context.Request
                .Include(r => r.Client)
                .Include(r => r.Truck)
                .ThenInclude(r => r.Driver)

                .ToListAsync();
            }
        }
    }
}
