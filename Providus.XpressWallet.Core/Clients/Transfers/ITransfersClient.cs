using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transfers;

namespace Providus.XpressWallet.Core.Clients.Transfers
{
    public interface ITransfersClient
    {

        ValueTask<BankList> RetrieveBankListAsync();
        ValueTask<BankAccountDetails> RetrieveBankAccountDetailsAsync(string sortCode, string accountNumber);
        ValueTask<MerchantBankTransfer> MerchantBankTransferAsync(
            MerchantBankTransfer merchantBankTransfer);
        ValueTask<CustomerBankTransfer> CustomerBankTransferAsync(
            CustomerBankTransfer customerBankTransfer);
        ValueTask<MerchantBatchBankTransfer> MerchantBatchBankTransferAsync(
            MerchantBatchBankTransfer merchantBatchBankTransfer);
        ValueTask<CustomerToCustomerWalletTransfer> CustomerToCustomerWalletTransferAsync(
            CustomerToCustomerWalletTransfer customerToCustomerWalletTransfer);
    }
}
