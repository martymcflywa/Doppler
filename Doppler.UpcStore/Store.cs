using System.Threading.Tasks;
using Doppler.Core;
using Doppler.Core.Type;
using Doppler.UpcStore.Extension;

namespace Doppler.UpcStore
{
    public class Store : IReadStore
    {
        private const string BaseUri = "https://api.upcitemdb.com";
        private readonly Client _client;

        public Store()
        {
            _client = new Client(BaseUri);
        }

        public async Task<IQueryResult> GetAsync(Query query)
        {
            var upcResponse = await _client.GetAsync(query.Upc);
            return new UpcQueryResult
            {
                UpcId = query.Upc,
                Title = upcResponse.Items[0].Title.GetTitle(),
                MediaType = upcResponse.Items[0].Title.GetMediaType()
            };
        }
    }
}