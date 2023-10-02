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
        [InlineData(0, null)]
        [InlineData(0,"")]
        [InlineData(0, " ")]
        public async Task ShouldThrowValidationExceptionOnGetPendingTransactionIfPendingTransactionIsInvalidAsync(
           int invalidPage,string invalidType)
        {
            // given


            var invalidPendingTransactionException = new InvalidTransactionsException();

            invalidPendingTransactionException.AddData(
                key: nameof(PendingTransaction),
                values: "Value is required");

;
            var expectedTransactionsValidationException =
                new TransactionsValidationException(invalidPendingTransactionException);

            // when
            ValueTask<PendingTransaction> PendingTransactionTask =
                this.transactionsService.GetPendingTransactionsRequestAsync(invalidPage,invalidType);

            TransactionsValidationException actualTransactionsValidationException =
                await Assert.ThrowsAsync<TransactionsValidationException>(PendingTransactionTask.AsTask);

            // then
            actualTransactionsValidationException.Should().BeEquivalentTo(
                expectedTransactionsValidationException);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

 
    }
}