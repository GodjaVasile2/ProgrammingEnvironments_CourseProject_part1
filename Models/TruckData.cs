using TruckAplication.Migrations;

namespace TruckAplication.Models
{
    public class TruckData
    {
        public IEnumerable<Truck> Trucks { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<TruckCategory> TruckCategories { get; set; }
    }
}
