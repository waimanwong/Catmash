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

        /// <summary>
        /// Records the choice
        /// </summary>
        /// <param name="battleOutcomeDto"></param>
        /// <returns></returns>
        Task RegisterBattleOutcomeAsync(BattleOutcomeDto battleOutcomeDto);
    }

    public class BattleOutcomeDto
    {
        public string SelectedImageId { get; set; }
        public string UnselectedImageId { get; set; }
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