using System.Threading.Tasks;
using Doppler.Core;
using Doppler.Core.Type;
using Doppler.MovieStore;
using Doppler.UpcStore;

namespace Doppler.Bootstrapper
{
    public class UpcToMovieFinder
    {
        private readonly IReadStore _upcStore;
        private readonly IReadStore _movieStore;

        public UpcToMovieFinder()
        {
            _upcStore = new UpcReadStore();
            _movieStore = new MovieReadStore();
        }

        public async Task<TmdbQueryResult> GetAsync(string upcId)
        {
            var query = new Query {UpcId = upcId};
            var upcResult = await FindUpc(query);

            query.Title = upcResult.Title;
            query.MediaType = upcResult.MediaType;
            query.Year = upcResult.Year;

            var movieResult = await FindMovie(query);
            return movieResult;
        }

        private async Task<UpcQueryResult> FindUpc(Query query)
        {
            return (UpcQueryResult) await _upcStore.GetAsync(query);
        }

        private async Task<TmdbQueryResult> FindMovie(Query query)
        {
            return (TmdbQueryResult) await _movieStore.GetAsync(query);
        }
    }
}