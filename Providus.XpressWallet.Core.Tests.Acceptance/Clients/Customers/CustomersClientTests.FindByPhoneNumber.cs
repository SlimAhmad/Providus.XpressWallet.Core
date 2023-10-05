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
        public async Task ShouldRetrieveFindByPhoneNumberAsync()
        {
            // given
            string randomString = GetRandomString();
            string randomApiKey = randomString;
            string inputPhoneNumber = randomApiKey;

            ExternalFindByPhoneNumberResponse randomExternalFindByPhoneNumberResponse =
                CreateExternalFindByPhoneNumberResponseResult();

            ExternalFindByPhoneNumberResponse retrievedFindByPhoneNumberResult =
                randomExternalFindByPhoneNumberResponse;

            FindByPhoneNumber expectedFindByPhoneNumberResponse =
                ConvertToCustomersResponse(retrievedFindByPhoneNumberResult);

            this.wireMockServer.Given(
                Request.Create()
                .UsingGet()
                    .WithPath($"/customer/phone")
                    .WithParam("phoneNumber", inputPhoneNumber))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(retrievedFindByPhoneNumberResult));

            // when
            FindByPhoneNumber actualResult =
                await this.xPressWalletClient.Customers.RetrieveFindByPhoneNumberAsync(inputPhoneNumber);

            // then
            actualResult.Should().BeEquivalentTo(expectedFindByPhoneNumberResponse);
        } 
    }
}
