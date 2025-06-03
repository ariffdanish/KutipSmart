using KutipSmart.Data;
using KutipSmart.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace KutipSmart.Controllers
{
    public class NotificationsController : Controller
    {
        private readonly KutipDbContext _context;

        public NotificationsController(KutipDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var notifications = await _context.Notifications
                .OrderByDescending(n => n.CreatedAt)
                .ToListAsync();

            foreach (var notif in notifications.Where(n => !n.IsRead))
                notif.IsRead = true;

            await _context.SaveChangesAsync();

            return View(notifications);
        }


        public async Task<IActionResult> MarkAsRead(int id)
        {
            var notif = await _context.Notifications.FindAsync(id);
            if (notif != null)
            {
                notif.IsRead = true;
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }
    }

}
