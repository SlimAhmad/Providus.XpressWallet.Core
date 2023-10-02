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
        public async Task ShouldThrowValidationExceptionOnFundMerchantSandBoxWalletIfFundMerchantSandBoxWalletIsNullAsync()
        {
            // given
            FundMerchantSandBoxWallet nullFundMerchantSandBoxWallet = null;
            var nullFundMerchantSandBoxWalletException = new NullWalletException();

        

            var exceptedWalletValidationException =
                new WalletValidationException(nullFundMerchantSandBoxWalletException);

            // when
            ValueTask<FundMerchantSandBoxWallet> FundMerchantSandBoxWalletTask =
                this.walletService.PostFundMerchantSandBoxWalletRequestAsync(nullFundMerchantSandBoxWallet);

            WalletValidationException actualWalletValidationException =
                await Assert.ThrowsAsync<WalletValidationException>(
                    FundMerchantSandBoxWalletTask.AsTask);

            // then
            actualWalletValidationException.Should()
                .BeEquivalentTo(exceptedWalletValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostFundMerchantSandBoxWalletAsync(
                    It.IsAny<ExternalFundMerchantSandBoxWalletRequest>()),
                        Times.Never);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnFundMerchantSandBoxWalletIfRequestIsNullAsync()
        {
            // given
            var invalidFundMerchantSandBoxWallet = new FundMerchantSandBoxWallet();
            invalidFundMerchantSandBoxWallet.Request = null;
        

            var invalidFundMerchantSandBoxWalletException =
                new InvalidWalletException();

            invalidFundMerchantSandBoxWalletException.AddData(
                key: nameof(FundMerchantSandBoxWalletRequest),
                values: "Value is required");

            var expectedWalletValidationException =
                new WalletValidationException(
                    invalidFundMerchantSandBoxWalletException);

            // when
            ValueTask<FundMerchantSandBoxWallet> FundMerchantSandBoxWalletTask =
                this.walletService.PostFundMerchantSandBoxWalletRequestAsync(invalidFundMerchantSandBoxWallet);

            WalletValidationException actualWalletValidationException =
                await Assert.ThrowsAsync<WalletValidationException>(
                    FundMerchantSandBoxWalletTask.AsTask);

            // then
            actualWalletValidationException.Should()
                .BeEquivalentTo(expectedWalletValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostFundMerchantSandBoxWalletAsync(
                    It.IsAny<ExternalFundMerchantSandBoxWalletRequest>()),
                        Times.Never);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(0)]
        public async Task ShouldThrowValidationExceptionOnPostFundMerchantSandBoxWalletIfFundMerchantSandBoxWalletIsInvalidAsync(
           int invalidAmount)
        {
            // given
            var accountVerificationRequest = new FundMerchantSandBoxWallet
            {
                Request = new FundMerchantSandBoxWalletRequest
                {

                      Amount = invalidAmount,

                }
            };

            var invalidFundMerchantSandBoxWalletException = new InvalidWalletException();

          

            invalidFundMerchantSandBoxWalletException.AddData(
                    key: nameof(FundMerchantSandBoxWalletRequest.Amount),
                    values: "Value is required");


        


            var expectedWalletValidationException =
                new WalletValidationException(invalidFundMerchantSandBoxWalletException);

            // when
            ValueTask<FundMerchantSandBoxWallet> FundMerchantSandBoxWalletTask =
                this.walletService.PostFundMerchantSandBoxWalletRequestAsync(accountVerificationRequest);

            WalletValidationException actualWalletValidationException =
                await Assert.ThrowsAsync<WalletValidationException>(FundMerchantSandBoxWalletTask.AsTask);

            // then
            actualWalletValidationException.Should().BeEquivalentTo(
                expectedWalletValidationException);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

     
    }
}