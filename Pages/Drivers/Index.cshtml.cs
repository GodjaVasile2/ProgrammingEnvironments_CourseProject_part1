using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TruckAplication.Data;
using TruckAplication.Models;
using TruckAplication.Models.ViewModels;

namespace TruckAplication.Pages.Drivers
{
    public class IndexModel : PageModel
    {
        private readonly TruckAplication.Data.TruckAplicationContext _context;

        public IndexModel(TruckAplication.Data.TruckAplicationContext context)
        {
            _context = context;
        }

        public IList<Driver> Driver { get; set; } = default!;

        public DriverIndexData DriverData { get; set; }
        public int DriverID { get; set; }
        public int TruckID { get; set; }

        public async Task OnGetAsync(int? id, int? bookID)
        {
            DriverData = new DriverIndexData();
            DriverData.Drivers = await _context.Driver
            .Include(i => i.Trucks)

            .OrderBy(i => i.DriverName)
            .ToListAsync();
            if (id != null)
            {
                DriverID = id.Value;
                Driver driver = DriverData.Drivers
                .Where(i => i.ID == id.Value).Single();
                DriverData.Trucks = driver.Trucks;
            }
            //if (_context.Driver != null)
            //{
            //  Driver = await _context.Driver.ToListAsync();
            //}
        }
    }
}