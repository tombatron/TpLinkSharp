using static TpLinkSharp.Utilities.StringUtilities;

namespace TpLinkSharp.Models
{
    public class LanInfo
    {
        private const int MacAddressIndex = 0;
        private const int IpAddressIndex = 1;
        private const int SubnetMaskIndex = 2;

        private string _macAddress;
        private string _ipAddress;
        private string _subnetMask;

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

        public LanInfo(string[] lanInfoArray)
        {
            MacAddress = lanInfoArray[MacAddressIndex];
            IpAddress = lanInfoArray[IpAddressIndex];
            SubnetMask = lanInfoArray[SubnetMaskIndex];
        }
    }
}