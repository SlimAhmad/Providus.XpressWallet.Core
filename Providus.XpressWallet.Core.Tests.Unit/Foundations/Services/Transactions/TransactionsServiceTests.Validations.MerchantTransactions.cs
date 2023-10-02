using FluentAssertions;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalTransactions;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transactions;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transactions.Exceptions;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.Transactions
{
    public partial class TransactionsServiceTests
    {



        [Theory]
        [InlineData(0, null, null)]
        [InlineData(0,"","")]
        [InlineData(0, " ", " ")]
        public async Task ShouldThrowValidationExceptionOnGetMerchantTransactionsIfMerchantTransactionsIsInvalidAsync(
           int invalidPage,string invalidType,string inputStatus)
        {
            // given


            var invalidMerchantTransactionsException = new InvalidTransactionsException();

            invalidMerchantTransactionsException.AddData(
                key: nameof(MerchantTransactions),
                values: "Value is required");

;
            var expectedTransactionsValidationException =
                new TransactionsValidationException(invalidMerchantTransactionsException);

            // when
            ValueTask<MerchantTransactions> MerchantTransactionsTask =
                this.transactionsService.GetMerchantTransactionsRequestAsync(invalidPage,invalidType,inputStatus);

            TransactionsValidationException actualTransactionsValidationException =
                await Assert.ThrowsAsync<TransactionsValidationException>(MerchantTransactionsTask.AsTask);

            // then
            actualTransactionsValidationException.Should().BeEquivalentTo(
                expectedTransactionsValidationException);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

 
    }
}