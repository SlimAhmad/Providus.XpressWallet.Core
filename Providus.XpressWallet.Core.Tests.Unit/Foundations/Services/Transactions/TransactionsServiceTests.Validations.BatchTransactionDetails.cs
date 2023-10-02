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
        public async Task ShouldThrowValidationExceptionOnGetBatchTransactionDetailsIfBatchTransactionDetailsIsInvalidAsync(
           string invalidReference)
        {
            // given


            var invalidBatchTransactionDetailsException = new InvalidTransactionsException();

            invalidBatchTransactionDetailsException.AddData(
                key: nameof(BatchTransactionDetails),
                values: "Value is required");

;
            var expectedTransactionsValidationException =
                new TransactionsValidationException(invalidBatchTransactionDetailsException);

            // when
            ValueTask<BatchTransactionDetails> BatchTransactionDetailsTask =
                this.transactionsService.GetBatchTransactionDetailsRequestAsync(invalidReference);

            TransactionsValidationException actualTransactionsValidationException =
                await Assert.ThrowsAsync<TransactionsValidationException>(BatchTransactionDetailsTask.AsTask);

            // then
            actualTransactionsValidationException.Should().BeEquivalentTo(
                expectedTransactionsValidationException);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

 
    }
}