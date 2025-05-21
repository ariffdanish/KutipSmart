using Microsoft.AspNetCore.Mvc;
using KutipSmart.Models;
using KutipSmart.Data;
using Microsoft.EntityFrameworkCore;
using KutipSmart.Models;
using System;
using KutipSmart.Models;

namespace ResumeManager_Mrhumi.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly ResumeDbContext _context;

        public ScheduleController(ResumeDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Daily(DateTime? date)
        {
            var targetDate = date ?? DateTime.UtcNow.Date;
            var routes = await _context.Routes
                .Include(r => r.Truck)
                .Where(r => r.ScheduledDate == targetDate)
                .ToListAsync();

            return View(routes);
        }

        [HttpPost]
        public async Task<IActionResult> Reschedule(int routeId, int newTruckId)
        {
            var route = await _context.Routes.FindAsync(routeId);
            if (route == null) return NotFound();

            var truck = await _context.Trucks.FindAsync(newTruckId);
            if (truck?.Status != TruckStatus.Active)
                return Json(new { success = false, message = "Truck is not available" });

            route.IsRescheduled = true;
            route.OriginalTruckId = route.TruckId;
            route.TruckId = newTruckId;

            await _context.SaveChangesAsync();
            return Json(new { success = true });
        }
    }
}