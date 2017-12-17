using Doppler.Core;
using Doppler.Core.Type;

namespace Doppler.UpcStore
{
    public class UpcQueryResult : IQueryResult
    {
        public string Title { get; set; }
        public string UpcId { get; set; }
        public MediaType MediaType { get; set; }
    }
}