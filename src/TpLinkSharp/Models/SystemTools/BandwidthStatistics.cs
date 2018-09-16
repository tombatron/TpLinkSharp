using System.Collections.Generic;
using System.Linq;
using static TpLinkSharp.Utilities.StringUtilities;

namespace TpLinkSharp.Models.SystemTools
{
    public class BandwidthStatistics
    {
        private const int IpAddressIndex = 1;
        private const int MacAddressIndex = 2;
        private const int TotalPacketsIndex = 3;
        private const int TotalBytesIndex = 4;
        private const int CurrentPacketsIndex = 5;
        private const int CurrentBytesIndex = 6;

        private readonly string[] _rawBandwidthStatistics;

        private string _ipAddress;
        private string _macAddress;

        public string IpAddress
        {
            get => _ipAddress;

            private set => _ipAddress = RemoveLeadingAndTrailingQuotes(value);
        }

        public string MacAddress
        {
            get => _macAddress;

            private set => _macAddress = RemoveLeadingAndTrailingQuotes(value);
        }

        public long TotalPackets { get; }

        public long TotalBytes { get; }

        public long CurrentPackets { get; }

        public long CurrentBytes { get; }

        public BandwidthStatistics(IEnumerable<string> rawBandwidthStatistics) :
            this(rawBandwidthStatistics.ToArray())
        { }

        public BandwidthStatistics(string[] rawBandwidthStatistics)
        {
            _rawBandwidthStatistics = rawBandwidthStatistics;

            IpAddress = rawBandwidthStatistics[IpAddressIndex];
            MacAddress = rawBandwidthStatistics[MacAddressIndex];
            TotalPackets = long.Parse(rawBandwidthStatistics[TotalPacketsIndex]);
            TotalBytes = long.Parse(rawBandwidthStatistics[TotalBytesIndex]);
            CurrentPackets = long.Parse(rawBandwidthStatistics[CurrentPacketsIndex]);
            CurrentBytes = long.Parse(rawBandwidthStatistics[CurrentBytesIndex]);
        }
    }
}