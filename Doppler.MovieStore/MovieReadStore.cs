using System.Linq;
using System.Threading.Tasks;
using Doppler.Core;
using Doppler.Core.Exception;
using Doppler.Core.Type;
using TMDbLib.Objects.Movies;
using TMDbLib.Objects.Search;

namespace Doppler.MovieStore
{
    public class MovieReadStore : IReadStore
    {
        private readonly Client _client;

        public MovieReadStore()
        {
            _client = new Client();
        }

        public async Task<IQueryResult> GetAsync(Query query)
        {
            var fromTitleYear = await Search(query.Title, query.Year);
            var fromId = await Search(fromTitleYear.Id);
            return BuildResult(query, fromId);
        }

        private async Task<SearchMovie> Search(string title, int year)
        {
            var movies = await _client.GetAsync(title, year);

            if (movies.Count < 1)
                throw new MovieNotFoundException(title);

            return movies.First();
        }

        private async Task<Movie> Search(int id)
        {
            return await _client.GetAsync(id);
        }

        private TmdbQueryResult BuildResult(Query query, Movie movie)
        {
            var cast = movie.Credits.Cast
                .Select(c => c.Name)
                .Take(5)
                .ToList();

            var genres = movie.Genres
                .Select(genre => genre.Name)
                .ToList();

            var images = movie.Images.Posters
                .Select(image => _client.BuildImageUrl(image.FilePath))
                .ToList();

            var year = GetYear(movie);

            return new TmdbQueryResult
            {
                UpcId = query.UpcId,
                Title = movie.Title,
                MediaType = query.MediaType,
                Year = year,
                Tagline = movie.Tagline,
                Overview = movie.Overview,
                Cast = cast,
                Genres = genres,
                Images = images,
                PosterPath = _client.BuildImageUrl(movie.PosterPath)
            };
        }

        private static int GetYear(Movie movie)
        {
            return int.Parse(
                movie
                    .ReleaseDate?
                    .Year
                    .ToString() ??
                movie
                    .ReleaseDates
                    .Results
                    .FirstOrDefault()
                    .ReleaseDates
                    .FirstOrDefault()
                    .ReleaseDate
                    .Year
                    .ToString());
        }
    }
}