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
        public string Street {  get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostCode {  get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
