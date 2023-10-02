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
        public async Task ShouldThrowValidationExceptionOnResendVerificationIfResendVerificationIsNullAsync()
        {
            // given
            ResendVerification nullResendVerification = null;
            var nullResendVerificationException = new NullMerchantException();

        

            var exceptedMerchantValidationException =
                new MerchantValidationException(nullResendVerificationException);

            // when
            ValueTask<ResendVerification> ResendVerificationTask =
                this.merchantService.PostResendVerificationRequestAsync(nullResendVerification);

            MerchantValidationException actualMerchantValidationException =
                await Assert.ThrowsAsync<MerchantValidationException>(
                    ResendVerificationTask.AsTask);

            // then
            actualMerchantValidationException.Should()
                .BeEquivalentTo(exceptedMerchantValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostResendVerificationAsync(
                    It.IsAny<ExternalResendVerificationRequest>()),
                        Times.Never);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnResendVerificationIfRequestIsNullAsync()
        {
            // given
            var invalidResendVerification = new ResendVerification();
            invalidResendVerification.Request = null;
        

            var invalidResendVerificationException =
                new InvalidMerchantException();

            invalidResendVerificationException.AddData(
                key: nameof(ResendVerificationRequest),
                values: "Value is required");

            var expectedMerchantValidationException =
                new MerchantValidationException(
                    invalidResendVerificationException);

            // when
            ValueTask<ResendVerification> ResendVerificationTask =
                this.merchantService.PostResendVerificationRequestAsync(invalidResendVerification);

            MerchantValidationException actualMerchantValidationException =
                await Assert.ThrowsAsync<MerchantValidationException>(
                    ResendVerificationTask.AsTask);

            // then
            actualMerchantValidationException.Should()
                .BeEquivalentTo(expectedMerchantValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostResendVerificationAsync(
                    It.IsAny<ExternalResendVerificationRequest>()),
                        Times.Never);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public async Task ShouldThrowValidationExceptionOnPostResendVerificationIfResendVerificationIsInvalidAsync(
           string invalidEmail)
        {
            // given
            var accountVerificationRequest = new ResendVerification
            {
                Request = new ResendVerificationRequest
                {
                  
                  Email = invalidEmail

                }
            };

            var invalidResendVerificationException = new InvalidMerchantException();

          

            invalidResendVerificationException.AddData(
                    key: nameof(ResendVerificationRequest.Email),
                    values: "Value is required");





            var expectedMerchantValidationException =
                new MerchantValidationException(invalidResendVerificationException);

            // when
            ValueTask<ResendVerification> ResendVerificationTask =
                this.merchantService.PostResendVerificationRequestAsync(accountVerificationRequest);

            MerchantValidationException actualMerchantValidationException =
                await Assert.ThrowsAsync<MerchantValidationException>(ResendVerificationTask.AsTask);

            // then
            actualMerchantValidationException.Should().BeEquivalentTo(
                expectedMerchantValidationException);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostResendVerificationIfPostResendVerificationIsEmptyAsync()
        {
            // given
            var accountVerificationRequest = new ResendVerification
            {
                Request = new ResendVerificationRequest
                {

                   Email = string.Empty,


                }
            };
            var customerId = string.Empty;

            var invalidResendVerificationException = new InvalidMerchantException();


            invalidResendVerificationException.AddData(
                       key: nameof(ResendVerificationRequest.Email),
                       values: "Value is required");






            var expectedMerchantValidationException =
                new MerchantValidationException(invalidResendVerificationException);

            // when
            ValueTask<ResendVerification> ResendVerificationTask =
                this.merchantService.PostResendVerificationRequestAsync(accountVerificationRequest);

            MerchantValidationException actualMerchantValidationException =
                await Assert.ThrowsAsync<MerchantValidationException>(
                    ResendVerificationTask.AsTask);

            // then
            actualMerchantValidationException.Should().BeEquivalentTo(
                expectedMerchantValidationException);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

    }
}