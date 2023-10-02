using FluentAssertions;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalMerchant;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Merchant;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Merchant.Exceptions;
using RESTFulSense.Exceptions;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.Merchant
{
    public partial class MerchantServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnMerchantRegistrationRequestIfUrlNotFoundAsync()
        {
            // given
            

            dynamic createRandomMerchantRegistrationRequestProperties =
                 CreateRandomMerchantRegistrationRequestProperties();

            var createMerchantRegistrationRequest = new ExternalMerchantRegistrationRequest
            {

                Email = createRandomMerchantRegistrationRequestProperties.Email,
                BusinessType = createRandomMerchantRegistrationRequestProperties.BusinessType,
                BusinessName = createRandomMerchantRegistrationRequestProperties.BusinessName,
                AccountNumber = createRandomMerchantRegistrationRequestProperties.AccountNumber,
                PhoneNumber = createRandomMerchantRegistrationRequestProperties.PhoneNumber,
                LastName = createRandomMerchantRegistrationRequestProperties.LastName,
                FirstName = createRandomMerchantRegistrationRequestProperties.FirstName,
                Password = createRandomMerchantRegistrationRequestProperties.Password,
                SendEmail = createRandomMerchantRegistrationRequestProperties.SendEmail

            };

            var createMerchantRegistration = new MerchantRegistration
            {
                Request = new MerchantRegistrationRequest
                {
                    Email = createRandomMerchantRegistrationRequestProperties.Email,
                    BusinessType = createRandomMerchantRegistrationRequestProperties.BusinessType,
                    BusinessName = createRandomMerchantRegistrationRequestProperties.BusinessName,
                    AccountNumber = createRandomMerchantRegistrationRequestProperties.AccountNumber,
                    PhoneNumber = createRandomMerchantRegistrationRequestProperties.PhoneNumber,
                    LastName = createRandomMerchantRegistrationRequestProperties.LastName,
                    FirstName = createRandomMerchantRegistrationRequestProperties.FirstName,
                    Password = createRandomMerchantRegistrationRequestProperties.Password,
                    SendEmail = createRandomMerchantRegistrationRequestProperties.SendEmail
                },
            };




            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException();

            var invalidConfigurationMerchantException =
                new InvalidConfigurationMerchantException(
                    message: "Invalid Merchant configuration error occurred, contact support.",
                    httpResponseUrlNotFoundException);

            var expectedMerchantDependencyException =
                new MerchantDependencyException(
                    message: "Merchant dependency error occurred, contact support.",
                    invalidConfigurationMerchantException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostMerchantRegistrationAsync(It.IsAny<ExternalMerchantRegistrationRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<MerchantRegistration> retrieveMerchantRegistrationTask =
               this.merchantService.PostMerchantRegistrationRequestAsync(createMerchantRegistration);

            MerchantDependencyException
                actualMerchantDependencyException =
                    await Assert.ThrowsAsync<MerchantDependencyException>(
                        retrieveMerchantRegistrationTask.AsTask);

            // then
            actualMerchantDependencyException.Should().BeEquivalentTo(
                expectedMerchantDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostMerchantRegistrationAsync(It.IsAny<ExternalMerchantRegistrationRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnMerchantRegistrationRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            

            dynamic createRandomMerchantRegistrationRequestProperties =
             CreateRandomMerchantRegistrationRequestProperties();

            var createMerchantRegistrationRequest = new ExternalMerchantRegistrationRequest
            {
                Email = createRandomMerchantRegistrationRequestProperties.Email,
                BusinessType = createRandomMerchantRegistrationRequestProperties.BusinessType,
                BusinessName = createRandomMerchantRegistrationRequestProperties.BusinessName,
                AccountNumber = createRandomMerchantRegistrationRequestProperties.AccountNumber,
                PhoneNumber = createRandomMerchantRegistrationRequestProperties.PhoneNumber,
                LastName = createRandomMerchantRegistrationRequestProperties.LastName,
                FirstName = createRandomMerchantRegistrationRequestProperties.FirstName,
                Password = createRandomMerchantRegistrationRequestProperties.Password,
                SendEmail = createRandomMerchantRegistrationRequestProperties.SendEmail

            };

            var createMerchantRegistration = new MerchantRegistration
            {
                Request = new MerchantRegistrationRequest
                {
                          Email = createRandomMerchantRegistrationRequestProperties.Email,
                BusinessType = createRandomMerchantRegistrationRequestProperties.BusinessType,
                BusinessName = createRandomMerchantRegistrationRequestProperties.BusinessName,
                AccountNumber = createRandomMerchantRegistrationRequestProperties.AccountNumber,
                PhoneNumber = createRandomMerchantRegistrationRequestProperties.PhoneNumber,
                LastName = createRandomMerchantRegistrationRequestProperties.LastName,
                FirstName = createRandomMerchantRegistrationRequestProperties.FirstName,
                Password = createRandomMerchantRegistrationRequestProperties.Password,
                SendEmail = createRandomMerchantRegistrationRequestProperties.SendEmail
                },
            };


            var unauthorizedMerchantException =
                new UnauthorizedMerchantException(unauthorizedException);

            var expectedMerchantDependencyException =
                new MerchantDependencyException(unauthorizedMerchantException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.PostMerchantRegistrationAsync(It.IsAny<ExternalMerchantRegistrationRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<MerchantRegistration> retrieveMerchantRegistrationTask =
               this.merchantService.PostMerchantRegistrationRequestAsync(createMerchantRegistration);

            MerchantDependencyException
                actualMerchantDependencyException =
                    await Assert.ThrowsAsync<MerchantDependencyException>(
                        retrieveMerchantRegistrationTask.AsTask);

            // then
            actualMerchantDependencyException.Should().BeEquivalentTo(
                expectedMerchantDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostMerchantRegistrationAsync(It.IsAny<ExternalMerchantRegistrationRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnMerchantRegistrationRequestIfNotFoundOccurredAsync()
        {
            // given
            

                dynamic createRandomMerchantRegistrationRequestProperties =
                 CreateRandomMerchantRegistrationRequestProperties();

            var createMerchantRegistrationRequest = new ExternalMerchantRegistrationRequest
            {
                        Email = createRandomMerchantRegistrationRequestProperties.Email,
                BusinessType = createRandomMerchantRegistrationRequestProperties.BusinessType,
                BusinessName = createRandomMerchantRegistrationRequestProperties.BusinessName,
                AccountNumber = createRandomMerchantRegistrationRequestProperties.AccountNumber,
                PhoneNumber = createRandomMerchantRegistrationRequestProperties.PhoneNumber,
                LastName = createRandomMerchantRegistrationRequestProperties.LastName,
                FirstName = createRandomMerchantRegistrationRequestProperties.FirstName,
                Password = createRandomMerchantRegistrationRequestProperties.Password,
                SendEmail = createRandomMerchantRegistrationRequestProperties.SendEmail
            };

            var createMerchantRegistration = new MerchantRegistration
            {
                Request = new MerchantRegistrationRequest
                {
                          Email = createRandomMerchantRegistrationRequestProperties.Email,
                BusinessType = createRandomMerchantRegistrationRequestProperties.BusinessType,
                BusinessName = createRandomMerchantRegistrationRequestProperties.BusinessName,
                AccountNumber = createRandomMerchantRegistrationRequestProperties.AccountNumber,
                PhoneNumber = createRandomMerchantRegistrationRequestProperties.PhoneNumber,
                LastName = createRandomMerchantRegistrationRequestProperties.LastName,
                FirstName = createRandomMerchantRegistrationRequestProperties.FirstName,
                Password = createRandomMerchantRegistrationRequestProperties.Password,
                SendEmail = createRandomMerchantRegistrationRequestProperties.SendEmail
                },
            };


            var httpResponseNotFoundException =
                new HttpResponseNotFoundException();

            var notFoundMerchantException =
                new NotFoundMerchantException(
                    message: "Not found Merchant error occurred, fix errors and try again.",
                    httpResponseNotFoundException);

            var expectedMerchantDependencyValidationException =
                new MerchantDependencyValidationException(
                    message: "Merchant dependency validation error occurred, contact support.",
                    notFoundMerchantException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostMerchantRegistrationAsync(It.IsAny<ExternalMerchantRegistrationRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<MerchantRegistration> retrieveMerchantRegistrationTask =
               this.merchantService.PostMerchantRegistrationRequestAsync(createMerchantRegistration);

            MerchantDependencyValidationException
                actualMerchantDependencyValidationException =
                    await Assert.ThrowsAsync<MerchantDependencyValidationException>(
                        retrieveMerchantRegistrationTask.AsTask);

            // then
            actualMerchantDependencyValidationException.Should().BeEquivalentTo(
                expectedMerchantDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostMerchantRegistrationAsync(It.IsAny<ExternalMerchantRegistrationRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnMerchantRegistrationRequestIfBadRequestOccurredAsync()
        {
            // given
            

                dynamic createRandomMerchantRegistrationRequestProperties =
                 CreateRandomMerchantRegistrationRequestProperties();

            var createMerchantRegistrationRequest = new ExternalMerchantRegistrationRequest
            {
                                      Email = createRandomMerchantRegistrationRequestProperties.Email,
                BusinessType = createRandomMerchantRegistrationRequestProperties.BusinessType,
                BusinessName = createRandomMerchantRegistrationRequestProperties.BusinessName,
                AccountNumber = createRandomMerchantRegistrationRequestProperties.AccountNumber,
                PhoneNumber = createRandomMerchantRegistrationRequestProperties.PhoneNumber,
                LastName = createRandomMerchantRegistrationRequestProperties.LastName,
                FirstName = createRandomMerchantRegistrationRequestProperties.FirstName,
                Password = createRandomMerchantRegistrationRequestProperties.Password,
                SendEmail = createRandomMerchantRegistrationRequestProperties.SendEmail
            };

            var createMerchantRegistration = new MerchantRegistration
            {
                Request = new MerchantRegistrationRequest
                {
                                 Email = createRandomMerchantRegistrationRequestProperties.Email,
                BusinessType = createRandomMerchantRegistrationRequestProperties.BusinessType,
                BusinessName = createRandomMerchantRegistrationRequestProperties.BusinessName,
                AccountNumber = createRandomMerchantRegistrationRequestProperties.AccountNumber,
                PhoneNumber = createRandomMerchantRegistrationRequestProperties.PhoneNumber,
                LastName = createRandomMerchantRegistrationRequestProperties.LastName,
                FirstName = createRandomMerchantRegistrationRequestProperties.FirstName,
                Password = createRandomMerchantRegistrationRequestProperties.Password,
                SendEmail = createRandomMerchantRegistrationRequestProperties.SendEmail
                },
            };

            var httpResponseBadRequestException =
                new HttpResponseBadRequestException();

            var invalidMerchantException =
                new InvalidMerchantException(
                    message: "Invalid Merchant error occurred, fix errors and try again.",
                    httpResponseBadRequestException);

            var expectedMerchantDependencyValidationException =
                new MerchantDependencyValidationException(
                    message: "Merchant dependency validation error occurred, contact support.",
                    invalidMerchantException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostMerchantRegistrationAsync(It.IsAny<ExternalMerchantRegistrationRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<MerchantRegistration> retrieveMerchantRegistrationTask =
               this.merchantService.PostMerchantRegistrationRequestAsync(createMerchantRegistration);

            MerchantDependencyValidationException
                actualMerchantDependencyValidationException =
                    await Assert.ThrowsAsync<MerchantDependencyValidationException>(
                        retrieveMerchantRegistrationTask.AsTask);

            // then
            actualMerchantDependencyValidationException.Should().BeEquivalentTo(
                expectedMerchantDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostMerchantRegistrationAsync(It.IsAny<ExternalMerchantRegistrationRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnMerchantRegistrationRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            

                dynamic createRandomMerchantRegistrationRequestProperties =
                 CreateRandomMerchantRegistrationRequestProperties();

            var createMerchantRegistrationRequest = new ExternalMerchantRegistrationRequest
            {
                    Email = createRandomMerchantRegistrationRequestProperties.Email,
                    BusinessType = createRandomMerchantRegistrationRequestProperties.BusinessType,
                    BusinessName = createRandomMerchantRegistrationRequestProperties.BusinessName,
                    AccountNumber = createRandomMerchantRegistrationRequestProperties.AccountNumber,
                    PhoneNumber = createRandomMerchantRegistrationRequestProperties.PhoneNumber,
                    LastName = createRandomMerchantRegistrationRequestProperties.LastName,
                    FirstName = createRandomMerchantRegistrationRequestProperties.FirstName,
                    Password = createRandomMerchantRegistrationRequestProperties.Password,
                    SendEmail = createRandomMerchantRegistrationRequestProperties.SendEmail
            };

            var createMerchantRegistration = new MerchantRegistration
            {
                Request = new MerchantRegistrationRequest
                {
                    Email = createRandomMerchantRegistrationRequestProperties.Email,
                    BusinessType = createRandomMerchantRegistrationRequestProperties.BusinessType,
                    BusinessName = createRandomMerchantRegistrationRequestProperties.BusinessName,
                    AccountNumber = createRandomMerchantRegistrationRequestProperties.AccountNumber,
                    PhoneNumber = createRandomMerchantRegistrationRequestProperties.PhoneNumber,
                    LastName = createRandomMerchantRegistrationRequestProperties.LastName,
                    FirstName = createRandomMerchantRegistrationRequestProperties.FirstName,
                    Password = createRandomMerchantRegistrationRequestProperties.Password,
                    SendEmail = createRandomMerchantRegistrationRequestProperties.SendEmail
                },
            };

            var httpResponseTooManyRequestsException =
                new HttpResponseTooManyRequestsException();

            var excessiveCallMerchantException =
                new ExcessiveCallMerchantException(
                    message: "Excessive call error occurred, limit your calls.",
                    httpResponseTooManyRequestsException);

            var expectedMerchantDependencyValidationException =
                new MerchantDependencyValidationException(
                    message: "Merchant dependency validation error occurred, contact support.",
                    excessiveCallMerchantException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.PostMerchantRegistrationAsync(It.IsAny<ExternalMerchantRegistrationRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<MerchantRegistration> retrieveMerchantRegistrationTask =
               this.merchantService.PostMerchantRegistrationRequestAsync(createMerchantRegistration);

            MerchantDependencyValidationException actualMerchantDependencyValidationException =
                await Assert.ThrowsAsync<MerchantDependencyValidationException>(
                    retrieveMerchantRegistrationTask.AsTask);

            // then
            actualMerchantDependencyValidationException.Should().BeEquivalentTo(
                expectedMerchantDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostMerchantRegistrationAsync(It.IsAny<ExternalMerchantRegistrationRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnMerchantRegistrationRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            

                dynamic createRandomMerchantRegistrationRequestProperties =
                 CreateRandomMerchantRegistrationRequestProperties();

            var createMerchantRegistrationRequest = new ExternalMerchantRegistrationRequest
            {
                Email = createRandomMerchantRegistrationRequestProperties.Email,
                BusinessType = createRandomMerchantRegistrationRequestProperties.BusinessType,
                BusinessName = createRandomMerchantRegistrationRequestProperties.BusinessName,
                AccountNumber = createRandomMerchantRegistrationRequestProperties.AccountNumber,
                PhoneNumber = createRandomMerchantRegistrationRequestProperties.PhoneNumber,
                LastName = createRandomMerchantRegistrationRequestProperties.LastName,
                FirstName = createRandomMerchantRegistrationRequestProperties.FirstName,
                Password = createRandomMerchantRegistrationRequestProperties.Password,
                SendEmail = createRandomMerchantRegistrationRequestProperties.SendEmail
            };

            var createMerchantRegistration = new MerchantRegistration
            {
                Request = new MerchantRegistrationRequest
                {
                        Email = createRandomMerchantRegistrationRequestProperties.Email,
                        BusinessType = createRandomMerchantRegistrationRequestProperties.BusinessType,
                        BusinessName = createRandomMerchantRegistrationRequestProperties.BusinessName,
                        AccountNumber = createRandomMerchantRegistrationRequestProperties.AccountNumber,
                        PhoneNumber = createRandomMerchantRegistrationRequestProperties.PhoneNumber,
                        LastName = createRandomMerchantRegistrationRequestProperties.LastName,
                        FirstName = createRandomMerchantRegistrationRequestProperties.FirstName,
                        Password = createRandomMerchantRegistrationRequestProperties.Password,
                        SendEmail = createRandomMerchantRegistrationRequestProperties.SendEmail
                },
            };

            var httpResponseException =
                new HttpResponseException();

            var failedServerMerchantException =
                new FailedServerMerchantException(
                    message: "Failed Merchant server error occurred, contact support.",
                    httpResponseException);

            var expectedMerchantDependencyException =
                new MerchantDependencyException(
                    message: "Merchant dependency error occurred, contact support.",
                    failedServerMerchantException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.PostMerchantRegistrationAsync(It.IsAny<ExternalMerchantRegistrationRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<MerchantRegistration> retrieveMerchantRegistrationTask =
               this.merchantService.PostMerchantRegistrationRequestAsync(createMerchantRegistration);

            MerchantDependencyException actualMerchantDependencyException =
                await Assert.ThrowsAsync<MerchantDependencyException>(
                    retrieveMerchantRegistrationTask.AsTask);

            // then
            actualMerchantDependencyException.Should().BeEquivalentTo(
                expectedMerchantDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostMerchantRegistrationAsync(It.IsAny<ExternalMerchantRegistrationRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnMerchantRegistrationRequestIfServiceErrorOccurredAsync()
        {
            // given
            

                dynamic createRandomMerchantRegistrationRequestProperties =
                 CreateRandomMerchantRegistrationRequestProperties();

            var createMerchantRegistrationRequest = new ExternalMerchantRegistrationRequest
            {
                                          Email = createRandomMerchantRegistrationRequestProperties.Email,
                BusinessType = createRandomMerchantRegistrationRequestProperties.BusinessType,
                BusinessName = createRandomMerchantRegistrationRequestProperties.BusinessName,
                AccountNumber = createRandomMerchantRegistrationRequestProperties.AccountNumber,
                PhoneNumber = createRandomMerchantRegistrationRequestProperties.PhoneNumber,
                LastName = createRandomMerchantRegistrationRequestProperties.LastName,
                FirstName = createRandomMerchantRegistrationRequestProperties.FirstName,
                Password = createRandomMerchantRegistrationRequestProperties.Password,
                SendEmail = createRandomMerchantRegistrationRequestProperties.SendEmail
            };

            var createMerchantRegistration = new MerchantRegistration
            {
                Request = new MerchantRegistrationRequest
                {
                          Email = createRandomMerchantRegistrationRequestProperties.Email,
                BusinessType = createRandomMerchantRegistrationRequestProperties.BusinessType,
                BusinessName = createRandomMerchantRegistrationRequestProperties.BusinessName,
                AccountNumber = createRandomMerchantRegistrationRequestProperties.AccountNumber,
                PhoneNumber = createRandomMerchantRegistrationRequestProperties.PhoneNumber,
                LastName = createRandomMerchantRegistrationRequestProperties.LastName,
                FirstName = createRandomMerchantRegistrationRequestProperties.FirstName,
                Password = createRandomMerchantRegistrationRequestProperties.Password,
                SendEmail = createRandomMerchantRegistrationRequestProperties.SendEmail
                },
            };
            var serviceException = new Exception();

            var failedMerchantServiceException =
                new FailedMerchantServiceException(serviceException);

            var expectedMerchantServiceException =
                new MerchantServiceException(failedMerchantServiceException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostMerchantRegistrationAsync(It.IsAny<ExternalMerchantRegistrationRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<MerchantRegistration> retrieveMerchantRegistrationTask =
               this.merchantService.PostMerchantRegistrationRequestAsync(createMerchantRegistration);

            MerchantServiceException actualMerchantServiceException =
                await Assert.ThrowsAsync<MerchantServiceException>(
                    retrieveMerchantRegistrationTask.AsTask);

            // then
            actualMerchantServiceException.Should().BeEquivalentTo(
                expectedMerchantServiceException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostMerchantRegistrationAsync(It.IsAny<ExternalMerchantRegistrationRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
