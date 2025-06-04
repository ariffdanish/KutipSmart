﻿using Microsoft.AspNetCore.Mvc;
using KutipSmart.Models;
using System.Linq;
using System.Collections.Generic;
using KutipSmart.Data;
using System;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

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
            var viewModel = new DashboardViewModel();

            // Build Bin Query
            var binsQuery = _context.Bin.Include(b => b.Schedules).AsQueryable();
            if (!string.IsNullOrEmpty(cityFilter)) binsQuery = binsQuery.Where(b => b.City == cityFilter);
            if (!string.IsNullOrEmpty(stateFilter)) binsQuery = binsQuery.Where(b => b.State == stateFilter);
            if (binStatusFilter.HasValue) binsQuery = binsQuery.Where(b => b.Status == binStatusFilter.Value);

            var bins = binsQuery.ToList(); // Materialize once

            // Build Truck Query
            var trucksQuery = _context.Trucks.AsQueryable();
            if (!string.IsNullOrEmpty(truckNoFilter)) trucksQuery = trucksQuery.Where(t => t.TruckNo.Contains(truckNoFilter));
            if (truckStatusFilter.HasValue) trucksQuery = trucksQuery.Where(t => t.Status == truckStatusFilter.Value);

            var trucks = trucksQuery.ToList(); // Materialize once

            //Get today truck assign
            var today = DateTime.Today;
            viewModel.TrucksAssignedToday = _context.Schedules
                .Where(s => s.ScheduledDateTime.Date == today)
                .Select(s => s.TruckId)
                .Distinct()
                .Count();

            // Inject filtered lists into ViewModel
            viewModel.Bins = bins;
            viewModel.Trucks = trucks;

            // Get latest schedule for each bin
            var scheduleLookup = bins.ToDictionary(
                bin => bin.BinId,
                bin => bin.Schedules
                    .OrderByDescending(s => s.ScheduledDateTime)
                    .FirstOrDefault()
            );
            viewModel.ScheduleLookup = scheduleLookup;

            // Get bins with any schedule scheduled for today
            
            viewModel.BinsScheduledToday = bins
                .Where(bin =>
                {
                    var todaysSchedules = bin.Schedules
                        .Where(s => s.ScheduledDateTime.Date == today)
                        .ToList();

                    return todaysSchedules != null && todaysSchedules.Count > 0;
                })
                .ToList();


            // Populate dropdown data
            viewModel.AllCities = _context.Bin.Select(b => b.City).Distinct().ToList();
            viewModel.AllStates = _context.Bin.Select(b => b.State).Distinct().ToList();
            viewModel.AllBinStatuses = Enum.GetValues(typeof(BinStatus)).Cast<BinStatus>().ToList();
            viewModel.AllTruckStatuses = Enum.GetValues(typeof(TruckStatus)).Cast<TruckStatus>().ToList();
            viewModel.AllTruckNos = _context.Trucks.Select(t => t.TruckNo).Distinct().ToList();

            // Set selected filters
            viewModel.SelectedCity = cityFilter;
            viewModel.SelectedState = stateFilter;
            viewModel.SelectedBinStatus = binStatusFilter;
            viewModel.SelectedTruckNo = truckNoFilter;
            viewModel.SelectedTruckStatus = truckStatusFilter;

            // Generate sample chart data (replace with real logic later)
            var currentYear = DateTime.Now.Year;

            // Count bins with Completed pickups per month
            var completedPickupCounts = _context.Schedules
                .Where(s => s.Status == ScheduleStatus.Completed &&
                            s.ScheduledDateTime.Year == currentYear)
                .GroupBy(s => s.ScheduledDateTime.Month)
                .ToDictionary(g => g.Key, g => g.Select(s => s.BinId).Distinct().Count());

            // Count unique trucks used in pickups per month
            var truckUsageCounts = _context.Schedules
                .Where(s => s.ScheduledDateTime.Year == currentYear)
                .GroupBy(s => s.ScheduledDateTime.Month)
                .ToDictionary(g => g.Key, g => g.Select(s => s.TruckId).Distinct().Count());

            List<string> labels = new List<string>();
            List<int> completedPickupData = new List<int>();
            List<int> truckUsageData = new List<int>();

            for (int month = 1; month <= 12; month++)
            {
                var monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(month);
                labels.Add(monthName);

                completedPickupData.Add(completedPickupCounts.GetValueOrDefault(month, 0));
                truckUsageData.Add(truckUsageCounts.GetValueOrDefault(month, 0));
            }

            viewModel.MonthLabels = labels.ToArray();
            viewModel.MonthlyCompletedPickups = completedPickupData.ToArray();
            viewModel.MonthlyTrucksUsedForPickups = truckUsageData.ToArray();

            var sevenDaysAgo = today.AddDays(-6); // Last 7 days including today

            // Get all completed pickups in the last 7 days
            var dailyPickups = _context.Schedules
                .Where(s => s.Status == ScheduleStatus.Completed &&
                            s.ScheduledDateTime >= sevenDaysAgo &&
                            s.ScheduledDateTime <= today)
                .GroupBy(s => s.ScheduledDateTime.Date)
                .ToDictionary(g => g.Key, g => g.Count());

            
            List<int> counts = new List<int>();

            for (int i = 0; i < 7; i++)
            {
                var date = sevenDaysAgo.AddDays(i);
                labels.Add(date.ToString("ddd")); // e.g., Mon, Tue...
                counts.Add(dailyPickups.GetValueOrDefault(date.Date, 0));
            }

            viewModel.DailyLabels = labels.ToArray();
            viewModel.DailyPickupCounts = counts.ToArray();
            viewModel.PickupsLast7Days = counts.Sum();

            return View(viewModel);
        }
    }
}
