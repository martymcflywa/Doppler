using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Doppler.Core.Extension
{
    public static class StringEx
    {
        public static string Clean(this string @string)
        {
            return @string
                .DecodeHtml()
                .TrimKnownChars()
                .CapitaliseSingleWord()
                .CapitaliseWords()
                .HandleApostrophe()
                .NullIfEmpty();
        }

        public static string RemoveChar(this string @string, char @char)
        {
            var index = 0;
            var result = new char[@string.Length];
            for (var i = 0; i < @string.Length; i++)
            {
                if (!@string[i].Equals(@char))
                {
                    result[index++] = @string[i];
                }
            }
            return new string(result, 0, index);
        }

        private static bool IsEmpty(this string @string)
        {
            return string.IsNullOrEmpty(@string) || string.IsNullOrWhiteSpace(@string);
        }

        private static string NullIfEmpty(this string @string)
        {
            return @string.IsEmpty() ? null : @string;
        }

        private static string DecodeHtml(this string @string)
        {
            return HttpUtility.HtmlDecode(@string);
        }

        private static string TrimKnownChars(this string @string)
        {
            return @string?.Trim(' ', ',', '.', '-', '`', '*', '?', '\'', '\u0009');
        }

        private static string CapitaliseSingleWord(this string @string)
        {
            if (@string.IsEmpty())
                return null;

            var singleWordRegex = new Regex(@"^[\p{L}- ']+$");
            return singleWordRegex.Match(@string).Success ? Capitalise(@string) : @string;
        }

        private static string CapitaliseWords(this string @string)
        {
            if (@string.IsEmpty())
                return null;

            @string = CapitaliseWords(@string, '-');
            @string = CapitaliseWords(@string, ' ');

            return @string;
        }

        private static string CapitaliseWords(this string @string, char delimiter)
        {
            if (@string.IsEmpty())
                return @string;

            var words = @string.Split(delimiter);
            if (words.Length <= 1) return @string;
            var sb = new StringBuilder();
            foreach (var word in words)
            {
                if (word.Contains("'"))
                {
                    var split = word.Split('\'');
                    sb.Append(Capitalise(split[0]) + "'" + Capitalise(split[1]));
                }
                else
                {
                    sb.Append(Capitalise(word));
                    sb.Append(delimiter);
                }
            }
            return sb.ToString().Trim(delimiter);
        }

        private static string HandleApostrophe(this string @string)
        {
            if (@string.IsEmpty())
                return null;

            if (@string.Length > 2 && @string.Substring(@string.Length - 2, 1) == "'")
                @string = @string.Substring(0, @string.Length - 1) + @string.Substring(@string.Length - 1).ToLower();

            return @string;
        }

        private static string Capitalise(this string @string)
        {
            if (@string.IsEmpty())
                return null;

            if (@string.Length < 2)
                return @string.ToUpper();

            return @string[0].ToString().ToUpper() + @string.Substring(1).ToLower();
        }
    }
}