using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Card;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Card.Exceptions;
using RESTFulSense.Exceptions;

namespace Providus.XpressWallet.Core.Services.Foundations.XpressWallet.Card
{
    internal partial class CardService
    {
        private delegate ValueTask<CardSetup> ReturningCardSetupFunction();

        private delegate ValueTask<CreateCard> ReturningCreateCardFunction();

        private delegate ValueTask<ActivateCard> ReturningActivateCardFunction();

        private delegate ValueTask<Balance> ReturningBalanceFunction();

        private delegate ValueTask<FundCard> ReturningFundCardFunction();



        private async ValueTask<FundCard> TryCatch(ReturningFundCardFunction returningFundCardFunction)
        {
            try
            {
                return await returningFundCardFunction();
            }
            catch (NullCardException nullCardException)
            {
                throw new CardValidationException(nullCardException);
            }
            catch (InvalidCardException invalidCardException)
            {
                throw new CardValidationException(invalidCardException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationCardException =
                    new InvalidConfigurationCardException(httpResponseUrlNotFoundException);

                throw new CardDependencyException(invalidConfigurationCardException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedCardException =
                    new UnauthorizedCardException(httpResponseUnauthorizedException);

                throw new CardDependencyException(unauthorizedCardException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedCardException =
                    new UnauthorizedCardException(httpResponseForbiddenException);

                throw new CardDependencyException(unauthorizedCardException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundCardException =
                    new NotFoundCardException(httpResponseNotFoundException);

                throw new CardDependencyValidationException(notFoundCardException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidCardException =
                    new InvalidCardException(httpResponseBadRequestException);

                throw new CardDependencyValidationException(invalidCardException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallCardException =
                    new ExcessiveCallCardException(httpResponseTooManyRequestsException);

                throw new CardDependencyValidationException(excessiveCallCardException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerCardException =
                    new FailedServerCardException(httpResponseException);

                throw new CardDependencyException(failedServerCardException);
            }
            catch (Exception exception)
            {
                var failedCardServiceException =
                    new FailedCardServiceException(exception);

                throw new CardServiceException(failedCardServiceException);
            }
        }
        private async ValueTask<ActivateCard> TryCatch(ReturningActivateCardFunction returningActivateCardFunction)
        {
            try
            {
                return await returningActivateCardFunction();
            }
            catch (NullCardException nullCardException)
            {
                throw new CardValidationException(nullCardException);
            }
            catch (InvalidCardException invalidCardException)
            {
                throw new CardValidationException(invalidCardException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationCardException =
                    new InvalidConfigurationCardException(httpResponseUrlNotFoundException);

                throw new CardDependencyException(invalidConfigurationCardException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedCardException =
                    new UnauthorizedCardException(httpResponseUnauthorizedException);

                throw new CardDependencyException(unauthorizedCardException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedCardException =
                    new UnauthorizedCardException(httpResponseForbiddenException);

                throw new CardDependencyException(unauthorizedCardException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundCardException =
                    new NotFoundCardException(httpResponseNotFoundException);

                throw new CardDependencyValidationException(notFoundCardException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidCardException =
                    new InvalidCardException(httpResponseBadRequestException);

                throw new CardDependencyValidationException(invalidCardException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallCardException =
                    new ExcessiveCallCardException(httpResponseTooManyRequestsException);

                throw new CardDependencyValidationException(excessiveCallCardException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerCardException =
                    new FailedServerCardException(httpResponseException);

                throw new CardDependencyException(failedServerCardException);
            }
            catch (Exception exception)
            {
                var failedCardServiceException =
                    new FailedCardServiceException(exception);

                throw new CardServiceException(failedCardServiceException);
            }
        }

        private async ValueTask<Balance> TryCatch(ReturningBalanceFunction returningBalanceFunction)
        {
            try
            {
                return await returningBalanceFunction();
            }
            catch (NullCardException nullCardException)
            {
                throw new CardValidationException(nullCardException);
            }
            catch (InvalidCardException invalidCardException)
            {
                throw new CardValidationException(invalidCardException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationCardException =
                    new InvalidConfigurationCardException(httpResponseUrlNotFoundException);

                throw new CardDependencyException(invalidConfigurationCardException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedCardException =
                    new UnauthorizedCardException(httpResponseUnauthorizedException);

                throw new CardDependencyException(unauthorizedCardException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedCardException =
                    new UnauthorizedCardException(httpResponseForbiddenException);

                throw new CardDependencyException(unauthorizedCardException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundCardException =
                    new NotFoundCardException(httpResponseNotFoundException);

                throw new CardDependencyValidationException(notFoundCardException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidCardException =
                    new InvalidCardException(httpResponseBadRequestException);

                throw new CardDependencyValidationException(invalidCardException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallCardException =
                    new ExcessiveCallCardException(httpResponseTooManyRequestsException);

                throw new CardDependencyValidationException(excessiveCallCardException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerCardException =
                    new FailedServerCardException(httpResponseException);

                throw new CardDependencyException(failedServerCardException);
            }
            catch (Exception exception)
            {
                var failedCardServiceException =
                    new FailedCardServiceException(exception);

                throw new CardServiceException(failedCardServiceException);
            }
        }

        private async ValueTask<CardSetup> TryCatch(ReturningCardSetupFunction returningCardSetupFunction)
        {
            try
            {
                return await returningCardSetupFunction();
            }
            catch (NullCardException nullCardException)
            {
                throw new CardValidationException(nullCardException);
            }
            catch (InvalidCardException invalidCardException)
            {
                throw new CardValidationException(invalidCardException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationCardException =
                    new InvalidConfigurationCardException(httpResponseUrlNotFoundException);

                throw new CardDependencyException(invalidConfigurationCardException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedCardException =
                    new UnauthorizedCardException(httpResponseUnauthorizedException);

                throw new CardDependencyException(unauthorizedCardException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedCardException =
                    new UnauthorizedCardException(httpResponseForbiddenException);

                throw new CardDependencyException(unauthorizedCardException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundCardException =
                    new NotFoundCardException(httpResponseNotFoundException);

                throw new CardDependencyValidationException(notFoundCardException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidCardException =
                    new InvalidCardException(httpResponseBadRequestException);

                throw new CardDependencyValidationException(invalidCardException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallCardException =
                    new ExcessiveCallCardException(httpResponseTooManyRequestsException);

                throw new CardDependencyValidationException(excessiveCallCardException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerCardException =
                    new FailedServerCardException(httpResponseException);

                throw new CardDependencyException(failedServerCardException);
            }
            catch (Exception exception)
            {
                var failedCardServiceException =
                    new FailedCardServiceException(exception);

                throw new CardServiceException(failedCardServiceException);
            }
        }

        private async ValueTask<CreateCard> TryCatch(
            ReturningCreateCardFunction returningCreateCardFunction)
        {
            try
            {
                return await returningCreateCardFunction();
            }
            catch (NullCardException nullCardException)
            {
                throw new CardValidationException(nullCardException);
            }
            catch (InvalidCardException invalidCardException)
            {
                throw new CardValidationException(invalidCardException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationCardException =
                    new InvalidConfigurationCardException(httpResponseUrlNotFoundException);

                throw new CardDependencyException(invalidConfigurationCardException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedCardException =
                    new UnauthorizedCardException(httpResponseUnauthorizedException);

                throw new CardDependencyException(unauthorizedCardException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedCardException =
                    new UnauthorizedCardException(httpResponseForbiddenException);

                throw new CardDependencyException(unauthorizedCardException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundCardException =
                    new NotFoundCardException(httpResponseNotFoundException);

                throw new CardDependencyValidationException(notFoundCardException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidCardException =
                    new InvalidCardException(httpResponseBadRequestException);

                throw new CardDependencyValidationException(invalidCardException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallCardException =
                    new ExcessiveCallCardException(httpResponseTooManyRequestsException);

                throw new CardDependencyValidationException(excessiveCallCardException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerCardException =
                    new FailedServerCardException(httpResponseException);

                throw new CardDependencyException(failedServerCardException);
            }
            catch (Exception exception)
            {
                var failedCardServiceException =
                    new FailedCardServiceException(exception);

                throw new CardServiceException(failedCardServiceException);
            }
        }

    }
}