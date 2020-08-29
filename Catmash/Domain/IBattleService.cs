using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catmash.Domain
{
    public interface IBattleService
    {
        /// <summary>
        /// returns a battle with randomly selected images
        /// </summary>
        /// <returns></returns>
        Task<NewBattleDto> InitBattleAsync();
    }

    public class NewBattleDto
    {
        public List<ImageDto> Images { get; set; }
    }

    public class ImageDto
    {
        public string Id { get; set; }
        public string Url { get; set; }
    }
}