using KellermanSoftware.CompareNetObjects;
using Moq;
using Providus.XpressWallet.Core.Brokers.DateTimes;
using Providus.XpressWallet.Core.Brokers.XpressWallet;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalUser;
using Providus.XpressWallet.Core.Services.Foundations.XpressWallet.User;
using RESTFulSense.Exceptions;
using System.Linq.Expressions;
using Tynamix.ObjectFiller;


namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.User
{
    public partial class UserServiceTests
    {

        private readonly Mock<IXpressWalletBroker> xPressWalletBrokerMock;
        private readonly Mock<IDateTimeBroker> dateTimeBrokerMock;
        private readonly ICompareLogic compareLogic;
        private readonly IUserService userService;

        public UserServiceTests()
        {
            xPressWalletBrokerMock = new Mock<IXpressWalletBroker>();
            dateTimeBrokerMock = new Mock<IDateTimeBroker>();
            compareLogic = new CompareLogic();

            userService = new UserService(
                xPressWalletBrokerMock.Object,
                dateTimeBroker: dateTimeBrokerMock.Object);
        }


        private Expression<Func<ExternalChangePasswordRequest, bool>> SameExternalChangePasswordRequestAs(
             ExternalChangePasswordRequest expectedExternalChangePasswordRequest)
        {
            return actualExternalChangePasswordRequest =>
                this.compareLogic.Compare(
                    expectedExternalChangePasswordRequest,
                    actualExternalChangePasswordRequest)
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

        private static List<string> GetRandomStringList() =>
          new Filler<List<string>>().Create();

        private static bool GetRandomBoolean() =>
            Randomizer<bool>.Create();

        private static Dictionary<string, int> CreateRandomDictionary() =>
            new Filler<Dictionary<string, int>>().Create();


        #region ChangePasswordRequest 

        private static dynamic CreateRandomChangePasswordRequestProperties()
        {
            return new
            {

                Password = GetRandomString(),
             
            };
        }




        #endregion

        #region ChangePasswordResponse 

        private static dynamic CreateRandomChangePasswordResponseProperties()
        {
            return new
            {
                
                 Status = GetRandomBoolean(),
                 Message = GetRandomString(),
    
            };
        }



        #endregion

        #region UserProfileResponse 

        private static dynamic CreateRandomUserProfileResponseProperties()
        {
            return new
            {

                Status = GetRandomBoolean(),
                Permissions = GetRandomStringList(),
                Data = GetRandomUserProfileResponseData(),
        

            };
        }

        private static dynamic GetRandomUserProfileResponseData()
        {
            return new
            {

                Id = GetRandomString(),
                Role = GetRandomString(),
                Email = GetRandomString(),
                LastName = GetRandomString(),
                FirstName = GetRandomString(),
                PhoneNumber = GetRandomString(),
                MerchantId = GetRandomString(),
                CreatedAt = GetRandomDate(),
                UpdatedAt = GetRandomDate(),
                Merchant = GetRandomUserProfileResponseMerchant(),



            };
        }

        private static dynamic GetRandomUserProfileResponseMerchant()
        {
            return new
            {

                Id = GetRandomString(),
                Email = GetRandomString(),
                Review = GetRandomString(),
                BusinessName = GetRandomString(),
                CanDebitCustomer = GetRandomBoolean(),
                ParentMerchant = new object(),
                CreatedAt = GetRandomDate(),
                Mode = GetRandomString(),
                Owner = GetRandomBoolean(),




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
