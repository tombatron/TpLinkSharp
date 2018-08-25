using System.Linq;
using TpLinkSharp.Models.SystemTools;
using Xunit;

namespace TpLinkSharp.UnitTests.Models.SystemTools
{
    public class BandwidthStatisticsCollectionTests : BaseTest
    {
        [Fact]
        public void ItCanInitializeFromAnHtmlString()
        {
            var fakeHtmlResponse = ReadTestAssetContent("SystemStatisticRpm.html");

            var statsCollection = BandwidthStatisticsCollection.FromHtmlResponse(fakeHtmlResponse);

            Assert.True(statsCollection.Any());
        }
    }
}
