using System.Threading.Tasks;
using Doppler.Core.Type;

namespace Doppler.Bootstrapper
{
    public interface IBootstrap
    {
        Task<TmdbQueryResult> GetAsync(string upcId);
    }
}