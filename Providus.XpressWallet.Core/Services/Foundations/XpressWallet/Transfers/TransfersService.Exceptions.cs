using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transfers;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transfers.Exceptions;
using RESTFulSense.Exceptions;

namespace Providus.XpressWallet.Core.Services.Foundations.XpressWallet.Transfers
{
    internal partial class TransfersService
    {
        private delegate ValueTask<BankList> ReturningBankListFunction();

        private delegate ValueTask<BankAccountDetails> ReturningBankAccountDetailsFunction();

        private delegate ValueTask<MerchantBankTransfer> ReturningMerchantBankTransferFunction();

        private delegate ValueTask<CustomerBankTransfer> ReturningCustomerBankTransferFunction();

        private delegate ValueTask<MerchantBatchBankTransfer> ReturningMerchantBatchBankTransferFunction();

        private delegate ValueTask<CustomerToCustomerWalletTransfer> ReturningCustomerToCustomerWalletTransferFunction();

        private async ValueTask<CustomerToCustomerWalletTransfer> TryCatch(ReturningCustomerToCustomerWalletTransferFunction returningCustomerToCustomerWalletTransferFunction)
        {
            try
            {
                return await returningCustomerToCustomerWalletTransferFunction();
            }
            catch (NullTransfersException nullTransfersException)
            {
                throw new TransfersValidationException(nullTransfersException);
            }
            catch (InvalidTransfersException invalidTransfersException)
            {
                throw new TransfersValidationException(invalidTransfersException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationTransfersException =
                    new InvalidConfigurationTransfersException(httpResponseUrlNotFoundException);

                throw new TransfersDependencyException(invalidConfigurationTransfersException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedTransfersException =
                    new UnauthorizedTransfersException(httpResponseUnauthorizedException);

                throw new TransfersDependencyException(unauthorizedTransfersException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedTransfersException =
                    new UnauthorizedTransfersException(httpResponseForbiddenException);

                throw new TransfersDependencyException(unauthorizedTransfersException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundTransfersException =
                    new NotFoundTransfersException(httpResponseNotFoundException);

                throw new TransfersDependencyValidationException(notFoundTransfersException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidTransfersException =
                    new InvalidTransfersException(httpResponseBadRequestException);

                throw new TransfersDependencyValidationException(invalidTransfersException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallTransfersException =
                    new ExcessiveCallTransfersException(httpResponseTooManyRequestsException);

                throw new TransfersDependencyValidationException(excessiveCallTransfersException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerTransfersException =
                    new FailedServerTransfersException(httpResponseException);

                throw new TransfersDependencyException(failedServerTransfersException);
            }
            catch (Exception exception)
            {
                var failedTransfersServiceException =
                    new FailedTransfersServiceException(exception);

                throw new TransfersServiceException(failedTransfersServiceException);
            }
        }

        private async ValueTask<MerchantBatchBankTransfer> TryCatch(ReturningMerchantBatchBankTransferFunction returningMerchantBatchBankTransferFunction)
        {
            try
            {
                return await returningMerchantBatchBankTransferFunction();
            }
            catch (NullTransfersException nullTransfersException)
            {
                throw new TransfersValidationException(nullTransfersException);
            }
            catch (InvalidTransfersException invalidTransfersException)
            {
                throw new TransfersValidationException(invalidTransfersException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationTransfersException =
                    new InvalidConfigurationTransfersException(httpResponseUrlNotFoundException);

                throw new TransfersDependencyException(invalidConfigurationTransfersException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedTransfersException =
                    new UnauthorizedTransfersException(httpResponseUnauthorizedException);

                throw new TransfersDependencyException(unauthorizedTransfersException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedTransfersException =
                    new UnauthorizedTransfersException(httpResponseForbiddenException);

                throw new TransfersDependencyException(unauthorizedTransfersException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundTransfersException =
                    new NotFoundTransfersException(httpResponseNotFoundException);

                throw new TransfersDependencyValidationException(notFoundTransfersException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidTransfersException =
                    new InvalidTransfersException(httpResponseBadRequestException);

                throw new TransfersDependencyValidationException(invalidTransfersException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallTransfersException =
                    new ExcessiveCallTransfersException(httpResponseTooManyRequestsException);

                throw new TransfersDependencyValidationException(excessiveCallTransfersException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerTransfersException =
                    new FailedServerTransfersException(httpResponseException);

                throw new TransfersDependencyException(failedServerTransfersException);
            }
            catch (Exception exception)
            {
                var failedTransfersServiceException =
                    new FailedTransfersServiceException(exception);

                throw new TransfersServiceException(failedTransfersServiceException);
            }
        }
        private async ValueTask<MerchantBankTransfer> TryCatch(ReturningMerchantBankTransferFunction returningMerchantBankTransferFunction)
        {
            try
            {
                return await returningMerchantBankTransferFunction();
            }
            catch (NullTransfersException nullTransfersException)
            {
                throw new TransfersValidationException(nullTransfersException);
            }
            catch (InvalidTransfersException invalidTransfersException)
            {
                throw new TransfersValidationException(invalidTransfersException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationTransfersException =
                    new InvalidConfigurationTransfersException(httpResponseUrlNotFoundException);

                throw new TransfersDependencyException(invalidConfigurationTransfersException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedTransfersException =
                    new UnauthorizedTransfersException(httpResponseUnauthorizedException);

                throw new TransfersDependencyException(unauthorizedTransfersException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedTransfersException =
                    new UnauthorizedTransfersException(httpResponseForbiddenException);

                throw new TransfersDependencyException(unauthorizedTransfersException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundTransfersException =
                    new NotFoundTransfersException(httpResponseNotFoundException);

                throw new TransfersDependencyValidationException(notFoundTransfersException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidTransfersException =
                    new InvalidTransfersException(httpResponseBadRequestException);

                throw new TransfersDependencyValidationException(invalidTransfersException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallTransfersException =
                    new ExcessiveCallTransfersException(httpResponseTooManyRequestsException);

                throw new TransfersDependencyValidationException(excessiveCallTransfersException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerTransfersException =
                    new FailedServerTransfersException(httpResponseException);

                throw new TransfersDependencyException(failedServerTransfersException);
            }
            catch (Exception exception)
            {
                var failedTransfersServiceException =
                    new FailedTransfersServiceException(exception);

                throw new TransfersServiceException(failedTransfersServiceException);
            }
        }

        private async ValueTask<CustomerBankTransfer> TryCatch(ReturningCustomerBankTransferFunction returningCustomerBankTransferFunction)
        {
            try
            {
                return await returningCustomerBankTransferFunction();
            }
            catch (NullTransfersException nullTransfersException)
            {
                throw new TransfersValidationException(nullTransfersException);
            }
            catch (InvalidTransfersException invalidTransfersException)
            {
                throw new TransfersValidationException(invalidTransfersException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationTransfersException =
                    new InvalidConfigurationTransfersException(httpResponseUrlNotFoundException);

                throw new TransfersDependencyException(invalidConfigurationTransfersException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedTransfersException =
                    new UnauthorizedTransfersException(httpResponseUnauthorizedException);

                throw new TransfersDependencyException(unauthorizedTransfersException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedTransfersException =
                    new UnauthorizedTransfersException(httpResponseForbiddenException);

                throw new TransfersDependencyException(unauthorizedTransfersException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundTransfersException =
                    new NotFoundTransfersException(httpResponseNotFoundException);

                throw new TransfersDependencyValidationException(notFoundTransfersException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidTransfersException =
                    new InvalidTransfersException(httpResponseBadRequestException);

                throw new TransfersDependencyValidationException(invalidTransfersException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallTransfersException =
                    new ExcessiveCallTransfersException(httpResponseTooManyRequestsException);

                throw new TransfersDependencyValidationException(excessiveCallTransfersException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerTransfersException =
                    new FailedServerTransfersException(httpResponseException);

                throw new TransfersDependencyException(failedServerTransfersException);
            }
            catch (Exception exception)
            {
                var failedTransfersServiceException =
                    new FailedTransfersServiceException(exception);

                throw new TransfersServiceException(failedTransfersServiceException);
            }
        }

        private async ValueTask<BankList> TryCatch(ReturningBankListFunction returningBankListFunction)
        {
            try
            {
                return await returningBankListFunction();
            }
            catch (NullTransfersException nullTransfersException)
            {
                throw new TransfersValidationException(nullTransfersException);
            }
            catch (InvalidTransfersException invalidTransfersException)
            {
                throw new TransfersValidationException(invalidTransfersException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationTransfersException =
                    new InvalidConfigurationTransfersException(httpResponseUrlNotFoundException);

                throw new TransfersDependencyException(invalidConfigurationTransfersException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedTransfersException =
                    new UnauthorizedTransfersException(httpResponseUnauthorizedException);

                throw new TransfersDependencyException(unauthorizedTransfersException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedTransfersException =
                    new UnauthorizedTransfersException(httpResponseForbiddenException);

                throw new TransfersDependencyException(unauthorizedTransfersException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundTransfersException =
                    new NotFoundTransfersException(httpResponseNotFoundException);

                throw new TransfersDependencyValidationException(notFoundTransfersException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidTransfersException =
                    new InvalidTransfersException(httpResponseBadRequestException);

                throw new TransfersDependencyValidationException(invalidTransfersException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallTransfersException =
                    new ExcessiveCallTransfersException(httpResponseTooManyRequestsException);

                throw new TransfersDependencyValidationException(excessiveCallTransfersException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerTransfersException =
                    new FailedServerTransfersException(httpResponseException);

                throw new TransfersDependencyException(failedServerTransfersException);
            }
            catch (Exception exception)
            {
                var failedTransfersServiceException =
                    new FailedTransfersServiceException(exception);

                throw new TransfersServiceException(failedTransfersServiceException);
            }
        }

        private async ValueTask<BankAccountDetails> TryCatch(
            ReturningBankAccountDetailsFunction returningBankAccountDetailsFunction)
        {
            try
            {
                return await returningBankAccountDetailsFunction();
            }
            catch (NullTransfersException nullTransfersException)
            {
                throw new TransfersValidationException(nullTransfersException);
            }
            catch (InvalidTransfersException invalidTransfersException)
            {
                throw new TransfersValidationException(invalidTransfersException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationTransfersException =
                    new InvalidConfigurationTransfersException(httpResponseUrlNotFoundException);

                throw new TransfersDependencyException(invalidConfigurationTransfersException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedTransfersException =
                    new UnauthorizedTransfersException(httpResponseUnauthorizedException);

                throw new TransfersDependencyException(unauthorizedTransfersException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedTransfersException =
                    new UnauthorizedTransfersException(httpResponseForbiddenException);

                throw new TransfersDependencyException(unauthorizedTransfersException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundTransfersException =
                    new NotFoundTransfersException(httpResponseNotFoundException);

                throw new TransfersDependencyValidationException(notFoundTransfersException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidTransfersException =
                    new InvalidTransfersException(httpResponseBadRequestException);

                throw new TransfersDependencyValidationException(invalidTransfersException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallTransfersException =
                    new ExcessiveCallTransfersException(httpResponseTooManyRequestsException);

                throw new TransfersDependencyValidationException(excessiveCallTransfersException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerTransfersException =
                    new FailedServerTransfersException(httpResponseException);

                throw new TransfersDependencyException(failedServerTransfersException);
            }
            catch (Exception exception)
            {
                var failedTransfersServiceException =
                    new FailedTransfersServiceException(exception);

                throw new TransfersServiceException(failedTransfersServiceException);
            }
        }

    }
}