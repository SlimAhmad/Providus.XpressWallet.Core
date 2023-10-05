using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transfers;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transfers.Exceptions;

namespace Providus.XpressWallet.Core.Services.Foundations.XpressWallet.Transfers
{
    internal partial class TransfersService
    {
        private static void ValidateMerchantBankTransfer(MerchantBankTransfer merchantBankTransfer)
        {
            ValidateMerchantBankTransferNotNull(merchantBankTransfer);
            ValidateMerchantBankTransferRequest(merchantBankTransfer.Request);
            Validate(
                (Rule: IsInvalid(merchantBankTransfer.Request), Parameter: nameof(merchantBankTransfer.Request)));

            Validate(
                (Rule: IsInvalid(merchantBankTransfer.Request.AccountNumber), Parameter: nameof(MerchantBankTransferRequest.AccountNumber)),
                (Rule: IsInvalid(merchantBankTransfer.Request.SortCode), Parameter: nameof(MerchantBankTransferRequest.SortCode)),
                (Rule: IsInvalid(merchantBankTransfer.Request.Narration), Parameter: nameof(MerchantBankTransferRequest.Narration)),
                (Rule: IsInvalid(merchantBankTransfer.Request.AccountName), Parameter: nameof(MerchantBankTransferRequest.AccountName)),
                            (Rule: IsInvalid(merchantBankTransfer.Request.Metadata), Parameter: nameof(MerchantBankTransferRequest.Metadata)),
                (Rule: IsInvalid(merchantBankTransfer.Request.Amount), Parameter: nameof(MerchantBankTransferRequest.Amount))
                );

        }

        private static void ValidateCustomerBankTransfer(CustomerBankTransfer customerBankTransfer)
        {
            ValidateCustomerBankTransferNotNull(customerBankTransfer);
            ValidateCustomerBankTransferRequest(customerBankTransfer.Request);
            Validate(
                (Rule: IsInvalid(customerBankTransfer.Request), Parameter: nameof(customerBankTransfer.Request)));

            Validate(
                (Rule: IsInvalid(customerBankTransfer.Request.AccountNumber), Parameter: nameof(CustomerBankTransferRequest.AccountNumber)),
                (Rule: IsInvalid(customerBankTransfer.Request.CustomerId), Parameter: nameof(CustomerBankTransferRequest.CustomerId)),
                (Rule: IsInvalid(customerBankTransfer.Request.AccountName), Parameter: nameof(CustomerBankTransferRequest.AccountName)),
                (Rule: IsInvalid(customerBankTransfer.Request.Amount), Parameter: nameof(CustomerBankTransferRequest.Amount)),
                (Rule: IsInvalid(customerBankTransfer.Request.SortCode), Parameter: nameof(CustomerBankTransferRequest.SortCode)),
                (Rule: IsInvalid(customerBankTransfer.Request.Narration), Parameter: nameof(CustomerBankTransferRequest.Narration)),
                (Rule: IsInvalid(customerBankTransfer.Request.Metadata), Parameter: nameof(CustomerBankTransferRequest.Metadata))
        

                );

        }

        private static void ValidateMerchantBatchBankTransfer(MerchantBatchBankTransfer merchantBatchBankTransfer)
        {
            ValidateMerchantBatchBankTransferNotNull(merchantBatchBankTransfer);
            ValidateMerchantBatchBankTransferRequest(merchantBatchBankTransfer.Request);
            Validate(
                (Rule: IsInvalid(merchantBatchBankTransfer.Request), Parameter: nameof(merchantBatchBankTransfer.Request)));

            Validate(
                (Rule: IsInvalid(merchantBatchBankTransfer.Request), Parameter: nameof(MerchantBatchBankTransferRequest))
     


                );

        }

        private static void ValidateCustomerToCustomerWalletTransfer(CustomerToCustomerWalletTransfer customerToCustomerWalletTransfer)
        {
            ValidateCustomerToCustomerWalletTransferNotNull(customerToCustomerWalletTransfer);
            ValidateCustomerToCustomerWalletTransferRequest(customerToCustomerWalletTransfer.Request);
            Validate(
                (Rule: IsInvalid(customerToCustomerWalletTransfer.Request), Parameter: nameof(customerToCustomerWalletTransfer.Request)));

            Validate(
                (Rule: IsInvalid(customerToCustomerWalletTransfer.Request.ToCustomerId), Parameter: nameof(CustomerToCustomerWalletTransferRequest.ToCustomerId)),
                (Rule: IsInvalid(customerToCustomerWalletTransfer.Request.FromCustomerId), Parameter: nameof(CustomerToCustomerWalletTransferRequest.FromCustomerId)),
                (Rule: IsInvalid(customerToCustomerWalletTransfer.Request.Amount), Parameter: nameof(CustomerToCustomerWalletTransferRequest.Amount))

                );

        }


        private static void ValidateCustomerToCustomerWalletTransferNotNull(CustomerToCustomerWalletTransfer customerToCustomerWalletTransfer)
        {
            if (customerToCustomerWalletTransfer is null)
            {
                throw new NullTransfersException();
            }
        }

        private static void ValidateCustomerToCustomerWalletTransferRequest(CustomerToCustomerWalletTransferRequest customerToCustomerWalletTransfer)
        {
            Validate((Rule: IsInvalid(customerToCustomerWalletTransfer), Parameter: nameof(CustomerToCustomerWalletTransferRequest)));
        }

        private static void ValidateMerchantBatchBankTransferNotNull(MerchantBatchBankTransfer merchantBatchBankTransfer)
        {
            if (merchantBatchBankTransfer is null)
            {
                throw new NullTransfersException();
            }
        }

        private static void ValidateMerchantBatchBankTransferRequest(List<MerchantBatchBankTransferRequest> merchantBatchBankTransfer)
        {
            Validate((Rule: IsInvalid(merchantBatchBankTransfer), Parameter: nameof(MerchantBatchBankTransferRequest)));
        }

        private static void ValidateCustomerBankTransferNotNull(CustomerBankTransfer customerBankTransfer)
        {
            if (customerBankTransfer is null)
            {
                throw new NullTransfersException();
            }
        }

        private static void ValidateCustomerBankTransferRequest(CustomerBankTransferRequest customerBankTransfer)
        {
            Validate((Rule: IsInvalid(customerBankTransfer), Parameter: nameof(CustomerBankTransferRequest)));
        }
        private static void ValidateMerchantBankTransferNotNull(MerchantBankTransfer customerBankTransfer)
        {
            if (customerBankTransfer is null)
            {
                throw new NullTransfersException();
            }
        }

        private static void ValidateMerchantBankTransferRequest(MerchantBankTransferRequest customerBankTransferRequest)
        {
            Validate((Rule: IsInvalid(customerBankTransferRequest), Parameter: nameof(MerchantBankTransferRequest)));
        }

        private static void ValidateBankAccountDetailsParameters(string text) =>
            Validate((Rule: IsInvalid(text), Parameter: nameof(BankAccountDetails)));

        private static dynamic IsInvalid(object @object) => new
        {
            Condition = @object is null,
            Message = "Value is required"
        };
        private static dynamic IsInvalid(List<object> @object) => new
        {
            Condition = @object.Count <= 0,
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
            var invalidcustomerBankTransferException = new InvalidTransfersException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidcustomerBankTransferException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidcustomerBankTransferException.ThrowIfContainsErrors();
        }
    }
}