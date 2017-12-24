using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Doppler.Core;
using Doppler.Core.Extension;
using Microsoft.AspNetCore.Mvc;
using Doppler.Frontend.Web.Models;
using Newtonsoft.Json;

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

        [HttpPost]
        public async Task<IActionResult> Result([Bind("UpcId")] SearchViewModel resultViewModel)
        {
            var result = await _dopplerStore.GetMovieByUpcAsync(resultViewModel.UpcId);
            var model = JsonConvert.DeserializeObject<ResultViewModel>(result);
            return View(model);
        }

        [HttpGet("Home/Result/{upcId}")]
        public async Task<IActionResult> Result(string upcId)
        {
            var result = await _dopplerStore.GetMovieByUpcAsync(upcId);
            var model = JsonConvert.DeserializeObject<ResultViewModel>(result);
            return View(model);
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