using Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment;
using Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.Categories;
using Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.Exceptions;
using Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.Fields;
using Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.Payment;
using Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.PaymentInquiry;
using Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.Validate;

namespace Providus.XpressWallet.Core.Services.Foundations.XpressWallet.BillPayment
{
    internal partial class BillPaymentService
    {
        private static void ValidateValidateCustomer(Validate update, string billId)
        {
            ValidateValidateCustomerNotNull(update);
            ValidateValidateCustomerRequest(update.Request);
            Validate(
                (Rule: IsInvalid(update.Request), Parameter: nameof(update.Request)));

            Validate(
                (Rule: IsInvalid(update.Request.BillId), Parameter: nameof(ValidateRequest.BillId)),
                (Rule: IsInvalid(update.Request.ChannelRef), Parameter: nameof(ValidateRequest.ChannelRef)),
                (Rule: IsInvalid(update.Request.CustomerAccountNo), Parameter: nameof(ValidateRequest.CustomerAccountNo)),
                (Rule: IsInvalid(update.Request.Inputs), Parameter: nameof(ValidateRequest.Inputs)),
                (Rule: IsInvalid(billId), Parameter: nameof(ValidateRequest))  
                );

        }

        private static void ValidatePayment(Payment payment)
        {
            ValidatePaymentNotNull(payment);
            ValidatePaymentRequest(payment.Request);
            Validate(
                (Rule: IsInvalid(payment.Request), Parameter: nameof(payment.Request)));

            Validate(
                (Rule: IsInvalid(payment.Request.BillId), Parameter: nameof(ValidateRequest.BillId)),
                (Rule: IsInvalid(payment.Request.ChannelRef), Parameter: nameof(ValidateRequest.ChannelRef)),
                (Rule: IsInvalid(payment.Request.CustomerAccountNo), Parameter: nameof(ValidateRequest.CustomerAccountNo)),
                (Rule: IsInvalid(payment.Request.Inputs), Parameter: nameof(ValidateRequest.Inputs))
                );

        }


        private static void ValidateValidateCustomerNotNull(Validate BillPayment)
        {
            if (BillPayment is null)
            {
                throw new NullBillPaymentException();
            }
        }

        private static void ValidateValidateCustomerRequest(ValidateRequest BillPaymentRequest)
        {
            Validate((Rule: IsInvalid(BillPaymentRequest), Parameter: nameof(ValidateRequest)));
        }

        private static void ValidatePaymentNotNull(Payment payment)
        {
            if (payment is null)
            {
                throw new NullBillPaymentException();
            }
        }

        private static void ValidatePaymentRequest(PaymentRequest paymentRequest)
        {
            Validate((Rule: IsInvalid(paymentRequest), Parameter: nameof(PaymentRequest)));
        }


        private static void ValidateBillsByCategoryParameters(string text) =>
             Validate((Rule: IsInvalid(text), Parameter: nameof(BillsByCategory)));
        private static void ValidateFieldsParameters(string text) =>
             Validate((Rule: IsInvalid(text), Parameter: nameof(Fields)));
        private static void ValidatePaymentInquiryParameters(string text) =>
            Validate((Rule: IsInvalid(text), Parameter: nameof(PaymentInquiry)));

        private static dynamic IsInvalid(object @object) => new
        {
            Condition = @object is null,
            Message = "Value is required"
        };


        private static dynamic IsInvalid(string text) => new
        {
            Condition = String.IsNullOrWhiteSpace(text),
            Message = "Value is required"
        };

        private static dynamic IsInvalid(double number) => new
        {
            Condition = number <= 0,
            Message = "Value is required"
        };

        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidBillPaymentException = new InvalidBillPaymentException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidBillPaymentException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidBillPaymentException.ThrowIfContainsErrors();
        }
    }
}