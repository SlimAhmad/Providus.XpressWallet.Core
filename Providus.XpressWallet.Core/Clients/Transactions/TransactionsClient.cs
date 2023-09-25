using Providus.XpressWallet.Core.Models.Clients.Transactions.Exceptions;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transactions;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transactions.Exceptions;
using Providus.XpressWallet.Core.Services.Foundations.XpressWallet.Transactions;
using Xeptions;

namespace Providus.XpressWallet.Core.Clients.Transactions
{
    internal class TransactionsClient : ITransactionsClient
    {
        private readonly ITransactionsService transactionsService;
        public TransactionsClient(ITransactionsService transactionService) =>
        transactionsService = transactionService;

        public async ValueTask<ApproveTransaction> ApproveTransactionAsync(ApproveTransaction approveTransaction)
        {
            try
            {
                return await transactionsService.PostApproveTransactionRequestAsync(approveTransaction);
            }
            catch (TransactionsValidationException transactionsValidationException)
            {

                throw new TransactionsClientValidationException(
                    transactionsValidationException.InnerException as Xeption);
            }
            catch (TransactionsDependencyValidationException transactionsDependencyValidationException)
            {


                throw new TransactionsClientValidationException(
                    transactionsDependencyValidationException.InnerException as Xeption);
            }
            catch (TransactionsDependencyException TransactionsDependencyException)
            {
                throw new TransactionsClientDependencyException(
                    TransactionsDependencyException.InnerException as Xeption);
            }
            catch (TransactionsServiceException TransactionsServiceException)
            {
                throw new TransactionsClientServiceException(
                    TransactionsServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<DeclinePendingTransaction> DeclinePendingTransactionAsync(string transactionId)
        {
              try
            {
                return await transactionsService.DeleteDeclinePendingTransactionRequestAsync(transactionId);
            }
            catch (TransactionsValidationException transactionsValidationException)
            {

                throw new TransactionsClientValidationException(
                    transactionsValidationException.InnerException as Xeption);
            }
            catch (TransactionsDependencyValidationException transactionsDependencyValidationException)
            {


                throw new TransactionsClientValidationException(
                    transactionsDependencyValidationException.InnerException as Xeption);
            }
            catch (TransactionsDependencyException TransactionsDependencyException)
            {
                throw new TransactionsClientDependencyException(
                    TransactionsDependencyException.InnerException as Xeption);
            }
            catch (TransactionsServiceException TransactionsServiceException)
            {
                throw new TransactionsClientServiceException(
                    TransactionsServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<BatchTransactionDetails> RetrieveBatchTransactionDetailsAsync(string reference)
        {
              try
            {
                return await transactionsService.GetBatchTransactionDetailsRequestAsync(reference);
            }
            catch (TransactionsValidationException transactionsValidationException)
            {

                throw new TransactionsClientValidationException(
                    transactionsValidationException.InnerException as Xeption);
            }
            catch (TransactionsDependencyValidationException transactionsDependencyValidationException)
            {


                throw new TransactionsClientValidationException(
                    transactionsDependencyValidationException.InnerException as Xeption);
            }
            catch (TransactionsDependencyException TransactionsDependencyException)
            {
                throw new TransactionsClientDependencyException(
                    TransactionsDependencyException.InnerException as Xeption);
            }
            catch (TransactionsServiceException TransactionsServiceException)
            {
                throw new TransactionsClientServiceException(
                    TransactionsServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<BatchTransactions> RetrieveBatchTransactionsAsync(string search, string category, string type, int page, int perPage)
        {
              try
            {
                return await transactionsService.GetBatchTransactionsRequestAsync(search,category,type,page,perPage);
            }
            catch (TransactionsValidationException transactionsValidationException)
            {

                throw new TransactionsClientValidationException(
                    transactionsValidationException.InnerException as Xeption);
            }
            catch (TransactionsDependencyValidationException transactionsDependencyValidationException)
            {


                throw new TransactionsClientValidationException(
                    transactionsDependencyValidationException.InnerException as Xeption);
            }
            catch (TransactionsDependencyException TransactionsDependencyException)
            {
                throw new TransactionsClientDependencyException(
                    TransactionsDependencyException.InnerException as Xeption);
            }
            catch (TransactionsServiceException TransactionsServiceException)
            {
                throw new TransactionsClientServiceException(
                    TransactionsServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<CustomerTransactions> RetrieveCustomerTransactionAsync(string customerId, int page, string type, int perPage)
        {
              try
            {
                return await transactionsService.GetCustomerTransactionRequestAsync(customerId,page,type,perPage);
            }
            catch (TransactionsValidationException transactionsValidationException)
            {

                throw new TransactionsClientValidationException(
                    transactionsValidationException.InnerException as Xeption);
            }
            catch (TransactionsDependencyValidationException transactionsDependencyValidationException)
            {


                throw new TransactionsClientValidationException(
                    transactionsDependencyValidationException.InnerException as Xeption);
            }
            catch (TransactionsDependencyException TransactionsDependencyException)
            {
                throw new TransactionsClientDependencyException(
                    TransactionsDependencyException.InnerException as Xeption);
            }
            catch (TransactionsServiceException TransactionsServiceException)
            {
                throw new TransactionsClientServiceException(
                    TransactionsServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<DownloadCustomerTransaction> RetrieveDownloadCustomerTransactionAsync(string customerId)
        {
              try
            {
                return await transactionsService.GetDownloadCustomerTransactionRequestAsync(customerId);
            }
            catch (TransactionsValidationException transactionsValidationException)
            {

                throw new TransactionsClientValidationException(
                    transactionsValidationException.InnerException as Xeption);
            }
            catch (TransactionsDependencyValidationException transactionsDependencyValidationException)
            {


                throw new TransactionsClientValidationException(
                    transactionsDependencyValidationException.InnerException as Xeption);
            }
            catch (TransactionsDependencyException TransactionsDependencyException)
            {
                throw new TransactionsClientDependencyException(
                    TransactionsDependencyException.InnerException as Xeption);
            }
            catch (TransactionsServiceException TransactionsServiceException)
            {
                throw new TransactionsClientServiceException(
                    TransactionsServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<DownloadMerchantTransaction> RetrieveDownloadMerchantTransactionAsync()
        {
              try
            {
                return await transactionsService.GetDownloadMerchantTransactionRequestAsync();
            }
            catch (TransactionsValidationException transactionsValidationException)
            {

                throw new TransactionsClientValidationException(
                    transactionsValidationException.InnerException as Xeption);
            }
            catch (TransactionsDependencyValidationException transactionsDependencyValidationException)
            {


                throw new TransactionsClientValidationException(
                    transactionsDependencyValidationException.InnerException as Xeption);
            }
            catch (TransactionsDependencyException TransactionsDependencyException)
            {
                throw new TransactionsClientDependencyException(
                    TransactionsDependencyException.InnerException as Xeption);
            }
            catch (TransactionsServiceException TransactionsServiceException)
            {
                throw new TransactionsClientServiceException(
                    TransactionsServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<MerchantTransactions> RetrieveMerchantTransactionsAsync(int page, string type, string status)
        {
              try
            {
                return await transactionsService.GetMerchantTransactionsRequestAsync(page,type,status);
            }
            catch (TransactionsValidationException transactionsValidationException)
            {

                throw new TransactionsClientValidationException(
                    transactionsValidationException.InnerException as Xeption);
            }
            catch (TransactionsDependencyValidationException transactionsDependencyValidationException)
            {


                throw new TransactionsClientValidationException(
                    transactionsDependencyValidationException.InnerException as Xeption);
            }
            catch (TransactionsDependencyException TransactionsDependencyException)
            {
                throw new TransactionsClientDependencyException(
                    TransactionsDependencyException.InnerException as Xeption);
            }
            catch (TransactionsServiceException TransactionsServiceException)
            {
                throw new TransactionsClientServiceException(
                    TransactionsServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<PendingTransaction> RetrievePendingTransactionsAsync(int page, string type)
        {
              try
            {
                return await transactionsService.GetPendingTransactionsRequestAsync(page,type);
            }
            catch (TransactionsValidationException transactionsValidationException)
            {

                throw new TransactionsClientValidationException(
                    transactionsValidationException.InnerException as Xeption);
            }
            catch (TransactionsDependencyValidationException transactionsDependencyValidationException)
            {


                throw new TransactionsClientValidationException(
                    transactionsDependencyValidationException.InnerException as Xeption);
            }
            catch (TransactionsDependencyException TransactionsDependencyException)
            {
                throw new TransactionsClientDependencyException(
                    TransactionsDependencyException.InnerException as Xeption);
            }
            catch (TransactionsServiceException TransactionsServiceException)
            {
                throw new TransactionsClientServiceException(
                    TransactionsServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<TransactionDetails> RetrieveTransactionDetailsAsync(string transactionReference)
        {
              try
            {
                return await transactionsService.GetTransactionDetailsRequestAsync(transactionReference);
            }
            catch (TransactionsValidationException transactionsValidationException)
            {

                throw new TransactionsClientValidationException(
                    transactionsValidationException.InnerException as Xeption);
            }
            catch (TransactionsDependencyValidationException transactionsDependencyValidationException)
            {


                throw new TransactionsClientValidationException(
                    transactionsDependencyValidationException.InnerException as Xeption);
            }
            catch (TransactionsDependencyException TransactionsDependencyException)
            {
                throw new TransactionsClientDependencyException(
                    TransactionsDependencyException.InnerException as Xeption);
            }
            catch (TransactionsServiceException TransactionsServiceException)
            {
                throw new TransactionsClientServiceException(
                    TransactionsServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<ReverseBatchTransaction> ReverseBatchTransactionAsync(ReverseBatchTransaction reverseBatchTransaction)
        {
              try
            {
                return await transactionsService.PostReverseBatchTransactionRequestAsync(reverseBatchTransaction);
            }
            catch (TransactionsValidationException transactionsValidationException)
            {

                throw new TransactionsClientValidationException(
                    transactionsValidationException.InnerException as Xeption);
            }
            catch (TransactionsDependencyValidationException transactionsDependencyValidationException)
            {


                throw new TransactionsClientValidationException(
                    transactionsDependencyValidationException.InnerException as Xeption);
            }
            catch (TransactionsDependencyException TransactionsDependencyException)
            {
                throw new TransactionsClientDependencyException(
                    TransactionsDependencyException.InnerException as Xeption);
            }
            catch (TransactionsServiceException TransactionsServiceException)
            {
                throw new TransactionsClientServiceException(
                    TransactionsServiceException.InnerException as Xeption);
            }
        }
    }
}
