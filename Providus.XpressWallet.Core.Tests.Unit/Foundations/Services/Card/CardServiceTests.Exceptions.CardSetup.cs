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
        public async Task ShouldThrowDependencyExceptionOnCardSetupRequestIfUrlNotFoundAsync()
        {
            // given

            dynamic createRandomCardSetupRequestProperties =
                 CreateRandomCardSetupRequestProperties();

            var cardSetupRequest = new ExternalCardSetupRequest
            {
                AppId = createRandomCardSetupRequestProperties.AppId,
                AppKey = createRandomCardSetupRequestProperties.AppKey,
                LoadingAccountName = createRandomCardSetupRequestProperties.LoadingAccountName,
                LoadingAccountNumber = createRandomCardSetupRequestProperties.LoadingAccountNumber,
                LoadingAccountSortcode = createRandomCardSetupRequestProperties.LoadingAccountSortcode,
                PrepaidCardPrefix = createRandomCardSetupRequestProperties.PrepaidCardPrefix
            };

            var cardSetup = new CardSetup
            {
                Request = new CardSetupRequest
                {
                    AppId = createRandomCardSetupRequestProperties.AppId,
                    AppKey = createRandomCardSetupRequestProperties.AppKey,
                    LoadingAccountName = createRandomCardSetupRequestProperties.LoadingAccountName,
                    LoadingAccountNumber = createRandomCardSetupRequestProperties.LoadingAccountNumber,
                    LoadingAccountSortcode = createRandomCardSetupRequestProperties.LoadingAccountSortcode,
                    PrepaidCardPrefix = createRandomCardSetupRequestProperties.PrepaidCardPrefix
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
                broker.PutCardSetupAsync(It.IsAny<ExternalCardSetupRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<CardSetup> retrieveCardSetupTask =
               this.authService.PutCardSetupRequestAsync(cardSetup);

            CardDependencyException
                actualCardDependencyException =
                    await Assert.ThrowsAsync<CardDependencyException>(
                        retrieveCardSetupTask.AsTask);

            // then
            actualCardDependencyException.Should().BeEquivalentTo(
                expectedCardDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PutCardSetupAsync(It.IsAny<ExternalCardSetupRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnCardSetupRequestIfUnCardorizedAsync(
            HttpResponseException unCardorizedException)
        {
            // given

            dynamic createRandomCardSetupRequestProperties =
             CreateRandomCardSetupRequestProperties();

            var cardSetupRequest = new ExternalCardSetupRequest
            {
                AppId = createRandomCardSetupRequestProperties.AppId,
                AppKey = createRandomCardSetupRequestProperties.AppKey,
                LoadingAccountName = createRandomCardSetupRequestProperties.LoadingAccountName,
                LoadingAccountNumber = createRandomCardSetupRequestProperties.LoadingAccountNumber,
                LoadingAccountSortcode = createRandomCardSetupRequestProperties.LoadingAccountSortcode,
                PrepaidCardPrefix = createRandomCardSetupRequestProperties.PrepaidCardPrefix
            };

            var cardSetup = new CardSetup
            {
                Request = new CardSetupRequest
                {
                    AppId = createRandomCardSetupRequestProperties.AppId,
                    AppKey = createRandomCardSetupRequestProperties.AppKey,
                    LoadingAccountName = createRandomCardSetupRequestProperties.LoadingAccountName,
                    LoadingAccountNumber = createRandomCardSetupRequestProperties.LoadingAccountNumber,
                    LoadingAccountSortcode = createRandomCardSetupRequestProperties.LoadingAccountSortcode,
                    PrepaidCardPrefix = createRandomCardSetupRequestProperties.PrepaidCardPrefix
                },
            };

            var unauthorizedCardException =
                new UnauthorizedCardException(unCardorizedException);

            var expectedCardDependencyException =
                new CardDependencyException(unauthorizedCardException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.PutCardSetupAsync(It.IsAny<ExternalCardSetupRequest>()))
                     .ThrowsAsync(unCardorizedException);

            // when
            ValueTask<CardSetup> retrieveCardSetupTask =
               this.authService.PutCardSetupRequestAsync(cardSetup);

            CardDependencyException
                actualCardDependencyException =
                    await Assert.ThrowsAsync<CardDependencyException>(
                        retrieveCardSetupTask.AsTask);

            // then
            actualCardDependencyException.Should().BeEquivalentTo(
                expectedCardDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PutCardSetupAsync(It.IsAny<ExternalCardSetupRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnCardSetupRequestIfNotFoundOccurredAsync()
        {
            // given

                dynamic createRandomCardSetupRequestProperties =
                 CreateRandomCardSetupRequestProperties();

            var cardSetupRequest = new ExternalCardSetupRequest
            {
                AppId = createRandomCardSetupRequestProperties.AppId,
                AppKey = createRandomCardSetupRequestProperties.AppKey,
                LoadingAccountName = createRandomCardSetupRequestProperties.LoadingAccountName,
                LoadingAccountNumber = createRandomCardSetupRequestProperties.LoadingAccountNumber,
                LoadingAccountSortcode = createRandomCardSetupRequestProperties.LoadingAccountSortcode,
                PrepaidCardPrefix = createRandomCardSetupRequestProperties.PrepaidCardPrefix
            };

            var cardSetup = new CardSetup
            {
                Request = new CardSetupRequest
                {
                    AppId = createRandomCardSetupRequestProperties.AppId,
                    AppKey = createRandomCardSetupRequestProperties.AppKey,
                    LoadingAccountName = createRandomCardSetupRequestProperties.LoadingAccountName,
                    LoadingAccountNumber = createRandomCardSetupRequestProperties.LoadingAccountNumber,
                    LoadingAccountSortcode = createRandomCardSetupRequestProperties.LoadingAccountSortcode,
                    PrepaidCardPrefix = createRandomCardSetupRequestProperties.PrepaidCardPrefix
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
                broker.PutCardSetupAsync(It.IsAny<ExternalCardSetupRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<CardSetup> retrieveCardSetupTask =
               this.authService.PutCardSetupRequestAsync(cardSetup);

            CardDependencyValidationException
                actualCardDependencyValidationException =
                    await Assert.ThrowsAsync<CardDependencyValidationException>(
                        retrieveCardSetupTask.AsTask);

            // then
            actualCardDependencyValidationException.Should().BeEquivalentTo(
                expectedCardDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PutCardSetupAsync(It.IsAny<ExternalCardSetupRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnCardSetupRequestIfBadRequestOccurredAsync()
        {
            // given

                dynamic createRandomCardSetupRequestProperties =
                 CreateRandomCardSetupRequestProperties();

            var cardSetupRequest = new ExternalCardSetupRequest
            {
                AppId = createRandomCardSetupRequestProperties.AppId,
                AppKey = createRandomCardSetupRequestProperties.AppKey,
                LoadingAccountName = createRandomCardSetupRequestProperties.LoadingAccountName,
                LoadingAccountNumber = createRandomCardSetupRequestProperties.LoadingAccountNumber,
                LoadingAccountSortcode = createRandomCardSetupRequestProperties.LoadingAccountSortcode,
                PrepaidCardPrefix = createRandomCardSetupRequestProperties.PrepaidCardPrefix
            };

            var cardSetup = new CardSetup
            {
                Request = new CardSetupRequest
                {
                    AppId = createRandomCardSetupRequestProperties.AppId,
                    AppKey = createRandomCardSetupRequestProperties.AppKey,
                    LoadingAccountName = createRandomCardSetupRequestProperties.LoadingAccountName,
                    LoadingAccountNumber = createRandomCardSetupRequestProperties.LoadingAccountNumber,
                    LoadingAccountSortcode = createRandomCardSetupRequestProperties.LoadingAccountSortcode,
                    PrepaidCardPrefix = createRandomCardSetupRequestProperties.PrepaidCardPrefix
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
                broker.PutCardSetupAsync(It.IsAny<ExternalCardSetupRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<CardSetup> retrieveCardSetupTask =
               this.authService.PutCardSetupRequestAsync(cardSetup);

            CardDependencyValidationException
                actualCardDependencyValidationException =
                    await Assert.ThrowsAsync<CardDependencyValidationException>(
                        retrieveCardSetupTask.AsTask);

            // then
            actualCardDependencyValidationException.Should().BeEquivalentTo(
                expectedCardDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PutCardSetupAsync(It.IsAny<ExternalCardSetupRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnCardSetupRequestIfTooManyRequestsOccurredAsync()
        {
            // given

                dynamic createRandomCardSetupRequestProperties =
                 CreateRandomCardSetupRequestProperties();

            var cardSetupRequest = new ExternalCardSetupRequest
            {
                AppId = createRandomCardSetupRequestProperties.AppId,
                AppKey = createRandomCardSetupRequestProperties.AppKey,
                LoadingAccountName = createRandomCardSetupRequestProperties.LoadingAccountName,
                LoadingAccountNumber = createRandomCardSetupRequestProperties.LoadingAccountNumber,
                LoadingAccountSortcode = createRandomCardSetupRequestProperties.LoadingAccountSortcode,
                PrepaidCardPrefix = createRandomCardSetupRequestProperties.PrepaidCardPrefix
            };

            var cardSetup = new CardSetup
            {
                Request = new CardSetupRequest
                {
                    AppId = createRandomCardSetupRequestProperties.AppId,
                    AppKey = createRandomCardSetupRequestProperties.AppKey,
                    LoadingAccountName = createRandomCardSetupRequestProperties.LoadingAccountName,
                    LoadingAccountNumber = createRandomCardSetupRequestProperties.LoadingAccountNumber,
                    LoadingAccountSortcode = createRandomCardSetupRequestProperties.LoadingAccountSortcode,
                    PrepaidCardPrefix = createRandomCardSetupRequestProperties.PrepaidCardPrefix
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
                 broker.PutCardSetupAsync(It.IsAny<ExternalCardSetupRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<CardSetup> retrieveCardSetupTask =
               this.authService.PutCardSetupRequestAsync(cardSetup);

            CardDependencyValidationException actualCardDependencyValidationException =
                await Assert.ThrowsAsync<CardDependencyValidationException>(
                    retrieveCardSetupTask.AsTask);

            // then
            actualCardDependencyValidationException.Should().BeEquivalentTo(
                expectedCardDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PutCardSetupAsync(It.IsAny<ExternalCardSetupRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnCardSetupRequestIfHttpResponseErrorOccurredAsync()
        {
            // given

                dynamic createRandomCardSetupRequestProperties =
                 CreateRandomCardSetupRequestProperties();

            var cardSetupRequest = new ExternalCardSetupRequest
            {
                AppId = createRandomCardSetupRequestProperties.AppId,
                AppKey = createRandomCardSetupRequestProperties.AppKey,
                LoadingAccountName = createRandomCardSetupRequestProperties.LoadingAccountName,
                LoadingAccountNumber = createRandomCardSetupRequestProperties.LoadingAccountNumber,
                LoadingAccountSortcode = createRandomCardSetupRequestProperties.LoadingAccountSortcode,
                PrepaidCardPrefix = createRandomCardSetupRequestProperties.PrepaidCardPrefix
            };

            var cardSetup = new CardSetup
            {
                Request = new CardSetupRequest
                {
                    AppId = createRandomCardSetupRequestProperties.AppId,
                    AppKey = createRandomCardSetupRequestProperties.AppKey,
                    LoadingAccountName = createRandomCardSetupRequestProperties.LoadingAccountName,
                    LoadingAccountNumber = createRandomCardSetupRequestProperties.LoadingAccountNumber,
                    LoadingAccountSortcode = createRandomCardSetupRequestProperties.LoadingAccountSortcode,
                    PrepaidCardPrefix = createRandomCardSetupRequestProperties.PrepaidCardPrefix
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
                 broker.PutCardSetupAsync(It.IsAny<ExternalCardSetupRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<CardSetup> retrieveCardSetupTask =
               this.authService.PutCardSetupRequestAsync(cardSetup);

            CardDependencyException actualCardDependencyException =
                await Assert.ThrowsAsync<CardDependencyException>(
                    retrieveCardSetupTask.AsTask);

            // then
            actualCardDependencyException.Should().BeEquivalentTo(
                expectedCardDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PutCardSetupAsync(It.IsAny<ExternalCardSetupRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnCardSetupRequestIfServiceErrorOccurredAsync()
        {
            // given

                dynamic createRandomCardSetupRequestProperties =
                 CreateRandomCardSetupRequestProperties();

            var cardSetupRequest = new ExternalCardSetupRequest
            {
                AppId = createRandomCardSetupRequestProperties.AppId,
                AppKey = createRandomCardSetupRequestProperties.AppKey,
                LoadingAccountName = createRandomCardSetupRequestProperties.LoadingAccountName,
                LoadingAccountNumber = createRandomCardSetupRequestProperties.LoadingAccountNumber,
                LoadingAccountSortcode = createRandomCardSetupRequestProperties.LoadingAccountSortcode,
                PrepaidCardPrefix = createRandomCardSetupRequestProperties.PrepaidCardPrefix
            };

            var cardSetup = new CardSetup
            {
                Request = new CardSetupRequest
                {
                    AppId = createRandomCardSetupRequestProperties.AppId,
                    AppKey = createRandomCardSetupRequestProperties.AppKey,
                    LoadingAccountName = createRandomCardSetupRequestProperties.LoadingAccountName,
                    LoadingAccountNumber = createRandomCardSetupRequestProperties.LoadingAccountNumber,
                    LoadingAccountSortcode = createRandomCardSetupRequestProperties.LoadingAccountSortcode,
                    PrepaidCardPrefix = createRandomCardSetupRequestProperties.PrepaidCardPrefix
                },
            };
            var serviceException = new Exception();

            var failedCardServiceException =
                new FailedCardServiceException(serviceException);

            var expectedCardServiceException =
                new CardServiceException(failedCardServiceException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PutCardSetupAsync(It.IsAny<ExternalCardSetupRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<CardSetup> retrieveCardSetupTask =
               this.authService.PutCardSetupRequestAsync(cardSetup);

            CardServiceException actualCardServiceException =
                await Assert.ThrowsAsync<CardServiceException>(
                    retrieveCardSetupTask.AsTask);

            // then
            actualCardServiceException.Should().BeEquivalentTo(
                expectedCardServiceException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PutCardSetupAsync(It.IsAny<ExternalCardSetupRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
