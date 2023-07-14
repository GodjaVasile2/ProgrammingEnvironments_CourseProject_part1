using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System.Security.Policy;

namespace TruckAplication.Models
{
    public class Truck
    {
        public int ID { get; set; }
        [Display(Name = "Model Name")]
        public string Model { get; set; }
        public string Brand { get; set; }
        
        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime AvailableDate { get; set; }
        public string Picture { get; set; }
        public int? DriverID { get; set; }
        public  Driver? Driver { get; set; }

        public ICollection<TruckCategory>? TruckCategories { get; set; }


    }
}
