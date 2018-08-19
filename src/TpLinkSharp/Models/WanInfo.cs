using System.Linq;
using static TpLinkSharp.Utilities.StringUtilities;

namespace TpLinkSharp.Models
{
    public class WanInfo
    {
        private const int MacAddressIndex = 1;
        private const int IpAddressIndex = 2;
        private const int SubnetMaskIndex = 4;
        private const int DefaultGatewayIndex = 7;
        private const int DnsServerIndex = 11;

        private string _macAddress;
        private string _ipAddress;
        private string _subnetMask;
        private string _defaultGateway;

        public string MacAddress
        {
            get => _macAddress;

            private set => _macAddress = RemoveLeadingAndTrailingQuotes(value);
        }

        public string IpAddress
        {
            get => _ipAddress;

            private set => _ipAddress = RemoveLeadingAndTrailingQuotes(value);
        }

        public string SubnetMask
        {
            get => _subnetMask;

            private set => _subnetMask = RemoveLeadingAndTrailingQuotes(value);
        }

        public string DefaultGateway
        {
            get => _defaultGateway;

            private set => _defaultGateway = RemoveLeadingAndTrailingQuotes(value);
        }

        public string[] DnsServer { get; }

        public WanInfo(string[] wanInfoArray)
        {
            MacAddress = wanInfoArray[MacAddressIndex];
            IpAddress = wanInfoArray[IpAddressIndex];
            SubnetMask = wanInfoArray[SubnetMaskIndex];
            DefaultGateway = wanInfoArray[DefaultGatewayIndex];
            DnsServer = ParseDnsServer(wanInfoArray[DnsServerIndex]);
        }

        private static string[] ParseDnsServer(string dnsServers) =>
            RemoveLeadingAndTrailingQuotes(dnsServers).Split(',').Select(x => x.Trim()).ToArray();
    }
}