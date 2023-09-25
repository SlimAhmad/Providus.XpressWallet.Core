using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Wallet;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Wallet.Exceptions;
using RESTFulSense.Exceptions;

namespace Providus.XpressWallet.Core.Services.Foundations.XpressWallet.Wallet
{
    internal partial class WalletService
    {
        private delegate ValueTask<CreateWallet> ReturningCreateWalletFunction();

        private delegate ValueTask<AllWallets> ReturningAllWalletsFunction();

        private delegate ValueTask<CustomerWallet> ReturningCustomerWalletFunction();

        private delegate ValueTask<CreditWallet> ReturningCreditWalletFunction();

        private delegate ValueTask<DebitWallet> ReturningDebitWalletFunction();

        private delegate ValueTask<FreezeWallet> ReturningFreezeWalletFunction();

        private delegate ValueTask<UnfreezeWallet> ReturningUnfreezeWalletFunction();

        private delegate ValueTask<BatchDebitCustomerWallets> ReturningBatchDebitCustomerWalletsFunction();

        private delegate ValueTask<BatchCreditCustomerWallets> ReturningBatchCreditCustomerWalletsFunction();

        private delegate ValueTask<CustomerCreditCustomerWallet> ReturningCustomerCreditCustomerWalletFunction();

        private delegate ValueTask<FundMerchantSandBoxWallet> ReturningFundMerchantSandBoxWalletFunction();


        private async ValueTask<UnfreezeWallet> TryCatch(ReturningUnfreezeWalletFunction returningUnfreezeWalletFunction)
        {
            try
            {
                return await returningUnfreezeWalletFunction();
            }
            catch (NullWalletException nullWalletException)
            {
                throw new WalletValidationException(nullWalletException);
            }
            catch (InvalidWalletException invalidWalletException)
            {
                throw new WalletValidationException(invalidWalletException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationWalletException =
                    new InvalidConfigurationWalletException(httpResponseUrlNotFoundException);

                throw new WalletDependencyException(invalidConfigurationWalletException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedWalletException =
                    new UnauthorizedWalletException(httpResponseUnauthorizedException);

                throw new WalletDependencyException(unauthorizedWalletException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedWalletException =
                    new UnauthorizedWalletException(httpResponseForbiddenException);

                throw new WalletDependencyException(unauthorizedWalletException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundWalletException =
                    new NotFoundWalletException(httpResponseNotFoundException);

                throw new WalletDependencyValidationException(notFoundWalletException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidWalletException =
                    new InvalidWalletException(httpResponseBadRequestException);

                throw new WalletDependencyValidationException(invalidWalletException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallWalletException =
                    new ExcessiveCallWalletException(httpResponseTooManyRequestsException);

                throw new WalletDependencyValidationException(excessiveCallWalletException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerWalletException =
                    new FailedServerWalletException(httpResponseException);

                throw new WalletDependencyException(failedServerWalletException);
            }
            catch (Exception exception)
            {
                var failedWalletServiceException =
                    new FailedWalletServiceException(exception);

                throw new WalletServiceException(failedWalletServiceException);
            }
        }

        private async ValueTask<BatchDebitCustomerWallets> TryCatch(ReturningBatchDebitCustomerWalletsFunction returningBatchDebitCustomerWalletsFunction)
        {
            try
            {
                return await returningBatchDebitCustomerWalletsFunction();
            }
            catch (NullWalletException nullWalletException)
            {
                throw new WalletValidationException(nullWalletException);
            }
            catch (InvalidWalletException invalidWalletException)
            {
                throw new WalletValidationException(invalidWalletException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationWalletException =
                    new InvalidConfigurationWalletException(httpResponseUrlNotFoundException);

                throw new WalletDependencyException(invalidConfigurationWalletException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedWalletException =
                    new UnauthorizedWalletException(httpResponseUnauthorizedException);

                throw new WalletDependencyException(unauthorizedWalletException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedWalletException =
                    new UnauthorizedWalletException(httpResponseForbiddenException);

                throw new WalletDependencyException(unauthorizedWalletException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundWalletException =
                    new NotFoundWalletException(httpResponseNotFoundException);

                throw new WalletDependencyValidationException(notFoundWalletException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidWalletException =
                    new InvalidWalletException(httpResponseBadRequestException);

                throw new WalletDependencyValidationException(invalidWalletException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallWalletException =
                    new ExcessiveCallWalletException(httpResponseTooManyRequestsException);

                throw new WalletDependencyValidationException(excessiveCallWalletException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerWalletException =
                    new FailedServerWalletException(httpResponseException);

                throw new WalletDependencyException(failedServerWalletException);
            }
            catch (Exception exception)
            {
                var failedWalletServiceException =
                    new FailedWalletServiceException(exception);

                throw new WalletServiceException(failedWalletServiceException);
            }
        }

        private async ValueTask<BatchCreditCustomerWallets> TryCatch(ReturningBatchCreditCustomerWalletsFunction returningBatchCreditCustomerWalletsFunction)
        {
            try
            {
                return await returningBatchCreditCustomerWalletsFunction();
            }
            catch (NullWalletException nullWalletException)
            {
                throw new WalletValidationException(nullWalletException);
            }
            catch (InvalidWalletException invalidWalletException)
            {
                throw new WalletValidationException(invalidWalletException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationWalletException =
                    new InvalidConfigurationWalletException(httpResponseUrlNotFoundException);

                throw new WalletDependencyException(invalidConfigurationWalletException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedWalletException =
                    new UnauthorizedWalletException(httpResponseUnauthorizedException);

                throw new WalletDependencyException(unauthorizedWalletException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedWalletException =
                    new UnauthorizedWalletException(httpResponseForbiddenException);

                throw new WalletDependencyException(unauthorizedWalletException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundWalletException =
                    new NotFoundWalletException(httpResponseNotFoundException);

                throw new WalletDependencyValidationException(notFoundWalletException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidWalletException =
                    new InvalidWalletException(httpResponseBadRequestException);

                throw new WalletDependencyValidationException(invalidWalletException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallWalletException =
                    new ExcessiveCallWalletException(httpResponseTooManyRequestsException);

                throw new WalletDependencyValidationException(excessiveCallWalletException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerWalletException =
                    new FailedServerWalletException(httpResponseException);

                throw new WalletDependencyException(failedServerWalletException);
            }
            catch (Exception exception)
            {
                var failedWalletServiceException =
                    new FailedWalletServiceException(exception);

                throw new WalletServiceException(failedWalletServiceException);
            }
        }

        private async ValueTask<CustomerCreditCustomerWallet> TryCatch(ReturningCustomerCreditCustomerWalletFunction returningCustomerCreditCustomerWalletFunction)
        {
            try
            {
                return await returningCustomerCreditCustomerWalletFunction();
            }
            catch (NullWalletException nullWalletException)
            {
                throw new WalletValidationException(nullWalletException);
            }
            catch (InvalidWalletException invalidWalletException)
            {
                throw new WalletValidationException(invalidWalletException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationWalletException =
                    new InvalidConfigurationWalletException(httpResponseUrlNotFoundException);

                throw new WalletDependencyException(invalidConfigurationWalletException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedWalletException =
                    new UnauthorizedWalletException(httpResponseUnauthorizedException);

                throw new WalletDependencyException(unauthorizedWalletException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedWalletException =
                    new UnauthorizedWalletException(httpResponseForbiddenException);

                throw new WalletDependencyException(unauthorizedWalletException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundWalletException =
                    new NotFoundWalletException(httpResponseNotFoundException);

                throw new WalletDependencyValidationException(notFoundWalletException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidWalletException =
                    new InvalidWalletException(httpResponseBadRequestException);

                throw new WalletDependencyValidationException(invalidWalletException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallWalletException =
                    new ExcessiveCallWalletException(httpResponseTooManyRequestsException);

                throw new WalletDependencyValidationException(excessiveCallWalletException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerWalletException =
                    new FailedServerWalletException(httpResponseException);

                throw new WalletDependencyException(failedServerWalletException);
            }
            catch (Exception exception)
            {
                var failedWalletServiceException =
                    new FailedWalletServiceException(exception);

                throw new WalletServiceException(failedWalletServiceException);
            }
        }

        private async ValueTask<FundMerchantSandBoxWallet> TryCatch(ReturningFundMerchantSandBoxWalletFunction returningFundMerchantSandBoxWalletFunction)
        {
            try
            {
                return await returningFundMerchantSandBoxWalletFunction();
            }
            catch (NullWalletException nullWalletException)
            {
                throw new WalletValidationException(nullWalletException);
            }
            catch (InvalidWalletException invalidWalletException)
            {
                throw new WalletValidationException(invalidWalletException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationWalletException =
                    new InvalidConfigurationWalletException(httpResponseUrlNotFoundException);

                throw new WalletDependencyException(invalidConfigurationWalletException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedWalletException =
                    new UnauthorizedWalletException(httpResponseUnauthorizedException);

                throw new WalletDependencyException(unauthorizedWalletException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedWalletException =
                    new UnauthorizedWalletException(httpResponseForbiddenException);

                throw new WalletDependencyException(unauthorizedWalletException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundWalletException =
                    new NotFoundWalletException(httpResponseNotFoundException);

                throw new WalletDependencyValidationException(notFoundWalletException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidWalletException =
                    new InvalidWalletException(httpResponseBadRequestException);

                throw new WalletDependencyValidationException(invalidWalletException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallWalletException =
                    new ExcessiveCallWalletException(httpResponseTooManyRequestsException);

                throw new WalletDependencyValidationException(excessiveCallWalletException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerWalletException =
                    new FailedServerWalletException(httpResponseException);

                throw new WalletDependencyException(failedServerWalletException);
            }
            catch (Exception exception)
            {
                var failedWalletServiceException =
                    new FailedWalletServiceException(exception);

                throw new WalletServiceException(failedWalletServiceException);
            }
        }

        private async ValueTask<FreezeWallet> TryCatch(ReturningFreezeWalletFunction returningFreezeWalletFunction)
        {
            try
            {
                return await returningFreezeWalletFunction();
            }
            catch (NullWalletException nullWalletException)
            {
                throw new WalletValidationException(nullWalletException);
            }
            catch (InvalidWalletException invalidWalletException)
            {
                throw new WalletValidationException(invalidWalletException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationWalletException =
                    new InvalidConfigurationWalletException(httpResponseUrlNotFoundException);

                throw new WalletDependencyException(invalidConfigurationWalletException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedWalletException =
                    new UnauthorizedWalletException(httpResponseUnauthorizedException);

                throw new WalletDependencyException(unauthorizedWalletException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedWalletException =
                    new UnauthorizedWalletException(httpResponseForbiddenException);

                throw new WalletDependencyException(unauthorizedWalletException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundWalletException =
                    new NotFoundWalletException(httpResponseNotFoundException);

                throw new WalletDependencyValidationException(notFoundWalletException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidWalletException =
                    new InvalidWalletException(httpResponseBadRequestException);

                throw new WalletDependencyValidationException(invalidWalletException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallWalletException =
                    new ExcessiveCallWalletException(httpResponseTooManyRequestsException);

                throw new WalletDependencyValidationException(excessiveCallWalletException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerWalletException =
                    new FailedServerWalletException(httpResponseException);

                throw new WalletDependencyException(failedServerWalletException);
            }
            catch (Exception exception)
            {
                var failedWalletServiceException =
                    new FailedWalletServiceException(exception);

                throw new WalletServiceException(failedWalletServiceException);
            }
        }

        private async ValueTask<DebitWallet> TryCatch(ReturningDebitWalletFunction returningDebitWalletFunction)
        {
            try
            {
                return await returningDebitWalletFunction();
            }
            catch (NullWalletException nullWalletException)
            {
                throw new WalletValidationException(nullWalletException);
            }
            catch (InvalidWalletException invalidWalletException)
            {
                throw new WalletValidationException(invalidWalletException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationWalletException =
                    new InvalidConfigurationWalletException(httpResponseUrlNotFoundException);

                throw new WalletDependencyException(invalidConfigurationWalletException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedWalletException =
                    new UnauthorizedWalletException(httpResponseUnauthorizedException);

                throw new WalletDependencyException(unauthorizedWalletException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedWalletException =
                    new UnauthorizedWalletException(httpResponseForbiddenException);

                throw new WalletDependencyException(unauthorizedWalletException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundWalletException =
                    new NotFoundWalletException(httpResponseNotFoundException);

                throw new WalletDependencyValidationException(notFoundWalletException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidWalletException =
                    new InvalidWalletException(httpResponseBadRequestException);

                throw new WalletDependencyValidationException(invalidWalletException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallWalletException =
                    new ExcessiveCallWalletException(httpResponseTooManyRequestsException);

                throw new WalletDependencyValidationException(excessiveCallWalletException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerWalletException =
                    new FailedServerWalletException(httpResponseException);

                throw new WalletDependencyException(failedServerWalletException);
            }
            catch (Exception exception)
            {
                var failedWalletServiceException =
                    new FailedWalletServiceException(exception);

                throw new WalletServiceException(failedWalletServiceException);
            }
        }
        private async ValueTask<CustomerWallet> TryCatch(ReturningCustomerWalletFunction returningCustomerWalletFunction)
        {
            try
            {
                return await returningCustomerWalletFunction();
            }
            catch (NullWalletException nullWalletException)
            {
                throw new WalletValidationException(nullWalletException);
            }
            catch (InvalidWalletException invalidWalletException)
            {
                throw new WalletValidationException(invalidWalletException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationWalletException =
                    new InvalidConfigurationWalletException(httpResponseUrlNotFoundException);

                throw new WalletDependencyException(invalidConfigurationWalletException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedWalletException =
                    new UnauthorizedWalletException(httpResponseUnauthorizedException);

                throw new WalletDependencyException(unauthorizedWalletException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedWalletException =
                    new UnauthorizedWalletException(httpResponseForbiddenException);

                throw new WalletDependencyException(unauthorizedWalletException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundWalletException =
                    new NotFoundWalletException(httpResponseNotFoundException);

                throw new WalletDependencyValidationException(notFoundWalletException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidWalletException =
                    new InvalidWalletException(httpResponseBadRequestException);

                throw new WalletDependencyValidationException(invalidWalletException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallWalletException =
                    new ExcessiveCallWalletException(httpResponseTooManyRequestsException);

                throw new WalletDependencyValidationException(excessiveCallWalletException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerWalletException =
                    new FailedServerWalletException(httpResponseException);

                throw new WalletDependencyException(failedServerWalletException);
            }
            catch (Exception exception)
            {
                var failedWalletServiceException =
                    new FailedWalletServiceException(exception);

                throw new WalletServiceException(failedWalletServiceException);
            }
        }

        private async ValueTask<CreditWallet> TryCatch(ReturningCreditWalletFunction returningCreditWalletFunction)
        {
            try
            {
                return await returningCreditWalletFunction();
            }
            catch (NullWalletException nullWalletException)
            {
                throw new WalletValidationException(nullWalletException);
            }
            catch (InvalidWalletException invalidWalletException)
            {
                throw new WalletValidationException(invalidWalletException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationWalletException =
                    new InvalidConfigurationWalletException(httpResponseUrlNotFoundException);

                throw new WalletDependencyException(invalidConfigurationWalletException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedWalletException =
                    new UnauthorizedWalletException(httpResponseUnauthorizedException);

                throw new WalletDependencyException(unauthorizedWalletException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedWalletException =
                    new UnauthorizedWalletException(httpResponseForbiddenException);

                throw new WalletDependencyException(unauthorizedWalletException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundWalletException =
                    new NotFoundWalletException(httpResponseNotFoundException);

                throw new WalletDependencyValidationException(notFoundWalletException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidWalletException =
                    new InvalidWalletException(httpResponseBadRequestException);

                throw new WalletDependencyValidationException(invalidWalletException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallWalletException =
                    new ExcessiveCallWalletException(httpResponseTooManyRequestsException);

                throw new WalletDependencyValidationException(excessiveCallWalletException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerWalletException =
                    new FailedServerWalletException(httpResponseException);

                throw new WalletDependencyException(failedServerWalletException);
            }
            catch (Exception exception)
            {
                var failedWalletServiceException =
                    new FailedWalletServiceException(exception);

                throw new WalletServiceException(failedWalletServiceException);
            }
        }

        private async ValueTask<CreateWallet> TryCatch(ReturningCreateWalletFunction returningCreateWalletFunction)
        {
            try
            {
                return await returningCreateWalletFunction();
            }
            catch (NullWalletException nullWalletException)
            {
                throw new WalletValidationException(nullWalletException);
            }
            catch (InvalidWalletException invalidWalletException)
            {
                throw new WalletValidationException(invalidWalletException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationWalletException =
                    new InvalidConfigurationWalletException(httpResponseUrlNotFoundException);

                throw new WalletDependencyException(invalidConfigurationWalletException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedWalletException =
                    new UnauthorizedWalletException(httpResponseUnauthorizedException);

                throw new WalletDependencyException(unauthorizedWalletException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedWalletException =
                    new UnauthorizedWalletException(httpResponseForbiddenException);

                throw new WalletDependencyException(unauthorizedWalletException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundWalletException =
                    new NotFoundWalletException(httpResponseNotFoundException);

                throw new WalletDependencyValidationException(notFoundWalletException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidWalletException =
                    new InvalidWalletException(httpResponseBadRequestException);

                throw new WalletDependencyValidationException(invalidWalletException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallWalletException =
                    new ExcessiveCallWalletException(httpResponseTooManyRequestsException);

                throw new WalletDependencyValidationException(excessiveCallWalletException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerWalletException =
                    new FailedServerWalletException(httpResponseException);

                throw new WalletDependencyException(failedServerWalletException);
            }
            catch (Exception exception)
            {
                var failedWalletServiceException =
                    new FailedWalletServiceException(exception);

                throw new WalletServiceException(failedWalletServiceException);
            }
        }

        private async ValueTask<AllWallets> TryCatch(
            ReturningAllWalletsFunction returningAllWalletsFunction)
        {
            try
            {
                return await returningAllWalletsFunction();
            }
            catch (NullWalletException nullWalletException)
            {
                throw new WalletValidationException(nullWalletException);
            }
            catch (InvalidWalletException invalidWalletException)
            {
                throw new WalletValidationException(invalidWalletException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationWalletException =
                    new InvalidConfigurationWalletException(httpResponseUrlNotFoundException);

                throw new WalletDependencyException(invalidConfigurationWalletException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedWalletException =
                    new UnauthorizedWalletException(httpResponseUnauthorizedException);

                throw new WalletDependencyException(unauthorizedWalletException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedWalletException =
                    new UnauthorizedWalletException(httpResponseForbiddenException);

                throw new WalletDependencyException(unauthorizedWalletException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundWalletException =
                    new NotFoundWalletException(httpResponseNotFoundException);

                throw new WalletDependencyValidationException(notFoundWalletException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidWalletException =
                    new InvalidWalletException(httpResponseBadRequestException);

                throw new WalletDependencyValidationException(invalidWalletException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallWalletException =
                    new ExcessiveCallWalletException(httpResponseTooManyRequestsException);

                throw new WalletDependencyValidationException(excessiveCallWalletException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerWalletException =
                    new FailedServerWalletException(httpResponseException);

                throw new WalletDependencyException(failedServerWalletException);
            }
            catch (Exception exception)
            {
                var failedWalletServiceException =
                    new FailedWalletServiceException(exception);

                throw new WalletServiceException(failedWalletServiceException);
            }
        }

    }
}