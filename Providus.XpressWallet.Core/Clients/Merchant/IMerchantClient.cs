using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Merchant;

namespace Providus.XpressWallet.Core.Clients.Merchant
{
    public interface IMerchantClient
    {

        ValueTask<AccountVerification> AccountVerificationAsync(
                     AccountVerification externalAccountVerification);

        ValueTask<ResendVerification> ResendVerificationAsync(
            ResendVerification externalResendVerification);

        ValueTask<MerchantKYC> MerchantKYCAsync(
            MerchantKYC externalMerchantKYC);

        ValueTask<MerchantProfile> RetrieveMerchantProfileAsync();
        ValueTask<UpdateMerchantProfile> UpdateMerchantProfileAsync(
            UpdateMerchantProfile externalUpdateMerchantProfile);

        ValueTask<MerchantAccessKeys> RetrieveMerchantAccessKeysAsync();

        ValueTask<GenerateAccessKeys> GenerateAccessKeysAsync();
        ValueTask<SwitchAccountMode> SwitchAccountModeAsync(
            SwitchAccountMode externalSwitchAccountMode);
        ValueTask<MerchantRegistration> MerchantRegistrationAsync(
            MerchantRegistration externalMerchantRegistration);
        ValueTask<MerchantWallet> RetrieveMerchantWalletAsync();
    }
}
