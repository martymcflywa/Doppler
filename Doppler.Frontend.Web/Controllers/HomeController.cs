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