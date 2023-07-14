namespace TruckAplication.Models
{
    public class Driver
    {
        public int ID { get; set; }
        public string DriverName { get; set; }
        public string Picture { get; set; }
        public ICollection<Truck>? Trucks { get; set; } 

    }
}
