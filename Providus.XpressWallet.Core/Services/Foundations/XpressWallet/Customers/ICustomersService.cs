using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Customers;

namespace Providus.XpressWallet.Core.Services.Foundations.XpressWallet.Customers
{
    internal interface ICustomersService
    {
        ValueTask<AllCustomers> GetAllCustomersRequestAsync();
        ValueTask<CustomerDetails> GetCustomerDetailsRequestAsync(string customerId);
        ValueTask<FindByPhoneNumber> GetFindByPhoneNumberRequestAsync(string phoneNumber);
        ValueTask<UpdateCustomerProfile> UpdateCustomerProfileRequestAsync(
            UpdateCustomerProfile externalUpdateCustomerProfile,
            string customerId);
    }
}
