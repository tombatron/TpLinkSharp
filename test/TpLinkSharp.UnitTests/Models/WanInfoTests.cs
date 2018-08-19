using TpLinkSharp.Models;
using Xunit;

namespace TpLinkSharp.UnitTests.Models
{
    public class WanInfoTests
    {
        public class ItCanInitialize
        {
            private static readonly string[] WanInfoArray = new[] { "4", "\"F4-F2-6D-94-C8-FE\"", "\"99.138.9.19\"", "1", "\"255.255.88.0\"", "0", "0", "\"77.138.0.1\"", "1", "1", "0", "\"75.58.81.1 , 11.18.47.61\"", "\"\"", "0", "0", "\"0.0.0.0\"", "\"0.0.0.0\"", "\"0.0.0.0\"", "\"0.0.0.0 , 0.0.0.0\"", "0", "0", "0", "0", "0", "0", "0" };
            private static readonly WanInfo WanInfo = new WanInfo(WanInfoArray);

            [Fact]
            public void MacAddressFromWanInfoArray()
            {
                Assert.Equal("F4-F2-6D-94-C8-FE", WanInfo.MacAddress);
            }

            [Fact]
            public void IpAddressFromWanInfoArray()
            {
                Assert.Equal("99.138.9.19", WanInfo.IpAddress);
            }

            [Fact]
            public void SubnetMaskFromWanInfoArray()
            {
                Assert.Equal("255.255.88.0", WanInfo.SubnetMask);
            }

            [Fact]
            public void DefaultGatewayFromWanInfoArray()
            {
                Assert.Equal("77.138.0.1", WanInfo.DefaultGateway);
            }

            [Fact]
            public void DnsServersFromWanInfoArray()
            {
                Assert.Equal(new[] { "75.58.81.1", "11.18.47.61" }, WanInfo.DnsServer);
            }
        }
    }
}
