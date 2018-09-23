using System.Threading.Tasks;
using TpLinkSharp.Models;

namespace TpLinkSharp
{
    public interface ITpLinkCommands
    {
        Status GetCurrentStatus();

        Task<Status> GetCurrentStatusAsync();

        ISystemTools SystemTools { get; }
    }
}