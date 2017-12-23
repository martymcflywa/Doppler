using System;
using Doppler.Frontend.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Doppler.Frontend.Web.Controllers
{
    public class SearchController : Controller
    {
        [HttpGet("Search")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Index(SearchViewModel model)
        {
            return View(model);
        }
    }
}