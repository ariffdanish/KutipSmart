using KutipSmart.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class SchedulesController : Controller
{
    private readonly KutipSmart.Data.KutipDbContext _context;

    public SchedulesController(KutipSmart.Data.KutipDbContext context)
    {
        _context = context;
    }

    // GET: Schedules
    public async Task<IActionResult> Index()
    {
        var schedules = _context.Schedules
            .Include(s => s.Bin)
            .Include(s => s.Truck);
        return View(await schedules.ToListAsync());
    }

    // GET: Schedules/Create
    public IActionResult Create()
    {
        ViewData["BinId"] = new SelectList(_context.Bin, "BinId", "Location");
        ViewData["TruckId"] = new SelectList(_context.Trucks, "TruckId", "PlateNumber");
        return View();
    }

    // POST: Schedules/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Schedule schedule)
    {
        if (ModelState.IsValid)
        {
            _context.Schedules.Add(schedule);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        ViewData["BinId"] = new SelectList(_context.Bin, "BinId", "Location", schedule.BinId);
        ViewData["TruckId"] = new SelectList(_context.Trucks, "TruckId", "PlateNumber", schedule.TruckId);
        return View(schedule);
    }

    // GET: Schedules/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();

        var schedule = await _context.Schedules.FindAsync(id);
        if (schedule == null) return NotFound();

        ViewData["BinId"] = new SelectList(_context.Bin, "BinId", "Location", schedule.BinId);
        ViewData["TruckId"] = new SelectList(_context.Trucks, "TruckId", "PlateNumber", schedule.TruckId);
        return View(schedule);
    }

    // POST: Schedules/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Schedule schedule)
    {
        if (id != schedule.ScheduleId) return NotFound();

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(schedule);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Schedules.Any(e => e.ScheduleId == id))
                    return NotFound();
                else
                    throw;
            }

            return RedirectToAction(nameof(Index));
        }

        ViewData["BinId"] = new SelectList(_context.Bin, "BinId", "Location", schedule.BinId);
        ViewData["TruckId"] = new SelectList(_context.Trucks, "TruckId", "PlateNumber", schedule.TruckId);
        return View(schedule);
    }

    // GET: Schedules/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var schedule = await _context.Schedules
            .Include(s => s.Bin)
            .Include(s => s.Truck)
            .FirstOrDefaultAsync(m => m.ScheduleId == id);

        if (schedule == null) return NotFound();

        return View(schedule);
    }

    // POST: Schedules/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var schedule = await _context.Schedules.FindAsync(id);
        if (schedule != null)
        {
            _context.Schedules.Remove(schedule);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }

    // GET: Schedules/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();

        var schedule = await _context.Schedules
            .Include(s => s.Bin)
            .Include(s => s.Truck)
            .FirstOrDefaultAsync(m => m.ScheduleId == id);

        if (schedule == null) return NotFound();

        return View(schedule);
    }
}
