using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalTransfers;

namespace Providus.XpressWallet.Core.Brokers.XpressWallet
{
    internal partial interface IXpressWalletBroker
    {

        ValueTask<ExternalBankListResponse> GetBankListAsync();
        ValueTask<ExternalBankAccountDetailsResponse> GetBankAccountDetailsAsync(string sortCode, string accountNumber);
        ValueTask<ExternalMerchantBankTransferResponse> PostMerchantBankTransferAsync(
            ExternalMerchantBankTransferRequest externalMerchantBankTransferRequest);
        ValueTask<ExternalCustomerBankTransferResponse> PostCustomerBankTransferAsync(
            ExternalCustomerBankTransferRequest externalCustomerBankTransferRequest);
        ValueTask<ExternalMerchantBatchBankTransferResponse> PostMerchantBatchBankTransferAsync(
            ExternalMerchantBatchBankTransferRequest  externalMerchantBatchBankTransferRequest);
        ValueTask<ExternalCustomerToCustomerWalletTransferResponse> PostCustomerToCustomerWalletTransferAsync(
            ExternalCustomerToCustomerWalletTransferRequest externalCustomerToCustomerWalletTransferRequest);

    }
}
