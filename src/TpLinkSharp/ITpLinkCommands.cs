using System.Threading.Tasks;
using TpLinkSharp.Models;

namespace TpLinkSharp
{
    public interface ITpLinkCommands
    {
        Task<Status> GetCurrentStatus ();
        
    }
}