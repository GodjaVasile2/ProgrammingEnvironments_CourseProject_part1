using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TruckAplication.Data;
using TruckAplication.Models;

namespace TruckAplication.Pages.Clients
{
    public class IndexModel : PageModel
    {
        private readonly TruckAplication.Data.TruckAplicationContext _context;

        public IndexModel(TruckAplication.Data.TruckAplicationContext context)
        {
            _context = context;
        }

        public IList<Client> Client { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Client != null)
            {
                Client = await _context.Client.ToListAsync();
            }
        }
    }
}
