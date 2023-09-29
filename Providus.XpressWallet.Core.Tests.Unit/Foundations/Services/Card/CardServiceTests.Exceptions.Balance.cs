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
        public async Task ShouldThrowDependencyExceptionOnBalanceRequestIfUrlNotFoundAsync()
        {
            // given
            var inputCustomerId = GetRandomString();


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
                broker.GetBalanceAsync(It.IsAny<string>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<Balance> retrieveBalanceTask =
               this.authService.GetBalanceRequestAsync(inputCustomerId);

            CardDependencyException
                actualCardDependencyException =
                    await Assert.ThrowsAsync<CardDependencyException>(
                        retrieveBalanceTask.AsTask);

            // then
            actualCardDependencyException.Should().BeEquivalentTo(
                expectedCardDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetBalanceAsync(It.IsAny<string>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnBalanceRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            var inputCustomerId = GetRandomString();

        
            var unauthorizedCardException =
                new UnauthorizedCardException(unauthorizedException);

            var expectedCardDependencyException =
                new CardDependencyException(unauthorizedCardException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.GetBalanceAsync(It.IsAny<string>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<Balance> retrieveBalanceTask =
               this.authService.GetBalanceRequestAsync(inputCustomerId);

            CardDependencyException
                actualCardDependencyException =
                    await Assert.ThrowsAsync<CardDependencyException>(
                        retrieveBalanceTask.AsTask);

            // then
            actualCardDependencyException.Should().BeEquivalentTo(
                expectedCardDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetBalanceAsync(It.IsAny<string>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnBalanceRequestIfNotFoundOccurredAsync()
        {
            // given
            var inputCustomerId = GetRandomString();



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
                broker.GetBalanceAsync(It.IsAny<string>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<Balance> retrieveBalanceTask =
               this.authService.GetBalanceRequestAsync(inputCustomerId);

            CardDependencyValidationException
                actualCardDependencyValidationException =
                    await Assert.ThrowsAsync<CardDependencyValidationException>(
                        retrieveBalanceTask.AsTask);

            // then
            actualCardDependencyValidationException.Should().BeEquivalentTo(
                expectedCardDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetBalanceAsync(It.IsAny<string>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnBalanceRequestIfBadRequestOccurredAsync()
        {
            // given
            var inputCustomerId = GetRandomString();

                

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
                broker.GetBalanceAsync(It.IsAny<string>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<Balance> retrieveBalanceTask =
               this.authService.GetBalanceRequestAsync(inputCustomerId);

            CardDependencyValidationException
                actualCardDependencyValidationException =
                    await Assert.ThrowsAsync<CardDependencyValidationException>(
                        retrieveBalanceTask.AsTask);

            // then
            actualCardDependencyValidationException.Should().BeEquivalentTo(
                expectedCardDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetBalanceAsync(It.IsAny<string>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnBalanceRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            var inputCustomerId = GetRandomString();

                

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
                 broker.GetBalanceAsync(It.IsAny<string>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<Balance> retrieveBalanceTask =
               this.authService.GetBalanceRequestAsync(inputCustomerId);

            CardDependencyValidationException actualCardDependencyValidationException =
                await Assert.ThrowsAsync<CardDependencyValidationException>(
                    retrieveBalanceTask.AsTask);

            // then
            actualCardDependencyValidationException.Should().BeEquivalentTo(
                expectedCardDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetBalanceAsync(It.IsAny<string>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnBalanceRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            var inputCustomerId = GetRandomString();

                

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
                 broker.GetBalanceAsync(It.IsAny<string>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<Balance> retrieveBalanceTask =
               this.authService.GetBalanceRequestAsync(inputCustomerId);

            CardDependencyException actualCardDependencyException =
                await Assert.ThrowsAsync<CardDependencyException>(
                    retrieveBalanceTask.AsTask);

            // then
            actualCardDependencyException.Should().BeEquivalentTo(
                expectedCardDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetBalanceAsync(It.IsAny<string>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnBalanceRequestIfServiceErrorOccurredAsync()
        {
            // given
            var inputCustomerId = GetRandomString();

                
            var serviceException = new Exception();

            var failedCardServiceException =
                new FailedCardServiceException(serviceException);

            var expectedCardServiceException =
                new CardServiceException(failedCardServiceException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.GetBalanceAsync(It.IsAny<string>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<Balance> retrieveBalanceTask =
               this.authService.GetBalanceRequestAsync(inputCustomerId);

            CardServiceException actualCardServiceException =
                await Assert.ThrowsAsync<CardServiceException>(
                    retrieveBalanceTask.AsTask);

            // then
            actualCardServiceException.Should().BeEquivalentTo(
                expectedCardServiceException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetBalanceAsync(It.IsAny<string>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
