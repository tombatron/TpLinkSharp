using System.Collections.Generic;
using System.Threading.Tasks;
using TpLinkSharp.Models.SystemTools;

namespace TpLinkSharp
{
    public interface ISystemTools
    {
        IEnumerable<BandwidthStatistics> GetStatistics();

        Task<IEnumerable<BandwidthStatistics>> GetStatisticsAsync();
    }
}