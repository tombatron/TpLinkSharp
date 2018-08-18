using TpLinkSharp.Models;
using Xunit;

namespace TpLinkSharp.UnitTests.Models
{
    public class LanInfoTests
    {
        public class ItCanInitialize : BaseTest
        {
            private static readonly string[] LanInfoArray = new[] { "\"F4-F2-6D-94-C8-FD\"", "\"192.168.0.1\"", "\"255.255.255.0\"", "0", "0" };

            [Fact]
            public void MacAddressFromLanInfoArray()
            {
                var lanInfo = new LanInfo(LanInfoArray);

                Assert.Equal("F4-F2-6D-94-C8-FD", lanInfo.MacAddress);
            }

            [Fact]
            public void IpAddressFromLanInfoArray()
            {
                var lanInfo = new LanInfo(LanInfoArray);

                Assert.Equal("192.168.0.1", lanInfo.IpAddress);
            }

            [Fact]
            public void SubnetMaskFromLanInfoArray()
            {
                var lanInfo = new LanInfo(LanInfoArray);

                Assert.Equal("255.255.255.0", lanInfo.SubnetMask);
            }
        }
    }
}