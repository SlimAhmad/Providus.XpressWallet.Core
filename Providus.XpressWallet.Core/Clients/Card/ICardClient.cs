using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Card;

namespace Providus.XpressWallet.Core.Clients.Card
{
    public interface ICardClient
    {

        ValueTask<CardSetup> ModifyCardSetupAsync(
              CardSetup externalCardSetup);

        ValueTask<CreateCard> CreateCardAsync(
            CreateCard externalCreateCard);

        ValueTask<ActivateCard> ActivateCardAsync(
            ActivateCard externalActivateCard);

        ValueTask<Balance> RetrieveBalanceAsync(
            string customerId);

        ValueTask<FundCard> FundCardAsync(
            FundCard externalFundCard);
    }
}
