using System;
using System.Net;
using System.Threading.Tasks;
using Doppler.Bootstrapper;
using Doppler.Core.Exception;
using Doppler.Core.Extension;
using Microsoft.AspNetCore.Mvc;

namespace Doppler.Api.Controllers
{
    [Route("api/[controller]")]
    public class UpcController : Controller
    {
        private readonly IBootstrap _upcToMovieFinder;
        private const string ContentType = "application/json";

        public UpcController(IBootstrap upcToMovieFinder)
        {
            _upcToMovieFinder = upcToMovieFinder;
        }

        // GET api/upc/{upcId}
        [HttpGet("{upcId}")]
        public async Task<IActionResult> Get(string upcId)
        {
            var content = new ContentResult
            {
                ContentType = ContentType
            };

            try
            {
                var movie = await _upcToMovieFinder.GetAsync(upcId);
                content.Content = movie.ToJson();
                content.StatusCode = (int) HttpStatusCode.OK;
            }
            catch (Exception ex) when (ex is UpcNotFoundException || ex is MovieNotFoundException)
            {
                content.Content = ex.GetBaseException().ToJson();
                content.StatusCode = (int) HttpStatusCode.NotFound;
            }
            catch (UpcStoreRequestLimitExceededException ex)
            {
                content.Content = ex.GetBaseException().Message;
                content.StatusCode = 429;
            }
            catch (InternalUpcStoreErrorException ex)
            {
                content.Content = ex.GetBaseException().Message;
                content.StatusCode = (int) HttpStatusCode.InternalServerError;
            }
            catch (UnauthorizedAccessException ex)
            {
                content.Content = ex.GetBaseException().Message;
                content.StatusCode = (int) HttpStatusCode.Unauthorized;
            }
            catch (Exception ex)
            {
                content.Content = ex.GetBaseException().Message;
                content.StatusCode = (int) HttpStatusCode.InternalServerError;
            }

            return content;
        }
    }
}