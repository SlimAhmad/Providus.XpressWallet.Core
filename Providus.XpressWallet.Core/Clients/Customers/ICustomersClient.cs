using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Customers;

namespace Providus.XpressWallet.Core.Clients.Customers
{
    public interface ICustomersClient
    {

        ValueTask<AllCustomers> RetrieveAllCustomersAsync();
        ValueTask<CustomerDetails> RetrieveCustomerDetailsAsync(string customerId);
        ValueTask<FindByPhoneNumber> RetrieveFindByPhoneNumberAsync(string phoneNumber);
        ValueTask<UpdateCustomerProfile> UpdateCustomerProfileAsync(
            UpdateCustomerProfile externalUpdateCustomerProfile,
            string customerId);
    }
}
