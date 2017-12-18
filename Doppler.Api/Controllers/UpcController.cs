using System;
using System.Threading.Tasks;
using Doppler.Bootstrapper;
using Doppler.Core.Exception;
using Doppler.Core.Extension;
using Doppler.UpcStore.Proxy;
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
            string result;

            try
            {
                result = (await upcToMovieFinder.GetAsync(upcId)).ToJson();
            }
            catch (UnauthorizedAccessException ex)
            {
                result = new Error
                {
                    Code = nameof(UnauthorizedAccessException),
                    Message = ex.Message
                }.ToJson();
            }
            catch (UpcNotFoundException ex)
            {
                result = new Error
                {
                    Code = nameof(UpcNotFoundException),
                    Message = ex.Message
                }.ToJson();
            }
            catch (InvalidUpcQueryException ex)
            {
                result = new Error
                {
                    Code = nameof(InvalidUpcQueryException),
                    Message = ex.Message
                }.ToJson();
            }
            catch (UpcStoreRequestLimitExceededException ex)
            {
                result = new Error
                {
                    Code = nameof(UpcStoreRequestLimitExceededException),
                    Message = ex.Message
                }.ToJson();
            }
            catch (InternalUpcStoreErrorException ex)
            {
                result = new Error
                {
                    Code = nameof(InternalUpcStoreErrorException),
                    Message = ex.Message
                }.ToJson();
            }
            catch (MovieStoreRequestLimitExceededException ex)
            {
                result = new Error
                {
                    Code = nameof(MovieStoreRequestLimitExceededException),
                    Message = ex.Message
                }.ToJson();
            }
            catch (Exception ex)
            {
                result = new Error
                {
                    Code = nameof(Exception),
                    Message = ex.Message
                }.ToJson();
            }

            return result;
        }
    }
}