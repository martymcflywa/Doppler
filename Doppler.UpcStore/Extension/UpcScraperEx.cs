using System;
using System.Text.RegularExpressions;
using Doppler.Core.Extension;
using Doppler.Core.Type;

namespace Doppler.UpcStore.Extension
{
    internal static class UpcScraperEx
    {
        private const string Pattern = @"^(.+?)[\(\[](DVD.*?|Blu?.Ray.*?)[\]\)]"; // group1=title, group2=media type
        private static readonly Regex Regex = new Regex(Pattern, RegexOptions.IgnoreCase | RegexOptions.Singleline);


        public static string GetTitle(this string title)
        {
            var titleMatch = Regex.Match(title);
            var cleanTitle = titleMatch?.Groups[1].Value.Clean();
            return cleanTitle;
        }

        public static MediaType GetMediaType(this string title)
        {
            const string mediaTypePattern = @"DVD.*?|Blu?.Ray.*?";
            var mediaTypeRegex = new Regex(mediaTypePattern);

            var rawMediaTypeMatch = Regex.Match(title);
            var rawMediaType = rawMediaTypeMatch?.Groups[2].Value;
            var cleanMediaType = mediaTypeRegex.Match(rawMediaType).Value.RemoveChar('-').Clean();

            if (!Enum.TryParse(cleanMediaType, out MediaType mediaType)) return mediaType;
            switch (mediaType)
            {
                case MediaType.Bluray:
                    mediaType = MediaType.Bluray;
                    break;
                case MediaType.Dvd:
                    mediaType = MediaType.Dvd;
                    break;
                default:
                    return MediaType.Unknown;
            }
            return mediaType;
        }
    }
}