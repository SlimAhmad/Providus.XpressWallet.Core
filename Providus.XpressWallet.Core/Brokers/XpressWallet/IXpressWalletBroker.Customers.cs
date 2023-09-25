using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalCustomers;

namespace Providus.XpressWallet.Core.Brokers.XpressWallet
{
    internal partial interface IXpressWalletBroker
    {

        ValueTask<ExternalAllCustomersResponse> GetAllCustomersAsync();
        ValueTask<ExternalCustomerDetailsResponse> GetCustomerDetailsAsync(string customerId);
        ValueTask<ExternalFindByPhoneNumberResponse> GetFindByPhoneNumberAsync(string phoneNumber);
        ValueTask<ExternalUpdateCustomerProfileResponse> UpdateCustomerProfileAsync(
            ExternalUpdateCustomerProfileRequest externalUpdateCustomerProfileRequest,
            string customerId);
     
    }
}
