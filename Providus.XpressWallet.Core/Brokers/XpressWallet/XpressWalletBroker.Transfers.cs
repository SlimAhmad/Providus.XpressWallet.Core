using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalTransfers;

namespace Providus.XpressWallet.Core.Brokers.XpressWallet
{
    internal partial class XpressWalletBroker
    {



        public async ValueTask<ExternalBankListResponse> GetBankListAsync()
        {
            return await GetAsync<ExternalBankListResponse>(
                                relativeUrl: $"transfer/banks"
                                );
        }
        public async ValueTask<ExternalBankAccountDetailsResponse> GetBankAccountDetailsAsync(
            string sortCode, string accountNumber)
        {
            return await GetAsync<ExternalBankAccountDetailsResponse>(
                                relativeUrl: $"transfer/account/details?sortCode={sortCode}&accountNumber={accountNumber}"
                               );
        }
        public async ValueTask<ExternalMerchantBankTransferResponse> PostMerchantBankTransferAsync(
            ExternalMerchantBankTransferRequest externalMerchantBankTransferRequest)
        {
            return await PostAsync<ExternalMerchantBankTransferRequest, ExternalMerchantBankTransferResponse>(
                                relativeUrl: $"transfer/bank",
                                content: externalMerchantBankTransferRequest);
        }
        public async ValueTask<ExternalCustomerBankTransferResponse> PostCustomerBankTransferAsync(
            ExternalCustomerBankTransferRequest externalCustomerBankTransferRequest)
        {
            return await PostAsync<ExternalCustomerBankTransferRequest, ExternalCustomerBankTransferResponse>(
                                relativeUrl: $"transfer/bank/customer",
                                content: externalCustomerBankTransferRequest);
        }
        public async ValueTask<ExternalMerchantBatchBankTransferResponse> PostMerchantBatchBankTransferAsync(
            ExternalMerchantBatchBankTransferRequest externalMerchantBatchBankTransferRequest)
        {
            return await PostAsync<ExternalMerchantBatchBankTransferRequest, ExternalMerchantBatchBankTransferResponse>(
                                relativeUrl: $"transfer/bank/batch",
                                content: externalMerchantBatchBankTransferRequest);
        }
        public async ValueTask<ExternalCustomerToCustomerWalletTransferResponse> PostCustomerToCustomerWalletTransferAsync(
            ExternalCustomerToCustomerWalletTransferRequest externalCustomerToCustomerWalletTransferRequest)
        {
            return await PostAsync<ExternalCustomerToCustomerWalletTransferRequest, ExternalCustomerToCustomerWalletTransferResponse>(
                                relativeUrl: $"transfer/wallet",
                                content: externalCustomerToCustomerWalletTransferRequest);
        }



    }
}
