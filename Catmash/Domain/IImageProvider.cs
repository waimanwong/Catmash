using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catmash.Domain
{
    public interface IImageProvider
    {
        Task<List<Image>> GetRandomImagesAsync(int count);

        Task<bool> DoesImageExist(string id);
    }

    
}
