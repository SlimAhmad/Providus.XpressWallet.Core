using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.User;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.User.Exceptions;
using RESTFulSense.Exceptions;

namespace Providus.XpressWallet.Core.Services.Foundations.XpressWallet.User
{
    internal partial class UserService
    {
        private delegate ValueTask<UserProfile> ReturningUserProfileFunction();

        private delegate ValueTask<ChangePassword> ReturningChangePasswordFunction();


        private async ValueTask<UserProfile> TryCatch(ReturningUserProfileFunction returningUserProfileFunction)
        {
            try
            {
                return await returningUserProfileFunction();
            }
            catch (NullUserException nullUserException)
            {
                throw new UserValidationException(nullUserException);
            }
            catch (InvalidUserException invalidUserException)
            {
                throw new UserValidationException(invalidUserException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationUserException =
                    new InvalidConfigurationUserException(httpResponseUrlNotFoundException);

                throw new UserDependencyException(invalidConfigurationUserException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedUserException =
                    new UnauthorizedUserException(httpResponseUnauthorizedException);

                throw new UserDependencyException(unauthorizedUserException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedUserException =
                    new UnauthorizedUserException(httpResponseForbiddenException);

                throw new UserDependencyException(unauthorizedUserException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundUserException =
                    new NotFoundUserException(httpResponseNotFoundException);

                throw new UserDependencyValidationException(notFoundUserException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidUserException =
                    new InvalidUserException(httpResponseBadRequestException);

                throw new UserDependencyValidationException(invalidUserException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallUserException =
                    new ExcessiveCallUserException(httpResponseTooManyRequestsException);

                throw new UserDependencyValidationException(excessiveCallUserException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerUserException =
                    new FailedServerUserException(httpResponseException);

                throw new UserDependencyException(failedServerUserException);
            }
            catch (Exception exception)
            {
                var failedUserServiceException =
                    new FailedUserServiceException(exception);

                throw new UserServiceException(failedUserServiceException);
            }
        }

        private async ValueTask<ChangePassword> TryCatch(
            ReturningChangePasswordFunction returningChangePasswordFunction)
        {
            try
            {
                return await returningChangePasswordFunction();
            }
            catch (NullUserException nullUserException)
            {
                throw new UserValidationException(nullUserException);
            }
            catch (InvalidUserException invalidUserException)
            {
                throw new UserValidationException(invalidUserException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationUserException =
                    new InvalidConfigurationUserException(httpResponseUrlNotFoundException);

                throw new UserDependencyException(invalidConfigurationUserException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedUserException =
                    new UnauthorizedUserException(httpResponseUnauthorizedException);

                throw new UserDependencyException(unauthorizedUserException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedUserException =
                    new UnauthorizedUserException(httpResponseForbiddenException);

                throw new UserDependencyException(unauthorizedUserException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundUserException =
                    new NotFoundUserException(httpResponseNotFoundException);

                throw new UserDependencyValidationException(notFoundUserException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidUserException =
                    new InvalidUserException(httpResponseBadRequestException);

                throw new UserDependencyValidationException(invalidUserException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallUserException =
                    new ExcessiveCallUserException(httpResponseTooManyRequestsException);

                throw new UserDependencyValidationException(excessiveCallUserException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerUserException =
                    new FailedServerUserException(httpResponseException);

                throw new UserDependencyException(failedServerUserException);
            }
            catch (Exception exception)
            {
                var failedUserServiceException =
                    new FailedUserServiceException(exception);

                throw new UserServiceException(failedUserServiceException);
            }
        }
    
    }
}