using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Customers;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Customers.Exceptions;
using RESTFulSense.Exceptions;

namespace Providus.XpressWallet.Core.Services.Foundations.XpressWallet.Customers
{
    internal partial class CustomersService
    {
        private delegate ValueTask<AllCustomers> ReturningAllCustomersFunction();

        private delegate ValueTask<CustomerDetails> ReturningCustomerDetailsFunction();

        private delegate ValueTask<FindByPhoneNumber> ReturningFindByPhoneNumberFunction();

        private delegate ValueTask<UpdateCustomerProfile> ReturningUpdateCustomerProfileFunction();



        private async ValueTask<FindByPhoneNumber> TryCatch(ReturningFindByPhoneNumberFunction returningFindByPhoneNumberFunction)
        {
            try
            {
                return await returningFindByPhoneNumberFunction();
            }
            catch (NullCustomersException nullCustomersException)
            {
                throw new CustomersValidationException(nullCustomersException);
            }
            catch (InvalidCustomersException invalidCustomersException)
            {
                throw new CustomersValidationException(invalidCustomersException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationCustomersException =
                    new InvalidConfigurationCustomersException(httpResponseUrlNotFoundException);

                throw new CustomersDependencyException(invalidConfigurationCustomersException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedCustomersException =
                    new UnauthorizedCustomersException(httpResponseUnauthorizedException);

                throw new CustomersDependencyException(unauthorizedCustomersException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedCustomersException =
                    new UnauthorizedCustomersException(httpResponseForbiddenException);

                throw new CustomersDependencyException(unauthorizedCustomersException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundCustomersException =
                    new NotFoundCustomersException(httpResponseNotFoundException);

                throw new CustomersDependencyValidationException(notFoundCustomersException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidCustomersException =
                    new InvalidCustomersException(httpResponseBadRequestException);

                throw new CustomersDependencyValidationException(invalidCustomersException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallCustomersException =
                    new ExcessiveCallCustomersException(httpResponseTooManyRequestsException);

                throw new CustomersDependencyValidationException(excessiveCallCustomersException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerCustomersException =
                    new FailedServerCustomersException(httpResponseException);

                throw new CustomersDependencyException(failedServerCustomersException);
            }
            catch (Exception exception)
            {
                var failedCustomersServiceException =
                    new FailedCustomersServiceException(exception);

                throw new CustomersServiceException(failedCustomersServiceException);
            }
        }

        private async ValueTask<UpdateCustomerProfile> TryCatch(ReturningUpdateCustomerProfileFunction returningUpdateCustomerProfileFunction)
        {
            try
            {
                return await returningUpdateCustomerProfileFunction();
            }
            catch (NullCustomersException nullCustomersException)
            {
                throw new CustomersValidationException(nullCustomersException);
            }
            catch (InvalidCustomersException invalidCustomersException)
            {
                throw new CustomersValidationException(invalidCustomersException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationCustomersException =
                    new InvalidConfigurationCustomersException(httpResponseUrlNotFoundException);

                throw new CustomersDependencyException(invalidConfigurationCustomersException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedCustomersException =
                    new UnauthorizedCustomersException(httpResponseUnauthorizedException);

                throw new CustomersDependencyException(unauthorizedCustomersException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedCustomersException =
                    new UnauthorizedCustomersException(httpResponseForbiddenException);

                throw new CustomersDependencyException(unauthorizedCustomersException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundCustomersException =
                    new NotFoundCustomersException(httpResponseNotFoundException);

                throw new CustomersDependencyValidationException(notFoundCustomersException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidCustomersException =
                    new InvalidCustomersException(httpResponseBadRequestException);

                throw new CustomersDependencyValidationException(invalidCustomersException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallCustomersException =
                    new ExcessiveCallCustomersException(httpResponseTooManyRequestsException);

                throw new CustomersDependencyValidationException(excessiveCallCustomersException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerCustomersException =
                    new FailedServerCustomersException(httpResponseException);

                throw new CustomersDependencyException(failedServerCustomersException);
            }
            catch (Exception exception)
            {
                var failedCustomersServiceException =
                    new FailedCustomersServiceException(exception);

                throw new CustomersServiceException(failedCustomersServiceException);
            }
        }

        private async ValueTask<AllCustomers> TryCatch(ReturningAllCustomersFunction returningAllCustomersFunction)
        {
            try
            {
                return await returningAllCustomersFunction();
            }
            catch (NullCustomersException nullCustomersException)
            {
                throw new CustomersValidationException(nullCustomersException);
            }
            catch (InvalidCustomersException invalidCustomersException)
            {
                throw new CustomersValidationException(invalidCustomersException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationCustomersException =
                    new InvalidConfigurationCustomersException(httpResponseUrlNotFoundException);

                throw new CustomersDependencyException(invalidConfigurationCustomersException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedCustomersException =
                    new UnauthorizedCustomersException(httpResponseUnauthorizedException);

                throw new CustomersDependencyException(unauthorizedCustomersException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedCustomersException =
                    new UnauthorizedCustomersException(httpResponseForbiddenException);

                throw new CustomersDependencyException(unauthorizedCustomersException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundCustomersException =
                    new NotFoundCustomersException(httpResponseNotFoundException);

                throw new CustomersDependencyValidationException(notFoundCustomersException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidCustomersException =
                    new InvalidCustomersException(httpResponseBadRequestException);

                throw new CustomersDependencyValidationException(invalidCustomersException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallCustomersException =
                    new ExcessiveCallCustomersException(httpResponseTooManyRequestsException);

                throw new CustomersDependencyValidationException(excessiveCallCustomersException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerCustomersException =
                    new FailedServerCustomersException(httpResponseException);

                throw new CustomersDependencyException(failedServerCustomersException);
            }
            catch (Exception exception)
            {
                var failedCustomersServiceException =
                    new FailedCustomersServiceException(exception);

                throw new CustomersServiceException(failedCustomersServiceException);
            }
        }

        private async ValueTask<CustomerDetails> TryCatch(
            ReturningCustomerDetailsFunction returningCustomerDetailsFunction)
        {
            try
            {
                return await returningCustomerDetailsFunction();
            }
            catch (NullCustomersException nullCustomersException)
            {
                throw new CustomersValidationException(nullCustomersException);
            }
            catch (InvalidCustomersException invalidCustomersException)
            {
                throw new CustomersValidationException(invalidCustomersException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationCustomersException =
                    new InvalidConfigurationCustomersException(httpResponseUrlNotFoundException);

                throw new CustomersDependencyException(invalidConfigurationCustomersException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedCustomersException =
                    new UnauthorizedCustomersException(httpResponseUnauthorizedException);

                throw new CustomersDependencyException(unauthorizedCustomersException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedCustomersException =
                    new UnauthorizedCustomersException(httpResponseForbiddenException);

                throw new CustomersDependencyException(unauthorizedCustomersException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundCustomersException =
                    new NotFoundCustomersException(httpResponseNotFoundException);

                throw new CustomersDependencyValidationException(notFoundCustomersException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidCustomersException =
                    new InvalidCustomersException(httpResponseBadRequestException);

                throw new CustomersDependencyValidationException(invalidCustomersException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallCustomersException =
                    new ExcessiveCallCustomersException(httpResponseTooManyRequestsException);

                throw new CustomersDependencyValidationException(excessiveCallCustomersException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerCustomersException =
                    new FailedServerCustomersException(httpResponseException);

                throw new CustomersDependencyException(failedServerCustomersException);
            }
            catch (Exception exception)
            {
                var failedCustomersServiceException =
                    new FailedCustomersServiceException(exception);

                throw new CustomersServiceException(failedCustomersServiceException);
            }
        }

    }
}