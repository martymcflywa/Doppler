using System.Threading.Tasks;
using Doppler.Core.Type;

namespace Doppler.Core
{
    public interface IApiConsumer
    {
        Task<string> GetMovieByUpcAsync(string upcId);
        Task<string> GetMovieByTitleYearAsync(string title);
        Task<string> GetMovieByExternalId(string source, string id);
    }
}