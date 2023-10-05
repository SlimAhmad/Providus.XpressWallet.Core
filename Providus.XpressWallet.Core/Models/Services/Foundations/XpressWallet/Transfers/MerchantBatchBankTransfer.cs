namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transfers
{
    public class MerchantBatchBankTransfer
    {
        public List<MerchantBatchBankTransferRequest> Request { get; set; }

        public MerchantBatchBankTransferResponse Response { get; set; }
    }
}
