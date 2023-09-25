using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Merchant;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Merchant.Exceptions;
using RESTFulSense.Exceptions;

namespace Providus.XpressWallet.Core.Services.Foundations.XpressWallet.Merchant
{
    internal partial class MerchantService
    {
        private delegate ValueTask<AccountVerification> ReturningAccountVerificationFunction();

        private delegate ValueTask<ResendVerification> ReturningResendVerificationFunction();

        private delegate ValueTask<MerchantKYC> ReturningMerchantKYCFunction();

        private delegate ValueTask<UpdateMerchantProfile> ReturningUpdateMerchantProfileFunction();

        private delegate ValueTask<MerchantProfile> ReturningMerchantProfileFunction();

        private delegate ValueTask<MerchantAccessKeys> ReturningMerchantAccessKeysFunction();

        private delegate ValueTask<GenerateAccessKeys> ReturningGenerateAccessKeysFunction();

        private delegate ValueTask<SwitchAccountMode> ReturningSwitchAccountModeFunction();

        private delegate ValueTask<MerchantRegistration> ReturningMerchantRegistrationFunction();

        private delegate ValueTask<MerchantWallet> ReturningMerchantWalletFunction();




        private async ValueTask<MerchantWallet> TryCatch(ReturningMerchantWalletFunction returningMerchantWalletFunction)
        {
            try
            {
                return await returningMerchantWalletFunction();
            }
            catch (NullMerchantException nullMerchantException)
            {
                throw new MerchantValidationException(nullMerchantException);
            }
            catch (InvalidMerchantException invalidMerchantException)
            {
                throw new MerchantValidationException(invalidMerchantException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationMerchantException =
                    new InvalidConfigurationMerchantException(httpResponseUrlNotFoundException);

                throw new MerchantDependencyException(invalidConfigurationMerchantException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedMerchantException =
                    new UnauthorizedMerchantException(httpResponseUnauthorizedException);

                throw new MerchantDependencyException(unauthorizedMerchantException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedMerchantException =
                    new UnauthorizedMerchantException(httpResponseForbiddenException);

                throw new MerchantDependencyException(unauthorizedMerchantException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundMerchantException =
                    new NotFoundMerchantException(httpResponseNotFoundException);

                throw new MerchantDependencyValidationException(notFoundMerchantException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidMerchantException =
                    new InvalidMerchantException(httpResponseBadRequestException);

                throw new MerchantDependencyValidationException(invalidMerchantException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallMerchantException =
                    new ExcessiveCallMerchantException(httpResponseTooManyRequestsException);

                throw new MerchantDependencyValidationException(excessiveCallMerchantException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerMerchantException =
                    new FailedServerMerchantException(httpResponseException);

                throw new MerchantDependencyException(failedServerMerchantException);
            }
            catch (Exception exception)
            {
                var failedMerchantServiceException =
                    new FailedMerchantServiceException(exception);

                throw new MerchantServiceException(failedMerchantServiceException);
            }
        }

        private async ValueTask<MerchantRegistration> TryCatch(ReturningMerchantRegistrationFunction returningMerchantRegistrationFunction)
        {
            try
            {
                return await returningMerchantRegistrationFunction();
            }
            catch (NullMerchantException nullMerchantException)
            {
                throw new MerchantValidationException(nullMerchantException);
            }
            catch (InvalidMerchantException invalidMerchantException)
            {
                throw new MerchantValidationException(invalidMerchantException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationMerchantException =
                    new InvalidConfigurationMerchantException(httpResponseUrlNotFoundException);

                throw new MerchantDependencyException(invalidConfigurationMerchantException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedMerchantException =
                    new UnauthorizedMerchantException(httpResponseUnauthorizedException);

                throw new MerchantDependencyException(unauthorizedMerchantException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedMerchantException =
                    new UnauthorizedMerchantException(httpResponseForbiddenException);

                throw new MerchantDependencyException(unauthorizedMerchantException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundMerchantException =
                    new NotFoundMerchantException(httpResponseNotFoundException);

                throw new MerchantDependencyValidationException(notFoundMerchantException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidMerchantException =
                    new InvalidMerchantException(httpResponseBadRequestException);

                throw new MerchantDependencyValidationException(invalidMerchantException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallMerchantException =
                    new ExcessiveCallMerchantException(httpResponseTooManyRequestsException);

                throw new MerchantDependencyValidationException(excessiveCallMerchantException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerMerchantException =
                    new FailedServerMerchantException(httpResponseException);

                throw new MerchantDependencyException(failedServerMerchantException);
            }
            catch (Exception exception)
            {
                var failedMerchantServiceException =
                    new FailedMerchantServiceException(exception);

                throw new MerchantServiceException(failedMerchantServiceException);
            }
        }

        private async ValueTask<SwitchAccountMode> TryCatch(ReturningSwitchAccountModeFunction returningSwitchAccountModeFunction)
        {
            try
            {
                return await returningSwitchAccountModeFunction();
            }
            catch (NullMerchantException nullMerchantException)
            {
                throw new MerchantValidationException(nullMerchantException);
            }
            catch (InvalidMerchantException invalidMerchantException)
            {
                throw new MerchantValidationException(invalidMerchantException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationMerchantException =
                    new InvalidConfigurationMerchantException(httpResponseUrlNotFoundException);

                throw new MerchantDependencyException(invalidConfigurationMerchantException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedMerchantException =
                    new UnauthorizedMerchantException(httpResponseUnauthorizedException);

                throw new MerchantDependencyException(unauthorizedMerchantException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedMerchantException =
                    new UnauthorizedMerchantException(httpResponseForbiddenException);

                throw new MerchantDependencyException(unauthorizedMerchantException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundMerchantException =
                    new NotFoundMerchantException(httpResponseNotFoundException);

                throw new MerchantDependencyValidationException(notFoundMerchantException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidMerchantException =
                    new InvalidMerchantException(httpResponseBadRequestException);

                throw new MerchantDependencyValidationException(invalidMerchantException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallMerchantException =
                    new ExcessiveCallMerchantException(httpResponseTooManyRequestsException);

                throw new MerchantDependencyValidationException(excessiveCallMerchantException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerMerchantException =
                    new FailedServerMerchantException(httpResponseException);

                throw new MerchantDependencyException(failedServerMerchantException);
            }
            catch (Exception exception)
            {
                var failedMerchantServiceException =
                    new FailedMerchantServiceException(exception);

                throw new MerchantServiceException(failedMerchantServiceException);
            }
        }

        private async ValueTask<GenerateAccessKeys> TryCatch(ReturningGenerateAccessKeysFunction returningGenerateAccessKeysFunction)
        {
            try
            {
                return await returningGenerateAccessKeysFunction();
            }
            catch (NullMerchantException nullMerchantException)
            {
                throw new MerchantValidationException(nullMerchantException);
            }
            catch (InvalidMerchantException invalidMerchantException)
            {
                throw new MerchantValidationException(invalidMerchantException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationMerchantException =
                    new InvalidConfigurationMerchantException(httpResponseUrlNotFoundException);

                throw new MerchantDependencyException(invalidConfigurationMerchantException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedMerchantException =
                    new UnauthorizedMerchantException(httpResponseUnauthorizedException);

                throw new MerchantDependencyException(unauthorizedMerchantException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedMerchantException =
                    new UnauthorizedMerchantException(httpResponseForbiddenException);

                throw new MerchantDependencyException(unauthorizedMerchantException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundMerchantException =
                    new NotFoundMerchantException(httpResponseNotFoundException);

                throw new MerchantDependencyValidationException(notFoundMerchantException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidMerchantException =
                    new InvalidMerchantException(httpResponseBadRequestException);

                throw new MerchantDependencyValidationException(invalidMerchantException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallMerchantException =
                    new ExcessiveCallMerchantException(httpResponseTooManyRequestsException);

                throw new MerchantDependencyValidationException(excessiveCallMerchantException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerMerchantException =
                    new FailedServerMerchantException(httpResponseException);

                throw new MerchantDependencyException(failedServerMerchantException);
            }
            catch (Exception exception)
            {
                var failedMerchantServiceException =
                    new FailedMerchantServiceException(exception);

                throw new MerchantServiceException(failedMerchantServiceException);
            }
        }

        private async ValueTask<MerchantAccessKeys> TryCatch(ReturningMerchantAccessKeysFunction returningMerchantAccessKeysFunction)
        {
            try
            {
                return await returningMerchantAccessKeysFunction();
            }
            catch (NullMerchantException nullMerchantException)
            {
                throw new MerchantValidationException(nullMerchantException);
            }
            catch (InvalidMerchantException invalidMerchantException)
            {
                throw new MerchantValidationException(invalidMerchantException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationMerchantException =
                    new InvalidConfigurationMerchantException(httpResponseUrlNotFoundException);

                throw new MerchantDependencyException(invalidConfigurationMerchantException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedMerchantException =
                    new UnauthorizedMerchantException(httpResponseUnauthorizedException);

                throw new MerchantDependencyException(unauthorizedMerchantException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedMerchantException =
                    new UnauthorizedMerchantException(httpResponseForbiddenException);

                throw new MerchantDependencyException(unauthorizedMerchantException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundMerchantException =
                    new NotFoundMerchantException(httpResponseNotFoundException);

                throw new MerchantDependencyValidationException(notFoundMerchantException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidMerchantException =
                    new InvalidMerchantException(httpResponseBadRequestException);

                throw new MerchantDependencyValidationException(invalidMerchantException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallMerchantException =
                    new ExcessiveCallMerchantException(httpResponseTooManyRequestsException);

                throw new MerchantDependencyValidationException(excessiveCallMerchantException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerMerchantException =
                    new FailedServerMerchantException(httpResponseException);

                throw new MerchantDependencyException(failedServerMerchantException);
            }
            catch (Exception exception)
            {
                var failedMerchantServiceException =
                    new FailedMerchantServiceException(exception);

                throw new MerchantServiceException(failedMerchantServiceException);
            }
        }

        private async ValueTask<MerchantProfile> TryCatch(ReturningMerchantProfileFunction returningMerchantProfileFunction)
        {
            try
            {
                return await returningMerchantProfileFunction();
            }
            catch (NullMerchantException nullMerchantException)
            {
                throw new MerchantValidationException(nullMerchantException);
            }
            catch (InvalidMerchantException invalidMerchantException)
            {
                throw new MerchantValidationException(invalidMerchantException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationMerchantException =
                    new InvalidConfigurationMerchantException(httpResponseUrlNotFoundException);

                throw new MerchantDependencyException(invalidConfigurationMerchantException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedMerchantException =
                    new UnauthorizedMerchantException(httpResponseUnauthorizedException);

                throw new MerchantDependencyException(unauthorizedMerchantException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedMerchantException =
                    new UnauthorizedMerchantException(httpResponseForbiddenException);

                throw new MerchantDependencyException(unauthorizedMerchantException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundMerchantException =
                    new NotFoundMerchantException(httpResponseNotFoundException);

                throw new MerchantDependencyValidationException(notFoundMerchantException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidMerchantException =
                    new InvalidMerchantException(httpResponseBadRequestException);

                throw new MerchantDependencyValidationException(invalidMerchantException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallMerchantException =
                    new ExcessiveCallMerchantException(httpResponseTooManyRequestsException);

                throw new MerchantDependencyValidationException(excessiveCallMerchantException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerMerchantException =
                    new FailedServerMerchantException(httpResponseException);

                throw new MerchantDependencyException(failedServerMerchantException);
            }
            catch (Exception exception)
            {
                var failedMerchantServiceException =
                    new FailedMerchantServiceException(exception);

                throw new MerchantServiceException(failedMerchantServiceException);
            }
        }
        private async ValueTask<MerchantKYC> TryCatch(ReturningMerchantKYCFunction returningMerchantKYCFunction)
        {
            try
            {
                return await returningMerchantKYCFunction();
            }
            catch (NullMerchantException nullMerchantException)
            {
                throw new MerchantValidationException(nullMerchantException);
            }
            catch (InvalidMerchantException invalidMerchantException)
            {
                throw new MerchantValidationException(invalidMerchantException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationMerchantException =
                    new InvalidConfigurationMerchantException(httpResponseUrlNotFoundException);

                throw new MerchantDependencyException(invalidConfigurationMerchantException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedMerchantException =
                    new UnauthorizedMerchantException(httpResponseUnauthorizedException);

                throw new MerchantDependencyException(unauthorizedMerchantException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedMerchantException =
                    new UnauthorizedMerchantException(httpResponseForbiddenException);

                throw new MerchantDependencyException(unauthorizedMerchantException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundMerchantException =
                    new NotFoundMerchantException(httpResponseNotFoundException);

                throw new MerchantDependencyValidationException(notFoundMerchantException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidMerchantException =
                    new InvalidMerchantException(httpResponseBadRequestException);

                throw new MerchantDependencyValidationException(invalidMerchantException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallMerchantException =
                    new ExcessiveCallMerchantException(httpResponseTooManyRequestsException);

                throw new MerchantDependencyValidationException(excessiveCallMerchantException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerMerchantException =
                    new FailedServerMerchantException(httpResponseException);

                throw new MerchantDependencyException(failedServerMerchantException);
            }
            catch (Exception exception)
            {
                var failedMerchantServiceException =
                    new FailedMerchantServiceException(exception);

                throw new MerchantServiceException(failedMerchantServiceException);
            }
        }

        private async ValueTask<UpdateMerchantProfile> TryCatch(ReturningUpdateMerchantProfileFunction returningUpdateMerchantProfileFunction)
        {
            try
            {
                return await returningUpdateMerchantProfileFunction();
            }
            catch (NullMerchantException nullMerchantException)
            {
                throw new MerchantValidationException(nullMerchantException);
            }
            catch (InvalidMerchantException invalidMerchantException)
            {
                throw new MerchantValidationException(invalidMerchantException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationMerchantException =
                    new InvalidConfigurationMerchantException(httpResponseUrlNotFoundException);

                throw new MerchantDependencyException(invalidConfigurationMerchantException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedMerchantException =
                    new UnauthorizedMerchantException(httpResponseUnauthorizedException);

                throw new MerchantDependencyException(unauthorizedMerchantException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedMerchantException =
                    new UnauthorizedMerchantException(httpResponseForbiddenException);

                throw new MerchantDependencyException(unauthorizedMerchantException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundMerchantException =
                    new NotFoundMerchantException(httpResponseNotFoundException);

                throw new MerchantDependencyValidationException(notFoundMerchantException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidMerchantException =
                    new InvalidMerchantException(httpResponseBadRequestException);

                throw new MerchantDependencyValidationException(invalidMerchantException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallMerchantException =
                    new ExcessiveCallMerchantException(httpResponseTooManyRequestsException);

                throw new MerchantDependencyValidationException(excessiveCallMerchantException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerMerchantException =
                    new FailedServerMerchantException(httpResponseException);

                throw new MerchantDependencyException(failedServerMerchantException);
            }
            catch (Exception exception)
            {
                var failedMerchantServiceException =
                    new FailedMerchantServiceException(exception);

                throw new MerchantServiceException(failedMerchantServiceException);
            }
        }

        private async ValueTask<AccountVerification> TryCatch(ReturningAccountVerificationFunction returningAccountVerificationFunction)
        {
            try
            {
                return await returningAccountVerificationFunction();
            }
            catch (NullMerchantException nullMerchantException)
            {
                throw new MerchantValidationException(nullMerchantException);
            }
            catch (InvalidMerchantException invalidMerchantException)
            {
                throw new MerchantValidationException(invalidMerchantException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationMerchantException =
                    new InvalidConfigurationMerchantException(httpResponseUrlNotFoundException);

                throw new MerchantDependencyException(invalidConfigurationMerchantException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedMerchantException =
                    new UnauthorizedMerchantException(httpResponseUnauthorizedException);

                throw new MerchantDependencyException(unauthorizedMerchantException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedMerchantException =
                    new UnauthorizedMerchantException(httpResponseForbiddenException);

                throw new MerchantDependencyException(unauthorizedMerchantException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundMerchantException =
                    new NotFoundMerchantException(httpResponseNotFoundException);

                throw new MerchantDependencyValidationException(notFoundMerchantException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidMerchantException =
                    new InvalidMerchantException(httpResponseBadRequestException);

                throw new MerchantDependencyValidationException(invalidMerchantException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallMerchantException =
                    new ExcessiveCallMerchantException(httpResponseTooManyRequestsException);

                throw new MerchantDependencyValidationException(excessiveCallMerchantException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerMerchantException =
                    new FailedServerMerchantException(httpResponseException);

                throw new MerchantDependencyException(failedServerMerchantException);
            }
            catch (Exception exception)
            {
                var failedMerchantServiceException =
                    new FailedMerchantServiceException(exception);

                throw new MerchantServiceException(failedMerchantServiceException);
            }
        }

        private async ValueTask<ResendVerification> TryCatch(
            ReturningResendVerificationFunction returningResendVerificationFunction)
        {
            try
            {
                return await returningResendVerificationFunction();
            }
            catch (NullMerchantException nullMerchantException)
            {
                throw new MerchantValidationException(nullMerchantException);
            }
            catch (InvalidMerchantException invalidMerchantException)
            {
                throw new MerchantValidationException(invalidMerchantException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationMerchantException =
                    new InvalidConfigurationMerchantException(httpResponseUrlNotFoundException);

                throw new MerchantDependencyException(invalidConfigurationMerchantException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedMerchantException =
                    new UnauthorizedMerchantException(httpResponseUnauthorizedException);

                throw new MerchantDependencyException(unauthorizedMerchantException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedMerchantException =
                    new UnauthorizedMerchantException(httpResponseForbiddenException);

                throw new MerchantDependencyException(unauthorizedMerchantException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundMerchantException =
                    new NotFoundMerchantException(httpResponseNotFoundException);

                throw new MerchantDependencyValidationException(notFoundMerchantException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidMerchantException =
                    new InvalidMerchantException(httpResponseBadRequestException);

                throw new MerchantDependencyValidationException(invalidMerchantException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallMerchantException =
                    new ExcessiveCallMerchantException(httpResponseTooManyRequestsException);

                throw new MerchantDependencyValidationException(excessiveCallMerchantException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerMerchantException =
                    new FailedServerMerchantException(httpResponseException);

                throw new MerchantDependencyException(failedServerMerchantException);
            }
            catch (Exception exception)
            {
                var failedMerchantServiceException =
                    new FailedMerchantServiceException(exception);

                throw new MerchantServiceException(failedMerchantServiceException);
            }
        }

    }
}