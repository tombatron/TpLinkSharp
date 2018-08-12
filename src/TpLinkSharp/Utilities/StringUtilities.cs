using System;
using System.Text;

namespace TpLinkSharp.Utilities
{
    public static class StringUtilities
    {
        public static string Base64Encode (string toEncode) =>
            Convert.ToBase64String (Encoding.UTF8.GetBytes (toEncode));
    }
}