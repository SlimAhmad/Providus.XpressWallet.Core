using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalProviPay.ExternalCategories;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalProviPay.ExternalFields;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalProviPay.ExternalPayment;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalProviPay.ExternalPaymentInquiry;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalProviPay.ExternalValidate;

namespace Providus.XpressWallet.Core.Brokers.ProviPay
{
    internal partial interface IProviPayBroker
    {

        ValueTask<List<ExternalCategoriesResponse>> GetCategoriesAsync();
        ValueTask<List<ExternalBillsByCategoryResponse>> GetBillsByCategoryAsync(string categoryId);
        ValueTask<ExternalFieldsResponse> GetFieldsAsync(string billId);
        ValueTask<ExternalValidateResponse> PostValidateCustomerAsync(
            ExternalValidateRequest externalValidateRequest, string billId);
        ValueTask<ExternalPaymentResponse> PostPaymentAsync(
            ExternalPaymentRequest externalPaymentRequest);
        ValueTask<ExternalPaymentInquiryResponse> GetPaymentInquiryAsync(string transactionReference);

    }
}
