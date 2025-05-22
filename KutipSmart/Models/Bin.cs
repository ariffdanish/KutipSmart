using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace KutipSmart.Models
{
    public class Bin
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Bin")]
        public string BinNo { get; set; }

        [Display(Name = "Street")]
        public string Street {  get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "State")]
        public string State { get; set; }

        [Display(Name = "PostCode")]
        public string PostCode {  get; set; }

        [Display(Name = "Created")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
