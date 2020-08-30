using AutoFixture.Xunit2;
using Catmash.Domain;
using FluentAssertions;
using FluentValidation;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Catmash.UnitTests.Domain
{
    public class BattleOutcomeDtoValidatorTests
    {
        [Theory]
        [InlineAutoData]
        public void When_ImageIds_Are_Identical_Validator_ThrowsException(string imageId)
        {
            //Arrange
            var imageProvider = Mock.Of<IImageProvider>();
            var validatorService = new BattleOutcomeDtoValidator(imageProvider);
            var battleOutcomDto = new BattleOutcomeDto
            {
                SelectedImageId = imageId,
                UnselectedImageId = imageId
            };

            //Act and assert
            FluentActions.Invoking(() => validatorService.ValidateAndThrow(battleOutcomDto))
                .Should()
                .Throw<ValidationException>(because: "selected and unselected image ids are identical");

        }

        private const bool SelectedImageIdExists = true;
        private const bool SelectedImageIdDoesNotExist = false;
        private const bool UnselectedImageIdExists = true;
        private const bool UnselectedImageIdDoesNotExist = false;


        [Theory]
        [InlineAutoData(SelectedImageIdDoesNotExist, UnselectedImageIdDoesNotExist)]
        [InlineAutoData(SelectedImageIdExists, UnselectedImageIdDoesNotExist)]
        [InlineAutoData(SelectedImageIdDoesNotExist, UnselectedImageIdExists)]
        public void When_One_Of_ImageId_Is_Unknown_Validator_ThrowsException(
            bool selectedImageExists, bool unselectedImageExists,
            string selectedImageId, string unselectedImageId)
        {
            //Arrange
            var imageProvider = Mock.Of<IImageProvider>(imageProvider => 
                imageProvider.DoesImageExist(selectedImageId) == Task.FromResult(selectedImageExists) &&
                imageProvider.DoesImageExist(unselectedImageId) == Task.FromResult(unselectedImageExists));
            var validatorService = new BattleOutcomeDtoValidator(imageProvider);
            var battleOutcomDto = new BattleOutcomeDto
            {
                SelectedImageId = selectedImageId,
                UnselectedImageId = unselectedImageId
            };

            //Act and assert
            FluentActions.Invoking(() => validatorService.ValidateAndThrow(battleOutcomDto))
                .Should()
                .Throw<ValidationException>(because: "one of the image id does not exist.");

        }

        [Theory]
        [InlineAutoData]
        public void When_BattleOutcomeIsValid_Validator_Does_Not_ThrowException(
            string selectedImageId, string unselectedImageId)
        {
            //Arrange
            var imageProvider = Mock.Of<IImageProvider>(imageProvider =>
                imageProvider.DoesImageExist(selectedImageId) == Task.FromResult(true) &&
                imageProvider.DoesImageExist(unselectedImageId) == Task.FromResult(true));
            var validatorService = new BattleOutcomeDtoValidator(imageProvider);
            var battleOutcomDto = new BattleOutcomeDto
            {
                SelectedImageId = selectedImageId,
                UnselectedImageId = unselectedImageId
            };

            //Act and assert
            FluentActions.Invoking(() => validatorService.ValidateAndThrow(battleOutcomDto))
                .Should()
                .NotThrow<ValidationException>(because: "image ids are different and they both exist.");

        }
    }
}
