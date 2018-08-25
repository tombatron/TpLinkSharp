using System.Collections.Generic;

namespace TpLinkSharp.Models.SystemTools
{
    public class BandwidthStatistics
    {
        private readonly IEnumerable<string> _rawBandwidthStatistics;

        public string IpAddress { get; }
        public string MacAddress { get; }
        public long TotalPackets { get; }
        public long TotalBytes { get; }

        public BandwidthStatistics(IEnumerable<string> rawBandwidthStatistics)
        {
            _rawBandwidthStatistics = rawBandwidthStatistics;
        }
    }
}