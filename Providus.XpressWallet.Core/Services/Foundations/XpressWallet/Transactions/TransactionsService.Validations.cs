using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Customers;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Team;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transactions;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transactions.Exceptions;

namespace Providus.XpressWallet.Core.Services.Foundations.XpressWallet.Transactions
{
    internal partial class TransactionsService
    {
        private static void ValidateReverseBatchTransaction(ReverseBatchTransaction reverseBatchTransaction)
        {
            ValidateReverseBatchTransactionNotNull(reverseBatchTransaction);
            ValidateReverseBatchTransactionRequest(reverseBatchTransaction.Request);
            Validate(
                (Rule: IsInvalid(reverseBatchTransaction.Request), Parameter: nameof(reverseBatchTransaction.Request)));

            Validate(
                (Rule: IsInvalid(reverseBatchTransaction.Request.BatchReference), Parameter: nameof(ReverseBatchTransactionRequest.BatchReference))
                );

        }

        private static void ValidateApproveTransaction(ApproveTransaction approveTransaction)
        {
            ValidateApproveTransactionNotNull(approveTransaction);
            ValidateApproveTransactionRequest(approveTransaction.Request);
            Validate(
                (Rule: IsInvalid(approveTransaction.Request), Parameter: nameof(approveTransaction.Request)));

            Validate(
                (Rule: IsInvalid(approveTransaction.Request.TransactionId), Parameter: nameof(ApproveTransactionRequest.TransactionId))
       
                );

        }



        private static void ValidateApproveTransactionNotNull(ApproveTransaction approveTransaction)
        {
            if (approveTransaction is null)
            {
                throw new NullTransactionsException();
            }
        }

        private static void ValidateApproveTransactionRequest(ApproveTransactionRequest approveTransaction)
        {
            Validate((Rule: IsInvalid(approveTransaction), Parameter: nameof(ApproveTransactionRequest)));
        }
        private static void ValidateReverseBatchTransactionNotNull(ReverseBatchTransaction approveTransaction)
        {
            if (approveTransaction is null)
            {
                throw new NullTransactionsException();
            }
        }

        private static void ValidateReverseBatchTransactionRequest(ReverseBatchTransactionRequest approveTransactionRequest)
        {
            Validate((Rule: IsInvalid(approveTransactionRequest), Parameter: nameof(ReverseBatchTransactionRequest)));
        }


        private static void ValidateMerchantTransactionsParameters(string text) =>
       Validate((Rule: IsInvalid(text), Parameter: nameof(MerchantTransactions)));
        private static void ValidateMerchantTransactionsParameters(double number) =>
       Validate((Rule: IsInvalid(number), Parameter: nameof(MerchantTransactions)));
        private static void ValidateTransactionDetailsParameters(string text) =>
       Validate((Rule: IsInvalid(text), Parameter: nameof(TransactionDetails)));
        private static void ValidateCustomerTransactionsParameters(string text) =>
      Validate((Rule: IsInvalid(text), Parameter: nameof(CustomerTransactions)));
        private static void ValidateCustomerTransactionsParameters(double number) =>
       Validate((Rule: IsInvalid(number), Parameter: nameof(CustomerTransactions)));
        private static void ValidateAllInvitationsParameters(double number) =>
       Validate((Rule: IsInvalid(number), Parameter: nameof(AllInvitations)));
        private static void ValidateBatchTransactionsParameters(string text) =>
      Validate((Rule: IsInvalid(text), Parameter: nameof(BatchTransactions)));
        private static void ValidateBatchTransactionsParameters(double number) =>
       Validate((Rule: IsInvalid(number), Parameter: nameof(BatchTransactions)));
        private static void ValidateBatchTransactionDetailsParameters(string text) =>
       Validate((Rule: IsInvalid(text), Parameter: nameof(BatchTransactionDetails)));
        private static void ValidatePendingTransactionParameters(string text) =>
     Validate((Rule: IsInvalid(text), Parameter: nameof(PendingTransaction)));
        private static void ValidatePendingTransactionParameters(double number) =>
       Validate((Rule: IsInvalid(number), Parameter: nameof(PendingTransaction)));
        private static void ValidateDeclinePendingTransactionParameters(string text) =>
       Validate((Rule: IsInvalid(text), Parameter: nameof(DeclinePendingTransaction)));
        private static void ValidateDownloadCustomerTransactionParameters(string text) =>
       Validate((Rule: IsInvalid(text), Parameter: nameof(DownloadCustomerTransaction)));

        private static dynamic IsInvalid(object @object) => new
        {
            Condition = @object is null,
            Message = "Value is required"
        };


        private static dynamic IsInvalid(string text) => new
        {
            Condition = String.IsNullOrWhiteSpace(text),
            Message = "Value is required"
        };

        private static dynamic IsInvalid(double number) => new
        {
            Condition = number <= 0,
            Message = "Value is required"
        };

        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidapproveTransactionException = new InvalidTransactionsException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidapproveTransactionException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidapproveTransactionException.ThrowIfContainsErrors();
        }
    }
}