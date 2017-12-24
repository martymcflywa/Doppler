using Doppler.Frontend.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Doppler.Frontend.Web.Controllers
{
    public class SearchController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(SearchViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            return RedirectToAction("Index", "Result", model);
        }
    }
}