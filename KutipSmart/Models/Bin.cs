using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace KutipSmart.Models
{
    public class Bin
    {
        [Key]
        public int BinId { get; set; }

        [Required(ErrorMessage = "Bin Number is required")]
        [Display(Name = "Bin")]
        public string BinNo { get; set; }

        [Required(ErrorMessage = "Street is required")]
        [Display(Name = "Street")]
        public string Street { get; set; }

        [Required(ErrorMessage = "City is required")]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required(ErrorMessage = "State is required")]
        [Display(Name = "State")]
        public string State { get; set; }

        [Required(ErrorMessage = "PostCode is required")]
        [Display(Name = "PostCode")]
        public string PostCode { get; set; }

        [Display(Name = "Created")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
