using System;
using System.Collections.Generic;
using Doppler.Core;
using Doppler.Core.Type;

namespace Doppler.MovieStore
{
    public class TmdbQueryResult : IQueryResult
    {
        public string UpcId { get; set; }
        public string Title { get; set; }
        public MediaType MediaType { get; set; }
        public int Year { get; set; }

        public string Tagline { get; set; }
        public string Overview { get; set; }
        public IEnumerable<string> Genres { get; set; }
        public IEnumerable<string> Images { get; set; }
        public string PosterPath { get; set; }
    }
}