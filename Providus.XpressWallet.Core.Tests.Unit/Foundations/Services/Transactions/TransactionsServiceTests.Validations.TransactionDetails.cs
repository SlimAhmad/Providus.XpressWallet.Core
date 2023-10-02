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
        public async Task ShouldThrowValidationExceptionOnGetTransactionDetailsIfTransactionDetailsIsInvalidAsync(
           string invalidTransactionReference)
        {
            // given


            var invalidTransactionDetailsException = new InvalidTransactionsException();

            invalidTransactionDetailsException.AddData(
                key: nameof(TransactionDetails),
                values: "Value is required");

;
            var expectedTransactionsValidationException =
                new TransactionsValidationException(invalidTransactionDetailsException);

            // when
            ValueTask<TransactionDetails> TransactionDetailsTask =
                this.transactionsService.GetTransactionDetailsRequestAsync(invalidTransactionReference);

            TransactionsValidationException actualTransactionsValidationException =
                await Assert.ThrowsAsync<TransactionsValidationException>(TransactionDetailsTask.AsTask);

            // then
            actualTransactionsValidationException.Should().BeEquivalentTo(
                expectedTransactionsValidationException);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

 
    }
}