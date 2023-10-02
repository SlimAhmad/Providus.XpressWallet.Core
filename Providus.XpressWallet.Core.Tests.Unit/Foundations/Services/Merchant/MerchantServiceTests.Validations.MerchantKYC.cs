using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalMerchant;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Merchant;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Merchant.Exceptions;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.Merchant
{
    public partial class MerchantServiceTests
    {

        [Fact]
        public async Task ShouldThrowValidationExceptionOnMerchantKYCIfMerchantKYCIsNullAsync()
        {
            // given
            MerchantKYC nullMerchantKYC = null;
            var nullMerchantKYCException = new NullMerchantException();

        

            var exceptedMerchantValidationException =
                new MerchantValidationException(nullMerchantKYCException);

            // when
            ValueTask<MerchantKYC> MerchantKYCTask =
                this.merchantService.PutMerchantKYCRequestAsync(nullMerchantKYC);

            MerchantValidationException actualMerchantValidationException =
                await Assert.ThrowsAsync<MerchantValidationException>(
                    MerchantKYCTask.AsTask);

            // then
            actualMerchantValidationException.Should()
                .BeEquivalentTo(exceptedMerchantValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PutMerchantKYCAsync(
                    It.IsAny<ExternalMerchantKYCRequest>()),
                        Times.Never);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnMerchantKYCIfRequestIsNullAsync()
        {
            // given
            var invalidMerchantKYC = new MerchantKYC();
            invalidMerchantKYC.Request = null;
        

            var invalidMerchantKYCException =
                new InvalidMerchantException();

            invalidMerchantKYCException.AddData(
                key: nameof(MerchantKYCRequest),
                values: "Value is required");

            var expectedMerchantValidationException =
                new MerchantValidationException(
                    invalidMerchantKYCException);

            // when
            ValueTask<MerchantKYC> MerchantKYCTask =
                this.merchantService.PutMerchantKYCRequestAsync(invalidMerchantKYC);

            MerchantValidationException actualMerchantValidationException =
                await Assert.ThrowsAsync<MerchantValidationException>(
                    MerchantKYCTask.AsTask);

            // then
            actualMerchantValidationException.Should()
                .BeEquivalentTo(expectedMerchantValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PutMerchantKYCAsync(
                    It.IsAny<ExternalMerchantKYCRequest>()),
                        Times.Never);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null,null)]
        [InlineData("","")]
        [InlineData("  "," ")]
        public async Task ShouldThrowValidationExceptionOnPutMerchantKYCIfMerchantKYCIsInvalidAsync(
           string invalidDirectorsBVN, string invalidMerchantId)
        {
            // given
            var accountVerificationRequest = new MerchantKYC
            {
                Request = new MerchantKYCRequest
                {
        
                    DirectorsBVN = invalidDirectorsBVN,
                    MerchantId = invalidMerchantId

                }
            };

            var invalidMerchantKYCException = new InvalidMerchantException();

          

            invalidMerchantKYCException.AddData(
                    key: nameof(MerchantKYCRequest.DirectorsBVN),
                    values: "Value is required");


            invalidMerchantKYCException.AddData(
                key: nameof(MerchantKYCRequest.MerchantId),
                values: "Value is required");

            invalidMerchantKYCException.AddData(
                key: nameof(MerchantKYCRequest.CacPack),
                values: "Value is required");

            var expectedMerchantValidationException =
                new MerchantValidationException(invalidMerchantKYCException);

            // when
            ValueTask<MerchantKYC> MerchantKYCTask =
                this.merchantService.PutMerchantKYCRequestAsync(accountVerificationRequest);

            MerchantValidationException actualMerchantValidationException =
                await Assert.ThrowsAsync<MerchantValidationException>(MerchantKYCTask.AsTask);

            // then
            actualMerchantValidationException.Should().BeEquivalentTo(
                expectedMerchantValidationException);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPutMerchantKYCIfPutMerchantKYCIsEmptyAsync()
        {
            // given
            var accountVerificationRequest = new MerchantKYC
            {
                Request = new MerchantKYCRequest
                {

                   DirectorsBVN = string.Empty,
                   MerchantId = string.Empty,


                }
            };
            var customerId = string.Empty;

            var invalidMerchantKYCException = new InvalidMerchantException();


            invalidMerchantKYCException.AddData(
                       key: nameof(MerchantKYCRequest.DirectorsBVN),
                       values: "Value is required");

            invalidMerchantKYCException.AddData(
                key: nameof(MerchantKYCRequest.MerchantId),
                values: "Value is required");

            invalidMerchantKYCException.AddData(
                 key: nameof(MerchantKYCRequest.CacPack),
                 values: "Value is required");


            var expectedMerchantValidationException =
                new MerchantValidationException(invalidMerchantKYCException);

            // when
            ValueTask<MerchantKYC> MerchantKYCTask =
                this.merchantService.PutMerchantKYCRequestAsync(accountVerificationRequest);

            MerchantValidationException actualMerchantValidationException =
                await Assert.ThrowsAsync<MerchantValidationException>(
                    MerchantKYCTask.AsTask);

            // then
            actualMerchantValidationException.Should().BeEquivalentTo(
                expectedMerchantValidationException);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

    }
}