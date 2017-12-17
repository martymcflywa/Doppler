using System.Collections.Generic;
using System.Threading.Tasks;
using TMDbLib.Client;
using TMDbLib.Objects.Find;
using TMDbLib.Objects.Movies;
using TMDbLib.Objects.Search;

namespace Doppler.MovieStore
{
    public class Client
    {
        private const string ApiKey = "ba6cb3131a329465fd5cf9232cbf26ae";
        private readonly TMDbClient _client;

        public Client()
        {
            _client = new TMDbClient(ApiKey);
        }

        public async Task<List<SearchMovie>> GetAsync(string movieTitle)
        {
            var movies = await _client.SearchMovieAsync(movieTitle);
            return movies.Results.Count > 0 ? movies.Results : null;
        }

        public async Task<Movie> GetAsync(FindExternalSource source, string id)
        {
            return await _client.GetMovieAsync(
                id,
                MovieMethods.Credits |
                MovieMethods.Images |
                MovieMethods.Keywords |
                MovieMethods.Reviews);
        }
    }
}
