using Microsoft.AspNetCore.Mvc.RazorPages;
using TruckAplication.Data;
using TruckAplication.Migrations;

namespace TruckAplication.Models
{
    public class TruckCategoriesPageModel:PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(TruckAplicationContext context,
        Truck truck)
        {
            var allCategories = context.Category;
            var truckCategories = new HashSet<int>(
            truck.TruckCategories.Select(c => c.CategoryID)); //
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = truckCategories.Contains(cat.ID)
                });
            }
        }
        public void UpdateTruckCategories(TruckAplicationContext context,
        string[] selectedCategories, Truck truckToUpdate)
        {
            if (selectedCategories == null)
            {
                truckToUpdate.TruckCategories = new List<TruckCategory>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var truckCategories = new HashSet<int>
            (truckToUpdate.TruckCategories.Select(c => c.Category.ID));
            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!truckCategories.Contains(cat.ID))
                    {
                        truckToUpdate.TruckCategories.Add(
                        new TruckCategory
                        {
                            TruckID = truckToUpdate.ID,
                            CategoryID = cat.ID
                        });
                    }
                }
                else
                {
                    if (truckCategories.Contains(cat.ID))
                    {
                        TruckCategory courseToRemove
                        = truckToUpdate
                        .TruckCategories
                        .SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }

}
