using Doppler.Frontend.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Doppler.Frontend.Web.Controllers
{
    public class SearchController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new SearchViewModel());
        }
    }
}