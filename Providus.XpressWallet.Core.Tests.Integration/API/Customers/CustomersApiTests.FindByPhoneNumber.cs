using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Customers;

namespace Providus.XpressWallet.Core.Tests.Integration.API.Customers
{
    public partial class CustomersApiTests
    {
        [Fact(Skip = "This test is only for releases")]
        public async Task ShouldRetrieveFindByPhoneNumberAsync()
        {
            // given
            string phoneNumber = "2348020245356";

            // when
            FindByPhoneNumber retrievedCustomerModel =
              await this.xPressWalletClient.Customers.RetrieveFindByPhoneNumberAsync(phoneNumber);

            // then
            Assert.NotNull(retrievedCustomerModel);
        }
    }
}
