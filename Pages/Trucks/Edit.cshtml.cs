using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TruckAplication.Data;
using TruckAplication.Models;

namespace TruckAplication.Pages.Trucks
{
    [Authorize(Roles = "Admin")]
    public class EditModel : TruckCategoriesPageModel
    {
        private readonly TruckAplication.Data.TruckAplicationContext _context;

        public EditModel(TruckAplication.Data.TruckAplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Truck Truck { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Truck == null)
            {
                return NotFound();
            }

            Truck = await _context.Truck
                .Include(b => b.Driver)
                .Include(b => b.TruckCategories).ThenInclude(b => b.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            // var truck =  await _context.Truck.FirstOrDefaultAsync(m => m.ID == id);
            if (Truck == null)
            {
                return NotFound();
            }
            //Truck = truck;
            PopulateAssignedCategoryData(_context, Truck);

            ViewData["DriverID"] = new SelectList(_context.Set<Driver>(), "ID", "DriverName");
           
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var truckToUpdate = await _context.Truck
            .Include(i => i.Driver)
            .Include(i => i.TruckCategories)
            .ThenInclude(i => i.Category)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (truckToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Truck>(
            truckToUpdate,
            "Truck",
            i => i.Model,
            i => i.Price, i => i.AvailableDate, i => i.Driver))
            {
                UpdateTruckCategories(_context, selectedCategories, truckToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateTruckCategories pentru a aplica informatiile din checkboxuri la entitatea Trucks care
            //este editata
            UpdateTruckCategories(_context, selectedCategories, truckToUpdate);
            PopulateAssignedCategoryData(_context, truckToUpdate);
            return Page();

            // if (!ModelState.IsValid)
            // {
            //    return Page();
            // }

            //  _context.Attach(Truck).State = EntityState.Modified;

            // try
            // {
            //   await _context.SaveChangesAsync();
            //  }
            // catch (DbUpdateConcurrencyException)
            // {
            //  if (!TruckExists(Truck.ID))
            //  {
            //     return NotFound();
            // }
            //  else
            //  {
            //  throw;
            // }
            // }

            // return RedirectToPage("./Index");
        }

        private bool TruckExists(int id)
        {
            return _context.Truck.Any(e => e.ID == id);
        }
    }
}