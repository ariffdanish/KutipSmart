using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace KutipSmart.Models
{
    public class Route
    {
        public int Id { get; set; }
        public int TruckId { get; set; }
        public Truck Truck { get; set; }
        public DateTime ScheduledDate { get; set; } = DateTime.UtcNow.Date;
        public List<Bin> Bins { get; set; } = new List<Bin>();
        public bool IsRescheduled { get; set; }
        public int? OriginalTruckId { get; set; } // For tracking
    }
}
