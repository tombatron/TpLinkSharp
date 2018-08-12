using System.Collections.Generic;
using System.Threading.Tasks;
using TpLinkSharp.Models.SystemTools;

namespace TpLinkSharp
{
    public interface ISystemTools
    {
        Task<IEnumerable<BandwidthStatistics>> GetStatisticsAsync ();
    }
}