using KellermanSoftware.CompareNetObjects;
using Moq;
using Providus.XpressWallet.Core.Brokers.DateTimes;
using Providus.XpressWallet.Core.Brokers.XpressWallet;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalMerchant;
using Providus.XpressWallet.Core.Services.Foundations.XpressWallet.Merchant;
using System.Linq.Expressions;
using Tynamix.ObjectFiller;
using RESTFulSense.Exceptions;
using System.Net;
using Microsoft.AspNetCore.Http;
using FluentAssertions.Equivalency;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using System.Net.NetworkInformation;


namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.Merchant
{
    public partial class MerchantServiceTests
    {

        private readonly Mock<IXpressWalletBroker> xPressWalletBrokerMock;
        private readonly Mock<IDateTimeBroker> dateTimeBrokerMock;
        private readonly ICompareLogic compareLogic;
        private readonly IMerchantService merchantService;

        public MerchantServiceTests()
        {
            xPressWalletBrokerMock = new Mock<IXpressWalletBroker>();
            dateTimeBrokerMock = new Mock<IDateTimeBroker>();
            compareLogic = new CompareLogic();

            merchantService = new MerchantService(
                xPressWalletBrokerMock.Object,
                dateTimeBroker: dateTimeBrokerMock.Object);
        }


        private Expression<Func<ExternalAccountVerificationRequest, bool>> SameExternalAccountVerificationRequestAs(
             ExternalAccountVerificationRequest expectedExternalAccountVerificationRequest)
        {
            return actualExternalAccountVerificationRequest =>
                this.compareLogic.Compare(
                    expectedExternalAccountVerificationRequest,
                    actualExternalAccountVerificationRequest)
                        .AreEqual;
        }

        private Expression<Func<ExternalResendVerificationRequest, bool>> SameExternalResendVerificationRequestAs(
             ExternalResendVerificationRequest expectedExternalResendVerificationRequest)
        {
            return actualExternalResendVerificationRequest =>
                this.compareLogic.Compare(
                    expectedExternalResendVerificationRequest,
                    actualExternalResendVerificationRequest)
                        .AreEqual;
        }

        private Expression<Func<ExternalMerchantKYCRequest, bool>> SameExternalMerchantKYCRequestAs(
            ExternalMerchantKYCRequest expectedExternalMerchantKYCRequest)
        {
            return actualExternalMerchantKYCRequest =>
                this.compareLogic.Compare(
                    expectedExternalMerchantKYCRequest,
                    actualExternalMerchantKYCRequest)
                        .AreEqual;
        }

        private Expression<Func<ExternalUpdateMerchantProfileRequest, bool>> SameExternalUpdateMerchantProfileRequestAs(
            ExternalUpdateMerchantProfileRequest expectedExternalUpdateMerchantProfileRequest)
        {
            return actualExternalUpdateMerchantProfileRequest =>
                this.compareLogic.Compare(
                    expectedExternalUpdateMerchantProfileRequest,
                    actualExternalUpdateMerchantProfileRequest)
                        .AreEqual;
        }

        private Expression<Func<ExternalSwitchAccountModeRequest, bool>> SameExternalSwitchAccountModeRequestAs(
          ExternalSwitchAccountModeRequest expectedExternalSwitchAccountModeRequest)
        {
            return actualExternalSwitchAccountModeRequest =>
                this.compareLogic.Compare(
                    expectedExternalSwitchAccountModeRequest,
                    actualExternalSwitchAccountModeRequest)
                        .AreEqual;
        }

        private Expression<Func<ExternalMerchantRegistrationRequest, bool>> SameExternalMerchantRegistrationRequestAs(
           ExternalMerchantRegistrationRequest expectedExternalMerchantRegistrationRequest)
        {
            return actualExternalMerchantRegistrationRequest =>
                this.compareLogic.Compare(
                    expectedExternalMerchantRegistrationRequest,
                    actualExternalMerchantRegistrationRequest)
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

        private static IFormFile GetRandomIFormFile() 
        {
            var mockFormFile = new Mock<IFormFile>();
            mockFormFile.SetupGet(x => x.FileName).Returns(GetRandomString());
            mockFormFile.SetupGet(x => x.Length).Returns(GetRandomNumber());
            return mockFormFile.Object;
        }

        private static Dictionary<string, int> CreateRandomDictionary() =>
            new Filler<Dictionary<string, int>>().Create();


        #region AccountVerificationRequest 

        private static dynamic CreateRandomAccountVerificationRequestProperties()
        {
            return new
            {

                ActivationCode = GetRandomString(),

            };
        }




        #endregion

        #region AccountVerificationResponse 

        private static dynamic CreateRandomAccountVerificationResponseProperties()
        {
            return new
            {
                
                 Status = GetRandomBoolean(),
                 Message = GetRandomString(),
    
            };
        }


        #endregion

        #region ResendVerificationRequest 

        private static dynamic CreateRandomResendVerificationRequestProperties()
        {
            return new
            {

                Email = GetRandomString(),

            };
        }




        #endregion

        #region ResendVerificationResponse 

        private static dynamic CreateRandomResendVerificationResponseProperties()
        {
            return new
            {

                Status = GetRandomBoolean(),
                Message = GetRandomString(),

            };
        }


        #endregion

        #region MerchantKYCRequest 

        private static dynamic CreateRandomMerchantKYCRequestProperties()
        {
            return new
            {
                CacPack =GetRandomIFormFile(),
                DirectorsBVN = GetRandomString(),
                MerchantId = GetRandomString(),
            };
        }



        #endregion

        #region MerchantKYCResponse 

        private static dynamic CreateRandomMerchantKYCResponseProperties()
        {
            return new
            {

                Status = GetRandomBoolean(),
                Message = GetRandomString(),

            };
        }


        #endregion

        #region MerchantProfileResponse 

        private static dynamic CreateRandomMerchantProfileResponseProperties()
        {
            return new
            {

                Status = GetRandomBoolean(),
                Data = GetRandomMerchantProfileResponseData(),

            };
        }

        private static dynamic GetRandomMerchantProfileResponseData()
        {
            return new
            {

                Id = GetRandomString(),
                Bvn = GetRandomString(),
                Slug = GetRandomString(),
                Email = GetRandomString(),
                PhoneNumber = GetRandomString(),
                CallbackURL = GetRandomString(),
                BusinessName = GetRandomString(),
                BusinessType = GetRandomString(),
                MerchantType = GetRandomString(),
                Review = GetRandomString(),
                WalletReservationCharge = GetRandomNumber(),
                BvnChargeV1 = GetRandomNumber(),
                BvnVerificationCharge = GetRandomNumber(),
                WalletToWalletTransfer = GetRandomNumber(),
                AirtimeCharge = GetRandomNumber(),
                TransferCharges = GetRandomMerchantProfileResponseTransfer(),
                ContractCode = new object(),
                SecretKey = new object(),
                ApiKey = new object(),
                Mode = GetRandomString(),
                FundingRate = GetRandomNumber(),
                FundingRateMax = GetRandomNumber(),
                SandboxCallbackURL = GetRandomString(),
                Tier1DailyLimit = GetRandomNumber(),
                Tier2DailyLimit = GetRandomNumber(),
                Tier3DailyLimit = GetRandomNumber(),
                Tier1MinBalance = GetRandomNumber(),
                Tier2MinBalance = GetRandomNumber(),
                Tier3MinBalance = GetRandomNumber(),
                BaseCustomerWalletCredit = GetRandomNumber(),
                CanLogin = GetRandomBoolean(),
                SendEmail = GetRandomBoolean(),
                AutoCardFunding = GetRandomBoolean(),
                CreatedAt = GetRandomDate(),
                UpdatedAt = GetRandomDate(),





            };
        }

        private static dynamic GetRandomMerchantProfileResponseTransfer()
        {
            return new
            {

                Max5000 = GetRandomNumber(),
                Max50000 = GetRandomNumber(),
                Min50000 = GetRandomNumber(),



            };
        }
        #endregion

        #region UpdateMerchantProfileRequest 

        private static dynamic CreateRandomUpdateMerchantProfileRequestProperties()
        {
            return new
            {

                CanLogin = GetRandomBoolean(),
                SendEmail = GetRandomBoolean(),
                CallbackURL = GetRandomString(),
                SandboxCallbackURL = GetRandomString(),


            };
        }




        #endregion

        #region UpdateMerchantProfileResponse 

        private static dynamic CreateRandomUpdateMerchantProfileResponseProperties()
        {
            return new
            {

                Status = GetRandomBoolean(),
                Message = GetRandomString(),

            };
        }


        #endregion

        #region MerchantAccessKeysResponse 

        private static dynamic CreateRandomMerchantAccessKeysResponseProperties()
        {
            return new
            {

                Status = GetRandomBoolean(),
                Data = GetRandomMerchantAccessKeysResponseData(),

            };
        }

        private static dynamic GetRandomMerchantAccessKeysResponseData()
        {
            return new
            {

                PublicKey = GetRandomString(),
                PrivateKey = GetRandomString(),

            };
        }


        #endregion

        #region GenerateAccessKeysResponse 

        private static dynamic CreateRandomGenerateAccessKeysResponseProperties()
        {
            return new
            {

                Status = GetRandomBoolean(),
                Data = GetRandomGenerateAccessKeysResponseData(),

            };
        }

        private static dynamic GetRandomGenerateAccessKeysResponseData()
        {
            return new
            {

                PublicKey = GetRandomString(),
                PrivateKey = GetRandomString(),

            };
        }


        #endregion

        #region SwitchAccountModeRequest 

        private static dynamic CreateRandomSwitchAccountModeRequestProperties()
        {
            return new
            {

                Mode = GetRandomString(),

            };
        }




        #endregion

        #region SwitchAccountModeResponse 

        private static dynamic CreateRandomSwitchAccountModeResponseProperties()
        {
            return new
            {

                Status = GetRandomBoolean(),
                Message = GetRandomString(),

            };
        }


        #endregion

        #region MerchantRegistrationRequest 

        private static dynamic CreateRandomMerchantRegistrationRequestProperties()
        {
            return new
            {

                FirstName = GetRandomString(),
                LastName = GetRandomString(),
                Password = GetRandomString(),
                AccountNumber = GetRandomString(),
                PhoneNumber = GetRandomString(),
                BusinessName = GetRandomString(),
                Email = GetRandomString(),
                BusinessType = GetRandomString(),
                SendEmail = GetRandomBoolean(),

            };
        }




        #endregion

        #region MerchantRegistrationResponse 

        private static dynamic CreateRandomMerchantRegistrationResponseProperties()
        {
            return new
            {


                Status = GetRandomBoolean(),
                RequireVerification = GetRandomBoolean(),
                Message = GetRandomString(),


            };
        }


        #endregion

        #region MerchantWalletResponse 

        private static dynamic CreateRandomMerchantWalletResponseProperties()
        {
            return new
            {

                Status = GetRandomBoolean(),
                Data = GetRandomMerchantWalletResponseData(),

            };
        }

        private static dynamic GetRandomMerchantWalletResponseData()
        {
            return new
            {

                Id = GetRandomString(),
                Email = GetRandomString(),
                BankName = GetRandomString(),
                BankCode = GetRandomString(),
                AccountName = GetRandomString(),
                BusinessName = GetRandomString(),
                AccountNumber = GetRandomString(),
                BookedBalance = GetRandomNumber(),
                AvailableBalance = GetRandomNumber(),
                AccountReference = GetRandomString(),
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
