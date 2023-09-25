using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transfers;

namespace Providus.XpressWallet.Core.Services.Foundations.XpressWallet.Transfers
{
    internal interface ITransfersService
    {
        ValueTask<BankList> GetBankListRequestAsync();
        ValueTask<BankAccountDetails> GetBankAccountDetailsRequestAsync(string sortCode, string accountNumber);
        ValueTask<MerchantBankTransfer> PostMerchantBankTransferRequestAsync(
            MerchantBankTransfer externalMerchantBankTransfer);
        ValueTask<CustomerBankTransfer> PostCustomerBankTransferRequestAsync(
            CustomerBankTransfer externalCustomerBankTransfer);
        ValueTask<MerchantBatchBankTransfer> PostMerchantBatchBankTransferRequestAsync(
            MerchantBatchBankTransfer externalMerchantBatchBankTransfer);
        ValueTask<CustomerToCustomerWalletTransfer> PostCustomerToCustomerWalletTransferRequestAsync(
            CustomerToCustomerWalletTransfer externalCustomerToCustomerWalletTransfer);
    }
}
