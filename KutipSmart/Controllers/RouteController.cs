/* using KutipSmart.Models;
using KutipSmart.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KutipSmart.Controllers
{
    public class RouteController : Controller
    {
        private readonly RouteService _routeService;

        public RouteController(RouteService routeService)
        {
            _routeService = routeService;
        }

        public async Task<IActionResult> Index()
        {
            // Sample data - replace with database or API later
            var trucks = new List<Truck>
{
    new Truck
    {
        TruckNo = "TRUCK001",
        Bins = new List<Bin>
        {
            new Bin
            {
                BinNo = "BIN0001",
                Latitude = 3.1581,
                Longitude = 101.7121
            },
            new Bin
            {
                BinNo = "BIN0002",
                Latitude = 5.4164,
                Longitude = 100.3327
            }
        }
    },
    new Truck
    {
        TruckNo = "TRUCK002",
        Bins = new List<Bin>
        {
            new Bin
            {
                BinNo = "BIN0003",
                Latitude = 1.4857,
                Longitude = 103.7616
            },
            new Bin
            {
                BinNo = "BIN0004",
                Latitude = 5.9754,
                Longitude = 116.0728
            }
        }
    }
};

            var options = new ParallelOptions { MaxDegreeOfParallelism = 3 };

            await Parallel.ForEachAsync(trucks, options, async (truck, ct) =>
            {
                if (truck.Bins == null || truck.Bins.Count < 1) return;

                // First leg: Truck → First Bin
                var firstBin = truck.Bins.First();
                var start = new double[] { truck.CurrentLongitude, truck.CurrentLatitude };
                var end = new double[] { firstBin.Longitude, firstBin.Latitude };

                try
                {
                    var result = await _routeService.GetRouteAsync(start, end);
                    if (result?.Routes != null && result.Routes.Length > 0)
                    {
                        var summary = result.Routes[0].Summary;
                        firstBin.DistanceToNext = summary.Distance / 1000.0;
                        firstBin.DurationToNext = summary.Duration / 60.0;
                    }
                }
                catch
                {
                    firstBin.DistanceToNext = 0;
                    firstBin.DurationToNext = 0;
                }

                // Remaining legs between bins
                for (int i = 0; i < truck.Bins.Count - 1; i++)
                {
                    var bin = truck.Bins[i];
                    start = new double[] { bin.Longitude, bin.Latitude };
                    end = new double[] { truck.Bins[i + 1].Longitude, truck.Bins[i + 1].Latitude };

                    try
                    {
                        var result = await _routeService.GetRouteAsync(start, end);
                        if (result?.Routes != null && result.Routes.Length > 0)
                        {
                            var summary = result.Routes[0].Summary;
                            bin.DistanceToNext = summary.Distance / 1000.0;
                            bin.DurationToNext = summary.Duration / 60.0;
                        }
                    }
                    catch
                    {
                        bin.DistanceToNext = 0;
                        bin.DurationToNext = 0;
                    }
                }

                // Calculate totals
                
            });

            return View(trucks);
        }
    }
}
*/