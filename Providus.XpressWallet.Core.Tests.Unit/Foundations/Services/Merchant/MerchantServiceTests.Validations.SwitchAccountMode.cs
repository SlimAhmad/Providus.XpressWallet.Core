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
        public async Task ShouldThrowValidationExceptionOnSwitchAccountModeIfSwitchAccountModeIsNullAsync()
        {
            // given
            SwitchAccountMode nullSwitchAccountMode = null;
            var nullSwitchAccountModeException = new NullMerchantException();

        

            var exceptedMerchantValidationException =
                new MerchantValidationException(nullSwitchAccountModeException);

            // when
            ValueTask<SwitchAccountMode> SwitchAccountModeTask =
                this.merchantService.PostSwitchAccountModeRequestAsync(nullSwitchAccountMode);

            MerchantValidationException actualMerchantValidationException =
                await Assert.ThrowsAsync<MerchantValidationException>(
                    SwitchAccountModeTask.AsTask);

            // then
            actualMerchantValidationException.Should()
                .BeEquivalentTo(exceptedMerchantValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostSwitchAccountModeAsync(
                    It.IsAny<ExternalSwitchAccountModeRequest>()),
                        Times.Never);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnSwitchAccountModeIfRequestIsNullAsync()
        {
            // given
            var invalidSwitchAccountMode = new SwitchAccountMode();
            invalidSwitchAccountMode.Request = null;
        

            var invalidSwitchAccountModeException =
                new InvalidMerchantException();

            invalidSwitchAccountModeException.AddData(
                key: nameof(SwitchAccountModeRequest),
                values: "Value is required");

            var expectedMerchantValidationException =
                new MerchantValidationException(
                    invalidSwitchAccountModeException);

            // when
            ValueTask<SwitchAccountMode> SwitchAccountModeTask =
                this.merchantService.PostSwitchAccountModeRequestAsync(invalidSwitchAccountMode);

            MerchantValidationException actualMerchantValidationException =
                await Assert.ThrowsAsync<MerchantValidationException>(
                    SwitchAccountModeTask.AsTask);

            // then
            actualMerchantValidationException.Should()
                .BeEquivalentTo(expectedMerchantValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostSwitchAccountModeAsync(
                    It.IsAny<ExternalSwitchAccountModeRequest>()),
                        Times.Never);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public async Task ShouldThrowValidationExceptionOnPostSwitchAccountModeIfSwitchAccountModeIsInvalidAsync(
           string invalidMode)
        {
            // given
            var accountVerificationRequest = new SwitchAccountMode
            {
                Request = new SwitchAccountModeRequest
                {

                   Mode =invalidMode
               

                }
            };

            var invalidSwitchAccountModeException = new InvalidMerchantException();

          

            invalidSwitchAccountModeException.AddData(
                    key: nameof(SwitchAccountModeRequest.Mode),
                    values: "Value is required");




            var expectedMerchantValidationException =
                new MerchantValidationException(invalidSwitchAccountModeException);

            // when
            ValueTask<SwitchAccountMode> SwitchAccountModeTask =
                this.merchantService.PostSwitchAccountModeRequestAsync(accountVerificationRequest);

            MerchantValidationException actualMerchantValidationException =
                await Assert.ThrowsAsync<MerchantValidationException>(SwitchAccountModeTask.AsTask);

            // then
            actualMerchantValidationException.Should().BeEquivalentTo(
                expectedMerchantValidationException);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostSwitchAccountModeIfPostSwitchAccountModeIsEmptyAsync()
        {
            // given
            var accountVerificationRequest = new SwitchAccountMode
            {
                Request = new SwitchAccountModeRequest
                {

                   Mode = string.Empty,



                }
            };
            var customerId = string.Empty;

            var invalidSwitchAccountModeException = new InvalidMerchantException();


            invalidSwitchAccountModeException.AddData(
                       key: nameof(SwitchAccountModeRequest.Mode),
                       values: "Value is required");





            var expectedMerchantValidationException =
                new MerchantValidationException(invalidSwitchAccountModeException);

            // when
            ValueTask<SwitchAccountMode> SwitchAccountModeTask =
                this.merchantService.PostSwitchAccountModeRequestAsync(accountVerificationRequest);

            MerchantValidationException actualMerchantValidationException =
                await Assert.ThrowsAsync<MerchantValidationException>(
                    SwitchAccountModeTask.AsTask);

            // then
            actualMerchantValidationException.Should().BeEquivalentTo(
                expectedMerchantValidationException);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

    }
}