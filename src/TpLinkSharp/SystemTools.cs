using System.Collections.Generic;
using System.Threading.Tasks;
using TpLinkSharp.Models.SystemTools;

namespace TpLinkSharp
{
    public class SystemTools : ISystemTools
    {
        public Task<IEnumerable<BandwidthStatistics>> GetStatisticsAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
