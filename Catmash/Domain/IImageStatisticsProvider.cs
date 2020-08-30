using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catmash.Domain
{
    public interface IImageStatisticsProvider
    {
        Task<List<ImageStatistics>> GetMostSelectedImagesAsync(int topN);
    }
}
