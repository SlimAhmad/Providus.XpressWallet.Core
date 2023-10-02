using Providus.XpressWallet.Core.Brokers.DateTimes;
using Providus.XpressWallet.Core.Brokers.XpressWallet;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalMerchant;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Merchant;

namespace Providus.XpressWallet.Core.Services.Foundations.XpressWallet.Merchant
{
    internal partial class MerchantService : IMerchantService
    {
        private readonly IXpressWalletBroker xPressWalletBroker;
        private readonly IDateTimeBroker dateTimeBroker;

        public MerchantService(
            IXpressWalletBroker xPressWalletBroker,
            IDateTimeBroker dateTimeBroker)
        {
            this.xPressWalletBroker = xPressWalletBroker;
            this.dateTimeBroker = dateTimeBroker;
        }

        public ValueTask<MerchantAccessKeys> GetMerchantAccessKeysRequestAsync() =>
        TryCatch(async () =>
        {
            ExternalMerchantAccessKeysResponse externalMerchantAccessKeysResponse = 
                await xPressWalletBroker.GetMerchantAccessKeysAsync();
            return ConvertToMerchantResponse(externalMerchantAccessKeysResponse);
        });
        public ValueTask<MerchantProfile> GetMerchantProfileRequestAsync()=>
        TryCatch(async () =>
        {

            ExternalMerchantProfileResponse externalMerchantProfileResponse =
                await xPressWalletBroker.GetMerchantProfileAsync();
            return ConvertToMerchantResponse(externalMerchantProfileResponse);
        });
        public ValueTask<MerchantWallet> GetMerchantWalletRequestAsync()=>
        TryCatch(async () =>
        {

            ExternalMerchantWalletResponse externalMerchantWalletResponse = 
                await xPressWalletBroker.GetMerchantWalletAsync();
            return ConvertToMerchantResponse(externalMerchantWalletResponse);
        });
        public ValueTask<GenerateAccessKeys> PostGenerateAccessKeysRequestAsync()=>
        TryCatch(async () =>
        {
            ExternalGenerateAccessKeysResponse externalGenerateAccessKeysResponse = 
                await xPressWalletBroker.PostGenerateAccessKeysAsync();
            return ConvertToMerchantResponse(externalGenerateAccessKeysResponse);
        });
        public ValueTask<MerchantRegistration> PostMerchantRegistrationRequestAsync(
            MerchantRegistration externalMerchantRegistration)=>
        TryCatch(async () =>
        {
            ValidateMerchantRegistration(externalMerchantRegistration);
            ExternalMerchantRegistrationRequest externalMerchantRegistrationRequest = ConvertToMerchantRequest(externalMerchantRegistration);
            ExternalMerchantRegistrationResponse externalMerchantRegistrationResponse = 
                await xPressWalletBroker.PostMerchantRegistrationAsync(externalMerchantRegistrationRequest);
            return ConvertToMerchantResponse(externalMerchantRegistration, externalMerchantRegistrationResponse);
        });
        public ValueTask<ResendVerification> PostResendVerificationRequestAsync(
            ResendVerification externalResendVerification)=>
        TryCatch(async () =>
        {
            ValidateResendVerification(externalResendVerification);
            ExternalResendVerificationRequest externalResendVerificationRequest = ConvertToMerchantRequest(externalResendVerification);
            ExternalResendVerificationResponse externalResendVerificationResponse = 
                await xPressWalletBroker.PostResendVerificationAsync(externalResendVerificationRequest);
            return ConvertToMerchantResponse(externalResendVerification, externalResendVerificationResponse);
        });
        public ValueTask<SwitchAccountMode> PostSwitchAccountModeRequestAsync(
            SwitchAccountMode externalSwitchAccountMode)=>
        TryCatch(async () =>
        {
            ValidateSwitchAccountMode(externalSwitchAccountMode);
            ExternalSwitchAccountModeRequest externalSwitchAccountModeRequest = ConvertToMerchantRequest(externalSwitchAccountMode);
            ExternalSwitchAccountModeResponse externalSwitchAccountModeResponse =
                await xPressWalletBroker.PostSwitchAccountModeAsync(externalSwitchAccountModeRequest);
            return ConvertToMerchantResponse(externalSwitchAccountMode, externalSwitchAccountModeResponse);
        });
        public ValueTask<AccountVerification> PostAccountVerificationRequestAsync(
            AccountVerification externalAccountVerification)=>
        TryCatch(async () =>
        {
            ValidateAccountVerification(externalAccountVerification);
            ExternalAccountVerificationRequest externalAccountVerificationRequest = ConvertToMerchantRequest(externalAccountVerification);
            ExternalAccountVerificationResponse externalAccountVerificationResponse =
                await xPressWalletBroker.PutAccountVerificationAsync(externalAccountVerificationRequest);
            return ConvertToMerchantResponse(externalAccountVerification, externalAccountVerificationResponse);
        });
        public ValueTask<MerchantKYC> PutMerchantKYCRequestAsync(
            MerchantKYC externalMerchantKYC)=>
        TryCatch(async () =>
        {
            ValidateMerchantKYC(externalMerchantKYC);
            ExternalMerchantKYCRequest externalMerchantKYCRequest = ConvertToMerchantRequest(externalMerchantKYC);
            ExternalMerchantKYCResponse externalMerchantKYCResponse = await xPressWalletBroker.PutMerchantKYCAsync(externalMerchantKYCRequest);
            return ConvertToMerchantResponse(externalMerchantKYC, externalMerchantKYCResponse);
        });
        public ValueTask<UpdateMerchantProfile> UpdateMerchantProfileRequestAsync(
            UpdateMerchantProfile externalUpdateMerchantProfile)=>
        TryCatch(async () =>
        {
            ValidateUpdateMerchantProfile(externalUpdateMerchantProfile);
            ExternalUpdateMerchantProfileRequest externalUpdateMerchantProfileRequest = ConvertToMerchantRequest(externalUpdateMerchantProfile);
            ExternalUpdateMerchantProfileResponse externalUpdateMerchantProfileResponse =
                await xPressWalletBroker.UpdateMerchantProfileAsync(externalUpdateMerchantProfileRequest);
            return ConvertToMerchantResponse(externalUpdateMerchantProfile, externalUpdateMerchantProfileResponse);
        });


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


    }
}
