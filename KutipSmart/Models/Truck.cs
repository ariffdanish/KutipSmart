using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace KutipSmart.Models
{
    public enum TruckStatus
    {
        Active,
        Inactive, // Truck malfunctioning
        Maintenance
    }

    public class Truck
    {
        [Key]
        public int TruckId { get; set; }
        [Display(Name = "Truck No")]
        public string TruckNo { get; set; }
        [Display(Name = "Driver")]
        public int Id { get; set; }

        public TruckStatus Status { get; set; } = TruckStatus.Active;
        public string DriverName { get; set; }
        [Display(Name = "Phone")]
        public string Phone { get; set; }
        [Display(Name = "Company")]
        public string Company { get; set; }
        [Display(Name ="Created")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

    }
}
