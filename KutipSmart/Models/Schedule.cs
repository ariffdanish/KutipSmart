using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KutipSmart.Models
{
    public class Schedule
    {
        [Key]
        public int ScheduleId { get; set; }

        [Required]
        [Display(Name = "Bin")]
        public int BinId { get; set; }

        [Required]
        [Display(Name = "Truck")]
        public int TruckId { get; set; }

        [Required]
        [Display(Name = "Scheduled Date and Time")]
        public DateTime ScheduledDateTime { get; set; }

        public string Status { get; set; } = "Scheduled";

        // Navigation Properties
        [ForeignKey("BinId")]
        public virtual Bin Bin { get; set; }

        [ForeignKey("TruckId")]
        public virtual Truck Truck { get; set; }
    }
}
