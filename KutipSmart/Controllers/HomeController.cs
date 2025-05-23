using System.Diagnostics;
using KutipSmart.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KutipSmart.Data;

namespace KutipSmart.Controllers
{
    public class HomeController : Controller
    {
        private readonly KutipDbContext _context;

            public HomeController(KutipDbContext context)
        {
            _context = context;
        }

            public async Task<IActionResult> IndexAsync()
        {
            var trucks = await _context.Trucks.ToListAsync();
            return View(trucks);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
