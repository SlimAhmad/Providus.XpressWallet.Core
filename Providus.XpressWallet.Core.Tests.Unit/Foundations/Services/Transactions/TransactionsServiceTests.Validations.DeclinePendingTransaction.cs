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
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task ShouldThrowValidationExceptionOnDeclinePendingTransactionIfDeclinePendingTransactionIsInvalidAsync(
           string invalidTransactionId)
        {
            // given


            var invalidDeclinePendingTransactionException = new InvalidTransactionsException();

            invalidDeclinePendingTransactionException.AddData(
                key: nameof(DeclinePendingTransaction),
                values: "Value is required");

;
            var expectedTransactionsValidationException =
                new TransactionsValidationException(invalidDeclinePendingTransactionException);

            // when
            ValueTask<DeclinePendingTransaction> DeclinePendingTransactionTask =
                this.transactionsService.DeleteDeclinePendingTransactionRequestAsync(invalidTransactionId);

            TransactionsValidationException actualTransactionsValidationException =
                await Assert.ThrowsAsync<TransactionsValidationException>(DeclinePendingTransactionTask.AsTask);

            // then
            actualTransactionsValidationException.Should().BeEquivalentTo(
                expectedTransactionsValidationException);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

 
    }
}