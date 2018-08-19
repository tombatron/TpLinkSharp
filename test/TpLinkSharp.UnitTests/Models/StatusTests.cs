using TpLinkSharp.Models;
using Xunit;

namespace TpLinkSharp.UnitTests.Models
{
    public class StatusTests
    {
        public class ItCanInitialize : BaseTest
        {
            private static readonly string StatusResponse = ReadTestAssetContent("StatusRpmResponse.html");
            private static readonly Status Status = Status.FromHtmlResponse(StatusResponse);

            [Fact]
            public void FirmwareVersionFromResponse()
            {
                Assert.Equal("3.14.3 Build 150508 Rel.42275n", Status.FirmwareVersion);
            }

            [Fact]
            public void HardwareVersionFromResponse()
            {
                Assert.Equal("Archer C7 v3 00000000", Status.HardwareVersion);
            }

            [Fact]
            public void SystemUptimeFromResponse()
            {
                Assert.Equal("2 Days 16 Hours 10 Minutes 41 Seconds", Status.SystemUptime);
            }

            [Fact]
            public void LanInfoFromResponse()
            {
                Assert.NotNull(Status.Lan);
            }

            [Fact]
            public void Wireless24ghzInfoFromResponse()
            {
                Assert.NotNull(Status.Wireless24ghz);
            }

            [Fact]
            public void Wireless5ghzInfoFromResponse()
            {
                Assert.NotNull(Status.Wireless5ghz);
            }

            [Fact]
            public void WanInfoFromResponse()
            {
                Assert.NotNull(Status.Wan);
            }

            [Fact]
            public void TrafficStatisticsInfoFromResponse()
            {
                Assert.NotNull(Status.TrafficStatistics);
            }
        }
    }
}
