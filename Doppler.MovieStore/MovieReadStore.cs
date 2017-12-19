using System.Linq;
using System.Threading.Tasks;
using Doppler.Core;
using Doppler.Core.Exception;
using Doppler.Core.Type;

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
            // TODO: handle multiple responses, show user all results, selectable
            var tmdbSearchResult = (await _client.GetAsync(query.Title, query.Year)).FirstOrDefault();

            var tmdbMovie = await _client.GetAsync(tmdbSearchResult.Id);

            var cast = tmdbMovie.Credits.Cast.Select(c => c.Name).ToList();
            var genres = tmdbMovie.Genres.Select(genre => genre.Name).ToList();
            var images = tmdbMovie.Images.Posters.Select(image => _client.BuildImageUrl(image.FilePath)).ToList();

            var year = int.Parse(
                tmdbMovie
                    .ReleaseDate?
                    .Year
                    .ToString() ??
                tmdbMovie
                    .ReleaseDates
                    .Results
                    .FirstOrDefault()
                    .ReleaseDates
                    .FirstOrDefault()
                    .ReleaseDate
                    .Year
                    .ToString());

            return new TmdbQueryResult
            {
                UpcId = query.UpcId,
                Title = tmdbMovie.Title,
                MediaType = query.MediaType,
                Year = year,
                Tagline = tmdbMovie.Tagline,
                Overview = tmdbMovie.Overview,
                Cast = cast,
                Genres = genres,
                Images = images,
                PosterPath = _client.BuildImageUrl(tmdbMovie.PosterPath)
            };
        }
    }
}