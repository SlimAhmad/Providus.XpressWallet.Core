using Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.Categories;
using Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.Exceptions;
using Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.Fields;
using Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.Payment;
using Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.PaymentInquiry;
using Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.Validate;
using RESTFulSense.Exceptions;

namespace Providus.XpressWallet.Core.Services.Foundations.XpressWallet.BillPayment
{
    internal partial class BillPaymentService
    {
        private delegate ValueTask<Categories> ReturningCategoriesFunction();
        private delegate ValueTask<BillsByCategory> ReturningBillsByCategoryFunction();
        private delegate ValueTask<Fields> ReturningFieldsFunction();
        private delegate ValueTask<Validate> ReturningValidateFunction();
        private delegate ValueTask<PaymentInquiry> ReturningPaymentInquiryFunction();
        private delegate ValueTask<Payment> ReturningPaymentFunction();




        private async ValueTask<Categories> TryCatch(ReturningCategoriesFunction returningCategoriesFunction)
        {
            try
            {
                return await returningCategoriesFunction();
            }
            catch (NullBillPaymentException nullBillPaymentException)
            {
                throw new BillPaymentValidationException(nullBillPaymentException);
            }
            catch (InvalidBillPaymentException invalidBillPaymentException)
            {
                throw new BillPaymentValidationException(invalidBillPaymentException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationBillPaymentException =
                    new InvalidConfigurationBillPaymentException(httpResponseUrlNotFoundException);

                throw new BillPaymentDependencyException(invalidConfigurationBillPaymentException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedBillPaymentException =
                    new UnauthorizedBillPaymentException(httpResponseUnauthorizedException);

                throw new BillPaymentDependencyException(unauthorizedBillPaymentException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedBillPaymentException =
                    new UnauthorizedBillPaymentException(httpResponseForbiddenException);

                throw new BillPaymentDependencyException(unauthorizedBillPaymentException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundBillPaymentException =
                    new NotFoundBillPaymentException(httpResponseNotFoundException);

                throw new BillPaymentDependencyValidationException(notFoundBillPaymentException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidBillPaymentException =
                    new InvalidBillPaymentException(httpResponseBadRequestException);

                throw new BillPaymentDependencyValidationException(invalidBillPaymentException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallBillPaymentException =
                    new ExcessiveCallBillPaymentException(httpResponseTooManyRequestsException);

                throw new BillPaymentDependencyValidationException(excessiveCallBillPaymentException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerBillPaymentException =
                    new FailedServerBillPaymentException(httpResponseException);

                throw new BillPaymentDependencyException(failedServerBillPaymentException);
            }
            catch (Exception exception)
            {
                var failedBillPaymentServiceException =
                    new FailedBillPaymentServiceException(exception);

                throw new BillPaymentServiceException(failedBillPaymentServiceException);
            }
        }
        private async ValueTask<BillsByCategory> TryCatch(
            ReturningBillsByCategoryFunction returningBillsByCategoryFunction)
        {
            try
            {
                return await returningBillsByCategoryFunction();
            }
            catch (NullBillPaymentException nullBillPaymentException)
            {
                throw new BillPaymentValidationException(nullBillPaymentException);
            }
            catch (InvalidBillPaymentException invalidBillPaymentException)
            {
                throw new BillPaymentValidationException(invalidBillPaymentException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationBillPaymentException =
                    new InvalidConfigurationBillPaymentException(httpResponseUrlNotFoundException);

                throw new BillPaymentDependencyException(invalidConfigurationBillPaymentException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedBillPaymentException =
                    new UnauthorizedBillPaymentException(httpResponseUnauthorizedException);

                throw new BillPaymentDependencyException(unauthorizedBillPaymentException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedBillPaymentException =
                    new UnauthorizedBillPaymentException(httpResponseForbiddenException);

                throw new BillPaymentDependencyException(unauthorizedBillPaymentException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundBillPaymentException =
                    new NotFoundBillPaymentException(httpResponseNotFoundException);

                throw new BillPaymentDependencyValidationException(notFoundBillPaymentException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidBillPaymentException =
                    new InvalidBillPaymentException(httpResponseBadRequestException);

                throw new BillPaymentDependencyValidationException(invalidBillPaymentException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallBillPaymentException =
                    new ExcessiveCallBillPaymentException(httpResponseTooManyRequestsException);

                throw new BillPaymentDependencyValidationException(excessiveCallBillPaymentException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerBillPaymentException =
                    new FailedServerBillPaymentException(httpResponseException);

                throw new BillPaymentDependencyException(failedServerBillPaymentException);
            }
            catch (Exception exception)
            {
                var failedBillPaymentServiceException =
                    new FailedBillPaymentServiceException(exception);

                throw new BillPaymentServiceException(failedBillPaymentServiceException);
            }
        }
        private async ValueTask<Fields> TryCatch(ReturningFieldsFunction returningFieldsFunction)
        {
            try
            {
                return await returningFieldsFunction();
            }
            catch (NullBillPaymentException nullBillPaymentException)
            {
                throw new BillPaymentValidationException(nullBillPaymentException);
            }
            catch (InvalidBillPaymentException invalidBillPaymentException)
            {
                throw new BillPaymentValidationException(invalidBillPaymentException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationBillPaymentException =
                    new InvalidConfigurationBillPaymentException(httpResponseUrlNotFoundException);

                throw new BillPaymentDependencyException(invalidConfigurationBillPaymentException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedBillPaymentException =
                    new UnauthorizedBillPaymentException(httpResponseUnauthorizedException);

                throw new BillPaymentDependencyException(unauthorizedBillPaymentException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedBillPaymentException =
                    new UnauthorizedBillPaymentException(httpResponseForbiddenException);

                throw new BillPaymentDependencyException(unauthorizedBillPaymentException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundBillPaymentException =
                    new NotFoundBillPaymentException(httpResponseNotFoundException);

                throw new BillPaymentDependencyValidationException(notFoundBillPaymentException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidBillPaymentException =
                    new InvalidBillPaymentException(httpResponseBadRequestException);

                throw new BillPaymentDependencyValidationException(invalidBillPaymentException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallBillPaymentException =
                    new ExcessiveCallBillPaymentException(httpResponseTooManyRequestsException);

                throw new BillPaymentDependencyValidationException(excessiveCallBillPaymentException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerBillPaymentException =
                    new FailedServerBillPaymentException(httpResponseException);

                throw new BillPaymentDependencyException(failedServerBillPaymentException);
            }
            catch (Exception exception)
            {
                var failedBillPaymentServiceException =
                    new FailedBillPaymentServiceException(exception);

                throw new BillPaymentServiceException(failedBillPaymentServiceException);
            }
        }
        private async ValueTask<Validate> TryCatch(ReturningValidateFunction returningValidateFunction)
        {
            try
            {
                return await returningValidateFunction();
            }
            catch (NullBillPaymentException nullBillPaymentException)
            {
                throw new BillPaymentValidationException(nullBillPaymentException);
            }
            catch (InvalidBillPaymentException invalidBillPaymentException)
            {
                throw new BillPaymentValidationException(invalidBillPaymentException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationBillPaymentException =
                    new InvalidConfigurationBillPaymentException(httpResponseUrlNotFoundException);

                throw new BillPaymentDependencyException(invalidConfigurationBillPaymentException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedBillPaymentException =
                    new UnauthorizedBillPaymentException(httpResponseUnauthorizedException);

                throw new BillPaymentDependencyException(unauthorizedBillPaymentException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedBillPaymentException =
                    new UnauthorizedBillPaymentException(httpResponseForbiddenException);

                throw new BillPaymentDependencyException(unauthorizedBillPaymentException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundBillPaymentException =
                    new NotFoundBillPaymentException(httpResponseNotFoundException);

                throw new BillPaymentDependencyValidationException(notFoundBillPaymentException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidBillPaymentException =
                    new InvalidBillPaymentException(httpResponseBadRequestException);

                throw new BillPaymentDependencyValidationException(invalidBillPaymentException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallBillPaymentException =
                    new ExcessiveCallBillPaymentException(httpResponseTooManyRequestsException);

                throw new BillPaymentDependencyValidationException(excessiveCallBillPaymentException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerBillPaymentException =
                    new FailedServerBillPaymentException(httpResponseException);

                throw new BillPaymentDependencyException(failedServerBillPaymentException);
            }
            catch (Exception exception)
            {
                var failedBillPaymentServiceException =
                    new FailedBillPaymentServiceException(exception);

                throw new BillPaymentServiceException(failedBillPaymentServiceException);
            }
        }
        private async ValueTask<PaymentInquiry> TryCatch(ReturningPaymentInquiryFunction returningPaymentInquiryFunction)
        {
            try
            {
                return await returningPaymentInquiryFunction();
            }
            catch (NullBillPaymentException nullBillPaymentException)
            {
                throw new BillPaymentValidationException(nullBillPaymentException);
            }
            catch (InvalidBillPaymentException invalidBillPaymentException)
            {
                throw new BillPaymentValidationException(invalidBillPaymentException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationBillPaymentException =
                    new InvalidConfigurationBillPaymentException(httpResponseUrlNotFoundException);

                throw new BillPaymentDependencyException(invalidConfigurationBillPaymentException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedBillPaymentException =
                    new UnauthorizedBillPaymentException(httpResponseUnauthorizedException);

                throw new BillPaymentDependencyException(unauthorizedBillPaymentException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedBillPaymentException =
                    new UnauthorizedBillPaymentException(httpResponseForbiddenException);

                throw new BillPaymentDependencyException(unauthorizedBillPaymentException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundBillPaymentException =
                    new NotFoundBillPaymentException(httpResponseNotFoundException);

                throw new BillPaymentDependencyValidationException(notFoundBillPaymentException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidBillPaymentException =
                    new InvalidBillPaymentException(httpResponseBadRequestException);

                throw new BillPaymentDependencyValidationException(invalidBillPaymentException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallBillPaymentException =
                    new ExcessiveCallBillPaymentException(httpResponseTooManyRequestsException);

                throw new BillPaymentDependencyValidationException(excessiveCallBillPaymentException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerBillPaymentException =
                    new FailedServerBillPaymentException(httpResponseException);

                throw new BillPaymentDependencyException(failedServerBillPaymentException);
            }
            catch (Exception exception)
            {
                var failedBillPaymentServiceException =
                    new FailedBillPaymentServiceException(exception);

                throw new BillPaymentServiceException(failedBillPaymentServiceException);
            }
        }
        private async ValueTask<Payment> TryCatch(ReturningPaymentFunction returningPaymentFunction)
        {
            try
            {
                return await returningPaymentFunction();
            }
            catch (NullBillPaymentException nullBillPaymentException)
            {
                throw new BillPaymentValidationException(nullBillPaymentException);
            }
            catch (InvalidBillPaymentException invalidBillPaymentException)
            {
                throw new BillPaymentValidationException(invalidBillPaymentException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationBillPaymentException =
                    new InvalidConfigurationBillPaymentException(httpResponseUrlNotFoundException);

                throw new BillPaymentDependencyException(invalidConfigurationBillPaymentException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedBillPaymentException =
                    new UnauthorizedBillPaymentException(httpResponseUnauthorizedException);

                throw new BillPaymentDependencyException(unauthorizedBillPaymentException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedBillPaymentException =
                    new UnauthorizedBillPaymentException(httpResponseForbiddenException);

                throw new BillPaymentDependencyException(unauthorizedBillPaymentException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundBillPaymentException =
                    new NotFoundBillPaymentException(httpResponseNotFoundException);

                throw new BillPaymentDependencyValidationException(notFoundBillPaymentException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidBillPaymentException =
                    new InvalidBillPaymentException(httpResponseBadRequestException);

                throw new BillPaymentDependencyValidationException(invalidBillPaymentException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallBillPaymentException =
                    new ExcessiveCallBillPaymentException(httpResponseTooManyRequestsException);

                throw new BillPaymentDependencyValidationException(excessiveCallBillPaymentException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerBillPaymentException =
                    new FailedServerBillPaymentException(httpResponseException);

                throw new BillPaymentDependencyException(failedServerBillPaymentException);
            }
            catch (Exception exception)
            {
                var failedBillPaymentServiceException =
                    new FailedBillPaymentServiceException(exception);

                throw new BillPaymentServiceException(failedBillPaymentServiceException);
            }
        }
    }
}