namespace TruckAplication.Models
{
    public class TruckCategory
    {
        public int ID { get; set; }
        public int TruckID { get; set; }
        public Truck Truck { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
