using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transfers;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Wallet;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Wallet.Exceptions;

namespace Providus.XpressWallet.Core.Services.Foundations.XpressWallet.Wallet
{
    internal partial class WalletService
    {
        private static void ValidateCreateWallet(CreateWallet createWallet)
        {
            ValidateCreateWalletNotNull(createWallet);
            ValidateCreateWalletRequest(createWallet.Request);
            Validate(
                (Rule: IsInvalid(createWallet.Request), Parameter: nameof(createWallet.Request)));

            Validate(
                (Rule: IsInvalid(createWallet.Request.PhoneNumber), Parameter: nameof(CreateWalletRequest.PhoneNumber)),
                (Rule: IsInvalid(createWallet.Request.Email), Parameter: nameof(CreateWalletRequest.Email)),
                (Rule: IsInvalid(createWallet.Request.FirstName), Parameter: nameof(CreateWalletRequest.FirstName)),
                (Rule: IsInvalid(createWallet.Request.LastName), Parameter: nameof(CreateWalletRequest.LastName)),
                (Rule: IsInvalid(createWallet.Request.Bvn), Parameter: nameof(CreateWalletRequest.Bvn)),
                (Rule: IsInvalid(createWallet.Request.Address), Parameter: nameof(CreateWalletRequest.Address)),
                (Rule: IsInvalid(createWallet.Request.Metadata), Parameter: nameof(CreateWalletRequest.Metadata)),
                (Rule: IsInvalid(createWallet.Request.DateOfBirth), Parameter: nameof(CreateWalletRequest.DateOfBirth))
                );

        }

        private static void ValidateCreditWallet(CreditWallet creditWallet)
        {
            ValidateCreditWalletNotNull(creditWallet);
            ValidateCreditWalletRequest(creditWallet.Request);
            Validate(
                (Rule: IsInvalid(creditWallet.Request), Parameter: nameof(creditWallet.Request)));

            Validate(
                (Rule: IsInvalid(creditWallet.Request.CustomerId), Parameter: nameof(CreditWalletRequest.CustomerId)),
                (Rule: IsInvalid(creditWallet.Request.Reference), Parameter: nameof(CreditWalletRequest.Reference)),
                (Rule: IsInvalid(creditWallet.Request.Metadata), Parameter: nameof(CreditWalletRequest.Metadata)),
                (Rule: IsInvalid(creditWallet.Request.Amount), Parameter: nameof(CreditWalletRequest.Amount))
        

                );

        }

        private static void ValidateDebitWallet(DebitWallet debitWallet)
        {
            ValidateDebitWalletNotNull(debitWallet);
            ValidateDebitWalletRequest(debitWallet.Request);
            Validate(
                (Rule: IsInvalid(debitWallet.Request), Parameter: nameof(debitWallet.Request)));

            Validate(
                (Rule: IsInvalid(debitWallet.Request.CustomerId), Parameter: nameof(DebitWalletRequest.CustomerId)),
                (Rule: IsInvalid(debitWallet.Request.Reference), Parameter: nameof(DebitWalletRequest.Reference)),
                (Rule: IsInvalid(debitWallet.Request.Amount), Parameter: nameof(DebitWalletRequest.Amount)),
                (Rule: IsInvalid(debitWallet.Request.Metadata), Parameter: nameof(DebitWalletRequest.Metadata))



                );

        }

        private static void ValidateFreezeWallet(FreezeWallet freezeWallet)
        {
            ValidateFreezeWalletNotNull(freezeWallet);
            ValidateFreezeWalletRequest(freezeWallet.Request);
            Validate(
                (Rule: IsInvalid(freezeWallet.Request), Parameter: nameof(freezeWallet.Request)));

            Validate(
                (Rule: IsInvalid(freezeWallet.Request.CustomerId), Parameter: nameof(FreezeWalletRequest.CustomerId))
                );

        }

        private static void ValidateUnfreezeWallet(UnfreezeWallet unfreezeWallet)
        {
            ValidateUnfreezeWalletNotNull(unfreezeWallet);
            ValidateUnfreezeWalletRequest(unfreezeWallet.Request);
            Validate(
                (Rule: IsInvalid(unfreezeWallet.Request), Parameter: nameof(unfreezeWallet.Request)));

            Validate(
                (Rule: IsInvalid(unfreezeWallet.Request.CustomerId), Parameter: nameof(UnfreezeWalletRequest.CustomerId))
     
                );

        }

        private static void ValidateBatchDebitCustomerWallets(BatchDebitCustomerWallets batchDebitCustomerWallets)
        {
            ValidateBatchDebitCustomerWalletsNotNull(batchDebitCustomerWallets);
            ValidateBatchDebitCustomerWalletsRequest(batchDebitCustomerWallets.Request);
            Validate(
                (Rule: IsInvalid(batchDebitCustomerWallets.Request), Parameter: nameof(batchDebitCustomerWallets.Request)));

            Validate(
                (Rule: IsInvalid(batchDebitCustomerWallets.Request.BatchReference), Parameter: nameof(BatchDebitCustomerWalletsRequest.BatchReference)),
                (Rule: IsInvalid(batchDebitCustomerWallets.Request.Transactions), Parameter: nameof(BatchDebitCustomerWalletsRequest.Transactions))


                );

        }

        private static void ValidateBatchCreditCustomerWallets(BatchCreditCustomerWallets batchDebitCustomerWallets)
        {
            ValidateBatchCreditCustomerWalletsNotNull(batchDebitCustomerWallets);
            ValidateBatchCreditCustomerWalletsRequest(batchDebitCustomerWallets.Request);
            Validate(
                (Rule: IsInvalid(batchDebitCustomerWallets.Request), Parameter: nameof(batchDebitCustomerWallets.Request)));

            Validate(
                (Rule: IsInvalid(batchDebitCustomerWallets.Request.BatchReference), Parameter: nameof(BatchCreditCustomerWalletsRequest.BatchReference)),
                (Rule: IsInvalid(batchDebitCustomerWallets.Request.Transactions), Parameter: nameof(BatchCreditCustomerWalletsRequest.Transactions))


                );

        }

        private static void ValidateCustomerCreditCustomerWallet(CustomerCreditCustomerWallet batchDebitCustomerWallets)
        {
            ValidateCustomerCreditCustomerWalletNotNull(batchDebitCustomerWallets);
            ValidateCustomerCreditCustomerWalletRequest(batchDebitCustomerWallets.Request);
            Validate(
                (Rule: IsInvalid(batchDebitCustomerWallets.Request), Parameter: nameof(batchDebitCustomerWallets.Request)));

            Validate(
                (Rule: IsInvalid(batchDebitCustomerWallets.Request.BatchReference), Parameter: nameof(CustomerCreditCustomerWalletRequest.BatchReference)),
                (Rule: IsInvalid(batchDebitCustomerWallets.Request.Recipients), Parameter: nameof(CustomerCreditCustomerWalletRequest.Recipients)),
                (Rule: IsInvalid(batchDebitCustomerWallets.Request.CustomerId), Parameter: nameof(CustomerCreditCustomerWalletRequest.CustomerId))


                );

        }

        private static void ValidateFundMerchantSandBoxWallet(FundMerchantSandBoxWallet batchDebitCustomerWallets)
        {
            ValidateFundMerchantSandBoxWalletNotNull(batchDebitCustomerWallets);
            ValidateFundMerchantSandBoxWalletRequest(batchDebitCustomerWallets.Request);
            Validate(
                (Rule: IsInvalid(batchDebitCustomerWallets.Request), Parameter: nameof(batchDebitCustomerWallets.Request)));

            Validate(
                (Rule: IsInvalid(batchDebitCustomerWallets.Request.Amount), Parameter: nameof(FundMerchantSandBoxWalletRequest.Amount))
             

                );

        }

        private static void ValidateBatchDebitCustomerWalletsNotNull(BatchDebitCustomerWallets batchDebitCustomerWallets)
        {
            if (batchDebitCustomerWallets is null)
            {
                throw new NullWalletException();
            }
        }

        private static void ValidateBatchDebitCustomerWalletsRequest(BatchDebitCustomerWalletsRequest batchDebitCustomerWallets)
        {
            Validate((Rule: IsInvalid(batchDebitCustomerWallets), Parameter: nameof(BatchDebitCustomerWalletsRequest)));
        }

        private static void ValidateBatchCreditCustomerWalletsNotNull(BatchCreditCustomerWallets batchCreditCustomerWallets)
        {
            if (batchCreditCustomerWallets is null)
            {
                throw new NullWalletException();
            }
        }

        private static void ValidateBatchCreditCustomerWalletsRequest(BatchCreditCustomerWalletsRequest batchCreditCustomerWallets)
        {
            Validate((Rule: IsInvalid(batchCreditCustomerWallets), Parameter: nameof(BatchCreditCustomerWalletsRequest)));
        }


        private static void ValidateCustomerCreditCustomerWalletNotNull(CustomerCreditCustomerWallet CustomerCreditCustomerWallet)
        {
            if (CustomerCreditCustomerWallet is null)
            {
                throw new NullWalletException();
            }
        }

        private static void ValidateCustomerCreditCustomerWalletRequest(CustomerCreditCustomerWalletRequest CustomerCreditCustomerWallet)
        {
            Validate((Rule: IsInvalid(CustomerCreditCustomerWallet), Parameter: nameof(CustomerCreditCustomerWalletRequest)));
        }


        private static void ValidateFundMerchantSandBoxWalletNotNull(FundMerchantSandBoxWallet fundMerchantSandBoxWallet)
        {
            if (fundMerchantSandBoxWallet is null)
            {
                throw new NullWalletException();
            }
        }

        private static void ValidateFundMerchantSandBoxWalletRequest(FundMerchantSandBoxWalletRequest fundMerchantSandBoxWallet)
        {
            Validate((Rule: IsInvalid(fundMerchantSandBoxWallet), Parameter: nameof(FundMerchantSandBoxWalletRequest)));
        }

        private static void ValidateUnfreezeWalletNotNull(UnfreezeWallet unfreezeWallet)
        {
            if (unfreezeWallet is null)
            {
                throw new NullWalletException();
            }
        }

        private static void ValidateUnfreezeWalletRequest(UnfreezeWalletRequest unfreezeWallet)
        {
            Validate((Rule: IsInvalid(unfreezeWallet), Parameter: nameof(UnfreezeWalletRequest)));
        }
        private static void ValidateFreezeWalletNotNull(FreezeWallet freezeWallet)
        {
            if (freezeWallet is null)
            {
                throw new NullWalletException();
            }
        }

        private static void ValidateFreezeWalletRequest(FreezeWalletRequest freezeWallet)
        {
            Validate((Rule: IsInvalid(freezeWallet), Parameter: nameof(FreezeWalletRequest)));
        }

        private static void ValidateDebitWalletNotNull(DebitWallet debitWallet)
        {
            if (debitWallet is null)
            {
                throw new NullWalletException();
            }
        }

        private static void ValidateDebitWalletRequest(DebitWalletRequest debitWallet)
        {
            Validate((Rule: IsInvalid(debitWallet), Parameter: nameof(DebitWalletRequest)));
        }

        private static void ValidateCreditWalletNotNull(CreditWallet creditWallet)
        {
            if (creditWallet is null)
            {
                throw new NullWalletException();
            }
        }

        private static void ValidateCreditWalletRequest(CreditWalletRequest creditWallet)
        {
            Validate((Rule: IsInvalid(creditWallet), Parameter: nameof(CreditWalletRequest)));
        }
        private static void ValidateCreateWalletNotNull(CreateWallet creditWallet)
        {
            if (creditWallet is null)
            {
                throw new NullWalletException();
            }
        }

        private static void ValidateCreateWalletRequest(CreateWalletRequest creditWalletRequest)
        {
            Validate((Rule: IsInvalid(creditWalletRequest), Parameter: nameof(CreateWalletRequest)));
        }

        private static void ValidateCustomerWalletParameters(string text) =>
          Validate((Rule: IsInvalid(text), Parameter: nameof(CustomerWallet)));

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
            var invalidcreditWalletException = new InvalidWalletException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidcreditWalletException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidcreditWalletException.ThrowIfContainsErrors();
        }
    }
}