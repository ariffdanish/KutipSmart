using KutipSmart.Data;
using KutipSmart.Models;
using Microsoft.AspNetCore.Mvc;

namespace KutipSmart.Controllers
{
    public class TruckController : Controller
    {
        private readonly KutipDbContext _context;
        public TruckController(KutipDbContext context)
        {
            _context = context;
        }

        public IActionResult Index() 
        {
            List<Truck> trucks = _context.Trucks.ToList();
            return View(trucks);
        }
    }
}
