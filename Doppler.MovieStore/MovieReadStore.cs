using System.Linq;
using System.Threading.Tasks;
using Doppler.Core;
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
            // TODO: handle when search unsuccessful
            var tmdbSearchResult = (await _client.GetAsync(query.Title, query.Year)).FirstOrDefault();
            if (tmdbSearchResult == null)
                return null;

            var tmdbMovie = await _client.GetAsync(tmdbSearchResult.Id);

            var genres = tmdbMovie.Genres.Select(genre => genre.Name).ToList();
            var images = tmdbMovie.Images.Posters.Select(image => _client.BuildImageUrl(image.FilePath)).ToList();

            return new TmdbQueryResult
            {
                UpcId = query.UpcId,
                Title = tmdbMovie.Title,
                MediaType = query.MediaType,
                Year = int.Parse(tmdbMovie.ReleaseDate?.Year.ToString()),
                Tagline = tmdbMovie.Tagline,
                Overview = tmdbMovie.Overview,
                Genres = genres,
                Images = images,
                PosterPath = _client.BuildImageUrl(tmdbMovie.PosterPath)
            };
        }
    }
}