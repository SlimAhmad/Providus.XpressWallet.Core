using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalWallet;

namespace Providus.XpressWallet.Core.Brokers.XpressWallet
{
    internal partial interface IXpressWalletBroker
    {

        ValueTask<ExternalCreateWalletResponse> PostCreateWalletAsync(
            ExternalCreateWalletRequest externalCreateWalletRequest);
        ValueTask<ExternalAllWalletsResponse> GetAllWalletsAsync();
        ValueTask<ExternalCustomerWalletResponse> GetCustomerWalletAsync(string customerId);
        ValueTask<ExternalCreditWalletResponse> PostCreditWalletAsync(
            ExternalCreditWalletRequest externalCreditWalletRequest);
        ValueTask<ExternalDebitWalletResponse> PostDebitWalletAsync(
            ExternalDebitWalletRequest externalDebitWalletRequest);
        ValueTask<ExternalFreezeWalletResponse> PostFreezeWalletAsync(
            ExternalFreezeWalletRequest externalFreezeWalletRequest);
        ValueTask<ExternalUnfreezeWalletResponse> PostUnfreezeWalletAsync(
            ExternalUnfreezeWalletRequest externalUnfreezeWalletRequest);
        ValueTask<ExternalBatchDebitCustomerWalletsResponse> PostBatchDebitCustomerWalletsAsync(
            ExternalBatchDebitCustomerWalletsRequest externalBatchDebitCustomerWalletsRequest);
        ValueTask<ExternalBatchCreditCustomerWalletsResponse> PostBatchCreditCustomerWalletsAsync(
            ExternalBatchCreditCustomerWalletsRequest externalBatchCreditCustomerWalletsRequest);
        ValueTask<ExternalCustomerCreditCustomerWalletResponse> PostCustomerCreditCustomerWalletAsync(
            ExternalCustomerCreditCustomerWalletRequest externalCustomerCreditCustomerWalletRequest);
        ValueTask<ExternalFundMerchantSandBoxWalletResponse> PostFundMerchantSandBoxWalletAsync(
            ExternalFundMerchantSandBoxWalletRequest externalFundMerchantSandBoxWalletRequest);
    
    }
}
