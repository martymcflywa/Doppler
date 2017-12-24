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

        [HttpGet]
        public async Task<IActionResult> Index(SearchViewModel searchViewModel)
        {
            var result = await _dopplerStore.GetMovieByUpcAsync(searchViewModel.UpcId);
            var resultViewModel = JsonConvert.DeserializeObject<ResultViewModel>(result);
            return View(resultViewModel);
        }
    }
}