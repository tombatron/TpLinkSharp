using Xunit;

namespace TpLinkSharp.UnitTests.Models
{
    public class WanInfoTests
    {
        public class ItCanInitialize
        {
            private static readonly string[] WanInfoArray = new[] { "4", "\"F4-F2-6D-94-C8-FE\"", "\"99.138.9.19\"", "1", "\"255.255.88.0\"", "0", "0", "\"77.138.0.1\"", "1", "1", "0", "\"75.58.81.1 , 11.18.47.61\"", "\"\"", "0", "0", "\"0.0.0.0\"", "\"0.0.0.0\"", "\"0.0.0.0\"", "\"0.0.0.0 , 0.0.0.0\"", "0", "0", "0", "0", "0", "0", "0" };

            [Fact]
            public void MacAddressFromWanInfoArray()
            {

            }

            [Fact]
            public void IpAddressFromWanInfoArray()
            {

            }

            [Fact]
            public void SubnetMaskFromWanInfoArray()
            {

            }

            [Fact]
            public void DnsServersFromWanInfoArray()
            {

            }
        }
    }
}
