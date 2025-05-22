﻿using System.ComponentModel.DataAnnotations;
using System.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace KutipSmart.Models
{
    
    public class Truck
    {
        [Key]
        public int TruckId { get; set; }
        [Display(Name = "Truck No")]
        [Required]
        [StringValidator(InvalidCharacters = "~!@#$%^&*()_+`-={}|[]:;\"'<>,.?/\\")]
        [StringLength(10)]
        public string TruckNo { get; set; }
        [Display(Name = "Status")]
        public TruckStatus Status { get; set; } = TruckStatus.Active;
        [Display(Name = "Driver")]
        [Required]
        [StringLength(100)]
        public string DriverName { get; set; }
        [Display(Name = "Phone")]
        [Required]
        [StringLength(15)]
        [RegularExpression(@"^\+?[0-9]*$", ErrorMessage = "Phone number must be numeric.")]
        public string Phone { get; set; }
        [Display(Name = "Company")]
        [Required]
        [StringLength(100)]
        public string Company { get; set; }
        [Display(Name ="Created")]
        public DateTimeOffset CreatedAt { get; set; } = DateTime.Now;
        public DateTimeOffset UpdatedAt { get; set; } = DateTime.Now;

    }

    public enum TruckStatus
    {
        Active,
        Inactive, // Truck malfunctioning
        Maintenance
    }
}
