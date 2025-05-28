using Microsoft.AspNetCore.Mvc;
using KutipSmart.Models;
using System.Linq;
using System.Collections.Generic;
using KutipSmart.Data;
using System;

namespace KutipSmart.Controllers
{
    public class DashboardController : Controller
    {
        private readonly KutipDbContext _context;

        public DashboardController(KutipDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(
            string cityFilter,
            string stateFilter,
            BinStatus? binStatusFilter,
            string truckNoFilter,
            TruckStatus? truckStatusFilter
        )
        {
            var binsQuery = _context.Bin.AsQueryable();
            var trucksQuery = _context.Trucks.AsQueryable();

            // Bin filters
            if (!string.IsNullOrEmpty(cityFilter))
                binsQuery = binsQuery.Where(b => b.City == cityFilter);

            if (!string.IsNullOrEmpty(stateFilter))
                binsQuery = binsQuery.Where(b => b.State == stateFilter);

            if (binStatusFilter.HasValue)
                binsQuery = binsQuery.Where(b => b.Status == binStatusFilter.Value);

            // Truck filters
            if (!string.IsNullOrEmpty(truckNoFilter))
                trucksQuery = trucksQuery.Where(t => t.TruckNo.Contains(truckNoFilter));

            if (truckStatusFilter.HasValue)
                trucksQuery = trucksQuery.Where(t => t.Status == truckStatusFilter.Value);

            var viewModel = new DashboardViewModel
            {
                Bins = binsQuery.ToList(),
                Trucks = trucksQuery.ToList()
            };

            // Dropdown data
            ViewBag.AllCities = _context.Bin.Select(b => b.City).Distinct().ToList();
            ViewBag.AllStates = _context.Bin.Select(b => b.State).Distinct().ToList();
            ViewBag.AllBinStatuses = Enum.GetValues(typeof(BinStatus)).Cast<BinStatus>().ToList();
            ViewBag.AllTruckStatuses = Enum.GetValues(typeof(TruckStatus)).Cast<TruckStatus>().ToList();
            ViewBag.AllTruckNos = _context.Trucks.Select(t => t.TruckNo).Distinct().ToList();

            // Selected filters
            ViewBag.SelectedCity = cityFilter;
            ViewBag.SelectedState = stateFilter;
            ViewBag.SelectedBinStatus = binStatusFilter;
            ViewBag.SelectedTruckNo = truckNoFilter;
            ViewBag.SelectedTruckStatus = truckStatusFilter;

            return View(viewModel);
        }
    }
}
