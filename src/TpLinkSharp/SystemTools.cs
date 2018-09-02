using System.Collections.Generic;
using System.Threading.Tasks;
using TpLinkSharp.Models.SystemTools;

namespace TpLinkSharp
{
    public class SystemTools : ISystemTools
    {
        private readonly ITpLinkCommandRunner _client;

        public SystemTools(ITpLinkCommandRunner client)
        {
            _client = client;
        }

        public async Task<IEnumerable<BandwidthStatistics>> GetStatisticsAsync()
        {
            var response = await _client.SendSecuredCommand("/userRpm/SystemStatisticRpm.htm?interval=10&sortType=5&Num_per_page=100&Goto_page=1");

            return BandwidthStatisticsCollection.FromHtmlResponse(response);
        }
    }
}
