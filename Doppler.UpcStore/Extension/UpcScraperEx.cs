using System;
using System.Text.RegularExpressions;
using Doppler.Core.Extension;
using Doppler.Core.Type;

namespace Doppler.UpcStore.Extension
{
    internal static class UpcScraperEx
    {
        public static string GetTitle(this string title)
        {
            const string titlePattern = @"^(.+?)[\(\[](DVD.*?|Blu?.Ray.*?)[\]\)]";
            var titleRegex = new Regex(titlePattern, RegexOptions.IgnoreCase | RegexOptions.Singleline);

            return titleRegex.Match(title).Success ? titleRegex.Match(title).Groups[1].Value.Clean() : null;
        }

        public static MediaType GetMediaType(this string title)
        {
            const string mediaTypePattern = @"DVD|Blu?.Ray";
            var mediaTypeRegex = new Regex(mediaTypePattern, RegexOptions.IgnoreCase | RegexOptions.Singleline);

            var mediaType = MediaType.Unknown;
            if (!mediaTypeRegex.Match(title).Success)
                return mediaType;

            var extractedMediaType = mediaTypeRegex
                .Match(title)
                .Groups[2]
                .Value
                .RemoveChar('-')
                .Clean();

            if (!Enum.TryParse(extractedMediaType, out mediaType)) return mediaType;
            switch (mediaType)
            {
                case MediaType.Dvd:
                    mediaType = MediaType.Dvd;
                    break;
                case MediaType.Bluray:
                    mediaType = MediaType.Bluray;
                    break;
            }
            return mediaType;
        }

        public static int GetYear(this string title)
        {
            const string yearPattern = @"\[\(\d{2,4}\)\]";
            var yearRegex = new Regex(yearPattern);

            return yearRegex.Match(title).Success ? int.Parse(yearRegex.Match(title).Groups[1].Value) : 0;
        }
    }
}