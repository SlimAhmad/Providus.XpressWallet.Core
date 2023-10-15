using KellermanSoftware.CompareNetObjects;
using Moq;
using Providus.XpressWallet.Core.Brokers.DateTimes;
using Providus.XpressWallet.Core.Brokers.ProviPay;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalProviPay.ExternalPayment;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalProviPay.ExternalValidate;
using Providus.XpressWallet.Core.Services.Foundations.XpressWallet.BillPayment;
using RESTFulSense.Exceptions;
using System.Linq.Expressions;
using Tynamix.ObjectFiller;


namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.BillPayment
{
    public partial class BillPaymentServiceTests
    {

        private readonly Mock<IProviPayBroker> proviPayBrokerMock;
        private readonly Mock<IDateTimeBroker> dateTimeBrokerMock;
        private readonly ICompareLogic compareLogic;
        private readonly IBillPaymentService billPaymentService;

        public BillPaymentServiceTests()
        {
            proviPayBrokerMock = new Mock<IProviPayBroker>();
            dateTimeBrokerMock = new Mock<IDateTimeBroker>();
            compareLogic = new CompareLogic();

            billPaymentService = new BillPaymentService(
                proviPayBrokerMock.Object,
                dateTimeBroker: dateTimeBrokerMock.Object);
        }


        private Expression<Func<ExternalValidateRequest, bool>> SameExternalValidateRequestAs(
             ExternalValidateRequest expectedExternalValidateRequest)
        {
            return actualExternalValidateRequest =>
                this.compareLogic.Compare(
                    expectedExternalValidateRequest,
                    actualExternalValidateRequest)
                        .AreEqual;
        }

        private Expression<Func<ExternalPaymentRequest, bool>> SameExternalPaymentRequestAs(
                ExternalPaymentRequest expectedExternalPaymentRequest)
        {
            return actualExternalPaymentRequest =>
                this.compareLogic.Compare(
                    expectedExternalPaymentRequest,
                    actualExternalPaymentRequest)
                        .AreEqual;
        }

        private static DateTime GetRandomDate() =>
            new DateTimeRange(earliestDate: new DateTime()).GetValue();

        private static string GetRandomString() =>
           new MnemonicString().GetValue();

        private static int GetRandomNumber() =>
            new IntRange(min: 2, max: 10).GetValue();

        private static string[] CreateRandomStringArray() =>
            new Filler<string[]>().Create();

        private static List<string> CreateRandomStringList() =>
          new Filler<List<string>>().Create();

        private static bool GetRandomBoolean() =>
            Randomizer<bool>.Create();

        private static Dictionary<string, int> CreateRandomDictionary() =>
            new Filler<Dictionary<string, int>>().Create();


        #region ValidateRequest 

        private static dynamic CreateRandomValidateRequestProperties()
        {
            return new
            {

                Inputs = GetRandomValidateRequestInputs(),
                BillId = GetRandomString(),
                CustomerAccountNo = GetRandomString(),
                ChannelRef = GetRandomString(),


            };
        }

        private static List<dynamic> GetRandomValidateRequestInputs()
        {

            return Enumerable.Range(0, GetRandomNumber()).Select(
            item => new
            {

                Key = GetRandomString(),
                Value = GetRandomString(),
             

            }).ToList<dynamic>();

        }


        #endregion

        #region ValidateResponse 

        private static dynamic CreateRandomValidateResponseProperties()
        {
            return new
            {

                Balance = GetRandomString(),
                CustomerName = GetRandomString(),
                Message = GetRandomString(),
                Successful = GetRandomBoolean(),


            };
        }



        #endregion

        #region PaymentRequest 

        private static dynamic CreateRandomPaymentRequestProperties()
        {
            return new
            {

                Inputs = GetRandomPaymentRequestInputs(),
                BillId = GetRandomString(),
                CustomerAccountNo = GetRandomString(),
                ChannelRef = GetRandomString(),


            };
        }

        private static List<dynamic> GetRandomPaymentRequestInputs()
        {

            return Enumerable.Range(0, GetRandomNumber()).Select(
            item => new
            {

                Key = GetRandomString(),
                Value = GetRandomString(),


            }).ToList<dynamic>();

        }


        #endregion

        #region PaymentResponse 

        private static dynamic CreateRandomPaymentResponseProperties()
        {
            return new
            {

                Data = GetRandomString(),
                Message = GetRandomString(),
                ResponseCode = GetRandomString(),
                ResponseMessage = GetRandomString(),

            };
        }



        #endregion

        #region CategoriesResponse 

        private static List<dynamic> CreateRandomCategoriesResponseProperties()
        {

            return Enumerable.Range(0, GetRandomNumber()).Select(
            item => new
            {

                CategoryId = GetRandomNumber(),
                ListOrder = GetRandomString(),
                Name = GetRandomString(),


            }).ToList<dynamic>();

        }

        #endregion

        #region BillsByCategoryResponse 

        

        private static List<dynamic> CreateRandomBillsByCategoryResponseProperties()
        {

            return Enumerable.Range(0, GetRandomNumber()).Select(
            item => new
            {

                BillId = GetRandomNumber(),
                CategoryId = GetRandomString(),
                Description = GetRandomString(),
                ListOrder = GetRandomString(),
                Name = GetRandomString(),
                SourceId = GetRandomString(),


            }).ToList<dynamic>();

        }

        #endregion

        #region FieldsResponse 

        private static dynamic CreateRandomFieldsResponseProperties()
        {
            return new
            {

                BillId = GetRandomNumber(),
                Fee = GetRandomNumber(),
                FieldId = GetRandomNumber(),
                Fields = GetRandomFieldsResponseField(),
                Type = GetRandomString(),
                Validate = GetRandomString(),


            };
        }

        private static List<dynamic> GetRandomFieldsResponseField()
        {

            return Enumerable.Range(0, GetRandomNumber()).Select(
            item => new
            {

                CallTag = GetRandomString(),
                FieldType = GetRandomString(),
                Key = GetRandomString(),
                List = GetRandomFieldsResponseList(),
                Name = GetRandomString(),


            }).ToList<dynamic>();

        }

        private static List<dynamic> GetRandomFieldsResponseItem()
        {

            return Enumerable.Range(0, GetRandomNumber()).Select(
            item => new
            {

                Amount = GetRandomString(),
                Id = GetRandomString(),
                Name = GetRandomString(),


            }).ToList<dynamic>();

        }

        private static dynamic GetRandomFieldsResponseList()
        {
            return new
            {
                Items = GetRandomFieldsResponseItem(),
                ListType = GetRandomString(),
              
         


            };
        }



        #endregion

        #region PaymentInquiryResponse 

        private static dynamic CreateRandomPaymentInquiryResponseProperties()
        {
            return new
            {

                Status = GetRandomString(),
              

            };
        }

        #endregion


        public static TheoryData UnauthorizedExceptions()
        {
            return new TheoryData<HttpResponseException>
            {
                new HttpResponseUnauthorizedException(),
                new HttpResponseForbiddenException()
            };
        }



    }
}
