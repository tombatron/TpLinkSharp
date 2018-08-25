using Xunit;
using static TpLinkSharp.Utilities.StringUtilities;

namespace TpLinkSharp.UnitTests.Utilities
{
    public class StringUtilitiesTests : BaseTest
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

        [Fact]
        public void ItCanExtractJavascriptArrays()
        {
            var testContent = ReadTestAssetContent("StatusRpmResponse.html");

            var extractedArrays = ExtractJavascriptArrays(testContent);

            Assert.Equal(23, extractedArrays.Length);
            Assert.Equal(11, extractedArrays[0].Length);
        }
    }
}