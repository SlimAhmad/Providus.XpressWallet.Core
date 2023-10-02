using FluentAssertions;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalTransactions;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transactions.Exceptions;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transactions;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transactions;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transactions.Exceptions;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.Transactions
{
    public partial class TransactionsServiceTests
    {

        [Fact]
        public async Task ShouldThrowValidationExceptionOnApproveTransactionIfApproveTransactionIsNullAsync()
        {
            // given
            ApproveTransaction nullApproveTransaction = null;
            var nullApproveTransactionException = new NullTransactionsException();

        

            var exceptedTransactionsValidationException =
                new TransactionsValidationException(nullApproveTransactionException);

            // when
            ValueTask<ApproveTransaction> ApproveTransactionTask =
                this.transactionsService.PostApproveTransactionRequestAsync(nullApproveTransaction);

            TransactionsValidationException actualTransactionsValidationException =
                await Assert.ThrowsAsync<TransactionsValidationException>(
                    ApproveTransactionTask.AsTask);

            // then
            actualTransactionsValidationException.Should()
                .BeEquivalentTo(exceptedTransactionsValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostApproveTransactionAsync(
                    It.IsAny<ExternalApproveTransactionRequest>()),
                        Times.Never);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnApproveTransactionIfRequestIsNullAsync()
        {
            // given
            var invalidApproveTransaction = new ApproveTransaction();
            invalidApproveTransaction.Request = null;
        

            var invalidApproveTransactionException =
                new InvalidTransactionsException();

            invalidApproveTransactionException.AddData(
                key: nameof(ApproveTransactionRequest),
                values: "Value is required");

            var expectedTransactionsValidationException =
                new TransactionsValidationException(
                    invalidApproveTransactionException);

            // when
            ValueTask<ApproveTransaction> ApproveTransactionTask =
                this.transactionsService.PostApproveTransactionRequestAsync(invalidApproveTransaction);

            TransactionsValidationException actualTransactionsValidationException =
                await Assert.ThrowsAsync<TransactionsValidationException>(
                    ApproveTransactionTask.AsTask);

            // then
            actualTransactionsValidationException.Should()
                .BeEquivalentTo(expectedTransactionsValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostApproveTransactionAsync(
                    It.IsAny<ExternalApproveTransactionRequest>()),
                        Times.Never);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public async Task ShouldThrowValidationExceptionOnPostApproveTransactionIfApproveTransactionIsInvalidAsync(
             string invalidTransactionId)
        {
            // given
            var approveTransaction = new ApproveTransaction
            {
                Request = new ApproveTransactionRequest
                {

                  TransactionId = invalidTransactionId,


                }
            };

            var invalidApproveTransactionException = new InvalidTransactionsException();



            invalidApproveTransactionException.AddData(
                    key: nameof(ApproveTransactionRequest.TransactionId),
                    values: "Value is required");




            var expectedTransactionsValidationException =
                new TransactionsValidationException(invalidApproveTransactionException);

            // when
            ValueTask<ApproveTransaction> ApproveTransactionTask =
                this.transactionsService.PostApproveTransactionRequestAsync(approveTransaction);

            TransactionsValidationException actualTransactionsValidationException =
                await Assert.ThrowsAsync<TransactionsValidationException>(ApproveTransactionTask.AsTask);

            // then
            actualTransactionsValidationException.Should().BeEquivalentTo(
                expectedTransactionsValidationException);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostApproveTransactionIfPostApproveTransactionIsEmptyAsync()
        {
            // given
            var approveTransaction = new ApproveTransaction
            {
                Request = new ApproveTransactionRequest
                {

                    TransactionId = string.Empty,
                   


                }
            };
            

            var invalidApproveTransactionException = new InvalidTransactionsException();


            invalidApproveTransactionException.AddData(
                       key: nameof(ApproveTransactionRequest.TransactionId),
                       values: "Value is required");

       

            var expectedTransactionsValidationException =
                new TransactionsValidationException(invalidApproveTransactionException);

            // when
            ValueTask<ApproveTransaction> ApproveTransactionTask =
                this.transactionsService.PostApproveTransactionRequestAsync(approveTransaction);

            TransactionsValidationException actualTransactionsValidationException =
                await Assert.ThrowsAsync<TransactionsValidationException>(
                    ApproveTransactionTask.AsTask);

            // then
            actualTransactionsValidationException.Should().BeEquivalentTo(
                expectedTransactionsValidationException);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

    }
}