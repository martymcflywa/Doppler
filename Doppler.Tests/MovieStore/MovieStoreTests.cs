using Doppler.Core.Type;
using Doppler.MovieStore;
using TMDbLib.Client;
using Xunit;

namespace Doppler.Tests.MovieStore
{
    public class MovieStoreTests
    {
        [Fact]
        public void GetAsync()
        {
            const string testTitle = "Space Jam";
            const int testYear = 1997;

            var store = new Doppler.MovieStore.MovieReadStore();
            var tmdbMovie = store.GetAsync(new Query {Title = testTitle, Year = testYear}).Result;
        }
    }
}