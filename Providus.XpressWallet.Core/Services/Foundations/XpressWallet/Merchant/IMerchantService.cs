using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Merchant;

namespace Providus.XpressWallet.Core.Services.Foundations.XpressWallet.Merchant
{
    internal interface IMerchantService
    {
        ValueTask<AccountVerification> PostAccountVerificationAsync(
                  AccountVerification externalAccountVerification);

        ValueTask<ResendVerification> PostResendVerificationAsync(
            ResendVerification externalResendVerification);

        ValueTask<MerchantKYC> PutMerchantKYCAsync(
            MerchantKYC externalMerchantKYC);

        ValueTask<MerchantProfile> GetMerchantProfileAsync();
        ValueTask<UpdateMerchantProfile> UpdateMerchantProfileAsync(
            UpdateMerchantProfile externalUpdateMerchantProfile);

        ValueTask<MerchantAccessKeys> GetMerchantAccessKeysAsync();

        ValueTask<GenerateAccessKeys> PostGenerateAccessKeysAsync();
        ValueTask<SwitchAccountMode> PostSwitchAccountModeAsync(
            SwitchAccountMode externalSwitchAccountMode);
        ValueTask<MerchantRegistration> PostMerchantRegistrationAsync(
            MerchantRegistration externalMerchantRegistration);
        ValueTask<MerchantWallet> GetMerchantWalletAsync();
    }
}
