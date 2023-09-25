using Providus.XpressWallet.Core.Models.Clients.Merchant.Exceptions;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Merchant;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Merchant.Exceptions;
using Providus.XpressWallet.Core.Services.Foundations.XpressWallet.Merchant;
using Xeptions;

namespace Providus.XpressWallet.Core.Clients.Merchant
{
    internal class MerchantClient : IMerchantClient
    {
        private readonly IMerchantService merchantService;

        public MerchantClient(IMerchantService merchantsService) =>
            merchantService = merchantsService;

        public async ValueTask<AccountVerification> AccountVerificationAsync(AccountVerification accountVerification)
        {
            try
            {
                return await merchantService.PostAccountVerificationAsync(accountVerification);
            }
            catch (MerchantValidationException merchantValidationException)
            {

                throw new MerchantClientValidationException(
                    merchantValidationException.InnerException as Xeption);
            }
            catch (MerchantDependencyValidationException merchantDependencyValidationException)
            {


                throw new MerchantClientValidationException(
                    merchantDependencyValidationException.InnerException as Xeption);
            }
            catch (MerchantDependencyException MerchantDependencyException)
            {
                throw new MerchantClientDependencyException(
                    MerchantDependencyException.InnerException as Xeption);
            }
            catch (MerchantServiceException MerchantServiceException)
            {
                throw new MerchantClientServiceException(
                    MerchantServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<GenerateAccessKeys> GenerateAccessKeysAsync()
        {
            try
            {
                return await merchantService.PostGenerateAccessKeysAsync();
            }
            catch (MerchantValidationException merchantValidationException)
            {

                throw new MerchantClientValidationException(
                    merchantValidationException.InnerException as Xeption);
            }
            catch (MerchantDependencyValidationException merchantDependencyValidationException)
            {


                throw new MerchantClientValidationException(
                    merchantDependencyValidationException.InnerException as Xeption);
            }
            catch (MerchantDependencyException MerchantDependencyException)
            {
                throw new MerchantClientDependencyException(
                    MerchantDependencyException.InnerException as Xeption);
            }
            catch (MerchantServiceException MerchantServiceException)
            {
                throw new MerchantClientServiceException(
                    MerchantServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<MerchantKYC> MerchantKYCAsync(MerchantKYC merchantKYC)
        {
             try
            {
                return await merchantService.PutMerchantKYCAsync(merchantKYC);
            }
            catch (MerchantValidationException merchantValidationException)
            {

                throw new MerchantClientValidationException(
                    merchantValidationException.InnerException as Xeption);
            }
            catch (MerchantDependencyValidationException merchantDependencyValidationException)
            {


                throw new MerchantClientValidationException(
                    merchantDependencyValidationException.InnerException as Xeption);
            }
            catch (MerchantDependencyException MerchantDependencyException)
            {
                throw new MerchantClientDependencyException(
                    MerchantDependencyException.InnerException as Xeption);
            }
            catch (MerchantServiceException MerchantServiceException)
            {
                throw new MerchantClientServiceException(
                    MerchantServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<MerchantRegistration> MerchantRegistrationAsync(MerchantRegistration merchantRegistration)
        {
             try
            {
                return await merchantService.PostMerchantRegistrationAsync(merchantRegistration);
            }
            catch (MerchantValidationException merchantValidationException)
            {

                throw new MerchantClientValidationException(
                    merchantValidationException.InnerException as Xeption);
            }
            catch (MerchantDependencyValidationException merchantDependencyValidationException)
            {


                throw new MerchantClientValidationException(
                    merchantDependencyValidationException.InnerException as Xeption);
            }
            catch (MerchantDependencyException MerchantDependencyException)
            {
                throw new MerchantClientDependencyException(
                    MerchantDependencyException.InnerException as Xeption);
            }
            catch (MerchantServiceException MerchantServiceException)
            {
                throw new MerchantClientServiceException(
                    MerchantServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<ResendVerification> ResendVerificationAsync(ResendVerification resendVerification)
        {
             try
            {
                return await merchantService.PostResendVerificationAsync(resendVerification);
            }
            catch (MerchantValidationException merchantValidationException)
            {

                throw new MerchantClientValidationException(
                    merchantValidationException.InnerException as Xeption);
            }
            catch (MerchantDependencyValidationException merchantDependencyValidationException)
            {


                throw new MerchantClientValidationException(
                    merchantDependencyValidationException.InnerException as Xeption);
            }
            catch (MerchantDependencyException MerchantDependencyException)
            {
                throw new MerchantClientDependencyException(
                    MerchantDependencyException.InnerException as Xeption);
            }
            catch (MerchantServiceException MerchantServiceException)
            {
                throw new MerchantClientServiceException(
                    MerchantServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<MerchantAccessKeys> RetrieveMerchantAccessKeysAsync()
        {
             try
            {
                return await merchantService.GetMerchantAccessKeysAsync();
            }
            catch (MerchantValidationException merchantValidationException)
            {

                throw new MerchantClientValidationException(
                    merchantValidationException.InnerException as Xeption);
            }
            catch (MerchantDependencyValidationException merchantDependencyValidationException)
            {


                throw new MerchantClientValidationException(
                    merchantDependencyValidationException.InnerException as Xeption);
            }
            catch (MerchantDependencyException MerchantDependencyException)
            {
                throw new MerchantClientDependencyException(
                    MerchantDependencyException.InnerException as Xeption);
            }
            catch (MerchantServiceException MerchantServiceException)
            {
                throw new MerchantClientServiceException(
                    MerchantServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<MerchantProfile> RetrieveMerchantProfileAsync()
        {
             try
            {
                return await merchantService.GetMerchantProfileAsync();
            }
            catch (MerchantValidationException merchantValidationException)
            {

                throw new MerchantClientValidationException(
                    merchantValidationException.InnerException as Xeption);
            }
            catch (MerchantDependencyValidationException merchantDependencyValidationException)
            {


                throw new MerchantClientValidationException(
                    merchantDependencyValidationException.InnerException as Xeption);
            }
            catch (MerchantDependencyException MerchantDependencyException)
            {
                throw new MerchantClientDependencyException(
                    MerchantDependencyException.InnerException as Xeption);
            }
            catch (MerchantServiceException MerchantServiceException)
            {
                throw new MerchantClientServiceException(
                    MerchantServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<MerchantWallet> RetrieveMerchantWalletAsync()
        {
             try
            {
                return await merchantService.GetMerchantWalletAsync();
            }
            catch (MerchantValidationException merchantValidationException)
            {

                throw new MerchantClientValidationException(
                    merchantValidationException.InnerException as Xeption);
            }
            catch (MerchantDependencyValidationException merchantDependencyValidationException)
            {


                throw new MerchantClientValidationException(
                    merchantDependencyValidationException.InnerException as Xeption);
            }
            catch (MerchantDependencyException MerchantDependencyException)
            {
                throw new MerchantClientDependencyException(
                    MerchantDependencyException.InnerException as Xeption);
            }
            catch (MerchantServiceException MerchantServiceException)
            {
                throw new MerchantClientServiceException(
                    MerchantServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<SwitchAccountMode> SwitchAccountModeAsync(SwitchAccountMode switchAccountMode)
        {
             try
            {
                return await merchantService.PostSwitchAccountModeAsync(switchAccountMode);
            }
            catch (MerchantValidationException merchantValidationException)
            {

                throw new MerchantClientValidationException(
                    merchantValidationException.InnerException as Xeption);
            }
            catch (MerchantDependencyValidationException merchantDependencyValidationException)
            {


                throw new MerchantClientValidationException(
                    merchantDependencyValidationException.InnerException as Xeption);
            }
            catch (MerchantDependencyException MerchantDependencyException)
            {
                throw new MerchantClientDependencyException(
                    MerchantDependencyException.InnerException as Xeption);
            }
            catch (MerchantServiceException MerchantServiceException)
            {
                throw new MerchantClientServiceException(
                    MerchantServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<UpdateMerchantProfile> UpdateMerchantProfileAsync(UpdateMerchantProfile updateMerchantProfile)
        {
             try
            {
                return await merchantService.UpdateMerchantProfileAsync(updateMerchantProfile);
            }
            catch (MerchantValidationException merchantValidationException)
            {

                throw new MerchantClientValidationException(
                    merchantValidationException.InnerException as Xeption);
            }
            catch (MerchantDependencyValidationException merchantDependencyValidationException)
            {


                throw new MerchantClientValidationException(
                    merchantDependencyValidationException.InnerException as Xeption);
            }
            catch (MerchantDependencyException MerchantDependencyException)
            {
                throw new MerchantClientDependencyException(
                    MerchantDependencyException.InnerException as Xeption);
            }
            catch (MerchantServiceException MerchantServiceException)
            {
                throw new MerchantClientServiceException(
                    MerchantServiceException.InnerException as Xeption);
            }
        }
    }
}
