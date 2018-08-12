using System.Security.Cryptography;
using System.Text;

namespace TpLinkSharp.Utilities
{
    public static class HashUtilities
    {
        public static string HashString (string stringToHash) => HashBytes (Encoding.UTF8.GetBytes (stringToHash));

        public static string HashBytes (byte[] stringBytes)
        {
            var result = new StringBuilder ();

            using (var md5 = MD5.Create ())
            {
                var hash = md5.ComputeHash (stringBytes);

                for (var i = 0; i < hash.Length; i++)
                {
                    result.Append (hash[i].ToString("x2"));
                }
            }

            return result.ToString ();
        }
    }
}