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
        public async Task ShouldThrowValidationExceptionOnAccountVerificationIfAccountVerificationIsNullAsync()
        {
            // given
            AccountVerification nullAccountVerification = null;
            var nullAccountVerificationException = new NullMerchantException();

        

            var exceptedMerchantValidationException =
                new MerchantValidationException(nullAccountVerificationException);

            // when
            ValueTask<AccountVerification> AccountVerificationTask =
                this.merchantService.PostAccountVerificationRequestAsync(nullAccountVerification);

            MerchantValidationException actualMerchantValidationException =
                await Assert.ThrowsAsync<MerchantValidationException>(
                    AccountVerificationTask.AsTask);

            // then
            actualMerchantValidationException.Should()
                .BeEquivalentTo(exceptedMerchantValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PutAccountVerificationAsync(
                    It.IsAny<ExternalAccountVerificationRequest>()),
                        Times.Never);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnAccountVerificationIfRequestIsNullAsync()
        {
            // given
            var invalidAccountVerification = new AccountVerification();
            invalidAccountVerification.Request = null;
        

            var invalidAccountVerificationException =
                new InvalidMerchantException();

            invalidAccountVerificationException.AddData(
                key: nameof(AccountVerificationRequest),
                values: "Value is required");

            var expectedMerchantValidationException =
                new MerchantValidationException(
                    invalidAccountVerificationException);

            // when
            ValueTask<AccountVerification> AccountVerificationTask =
                this.merchantService.PostAccountVerificationRequestAsync(invalidAccountVerification);

            MerchantValidationException actualMerchantValidationException =
                await Assert.ThrowsAsync<MerchantValidationException>(
                    AccountVerificationTask.AsTask);

            // then
            actualMerchantValidationException.Should()
                .BeEquivalentTo(expectedMerchantValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PutAccountVerificationAsync(
                    It.IsAny<ExternalAccountVerificationRequest>()),
                        Times.Never);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public async Task ShouldThrowValidationExceptionOnPostAccountVerificationIfAccountVerificationIsInvalidAsync(
           string invalidLastName)
        {
            // given
            var accountVerificationRequest = new AccountVerification
            {
                Request = new AccountVerificationRequest
                {
                      
                  ActivationCode = invalidLastName

                }
            };

            var invalidAccountVerificationException = new InvalidMerchantException();

          

            invalidAccountVerificationException.AddData(
                    key: nameof(AccountVerificationRequest.ActivationCode),
                    values: "Value is required");





            var expectedMerchantValidationException =
                new MerchantValidationException(invalidAccountVerificationException);

            // when
            ValueTask<AccountVerification> AccountVerificationTask =
                this.merchantService.PostAccountVerificationRequestAsync(accountVerificationRequest);

            MerchantValidationException actualMerchantValidationException =
                await Assert.ThrowsAsync<MerchantValidationException>(AccountVerificationTask.AsTask);

            // then
            actualMerchantValidationException.Should().BeEquivalentTo(
                expectedMerchantValidationException);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostAccountVerificationIfPostAccountVerificationIsEmptyAsync()
        {
            // given
            var accountVerificationRequest = new AccountVerification
            {
                Request = new AccountVerificationRequest
                {

                   ActivationCode = string.Empty,


                }
            };
            var customerId = string.Empty;

            var invalidAccountVerificationException = new InvalidMerchantException();


            invalidAccountVerificationException.AddData(
                       key: nameof(AccountVerificationRequest.ActivationCode),
                       values: "Value is required");






            var expectedMerchantValidationException =
                new MerchantValidationException(invalidAccountVerificationException);

            // when
            ValueTask<AccountVerification> AccountVerificationTask =
                this.merchantService.PostAccountVerificationRequestAsync(accountVerificationRequest);

            MerchantValidationException actualMerchantValidationException =
                await Assert.ThrowsAsync<MerchantValidationException>(
                    AccountVerificationTask.AsTask);

            // then
            actualMerchantValidationException.Should().BeEquivalentTo(
                expectedMerchantValidationException);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

    }
}