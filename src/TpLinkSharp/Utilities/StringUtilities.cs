using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TpLinkSharp.Utilities
{
    public static class StringUtilities
    {
        private static readonly Regex QuotedTextPattern = new Regex("\"(.*?)\"", RegexOptions.Compiled);
        private static readonly Regex JavascriptArrayPattern = new Regex(@"new Array\(([^\)]+)\)", RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase);

        public static string Base64Encode(string toEncode) =>
            Convert.ToBase64String(Encoding.UTF8.GetBytes(toEncode));

        public static string RemoveLeadingAndTrailingQuotes(string toAlter) =>
            QuotedTextPattern.Match(toAlter).Groups[1].Value.Trim();

        public static string[][] ExtractJavascriptArrays(string htmlWithJavascriptArrays) =>
            JavascriptArrayPattern.Matches(htmlWithJavascriptArrays).Cast<Match>().Select(x => x.Groups[1].Value.Split(',')).ToArray();
    }
}