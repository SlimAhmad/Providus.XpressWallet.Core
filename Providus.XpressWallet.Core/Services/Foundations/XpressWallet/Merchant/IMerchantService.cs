using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Merchant;

namespace Providus.XpressWallet.Core.Services.Foundations.XpressWallet.Merchant
{
    internal interface IMerchantService
    {
        ValueTask<AccountVerification> PostAccountVerificationRequestAsync(
                  AccountVerification externalAccountVerification);

        ValueTask<ResendVerification> PostResendVerificationRequestAsync(
            ResendVerification externalResendVerification);

        ValueTask<MerchantKYC> PutMerchantKYCRequestAsync(
            MerchantKYC externalMerchantKYC);

        ValueTask<MerchantProfile> GetMerchantProfileRequestAsync();
        ValueTask<UpdateMerchantProfile> UpdateMerchantProfileRequestAsync(
            UpdateMerchantProfile externalUpdateMerchantProfile);

        ValueTask<MerchantAccessKeys> GetMerchantAccessKeysRequestAsync();

        ValueTask<GenerateAccessKeys> PostGenerateAccessKeysRequestAsync();
        ValueTask<SwitchAccountMode> PostSwitchAccountModeRequestAsync(
            SwitchAccountMode externalSwitchAccountMode);
        ValueTask<MerchantRegistration> PostMerchantRegistrationRequestAsync(
            MerchantRegistration externalMerchantRegistration);
        ValueTask<MerchantWallet> GetMerchantWalletRequestAsync();
    }
}
