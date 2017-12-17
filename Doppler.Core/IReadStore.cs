using System.Threading.Tasks;
using Doppler.Core.Type;

namespace Doppler.Core
{
    public interface IReadStore
    {
        Task<IQueryResult> GetAsync(Query query);
    }
}