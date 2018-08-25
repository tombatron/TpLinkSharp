using System.Collections.Generic;
using System.Threading.Tasks;
using TpLinkSharp.Models.SystemTools;

namespace TpLinkSharp
{
    public class SystemTools : ISystemTools
    {
        private readonly TpLinkClient _client;

        public SystemTools(TpLinkClient client)
        {
            _client = client;
        }

        public Task<IEnumerable<BandwidthStatistics>> GetStatisticsAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
