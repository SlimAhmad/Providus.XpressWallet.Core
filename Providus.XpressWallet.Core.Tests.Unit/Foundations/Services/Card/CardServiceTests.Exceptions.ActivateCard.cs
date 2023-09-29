using FluentAssertions;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalCard;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Card;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Card.Exceptions;
using RESTFulSense.Exceptions;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.Card
{
    public partial class CardServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnActivateCardRequestIfUrlNotFoundAsync()
        {
            // given

            dynamic createRandomActivateCardRequestProperties =
                 CreateRandomActivateCardRequestProperties();

            var activateCardsRequest = new ExternalActivateCardRequest
            {
                 CustomerId = createRandomActivateCardRequestProperties.CustomerId,
                 Last6 = createRandomActivateCardRequestProperties.Last6
            };

            var activateCards = new ActivateCard
            {
                Request = new ActivateCardRequest
                {
                    CustomerId = createRandomActivateCardRequestProperties.CustomerId,
                    Last6 = createRandomActivateCardRequestProperties.Last6
                },
            };

            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException();

            var invalidConfigurationCardException =
                new InvalidConfigurationCardException(
                    message: "Invalid Card configuration error occurred, contact support.",
                    httpResponseUrlNotFoundException);

            var expectedCardDependencyException =
                new CardDependencyException(
                    message: "Card dependency error occurred, contact support.",
                    invalidConfigurationCardException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostActivateCardAsync(It.IsAny<ExternalActivateCardRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<ActivateCard> retrieveActivateCardTask =
               this.authService.PostActivateCardRequestAsync(activateCards);

            CardDependencyException
                actualCardDependencyException =
                    await Assert.ThrowsAsync<CardDependencyException>(
                        retrieveActivateCardTask.AsTask);

            // then
            actualCardDependencyException.Should().BeEquivalentTo(
                expectedCardDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostActivateCardAsync(It.IsAny<ExternalActivateCardRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnActivateCardRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given

            dynamic createRandomActivateCardRequestProperties =
             CreateRandomActivateCardRequestProperties();

            var activateCardsRequest = new ExternalActivateCardRequest
            {
                CustomerId = createRandomActivateCardRequestProperties.CustomerId,
                    Last6 = createRandomActivateCardRequestProperties.Last6
            };

            var activateCards = new ActivateCard
            {
                Request = new ActivateCardRequest
                {
                    CustomerId = createRandomActivateCardRequestProperties.CustomerId,
                 Last6 = createRandomActivateCardRequestProperties.Last6
                },
            };

            var unauthorizedCardException =
                new UnauthorizedCardException(unauthorizedException);

            var expectedCardDependencyException =
                new CardDependencyException(unauthorizedCardException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.PostActivateCardAsync(It.IsAny<ExternalActivateCardRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<ActivateCard> retrieveActivateCardTask =
               this.authService.PostActivateCardRequestAsync(activateCards);

            CardDependencyException
                actualCardDependencyException =
                    await Assert.ThrowsAsync<CardDependencyException>(
                        retrieveActivateCardTask.AsTask);

            // then
            actualCardDependencyException.Should().BeEquivalentTo(
                expectedCardDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostActivateCardAsync(It.IsAny<ExternalActivateCardRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnActivateCardRequestIfNotFoundOccurredAsync()
        {
            // given

                dynamic createRandomActivateCardRequestProperties =
                 CreateRandomActivateCardRequestProperties();

            var activateCardsRequest = new ExternalActivateCardRequest
            {
                CustomerId = createRandomActivateCardRequestProperties.CustomerId,
                Last6 = createRandomActivateCardRequestProperties.Last6
            };

            var activateCards = new ActivateCard
            {
                Request = new ActivateCardRequest
                {
                    CustomerId = createRandomActivateCardRequestProperties.CustomerId,
                    Last6 = createRandomActivateCardRequestProperties.Last6
                },
            };


            var httpResponseNotFoundException =
                new HttpResponseNotFoundException();

            var notFoundCardException =
                new NotFoundCardException(
                    message: "Not found Card error occurred, fix errors and try again.",
                    httpResponseNotFoundException);

            var expectedCardDependencyValidationException =
                new CardDependencyValidationException(
                    message: "Card dependency validation error occurred, contact support.",
                    notFoundCardException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostActivateCardAsync(It.IsAny<ExternalActivateCardRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<ActivateCard> retrieveActivateCardTask =
               this.authService.PostActivateCardRequestAsync(activateCards);

            CardDependencyValidationException
                actualCardDependencyValidationException =
                    await Assert.ThrowsAsync<CardDependencyValidationException>(
                        retrieveActivateCardTask.AsTask);

            // then
            actualCardDependencyValidationException.Should().BeEquivalentTo(
                expectedCardDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostActivateCardAsync(It.IsAny<ExternalActivateCardRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnActivateCardRequestIfBadRequestOccurredAsync()
        {
            // given

                dynamic createRandomActivateCardRequestProperties =
                 CreateRandomActivateCardRequestProperties();

            var activateCardsRequest = new ExternalActivateCardRequest
            {
                CustomerId = createRandomActivateCardRequestProperties.CustomerId,
                    Last6 = createRandomActivateCardRequestProperties.Last6
            };

            var activateCards = new ActivateCard
            {
                Request = new ActivateCardRequest
                {
                    CustomerId = createRandomActivateCardRequestProperties.CustomerId,
                 Last6 = createRandomActivateCardRequestProperties.Last6
                },
            };

            var httpResponseBadRequestException =
                new HttpResponseBadRequestException();

            var invalidCardException =
                new InvalidCardException(
                    message: "Invalid Card error occurred, fix errors and try again.",
                    httpResponseBadRequestException);

            var expectedCardDependencyValidationException =
                new CardDependencyValidationException(
                    message: "Card dependency validation error occurred, contact support.",
                    invalidCardException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostActivateCardAsync(It.IsAny<ExternalActivateCardRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<ActivateCard> retrieveActivateCardTask =
               this.authService.PostActivateCardRequestAsync(activateCards);

            CardDependencyValidationException
                actualCardDependencyValidationException =
                    await Assert.ThrowsAsync<CardDependencyValidationException>(
                        retrieveActivateCardTask.AsTask);

            // then
            actualCardDependencyValidationException.Should().BeEquivalentTo(
                expectedCardDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostActivateCardAsync(It.IsAny<ExternalActivateCardRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnActivateCardRequestIfTooManyRequestsOccurredAsync()
        {
            // given

                dynamic createRandomActivateCardRequestProperties =
                 CreateRandomActivateCardRequestProperties();

            var activateCardsRequest = new ExternalActivateCardRequest
            {
                CustomerId = createRandomActivateCardRequestProperties.CustomerId,
                    Last6 = createRandomActivateCardRequestProperties.Last6
            };

            var activateCards = new ActivateCard
            {
                Request = new ActivateCardRequest
                {
                    CustomerId = createRandomActivateCardRequestProperties.CustomerId,
                 Last6 = createRandomActivateCardRequestProperties.Last6
                },
            };

            var httpResponseTooManyRequestsException =
                new HttpResponseTooManyRequestsException();

            var excessiveCallCardException =
                new ExcessiveCallCardException(
                    message: "Excessive call error occurred, limit your calls.",
                    httpResponseTooManyRequestsException);

            var expectedCardDependencyValidationException =
                new CardDependencyValidationException(
                    message: "Card dependency validation error occurred, contact support.",
                    excessiveCallCardException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.PostActivateCardAsync(It.IsAny<ExternalActivateCardRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<ActivateCard> retrieveActivateCardTask =
               this.authService.PostActivateCardRequestAsync(activateCards);

            CardDependencyValidationException actualCardDependencyValidationException =
                await Assert.ThrowsAsync<CardDependencyValidationException>(
                    retrieveActivateCardTask.AsTask);

            // then
            actualCardDependencyValidationException.Should().BeEquivalentTo(
                expectedCardDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostActivateCardAsync(It.IsAny<ExternalActivateCardRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnActivateCardRequestIfHttpResponseErrorOccurredAsync()
        {
            // given

                dynamic createRandomActivateCardRequestProperties =
                 CreateRandomActivateCardRequestProperties();

            var activateCardsRequest = new ExternalActivateCardRequest
            {
                CustomerId = createRandomActivateCardRequestProperties.CustomerId,
                    Last6 = createRandomActivateCardRequestProperties.Last6
            };

            var activateCards = new ActivateCard
            {
                Request = new ActivateCardRequest
                {
                    CustomerId = createRandomActivateCardRequestProperties.CustomerId,
                 Last6 = createRandomActivateCardRequestProperties.Last6
                },
            };

            var httpResponseException =
                new HttpResponseException();

            var failedServerCardException =
                new FailedServerCardException(
                    message: "Failed Card server error occurred, contact support.",
                    httpResponseException);

            var expectedCardDependencyException =
                new CardDependencyException(
                    message: "Card dependency error occurred, contact support.",
                    failedServerCardException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.PostActivateCardAsync(It.IsAny<ExternalActivateCardRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<ActivateCard> retrieveActivateCardTask =
               this.authService.PostActivateCardRequestAsync(activateCards);

            CardDependencyException actualCardDependencyException =
                await Assert.ThrowsAsync<CardDependencyException>(
                    retrieveActivateCardTask.AsTask);

            // then
            actualCardDependencyException.Should().BeEquivalentTo(
                expectedCardDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostActivateCardAsync(It.IsAny<ExternalActivateCardRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnActivateCardRequestIfServiceErrorOccurredAsync()
        {
            // given

                dynamic createRandomActivateCardRequestProperties =
                 CreateRandomActivateCardRequestProperties();

            var activateCardsRequest = new ExternalActivateCardRequest
            {
                CustomerId = createRandomActivateCardRequestProperties.CustomerId,
                    Last6 = createRandomActivateCardRequestProperties.Last6
            };

            var activateCards = new ActivateCard
            {
                Request = new ActivateCardRequest
                {
                    CustomerId = createRandomActivateCardRequestProperties.CustomerId,
                 Last6 = createRandomActivateCardRequestProperties.Last6
                },
            };
            var serviceException = new Exception();

            var failedCardServiceException =
                new FailedCardServiceException(serviceException);

            var expectedCardServiceException =
                new CardServiceException(failedCardServiceException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostActivateCardAsync(It.IsAny<ExternalActivateCardRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<ActivateCard> retrieveActivateCardTask =
               this.authService.PostActivateCardRequestAsync(activateCards);

            CardServiceException actualCardServiceException =
                await Assert.ThrowsAsync<CardServiceException>(
                    retrieveActivateCardTask.AsTask);

            // then
            actualCardServiceException.Should().BeEquivalentTo(
                expectedCardServiceException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostActivateCardAsync(It.IsAny<ExternalActivateCardRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
