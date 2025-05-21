using Microsoft.AspNetCore.Mvc;

namespace KutipSmart.Models
{
    public class Bin
    {
        public int Id { get; set; }
        public int RouteId { get; set; }
        public Route Route { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Address { get; set; }
        public int Order { get; set; }
        public bool IsCollected { get; set; }
        public bool IsMissed { get; set; }
    }
}
