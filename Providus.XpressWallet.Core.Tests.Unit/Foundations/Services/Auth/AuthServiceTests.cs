using KellermanSoftware.CompareNetObjects;
using Moq;
using Providus.XpressWallet.Core.Brokers.DateTimes;
using Providus.XpressWallet.Core.Brokers.XpressWallet;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalAuth;
using Providus.XpressWallet.Core.Services.Foundations.XpressWallet.Auth;
using System.Linq.Expressions;
using Tynamix.ObjectFiller;
using RESTFulSense.Exceptions;


namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.Auth
{
    public partial class AuthServiceTests
    {

        private readonly Mock<IXpressWalletBroker> xPressWalletBrokerMock;
        private readonly Mock<IDateTimeBroker> dateTimeBrokerMock;
        private readonly ICompareLogic compareLogic;
        private readonly IAuthService authService;

        public AuthServiceTests()
        {
            xPressWalletBrokerMock = new Mock<IXpressWalletBroker>();
            dateTimeBrokerMock = new Mock<IDateTimeBroker>();
            compareLogic = new CompareLogic();

            authService = new AuthService(
                xPressWalletBrokerMock.Object,
                dateTimeBroker: dateTimeBrokerMock.Object);
        }


        private Expression<Func<ExternalLoginRequest, bool>> SameExternalLoginRequestAs(
             ExternalLoginRequest expectedExternalLoginRequest)
        {
            return actualExternalLoginRequest =>
                this.compareLogic.Compare(
                    expectedExternalLoginRequest,
                    actualExternalLoginRequest)
                        .AreEqual;
        }

        private Expression<Func<ExternalForgetPasswordRequest, bool>> SameExternalForgetPasswordRequestAs(
            ExternalForgetPasswordRequest expectedExternalForgetPasswordRequest)
        {
            return actualExternalForgetPasswordRequest =>
                this.compareLogic.Compare(
                    expectedExternalForgetPasswordRequest,
                    actualExternalForgetPasswordRequest)
                        .AreEqual;
        }

        private Expression<Func<ExternalResetPasswordRequest, bool>> SameExternalResetPasswordRequestAs(
        ExternalResetPasswordRequest expectedExternalResetPasswordRequest)
        {
            return actualExternalResetPasswordRequest =>
                this.compareLogic.Compare(
                    expectedExternalResetPasswordRequest,
                    actualExternalResetPasswordRequest)
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


        #region LoginRequest 

        private static dynamic CreateRandomLoginRequestProperties()
        {
            return new
            {

                Email = GetRandomString(),
                Password = GetRandomString(),
            

            };
        }




        #endregion

        #region LoginResponse 

        private static dynamic CreateRandomLoginResponseProperties()
        {
            return new
            {
                
                 Status = GetRandomBoolean(),
                 Data = GetRandomLoginResponseData(),
                 Merchant = GetRandomLoginResponseMeta(),

            };
        }

        private static dynamic GetRandomLoginResponseData()
        {
            return new
            {

                Id = GetRandomString(),
                Role = GetRandomString(),
                Email = GetRandomString(),
                LastName = GetRandomString(),
                FirstName = GetRandomString(),
                CreatedAt = GetRandomDate(),
                UpdatedAt = GetRandomDate(),


            };
        }

        private static dynamic GetRandomLoginResponseMeta()
        {
            return new
            {

                Email = GetRandomString(),
                Id = GetRandomString(),
                LastName = GetRandomString(),
                Mode = GetRandomString(),
                Role = GetRandomString(),
                FirstName = GetRandomString(),
                Owner = GetRandomBoolean(),
                Review = GetRandomString(),
                CallbackURL = new object(),
                BusinessName = GetRandomString(),
                BusinessType = GetRandomString(),
                ParentMerchant = new object(),
                CanDebitCustomer = GetRandomBoolean(),
                SandboxCallbackURL = new object(),
                CreatedAt = GetRandomDate(),
                UpdatedAt = GetRandomDate(),



            };
        }

        #endregion

        #region LogoutResponse 

        private static dynamic CreateRandomLogoutResponseProperties()
        {
            return new
            {

                Status = GetRandomBoolean(),
                Message = GetRandomString(),
        

            };
        }


        #endregion

        #region ForgetPasswordRequest 

        private static dynamic CreateRandomForgetPasswordRequestProperties()
        {
            return new
            {

                
                Email = GetRandomString(),


            };
        }


        #endregion

        #region ForgetPasswordResponse 

        private static dynamic CreateRandomForgetPasswordResponseProperties()
        {
            return new
            {

                Status = GetRandomBoolean(),
                Message = GetRandomString(),


            };
        }


        #endregion

        #region ResetPasswordRequest 

        private static dynamic CreateRandomResetPasswordRequestProperties()
        {
            return new
            {

                Password = GetRandomString(),
                ResetCode = GetRandomString(),


            };
        }


        #endregion

        #region ResetPasswordResponse 

        private static dynamic CreateRandomResetPasswordResponseProperties()
        {
            return new
            {

                Status = GetRandomBoolean(),
                Message = GetRandomString(),


            };
        }


        #endregion

        #region RefreshTokensResponse 

        private static dynamic CreateRandomRefreshTokensResponseProperties()
        {
            return new
            {

                Status = GetRandomBoolean(),
                Data = GetRandomRefreshTokensResponseData(),
                Merchant = GetRandomRefreshTokensResponseMeta(),

            };
        }

        private static dynamic GetRandomRefreshTokensResponseData()
        {
            return new
            {

                Id = GetRandomString(),
                Role = GetRandomString(),
                Email = GetRandomString(),
                LastName = GetRandomString(),
                FirstName = GetRandomString(),
                CreatedAt = GetRandomDate(),
                UpdatedAt = GetRandomDate(),


            };
        }

        private static dynamic GetRandomRefreshTokensResponseMeta()
        {
            return new
            {

                Email = GetRandomString(),
                Id = GetRandomString(),
                LastName = GetRandomString(),
                Mode = GetRandomString(),
                Role = GetRandomString(),
                FirstName = GetRandomString(),
                Owner = GetRandomBoolean(),
                Review = GetRandomString(),
                CallbackURL = GetRandomString(),
                BusinessName = GetRandomString(),
                BusinessType = GetRandomString(),
                ParentMerchant = GetRandomString(),
                CanDebitCustomer = GetRandomBoolean(),
                SandboxCallbackURL = GetRandomString(),
                CreatedAt = GetRandomDate(),
                UpdatedAt = GetRandomDate(),



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
