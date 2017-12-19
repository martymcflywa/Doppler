using System.Threading.Tasks;
using Doppler.Bootstrapper;
using Microsoft.AspNetCore.Mvc;

namespace Doppler.Api.Controllers
{
    [Route("api/[controller]")]
    public class UpcController
    {
        private readonly IBootstrap _upcToMovieFinder;

        public UpcController(IBootstrap upcToMovieFinder)
        {
            _upcToMovieFinder = upcToMovieFinder;
        }

        // GET api/upc/{upcId}
        [HttpGet("{upcId}")]
        public async Task<IActionResult> Get(string upcId)
        {
            var result = await _upcToMovieFinder.GetAsync(upcId);
            return new JsonResult(result);
        }
    }
}