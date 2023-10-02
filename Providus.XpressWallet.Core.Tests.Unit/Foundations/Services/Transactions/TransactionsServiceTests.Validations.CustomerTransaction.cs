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
        [InlineData(null, null,0,0)]
        [InlineData("","",0,0)]
        [InlineData(" ", " ",0,0)]
        public async Task ShouldThrowValidationExceptionOnGetCustomerTransactionsIfCustomerTransactionsIsInvalidAsync(
           string invalidCustomerId,string invalidType,int invalidPage, int invalidPerPage)
        {
            // given


            var invalidCustomerTransactionsException = new InvalidTransactionsException();

            invalidCustomerTransactionsException.AddData(
                key: nameof(CustomerTransactions),
                values: "Value is required");

;
            var expectedTransactionsValidationException =
                new TransactionsValidationException(invalidCustomerTransactionsException);

            // when
            ValueTask<CustomerTransactions> CustomerTransactionsTask =
                this.transactionsService.GetCustomerTransactionsRequestAsync(invalidCustomerId,invalidPage,invalidType,invalidPerPage);

            TransactionsValidationException actualTransactionsValidationException =
                await Assert.ThrowsAsync<TransactionsValidationException>(CustomerTransactionsTask.AsTask);

            // then
            actualTransactionsValidationException.Should().BeEquivalentTo(
                expectedTransactionsValidationException);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

 
    }
}