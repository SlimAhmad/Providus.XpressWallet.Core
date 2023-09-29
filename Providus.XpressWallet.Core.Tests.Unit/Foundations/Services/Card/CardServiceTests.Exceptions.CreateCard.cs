using FluentAssertions;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalCard;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Card;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Card.Exceptions;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Card;
using RESTFulSense.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.Card
{
    public partial class CardServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnCreateCardRequestIfUrlNotFoundAsync()
        {
            // given

            dynamic createRandomCreateCardRequestProperties =
                 CreateRandomCreateCardRequestProperties();

            var createCardRequest = new ExternalCreateCardRequest
            {
                 CustomerId = createRandomCreateCardRequestProperties.CustomerId,
                 Address1 = createRandomCreateCardRequestProperties.Address1,
                 Address2 = createRandomCreateCardRequestProperties.Address2,
             
            };

            var createCard = new CreateCard
            {
                Request = new CreateCardRequest
                {
                    CustomerId = createRandomCreateCardRequestProperties.CustomerId,
                    Address1 = createRandomCreateCardRequestProperties.Address1,
                    Address2 = createRandomCreateCardRequestProperties.Address2,
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
                broker.PostCreateCardAsync(It.IsAny<ExternalCreateCardRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<CreateCard> retrieveCreateCardTask =
               this.authService.PostCreateCardRequestAsync(createCard);

            CardDependencyException
                actualCardDependencyException =
                    await Assert.ThrowsAsync<CardDependencyException>(
                        retrieveCreateCardTask.AsTask);

            // then
            actualCardDependencyException.Should().BeEquivalentTo(
                expectedCardDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostCreateCardAsync(It.IsAny<ExternalCreateCardRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnCreateCardRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given

            dynamic createRandomCreateCardRequestProperties =
             CreateRandomCreateCardRequestProperties();

            var createCardRequest = new ExternalCreateCardRequest
            {
                CustomerId = createRandomCreateCardRequestProperties.CustomerId,
                Address1 = createRandomCreateCardRequestProperties.Address1,
                Address2 = createRandomCreateCardRequestProperties.Address2,
            };

            var createCard = new CreateCard
            {
                Request = new CreateCardRequest
                {
                    CustomerId = createRandomCreateCardRequestProperties.CustomerId,
                 Address1 = createRandomCreateCardRequestProperties.Address1,
                 Address2 = createRandomCreateCardRequestProperties.Address2,
                },
            };

            var unauthorizedCardException =
                new UnauthorizedCardException(unauthorizedException);

            var expectedCardDependencyException =
                new CardDependencyException(unauthorizedCardException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.PostCreateCardAsync(It.IsAny<ExternalCreateCardRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<CreateCard> retrieveCreateCardTask =
               this.authService.PostCreateCardRequestAsync(createCard);

            CardDependencyException
                actualCardDependencyException =
                    await Assert.ThrowsAsync<CardDependencyException>(
                        retrieveCreateCardTask.AsTask);

            // then
            actualCardDependencyException.Should().BeEquivalentTo(
                expectedCardDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostCreateCardAsync(It.IsAny<ExternalCreateCardRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnCreateCardRequestIfNotFoundOccurredAsync()
        {
            // given

                dynamic createRandomCreateCardRequestProperties =
                 CreateRandomCreateCardRequestProperties();

            var createCardRequest = new ExternalCreateCardRequest
            {
                CustomerId = createRandomCreateCardRequestProperties.CustomerId,
                 Address1 = createRandomCreateCardRequestProperties.Address1,
                 Address2 = createRandomCreateCardRequestProperties.Address2,
            };

            var createCard = new CreateCard
            {
                Request = new CreateCardRequest
                {
                    CustomerId = createRandomCreateCardRequestProperties.CustomerId,
                 Address1 = createRandomCreateCardRequestProperties.Address1,
                 Address2 = createRandomCreateCardRequestProperties.Address2,
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
                broker.PostCreateCardAsync(It.IsAny<ExternalCreateCardRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<CreateCard> retrieveCreateCardTask =
               this.authService.PostCreateCardRequestAsync(createCard);

            CardDependencyValidationException
                actualCardDependencyValidationException =
                    await Assert.ThrowsAsync<CardDependencyValidationException>(
                        retrieveCreateCardTask.AsTask);

            // then
            actualCardDependencyValidationException.Should().BeEquivalentTo(
                expectedCardDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostCreateCardAsync(It.IsAny<ExternalCreateCardRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnCreateCardRequestIfBadRequestOccurredAsync()
        {
            // given

                dynamic createRandomCreateCardRequestProperties =
                 CreateRandomCreateCardRequestProperties();

            var createCardRequest = new ExternalCreateCardRequest
            {
                CustomerId = createRandomCreateCardRequestProperties.CustomerId,
                 Address1 = createRandomCreateCardRequestProperties.Address1,
                 Address2 = createRandomCreateCardRequestProperties.Address2,
            };

            var createCard = new CreateCard
            {
                Request = new CreateCardRequest
                {
                    CustomerId = createRandomCreateCardRequestProperties.CustomerId,
                 Address1 = createRandomCreateCardRequestProperties.Address1,
                 Address2 = createRandomCreateCardRequestProperties.Address2,
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
                broker.PostCreateCardAsync(It.IsAny<ExternalCreateCardRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<CreateCard> retrieveCreateCardTask =
               this.authService.PostCreateCardRequestAsync(createCard);

            CardDependencyValidationException
                actualCardDependencyValidationException =
                    await Assert.ThrowsAsync<CardDependencyValidationException>(
                        retrieveCreateCardTask.AsTask);

            // then
            actualCardDependencyValidationException.Should().BeEquivalentTo(
                expectedCardDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostCreateCardAsync(It.IsAny<ExternalCreateCardRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnCreateCardRequestIfTooManyRequestsOccurredAsync()
        {
            // given

                dynamic createRandomCreateCardRequestProperties =
                 CreateRandomCreateCardRequestProperties();

            var createCardRequest = new ExternalCreateCardRequest
            {
                CustomerId = createRandomCreateCardRequestProperties.CustomerId,
                 Address1 = createRandomCreateCardRequestProperties.Address1,
                 Address2 = createRandomCreateCardRequestProperties.Address2,
            };

            var createCard = new CreateCard
            {
                Request = new CreateCardRequest
                {
                    CustomerId = createRandomCreateCardRequestProperties.CustomerId,
                 Address1 = createRandomCreateCardRequestProperties.Address1,
                 Address2 = createRandomCreateCardRequestProperties.Address2,
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
                 broker.PostCreateCardAsync(It.IsAny<ExternalCreateCardRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<CreateCard> retrieveCreateCardTask =
               this.authService.PostCreateCardRequestAsync(createCard);

            CardDependencyValidationException actualCardDependencyValidationException =
                await Assert.ThrowsAsync<CardDependencyValidationException>(
                    retrieveCreateCardTask.AsTask);

            // then
            actualCardDependencyValidationException.Should().BeEquivalentTo(
                expectedCardDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostCreateCardAsync(It.IsAny<ExternalCreateCardRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnCreateCardRequestIfHttpResponseErrorOccurredAsync()
        {
            // given

                dynamic createRandomCreateCardRequestProperties =
                 CreateRandomCreateCardRequestProperties();

            var createCardRequest = new ExternalCreateCardRequest
            {
                CustomerId = createRandomCreateCardRequestProperties.CustomerId,
                 Address1 = createRandomCreateCardRequestProperties.Address1,
                 Address2 = createRandomCreateCardRequestProperties.Address2,
            };

            var createCard = new CreateCard
            {
                Request = new CreateCardRequest
                {
                    CustomerId = createRandomCreateCardRequestProperties.CustomerId,
                 Address1 = createRandomCreateCardRequestProperties.Address1,
                 Address2 = createRandomCreateCardRequestProperties.Address2,
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
                 broker.PostCreateCardAsync(It.IsAny<ExternalCreateCardRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<CreateCard> retrieveCreateCardTask =
               this.authService.PostCreateCardRequestAsync(createCard);

            CardDependencyException actualCardDependencyException =
                await Assert.ThrowsAsync<CardDependencyException>(
                    retrieveCreateCardTask.AsTask);

            // then
            actualCardDependencyException.Should().BeEquivalentTo(
                expectedCardDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostCreateCardAsync(It.IsAny<ExternalCreateCardRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnCreateCardRequestIfServiceErrorOccurredAsync()
        {
            // given

                dynamic createRandomCreateCardRequestProperties =
                 CreateRandomCreateCardRequestProperties();

            var createCardRequest = new ExternalCreateCardRequest
            {
                CustomerId = createRandomCreateCardRequestProperties.CustomerId,
                 Address1 = createRandomCreateCardRequestProperties.Address1,
                 Address2 = createRandomCreateCardRequestProperties.Address2,
            };

            var createCard = new CreateCard
            {
                Request = new CreateCardRequest
                {
                    CustomerId = createRandomCreateCardRequestProperties.CustomerId,
                 Address1 = createRandomCreateCardRequestProperties.Address1,
                 Address2 = createRandomCreateCardRequestProperties.Address2,
                },
            };
            var serviceException = new Exception();

            var failedCardServiceException =
                new FailedCardServiceException(serviceException);

            var expectedCardServiceException =
                new CardServiceException(failedCardServiceException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostCreateCardAsync(It.IsAny<ExternalCreateCardRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<CreateCard> retrieveCreateCardTask =
               this.authService.PostCreateCardRequestAsync(createCard);

            CardServiceException actualCardServiceException =
                await Assert.ThrowsAsync<CardServiceException>(
                    retrieveCreateCardTask.AsTask);

            // then
            actualCardServiceException.Should().BeEquivalentTo(
                expectedCardServiceException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostCreateCardAsync(It.IsAny<ExternalCreateCardRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
