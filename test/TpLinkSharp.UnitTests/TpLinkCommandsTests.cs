using Moq;
using System.Threading.Tasks;
using Xunit;

namespace TpLinkSharp.UnitTests
{
    public class TpLinkCommandsTests : BaseTest
    {
        public class ItWillInitialize
        {
            [Fact]
            public void TheSystemToolsCommands()
            {
                var mockCommandRunner = new Mock<ITpLinkCommandRunner>();

                var tpLinkCommands = new TpLinkCommands(mockCommandRunner.Object);

                Assert.NotNull(tpLinkCommands.SystemTools);
            }
        }

        public class ItCanExecute
        {
            [Fact]
            public async Task TheGetCurrentStatusCommand()
            {
                var mockCommandRunner = new Mock<ITpLinkCommandRunner>();

                mockCommandRunner
                    .Setup(x => x.SendSecuredCommand(It.Is<string>(s => s.StartsWith("/userRpm/StatusRpm.htm"))))
                    .ReturnsAsync(ReadTestAssetContent("StatusRpmResponse.html"));

                var tpLinkCommands = new TpLinkCommands(mockCommandRunner.Object);

                var result = await tpLinkCommands.GetCurrentStatus();

                Assert.NotNull(result);
            }
        }
    }
}
