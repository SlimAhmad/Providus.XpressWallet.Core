using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalMerchant;

namespace Providus.XpressWallet.Core.Brokers.XpressWallet
{
    internal partial interface IXpressWalletBroker
    {

        ValueTask<ExternalAccountVerificationResponse> PutAccountVerificationAsync(
            ExternalAccountVerificationRequest externalAccountVerificationRequest);

        ValueTask<ExternalResendVerificationResponse> PostResendVerificationAsync(
            ExternalResendVerificationRequest externalResendVerificationRequest);

        ValueTask<ExternalMerchantKYCResponse> PutMerchantKYCAsync(
            ExternalMerchantKYCRequest externalMerchantKYCRequest);

        ValueTask<ExternalMerchantProfileResponse> GetMerchantProfileAsync();
        ValueTask<ExternalUpdateMerchantProfileResponse> UpdateMerchantProfileAsync(
            ExternalUpdateMerchantProfileRequest externalUpdateMerchantProfileRequest );

        ValueTask<ExternalMerchantAccessKeysResponse> GetMerchantAccessKeysAsync();

        ValueTask<ExternalGenerateAccessKeysResponse> PostGenerateAccessKeysAsync();
        ValueTask<ExternalSwitchAccountModeResponse> PostSwitchAccountModeAsync(
            ExternalSwitchAccountModeRequest externalSwitchAccountModeRequest);
        ValueTask<ExternalMerchantRegistrationResponse> PostMerchantRegistrationAsync(
            ExternalMerchantRegistrationRequest externalMerchantRegistrationRequest);
        ValueTask<ExternalMerchantWalletResponse> GetMerchantWalletAsync();
    }
}
