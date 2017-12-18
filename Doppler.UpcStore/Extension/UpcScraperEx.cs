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
            const string titlePattern = @"^(.+?)[\(\[]";
            var titleRegex = new Regex(titlePattern, RegexOptions.IgnoreCase | RegexOptions.Singleline);

            return titleRegex.Match(title).Success ? titleRegex.Match(title).Groups[1].Value.Clean() : null;
        }

        public static MediaType GetMediaType(this string title)
        {
            const string mediaTypePattern = @"DVD|Blu?.Ray";
            var mediaTypeRegex = new Regex(mediaTypePattern, RegexOptions.IgnoreCase | RegexOptions.Singleline);

            var extractedMediaType = mediaTypeRegex
                .Match(title)
                .Value
                .RemoveChar('-')
                .RemoveChar('e')
                .Clean();

            return Enum.TryParse(extractedMediaType, true, out MediaType mediaType) ? mediaType : MediaType.Unknown;
        }

        public static int GetYear(this string title)
        {
            const string yearPattern = @"\[\(\d{2,4}\)\]";
            var yearRegex = new Regex(yearPattern);

            return yearRegex.Match(title).Success ? int.Parse(yearRegex.Match(title).Groups[1].Value) : 0;
        }
    }
}