using Providus.XpressWallet.Core.Brokers.DateTimes;
using Providus.XpressWallet.Core.Brokers.ProviPay;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalProviPay.ExternalCategories;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalProviPay.ExternalFields;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalProviPay.ExternalPayment;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalProviPay.ExternalPaymentInquiry;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalProviPay.ExternalValidate;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalTransfers;
using Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.Categories;
using Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.Fields;
using Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.Payment;
using Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.PaymentInquiry;
using Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.Validate;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transfers;

namespace Providus.XpressWallet.Core.Services.Foundations.XpressWallet.BillPayment
{
    internal partial class BillPaymentService : IBillPaymentService
    {
        private readonly IProviPayBroker proviPayBroker;
        private readonly IDateTimeBroker dateTimeBroker;

        public BillPaymentService(
            IProviPayBroker proviPayBroker,
            IDateTimeBroker dateTimeBroker)
        {
            this.proviPayBroker = proviPayBroker;
            this.dateTimeBroker = dateTimeBroker;
        }

        public ValueTask<Categories> GetCategoriesRequestAsync() =>
        TryCatch(async () =>
        {
         
            List<ExternalCategoriesResponse> externalCategoriesResponse = await proviPayBroker.GetCategoriesAsync();
            return ConvertToBillPaymentResponse(externalCategoriesResponse);
        });

        public ValueTask<BillsByCategory> GetBillsByCategoryRequestAsync(string categoryId) =>
        TryCatch(async () =>
        {
            ValidateBillsByCategoryParameters(categoryId);
            List<ExternalBillsByCategoryResponse> externalBillsByCategoryResponse = await proviPayBroker.GetBillsByCategoryAsync(categoryId);
            return ConvertToBillPaymentResponse(externalBillsByCategoryResponse);
        });

        public ValueTask<Fields> GetFieldsRequestAsync(string billId) =>
        TryCatch(async () =>
        {
            ValidateFieldsParameters(billId);
            ExternalFieldsResponse externalFieldsResponse = await proviPayBroker.GetFieldsAsync(billId);
            return ConvertToBillPaymentResponse(externalFieldsResponse);
        });

        public ValueTask<Validate> PostValidateCustomerRequestAsync(Validate 
            externalValidateRequest, string billId) =>
        TryCatch(async () =>
        {
            ValidateValidateCustomer(externalValidateRequest,billId);
            ExternalValidateRequest externalValidateCustomerRequest =
                ConvertToBillPaymentRequest(externalValidateRequest);
            ExternalValidateResponse externalValidateCustomerResponse =
                await proviPayBroker.PostValidateCustomerAsync(externalValidateCustomerRequest, billId);
            return ConvertToBillPaymentResponse(externalValidateRequest, externalValidateCustomerResponse);
        });

        public ValueTask<Payment> PostPaymentRequestAsync(Payment externalPayment) =>
        TryCatch(async () =>
        {
            ValidatePayment(externalPayment);
            ExternalPaymentRequest externalPaymentRequest =
                ConvertToBillPaymentRequest(externalPayment);
            ExternalPaymentResponse externalPaymentResponse =
                await proviPayBroker.PostPaymentAsync(externalPaymentRequest);
            return ConvertToBillPaymentResponse(externalPayment, externalPaymentResponse);
        });

        public ValueTask<PaymentInquiry> GetPaymentInquiryRequestAsync(string transactionReference) =>
        TryCatch(async () =>
        {
            ValidatePaymentInquiryParameters(transactionReference);
            ExternalPaymentInquiryResponse externalPaymentInquiryResponse = await proviPayBroker.GetPaymentInquiryAsync(transactionReference);
            return ConvertToBillPaymentResponse(externalPaymentInquiryResponse);
        });





        private static ExternalPaymentRequest ConvertToBillPaymentRequest(
            Payment payment)
        {

            return new ExternalPaymentRequest
            {
                BillId = payment.Request.BillId,
                ChannelRef = payment.Request.ChannelRef,
                CustomerAccountNo = payment.Request.CustomerAccountNo,
                Inputs = payment.Request.Inputs.Select(inputs =>
                {
                    return new ExternalPaymentRequest.Input
                    {
                        Key = inputs.Key,
                        Value = inputs.Value,
                    };
                }).ToList()
               
            };



        }
        private static Payment ConvertToBillPaymentResponse(
            Payment payment, ExternalPaymentResponse externalPaymentResponse)
        {
            payment.Response = new PaymentResponse
            {
                Data = externalPaymentResponse.Data,
                Message = externalPaymentResponse.Message,
                ResponseCode = externalPaymentResponse.ResponseCode,
                ResponseMessage = externalPaymentResponse.ResponseMessage,
            };
            return payment;

        }
        private static ExternalValidateRequest ConvertToBillPaymentRequest(
             Validate validate)
        {

            return new ExternalValidateRequest
            {
                BillId = validate.Request.BillId,
                ChannelRef = validate.Request.ChannelRef,
                CustomerAccountNo = validate.Request.CustomerAccountNo,
                Inputs = validate.Request.Inputs.Select(inputs =>
                {
                    return new ExternalValidateRequest.Input
                    {
                        Key = inputs.Key,
                        Value = inputs.Value,
                    };
                }).ToList()

            };



        }
        private static Validate ConvertToBillPaymentResponse(
            Validate payment, ExternalValidateResponse externalValidateResponse)
        {
            payment.Response = new ValidateResponse
            {
                Balance = externalValidateResponse.Balance,
                CustomerName = externalValidateResponse.CustomerName,
                Message = externalValidateResponse.Message,
                Successful = externalValidateResponse.Successful,
            };
            return payment;

        }

        private static PaymentInquiry ConvertToBillPaymentResponse(
             ExternalPaymentInquiryResponse externalPaymentInquiryResponse)
        {
            return new PaymentInquiry
            {
                Response = new PaymentInquiryResponse
                {
                   
                    Status = externalPaymentInquiryResponse.Status
                }
            };
           

        }

        private static BillsByCategory ConvertToBillPaymentResponse(
             List<ExternalBillsByCategoryResponse> externalBillsByCategoryResponse)
        {

            return new BillsByCategory
            {
                Response = externalBillsByCategoryResponse.Select(billsByCategory =>
                {
                    return new BillsByCategoryResponse
                    {
                        BillId = billsByCategory.BillId,
                        CategoryId = billsByCategory.CategoryId,
                        Description = billsByCategory.Description,
                        ListOrder = billsByCategory.ListOrder,
                        Name = billsByCategory.Name,
                        SourceId = billsByCategory.SourceId,
                    };
                }).ToList()
            };

        }
        private static Categories ConvertToBillPaymentResponse(
            List<ExternalCategoriesResponse> externalCategoriesResponse)
        {
            return new Categories
            {
                Response = externalCategoriesResponse.Select(categories =>
                {
                    return new CategoriesResponse
                    {
                        Name = categories.Name,
                        CategoryId = categories.CategoryId,
                        ListOrder = categories.ListOrder
                    };
                }).ToList()
            };
        

        }

        private static Fields ConvertToBillPaymentResponse(
          ExternalFieldsResponse externalFieldsResponse)
        {
            return new Fields
            {
                Response = new FieldsResponse
                {
                    BillId = externalFieldsResponse.BillId,
                    Fee = externalFieldsResponse.Fee,
                    FieldId = externalFieldsResponse.FieldId,
                    Type = externalFieldsResponse.Type,
                    Validate = externalFieldsResponse.Validate,
                    Fields = externalFieldsResponse.Fields.Select(fields =>
                    {
                        return new FieldsResponse.Field
                        {
                            Name = fields.Name,
                            CallTag = fields.CallTag,
                            FieldType = fields.FieldType,
                            Key = fields.Key,
                            List = new FieldsResponse.List
                            {
                               Items = fields.List.Items.Select(items =>
                               {
                                   return new FieldsResponse.Item
                                   {
                                       Amount = items.Amount,
                                       Id = items.Id,
                                       Name = items.Name,
                                   };
                               }).ToList(),
                               ListType = fields.List.ListType,
                             
                            }
                        };
                    }).ToList()
                }
            };


        }

    }
}
