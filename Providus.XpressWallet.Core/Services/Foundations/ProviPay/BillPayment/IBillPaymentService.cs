using Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.Categories;
using Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.Fields;
using Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.Payment;
using Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.PaymentInquiry;
using Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.Validate;

namespace Providus.XpressWallet.Core.Services.Foundations.XpressWallet.BillPayment
{
    internal interface IBillPaymentService
    {
        ValueTask<Categories> GetCategoriesRequestAsync();
        ValueTask<BillsByCategory> GetBillsByCategoryRequestAsync(string categoryId);
        ValueTask<Fields> GetFieldsRequestAsync(string billId);
        ValueTask<Validate> PostValidateCustomerRequestAsync(
            Validate externalValidate, string billId);
        ValueTask<Payment> PostPaymentRequestAsync(
            Payment externalPayment);
        ValueTask<PaymentInquiry> GetPaymentInquiryRequestAsync(string transactionReference);
    }
}
