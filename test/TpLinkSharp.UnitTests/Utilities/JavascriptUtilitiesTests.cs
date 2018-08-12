using Xunit;
using static TpLinkSharp.Utilities.JavascriptUtilities;

namespace TpLinkSharp.UnitTests.Utilities
{
    public class JavascriptUtilitiesTests
    {
        [Fact]
        public void ItCanEscapeAString()
        {
            var testString = "ཀཁགགྷངཅཆཇཉཊཋཌཌྷཎཏཐདདྷནཔཕབབྷམཙ1234567890!@#$%^&*()~`_+-=[]{}:><.,/?abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

            var escapedScript = Escape(testString);

            Assert.Equal("%u0F40%u0F41%u0F42%u0F43%u0F44%u0F45%u0F46%u0F47%u0F49%u0F4A%u0F4B%u0F4C%u0F4D%u0F4E%u0F4F%u0F50%u0F51%u0F52%u0F53%u0F54%u0F55%u0F56%u0F57%u0F58%u0F591234567890%21@%23%24%25%5E%26*%28%29%7E%60_+-%3D%5B%5D%7B%7D%3A%3E%3C.%2C/%3FabcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ", escapedScript);
        }
    }
}