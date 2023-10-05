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
        public async Task ShouldRetrieveAllWalletsAsync()
        {
            // given
           

            ExternalAllWalletsResponse randomExternalAllWalletsResponse =
                CreateExternalAllWalletsResponseResult();

            ExternalAllWalletsResponse retrievedAllWalletsResult =
                randomExternalAllWalletsResponse;

            AllWallets expectedAllWalletsResponse =
                ConvertToWalletResponse(retrievedAllWalletsResult);

            this.wireMockServer.Given(
                Request.Create()
                .UsingGet()
                    .WithPath($"/wallet")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}"))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(retrievedAllWalletsResult));

            // when
            AllWallets actualResult =
                await this.xPressWalletClient.Wallet.RetrieveAllWalletsAsync();

            // then
            actualResult.Should().BeEquivalentTo(expectedAllWalletsResponse);
        }
    }
}
