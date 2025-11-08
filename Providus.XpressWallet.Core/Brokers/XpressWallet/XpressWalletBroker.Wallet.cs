using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalWallet;

namespace Providus.XpressWallet.Core.Brokers.XpressWallet
{
    internal partial class XpressWalletBroker
    {



        public async ValueTask<ExternalCreateWalletResponse> PostCreateWalletAsync(
            ExternalCreateWalletRequest externalCreateWalletRequest)
        {
            return await PostAsync<ExternalCreateWalletRequest, ExternalCreateWalletResponse>(
                                    relativeUrl: $"wallet",
                                    content: externalCreateWalletRequest);
        }
        public async ValueTask<ExternalAllWalletsResponse> GetAllWalletsAsync()
        {
            return await GetAsync<ExternalAllWalletsResponse>(
                relativeUrl: $"wallet");
        }
        public async ValueTask<ExternalCustomerWalletResponse> GetCustomerWalletAsync(
            string customerId)
        {
            return await GetAsync<ExternalCustomerWalletResponse>(
                relativeUrl: $"wallet/customer?customerId={customerId}");
        }
        public async ValueTask<ExternalCreditWalletResponse> PostCreditWalletAsync(
            ExternalCreditWalletRequest externalCreditWalletRequest)
        {
            return await PostAsync<ExternalCreditWalletRequest, ExternalCreditWalletResponse>(
                                    relativeUrl: $"wallet/credit",
                                    content: externalCreditWalletRequest);
        }
        public async ValueTask<ExternalDebitWalletResponse> PostDebitWalletAsync(
            ExternalDebitWalletRequest externalDebitWalletRequest)
        {
            return await PostAsync<ExternalDebitWalletRequest, ExternalDebitWalletResponse>(
                                    relativeUrl: $"wallet/debit",
                                    content: externalDebitWalletRequest);
        }
        public async ValueTask<ExternalFreezeWalletResponse> PostFreezeWalletAsync(
            ExternalFreezeWalletRequest externalFreezeWalletRequest)
        {
            return await PostAsync<ExternalFreezeWalletRequest, ExternalFreezeWalletResponse>(
                                    relativeUrl: $"wallet/close",
                                    content: externalFreezeWalletRequest);
        }
        public async ValueTask<ExternalUnfreezeWalletResponse> PostUnfreezeWalletAsync(
            ExternalUnfreezeWalletRequest externalUnfreezeWalletRequest)
        {
            return await PostAsync<ExternalUnfreezeWalletRequest, ExternalUnfreezeWalletResponse>(
                                    relativeUrl: $"wallet/enable",
                                    content: externalUnfreezeWalletRequest);
        }
        public async ValueTask<ExternalBatchDebitCustomerWalletsResponse> PostBatchDebitCustomerWalletsAsync(
            ExternalBatchDebitCustomerWalletsRequest externalBatchDebitCustomerWalletsRequest)
        {
            return await PostAsync<ExternalBatchDebitCustomerWalletsRequest, ExternalBatchDebitCustomerWalletsResponse>(
                                    relativeUrl: $"wallet/batch-debit-customer-wallet",
                                    content: externalBatchDebitCustomerWalletsRequest);
        }
        public async ValueTask<ExternalBatchCreditCustomerWalletsResponse> PostBatchCreditCustomerWalletsAsync(
            ExternalBatchCreditCustomerWalletsRequest externalBatchCreditCustomerWalletsRequest)
        {
            return await PostAsync<ExternalBatchCreditCustomerWalletsRequest, ExternalBatchCreditCustomerWalletsResponse>(
                                    relativeUrl: $"wallet/batch-credit-customer-wallet",
                                    content: externalBatchCreditCustomerWalletsRequest);
        }
        public async ValueTask<ExternalCustomerCreditCustomerWalletResponse> PostCustomerCreditCustomerWalletAsync(
            ExternalCustomerCreditCustomerWalletRequest externalCustomerCreditCustomerWalletRequest)
        {
            return await PostAsync<ExternalCustomerCreditCustomerWalletRequest, ExternalCustomerCreditCustomerWalletResponse>(
                                    relativeUrl: $"wallet/customer-batch-credit-customer-wallet",
                                    content: externalCustomerCreditCustomerWalletRequest);
        }
        public async ValueTask<ExternalFundMerchantSandBoxWalletResponse> PostFundMerchantSandBoxWalletAsync(
            ExternalFundMerchantSandBoxWalletRequest externalFundMerchantSandBoxWalletRequest)
        {
            return await PostAsync<ExternalFundMerchantSandBoxWalletRequest, ExternalFundMerchantSandBoxWalletResponse>(
                                    relativeUrl: $"merchant/fund-wallet",
                                    content: externalFundMerchantSandBoxWalletRequest);
        }
        public async ValueTask<ExternalUpgradeCustomerWalletResponse> PostUpgradeCustomerWalletAsync(
            ExternalUpgradeCustomerWalletRequest externalUpgradeCustomerWalletRequest,string customerId)
        {
            return await PutAsync<ExternalUpgradeCustomerWalletRequest, ExternalUpgradeCustomerWalletResponse>(
                                    relativeUrl: $"customer/{customerId}",
                                    content: externalUpgradeCustomerWalletRequest);
        }



    }
}
