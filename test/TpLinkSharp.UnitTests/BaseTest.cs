using System.IO;

namespace TpLinkSharp.UnitTests
{
    public abstract class BaseTest
    {
        protected static string ReadTestAssetContent(string filename)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "TestAssets", filename);

            return File.ReadAllText(path);
        }
    }
}