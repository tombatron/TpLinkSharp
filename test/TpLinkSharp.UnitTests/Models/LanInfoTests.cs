using TpLinkSharp.Models;
using Xunit;

namespace TpLinkSharp.UnitTests.Models
{
    public class LanInfoTests
    {
        public class ItCanInitialize : BaseTest
        {
            private static readonly string[] LanInfoArray = new[] { "\"F4-F2-6D-94-C8-FD\"", "\"192.168.0.1\"", "\"255.255.255.0\"", "0", "0" };
            private static readonly LanInfo LanInfo = new LanInfo(LanInfoArray);

            [Fact]
            public void MacAddressFromLanInfoArray()
            {
                Assert.Equal("F4-F2-6D-94-C8-FD", LanInfo.MacAddress);
            }

            [Fact]
            public void IpAddressFromLanInfoArray()
            {
                Assert.Equal("192.168.0.1", LanInfo.IpAddress);
            }

            [Fact]
            public void SubnetMaskFromLanInfoArray()
            {
                Assert.Equal("255.255.255.0", LanInfo.SubnetMask);
            }
        }
    }
}