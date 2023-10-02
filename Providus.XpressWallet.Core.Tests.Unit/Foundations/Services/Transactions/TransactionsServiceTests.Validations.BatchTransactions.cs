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
        [InlineData(null, null, null,0,0)]
        [InlineData("","","",0,0)]
        [InlineData(" ", " ", " ",0,0)]
        public async Task ShouldThrowValidationExceptionOnGetBatchTransactionsIfBatchTransactionsIsInvalidAsync(
          string invalidSearch,string invalidCategory ,string invalidType, int invalidPage, int invalidPerPage)
        {
            // given


            var invalidBatchTransactionsException = new InvalidTransactionsException();

            invalidBatchTransactionsException.AddData(
                key: nameof(BatchTransactions),
                values: "Value is required");

;
            var expectedTransactionsValidationException =
                new TransactionsValidationException(invalidBatchTransactionsException);

            // when
            ValueTask<BatchTransactions> BatchTransactionsTask =
                this.transactionsService.GetBatchTransactionsRequestAsync(
                    invalidSearch,invalidCategory,invalidType,invalidPage,invalidPerPage);

            TransactionsValidationException actualTransactionsValidationException =
                await Assert.ThrowsAsync<TransactionsValidationException>(BatchTransactionsTask.AsTask);

            // then
            actualTransactionsValidationException.Should().BeEquivalentTo(
                expectedTransactionsValidationException);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

 
    }
}