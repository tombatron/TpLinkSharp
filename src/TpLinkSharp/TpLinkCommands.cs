using System.Threading.Tasks;
using TpLinkSharp.Models;

namespace TpLinkSharp
{
    public class TpLinkCommands : ITpLinkCommands
    {
        private readonly ITpLinkCommandRunner _client;

        public TpLinkCommands(ITpLinkCommandRunner client)
        {
            _client = client;

            SystemTools = new SystemTools(_client);
        }

        public ISystemTools SystemTools { get; }

        public async Task<Status> GetCurrentStatus()
        {
            var response = await _client.SendSecuredCommand("/userRpm/StatusRpm.htm");

            return Status.FromHtmlResponse(response);
        }
    }
}