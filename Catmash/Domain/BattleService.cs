using System;
using System.Linq;
using System.Threading.Tasks;

namespace Catmash.Domain
{
    public class BattleService : IBattleService
    {
        private readonly IImageProviderService _imageProviderService;
        private readonly IBattleOutcomeRepository _battleOutcomeRepository;

        public BattleService(
            IImageProviderService imageProviderService,
            IBattleOutcomeRepository battleOutcomeRepository)
        {
            _imageProviderService = imageProviderService;
            _battleOutcomeRepository = battleOutcomeRepository;
        }

        public async Task<NewBattleDto> InitBattleAsync()
        {
            var randomImages = await _imageProviderService.GetRandomImagesAsync(2);

            return new NewBattleDto
            {
                Images = randomImages
                    .Select(img => new ImageDto {  Id = img.Id, Url = img.Url})
                    .ToList()
            };
        }

        public async Task RegisterBattleOutcomeAsync(BattleOutcomeDto battleOutcomeDto)
        {
            // Input validation
            if (await BattleOutcomeIsNotValidAsync(battleOutcomeDto))
            {
                throw new ApplicationException("Battle is invalid");
            }

            //Register Battle
            var battleOutcome = new BattleOutcome(battleOutcomeDto.SelectedImageId, battleOutcomeDto.UnselectedImageId);

            await _battleOutcomeRepository.AddAsync(battleOutcome);
            await _battleOutcomeRepository.CommitAsync();

            return;
        }

        private async Task<bool> BattleOutcomeIsNotValidAsync(BattleOutcomeDto battleOutcomeDto)
        {
            var selectedImageId = battleOutcomeDto.SelectedImageId;
            var unselectedImageId = battleOutcomeDto.UnselectedImageId;

            if (selectedImageId == unselectedImageId)
            {
                return true;
            }

            var selectedImageIsInvalid = (await _imageProviderService.DoesImageExist(selectedImageId)) == false;
            var unselectedImageIsInvalid = (await _imageProviderService.DoesImageExist(unselectedImageId)) == false;

            return selectedImageIsInvalid || unselectedImageIsInvalid;
        }
    }
}
