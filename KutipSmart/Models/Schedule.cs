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
        [Display(Name = "Scheduled Date & Time")]
        public DateTime ScheduledDateTime { get; set; }

        [Required]
        [Display(Name = "Schedule Status")]
        public ScheduleStatus Status { get; set; }

        [Display(Name = "Created")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Display(Name = "Last Updated")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties (must be virtual for lazy loading)
        public virtual Bin Bin { get; set; }
        public virtual Truck Truck { get; set; }
    }

    public enum ScheduleStatus
    {
        Scheduled = 0,
        Completed = 1,
        Missed = 2,
        Reassigned = 3
    }
}
