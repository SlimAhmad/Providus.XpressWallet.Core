using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Card;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Card.Exceptions;

namespace Providus.XpressWallet.Core.Services.Foundations.XpressWallet.Card
{
    internal partial class CardService
    {
        private static void ValidateCardSetup(CardSetup cardSetup)
        {
            ValidateCardSetupNotNull(cardSetup);
            ValidateCardSetupRequest(cardSetup.Request);
            Validate(
                (Rule: IsInvalid(cardSetup.Request), Parameter: nameof(cardSetup.Request)));

            Validate(
                (Rule: IsInvalid(cardSetup.Request.AppId), Parameter: nameof(CardSetupRequest.AppId)),
                (Rule: IsInvalid(cardSetup.Request.AppKey), Parameter: nameof(CardSetupRequest.AppKey)),
                 (Rule: IsInvalid(cardSetup.Request.PrepaidCardPrefix), Parameter: nameof(CardSetupRequest.PrepaidCardPrefix)),
                (Rule: IsInvalid(cardSetup.Request.LoadingAccountNumber), Parameter: nameof(CardSetupRequest.LoadingAccountNumber)),
                (Rule: IsInvalid(cardSetup.Request.LoadingAccountName), Parameter: nameof(CardSetupRequest.LoadingAccountName)),
                (Rule: IsInvalid(cardSetup.Request.LoadingAccountSortcode), Parameter: nameof(CardSetupRequest.LoadingAccountSortcode))
                );

        }

        private static void ValidateCreateCard(CreateCard createCard)
        {
            ValidateCreateCardNotNull(createCard);
            ValidateCreateCardRequest(createCard.Request);
            Validate(
                (Rule: IsInvalid(createCard.Request), Parameter: nameof(createCard.Request)));

            Validate(
                (Rule: IsInvalid(createCard.Request.CustomerId), Parameter: nameof(CreateCardRequest.CustomerId)),
                (Rule: IsInvalid(createCard.Request.Address2), Parameter: nameof(CreateCardRequest.Address2)),
                (Rule: IsInvalid(createCard.Request.Address1), Parameter: nameof(CreateCardRequest.Address1))
        

                );

        }

        private static void ValidateActivateCard(ActivateCard activateCard)
        {
            ValidateActivateCardNotNull(activateCard);
            ValidateActivateCardRequest(activateCard.Request);
            Validate(
                (Rule: IsInvalid(activateCard.Request), Parameter: nameof(activateCard.Request)));

            Validate(
                (Rule: IsInvalid(activateCard.Request.CustomerId), Parameter: nameof(ActivateCardRequest.CustomerId)),
                (Rule: IsInvalid(activateCard.Request.Last6), Parameter: nameof(ActivateCardRequest.Last6))

                );

        }

        private static void ValidateFundCard(FundCard fundCard)
        {
            ValidateFundCardNotNull(fundCard);
            ValidateFundCardRequest(fundCard.Request);
            Validate(
                (Rule: IsInvalid(fundCard.Request), Parameter: nameof(fundCard.Request)));

            Validate(
                (Rule: IsInvalid(fundCard.Request.CustomerId), Parameter: nameof(FundCardRequest.CustomerId)),
                (Rule: IsInvalid(fundCard.Request.Amount), Parameter: nameof(FundCardRequest.Amount))

                );

        }


        private static void ValidateFundCardNotNull(FundCard fundCard)
        {
            if (fundCard is null)
            {
                throw new NullCardException();
            }
        }

        private static void ValidateFundCardRequest(FundCardRequest fundCard)
        {
            Validate((Rule: IsInvalid(fundCard), Parameter: nameof(FundCardRequest)));
        }

        private static void ValidateActivateCardNotNull(ActivateCard activateCard)
        {
            if (activateCard is null)
            {
                throw new NullCardException();
            }
        }

        private static void ValidateActivateCardRequest(ActivateCardRequest activateCard)
        {
            Validate((Rule: IsInvalid(activateCard), Parameter: nameof(ActivateCardRequest)));
        }

        private static void ValidateCreateCardNotNull(CreateCard createCard)
        {
            if (createCard is null)
            {
                throw new NullCardException();
            }
        }

        private static void ValidateCreateCardRequest(CreateCardRequest createCard)
        {
            Validate((Rule: IsInvalid(createCard), Parameter: nameof(CreateCardRequest)));
        }
        private static void ValidateCardSetupNotNull(CardSetup createCard)
        {
            if (createCard is null)
            {
                throw new NullCardException();
            }
        }

        private static void ValidateCardSetupRequest(CardSetupRequest createCardRequest)
        {
            Validate((Rule: IsInvalid(createCardRequest), Parameter: nameof(CardSetupRequest)));
        }


        private static void ValidateBalanceParameters(string text) =>
            Validate((Rule: IsInvalid(text), Parameter: nameof(Balance)));

        private static dynamic IsInvalid(object @object) => new
        {
            Condition = @object is null,
            Message = "Value is required"
        };


        private static dynamic IsInvalid(string text) => new
        {
            Condition = String.IsNullOrWhiteSpace(text),
            Message = "Value is required"
        };

        private static dynamic IsInvalid(double number) => new
        {
            Condition = number <= 0,
            Message = "Value is required"
        };

        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidcreateCardException = new InvalidCardException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidcreateCardException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidcreateCardException.ThrowIfContainsErrors();
        }
    }
}