using FluentAssertions;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalMerchant;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Merchant;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Merchant.Exceptions;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.Merchant
{
    public partial class MerchantServiceTests
    {

        [Fact]
        public async Task ShouldThrowValidationExceptionOnMerchantRegistrationIfMerchantRegistrationIsNullAsync()
        {
            // given
            MerchantRegistration nullMerchantRegistration = null;
            var nullMerchantRegistrationException = new NullMerchantException();

        

            var exceptedMerchantValidationException =
                new MerchantValidationException(nullMerchantRegistrationException);

            // when
            ValueTask<MerchantRegistration> MerchantRegistrationTask =
                this.merchantService.PostMerchantRegistrationRequestAsync(nullMerchantRegistration);

            MerchantValidationException actualMerchantValidationException =
                await Assert.ThrowsAsync<MerchantValidationException>(
                    MerchantRegistrationTask.AsTask);

            // then
            actualMerchantValidationException.Should()
                .BeEquivalentTo(exceptedMerchantValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostMerchantRegistrationAsync(
                    It.IsAny<ExternalMerchantRegistrationRequest>()),
                        Times.Never);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnMerchantRegistrationIfRequestIsNullAsync()
        {
            // given
            var invalidMerchantRegistration = new MerchantRegistration();
            invalidMerchantRegistration.Request = null;
        

            var invalidMerchantRegistrationException =
                new InvalidMerchantException();

            invalidMerchantRegistrationException.AddData(
                key: nameof(MerchantRegistrationRequest),
                values: "Value is required");

            var expectedMerchantValidationException =
                new MerchantValidationException(
                    invalidMerchantRegistrationException);

            // when
            ValueTask<MerchantRegistration> MerchantRegistrationTask =
                this.merchantService.PostMerchantRegistrationRequestAsync(invalidMerchantRegistration);

            MerchantValidationException actualMerchantValidationException =
                await Assert.ThrowsAsync<MerchantValidationException>(
                    MerchantRegistrationTask.AsTask);

            // then
            actualMerchantValidationException.Should()
                .BeEquivalentTo(expectedMerchantValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostMerchantRegistrationAsync(
                    It.IsAny<ExternalMerchantRegistrationRequest>()),
                        Times.Never);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

     

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostMerchantRegistrationIfPostMerchantRegistrationIsEmptyAsync()
        {
            // given
            var accountVerificationRequest = new MerchantRegistration
            {
                Request = new MerchantRegistrationRequest
                {

                  AccountNumber = string.Empty,
                  BusinessName = string.Empty,
                  BusinessType = string.Empty,
                  Email = string.Empty,
                  FirstName = string.Empty,
                  LastName = string.Empty,
                  Password = string.Empty,
                  PhoneNumber = string.Empty,
                 


                }
            };
            var customerId = string.Empty;

            var invalidMerchantRegistrationException = new InvalidMerchantException();


            invalidMerchantRegistrationException.AddData(
                key: nameof(MerchantRegistrationRequest.Password),
                values: "Value is required");


            invalidMerchantRegistrationException.AddData(
                key: nameof(MerchantRegistrationRequest.FirstName),
                values: "Value is required");

            invalidMerchantRegistrationException.AddData(
                key: nameof(MerchantRegistrationRequest.LastName),
                values: "Value is required");

            invalidMerchantRegistrationException.AddData(
                key: nameof(MerchantRegistrationRequest.PhoneNumber),
                values: "Value is required");
            invalidMerchantRegistrationException.AddData(
                    key: nameof(MerchantRegistrationRequest.AccountNumber),
                    values: "Value is required");
            invalidMerchantRegistrationException.AddData(
                    key: nameof(MerchantRegistrationRequest.BusinessName),
                    values: "Value is required");
            invalidMerchantRegistrationException.AddData(
                    key: nameof(MerchantRegistrationRequest.BusinessType),
                    values: "Value is required");
            invalidMerchantRegistrationException.AddData(
                    key: nameof(MerchantRegistrationRequest.Email),
                    values: "Value is required");

            var expectedMerchantValidationException =
                new MerchantValidationException(invalidMerchantRegistrationException);

            // when
            ValueTask<MerchantRegistration> MerchantRegistrationTask =
                this.merchantService.PostMerchantRegistrationRequestAsync(accountVerificationRequest);

            MerchantValidationException actualMerchantValidationException =
                await Assert.ThrowsAsync<MerchantValidationException>(
                    MerchantRegistrationTask.AsTask);

            // then
            actualMerchantValidationException.Should().BeEquivalentTo(
                expectedMerchantValidationException);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

    }
}