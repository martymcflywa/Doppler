using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMDbLib.Client;
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
            _client.GetConfig();
        }

        public async Task<List<SearchMovie>> GetAsync(string movieTitle, int year)
        {
            var movies = await _client.SearchMovieAsync(movieTitle, 0, false, year);
            return movies.Results.Count > 0 ? movies.Results : null;
        }

        public async Task<Movie> GetAsync(int id)
        {
            return await _client.GetMovieAsync(
                id,
                MovieMethods.Credits |
                MovieMethods.Images |
                MovieMethods.Keywords |
                MovieMethods.Reviews);
        }

        public string BuildImageUrl(string imagePath)
        {
            return $"{_client.Config.Images.BaseUrl}{_client.Config.Images.PosterSizes.FirstOrDefault(p => p.Contains("500"))}{imagePath}";
        }
    }
}