using TpLinkSharp.Models.SystemTools;
using Xunit;

namespace TpLinkSharp.UnitTests.Models.SystemTools
{
    public class BandwidthStatisticsTests : BaseTest
    {
        private static readonly string[] RawStatistics = new[]
        {
            "\r\n0", "\"10.0.0.117\"", "\"0F-1F-C6-9C-3F-38\"", " 289234", " 180012916",
            " 6", " 1967", " 0", " 0", " 0", " 289", " 0", " 12",
        };

        private static readonly BandwidthStatistics BandwidthStatistics = new BandwidthStatistics(RawStatistics);

        public class ItCanInitialize
        {
            [Fact]
            public void IpAddressFromRawStatisticsArray()
            {
                Assert.Equal("10.0.0.117", BandwidthStatistics.IpAddress);
            }

            [Fact]
            public void MacAddressFromRawStatisticsArray()
            {
                Assert.Equal("0F-1F-C6-9C-3F-38", BandwidthStatistics.MacAddress);
            }

            [Fact]
            public void TotalPacketsFromRawStatisticsArray()
            {
                Assert.Equal(289234, BandwidthStatistics.TotalPackets);
            }

            [Fact]
            public void TotalBytesFromRawStatisticsArray()
            {
                Assert.Equal(180012916, BandwidthStatistics.TotalBytes);
            }
        }
    }
}