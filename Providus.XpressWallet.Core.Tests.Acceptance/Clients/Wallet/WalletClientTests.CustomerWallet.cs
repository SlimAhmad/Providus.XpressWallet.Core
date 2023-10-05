using FluentAssertions;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalWallet;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Wallet;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;


namespace Providus.XpressWallet.Core.Tests.Acceptance.Clients.Wallet
{
    public partial class WalletClientTests
    {
        [Fact]
        public async Task ShouldRetrieveCustomerWalletAsync()
        {
            // given
            string randomString = GetRandomString();
            string randomApiKey = randomString;
            string inputCustomerId = randomApiKey;

            ExternalCustomerWalletResponse randomExternalCustomerWalletResponse =
                CreateExternalCustomerWalletResponseResult();

            ExternalCustomerWalletResponse retrievedCustomerWalletResult =
                randomExternalCustomerWalletResponse;
            var body = new object();
            CustomerWallet expectedCustomerWalletResponse =
                ConvertToWalletResponse(retrievedCustomerWalletResult);

            this.wireMockServer.Given(
                Request.Create()
                .UsingGet()
                    .WithPath($"/wallet/customer")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}")
                     .WithParam("customerId", inputCustomerId)
                   )
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(retrievedCustomerWalletResult));

            // when
            CustomerWallet actualResult =
                await this.xPressWalletClient.Wallet.RetrieveCustomerWalletAsync(inputCustomerId);

            // then
            actualResult.Should().BeEquivalentTo(expectedCustomerWalletResponse);
        }
    }
}
