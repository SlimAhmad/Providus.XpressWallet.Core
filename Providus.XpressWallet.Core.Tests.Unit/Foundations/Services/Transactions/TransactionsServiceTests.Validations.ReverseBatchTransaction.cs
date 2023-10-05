using FluentAssertions;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalTransactions;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transactions;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transactions.Exceptions;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.Transactions
{
    public partial class TransactionsServiceTests
    {

        [Fact]
        public async Task ShouldThrowValidationExceptionOnReverseBatchTransactionIfReverseBatchTransactionIsNullAsync()
        {
            // given
            ReverseBatchTransaction nullReverseBatchTransaction = null;
            var nullReverseBatchTransactionException = new NullTransactionsException();

        

            var exceptedTransactionsValidationException =
                new TransactionsValidationException(nullReverseBatchTransactionException);

            // when
            ValueTask<ReverseBatchTransaction> ReverseBatchTransactionTask =
                this.transactionsService.PostReverseBatchTransactionRequestAsync(nullReverseBatchTransaction);

            TransactionsValidationException actualTransactionsValidationException =
                await Assert.ThrowsAsync<TransactionsValidationException>(
                    ReverseBatchTransactionTask.AsTask);

            // then
            actualTransactionsValidationException.Should()
                .BeEquivalentTo(exceptedTransactionsValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostReverseBatchTransactionAsync(
                    It.IsAny<ExternalReverseBatchTransactionRequest>()),
                        Times.Never);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnReverseBatchTransactionIfRequestIsNullAsync()
        {
            // given
            var invalidReverseBatchTransaction = new ReverseBatchTransaction();
            invalidReverseBatchTransaction.Request = null;
        

            var invalidReverseBatchTransactionException =
                new InvalidTransactionsException();

            invalidReverseBatchTransactionException.AddData(
                key: nameof(ReverseBatchTransactionRequest),
                values: "Value is required");

            var expectedTransactionsValidationException =
                new TransactionsValidationException(
                    invalidReverseBatchTransactionException);

            // when
            ValueTask<ReverseBatchTransaction> ReverseBatchTransactionTask =
                this.transactionsService.PostReverseBatchTransactionRequestAsync(invalidReverseBatchTransaction);

            TransactionsValidationException actualTransactionsValidationException =
                await Assert.ThrowsAsync<TransactionsValidationException>(
                    ReverseBatchTransactionTask.AsTask);

            // then
            actualTransactionsValidationException.Should()
                .BeEquivalentTo(expectedTransactionsValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostReverseBatchTransactionAsync(
                    It.IsAny<ExternalReverseBatchTransactionRequest>()),
                        Times.Never);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public async Task ShouldThrowValidationExceptionOnPostReverseBatchTransactionIfReverseBatchTransactionIsInvalidAsync(
             string invalidBatchReference)
        {
            // given
            var approveTransaction = new ReverseBatchTransaction
            {
                Request = new ReverseBatchTransactionRequest
                {

                    BatchReference = invalidBatchReference,


                }
            };

            var invalidReverseBatchTransactionException = new InvalidTransactionsException();



            invalidReverseBatchTransactionException.AddData(
                    key: nameof(ReverseBatchTransactionRequest.BatchReference),
                    values: "Value is required");




            var expectedTransactionsValidationException =
                new TransactionsValidationException(invalidReverseBatchTransactionException);

            // when
            ValueTask<ReverseBatchTransaction> ReverseBatchTransactionTask =
                this.transactionsService.PostReverseBatchTransactionRequestAsync(approveTransaction);

            TransactionsValidationException actualTransactionsValidationException =
                await Assert.ThrowsAsync<TransactionsValidationException>(ReverseBatchTransactionTask.AsTask);

            // then
            actualTransactionsValidationException.Should().BeEquivalentTo(
                expectedTransactionsValidationException);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostReverseBatchTransactionIfPostReverseBatchTransactionIsEmptyAsync()
        {
            // given
            var approveTransaction = new ReverseBatchTransaction
            {
                Request = new ReverseBatchTransactionRequest
                {

                    BatchReference = string.Empty,
                   


                }
            };
            

            var invalidReverseBatchTransactionException = new InvalidTransactionsException();


            invalidReverseBatchTransactionException.AddData(
                       key: nameof(ReverseBatchTransactionRequest.BatchReference),
                       values: "Value is required");

       

            var expectedTransactionsValidationException =
                new TransactionsValidationException(invalidReverseBatchTransactionException);

            // when
            ValueTask<ReverseBatchTransaction> ReverseBatchTransactionTask =
                this.transactionsService.PostReverseBatchTransactionRequestAsync(approveTransaction);

            TransactionsValidationException actualTransactionsValidationException =
                await Assert.ThrowsAsync<TransactionsValidationException>(
                    ReverseBatchTransactionTask.AsTask);

            // then
            actualTransactionsValidationException.Should().BeEquivalentTo(
                expectedTransactionsValidationException);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

    }
}