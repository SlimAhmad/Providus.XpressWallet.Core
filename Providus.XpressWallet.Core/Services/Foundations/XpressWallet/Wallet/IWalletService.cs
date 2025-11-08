using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Wallet;

namespace Providus.XpressWallet.Core.Services.Foundations.XpressWallet.Wallet
{
    internal interface IWalletService
    {
        ValueTask<CreateWallet> PostCreateWalletRequestAsync(
                  CreateWallet externalCreateWallet);
        ValueTask<AllWallets> GetAllWalletsRequestAsync();
        ValueTask<CustomerWallet> GetCustomerWalletRequestAsync(string customerId);
        ValueTask<CreditWallet> PostCreditWalletRequestAsync(
            CreditWallet externalCreditWallet);
        ValueTask<DebitWallet> PostDebitWalletRequestAsync(
            DebitWallet externalDebitWallet);
        ValueTask<FreezeWallet> PostFreezeWalletRequestAsync(
            FreezeWallet externalFreezeWallet);
        ValueTask<UnfreezeWallet> PostUnfreezeWalletRequestAsync(
            UnfreezeWallet externalUnfreezeWallet);
        ValueTask<BatchDebitCustomerWallets> PostBatchDebitCustomerWalletsRequestAsync(
            BatchDebitCustomerWallets externalBatchDebitCustomerWallets);
        ValueTask<BatchCreditCustomerWallets> PostBatchCreditCustomerWalletsRequestAsync(
            BatchCreditCustomerWallets externalBatchCreditCustomerWallets);
        ValueTask<CustomerCreditCustomerWallet> PostCustomerCreditCustomerWalletRequestAsync(
            CustomerCreditCustomerWallet externalCustomerCreditCustomerWallet);
        ValueTask<FundMerchantSandBoxWallet> PostFundMerchantSandBoxWalletRequestAsync(
            FundMerchantSandBoxWallet externalFundMerchantSandBoxWallet);
        ValueTask<UpgradeCustomerWallet> PostUpgradeCustomerWalletRequestAsync(
            UpgradeCustomerWallet externalUpgradeCustomerWallet);
    }
}
