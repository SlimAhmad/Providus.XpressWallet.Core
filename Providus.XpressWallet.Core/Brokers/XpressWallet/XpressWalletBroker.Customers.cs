using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalCard;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalCustomers;


namespace Providus.XpressWallet.Core.Brokers.XpressWallet
{
    internal partial class XpressWalletBroker
    {



        public async ValueTask<ExternalAllCustomersResponse> GetAllCustomersAsync()
        {
            return await GetAsync<ExternalAllCustomersResponse>(
                    relativeUrl: $"customer");
        }


        public async ValueTask<ExternalCustomerDetailsResponse> GetCustomerDetailsAsync(string customerId)
        
        {
            return await GetAsync<ExternalCustomerDetailsResponse>(
                    relativeUrl: $"customer/{customerId}");
        }
        public async ValueTask<ExternalFindByPhoneNumberResponse> GetFindByPhoneNumberAsync(string phoneNumber)
        {
            return await GetAsync<ExternalFindByPhoneNumberResponse>(
                    relativeUrl: $"customer/phone?phoneNumber={phoneNumber}");
        }
        public async ValueTask<ExternalUpdateCustomerProfileResponse> UpdateCustomerProfileAsync(
            ExternalUpdateCustomerProfileRequest externalUpdateCustomerProfileRequest,string customerId)
        
        {
            return await PutAsync<ExternalUpdateCustomerProfileRequest, ExternalUpdateCustomerProfileResponse>(
                        relativeUrl: $"customer/{customerId}",
                        content: externalUpdateCustomerProfileRequest);
        }


    }
}
