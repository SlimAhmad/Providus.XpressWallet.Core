using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalCard;

namespace Providus.XpressWallet.Core.Brokers.XpressWallet
{
    internal partial interface IXpressWalletBroker
    {

        ValueTask<ExternalCardSetupResponse> PutCardSetupAsync(
            ExternalCardSetupRequest externalCardSetupRequest);

        ValueTask<ExternalCreateCardResponse> PostCreateCardAsync(
            ExternalCreateCardRequest externalCreateCardRequest);

        ValueTask<ExternalActivateCardResponse> PostActivateCardAsync(
            ExternalActivateCardRequest externalActivateCardRequest);

        ValueTask<ExternalBalanceResponse> GetBalanceAsync(
            string customerId);

        ValueTask<ExternalFundCardResponse> PostFundCardAsync(
            ExternalFundCardRequest  externalFundCardRequest);

        
    }
}
