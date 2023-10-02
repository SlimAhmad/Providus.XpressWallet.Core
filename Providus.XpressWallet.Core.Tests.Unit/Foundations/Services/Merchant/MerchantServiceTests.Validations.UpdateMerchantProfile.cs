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
        public async Task ShouldThrowValidationExceptionOnUpdateMerchantProfileIfUpdateMerchantProfileIsNullAsync()
        {
            // given
            UpdateMerchantProfile nullUpdateMerchantProfile = null;
            var nullUpdateMerchantProfileException = new NullMerchantException();

        

            var exceptedMerchantValidationException =
                new MerchantValidationException(nullUpdateMerchantProfileException);

            // when
            ValueTask<UpdateMerchantProfile> UpdateMerchantProfileTask =
                this.merchantService.UpdateMerchantProfileRequestAsync(nullUpdateMerchantProfile);

            MerchantValidationException actualMerchantValidationException =
                await Assert.ThrowsAsync<MerchantValidationException>(
                    UpdateMerchantProfileTask.AsTask);

            // then
            actualMerchantValidationException.Should()
                .BeEquivalentTo(exceptedMerchantValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.UpdateMerchantProfileAsync(
                    It.IsAny<ExternalUpdateMerchantProfileRequest>()),
                        Times.Never);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnUpdateMerchantProfileIfRequestIsNullAsync()
        {
            // given
            var invalidUpdateMerchantProfile = new UpdateMerchantProfile();
            invalidUpdateMerchantProfile.Request = null;
        

            var invalidUpdateMerchantProfileException =
                new InvalidMerchantException();

            invalidUpdateMerchantProfileException.AddData(
                key: nameof(UpdateMerchantProfileRequest),
                values: "Value is required");

            var expectedMerchantValidationException =
                new MerchantValidationException(
                    invalidUpdateMerchantProfileException);

            // when
            ValueTask<UpdateMerchantProfile> UpdateMerchantProfileTask =
                this.merchantService.UpdateMerchantProfileRequestAsync(invalidUpdateMerchantProfile);

            MerchantValidationException actualMerchantValidationException =
                await Assert.ThrowsAsync<MerchantValidationException>(
                    UpdateMerchantProfileTask.AsTask);

            // then
            actualMerchantValidationException.Should()
                .BeEquivalentTo(expectedMerchantValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.UpdateMerchantProfileAsync(
                    It.IsAny<ExternalUpdateMerchantProfileRequest>()),
                        Times.Never);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null,null)]
        [InlineData("","")]
        [InlineData("  "," ")]
        public async Task ShouldThrowValidationExceptionOnPostUpdateMerchantProfileIfUpdateMerchantProfileIsInvalidAsync(
           string invalidCallbackURL,string invalidSandboxCallbackURL)
        {
            // given
            var accountVerificationRequest = new UpdateMerchantProfile
            {
                Request = new UpdateMerchantProfileRequest
                {

                    CallbackURL = invalidCallbackURL,
                    SandboxCallbackURL = invalidSandboxCallbackURL,
               

                }
            };

            var invalidUpdateMerchantProfileException = new InvalidMerchantException();

          

            invalidUpdateMerchantProfileException.AddData(
                    key: nameof(UpdateMerchantProfileRequest.CallbackURL),
                    values: "Value is required");


            invalidUpdateMerchantProfileException.AddData(
                key: nameof(UpdateMerchantProfileRequest.SandboxCallbackURL),
                values: "Value is required");


            var expectedMerchantValidationException =
                new MerchantValidationException(invalidUpdateMerchantProfileException);

            // when
            ValueTask<UpdateMerchantProfile> UpdateMerchantProfileTask =
                this.merchantService.UpdateMerchantProfileRequestAsync(accountVerificationRequest);

            MerchantValidationException actualMerchantValidationException =
                await Assert.ThrowsAsync<MerchantValidationException>(UpdateMerchantProfileTask.AsTask);

            // then
            actualMerchantValidationException.Should().BeEquivalentTo(
                expectedMerchantValidationException);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostUpdateMerchantProfileIfPostUpdateMerchantProfileIsEmptyAsync()
        {
            // given
            var accountVerificationRequest = new UpdateMerchantProfile
            {
                Request = new UpdateMerchantProfileRequest
                {

                   SandboxCallbackURL = string.Empty,
                   CallbackURL = string.Empty,


                }
            };
            var customerId = string.Empty;

            var invalidUpdateMerchantProfileException = new InvalidMerchantException();


            invalidUpdateMerchantProfileException.AddData(
                       key: nameof(UpdateMerchantProfileRequest.CallbackURL),
                       values: "Value is required");


            invalidUpdateMerchantProfileException.AddData(
                key: nameof(UpdateMerchantProfileRequest.SandboxCallbackURL),
                values: "Value is required");



            var expectedMerchantValidationException =
                new MerchantValidationException(invalidUpdateMerchantProfileException);

            // when
            ValueTask<UpdateMerchantProfile> UpdateMerchantProfileTask =
                this.merchantService.UpdateMerchantProfileRequestAsync(accountVerificationRequest);

            MerchantValidationException actualMerchantValidationException =
                await Assert.ThrowsAsync<MerchantValidationException>(
                    UpdateMerchantProfileTask.AsTask);

            // then
            actualMerchantValidationException.Should().BeEquivalentTo(
                expectedMerchantValidationException);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

    }
}