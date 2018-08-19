using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using static TpLinkSharp.Utilities.StringUtilities;

namespace TpLinkSharp.Models
{
    public class Status
    {
        private static readonly Regex ArrayPattern = new Regex(@"new Array\(([^\)]+)\)", RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase);

        private const int FirmwareVersionIndex = 6;
        private const int HardwareVersionIndex = 7;
        private const int SystemUptimeIndex = 5;

        private const int StatusInfoArrayIndex = 0;
        private const int LanInfoArrayIndex = 1;
        private const int Wireless24ghzInfoArrayIndex = 2;
        private const int Wireless5ghzInfoArrayIndex = 3;
        private const int TrafficStatisticsInfoArrayIndex = 4;
        private const int WanInfoArrayIndex = 5;

        private string _firmwareVersion;
        private string _hardwareVersion;
        private string _systemUptime;
        private LanInfo _lan;
        private WirelessInfo _wireless24ghz;
        private WirelessInfo _wireless5ghz;
        private WanInfo _wan;
        private TrafficStatisticsInfo _trafficStatistics;

        private readonly string[][] _parsedArrays;

        public string FirmwareVersion
        {
            get => _firmwareVersion;

            private set => _firmwareVersion = RemoveLeadingAndTrailingQuotes(value);
        }

        public string HardwareVersion
        {
            get => _hardwareVersion;

            private set => _hardwareVersion = RemoveLeadingAndTrailingQuotes(value);
        }

        public string SystemUptime
        {
            get => _systemUptime;

            set
            {
                var seconds = int.Parse(value);
                var uptimeSpan = TimeSpan.FromSeconds(seconds);

                var result = new StringBuilder();

                if (uptimeSpan.Days == 1)
                {
                    result.Append("1 Day ");
                }

                if (uptimeSpan.Days > 1)
                {
                    result.Append($"{uptimeSpan.Days} Days ");
                }

                result.Append($"{uptimeSpan.Hours} Hours ");

                result.Append($"{uptimeSpan.Minutes} Minutes ");

                result.Append($"{uptimeSpan.Seconds} Seconds");

                _systemUptime = result.ToString();
            }
        }

        public LanInfo Lan
        {
            get
            {
                if (_lan == default(LanInfo))
                {
                    _lan = new LanInfo(_parsedArrays[LanInfoArrayIndex]);
                }

                return _lan;
            }
        }

        public WirelessInfo Wireless24ghz
        {
            get
            {
                if (_wireless24ghz == default(WirelessInfo))
                {
                    _wireless24ghz = new WirelessInfo(_parsedArrays[Wireless24ghzInfoArrayIndex]);
                }

                return _wireless24ghz;
            }
        }

        public WirelessInfo Wireless5ghz
        {
            get
            {
                if (_wireless5ghz == default(WirelessInfo))
                {
                    _wireless5ghz = new WirelessInfo(_parsedArrays[Wireless5ghzInfoArrayIndex]);
                }

                return _wireless5ghz;
            }
        }

        public WanInfo Wan
        {
            get
            {
                if (_wan == default(WanInfo))
                {
                    _wan = new WanInfo(_parsedArrays[WanInfoArrayIndex]);
                }

                return _wan;
            }
        }

        public TrafficStatisticsInfo TrafficStatistics
        {
            get
            {
                if (_trafficStatistics == default(TrafficStatisticsInfo))
                {
                    _trafficStatistics = new TrafficStatisticsInfo(_parsedArrays[TrafficStatisticsInfoArrayIndex]);
                }

                return _trafficStatistics;
            }
        }

        private Status(string[][] parsedArrays)
        {
            FirmwareVersion = parsedArrays[StatusInfoArrayIndex][FirmwareVersionIndex];
            HardwareVersion = parsedArrays[StatusInfoArrayIndex][HardwareVersionIndex];
            SystemUptime = parsedArrays[StatusInfoArrayIndex][SystemUptimeIndex];

            _parsedArrays = parsedArrays;
        }

        public static Status FromHtmlResponse(string responseHtml)
        {
            var parsedArrays = ArrayPattern.Matches(responseHtml).Cast<Match>().Select(x => x.Groups[1].Value.Split(',')).ToArray();

            return new Status(parsedArrays);
        }
    }
}