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

        public Status GetCurrentStatus()
        {
            return GetCurrentStatusAsync().GetAwaiter().GetResult();
        }

        public async Task<Status> GetCurrentStatusAsync()
        {
            var response = await _client.SendSecuredCommand("/userRpm/StatusRpm.htm").ConfigureAwait(false);

            return Status.FromHtmlResponse(response);
        }
    }
}