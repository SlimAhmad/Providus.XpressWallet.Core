using Providus.XpressWallet.Core.Clients;
using Providus.XpressWallet.Core.Clients.Auth;
using Providus.XpressWallet.Core.Models.Configurations;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalProviPay.ExternalCategories;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalProviPay.ExternalFields;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalProviPay.ExternalPayment;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalProviPay.ExternalPaymentInquiry;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalProviPay.ExternalValidate;
using Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.Categories;
using Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.Fields;
using Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.Payment;
using Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.PaymentInquiry;
using Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.Validate;
using Tynamix.ObjectFiller;
using WireMock.Server;

namespace Providus.XpressWallet.Core.Tests.Acceptance.Clients.BillPayment
{
    public partial class BillPaymentClientTests : IDisposable
    {
        private readonly string userName;
        private readonly string password;
        private readonly WireMockServer wireMockServer;
        private readonly IXpressWalletClient xPressWalletClient;

        public BillPaymentClientTests()
        {
            userName = GetRandomString();
            password = GetRandomString();
            wireMockServer = WireMockServer.Start();

            var apiConfigurations = new ApiConfigurations
            {
                ApiUrl = wireMockServer.Url,
                UserName = userName,
                Password = password

            };

            xPressWalletClient = new XpressWalletClient(apiConfigurations);
        }

        private static DateTimeOffset GetRandomDate() =>
             new DateTimeRange(earliestDate: new DateTime()).GetValue();

        private static string GetRandomString() =>
            new MnemonicString().GetValue();

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


        private static ExternalValidateResponse CreateExternalValidateResponseResult() =>
                CreateExternalValidateResponseFiller().Create();
        private static ExternalPaymentResponse CreateExternalPaymentResponseResult() =>
          CreateExternalPaymentResponseFiller().Create();

        private static List<ExternalBillsByCategoryResponse> CreateExternalBillsByCategoryResponseResult() =>
           CreateExternalBillsByCategoryResponseFiller().Create();

        private static List<ExternalCategoriesResponse> CreateExternalCategoriesResponseResult() =>
          CreateExternalCategoriesResponseFiller().Create();

        private static ExternalFieldsResponse CreateExternalFieldsResponseResult() =>
           CreateExternalExternalFieldsResponseFiller().Create();

        private static ExternalPaymentInquiryResponse CreateExternalPaymentInquiryResponseResult() =>
          CreateExternalPaymentInquiryResponseFiller().Create();


        private static Validate CreateValidateResponseResult() =>
          CreateValidateFiller().Create();
        private static Payment CreatePaymentResponseResult() =>
          CreatePaymentFiller().Create();


        private static Filler<ExternalValidateResponse> CreateExternalValidateResponseFiller()
        {
            var filler = new Filler<ExternalValidateResponse>();

            filler.Setup()
               .OnType<object>().IgnoreIt();

            return filler;
        }
        private static Filler<ExternalPaymentResponse> CreateExternalPaymentResponseFiller()
        {
            var filler = new Filler<ExternalPaymentResponse>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<List<ExternalBillsByCategoryResponse>> CreateExternalBillsByCategoryResponseFiller()
        {
            var filler = new Filler<List<ExternalBillsByCategoryResponse>>();

            filler.Setup()
               .OnType<object>().IgnoreIt();

            return filler;
        }
        private static Filler<ExternalFieldsResponse> CreateExternalExternalFieldsResponseFiller()
        {
            var filler = new Filler<ExternalFieldsResponse>();

            filler.Setup()
               .OnType<object>().IgnoreIt();

            return filler;
        }
        private static Filler<List<ExternalCategoriesResponse>> CreateExternalCategoriesResponseFiller()
        {
            var filler = new Filler<List<ExternalCategoriesResponse>>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<ExternalPaymentInquiryResponse> CreateExternalPaymentInquiryResponseFiller()
        {
            var filler = new Filler<ExternalPaymentInquiryResponse>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }

        private static Filler<Validate> CreateValidateFiller()
        {
            var filler = new Filler<Validate>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<Payment> CreatePaymentFiller()
        {
            var filler = new Filler<Payment>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }

        public void Dispose() => wireMockServer.Stop();
    }
}
