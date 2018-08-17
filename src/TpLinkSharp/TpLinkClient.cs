using System;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static TpLinkSharp.Utilities.HashUtilities;
using static TpLinkSharp.Utilities.JavascriptUtilities;
using static TpLinkSharp.Utilities.StringUtilities;

namespace TpLinkSharp
{
    public class TpLinkClient : IDisposable
    {
        private static Regex ValidAuthenticationStringPattern = new Regex ("^[\x21-\x7e]+$", RegexOptions.Compiled);
        private static Regex UrlPattern = new Regex (@"(http|https)://([\w_-]+(?:(?:\.[\w_-]+)+))([\w.,@?^=%&:/~+#-]*[\w@?^=%&/~+#-])?", RegexOptions.Compiled);

        private readonly CookieContainer _cookieContainer;
        private readonly HttpClientHandler _clientHandler;
        private readonly HttpClient _client;
        private readonly Uri _baseAdminUrl;

        private string _securityToken = default (string);

        public TpLinkClient (string baseAdminUrl) : this (new Uri (baseAdminUrl)) { }

        public TpLinkClient (Uri baseAdminUrl)
        {
            _baseAdminUrl = baseAdminUrl;

            _cookieContainer = new CookieContainer (capacity: 1);
            _clientHandler = new HttpClientHandler { CookieContainer = _cookieContainer, AllowAutoRedirect = true };
            _client = new HttpClient (_clientHandler) { BaseAddress = _baseAdminUrl };
        }

        public void Connect (string username, string password)
        {
            if (IsValidUsername (username) && IsValidPassword (password))
            {
                var authCookie = CreateAuthenticationCookie (username, password);

                _cookieContainer.Add (authCookie);

                var response = _client.GetAsync ("/userRpm/LoginRpm.htm?Save=Save").GetAwaiter ().GetResult ();
                var responseContent = response.Content.ReadAsStringAsync ().GetAwaiter ().GetResult ();

                _securityToken = UrlPattern.Match (responseContent).Groups[3].Value.Split ('/') [1];
            }
            else
            {
                // TODO: Throw an exception here. 
            }
        }

        public void Disconnect ()
        {
            if (_securityToken != default (string))
            {
                var response = _client.GetAsync ("/userRpm/LogoutRpm.htm").GetAwaiter ().GetResult ();

                // TODO: If logout is unsucessful, throw an exception.

                _securityToken = default (string);
            }
        }

        internal async Task<string> SendSecuredCommand (string path)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"/{_securityToken}{path}");
            requestMessage.Headers.Add("Referer", $"{_baseAdminUrl}/{_securityToken}/userRpm/MenuRpm.htm");

            var response = await _client.SendAsync(requestMessage);

            return await response.Content.ReadAsStringAsync ();
        }

        public void Dispose ()
        {
            Disconnect ();

            _client.Dispose ();
            _clientHandler.Dispose ();
        }

        private static Cookie CreateAuthenticationCookie (string username, string password) =>
            new Cookie ("Authorization", $"{CreateAuthenticationString(username, password)}", "/", "192.168.0.1");

        private static string CreateAuthenticationString (string username, string password) =>
            Escape ($"Basic {Base64Encode($"{username}:{HashString (password.Substring (0, 15))}")}");

        private static bool IsAuthenticationSuccessful (string responseBody) => responseBody.Contains ("httpAutErrorArray");

        private static bool IsValidUsername (string username) => HasValidAuthenticationCharacters (username);

        private static bool IsValidPassword (string password) => HasValidAuthenticationCharacters (password);

        public static bool HasValidAuthenticationCharacters (string authenticationString) =>
            authenticationString.Length > 0 && ValidAuthenticationStringPattern.IsMatch (authenticationString);
    }
}