using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Wallet;

namespace Providus.XpressWallet.Core.Clients.Wallet
{
    public interface IWalletClient
    {

        ValueTask<CreateWallet> PostCreateWalletAsync(
                  CreateWallet externalCreateWallet);
        ValueTask<AllWallets> GetAllWalletsAsync();
        ValueTask<CustomerWallet> GetCustomerWalletAsync(string customerId);
        ValueTask<CreditWallet> PostCreditWalletAsync(
            CreditWallet externalCreditWallet);
        ValueTask<DebitWallet> PostDebitWalletAsync(
            DebitWallet externalDebitWallet);
        ValueTask<FreezeWallet> PostFreezeWalletAsync(
            FreezeWallet externalFreezeWallet);
        ValueTask<UnfreezeWallet> PostUnfreezeWalletAsync(
            UnfreezeWallet externalUnfreezeWallet);
        ValueTask<BatchDebitCustomerWallets> PostBatchDebitCustomerWalletsAsync(
            BatchDebitCustomerWallets externalBatchDebitCustomerWallets);
        ValueTask<BatchCreditCustomerWallets> PostBatchCreditCustomerWalletsAsync(
            BatchCreditCustomerWallets externalBatchCreditCustomerWallets);
        ValueTask<CustomerCreditCustomerWallet> PostCustomerCreditCustomerWalletAsync(
            CustomerCreditCustomerWallet externalCustomerCreditCustomerWallet);
        ValueTask<FundMerchantSandBoxWallet> PostFundMerchantSandBoxWalletAsync(
            FundMerchantSandBoxWallet externalFundMerchantSandBoxWallet);
    }
}
