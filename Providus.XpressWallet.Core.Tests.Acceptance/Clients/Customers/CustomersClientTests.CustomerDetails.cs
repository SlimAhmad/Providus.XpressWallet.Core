using FluentAssertions;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalCustomers;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Customers;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;


namespace Providus.XpressWallet.Core.Tests.Acceptance.Clients.Customers
{
    public partial class CustomersClientTests
    {
        [Fact]
        public async Task ShouldRetrieveCustomerDetailsAsync()
        {
            // given
            string randomString = GetRandomString();
            string randomApiKey = randomString;
            string inputCustomerId = randomApiKey;

            ExternalCustomerDetailsResponse randomExternalCustomerDetailsResponse =
                CreateExternalCustomerDetailsResponseResult();

            ExternalCustomerDetailsResponse retrievedCustomerDetailsResult =
                randomExternalCustomerDetailsResponse;

            CustomerDetails expectedCustomerDetailsResponse =
                ConvertToCustomersResponse(retrievedCustomerDetailsResult);

            this.wireMockServer.Given(
                Request.Create()
                .UsingGet()
                    .WithPath($"/customer/{inputCustomerId}"))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(retrievedCustomerDetailsResult));

            // when
            CustomerDetails actualResult =
                await this.xPressWalletClient.Customers.RetrieveCustomerDetailsAsync(inputCustomerId);

            // then
            actualResult.Should().BeEquivalentTo(expectedCustomerDetailsResponse);
        }
    }
}
