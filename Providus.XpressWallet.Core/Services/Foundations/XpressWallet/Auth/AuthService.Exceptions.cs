using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Auth;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Auth.Exceptions;
using RESTFulSense.Exceptions;

namespace Providus.XpressWallet.Core.Services.Foundations.XpressWallet.Auth 
{ 

    internal partial class AuthService
    {
        private delegate ValueTask<Login> ReturningLoginFunction();

        private delegate ValueTask<ForgetPassword> ReturningForgetPasswordFunction();

        private delegate ValueTask<Logout> ReturningLogoutFunction();

        private delegate ValueTask<RefreshTokens> ReturningRefreshTokensFunction();

        private delegate ValueTask<ResetPassword> ReturningResetPasswordFunction();

        private async ValueTask<Logout> TryCatch(ReturningLogoutFunction returningLogoutFunction)
        {
            try
            {
                return await returningLogoutFunction();
            }
            catch (NullAuthException nullAuthException)
            {
                throw new AuthValidationException(nullAuthException);
            }
            catch (InvalidAuthException invalidAuthException)
            {
                throw new AuthValidationException(invalidAuthException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationAuthException =
                    new InvalidConfigurationAuthException(httpResponseUrlNotFoundException);

                throw new AuthDependencyException(invalidConfigurationAuthException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedAuthException =
                    new UnauthorizedAuthException(httpResponseUnauthorizedException);

                throw new AuthDependencyException(unauthorizedAuthException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedAuthException =
                    new UnauthorizedAuthException(httpResponseForbiddenException);

                throw new AuthDependencyException(unauthorizedAuthException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundAuthException =
                    new NotFoundAuthException(httpResponseNotFoundException);

                throw new AuthDependencyValidationException(notFoundAuthException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidAuthException =
                    new InvalidAuthException(httpResponseBadRequestException);

                throw new AuthDependencyValidationException(invalidAuthException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallAuthException =
                    new ExcessiveCallAuthException(httpResponseTooManyRequestsException);

                throw new AuthDependencyValidationException(excessiveCallAuthException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerAuthException =
                    new FailedServerAuthException(httpResponseException);

                throw new AuthDependencyException(failedServerAuthException);
            }
            catch (Exception exception)
            {
                var failedAuthServiceException =
                    new FailedAuthServiceException(exception);

                throw new AuthServiceException(failedAuthServiceException);
            }
        }
  
        private async ValueTask<RefreshTokens> TryCatch(ReturningRefreshTokensFunction returningRefreshTokensFunction)
        {
            try
            {
                return await returningRefreshTokensFunction();
            }
            catch (NullAuthException nullAuthException)
            {
                throw new AuthValidationException(nullAuthException);
            }
            catch (InvalidAuthException invalidAuthException)
            {
                throw new AuthValidationException(invalidAuthException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationAuthException =
                    new InvalidConfigurationAuthException(httpResponseUrlNotFoundException);

                throw new AuthDependencyException(invalidConfigurationAuthException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedAuthException =
                    new UnauthorizedAuthException(httpResponseUnauthorizedException);

                throw new AuthDependencyException(unauthorizedAuthException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedAuthException =
                    new UnauthorizedAuthException(httpResponseForbiddenException);

                throw new AuthDependencyException(unauthorizedAuthException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundAuthException =
                    new NotFoundAuthException(httpResponseNotFoundException);

                throw new AuthDependencyValidationException(notFoundAuthException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidAuthException =
                    new InvalidAuthException(httpResponseBadRequestException);

                throw new AuthDependencyValidationException(invalidAuthException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallAuthException =
                    new ExcessiveCallAuthException(httpResponseTooManyRequestsException);

                throw new AuthDependencyValidationException(excessiveCallAuthException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerAuthException =
                    new FailedServerAuthException(httpResponseException);

                throw new AuthDependencyException(failedServerAuthException);
            }
            catch (Exception exception)
            {
                var failedAuthServiceException =
                    new FailedAuthServiceException(exception);

                throw new AuthServiceException(failedAuthServiceException);
            }
        }

        private async ValueTask<Login> TryCatch(ReturningLoginFunction returningLoginFunction)
        {
            try
            {
                return await returningLoginFunction();
            }
            catch (NullAuthException nullAuthException)
            {
                throw new AuthValidationException(nullAuthException);
            }
            catch (InvalidAuthException invalidAuthException)
            {
                throw new AuthValidationException(invalidAuthException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationAuthException =
                    new InvalidConfigurationAuthException(httpResponseUrlNotFoundException);

                throw new AuthDependencyException(invalidConfigurationAuthException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedAuthException =
                    new UnauthorizedAuthException(httpResponseUnauthorizedException);

                throw new AuthDependencyException(unauthorizedAuthException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedAuthException =
                    new UnauthorizedAuthException(httpResponseForbiddenException);

                throw new AuthDependencyException(unauthorizedAuthException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundAuthException =
                    new NotFoundAuthException(httpResponseNotFoundException);

                throw new AuthDependencyValidationException(notFoundAuthException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidAuthException =
                    new InvalidAuthException(httpResponseBadRequestException);

                throw new AuthDependencyValidationException(invalidAuthException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallAuthException =
                    new ExcessiveCallAuthException(httpResponseTooManyRequestsException);

                throw new AuthDependencyValidationException(excessiveCallAuthException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerAuthException =
                    new FailedServerAuthException(httpResponseException);

                throw new AuthDependencyException(failedServerAuthException);
            }
            catch (Exception exception)
            {
                var failedAuthServiceException =
                    new FailedAuthServiceException(exception);

                throw new AuthServiceException(failedAuthServiceException);
            }
        }

        private async ValueTask<ForgetPassword> TryCatch(
            ReturningForgetPasswordFunction returningForgetPasswordFunction)
        {
            try
            {
                return await returningForgetPasswordFunction();
            }
            catch (NullAuthException nullAuthException)
            {
                throw new AuthValidationException(nullAuthException);
            }
            catch (InvalidAuthException invalidAuthException)
            {
                throw new AuthValidationException(invalidAuthException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationAuthException =
                    new InvalidConfigurationAuthException(httpResponseUrlNotFoundException);

                throw new AuthDependencyException(invalidConfigurationAuthException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedAuthException =
                    new UnauthorizedAuthException(httpResponseUnauthorizedException);

                throw new AuthDependencyException(unauthorizedAuthException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedAuthException =
                    new UnauthorizedAuthException(httpResponseForbiddenException);

                throw new AuthDependencyException(unauthorizedAuthException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundAuthException =
                    new NotFoundAuthException(httpResponseNotFoundException);

                throw new AuthDependencyValidationException(notFoundAuthException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidAuthException =
                    new InvalidAuthException(httpResponseBadRequestException);

                throw new AuthDependencyValidationException(invalidAuthException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallAuthException =
                    new ExcessiveCallAuthException(httpResponseTooManyRequestsException);

                throw new AuthDependencyValidationException(excessiveCallAuthException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerAuthException =
                    new FailedServerAuthException(httpResponseException);

                throw new AuthDependencyException(failedServerAuthException);
            }
            catch (Exception exception)
            {
                var failedAuthServiceException =
                    new FailedAuthServiceException(exception);

                throw new AuthServiceException(failedAuthServiceException);
            }
        }

        private async ValueTask<ResetPassword> TryCatch(
            ReturningResetPasswordFunction returningResetPasswordFunction)
        {
            try
            {
                return await returningResetPasswordFunction();
            }
            catch (NullAuthException nullAuthException)
            {
                throw new AuthValidationException(nullAuthException);
            }
            catch (InvalidAuthException invalidAuthException)
            {
                throw new AuthValidationException(invalidAuthException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationAuthException =
                    new InvalidConfigurationAuthException(httpResponseUrlNotFoundException);

                throw new AuthDependencyException(invalidConfigurationAuthException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedAuthException =
                    new UnauthorizedAuthException(httpResponseUnauthorizedException);

                throw new AuthDependencyException(unauthorizedAuthException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedAuthException =
                    new UnauthorizedAuthException(httpResponseForbiddenException);

                throw new AuthDependencyException(unauthorizedAuthException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundAuthException =
                    new NotFoundAuthException(httpResponseNotFoundException);

                throw new AuthDependencyValidationException(notFoundAuthException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidAuthException =
                    new InvalidAuthException(httpResponseBadRequestException);

                throw new AuthDependencyValidationException(invalidAuthException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallAuthException =
                    new ExcessiveCallAuthException(httpResponseTooManyRequestsException);

                throw new AuthDependencyValidationException(excessiveCallAuthException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerAuthException =
                    new FailedServerAuthException(httpResponseException);

                throw new AuthDependencyException(failedServerAuthException);
            }
            catch (Exception exception)
            {
                var failedAuthServiceException =
                    new FailedAuthServiceException(exception);

                throw new AuthServiceException(failedAuthServiceException);
            }
        }

    }
}