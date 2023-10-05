using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Customers;

namespace Providus.XpressWallet.Core.Tests.Integration.API.Customers
{
    public partial class CustomersApiTests
    {
        [Fact(Skip = "This test is only for releases")]
        public async Task ShouldRetrieveUpdateCustomerProfileAsync()
        {
            // given
            var request = new UpdateCustomerProfile
            {
                Request = new UpdateCustomerProfileRequest
                {
                    Address = "<Address>",
                    PhoneNumber = "<Number>",
                    FirstName = "<FirstName>",
                    LastName  = "LastName",
                    Metadata = new UpdateCustomerProfileRequest.MetadataResponse
                    {
                       Others = ""
                    }
                }
            };

            var customerId = "<customerId>";
            // when
            UpdateCustomerProfile retrievedCustomerModel =
              await this.xPressWalletClient.Customers.UpdateCustomerProfileAsync(request,customerId);

            // then
            Assert.NotNull(retrievedCustomerModel);
        }
    }
}
