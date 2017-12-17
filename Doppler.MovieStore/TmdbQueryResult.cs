using Doppler.Core;
using Doppler.Core.Type;

namespace Doppler.MovieStore
{
    public class TmdbQueryResult : IQueryResult
    {
        public string UpcId { get; set; }
        public string Title { get; set; }
        public MediaType MediaType { get; set; }
    }
}