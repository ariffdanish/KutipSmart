using KutipSmart.Data;
using KutipSmart.Models;
using Microsoft.AspNetCore.Mvc;

namespace KutipSmart.Controllers
{
    public class BinController : Controller
    {
        private readonly KutipDbContext _context;
        
        public BinController(KutipDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Bin> bins = _context.Bin.ToList();
            return View(bins);
        }


    }
}
