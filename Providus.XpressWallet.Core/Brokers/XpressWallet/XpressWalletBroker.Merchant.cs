using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalCustomers;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalMerchant;

namespace Providus.XpressWallet.Core.Brokers.XpressWallet
{
    internal partial class XpressWalletBroker
    {



        public async ValueTask<ExternalAccountVerificationResponse> PutAccountVerificationAsync(
          ExternalAccountVerificationRequest externalAccountVerificationRequest)
        {
            return await PutAsync<ExternalAccountVerificationRequest, ExternalAccountVerificationResponse>(
                    relativeUrl: $"merchant/verify",
                    content: externalAccountVerificationRequest);
        }

        public async ValueTask<ExternalResendVerificationResponse> PostResendVerificationAsync(
            ExternalResendVerificationRequest externalResendVerificationRequest)
        {
            return await PostAsync<ExternalResendVerificationRequest, ExternalResendVerificationResponse>(
                   relativeUrl: $"merchant/verify/resend",
                   content: externalResendVerificationRequest);
        }

        public async ValueTask<ExternalMerchantKYCResponse> PutMerchantKYCAsync(
            ExternalMerchantKYCRequest externalMerchantKYCRequest)
        {
            return await PutAsync<ExternalMerchantKYCRequest, ExternalMerchantKYCResponse>(
                   relativeUrl: $"merchant/complete-merchant-registration",
                   content: externalMerchantKYCRequest);
        }

        public async ValueTask<ExternalMerchantProfileResponse> GetMerchantProfileAsync()
        {
            return await GetAsync<ExternalMerchantProfileResponse>(
                        relativeUrl: $"merchant/profile");
        }
        public async ValueTask<ExternalUpdateMerchantProfileResponse> UpdateMerchantProfileAsync(
            ExternalUpdateMerchantProfileRequest externalUpdateMerchantProfileRequest)
        {
            return await PutAsync<ExternalUpdateMerchantProfileRequest, ExternalUpdateMerchantProfileResponse>(
                    relativeUrl: $"merchant/profile",
                    content: externalUpdateMerchantProfileRequest);
        }

        public async ValueTask<ExternalMerchantAccessKeysResponse> GetMerchantAccessKeysAsync()
        {
            return await GetAsync<ExternalMerchantAccessKeysResponse>(
                        relativeUrl: $"merchant/my-access-keys");
        }

        public async ValueTask<ExternalGenerateAccessKeysResponse> PostGenerateAccessKeysAsync()
        {
            return await PutAsync<ExternalGenerateAccessKeysResponse>(
                   relativeUrl: $"merchant/generate-access-keys",
                   content: null);
        }
        public async ValueTask<ExternalSwitchAccountModeResponse> PostSwitchAccountModeAsync(
            ExternalSwitchAccountModeRequest externalSwitchAccountModeRequest)
        {
            return await PutAsync<ExternalSwitchAccountModeRequest, ExternalSwitchAccountModeResponse>(
                   relativeUrl: $"merchant/account-mode",
                   content: externalSwitchAccountModeRequest);
        }
        public async ValueTask<ExternalMerchantRegistrationResponse> PostMerchantRegistrationAsync(
            ExternalMerchantRegistrationRequest externalMerchantRegistrationRequest)
        {
            return await PutAsync<ExternalMerchantRegistrationRequest, ExternalMerchantRegistrationResponse>(
                   relativeUrl: $"merchant",
                   content: externalMerchantRegistrationRequest);
        }
        public async ValueTask<ExternalMerchantWalletResponse> GetMerchantWalletAsync()
        {
            return await GetAsync<ExternalMerchantWalletResponse>(
                        relativeUrl: $"merchant/wallet");
        }



    }
}
