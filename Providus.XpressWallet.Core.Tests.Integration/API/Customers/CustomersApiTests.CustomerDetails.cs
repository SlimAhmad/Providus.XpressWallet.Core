using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Customers;

namespace Providus.XpressWallet.Core.Tests.Integration.API.Customers
{
    public partial class CustomersApiTests
    {
        [Fact(Skip = "This test is only for releases")]
        public async Task ShouldRetrieveCustomerDetailsAsync()
        {
            // given
            string customerId = "183adcd3-4695-496a-8c25-10715cdfc45f";

            // when
            CustomerDetails retrievedCustomerModel =
              await this.xPressWalletClient.Customers.RetrieveCustomerDetailsAsync(customerId);

            // then
            Assert.NotNull(retrievedCustomerModel);
        }
    }
}
