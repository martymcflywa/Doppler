using System.Threading.Tasks;
using Doppler.Core;
using Doppler.Core.Type;
using Doppler.UpcStore.Extension;

namespace Doppler.UpcStore
{
    public class UpcReadStore : IReadStore
    {
        private const string BaseUri = "https://api.upcitemdb.com";
        private readonly Client _client;

        public UpcReadStore()
        {
            _client = new Client(BaseUri);
        }

        public async Task<IQueryResult> GetAsync(Query query)
        {
            var upcResponse = await _client.GetAsync(query.UpcId);
            var result = new UpcQueryResult
            {
                UpcId = query.UpcId,
                Title = upcResponse.Items[0].Title.GetTitle(),
                MediaType = upcResponse.Items[0].Title.GetMediaType(),
                Year = upcResponse.Items[0].Title.GetYear()
            };
            return result;
        }
    }
}