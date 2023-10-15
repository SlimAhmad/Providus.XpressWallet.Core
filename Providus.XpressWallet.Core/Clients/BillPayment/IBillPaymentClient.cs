using Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.Categories;
using Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.Fields;
using Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.Payment;
using Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.PaymentInquiry;
using Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.Validate;

namespace Providus.XpressWallet.Core.Clients.BillPayment
{
    public interface IBillPaymentClient
    {

        ValueTask<Categories> RetrieveCategoriesAsync();
        ValueTask<BillsByCategory> RetrieveBillsByCategoryAsync(string categoryId);
        ValueTask<Fields> RetrieveFieldsAsync(string billId);
        ValueTask<Validate> ValidateCustomerAsync(
            Validate externalValidate, string billId);
        ValueTask<Payment> ChargePaymentAsync(
            Payment externalPayment);
        ValueTask<PaymentInquiry> RetrievePaymentInquiryAsync(string transactionReference);
    }
}
