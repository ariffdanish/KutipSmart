using System.ComponentModel.DataAnnotations;

namespace KutipSmart.Models
{
    public class Truck
    {
        [Key]
        public int TruckId { get; set; }
        [Display(Name = "Truck No")]
        public string TruckNo { get; set; }
        [Display(Name = "Driver")]
        public string DriverName { get; set; }
        [Display(Name = "Phone")]
        public string Phone { get; set; }
        [Display(Name = "Company")]
        public string Company { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

    }
}
