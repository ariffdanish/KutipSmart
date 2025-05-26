using System;
using System.ComponentModel.DataAnnotations;

namespace KutipSmart.Models
{
    public class Schedule
    {
        [Key]
        public int ScheduleId { get; set; }

        [Required]
        [Display(Name = "Bin Name")]
        public string BinName { get; set; }

        [Required]
        [Display(Name = "Collector Name")]
        public string CollectorName { get; set; }

        [Required]
        [Display(Name = "Scheduled Date and Time")]
        [DataType(DataType.DateTime)]
        public DateTime ScheduledDateTime { get; set; }

        public string Status { get; set; } = "Scheduled";
    }
}
