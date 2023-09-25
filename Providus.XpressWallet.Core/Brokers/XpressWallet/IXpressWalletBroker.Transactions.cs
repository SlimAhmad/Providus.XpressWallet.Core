using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalCustomers;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalTransactions;

namespace Providus.XpressWallet.Core.Brokers.XpressWallet
{
    internal partial interface IXpressWalletBroker
    {

        ValueTask<ExternalMerchantTransactionsResponse> GetMerchantTransactionsAsync(int page,string type,string status);
        ValueTask<ExternalTransactionDetailsResponse> GetTransactionDetailsAsync(string transactionReference);
        ValueTask<ExternalCustomerTransactionsResponse> GetCustomerTransactionAsync(
            string customerId,int page,string type,int perPage);
        ValueTask<ExternalBatchTransactionsResponse>GetBatchTransactionsAsync(string search, string category, string type,int page,int perPage);
        ValueTask<ExternalBatchTransactionDetailsResponse> GetBatchTransactionDetailsAsync(string reference);
        ValueTask<ExternalReverseBatchTransactionResponse> PostReverseBatchTransactionAsync(
            ExternalReverseBatchTransactionRequest externalReverseBatchTransactionRequest);
        ValueTask<ExternalPendingTransactionResponse> GetPendingTransactionsAsync(int page,string type);
        ValueTask<ExternalApproveTransactionResponse> PostApproveTransactionAsync(
            ExternalApproveTransactionRequest externalApproveTransactionRequest);
        ValueTask<ExternalDeclinePendingTransactionResponse> DeleteDeclinePendingTransactionAsync(string transactionId);
        ValueTask<ExternalDownloadCustomerTransactionResponse> GetDownloadCustomerTransactionAsync(string customerId);
        ValueTask<ExternalDownloadMerchantTransactionResponse> GetDownloadMerchantTransactionAsync();
    }
}
