namespace TruckAplication.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public ICollection<TruckCategory>? TruckCategories { get; set; }
    }
}
