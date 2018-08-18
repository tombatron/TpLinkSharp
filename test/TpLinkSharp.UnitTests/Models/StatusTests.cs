using System.Threading.Tasks;
using TpLinkSharp.Models;
using Xunit;

namespace TpLinkSharp.UnitTests.Models
{
    public class StatusTests
    {
        public class ItCanInitialize : BaseTest
        {
            [Fact]
            public async Task FirmwareVersionFromResponse()
            {
                var statusResponse = await ReadTestAssetContent("StatusRpmResponse.html");

                var status = Status.FromHtmlResponse(statusResponse);

                Assert.Equal("3.14.3 Build 150508 Rel.42275n", status.FirmwareVersion);
            }

            [Fact]
            public async Task HardwareVersionFromResponse()
            {
                var statusResponse = await ReadTestAssetContent("StatusRpmResponse.html");

                var status = Status.FromHtmlResponse(statusResponse);

                Assert.Equal("Archer C7 v3 00000000", status.HardwareVersion);
            }

            [Fact]
            public async Task SystemUptimeFromResponse()
            {
                var statusResponse = await ReadTestAssetContent("StatusRpmResponse.html");

                var status = Status.FromHtmlResponse(statusResponse);

                Assert.Equal("2 Days 16 Hours 10 Minutes 41 Seconds", status.SystemUptime);
            }

            [Fact]
            public async Task LanInfoFromResponse()
            {
                var statusResponse = await ReadTestAssetContent("StatusRpmResponse.html");

                var status = Status.FromHtmlResponse(statusResponse);

                Assert.NotNull(status.Lan);
            }

            [Fact]
            public async Task Wireless24ghzInfoFromResponse()
            {
                var statusResponse = await ReadTestAssetContent("StatusRpmResponse.html");

                var status = Status.FromHtmlResponse(statusResponse);

                Assert.NotNull(status.Wireless24ghz);
            }

            [Fact]
            public async Task Wireless5ghzInfoFromResponse()
            {
                var statusResponse = await ReadTestAssetContent("StatusRpmResponse.html");

                var status = Status.FromHtmlResponse(statusResponse);

                Assert.NotNull(status.Wireless5ghz);
            }

            [Fact]
            public async Task WanInfoFromResponse()
            {
                var statusResponse = await ReadTestAssetContent("StatusRpmResponse.html");

                var status = Status.FromHtmlResponse(statusResponse);

                Assert.NotNull(status.Wan);
            }

            [Fact]
            public async Task TrafficStatisticsInfoFromResponse()
            {
                var statusResponse = await ReadTestAssetContent("StatusRpmResponse.html");

                var status = Status.FromHtmlResponse(statusResponse);

                Assert.NotNull(status.TrafficStatistics);
            }
        }
    }
}
