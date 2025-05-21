namespace KutipSmart.Models
{
    public class Truck
    {
        public int TruckId { get; set; }
        public string TruckNo { get; set; }
        public string DriverName { get; set; }
        public string Phone { get; set; }
        public string Company { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

    }
}
