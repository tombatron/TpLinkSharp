using System;
using System.Text;
using System.Text.RegularExpressions;

namespace TpLinkSharp.Utilities
{
    public static class StringUtilities
    {
        private static readonly Regex QuotedTextPattern = new Regex("\"(.*?)\"", RegexOptions.Compiled);

        public static string Base64Encode(string toEncode) =>
            Convert.ToBase64String(Encoding.UTF8.GetBytes(toEncode));

        public static string RemoveLeadingAndTrailingQuotes(string toAlter) =>
            QuotedTextPattern.Match(toAlter).Groups[1].Value.Trim();
    }
}