using TpLinkSharp.Models;
using Xunit;

namespace TpLinkSharp.UnitTests.Models
{
    public class TrafficStatisticsInfoTests
    {
        private static readonly string[] TrafficStatisticsInfoArray = new[] { "2241896878", "2008981811", "9987275", "6182795", "0", "0" };
        private static readonly TrafficStatisticsInfo TrafficStatistics = new TrafficStatisticsInfo(TrafficStatisticsInfoArray);

        public class ItCanInitializeReceived
        {
            [Fact]
            public void BytesFromInfoArray()
            {
                Assert.Equal(2241896878, TrafficStatistics.Received.Bytes);
            }

            [Fact]
            public void PacketsFromInfoArray()
            {
                Assert.Equal(9987275, TrafficStatistics.Received.Packets);
            }
        }

        public class ItCanInitializeSent
        {
            [Fact]
            public void BytesFromInfoArray()
            {
                Assert.Equal(2008981811, TrafficStatistics.Sent.Bytes);
            }

            [Fact]
            public void PacketsFromInfoArray()
            {
                Assert.Equal(6182795, TrafficStatistics.Sent.Packets);
            }
        }
    }
}
