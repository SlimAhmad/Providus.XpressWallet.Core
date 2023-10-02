using FluentAssertions;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalWallet;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Wallet;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Wallet.Exceptions;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.Wallet
{
    public partial class WalletServiceTests
    {



        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public async Task ShouldThrowValidationExceptionOnGetCustomerWalletIfCustomerWalletIsInvalidAsync(
           string invalidCustomerId)
        {
            // given


            var invalidCustomerWalletException = new InvalidWalletException();

            invalidCustomerWalletException.AddData(
                key: nameof(CustomerWallet),
                values: "Value is required");

;
            var expectedWalletValidationException =
                new WalletValidationException(invalidCustomerWalletException);

            // when
            ValueTask<CustomerWallet> CustomerWalletTask =
                this.walletService.GetCustomerWalletRequestAsync(invalidCustomerId);

            WalletValidationException actualWalletValidationException =
                await Assert.ThrowsAsync<WalletValidationException>(CustomerWalletTask.AsTask);

            // then
            actualWalletValidationException.Should().BeEquivalentTo(
                expectedWalletValidationException);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnGetCustomerWalletIfGetCustomerWalletIsEmptyAsync()
        {
            // given
            var inputCustomerId = string.Empty;

            var invalidCustomerWalletException = new InvalidWalletException();


            invalidCustomerWalletException.AddData(
                 key: nameof(CustomerWallet),
                 values: "Value is required");


            var expectedWalletValidationException =
                new WalletValidationException(invalidCustomerWalletException);

            // when
            ValueTask<CustomerWallet> CustomerWalletTask =
                this.walletService.GetCustomerWalletRequestAsync(inputCustomerId);

            WalletValidationException actualWalletValidationException =
                await Assert.ThrowsAsync<WalletValidationException>(
                    CustomerWalletTask.AsTask);

            // then
            actualWalletValidationException.Should().BeEquivalentTo(
                expectedWalletValidationException);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

    }
}