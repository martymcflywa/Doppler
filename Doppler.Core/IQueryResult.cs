using Doppler.Core.Type;

namespace Doppler.Core
{
    public interface IQueryResult
    {
        string UpcId { get; set; }
        string Title { get; set; }
        MediaType MediaType { get; set; }
        int Year { get; set; }
    }
}