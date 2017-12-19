using System.Diagnostics;
using Doppler.Core;
using Microsoft.AspNetCore.Mvc;
using Doppler.Frontend.Web.Models;

namespace Doppler.Frontend.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IApiConsumer _dopplerStore;

        public HomeController(IApiConsumer dopplerStore)
        {
            _dopplerStore = dopplerStore;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}