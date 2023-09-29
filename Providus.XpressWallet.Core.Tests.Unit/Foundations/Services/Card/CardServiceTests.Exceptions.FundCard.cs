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
        public async Task ShouldThrowDependencyExceptionOnFundCardRequestIfUrlNotFoundAsync()
        {
            // given

            dynamic createRandomFundCardRequestProperties =
                 CreateRandomFundCardRequestProperties();

            var fundCardRequest = new ExternalFundCardRequest
            {
               CustomerId = createRandomFundCardRequestProperties.CustomerId,
               Amount = createRandomFundCardRequestProperties.Amount,
            };

            var fundCard = new FundCard
            {
                Request = new FundCardRequest
                {
                    CustomerId = createRandomFundCardRequestProperties.CustomerId,
                    Amount = createRandomFundCardRequestProperties.Amount,
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
                broker.PostFundCardAsync(It.IsAny<ExternalFundCardRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<FundCard> retrieveFundCardTask =
               this.authService.PostFundCardRequestAsync(fundCard);

            CardDependencyException
                actualCardDependencyException =
                    await Assert.ThrowsAsync<CardDependencyException>(
                        retrieveFundCardTask.AsTask);

            // then
            actualCardDependencyException.Should().BeEquivalentTo(
                expectedCardDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostFundCardAsync(It.IsAny<ExternalFundCardRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnFundCardRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given

            dynamic createRandomFundCardRequestProperties =
             CreateRandomFundCardRequestProperties();

            var fundCardRequest = new ExternalFundCardRequest
            {
                CustomerId = createRandomFundCardRequestProperties.CustomerId,
                Amount = createRandomFundCardRequestProperties.Amount,
            };

            var fundCard = new FundCard
            {
                Request = new FundCardRequest
                {
                    CustomerId = createRandomFundCardRequestProperties.CustomerId,
                    Amount = createRandomFundCardRequestProperties.Amount,
                },
            };

            var unauthorizedCardException =
                new UnauthorizedCardException(unauthorizedException);

            var expectedCardDependencyException =
                new CardDependencyException(unauthorizedCardException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.PostFundCardAsync(It.IsAny<ExternalFundCardRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<FundCard> retrieveFundCardTask =
               this.authService.PostFundCardRequestAsync(fundCard);

            CardDependencyException
                actualCardDependencyException =
                    await Assert.ThrowsAsync<CardDependencyException>(
                        retrieveFundCardTask.AsTask);

            // then
            actualCardDependencyException.Should().BeEquivalentTo(
                expectedCardDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostFundCardAsync(It.IsAny<ExternalFundCardRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnFundCardRequestIfNotFoundOccurredAsync()
        {
            // given

                dynamic createRandomFundCardRequestProperties =
                 CreateRandomFundCardRequestProperties();

            var fundCardRequest = new ExternalFundCardRequest
            {
                CustomerId = createRandomFundCardRequestProperties.CustomerId,
               Amount = createRandomFundCardRequestProperties.Amount,
            };

            var fundCard = new FundCard
            {
                Request = new FundCardRequest
                {
                    CustomerId = createRandomFundCardRequestProperties.CustomerId,
               Amount = createRandomFundCardRequestProperties.Amount,
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
                broker.PostFundCardAsync(It.IsAny<ExternalFundCardRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<FundCard> retrieveFundCardTask =
               this.authService.PostFundCardRequestAsync(fundCard);

            CardDependencyValidationException
                actualCardDependencyValidationException =
                    await Assert.ThrowsAsync<CardDependencyValidationException>(
                        retrieveFundCardTask.AsTask);

            // then
            actualCardDependencyValidationException.Should().BeEquivalentTo(
                expectedCardDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostFundCardAsync(It.IsAny<ExternalFundCardRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnFundCardRequestIfBadRequestOccurredAsync()
        {
            // given

                dynamic createRandomFundCardRequestProperties =
                 CreateRandomFundCardRequestProperties();

            var fundCardRequest = new ExternalFundCardRequest
            {
                CustomerId = createRandomFundCardRequestProperties.CustomerId,
               Amount = createRandomFundCardRequestProperties.Amount,
            };

            var fundCard = new FundCard
            {
                Request = new FundCardRequest
                {
                    CustomerId = createRandomFundCardRequestProperties.CustomerId,
               Amount = createRandomFundCardRequestProperties.Amount,
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
                broker.PostFundCardAsync(It.IsAny<ExternalFundCardRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<FundCard> retrieveFundCardTask =
               this.authService.PostFundCardRequestAsync(fundCard);

            CardDependencyValidationException
                actualCardDependencyValidationException =
                    await Assert.ThrowsAsync<CardDependencyValidationException>(
                        retrieveFundCardTask.AsTask);

            // then
            actualCardDependencyValidationException.Should().BeEquivalentTo(
                expectedCardDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostFundCardAsync(It.IsAny<ExternalFundCardRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnFundCardRequestIfTooManyRequestsOccurredAsync()
        {
            // given

                dynamic createRandomFundCardRequestProperties =
                 CreateRandomFundCardRequestProperties();

            var fundCardRequest = new ExternalFundCardRequest
            {
                CustomerId = createRandomFundCardRequestProperties.CustomerId,
               Amount = createRandomFundCardRequestProperties.Amount,
            };

            var fundCard = new FundCard
            {
                Request = new FundCardRequest
                {
                    CustomerId = createRandomFundCardRequestProperties.CustomerId,
               Amount = createRandomFundCardRequestProperties.Amount,
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
                 broker.PostFundCardAsync(It.IsAny<ExternalFundCardRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<FundCard> retrieveFundCardTask =
               this.authService.PostFundCardRequestAsync(fundCard);

            CardDependencyValidationException actualCardDependencyValidationException =
                await Assert.ThrowsAsync<CardDependencyValidationException>(
                    retrieveFundCardTask.AsTask);

            // then
            actualCardDependencyValidationException.Should().BeEquivalentTo(
                expectedCardDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostFundCardAsync(It.IsAny<ExternalFundCardRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnFundCardRequestIfHttpResponseErrorOccurredAsync()
        {
            // given

                dynamic createRandomFundCardRequestProperties =
                 CreateRandomFundCardRequestProperties();

            var fundCardRequest = new ExternalFundCardRequest
            {
                CustomerId = createRandomFundCardRequestProperties.CustomerId,
               Amount = createRandomFundCardRequestProperties.Amount,
            };

            var fundCard = new FundCard
            {
                Request = new FundCardRequest
                {
                    CustomerId = createRandomFundCardRequestProperties.CustomerId,
               Amount = createRandomFundCardRequestProperties.Amount,
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
                 broker.PostFundCardAsync(It.IsAny<ExternalFundCardRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<FundCard> retrieveFundCardTask =
               this.authService.PostFundCardRequestAsync(fundCard);

            CardDependencyException actualCardDependencyException =
                await Assert.ThrowsAsync<CardDependencyException>(
                    retrieveFundCardTask.AsTask);

            // then
            actualCardDependencyException.Should().BeEquivalentTo(
                expectedCardDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostFundCardAsync(It.IsAny<ExternalFundCardRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnFundCardRequestIfServiceErrorOccurredAsync()
        {
            // given

                dynamic createRandomFundCardRequestProperties =
                 CreateRandomFundCardRequestProperties();

            var fundCardRequest = new ExternalFundCardRequest
            {
                CustomerId = createRandomFundCardRequestProperties.CustomerId,
               Amount = createRandomFundCardRequestProperties.Amount,
            };

            var fundCard = new FundCard
            {
                Request = new FundCardRequest
                {
                    CustomerId = createRandomFundCardRequestProperties.CustomerId,
               Amount = createRandomFundCardRequestProperties.Amount,
                },
            };
            var serviceException = new Exception();

            var failedCardServiceException =
                new FailedCardServiceException(serviceException);

            var expectedCardServiceException =
                new CardServiceException(failedCardServiceException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostFundCardAsync(It.IsAny<ExternalFundCardRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<FundCard> retrieveFundCardTask =
               this.authService.PostFundCardRequestAsync(fundCard);

            CardServiceException actualCardServiceException =
                await Assert.ThrowsAsync<CardServiceException>(
                    retrieveFundCardTask.AsTask);

            // then
            actualCardServiceException.Should().BeEquivalentTo(
                expectedCardServiceException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostFundCardAsync(It.IsAny<ExternalFundCardRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
