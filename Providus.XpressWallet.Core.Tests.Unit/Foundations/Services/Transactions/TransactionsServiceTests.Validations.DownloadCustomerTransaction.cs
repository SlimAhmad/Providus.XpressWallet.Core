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
        public async Task ShouldThrowValidationExceptionOnGetDownloadCustomerTransactionIfDownloadCustomerTransactionIsInvalidAsync(
           string invalidCustomerId)
        {
            // given


            var invalidDownloadCustomerTransactionException = new InvalidTransactionsException();

            invalidDownloadCustomerTransactionException.AddData(
                key: nameof(DownloadCustomerTransaction),
                values: "Value is required");

;
            var expectedTransactionsValidationException =
                new TransactionsValidationException(invalidDownloadCustomerTransactionException);

            // when
            ValueTask<DownloadCustomerTransaction> DownloadCustomerTransactionTask =
                this.transactionsService.GetDownloadCustomerTransactionRequestAsync(invalidCustomerId);

            TransactionsValidationException actualTransactionsValidationException =
                await Assert.ThrowsAsync<TransactionsValidationException>(DownloadCustomerTransactionTask.AsTask);

            // then
            actualTransactionsValidationException.Should().BeEquivalentTo(
                expectedTransactionsValidationException);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

 
    }
}