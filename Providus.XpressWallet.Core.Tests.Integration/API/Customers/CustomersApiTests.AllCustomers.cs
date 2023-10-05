using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Customers;

namespace Providus.XpressWallet.Core.Tests.Integration.API.Customers
{
    public partial class CustomersApiTests
    {
        [Fact(Skip = "This test is only for releases")]
        public async Task ShouldRetrieveAllCustomersAsync()
        {
            // given

            // when
            AllCustomers retrievedCustomerModel =
              await this.xPressWalletClient.Customers.RetrieveAllCustomersAsync();

            // then
            Assert.NotNull(retrievedCustomerModel);
        }
    }
}
