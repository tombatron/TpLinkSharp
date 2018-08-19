using TpLinkSharp.Models;
using Xunit;

namespace TpLinkSharp.UnitTests.Models
{
    public class WirelessInfoTests
    {
        public class ItCanInitialize
        {
            private static readonly string[] WirelessInfoArray = new[] { "1", "\"hello-world\"", "15", "5", "\"F4-F2-6D-94-C8-FD\"", "\"192.168.0.1\"", "2", "8", "71", "1", "6", "0", "0" };
            private static readonly WirelessInfo WirelessInfo = new WirelessInfo(WirelessInfoArray);

            [Fact]
            public void WirelessRadioFromWirelessInfoArray()
            {
                Assert.Equal("Enabled", WirelessInfo.WirelessRadio);
            }

            [Fact]
            public void NameSsidFromWirelessInfoArray()
            {
                Assert.Equal("hello-world", WirelessInfo.NameSsid);
            }

            [Fact]
            public void ModeFromWirelessInfoArray()
            {
                Assert.Equal("11bgn mixed", WirelessInfo.Mode);
            }

            [Fact]
            public void ChannelFromWirelessInfoArray()
            {
                Assert.Equal("Auto (Current channel 1)", WirelessInfo.Channel);
            }

            [Fact]
            public void ChannelWidthFromWirelessInfoArray()
            {
                Assert.Equal("Automatic", WirelessInfo.ChannelWidth);
            }

            [Fact]
            public void MacAddressFromWirelessInfoArray()
            {
                Assert.Equal("F4-F2-6D-94-C8-FD", WirelessInfo.MacAddress);
            }

            [Fact]
            public void WdsStatusFromWirelessInfoArray()
            {
                Assert.Equal("Disabled", WirelessInfo.WdsStatus);
            }
        }
    }
}
