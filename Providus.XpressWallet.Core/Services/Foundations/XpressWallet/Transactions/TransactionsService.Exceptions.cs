using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Customers;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transactions;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transactions.Exceptions;
using RESTFulSense.Exceptions;

namespace Providus.XpressWallet.Core.Services.Foundations.XpressWallet.Transactions
{
    internal partial class TransactionsService
    {
        private delegate ValueTask<MerchantTransactions> ReturningMerchantTransactionsFunction();

        private delegate ValueTask<TransactionDetails> ReturningTransactionDetailsFunction();

        private delegate ValueTask<CustomerTransactions> ReturningCustomerTransactionsFunction();

        private delegate ValueTask<BatchTransactions> ReturningBatchTransactionsFunction();

        private delegate ValueTask<BatchTransactionDetails> ReturningBatchTransactionDetailsFunction();

        private delegate ValueTask<ReverseBatchTransaction> ReturningReverseBatchTransactionFunction();

        private delegate ValueTask<PendingTransaction> ReturningPendingTransactionFunction();

        private delegate ValueTask<ApproveTransaction> ReturningApproveTransactionFunction();

        private delegate ValueTask<DeclinePendingTransaction> ReturningDeclinePendingTransactionFunction();

        private delegate ValueTask<DownloadCustomerTransaction> ReturningDownloadCustomerTransactionFunction();

        private delegate ValueTask<DownloadMerchantTransaction> ReturningDownloadMerchantTransactionFunction();




        private async ValueTask<DeclinePendingTransaction> TryCatch(ReturningDeclinePendingTransactionFunction returningDeclinePendingTransactionFunction)
        {
            try
            {
                return await returningDeclinePendingTransactionFunction();
            }
            catch (NullTransactionsException nullTransactionsException)
            {
                throw new TransactionsValidationException(nullTransactionsException);
            }
            catch (InvalidTransactionsException invalidTransactionsException)
            {
                throw new TransactionsValidationException(invalidTransactionsException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationTransactionsException =
                    new InvalidConfigurationTransactionsException(httpResponseUrlNotFoundException);

                throw new TransactionsDependencyException(invalidConfigurationTransactionsException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedTransactionsException =
                    new UnauthorizedTransactionsException(httpResponseUnauthorizedException);

                throw new TransactionsDependencyException(unauthorizedTransactionsException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedTransactionsException =
                    new UnauthorizedTransactionsException(httpResponseForbiddenException);

                throw new TransactionsDependencyException(unauthorizedTransactionsException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundTransactionsException =
                    new NotFoundTransactionsException(httpResponseNotFoundException);

                throw new TransactionsDependencyValidationException(notFoundTransactionsException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidTransactionsException =
                    new InvalidTransactionsException(httpResponseBadRequestException);

                throw new TransactionsDependencyValidationException(invalidTransactionsException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallTransactionsException =
                    new ExcessiveCallTransactionsException(httpResponseTooManyRequestsException);

                throw new TransactionsDependencyValidationException(excessiveCallTransactionsException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerTransactionsException =
                    new FailedServerTransactionsException(httpResponseException);

                throw new TransactionsDependencyException(failedServerTransactionsException);
            }
            catch (Exception exception)
            {
                var failedTransactionsServiceException =
                    new FailedTransactionsServiceException(exception);

                throw new TransactionsServiceException(failedTransactionsServiceException);
            }
        }

        private async ValueTask<DownloadCustomerTransaction> TryCatch(ReturningDownloadCustomerTransactionFunction returningDownloadCustomerTransactionFunction)
        {
            try
            {
                return await returningDownloadCustomerTransactionFunction();
            }
            catch (NullTransactionsException nullTransactionsException)
            {
                throw new TransactionsValidationException(nullTransactionsException);
            }
            catch (InvalidTransactionsException invalidTransactionsException)
            {
                throw new TransactionsValidationException(invalidTransactionsException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationTransactionsException =
                    new InvalidConfigurationTransactionsException(httpResponseUrlNotFoundException);

                throw new TransactionsDependencyException(invalidConfigurationTransactionsException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedTransactionsException =
                    new UnauthorizedTransactionsException(httpResponseUnauthorizedException);

                throw new TransactionsDependencyException(unauthorizedTransactionsException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedTransactionsException =
                    new UnauthorizedTransactionsException(httpResponseForbiddenException);

                throw new TransactionsDependencyException(unauthorizedTransactionsException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundTransactionsException =
                    new NotFoundTransactionsException(httpResponseNotFoundException);

                throw new TransactionsDependencyValidationException(notFoundTransactionsException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidTransactionsException =
                    new InvalidTransactionsException(httpResponseBadRequestException);

                throw new TransactionsDependencyValidationException(invalidTransactionsException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallTransactionsException =
                    new ExcessiveCallTransactionsException(httpResponseTooManyRequestsException);

                throw new TransactionsDependencyValidationException(excessiveCallTransactionsException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerTransactionsException =
                    new FailedServerTransactionsException(httpResponseException);

                throw new TransactionsDependencyException(failedServerTransactionsException);
            }
            catch (Exception exception)
            {
                var failedTransactionsServiceException =
                    new FailedTransactionsServiceException(exception);

                throw new TransactionsServiceException(failedTransactionsServiceException);
            }
        }

        private async ValueTask<DownloadMerchantTransaction> TryCatch(ReturningDownloadMerchantTransactionFunction returningDownloadMerchantTransactionFunction)
        {
            try
            {
                return await returningDownloadMerchantTransactionFunction();
            }
            catch (NullTransactionsException nullTransactionsException)
            {
                throw new TransactionsValidationException(nullTransactionsException);
            }
            catch (InvalidTransactionsException invalidTransactionsException)
            {
                throw new TransactionsValidationException(invalidTransactionsException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationTransactionsException =
                    new InvalidConfigurationTransactionsException(httpResponseUrlNotFoundException);

                throw new TransactionsDependencyException(invalidConfigurationTransactionsException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedTransactionsException =
                    new UnauthorizedTransactionsException(httpResponseUnauthorizedException);

                throw new TransactionsDependencyException(unauthorizedTransactionsException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedTransactionsException =
                    new UnauthorizedTransactionsException(httpResponseForbiddenException);

                throw new TransactionsDependencyException(unauthorizedTransactionsException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundTransactionsException =
                    new NotFoundTransactionsException(httpResponseNotFoundException);

                throw new TransactionsDependencyValidationException(notFoundTransactionsException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidTransactionsException =
                    new InvalidTransactionsException(httpResponseBadRequestException);

                throw new TransactionsDependencyValidationException(invalidTransactionsException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallTransactionsException =
                    new ExcessiveCallTransactionsException(httpResponseTooManyRequestsException);

                throw new TransactionsDependencyValidationException(excessiveCallTransactionsException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerTransactionsException =
                    new FailedServerTransactionsException(httpResponseException);

                throw new TransactionsDependencyException(failedServerTransactionsException);
            }
            catch (Exception exception)
            {
                var failedTransactionsServiceException =
                    new FailedTransactionsServiceException(exception);

                throw new TransactionsServiceException(failedTransactionsServiceException);
            }
        }

        private async ValueTask<ApproveTransaction> TryCatch(ReturningApproveTransactionFunction returningApproveTransactionFunction)
        {
            try
            {
                return await returningApproveTransactionFunction();
            }
            catch (NullTransactionsException nullTransactionsException)
            {
                throw new TransactionsValidationException(nullTransactionsException);
            }
            catch (InvalidTransactionsException invalidTransactionsException)
            {
                throw new TransactionsValidationException(invalidTransactionsException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationTransactionsException =
                    new InvalidConfigurationTransactionsException(httpResponseUrlNotFoundException);

                throw new TransactionsDependencyException(invalidConfigurationTransactionsException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedTransactionsException =
                    new UnauthorizedTransactionsException(httpResponseUnauthorizedException);

                throw new TransactionsDependencyException(unauthorizedTransactionsException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedTransactionsException =
                    new UnauthorizedTransactionsException(httpResponseForbiddenException);

                throw new TransactionsDependencyException(unauthorizedTransactionsException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundTransactionsException =
                    new NotFoundTransactionsException(httpResponseNotFoundException);

                throw new TransactionsDependencyValidationException(notFoundTransactionsException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidTransactionsException =
                    new InvalidTransactionsException(httpResponseBadRequestException);

                throw new TransactionsDependencyValidationException(invalidTransactionsException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallTransactionsException =
                    new ExcessiveCallTransactionsException(httpResponseTooManyRequestsException);

                throw new TransactionsDependencyValidationException(excessiveCallTransactionsException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerTransactionsException =
                    new FailedServerTransactionsException(httpResponseException);

                throw new TransactionsDependencyException(failedServerTransactionsException);
            }
            catch (Exception exception)
            {
                var failedTransactionsServiceException =
                    new FailedTransactionsServiceException(exception);

                throw new TransactionsServiceException(failedTransactionsServiceException);
            }
        }

        private async ValueTask<PendingTransaction> TryCatch(ReturningPendingTransactionFunction returningPendingTransactionFunction)
        {
            try
            {
                return await returningPendingTransactionFunction();
            }
            catch (NullTransactionsException nullTransactionsException)
            {
                throw new TransactionsValidationException(nullTransactionsException);
            }
            catch (InvalidTransactionsException invalidTransactionsException)
            {
                throw new TransactionsValidationException(invalidTransactionsException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationTransactionsException =
                    new InvalidConfigurationTransactionsException(httpResponseUrlNotFoundException);

                throw new TransactionsDependencyException(invalidConfigurationTransactionsException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedTransactionsException =
                    new UnauthorizedTransactionsException(httpResponseUnauthorizedException);

                throw new TransactionsDependencyException(unauthorizedTransactionsException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedTransactionsException =
                    new UnauthorizedTransactionsException(httpResponseForbiddenException);

                throw new TransactionsDependencyException(unauthorizedTransactionsException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundTransactionsException =
                    new NotFoundTransactionsException(httpResponseNotFoundException);

                throw new TransactionsDependencyValidationException(notFoundTransactionsException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidTransactionsException =
                    new InvalidTransactionsException(httpResponseBadRequestException);

                throw new TransactionsDependencyValidationException(invalidTransactionsException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallTransactionsException =
                    new ExcessiveCallTransactionsException(httpResponseTooManyRequestsException);

                throw new TransactionsDependencyValidationException(excessiveCallTransactionsException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerTransactionsException =
                    new FailedServerTransactionsException(httpResponseException);

                throw new TransactionsDependencyException(failedServerTransactionsException);
            }
            catch (Exception exception)
            {
                var failedTransactionsServiceException =
                    new FailedTransactionsServiceException(exception);

                throw new TransactionsServiceException(failedTransactionsServiceException);
            }
        }

        private async ValueTask<ReverseBatchTransaction> TryCatch(ReturningReverseBatchTransactionFunction returningReverseBatchTransactionFunction)
        {
            try
            {
                return await returningReverseBatchTransactionFunction();
            }
            catch (NullTransactionsException nullTransactionsException)
            {
                throw new TransactionsValidationException(nullTransactionsException);
            }
            catch (InvalidTransactionsException invalidTransactionsException)
            {
                throw new TransactionsValidationException(invalidTransactionsException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationTransactionsException =
                    new InvalidConfigurationTransactionsException(httpResponseUrlNotFoundException);

                throw new TransactionsDependencyException(invalidConfigurationTransactionsException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedTransactionsException =
                    new UnauthorizedTransactionsException(httpResponseUnauthorizedException);

                throw new TransactionsDependencyException(unauthorizedTransactionsException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedTransactionsException =
                    new UnauthorizedTransactionsException(httpResponseForbiddenException);

                throw new TransactionsDependencyException(unauthorizedTransactionsException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundTransactionsException =
                    new NotFoundTransactionsException(httpResponseNotFoundException);

                throw new TransactionsDependencyValidationException(notFoundTransactionsException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidTransactionsException =
                    new InvalidTransactionsException(httpResponseBadRequestException);

                throw new TransactionsDependencyValidationException(invalidTransactionsException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallTransactionsException =
                    new ExcessiveCallTransactionsException(httpResponseTooManyRequestsException);

                throw new TransactionsDependencyValidationException(excessiveCallTransactionsException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerTransactionsException =
                    new FailedServerTransactionsException(httpResponseException);

                throw new TransactionsDependencyException(failedServerTransactionsException);
            }
            catch (Exception exception)
            {
                var failedTransactionsServiceException =
                    new FailedTransactionsServiceException(exception);

                throw new TransactionsServiceException(failedTransactionsServiceException);
            }
        }

        private async ValueTask<BatchTransactionDetails> TryCatch(ReturningBatchTransactionDetailsFunction returningBatchTransactionDetailsFunction)
        {
            try
            {
                return await returningBatchTransactionDetailsFunction();
            }
            catch (NullTransactionsException nullTransactionsException)
            {
                throw new TransactionsValidationException(nullTransactionsException);
            }
            catch (InvalidTransactionsException invalidTransactionsException)
            {
                throw new TransactionsValidationException(invalidTransactionsException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationTransactionsException =
                    new InvalidConfigurationTransactionsException(httpResponseUrlNotFoundException);

                throw new TransactionsDependencyException(invalidConfigurationTransactionsException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedTransactionsException =
                    new UnauthorizedTransactionsException(httpResponseUnauthorizedException);

                throw new TransactionsDependencyException(unauthorizedTransactionsException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedTransactionsException =
                    new UnauthorizedTransactionsException(httpResponseForbiddenException);

                throw new TransactionsDependencyException(unauthorizedTransactionsException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundTransactionsException =
                    new NotFoundTransactionsException(httpResponseNotFoundException);

                throw new TransactionsDependencyValidationException(notFoundTransactionsException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidTransactionsException =
                    new InvalidTransactionsException(httpResponseBadRequestException);

                throw new TransactionsDependencyValidationException(invalidTransactionsException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallTransactionsException =
                    new ExcessiveCallTransactionsException(httpResponseTooManyRequestsException);

                throw new TransactionsDependencyValidationException(excessiveCallTransactionsException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerTransactionsException =
                    new FailedServerTransactionsException(httpResponseException);

                throw new TransactionsDependencyException(failedServerTransactionsException);
            }
            catch (Exception exception)
            {
                var failedTransactionsServiceException =
                    new FailedTransactionsServiceException(exception);

                throw new TransactionsServiceException(failedTransactionsServiceException);
            }
        }
        private async ValueTask<CustomerTransactions> TryCatch(ReturningCustomerTransactionsFunction returningCustomerTransactionsFunction)
        {
            try
            {
                return await returningCustomerTransactionsFunction();
            }
            catch (NullTransactionsException nullTransactionsException)
            {
                throw new TransactionsValidationException(nullTransactionsException);
            }
            catch (InvalidTransactionsException invalidTransactionsException)
            {
                throw new TransactionsValidationException(invalidTransactionsException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationTransactionsException =
                    new InvalidConfigurationTransactionsException(httpResponseUrlNotFoundException);

                throw new TransactionsDependencyException(invalidConfigurationTransactionsException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedTransactionsException =
                    new UnauthorizedTransactionsException(httpResponseUnauthorizedException);

                throw new TransactionsDependencyException(unauthorizedTransactionsException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedTransactionsException =
                    new UnauthorizedTransactionsException(httpResponseForbiddenException);

                throw new TransactionsDependencyException(unauthorizedTransactionsException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundTransactionsException =
                    new NotFoundTransactionsException(httpResponseNotFoundException);

                throw new TransactionsDependencyValidationException(notFoundTransactionsException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidTransactionsException =
                    new InvalidTransactionsException(httpResponseBadRequestException);

                throw new TransactionsDependencyValidationException(invalidTransactionsException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallTransactionsException =
                    new ExcessiveCallTransactionsException(httpResponseTooManyRequestsException);

                throw new TransactionsDependencyValidationException(excessiveCallTransactionsException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerTransactionsException =
                    new FailedServerTransactionsException(httpResponseException);

                throw new TransactionsDependencyException(failedServerTransactionsException);
            }
            catch (Exception exception)
            {
                var failedTransactionsServiceException =
                    new FailedTransactionsServiceException(exception);

                throw new TransactionsServiceException(failedTransactionsServiceException);
            }
        }

        private async ValueTask<BatchTransactions> TryCatch(ReturningBatchTransactionsFunction returningBatchTransactionsFunction)
        {
            try
            {
                return await returningBatchTransactionsFunction();
            }
            catch (NullTransactionsException nullTransactionsException)
            {
                throw new TransactionsValidationException(nullTransactionsException);
            }
            catch (InvalidTransactionsException invalidTransactionsException)
            {
                throw new TransactionsValidationException(invalidTransactionsException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationTransactionsException =
                    new InvalidConfigurationTransactionsException(httpResponseUrlNotFoundException);

                throw new TransactionsDependencyException(invalidConfigurationTransactionsException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedTransactionsException =
                    new UnauthorizedTransactionsException(httpResponseUnauthorizedException);

                throw new TransactionsDependencyException(unauthorizedTransactionsException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedTransactionsException =
                    new UnauthorizedTransactionsException(httpResponseForbiddenException);

                throw new TransactionsDependencyException(unauthorizedTransactionsException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundTransactionsException =
                    new NotFoundTransactionsException(httpResponseNotFoundException);

                throw new TransactionsDependencyValidationException(notFoundTransactionsException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidTransactionsException =
                    new InvalidTransactionsException(httpResponseBadRequestException);

                throw new TransactionsDependencyValidationException(invalidTransactionsException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallTransactionsException =
                    new ExcessiveCallTransactionsException(httpResponseTooManyRequestsException);

                throw new TransactionsDependencyValidationException(excessiveCallTransactionsException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerTransactionsException =
                    new FailedServerTransactionsException(httpResponseException);

                throw new TransactionsDependencyException(failedServerTransactionsException);
            }
            catch (Exception exception)
            {
                var failedTransactionsServiceException =
                    new FailedTransactionsServiceException(exception);

                throw new TransactionsServiceException(failedTransactionsServiceException);
            }
        }

        private async ValueTask<MerchantTransactions> TryCatch(ReturningMerchantTransactionsFunction returningMerchantTransactionsFunction)
        {
            try
            {
                return await returningMerchantTransactionsFunction();
            }
            catch (NullTransactionsException nullTransactionsException)
            {
                throw new TransactionsValidationException(nullTransactionsException);
            }
            catch (InvalidTransactionsException invalidTransactionsException)
            {
                throw new TransactionsValidationException(invalidTransactionsException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationTransactionsException =
                    new InvalidConfigurationTransactionsException(httpResponseUrlNotFoundException);

                throw new TransactionsDependencyException(invalidConfigurationTransactionsException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedTransactionsException =
                    new UnauthorizedTransactionsException(httpResponseUnauthorizedException);

                throw new TransactionsDependencyException(unauthorizedTransactionsException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedTransactionsException =
                    new UnauthorizedTransactionsException(httpResponseForbiddenException);

                throw new TransactionsDependencyException(unauthorizedTransactionsException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundTransactionsException =
                    new NotFoundTransactionsException(httpResponseNotFoundException);

                throw new TransactionsDependencyValidationException(notFoundTransactionsException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidTransactionsException =
                    new InvalidTransactionsException(httpResponseBadRequestException);

                throw new TransactionsDependencyValidationException(invalidTransactionsException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallTransactionsException =
                    new ExcessiveCallTransactionsException(httpResponseTooManyRequestsException);

                throw new TransactionsDependencyValidationException(excessiveCallTransactionsException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerTransactionsException =
                    new FailedServerTransactionsException(httpResponseException);

                throw new TransactionsDependencyException(failedServerTransactionsException);
            }
            catch (Exception exception)
            {
                var failedTransactionsServiceException =
                    new FailedTransactionsServiceException(exception);

                throw new TransactionsServiceException(failedTransactionsServiceException);
            }
        }

        private async ValueTask<TransactionDetails> TryCatch(
            ReturningTransactionDetailsFunction returningTransactionDetailsFunction)
        {
            try
            {
                return await returningTransactionDetailsFunction();
            }
            catch (NullTransactionsException nullTransactionsException)
            {
                throw new TransactionsValidationException(nullTransactionsException);
            }
            catch (InvalidTransactionsException invalidTransactionsException)
            {
                throw new TransactionsValidationException(invalidTransactionsException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationTransactionsException =
                    new InvalidConfigurationTransactionsException(httpResponseUrlNotFoundException);

                throw new TransactionsDependencyException(invalidConfigurationTransactionsException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedTransactionsException =
                    new UnauthorizedTransactionsException(httpResponseUnauthorizedException);

                throw new TransactionsDependencyException(unauthorizedTransactionsException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedTransactionsException =
                    new UnauthorizedTransactionsException(httpResponseForbiddenException);

                throw new TransactionsDependencyException(unauthorizedTransactionsException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundTransactionsException =
                    new NotFoundTransactionsException(httpResponseNotFoundException);

                throw new TransactionsDependencyValidationException(notFoundTransactionsException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidTransactionsException =
                    new InvalidTransactionsException(httpResponseBadRequestException);

                throw new TransactionsDependencyValidationException(invalidTransactionsException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallTransactionsException =
                    new ExcessiveCallTransactionsException(httpResponseTooManyRequestsException);

                throw new TransactionsDependencyValidationException(excessiveCallTransactionsException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerTransactionsException =
                    new FailedServerTransactionsException(httpResponseException);

                throw new TransactionsDependencyException(failedServerTransactionsException);
            }
            catch (Exception exception)
            {
                var failedTransactionsServiceException =
                    new FailedTransactionsServiceException(exception);

                throw new TransactionsServiceException(failedTransactionsServiceException);
            }
        }

    }
}