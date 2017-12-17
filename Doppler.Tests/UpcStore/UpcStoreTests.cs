using Doppler.Core.Type;
using Doppler.UpcStore;
using Xunit;

namespace Doppler.Tests.UpcStore
{
    public class UpcStoreTests
    {
        [Fact]
        public void GetAsync()
        {
            const string testUpc = "085391640028";
            var store = new Store();
            var upcMovie = store.GetAsync(new Query {UpcId = testUpc}).Result;
            var title = upcMovie.Title;
            var upc = upcMovie.UpcId;
            var media = upcMovie.MediaType;
        }
    }
}