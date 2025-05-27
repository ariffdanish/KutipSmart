using Microsoft.AspNetCore.Mvc;
using KutipSmart.Models;
using System.Linq;
using System.Collections.Generic;
using KutipSmart.Data;

namespace KutipSmart.Controllers
{
    public class DashboardController : Controller
    {
        private readonly KutipDbContext _context;

        // Constructor to inject the DB context
        public DashboardController(KutipDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Fetch real data from the database
            var bins = _context.Bin.ToList();
            var trucks = _context.Trucks.ToList();

            var model = new DashboardViewModel
            {
                Bins = bins,
                Trucks = trucks
            };

            return View(model);
        }
    }
}

