using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catmash.Domain
{

    public class BattleService : IBattleService
    {
        private readonly IValidator<BattleOutcomeDto> _validator;
        private readonly IImageProvider _imageProviderService;
        private readonly IBattleOutcomeRepository _battleOutcomeRepository;

        public BattleService(
            IImageProvider imageProviderService,
            IBattleOutcomeRepository battleOutcomeRepository,
            IValidator<BattleOutcomeDto> validator)
        {
            _imageProviderService = imageProviderService;
            _battleOutcomeRepository = battleOutcomeRepository;
            _validator = validator;
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
            await _validator.ValidateAndThrowAsync(battleOutcomeDto);

            //Register Battle
            var battleOutcome = new BattleOutcome(battleOutcomeDto.SelectedImageId, battleOutcomeDto.UnselectedImageId);

            await _battleOutcomeRepository.AddAsync(battleOutcome);
            await _battleOutcomeRepository.CommitAsync();

            return;
        }

    }
}
