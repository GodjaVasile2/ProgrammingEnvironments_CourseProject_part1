using System.Security.Policy;
using TruckAplication.Models;


namespace TruckAplication.Models.ViewModels
{
    public class DriverIndexData
    {
        public IEnumerable<Driver> Drivers { get; set; }
        public IEnumerable<Truck> Trucks { get; set; }
    }
}
