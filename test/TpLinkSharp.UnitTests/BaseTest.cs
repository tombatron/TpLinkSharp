using System.IO;
using System.Threading.Tasks;

namespace TpLinkSharp.UnitTests
{
    public abstract class BaseTest
    {
        protected static Task<string> ReadTestAssetContent(string filename)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "TestAssets", filename);

            return File.ReadAllTextAsync(path);
        }
    }
}
