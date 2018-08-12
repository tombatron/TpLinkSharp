namespace TpLinkSharp.Models.SystemTools
{
    public class BandwidthStatistics
    {
        public string IpAddress { get; }
        public string MacAddress { get; }
        public long TotalPackets { get; }
        public long TotalBytes { get; }
    }
}