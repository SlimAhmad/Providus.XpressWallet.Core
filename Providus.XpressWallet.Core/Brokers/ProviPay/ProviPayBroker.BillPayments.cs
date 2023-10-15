using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalProviPay.ExternalCategories;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalProviPay.ExternalFields;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalProviPay.ExternalPayment;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalProviPay.ExternalPaymentInquiry;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalProviPay.ExternalValidate;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalCustomers;


namespace Providus.XpressWallet.Core.Brokers.ProviPay
{
    internal partial class ProviPayBroker
    {



        public async ValueTask<List<ExternalCategoriesResponse>> GetCategoriesAsync()
        {
            return await GetAsync<List<ExternalCategoriesResponse>>(
                    relativeUrl: $"provipay/webapi/categories");
        }
        public async ValueTask<List<ExternalBillsByCategoryResponse>> GetBillsByCategoryAsync(string categoryId)
        
        {
            return await GetAsync<List<ExternalBillsByCategoryResponse>>(
                    relativeUrl: $"provipay/webapi/bill/assigned/byCategoryId/{categoryId}");
        }
        public async ValueTask<ExternalFieldsResponse> GetFieldsAsync(string billId)
        {
            return await GetAsync<ExternalFieldsResponse>(
                    relativeUrl: $"provipay/webapi/field/assigned/byBillId/{billId}");
        }
        public async ValueTask<ExternalValidateResponse> PostValidateCustomerAsync(
            ExternalValidateRequest externalValidateRequest,string billId)
        
        {
            return await PostAsync<ExternalValidateRequest, ExternalValidateResponse>(
                        relativeUrl: $"provipay/webapi/validate/{billId}/customer",
                        content: externalValidateRequest);
        }
        public async ValueTask<ExternalPaymentResponse> PostPaymentAsync(
          ExternalPaymentRequest externalPaymentRequest)

        {
            return await PostAsync<ExternalPaymentRequest, ExternalPaymentResponse>(
                        relativeUrl: $"provipay/webapi/makepayment",
                        content: externalPaymentRequest);
        }
        public async ValueTask<ExternalPaymentInquiryResponse> GetPaymentInquiryAsync(string transactionReference)
        {
            return await GetAsync<ExternalPaymentInquiryResponse>(
                    relativeUrl: $"provipay/webapi/makepayment/enquiry?txn_ref={transactionReference}");
        }
    }
}
