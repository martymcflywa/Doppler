using System.Threading.Tasks;
using Doppler.Core.Type;

namespace Doppler.Core
{
    public interface IApiConsumer
    {
        Task<string> GetMovieFromUpcAsync(string upcId);
        Task<string> GetMovieFromTitleAsync(string title);
        Task<string> GetMovieFromExternalId(string source, string id);
    }
}