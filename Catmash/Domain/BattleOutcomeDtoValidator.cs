using FluentValidation;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Catmash.Domain
{
    public class BattleOutcomeDtoValidator: AbstractValidator<BattleOutcomeDto>
    {
        private readonly IImageProvider _imageProvider;

        public BattleOutcomeDtoValidator(IImageProvider imageProvider)
        {
            _imageProvider = imageProvider;

            RuleFor(x => x).Must(HaveDifferentImageIds).WithMessage("Selected ImageId and unselected image id can not be identical");

            RuleFor(x => x.SelectedImageId)
                .NotNull()
                .MustAsync(HaveValidImageId).WithMessage("ImageId is invalid");

            RuleFor(x => x.UnselectedImageId)
                .NotNull()
                .MustAsync(HaveValidImageId).WithMessage("ImageId is invalid");
           
        }

        private static bool HaveDifferentImageIds(BattleOutcomeDto battleOutcomeDto)
        {
            return battleOutcomeDto.SelectedImageId != battleOutcomeDto.UnselectedImageId;
        }

        private Task<bool> HaveValidImageId(string imageId, CancellationToken cancellationToken)
        {
            return _imageProvider.DoesImageExist(imageId);
        }

    }
}
