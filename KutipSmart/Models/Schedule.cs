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
        [EnumDataType(typeof(ScheduleStatus))]
        public ScheduleStatus Status { get; set; } = ScheduleStatus.Scheduled;

        [Display(Name = "Created")]
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;

        [Display(Name = "Last Updated")]
        public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.Now;

        // Navigation properties
        [ForeignKey("BinId")]
        public virtual Bin Bin { get; set; }
        

        [ForeignKey("TruckId")]
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
