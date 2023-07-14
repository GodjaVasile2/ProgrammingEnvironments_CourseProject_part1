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
    public class IndexModel : PageModel
    {
        private readonly TruckAplication.Data.TruckAplicationContext _context;

        public IndexModel(TruckAplication.Data.TruckAplicationContext context)
        {
            _context = context;
        }

        public IList<Truck> Truck { get; set; } = default!;

        public TruckData TruckD { get; set; }
        public int TruckID { get; set; }
        public int CategoryID { get; set; }
        public string BrandSort { get; set; }
        public string PriceSort { get; set; }
        public string CurrentFilter { get; set; }
        public async Task OnGetAsync(int? id, int? categoryID, string sortOrder, string searchString)
        {
            TruckD = new TruckData();

            BrandSort = String.IsNullOrEmpty(sortOrder) ? "brand_desc" : "";
            PriceSort = String.IsNullOrEmpty(sortOrder) ? "price_desc" : "";
            CurrentFilter = searchString;



            TruckD.Trucks = await _context.Truck
            .Include(b => b.Driver)
            .Include(b => b.TruckCategories)
            .ThenInclude(b => b.Category)
            .AsNoTracking()
            .ToListAsync();

            if (!String.IsNullOrEmpty(searchString))
            {
                TruckD.Trucks = TruckD.Trucks.Where(s => s.Brand.Contains(searchString)

               || s.Brand.Contains(searchString)
               || s.Model.Contains(searchString));


                if (id != null)
                {
                    TruckID = id.Value;
                    Truck truck = TruckD.Trucks
                    .Where(i => i.ID == id.Value).Single();
                    TruckD.Categories = truck.TruckCategories.Select(s => s.Category);
                }

                switch (sortOrder)
                {
                    case "brand_desc":
                        TruckD.Trucks = TruckD.Trucks.OrderByDescending(s =>
                       s.Brand);
                        break;
                    case "price_desc":
                        TruckD.Trucks = TruckD.Trucks.OrderByDescending(s =>
                       s.Price);
                        break;

                }
            }
        }
    }
}
