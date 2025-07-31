using KellermanSoftware.CompareNetObjects;
using Moq;
using Providus.XpressWallet.Core.Brokers.DateTimes;
using Providus.XpressWallet.Core.Brokers.XpressWallet;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalCard;
using Providus.XpressWallet.Core.Services.Foundations.XpressWallet.Card;
using System.Linq.Expressions;
using Tynamix.ObjectFiller;
using RESTFulSense.Exceptions;


namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.Card
{
    public partial class CardServiceTests
    {

        private readonly Mock<IXpressWalletBroker> xPressWalletBrokerMock;
        private readonly Mock<IDateTimeBroker> dateTimeBrokerMock;
        private readonly ICompareLogic compareLogic;
        private readonly ICardService authService;

        public CardServiceTests()
        {
            xPressWalletBrokerMock = new Mock<IXpressWalletBroker>();
            dateTimeBrokerMock = new Mock<IDateTimeBroker>();
            compareLogic = new CompareLogic();

            authService = new CardService(
                xPressWalletBrokerMock.Object,
                dateTimeBroker: dateTimeBrokerMock.Object);
        }


        private Expression<Func<ExternalCardSetupRequest, bool>> SameExternalCardSetupRequestAs(
             ExternalCardSetupRequest expectedExternalCardSetupRequest)
        {
            return actualExternalCardSetupRequest =>
                this.compareLogic.Compare(
                    expectedExternalCardSetupRequest,
                    actualExternalCardSetupRequest)
                        .AreEqual;
        }

        private Expression<Func<ExternalCreateCardRequest, bool>> SameExternalCreateCardRequestAs(
            ExternalCreateCardRequest expectedExternalCreateCardRequest)
        {
            return actualExternalCreateCardRequest =>
                this.compareLogic.Compare(
                    expectedExternalCreateCardRequest,
                    actualExternalCreateCardRequest)
                        .AreEqual;
        }

        private Expression<Func<ExternalActivateCardRequest, bool>> SameExternalActivateCardRequestAs(
        ExternalActivateCardRequest expectedExternalActivateCardRequest)
        {
            return actualExternalActivateCardRequest =>
                this.compareLogic.Compare(
                    expectedExternalActivateCardRequest,
                    actualExternalActivateCardRequest)
                        .AreEqual;
        }

        private Expression<Func<ExternalFundCardRequest, bool>> SameExternalFundCardRequestAs(
       ExternalFundCardRequest expectedExternalFundCardRequest)
        {
            return actualExternalFundCardRequest =>
                this.compareLogic.Compare(
                    expectedExternalFundCardRequest,
                    actualExternalFundCardRequest)
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


        #region CardSetupRequest 

        private static dynamic CreateRandomCardSetupRequestProperties()
        {
            return new
            {

                AppId = GetRandomString(),
                AppKey = GetRandomString(),
                PrepaidCardPrefix = GetRandomString(),
                LoadingAccountName = GetRandomString(),
                LoadingAccountNumber = GetRandomString(),
                LoadingAccountSortcode = GetRandomString(),



            };
        }




        #endregion

        #region CardSetupResponse 

        private static dynamic CreateRandomCardSetupResponseProperties()
        {
            return new
            {
                
                 Status = GetRandomBoolean(),
                 Message = GetRandomString(),
    
            };
        }



        #endregion

        #region BalanceResponse 

        private static dynamic CreateRandomBalanceResponseProperties()
        {
            return new
            {

                Status = GetRandomBoolean(),
                Data = GetRandomBalanceResponseData(),
        

            };
        }

        private static dynamic GetRandomBalanceResponseData()
        {
            return new
            {

                Id = GetRandomString(),
                LedgerBalance = GetRandomString(),
                AvailableBalance = GetRandomString(),
                GoodsLimit = GetRandomString(),
                GoodsNrTransLimit = GetRandomString(),
                CashLimit = GetRandomString(),
                CashNrTransLimit = GetRandomString(),
                PaymentLimit = GetRandomString(),
                PaymentNrTransLimit = GetRandomString(),
                CardNotPresentLimit = GetRandomString(),
                DepositCreditLimit = GetRandomString(),
                UpdatedAt = GetRandomDate(),
                CreatedAt = GetRandomDate(),
                DeletedAt = new object(),



            };
        }

        #endregion

        #region CreateCardRequest 

        private static dynamic CreateRandomCreateCardRequestProperties()
        {
            return new
            {
                Address1 = GetRandomString(),
                Address2 = GetRandomString(),
                CustomerId = GetRandomString(),

            };
        }


        #endregion

        #region CreateCardResponse 

        private static dynamic CreateRandomCreateCardResponseProperties()
        {
            return new
            {

                Status = GetRandomBoolean(),
                Message = GetRandomString(),


            };
        }


        #endregion

        #region ActivateCardRequest 

        private static dynamic CreateRandomActivateCardRequestProperties()
        {
            return new
            {

                Last6 = GetRandomString(),
                CustomerId = GetRandomString(),


            };
        }


        #endregion

        #region ActivateCardResponse 

        private static dynamic CreateRandomActivateCardResponseProperties()
        {
            return new
            {

                Status = GetRandomBoolean(),
                Message = GetRandomString(),


            };
        }


        #endregion

        #region FundCardRequest 

        private static dynamic CreateRandomFundCardRequestProperties()
        {
            return new
            {

                Amount = GetRandomNumber(),
                CustomerId = GetRandomString(),


            };
        }


        #endregion

        #region FundCardResponse 

        private static dynamic CreateRandomFundCardResponseProperties()
        {
            return new
            {

                Status = GetRandomBoolean(),
                Message = GetRandomString(),


            };
        }


        #endregion



        public static TheoryData<HttpResponseException> UnauthorizedExceptions()
        {
            return new TheoryData<HttpResponseException>
            {
                new HttpResponseUnauthorizedException(),
                new HttpResponseForbiddenException()
            };
        }



    }
}
