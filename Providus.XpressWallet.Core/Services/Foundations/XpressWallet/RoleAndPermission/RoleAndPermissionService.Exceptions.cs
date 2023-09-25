using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.RoleAndPermission;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.RoleAndPermission.Exceptions;
using RESTFulSense.Exceptions;

namespace Providus.XpressWallet.Core.Services.Foundations.XpressWallet.RoleAndPermission
{
    internal partial class RoleAndPermissionService
    {
        private delegate ValueTask<AllPermissions> ReturningAllPermissionsFunction();

        private delegate ValueTask<AllRoles> ReturningAllRolesFunction();

        private delegate ValueTask<CreateRole> ReturningCreateRoleFunction();

        private delegate ValueTask<UpdateRole> ReturningUpdateRoleFunction();

     

        private async ValueTask<UpdateRole> TryCatch(ReturningUpdateRoleFunction returningUpdateRoleFunction)
        {
            try
            {
                return await returningUpdateRoleFunction();
            }
            catch (NullRoleAndPermissionException nullRoleAndPermissionException)
            {
                throw new RoleAndPermissionValidationException(nullRoleAndPermissionException);
            }
            catch (InvalidRoleAndPermissionException invalidRoleAndPermissionException)
            {
                throw new RoleAndPermissionValidationException(invalidRoleAndPermissionException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationRoleAndPermissionException =
                    new InvalidConfigurationRoleAndPermissionException(httpResponseUrlNotFoundException);

                throw new RoleAndPermissionDependencyException(invalidConfigurationRoleAndPermissionException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedRoleAndPermissionException =
                    new UnauthorizedRoleAndPermissionException(httpResponseUnauthorizedException);

                throw new RoleAndPermissionDependencyException(unauthorizedRoleAndPermissionException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedRoleAndPermissionException =
                    new UnauthorizedRoleAndPermissionException(httpResponseForbiddenException);

                throw new RoleAndPermissionDependencyException(unauthorizedRoleAndPermissionException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundRoleAndPermissionException =
                    new NotFoundRoleAndPermissionException(httpResponseNotFoundException);

                throw new RoleAndPermissionDependencyValidationException(notFoundRoleAndPermissionException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidRoleAndPermissionException =
                    new InvalidRoleAndPermissionException(httpResponseBadRequestException);

                throw new RoleAndPermissionDependencyValidationException(invalidRoleAndPermissionException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallRoleAndPermissionException =
                    new ExcessiveCallRoleAndPermissionException(httpResponseTooManyRequestsException);

                throw new RoleAndPermissionDependencyValidationException(excessiveCallRoleAndPermissionException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerRoleAndPermissionException =
                    new FailedServerRoleAndPermissionException(httpResponseException);

                throw new RoleAndPermissionDependencyException(failedServerRoleAndPermissionException);
            }
            catch (Exception exception)
            {
                var failedRoleAndPermissionServiceException =
                    new FailedRoleAndPermissionServiceException(exception);

                throw new RoleAndPermissionServiceException(failedRoleAndPermissionServiceException);
            }
        }

        private async ValueTask<CreateRole> TryCatch(ReturningCreateRoleFunction returningCreateRoleFunction)
        {
            try
            {
                return await returningCreateRoleFunction();
            }
            catch (NullRoleAndPermissionException nullRoleAndPermissionException)
            {
                throw new RoleAndPermissionValidationException(nullRoleAndPermissionException);
            }
            catch (InvalidRoleAndPermissionException invalidRoleAndPermissionException)
            {
                throw new RoleAndPermissionValidationException(invalidRoleAndPermissionException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationRoleAndPermissionException =
                    new InvalidConfigurationRoleAndPermissionException(httpResponseUrlNotFoundException);

                throw new RoleAndPermissionDependencyException(invalidConfigurationRoleAndPermissionException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedRoleAndPermissionException =
                    new UnauthorizedRoleAndPermissionException(httpResponseUnauthorizedException);

                throw new RoleAndPermissionDependencyException(unauthorizedRoleAndPermissionException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedRoleAndPermissionException =
                    new UnauthorizedRoleAndPermissionException(httpResponseForbiddenException);

                throw new RoleAndPermissionDependencyException(unauthorizedRoleAndPermissionException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundRoleAndPermissionException =
                    new NotFoundRoleAndPermissionException(httpResponseNotFoundException);

                throw new RoleAndPermissionDependencyValidationException(notFoundRoleAndPermissionException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidRoleAndPermissionException =
                    new InvalidRoleAndPermissionException(httpResponseBadRequestException);

                throw new RoleAndPermissionDependencyValidationException(invalidRoleAndPermissionException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallRoleAndPermissionException =
                    new ExcessiveCallRoleAndPermissionException(httpResponseTooManyRequestsException);

                throw new RoleAndPermissionDependencyValidationException(excessiveCallRoleAndPermissionException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerRoleAndPermissionException =
                    new FailedServerRoleAndPermissionException(httpResponseException);

                throw new RoleAndPermissionDependencyException(failedServerRoleAndPermissionException);
            }
            catch (Exception exception)
            {
                var failedRoleAndPermissionServiceException =
                    new FailedRoleAndPermissionServiceException(exception);

                throw new RoleAndPermissionServiceException(failedRoleAndPermissionServiceException);
            }
        }

        private async ValueTask<AllPermissions> TryCatch(ReturningAllPermissionsFunction returningAllPermissionsFunction)
        {
            try
            {
                return await returningAllPermissionsFunction();
            }
            catch (NullRoleAndPermissionException nullRoleAndPermissionException)
            {
                throw new RoleAndPermissionValidationException(nullRoleAndPermissionException);
            }
            catch (InvalidRoleAndPermissionException invalidRoleAndPermissionException)
            {
                throw new RoleAndPermissionValidationException(invalidRoleAndPermissionException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationRoleAndPermissionException =
                    new InvalidConfigurationRoleAndPermissionException(httpResponseUrlNotFoundException);

                throw new RoleAndPermissionDependencyException(invalidConfigurationRoleAndPermissionException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedRoleAndPermissionException =
                    new UnauthorizedRoleAndPermissionException(httpResponseUnauthorizedException);

                throw new RoleAndPermissionDependencyException(unauthorizedRoleAndPermissionException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedRoleAndPermissionException =
                    new UnauthorizedRoleAndPermissionException(httpResponseForbiddenException);

                throw new RoleAndPermissionDependencyException(unauthorizedRoleAndPermissionException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundRoleAndPermissionException =
                    new NotFoundRoleAndPermissionException(httpResponseNotFoundException);

                throw new RoleAndPermissionDependencyValidationException(notFoundRoleAndPermissionException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidRoleAndPermissionException =
                    new InvalidRoleAndPermissionException(httpResponseBadRequestException);

                throw new RoleAndPermissionDependencyValidationException(invalidRoleAndPermissionException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallRoleAndPermissionException =
                    new ExcessiveCallRoleAndPermissionException(httpResponseTooManyRequestsException);

                throw new RoleAndPermissionDependencyValidationException(excessiveCallRoleAndPermissionException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerRoleAndPermissionException =
                    new FailedServerRoleAndPermissionException(httpResponseException);

                throw new RoleAndPermissionDependencyException(failedServerRoleAndPermissionException);
            }
            catch (Exception exception)
            {
                var failedRoleAndPermissionServiceException =
                    new FailedRoleAndPermissionServiceException(exception);

                throw new RoleAndPermissionServiceException(failedRoleAndPermissionServiceException);
            }
        }

        private async ValueTask<AllRoles> TryCatch(
            ReturningAllRolesFunction returningAllRolesFunction)
        {
            try
            {
                return await returningAllRolesFunction();
            }
            catch (NullRoleAndPermissionException nullRoleAndPermissionException)
            {
                throw new RoleAndPermissionValidationException(nullRoleAndPermissionException);
            }
            catch (InvalidRoleAndPermissionException invalidRoleAndPermissionException)
            {
                throw new RoleAndPermissionValidationException(invalidRoleAndPermissionException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationRoleAndPermissionException =
                    new InvalidConfigurationRoleAndPermissionException(httpResponseUrlNotFoundException);

                throw new RoleAndPermissionDependencyException(invalidConfigurationRoleAndPermissionException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedRoleAndPermissionException =
                    new UnauthorizedRoleAndPermissionException(httpResponseUnauthorizedException);

                throw new RoleAndPermissionDependencyException(unauthorizedRoleAndPermissionException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedRoleAndPermissionException =
                    new UnauthorizedRoleAndPermissionException(httpResponseForbiddenException);

                throw new RoleAndPermissionDependencyException(unauthorizedRoleAndPermissionException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundRoleAndPermissionException =
                    new NotFoundRoleAndPermissionException(httpResponseNotFoundException);

                throw new RoleAndPermissionDependencyValidationException(notFoundRoleAndPermissionException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidRoleAndPermissionException =
                    new InvalidRoleAndPermissionException(httpResponseBadRequestException);

                throw new RoleAndPermissionDependencyValidationException(invalidRoleAndPermissionException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallRoleAndPermissionException =
                    new ExcessiveCallRoleAndPermissionException(httpResponseTooManyRequestsException);

                throw new RoleAndPermissionDependencyValidationException(excessiveCallRoleAndPermissionException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerRoleAndPermissionException =
                    new FailedServerRoleAndPermissionException(httpResponseException);

                throw new RoleAndPermissionDependencyException(failedServerRoleAndPermissionException);
            }
            catch (Exception exception)
            {
                var failedRoleAndPermissionServiceException =
                    new FailedRoleAndPermissionServiceException(exception);

                throw new RoleAndPermissionServiceException(failedRoleAndPermissionServiceException);
            }
        }

    }
}