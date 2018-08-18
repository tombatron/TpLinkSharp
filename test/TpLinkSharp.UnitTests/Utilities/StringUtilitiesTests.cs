using Xunit;
using static TpLinkSharp.Utilities.StringUtilities;

namespace TpLinkSharp.UnitTests.Utilities
{
    public class StringUtilitiesTests
    {
        [Fact]
        public void ItCanBase64EncodeAString()
        {
            var testString = "hello world";

            var encodedString = Base64Encode(testString);

            Assert.Equal("aGVsbG8gd29ybGQ=", encodedString);
        }

        [Fact]
        public void ItCanRemoveLeadingAndTrailingQuotes()
        {
            var testString = "\"hello world\"";

            var stringWithRemovedQuotes = RemoveLeadingAndTrailingQuotes(testString);

            Assert.Equal("hello world", stringWithRemovedQuotes);
        }
    }
}