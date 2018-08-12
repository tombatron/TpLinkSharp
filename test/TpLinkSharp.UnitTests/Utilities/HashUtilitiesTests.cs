using Xunit;
using static TpLinkSharp.Utilities.HashUtilities;

namespace TpLinkSharp.UnitTests.Utilities
{
    public class HashUtilitiesTests
    {
        [Fact]
        public void ItCanHashString()
        {
            string testString = "hello world";

            string hashedString = HashString(testString);

            Assert.Equal("5eb63bbbe01eeed093cb22bb8f5acdc3", hashedString);
        }        
    }
}