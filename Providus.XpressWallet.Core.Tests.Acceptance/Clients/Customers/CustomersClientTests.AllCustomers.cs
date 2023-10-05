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
        public async Task ShouldRetrieveAllCustomersAsync()
        {
            // given
           

            ExternalAllCustomersResponse randomExternalAllCustomersResponse =
                CreateExternalAllCustomersResponseResult();

            ExternalAllCustomersResponse retrievedAllCustomersResult =
                randomExternalAllCustomersResponse;

            AllCustomers expectedAllCustomersResponse =
                ConvertToCustomersResponse(retrievedAllCustomersResult);

            this.wireMockServer.Given(
                Request.Create()
                .UsingGet()
                    .WithPath($"/customer"))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(retrievedAllCustomersResult));

            // when
            AllCustomers actualResult =
                await this.xPressWalletClient.Customers.RetrieveAllCustomersAsync();

            // then
            actualResult.Should().BeEquivalentTo(expectedAllCustomersResponse);
        }
    }
}
