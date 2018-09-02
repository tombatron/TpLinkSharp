using Moq;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace TpLinkSharp.UnitTests
{
    public class SystemToolsTests : BaseTest
    {
        [Fact]
        public async Task ItCanGetStatistics()
        {
            var mockCommandRunner = new Mock<ITpLinkCommandRunner>();

            mockCommandRunner
                .Setup(x => x.SendSecuredCommand(It.Is<string>(s => s.StartsWith("/userRpm/SystemStatisticRpm.htm"))))
                .ReturnsAsync(ReadTestAssetContent("SystemStatisticRpm.html"));

            var systemToolsCommands = new SystemTools(mockCommandRunner.Object);

            var result = await systemToolsCommands.GetStatisticsAsync();

            Assert.True(result.Any());
        }
    }
}
