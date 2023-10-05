using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalCustomers;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalTeam;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalTransactions;

namespace Providus.XpressWallet.Core.Brokers.XpressWallet
{
    internal partial class XpressWalletBroker
    {



        public async ValueTask<ExternalMerchantTransactionsResponse> GetMerchantTransactionsAsync(
            int page, string type, string status) 
        {
            return await GetAsync<ExternalMerchantTransactionsResponse>(
                              relativeUrl: $"merchant/transactions?page={page}&type={type}&status={status}"
                              );
        }
        public async ValueTask<ExternalTransactionDetailsResponse> GetTransactionDetailsAsync(string transactionReference)
        {
            return await GetAsync<ExternalTransactionDetailsResponse>(
                                  relativeUrl: $"merchant/transaction/{transactionReference}"
                                  );
        }
        public async ValueTask<ExternalCustomerTransactionsResponse> GetCustomerTransactionsAsync(
            string customerId, int page, string type, int perPage)
        {
            return await GetAsync<ExternalCustomerTransactionsResponse>(
                                  relativeUrl: $"transaction/customer?customerId={customerId}&page={page}&type={type}&perPage={perPage}"
                                  );
        }
        public async ValueTask<ExternalBatchTransactionsResponse> GetBatchTransactionsAsync(
            string search,string category, string type, int page, int perPage)
        {
            return await GetAsync<ExternalBatchTransactionsResponse>(
                                  relativeUrl: $"transaction/batch?search={search}&category={category}&type={type}&page={page}&perPage={perPage}"
                                  );
        }
        public async ValueTask<ExternalBatchTransactionDetailsResponse> GetBatchTransactionDetailsAsync(string reference)
        {
            return await GetAsync<ExternalBatchTransactionDetailsResponse>(
                                  relativeUrl: $"transaction/batch/{reference}"
                                  );
        }
        public async ValueTask<ExternalReverseBatchTransactionResponse> PostReverseBatchTransactionAsync(
            ExternalReverseBatchTransactionRequest externalReverseBatchTransactionRequest)
        {
            return await PostAsync<ExternalReverseBatchTransactionRequest, ExternalReverseBatchTransactionResponse>(
                                  relativeUrl: $"wallet/reverse-batch-transaction",
                                  content: externalReverseBatchTransactionRequest);
        }
        public async ValueTask<ExternalPendingTransactionResponse> GetPendingTransactionsAsync(
            int page, string type)
        {
            return await GetAsync<ExternalPendingTransactionResponse>(
                                  relativeUrl: $"transaction/pending?page={page}&type={type}"
                                  );
        }
        public async ValueTask<ExternalApproveTransactionResponse> PostApproveTransactionAsync(
            ExternalApproveTransactionRequest externalApproveTransactionRequest)
        {
            return await PostAsync<ExternalApproveTransactionRequest, ExternalApproveTransactionResponse>(
                                  relativeUrl: $"transaction/approve",
                                  content: externalApproveTransactionRequest);
        }
        public async ValueTask<ExternalDeclinePendingTransactionResponse> DeleteDeclinePendingTransactionAsync(string transactionId)
        {
            return await DeleteAsync<ExternalDeclinePendingTransactionResponse>(
                                  relativeUrl: $"transaction/{transactionId}"
                                  );
        }
        public async ValueTask<ExternalDownloadCustomerTransactionResponse> GetDownloadCustomerTransactionAsync(string customerId)
        {
            return await GetAsync<ExternalDownloadCustomerTransactionResponse>(
                                  relativeUrl: $"transaction/download/customer?customerId={customerId}"
                                  );
        }
        public async ValueTask<ExternalDownloadMerchantTransactionResponse> GetDownloadMerchantTransactionAsync()
        {
            return await GetAsync<ExternalDownloadMerchantTransactionResponse>(
                                  relativeUrl: $"transaction/download/merchant"
                                  );
        }


    }
}
