using System.Diagnostics;
using System.Linq;
using BusBoard.Web.Models;
using BusBoardScratch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BusBoard.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index([FromQuery] string postCode)
        {
            if (postCode == null) postCode = "NW51PB";

            var postcodeClient = new PostcodeApiCaller();

            var latLong = postcodeClient.GetLatLong(postCode);

            var latLongClient = new TflApiClient();

            var places = latLongClient.GetStopcode(latLong.latitude.ToString(), latLong.longitude.ToString(), 1000);

            foreach (var stop in places) stop.arrivals = TflApiClient.GetArrivals(stop.naptanId);

            var viewModels = places.Select(bs => new BusStopViewModel(bs)).ToList();

            return View(viewModels);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}