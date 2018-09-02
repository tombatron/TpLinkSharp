using System.Threading.Tasks;

namespace TpLinkSharp
{
    public interface ITpLinkCommandRunner
    {
        Task<string> SendSecuredCommand(string path);
    }
}