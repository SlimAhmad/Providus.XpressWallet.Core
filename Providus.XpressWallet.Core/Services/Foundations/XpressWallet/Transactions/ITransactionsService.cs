using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transactions;

namespace Providus.XpressWallet.Core.Services.Foundations.XpressWallet.Transactions
{
    internal interface ITransactionsService
    {
        ValueTask<MerchantTransactions> GetMerchantTransactionsRequestAsync(int page, string type, string status);
        ValueTask<TransactionDetails> GetTransactionDetailsRequestAsync(string transactionReference);
        ValueTask<CustomerTransactions> GetCustomerTransactionsRequestAsync(
            string customerId, int page, string type, int perPage);
        ValueTask<BatchTransactions> GetBatchTransactionsRequestAsync(string search, string category, string type, int page, int perPage);
        ValueTask<BatchTransactionDetails> GetBatchTransactionDetailsRequestAsync(string reference);
        ValueTask<ReverseBatchTransaction> PostReverseBatchTransactionRequestAsync(
            ReverseBatchTransaction externalReverseBatchTransaction);
        ValueTask<PendingTransaction> GetPendingTransactionsRequestAsync(int page, string type);
        ValueTask<ApproveTransaction> PostApproveTransactionRequestAsync(
            ApproveTransaction externalApproveTransaction);
        ValueTask<DeclinePendingTransaction> DeleteDeclinePendingTransactionRequestAsync(string transactionId);
        ValueTask<DownloadCustomerTransaction> GetDownloadCustomerTransactionRequestAsync(string customerId);
        ValueTask<DownloadMerchantTransaction> GetDownloadMerchantTransactionRequestAsync();
    }
}
