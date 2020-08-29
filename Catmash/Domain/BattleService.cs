using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catmash.Domain
{

    public class BattleService : IBattleService
    {
        private readonly IImageProviderService _imageProviderService;

        public BattleService(IImageProviderService imageProviderService)
        {
            _imageProviderService = imageProviderService;
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
    }

}
