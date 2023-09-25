using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalAuth;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalCard;

namespace Providus.XpressWallet.Core.Brokers.XpressWallet
{
    internal partial class XpressWalletBroker
    {


        public async ValueTask<ExternalCardSetupResponse> PutCardSetupAsync(
                    ExternalCardSetupRequest externalCardSetupRequest)
        {
            return await PutAsync<ExternalCardSetupRequest, ExternalCardSetupResponse>(
                 relativeUrl: $"card/setup",
                 content: externalCardSetupRequest);
        }

        public async ValueTask<ExternalCreateCardResponse> PostCreateCardAsync(
            ExternalCreateCardRequest externalCreateCardRequest)
        {
            return await PostAsync<ExternalCreateCardRequest, ExternalCreateCardResponse>(
                    relativeUrl: $"card",
                    content: externalCreateCardRequest);
        }

        public async ValueTask<ExternalActivateCardResponse> PostActivateCardAsync(
            ExternalActivateCardRequest externalActivateCardRequest)
        {
            return await PostAsync<ExternalActivateCardRequest, ExternalActivateCardResponse>(
                relativeUrl: $"card/activate",
                content: externalActivateCardRequest);

        }

        public async ValueTask<ExternalBalanceResponse> GetBalanceAsync(
            string customerId)
        {
            return await GetAsync<ExternalBalanceResponse>(
                    relativeUrl: $"card/balance?customerId={customerId}");
        }

        public async ValueTask<ExternalFundCardResponse> PostFundCardAsync(
            ExternalFundCardRequest externalFundCardRequest)
        {
            return await PostAsync<ExternalFundCardRequest, ExternalFundCardResponse>(
                relativeUrl: $"card/fund",
                content: externalFundCardRequest);

        }


    }
}
