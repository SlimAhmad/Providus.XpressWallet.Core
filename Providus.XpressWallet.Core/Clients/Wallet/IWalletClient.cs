using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Wallet;

namespace Providus.XpressWallet.Core.Clients.Wallet
{
    public interface IWalletClient
    {

        ValueTask<CreateWallet> CreateWalletAsync(
                  CreateWallet externalCreateWallet);
        ValueTask<AllWallets> RetrieveAllWalletsAsync();
        ValueTask<CustomerWallet> RetrieveCustomerWalletAsync(string customerId);
        ValueTask<CreditWallet> CreditWalletAsync(
            CreditWallet externalCreditWallet);
        ValueTask<DebitWallet> DebitWalletAsync(
            DebitWallet externalDebitWallet);
        ValueTask<FreezeWallet> FreezeWalletAsync(
            FreezeWallet externalFreezeWallet);
        ValueTask<UnfreezeWallet> UnfreezeWalletAsync(
            UnfreezeWallet externalUnfreezeWallet);
        ValueTask<BatchDebitCustomerWallets> BatchDebitCustomerWalletsAsync(
            BatchDebitCustomerWallets externalBatchDebitCustomerWallets);
        ValueTask<BatchCreditCustomerWallets> BatchCreditCustomerWalletsAsync(
            BatchCreditCustomerWallets externalBatchCreditCustomerWallets);
        ValueTask<CustomerCreditCustomerWallet> CustomerCreditCustomerWalletAsync(
            CustomerCreditCustomerWallet externalCustomerCreditCustomerWallet);
        ValueTask<FundMerchantSandBoxWallet> FundMerchantSandBoxWalletAsync(
            FundMerchantSandBoxWallet externalFundMerchantSandBoxWallet);
        ValueTask<UpgradeCustomerWallet> UpgradeCustomerWalletAsync(
            UpgradeCustomerWallet upgradeCustomerWallet);
    }
}
