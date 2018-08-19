namespace TpLinkSharp.Models
{
    public class TrafficStatisticsInfo
    {
        private const int BytesReceivedIndex = 0;
        private const int BytesSentIndex = 1;
        private const int PacketsReceivedIndex = 2;
        private const int PacketsSentIndex = 3;

        public BandwithUsageInfo Received { get; }
        public BandwithUsageInfo Sent { get; }

        public TrafficStatisticsInfo(string[] trafficStatisitcsInfoArray)
        {
            Received = BandwithUsageInfo.Create(trafficStatisitcsInfoArray[BytesReceivedIndex], trafficStatisitcsInfoArray[PacketsReceivedIndex]);
            Sent = BandwithUsageInfo.Create(trafficStatisitcsInfoArray[BytesSentIndex], trafficStatisitcsInfoArray[PacketsSentIndex]);
        }
    }
}