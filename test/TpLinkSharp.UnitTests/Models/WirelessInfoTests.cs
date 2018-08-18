using TpLinkSharp.Models;
using Xunit;

namespace TpLinkSharp.UnitTests.Models
{
    public class WirelessInfoTests
    {
        public class ItCanInitialize
        {
            private static readonly string[] WirelessInfoArray = new[] { "1", "\"hello-world\"", "15", "5", "\"F4-F2-6D-94-C8-FD\"", "\"192.168.0.1\"", "2", "8", "71", "1", "6", "0", "0" };

            [Fact]
            public void WirelessRadioFromWirelessInfoArray()
            {
                var wirelessInfo = new WirelessInfo(WirelessInfoArray);

                Assert.Equal("Enabled", wirelessInfo.WirelessRadio);
            }

            [Fact]
            public void NameSsidFromWirelessInfoArray()
            {
                var wirelessInfo = new WirelessInfo(WirelessInfoArray);

                Assert.Equal("hello-world", wirelessInfo.NameSsid);
            }

            [Fact]
            public void ModeFromWirelessInfoArray()
            {
                var wirelessInfo = new WirelessInfo(WirelessInfoArray);

                Assert.Equal("11bgn mixed", wirelessInfo.Mode);
            }

            [Fact]
            public void ChannelFromWirelessInfoArray()
            {
                var wirelessInfo = new WirelessInfo(WirelessInfoArray);

                Assert.Equal("Auto (Current channel 1)", wirelessInfo.Channel);
            }

            [Fact]
            public void ChannelWidthFromWirelessInfoArray()
            {
                var wirelessInfo = new WirelessInfo(WirelessInfoArray);

                Assert.Equal("Automatic", wirelessInfo.ChannelWidth);
            }

            [Fact]
            public void MacAddressFromWirelessInfoArray()
            {
                var wirelessInfo = new WirelessInfo(WirelessInfoArray);

                Assert.Equal("F4-F2-6D-94-C8-FD", wirelessInfo.MacAddress);
            }

            [Fact]
            public void WdsStatusFromWirelessInfoArray()
            {
                var wirelessInfo = new WirelessInfo(WirelessInfoArray);

                Assert.Equal("Disable", wirelessInfo.WdsStatus);
            }
        }
    }
}
