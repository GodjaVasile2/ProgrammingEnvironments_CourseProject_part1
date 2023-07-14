using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace TruckAplication.Models
{
    public class Request
    {
        public int ID { get; set; }
        public int? ClientID { get; set; }
        public Client? Client { get; set; }
        public int? TruckID { get; set; }
        public Truck? Truck { get; set; }

        [RegularExpression("^[1-9][0-9]{0,2}$")]
        public decimal RentedDays { get; set; }
    }
}
