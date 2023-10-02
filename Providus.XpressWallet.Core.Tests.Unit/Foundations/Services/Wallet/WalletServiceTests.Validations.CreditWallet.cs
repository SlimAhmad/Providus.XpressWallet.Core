using FluentAssertions;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalWallet;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Wallet;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Wallet.Exceptions;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.Wallet
{
    public partial class WalletServiceTests
    {

        [Fact]
        public async Task ShouldThrowValidationExceptionOnCreditWalletIfCreditWalletIsNullAsync()
        {
            // given
            CreditWallet nullCreditWallet = null;
            var nullCreditWalletException = new NullWalletException();

        

            var exceptedWalletValidationException =
                new WalletValidationException(nullCreditWalletException);

            // when
            ValueTask<CreditWallet> CreditWalletTask =
                this.walletService.PostCreditWalletRequestAsync(nullCreditWallet);

            WalletValidationException actualWalletValidationException =
                await Assert.ThrowsAsync<WalletValidationException>(
                    CreditWalletTask.AsTask);

            // then
            actualWalletValidationException.Should()
                .BeEquivalentTo(exceptedWalletValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostCreditWalletAsync(
                    It.IsAny<ExternalCreditWalletRequest>()),
                        Times.Never);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnCreditWalletIfRequestIsNullAsync()
        {
            // given
            var invalidCreditWallet = new CreditWallet();
            invalidCreditWallet.Request = null;
        

            var invalidCreditWalletException =
                new InvalidWalletException();

            invalidCreditWalletException.AddData(
                key: nameof(CreditWalletRequest),
                values: "Value is required");

            var expectedWalletValidationException =
                new WalletValidationException(
                    invalidCreditWalletException);

            // when
            ValueTask<CreditWallet> CreditWalletTask =
                this.walletService.PostCreditWalletRequestAsync(invalidCreditWallet);

            WalletValidationException actualWalletValidationException =
                await Assert.ThrowsAsync<WalletValidationException>(
                    CreditWalletTask.AsTask);

            // then
            actualWalletValidationException.Should()
                .BeEquivalentTo(expectedWalletValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostCreditWalletAsync(
                    It.IsAny<ExternalCreditWalletRequest>()),
                        Times.Never);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null,null)]
        [InlineData("","")]
        [InlineData("  "," ")]
        public async Task ShouldThrowValidationExceptionOnPostCreditWalletIfCreditWalletIsInvalidAsync(
           string invalidPhoneNumber, string invalidAddress)
        {
            // given
            var accountVerificationRequest = new CreditWallet
            {
                Request = new CreditWalletRequest
                {

                      CustomerId = invalidPhoneNumber,
                      Reference = invalidAddress,
                    
               

                }
            };

            var invalidCreditWalletException = new InvalidWalletException();

          

            invalidCreditWalletException.AddData(
                    key: nameof(CreditWalletRequest.Amount),
                    values: "Value is required");


            invalidCreditWalletException.AddData(
                key: nameof(CreditWalletRequest.Metadata),
                values: "Value is required");

            invalidCreditWalletException.AddData(
                    key: nameof(CreditWalletRequest.Reference),
                    values: "Value is required");


            invalidCreditWalletException.AddData(
                key: nameof(CreditWalletRequest.CustomerId),
                values: "Value is required");


            var expectedWalletValidationException =
                new WalletValidationException(invalidCreditWalletException);

            // when
            ValueTask<CreditWallet> CreditWalletTask =
                this.walletService.PostCreditWalletRequestAsync(accountVerificationRequest);

            WalletValidationException actualWalletValidationException =
                await Assert.ThrowsAsync<WalletValidationException>(CreditWalletTask.AsTask);

            // then
            actualWalletValidationException.Should().BeEquivalentTo(
                expectedWalletValidationException);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostCreditWalletIfPostCreditWalletIsEmptyAsync()
        {
            // given
            var accountVerificationRequest = new CreditWallet
            {
                Request = new CreditWalletRequest
                {

                   CustomerId = string.Empty,
                   Reference = string.Empty,
                  

                }
            };
            

            var invalidCreditWalletException = new InvalidWalletException();


            invalidCreditWalletException.AddData(
                   key: nameof(CreditWalletRequest.Amount),
                   values: "Value is required");


            invalidCreditWalletException.AddData(
                key: nameof(CreditWalletRequest.Metadata),
                values: "Value is required");

            invalidCreditWalletException.AddData(
                    key: nameof(CreditWalletRequest.Reference),
                    values: "Value is required");


            invalidCreditWalletException.AddData(
                key: nameof(CreditWalletRequest.CustomerId),
                values: "Value is required");





            var expectedWalletValidationException =
                new WalletValidationException(invalidCreditWalletException);

            // when
            ValueTask<CreditWallet> CreditWalletTask =
                this.walletService.PostCreditWalletRequestAsync(accountVerificationRequest);

            WalletValidationException actualWalletValidationException =
                await Assert.ThrowsAsync<WalletValidationException>(
                    CreditWalletTask.AsTask);

            // then
            actualWalletValidationException.Should().BeEquivalentTo(
                expectedWalletValidationException);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

    }
}