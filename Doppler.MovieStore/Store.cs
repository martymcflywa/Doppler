using System.Threading.Tasks;
using Doppler.Core;
using Doppler.Core.Type;

namespace Doppler.MovieStore
{
    public class Store : IReadStore
    {
        public Task<IQueryResult> GetAsync(Query query)
        {
            throw new System.NotImplementedException();
        }
    }
}