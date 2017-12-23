using System.Threading.Tasks;
using Doppler.Core;
using Doppler.Frontend.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Doppler.Frontend.Web.Controllers
{
    public class ResultController : Controller
    {
        private readonly IApiConsumer _dopplerStore;

        public ResultController(IApiConsumer dopplerStore)
        {
            _dopplerStore = dopplerStore;
        }

        [HttpPost]
        public async Task<IActionResult> Index(SearchViewModel searchViewModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "Search", searchViewModel);
            }

            var result = await _dopplerStore.GetMovieFromUpcAsync(searchViewModel.UpcId);
            var model = JsonConvert.DeserializeObject<ResultViewModel>(result);
            return View(model);
        }
    }
}