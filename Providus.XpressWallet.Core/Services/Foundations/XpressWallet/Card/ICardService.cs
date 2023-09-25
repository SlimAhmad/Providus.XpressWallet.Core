using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Card;

namespace Providus.XpressWallet.Core.Services.Foundations.XpressWallet.Card
{
    internal interface ICardService
    {
        ValueTask<CardSetup> PutCardSetupRequestAsync(
              CardSetup externalCardSetup);

        ValueTask<CreateCard> PostCreateCardRequestAsync(
            CreateCard externalCreateCard);

        ValueTask<ActivateCard> PostActivateCardRequestAsync(
            ActivateCard externalActivateCard);

        ValueTask<Balance> GetBalanceRequestAsync(
            string customerId);

        ValueTask<FundCard> PostFundCardRequestAsync(
            FundCard externalFundCard);
    }
}
