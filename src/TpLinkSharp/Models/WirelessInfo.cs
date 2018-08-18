using static TpLinkSharp.Utilities.StringUtilities;

namespace TpLinkSharp.Models
{
    public class WirelessInfo
    {
        private readonly static string[] _wlanTypes = new[]
        {
            string.Empty,
            "11b only",
            "11g only",
            "11n only",
            "11bg mixed",
            "11bgn mixed",
            "11a only",
            "11n only",
            "11an mixed",
            "11ac only",
            "11a/n/ac mixed",
        };

        private readonly static string[] _channelWidths = new[]
        {
            string.Empty,
            "20MHz",
            "Automatic",
            "40MHz"
        };

        private const int WirelessRadioStatusIndex = 0;
        private const int NameSsidIndex = 1;
        private const int ChannelIndex = 2;
        private const int ModeIndex = 3;
        private const int MacAddressIndex = 4;
        private const int IpAddressIndex = 5;
        private const int ChannelWidthIndex = 6;
        private const int AutoChannelIndex = 9;
        private const int WdsStatusIndex = 10;

        private string _wirelessRadio;
        private string _nameSsid;
        private string _mode;
        private string _channel;
        private string _channelWidth;
        private string _macAddress;
        private string _wdsStatus;
        private string _autoChannel;

        public string WirelessRadio
        {
            get => _wirelessRadio;

            private set => _wirelessRadio = value == "1" ? "Enabled" : "Disabled";
        }

        public string NameSsid
        {
            get => _nameSsid;

            private set => _nameSsid = RemoveLeadingAndTrailingQuotes(value);
        }

        public string Mode
        {
            get => _mode;

            private set => _mode = _wlanTypes[int.Parse(value)];
        }

        public string Channel
        {
            get => _channel;

            private set
            {
                if (value == "15")
                {
                    _channel = $"Auto (Current channel {_autoChannel})";
                }
                else
                {
                    _channel = value;
                }
            }
        }

        public string ChannelWidth
        {
            get => _channelWidth;

            private set => _channelWidth = _channelWidths[int.Parse(value)];
        }

        public string MacAddress
        {
            get => _macAddress;

            private set => _macAddress = RemoveLeadingAndTrailingQuotes(value);
        }

        public string WdsStatus
        {
            get => _wdsStatus;

            private set => _wdsStatus = GetWdsStatus(value);
        }

        public WirelessInfo(string[] wirelessInfoArray)
        {
            _autoChannel = wirelessInfoArray[AutoChannelIndex];

            WirelessRadio = wirelessInfoArray[WirelessRadioStatusIndex];
            NameSsid = wirelessInfoArray[NameSsidIndex];
            Mode = wirelessInfoArray[ModeIndex];
            Channel = wirelessInfoArray[ChannelIndex];
            ChannelWidth = wirelessInfoArray[ChannelWidthIndex];
            MacAddress = wirelessInfoArray[MacAddressIndex];
            WdsStatus = wirelessInfoArray[WdsStatusIndex];
        }

        private static string GetWdsStatus(string wdsStatusId)
        {
            string result;

            switch (wdsStatusId)
            {
                case "0":
                    result = "Init...";
                    break;

                case "1":
                    result = "Scan...";
                    break;

                case "2":
                    result = "Join...";
                    break;

                case "3":
                    result = "Auth...";
                    break;

                case "4":
                    result = "Assoc...";
                    break;

                case "5":
                    result = "Run";
                    break;

                case "6":
                    result = "Disable";
                    break;

                default:
                    result = "Invalid";
                    break;
            }

            return result;
        }
    }
}