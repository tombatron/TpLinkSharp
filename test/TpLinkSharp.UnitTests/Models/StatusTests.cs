using System.Threading.Tasks;
using TpLinkSharp.Models;
using Xunit;

namespace TpLinkSharp.UnitTests.Models
{
    public class StatusTests
    {
        public class ItCanInitialize : BaseTest
        {
            private string StatusResponse = ReadTestAssetContent("StatusRpmResponse.html");

            [Fact]
            public void FirmwareVersionFromResponse()
            {
                var status = Status.FromHtmlResponse(StatusResponse);

                Assert.Equal("3.14.3 Build 150508 Rel.42275n", status.FirmwareVersion);
            }

            [Fact]
            public void HardwareVersionFromResponse()
            {
                var status = Status.FromHtmlResponse(StatusResponse);

                Assert.Equal("Archer C7 v3 00000000", status.HardwareVersion);
            }

            [Fact]
            public void SystemUptimeFromResponse()
            {
                var status = Status.FromHtmlResponse(StatusResponse);

                Assert.Equal("2 Days 16 Hours 10 Minutes 41 Seconds", status.SystemUptime);
            }

            [Fact]
            public void LanInfoFromResponse()
            {
                var status = Status.FromHtmlResponse(StatusResponse);

                Assert.NotNull(status.Lan);
            }

            [Fact]
            public void Wireless24ghzInfoFromResponse()
            {
                var status = Status.FromHtmlResponse(StatusResponse);

                Assert.NotNull(status.Wireless24ghz);
            }

            [Fact]
            public void Wireless5ghzInfoFromResponse()
            {
                var status = Status.FromHtmlResponse(StatusResponse);

                Assert.NotNull(status.Wireless5ghz);
            }

            [Fact]
            public void WanInfoFromResponse()
            {
                var status = Status.FromHtmlResponse(StatusResponse);

                Assert.NotNull(status.Wan);
            }

            [Fact]
            public void TrafficStatisticsInfoFromResponse()
            {
                var status = Status.FromHtmlResponse(StatusResponse);

                Assert.NotNull(status.TrafficStatistics);
            }
        }
    }
}
