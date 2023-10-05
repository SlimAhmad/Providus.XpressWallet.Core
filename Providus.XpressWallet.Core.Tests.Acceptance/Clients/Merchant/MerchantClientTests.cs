using Providus.XpressWallet.Core.Clients;
using Providus.XpressWallet.Core.Clients.Auth;
using Providus.XpressWallet.Core.Models.Configurations;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalMerchant;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Merchant;
using Tynamix.ObjectFiller;
using WireMock.Server;

namespace Providus.XpressWallet.Core.Tests.Acceptance.Clients.Merchant
{
    public partial class MerchantClientTests : IDisposable
    {
        private readonly string apiKey;
        private readonly WireMockServer wireMockServer;
        private readonly IXpressWalletClient xPressWalletClient;

        public MerchantClientTests()
        {
            apiKey = GetRandomString();
            wireMockServer = WireMockServer.Start();

            var apiConfigurations = new ApiConfigurations
            {
                ApiUrl = wireMockServer.Url,
                ApiKey = apiKey,

            };

            xPressWalletClient = new XpressWalletClient(apiConfigurations);
        }

        private static DateTimeOffset GetRandomDate() =>
             new DateTimeRange(earliestDate: new DateTime()).GetValue();

        private static string GetRandomString() =>
            new MnemonicString().GetValue();


        private static ExternalResendVerificationRequest ConvertToMerchantRequest(ResendVerification resendVerification)
        {

            return new ExternalResendVerificationRequest
            {
                Email = resendVerification.Request.Email,
            };



        }
        private static ExternalMerchantRegistrationRequest ConvertToMerchantRequest(MerchantRegistration merchantRegistration)
        {

            return new ExternalMerchantRegistrationRequest
            {
                AccountNumber = merchantRegistration.Request.AccountNumber,
                Email = merchantRegistration.Request.Email,
                BusinessName = merchantRegistration.Request.BusinessName,
                BusinessType = merchantRegistration.Request.BusinessType,
                FirstName = merchantRegistration.Request.FirstName,
                LastName = merchantRegistration.Request.LastName,
                Password = merchantRegistration.Request.Password,
                PhoneNumber = merchantRegistration.Request.PhoneNumber,
                SendEmail = merchantRegistration.Request.SendEmail,

            };



        }
        private static ExternalSwitchAccountModeRequest ConvertToMerchantRequest(SwitchAccountMode switchAccountMode)
        {

            return new ExternalSwitchAccountModeRequest
            {
                Mode = switchAccountMode.Request.Mode,
            };

        }
        private static ExternalAccountVerificationRequest ConvertToMerchantRequest(AccountVerification accountVerification)
        {

            return new ExternalAccountVerificationRequest
            {
                ActivationCode = accountVerification.Request.ActivationCode,

            };



        }
        private static ExternalMerchantKYCRequest ConvertToMerchantRequest(MerchantKYC merchantKYC)
        {

            return new ExternalMerchantKYCRequest
            {
                CacPack = merchantKYC.Request.CacPack,
                DirectorsBVN = merchantKYC.Request.DirectorsBVN,
                MerchantId = merchantKYC.Request.MerchantId,
            };



        }
        private static ExternalUpdateMerchantProfileRequest ConvertToMerchantRequest(UpdateMerchantProfile updateMerchantProfile)
        {

            return new ExternalUpdateMerchantProfileRequest
            {
                CallbackURL = updateMerchantProfile.Request.CallbackURL,
                CanLogin = updateMerchantProfile.Request.CanLogin,
                SandboxCallbackURL = updateMerchantProfile.Request.SandboxCallbackURL,
                SendEmail = updateMerchantProfile.Request.SendEmail
            };



        }

        private static MerchantAccessKeys ConvertToMerchantResponse(
              ExternalMerchantAccessKeysResponse externalMerchantAccessKeysResponse)
        {
            return new MerchantAccessKeys
            {
                Response = new MerchantAccessKeysResponse
                {
                    Data = new MerchantAccessKeysResponse.DataResponse
                    {
                        PrivateKey = externalMerchantAccessKeysResponse.Data.PrivateKey,
                        PublicKey = externalMerchantAccessKeysResponse.Data.PublicKey,

                    },

                    Status = externalMerchantAccessKeysResponse.Status
                }
            };

        }
        private static MerchantProfile ConvertToMerchantResponse(
            ExternalMerchantProfileResponse externalMerchantProfileResponse)
        {
            return new MerchantProfile
            {
                Response = new MerchantProfileResponse
                {
                    Data = new MerchantProfileResponse.DataResponse
                    {
                        UpdatedAt = externalMerchantProfileResponse.Data.UpdatedAt,
                        Id = externalMerchantProfileResponse.Data.Id,
                        Email = externalMerchantProfileResponse.Data.Email,
                        CreatedAt = externalMerchantProfileResponse.Data.CreatedAt,
                        BusinessName = externalMerchantProfileResponse.Data.BusinessName,
                        AirtimeCharge = externalMerchantProfileResponse.Data.AirtimeCharge,
                        ApiKey = externalMerchantProfileResponse.Data.ApiKey,
                        AutoCardFunding = externalMerchantProfileResponse.Data.AutoCardFunding,
                        BaseCustomerWalletCredit = externalMerchantProfileResponse.Data.BaseCustomerWalletCredit,
                        BusinessType = externalMerchantProfileResponse.Data.BusinessType,
                        Bvn = externalMerchantProfileResponse.Data.Bvn,
                        BvnChargeV1 = externalMerchantProfileResponse.Data.BvnChargeV1,
                        BvnVerificationCharge = externalMerchantProfileResponse.Data.BvnVerificationCharge,
                        CallbackURL = externalMerchantProfileResponse.Data.CallbackURL,
                        CanLogin = externalMerchantProfileResponse.Data.CanLogin,
                        ContractCode = externalMerchantProfileResponse.Data.ContractCode,
                        FundingRate = externalMerchantProfileResponse.Data.FundingRate,
                        FundingRateMax = externalMerchantProfileResponse.Data.FundingRateMax,
                        MerchantType = externalMerchantProfileResponse.Data.MerchantType,
                        Mode = externalMerchantProfileResponse.Data.Mode,
                        PhoneNumber = externalMerchantProfileResponse.Data.PhoneNumber,
                        Review = externalMerchantProfileResponse.Data.Review,
                        SandboxCallbackURL = externalMerchantProfileResponse.Data.SandboxCallbackURL,
                        SecretKey = externalMerchantProfileResponse.Data.SecretKey,
                        SendEmail = externalMerchantProfileResponse.Data.SendEmail,
                        Slug = externalMerchantProfileResponse.Data.Slug,
                        Tier1DailyLimit = externalMerchantProfileResponse.Data.Tier1DailyLimit,
                        Tier1MinBalance = externalMerchantProfileResponse.Data.Tier1MinBalance,
                        Tier2DailyLimit = externalMerchantProfileResponse.Data.Tier2DailyLimit,
                        Tier2MinBalance = externalMerchantProfileResponse.Data.Tier2MinBalance,
                        Tier3DailyLimit = externalMerchantProfileResponse.Data.Tier3DailyLimit,
                        Tier3MinBalance = externalMerchantProfileResponse.Data.Tier3MinBalance,
                        TransferCharges = new MerchantProfileResponse.TransferCharges
                        {
                            Max5000 = externalMerchantProfileResponse.Data.TransferCharges.Max5000,
                            Max50000 = externalMerchantProfileResponse.Data.TransferCharges.Max50000,
                            Min50000 = externalMerchantProfileResponse.Data.TransferCharges.Min50000,

                        },
                        WalletReservationCharge = externalMerchantProfileResponse.Data.WalletReservationCharge,
                        WalletToWalletTransfer = externalMerchantProfileResponse.Data.WalletToWalletTransfer
                    },

                    Status = externalMerchantProfileResponse.Status
                }
            };

        }
        private static GenerateAccessKeys ConvertToMerchantResponse(
           ExternalGenerateAccessKeysResponse externalGenerateAccessKeysResponse)
        {
            return new GenerateAccessKeys
            {
                Response = new GenerateAccessKeysResponse
                {
                    Data = new GenerateAccessKeysResponse.DataResponse
                    {
                        PrivateKey = externalGenerateAccessKeysResponse.Data.PrivateKey,
                        PublicKey = externalGenerateAccessKeysResponse.Data.PublicKey,
                    },
                    Status = externalGenerateAccessKeysResponse.Status
                }
            };

        }
        private static MerchantWallet ConvertToMerchantResponse(
            ExternalMerchantWalletResponse externalMerchantWalletResponse)
        {
            return new MerchantWallet
            {
                Response = new MerchantWalletResponse
                {
                    Data = new MerchantWalletResponse.DataResponse
                    {
                        AccountName = externalMerchantWalletResponse.Data.AccountName,
                        AccountNumber = externalMerchantWalletResponse.Data.AccountNumber,
                        AccountReference = externalMerchantWalletResponse.Data.AccountReference,
                        AvailableBalance = externalMerchantWalletResponse.Data.AvailableBalance,
                        BankCode = externalMerchantWalletResponse.Data.BankCode,
                        BankName = externalMerchantWalletResponse.Data.BankName,
                        BookedBalance = externalMerchantWalletResponse.Data.BookedBalance,
                        BusinessName = externalMerchantWalletResponse.Data.BusinessName,
                        CreatedAt = externalMerchantWalletResponse.Data.CreatedAt,
                        Email = externalMerchantWalletResponse.Data.Email,
                        Id = externalMerchantWalletResponse.Data.Id,
                        UpdatedAt = externalMerchantWalletResponse.Data.UpdatedAt,
                    },

                    Status = externalMerchantWalletResponse.Status
                }
            };

        }
        private static MerchantRegistration ConvertToMerchantResponse(
            MerchantRegistration merchantRegistration,
            ExternalMerchantRegistrationResponse externalMerchantRegistrationResponse)
        {
            merchantRegistration.Response = new MerchantRegistrationResponse
            {
                Message = externalMerchantRegistrationResponse.Message,
                Status = externalMerchantRegistrationResponse.Status,
                RequireVerification = externalMerchantRegistrationResponse.RequireVerification,
            };
            return merchantRegistration;

        }
        private static ResendVerification ConvertToMerchantResponse(ResendVerification inAppToken, ExternalResendVerificationResponse externalResendVerificationResponse)
        {
            inAppToken.Response = new ResendVerificationResponse
            {
                Status = externalResendVerificationResponse.Status,
                Message = externalResendVerificationResponse.Message,
            };
            return inAppToken;

        }
        private static SwitchAccountMode ConvertToMerchantResponse(SwitchAccountMode switchAccountMode, ExternalSwitchAccountModeResponse externalSwitchAccountModeResponse)
        {
            switchAccountMode.Response = new SwitchAccountModeResponse
            {
                Message = externalSwitchAccountModeResponse.Message,
                Status = externalSwitchAccountModeResponse.Status
            };
            return switchAccountMode;

        }
        private static AccountVerification ConvertToMerchantResponse(AccountVerification accountVerification, ExternalAccountVerificationResponse externalAccountVerificationResponse)
        {
            accountVerification.Response = new AccountVerificationResponse
            {
                Status = externalAccountVerificationResponse.Status,
                Message = externalAccountVerificationResponse.Message,
            };
            return accountVerification;

        }
        private static MerchantKYC ConvertToMerchantResponse(MerchantKYC merchantKYC, ExternalMerchantKYCResponse externalMerchantKYCResponse)
        {
            merchantKYC.Response = new MerchantKYCResponse
            {
                Message = externalMerchantKYCResponse.Message,
                Status = externalMerchantKYCResponse.Status,
            };
            return merchantKYC;

        }
        private static UpdateMerchantProfile ConvertToMerchantResponse(UpdateMerchantProfile updateMerchantProfile, ExternalUpdateMerchantProfileResponse externalUpdateMerchantProfileResponse)
        {
            updateMerchantProfile.Response = new UpdateMerchantProfileResponse
            {
                Status = externalUpdateMerchantProfileResponse.Status,
                Message = externalUpdateMerchantProfileResponse.Message,
            };
            return updateMerchantProfile;

        }



        private static ExternalUpdateMerchantProfileResponse CreateExternalUpdateMerchantProfileResponseResult() =>
                CreateExternalUpdateMerchantProfileResponseFiller().Create();

        private static ExternalMerchantProfileResponse CreateExternalMerchantProfileResponseResult() =>
           CreateExternalMerchantProfileResponseFiller().Create();

        private static ExternalMerchantAccessKeysResponse CreateExternalMerchantAccessKeysResponseResult() =>
          CreateExternalMerchantAccessKeysResponseFiller().Create();

        private static ExternalMerchantWalletResponse CreateExternalMerchantWalletResponseResult() =>
           CreateExternalMerchantWalletResponseFiller().Create();
        private static ExternalAccountVerificationResponse CreateExternalAccountVerificationResponseResult() =>
            CreateExternalAccountVerificationResponseFiller().Create();

        private static ExternalResendVerificationResponse CreateExternalResendVerificationResponseResult() =>
            CreateExternalResendVerificationResponseFiller().Create();

        private static ExternalMerchantKYCResponse CreateExternalMerchantKYCResponseResult() =>
             CreateExternalMerchantKYCResponseFiller().Create();

        private static ExternalSwitchAccountModeResponse CreateExternalSwitchAccountModeResponseResult() =>
             CreateExternalSwitchAccountModeResponseFiller().Create();

        private static ExternalMerchantRegistrationResponse CreateExternalMerchantRegistrationResponseResult() =>
            CreateExternalMerchantRegistrationResponseFiller().Create();
        private static ExternalGenerateAccessKeysResponse CreateExternalGenerateAccessKeysResponseResult() =>
             CreateExternalGenerateAccessKeysResponseFiller().Create();


        private static UpdateMerchantProfile CreateUpdateMerchantProfileResponseResult() =>
          CreateUpdateMerchantProfileFiller().Create();
        private static AccountVerification CreateAccountVerificationResponseResult() =>
          CreateAccountVerificationFiller().Create();
        private static ResendVerification CreateResendVerificationResponseResult() =>
          CreateResendVerificationFiller().Create();
        private static MerchantKYC CreateMerchantKYCResponseResult() =>
          CreateMerchantKYCFiller().Create();
        private static SwitchAccountMode CreateSwitchAccountModeResponseResult() =>
          CreateSwitchAccountModeFiller().Create();
        private static MerchantRegistration CreateMerchantRegistrationResponseResult() =>
          CreateMerchantRegistrationFiller().Create();


        private static Filler<ExternalUpdateMerchantProfileResponse> CreateExternalUpdateMerchantProfileResponseFiller()
        {
            var filler = new Filler<ExternalUpdateMerchantProfileResponse>();

            filler.Setup()
               .OnType<object>().IgnoreIt();

            return filler;
        }
        private static Filler<ExternalMerchantProfileResponse> CreateExternalMerchantProfileResponseFiller()
        {
            var filler = new Filler<ExternalMerchantProfileResponse>();

            filler.Setup()
               .OnType<object>().IgnoreIt();

            return filler;
        }
        private static Filler<ExternalMerchantWalletResponse> CreateExternalMerchantWalletResponseFiller()
        {
            var filler = new Filler<ExternalMerchantWalletResponse>();

            filler.Setup()
               .OnType<object>().IgnoreIt();

            return filler;
        }
        private static Filler<ExternalMerchantAccessKeysResponse> CreateExternalMerchantAccessKeysResponseFiller()
        {
            var filler = new Filler<ExternalMerchantAccessKeysResponse>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<ExternalAccountVerificationResponse> CreateExternalAccountVerificationResponseFiller()
        {
            var filler = new Filler<ExternalAccountVerificationResponse>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<ExternalResendVerificationResponse> CreateExternalResendVerificationResponseFiller()
        {
            var filler = new Filler<ExternalResendVerificationResponse>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<ExternalMerchantKYCResponse> CreateExternalMerchantKYCResponseFiller()
        {
            var filler = new Filler<ExternalMerchantKYCResponse>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<ExternalSwitchAccountModeResponse> CreateExternalSwitchAccountModeResponseFiller()
        {
            var filler = new Filler<ExternalSwitchAccountModeResponse>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<ExternalMerchantRegistrationResponse> CreateExternalMerchantRegistrationResponseFiller()
        {
            var filler = new Filler<ExternalMerchantRegistrationResponse>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<ExternalGenerateAccessKeysResponse> CreateExternalGenerateAccessKeysResponseFiller()
        {
            var filler = new Filler<ExternalGenerateAccessKeysResponse>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }


        private static Filler<UpdateMerchantProfile> CreateUpdateMerchantProfileFiller()
        {
            var filler = new Filler<UpdateMerchantProfile>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<AccountVerification> CreateAccountVerificationFiller()
        {
            var filler = new Filler<AccountVerification>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<ResendVerification> CreateResendVerificationFiller()
        {
            var filler = new Filler<ResendVerification>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<MerchantKYC> CreateMerchantKYCFiller()
        {
            var filler = new Filler<MerchantKYC>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<SwitchAccountMode> CreateSwitchAccountModeFiller()
        {
            var filler = new Filler<SwitchAccountMode>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<MerchantRegistration> CreateMerchantRegistrationFiller()
        {
            var filler = new Filler<MerchantRegistration>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }
        public void Dispose() => wireMockServer.Stop();
    }
}
