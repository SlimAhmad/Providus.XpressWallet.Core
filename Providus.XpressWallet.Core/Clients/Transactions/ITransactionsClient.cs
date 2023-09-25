using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Customers;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transactions;

namespace Providus.XpressWallet.Core.Clients.Transactions
{
    public interface ITransactionsClient
    {

        ValueTask<MerchantTransactions> RetrieveMerchantTransactionsAsync(int page, string type, string status);
        ValueTask<TransactionDetails> RetrieveTransactionDetailsAsync(string transactionReference);
        ValueTask<CustomerTransactions> RetrieveCustomerTransactionAsync(
            string customerId, int page, string type, int perPage);
        ValueTask<BatchTransactions> RetrieveBatchTransactionsAsync(string search, string category, string type, int page, int perPage);
        ValueTask<BatchTransactionDetails> RetrieveBatchTransactionDetailsAsync(string reference);
        ValueTask<ReverseBatchTransaction> ReverseBatchTransactionAsync(
            ReverseBatchTransaction reverseBatchTransaction);
        ValueTask<PendingTransaction> RetrievePendingTransactionsAsync(int page, string type);
        ValueTask<ApproveTransaction> ApproveTransactionAsync(
            ApproveTransaction approveTransaction);
        ValueTask<DeclinePendingTransaction> DeclinePendingTransactionAsync(string transactionId);
        ValueTask<DownloadCustomerTransaction> RetrieveDownloadCustomerTransactionAsync(string customerId);
        ValueTask<DownloadMerchantTransaction> RetrieveDownloadMerchantTransactionAsync();
    }
}
