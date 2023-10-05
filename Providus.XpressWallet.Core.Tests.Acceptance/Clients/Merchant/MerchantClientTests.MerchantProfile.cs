using FluentAssertions;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalMerchant;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Merchant;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;


namespace Providus.XpressWallet.Core.Tests.Acceptance.Clients.Merchant
{
    public partial class MerchantClientTests
    {
        [Fact]
        public async Task ShouldRetrieveMerchantProfileAsync()
        {
            // given
           

            ExternalMerchantProfileResponse randomExternalMerchantProfileResponse =
                CreateExternalMerchantProfileResponseResult();

            ExternalMerchantProfileResponse retrievedMerchantProfileResult =
                randomExternalMerchantProfileResponse;

            MerchantProfile expectedMerchantProfileResponse =
                ConvertToMerchantResponse(retrievedMerchantProfileResult);

            this.wireMockServer.Given(
                Request.Create()
                .UsingGet()
                    .WithPath($"/merchant/profile")
                     .WithHeader("Authorization", $"Bearer {this.apiKey}"))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(retrievedMerchantProfileResult));

            // when
            MerchantProfile actualResult =
                await this.xPressWalletClient.Merchant.RetrieveMerchantProfileAsync();

            // then
            actualResult.Should().BeEquivalentTo(expectedMerchantProfileResponse);
        }
    }
}
