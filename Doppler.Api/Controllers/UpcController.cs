using System.Threading.Tasks;
using Doppler.Bootstrapper;
using Doppler.Core.Extension;
using Microsoft.AspNetCore.Mvc;

namespace Doppler.Api.Controllers
{
    [Route("api/[controller]")]
    public class UpcController
    {
        // GET api/upc/{upcId}
        [HttpGet("{upcId}")]
        public async Task<string> Get(string upcId)
        {
            var upcToMovieFinder = new UpcToMovieFinder();
            var result = await upcToMovieFinder.GetAsync(upcId);
            return result.ToJson();
            // TODO handle when upc or movie not found
        }
    }
}