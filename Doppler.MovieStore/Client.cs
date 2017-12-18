using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Doppler.Core.Exception;
using TMDbLib.Client;
using TMDbLib.Objects.Exceptions;
using TMDbLib.Objects.General;
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
            SearchContainer<SearchMovie> movies;

            try
            {
                movies = await _client.SearchMovieAsync(movieTitle, 0, false, year);
            }
            catch (RequestLimitExceededException)
            {
                throw new MovieStoreRequestLimitExceededException();
            }
            // TODO: also throws UnauthorizedAccessException and 429, catch this at api

            if(movies.Results.Count < 1)
                throw new MovieNotFoundException(movieTitle);

            return movies.Results;
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