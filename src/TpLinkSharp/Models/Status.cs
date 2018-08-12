namespace TpLinkSharp.Models
{
    public class Status
    {
        public string FirmwareVersion { get; }
        public string HardwareVersion { get; }
        public LanInfo Lan { get; }
        public WirelessInfo Wireless24ghz { get; }
        public WirelessInfo Wireless5ghz { get; }
        public WanInfo Wan { get; }

        public TrafficStatisticsInfo TrafficStatistics { get; }
        public string SystemUptime { get; }
    }
}