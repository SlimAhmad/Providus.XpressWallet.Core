using FluentAssertions;
using Force.DeepCloner;
using Newtonsoft.Json;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalWallet;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Wallet;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace Providus.XpressWallet.Core.Tests.Acceptance.Clients.Wallet
{
    public partial class WalletClientTests
    {
        [Fact]
        public async Task ShouldUnfreezeWalletAsync()
        {
            // given
            string randomString = GetRandomString();
            string randomCustomerId = randomString;
            string inputCustomerId = randomCustomerId;

            UnfreezeWallet randomUnfreezeWallet = CreateUnfreezeWalletResponseResult();
            UnfreezeWallet inputUnfreezeWallet = randomUnfreezeWallet;

            ExternalUnfreezeWalletRequest updateCustomerProfileRequest =
                ConvertToWalletRequest(inputUnfreezeWallet);

            ExternalUnfreezeWalletResponse updateCustomerProfileResponse =
                            CreateExternalUnfreezeWalletResponseResult();

            UnfreezeWallet expectedUnfreezeWallet = inputUnfreezeWallet.DeepClone();
            expectedUnfreezeWallet = ConvertToWalletResponse(inputUnfreezeWallet, updateCustomerProfileResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            this.wireMockServer.Given(
                Request.Create()
                .UsingPost()
                    .WithPath($"/wallet/enable")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}")
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithBody(JsonConvert.SerializeObject(
                        updateCustomerProfileRequest,
                        jsonSerializationSettings)))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(updateCustomerProfileResponse));

            // when
            UnfreezeWallet actualResult =
                await this.xPressWalletClient.Wallet.UnfreezeWalletAsync(inputUnfreezeWallet);

            // then
            actualResult.Should().BeEquivalentTo(expectedUnfreezeWallet);
        }
    }
}
