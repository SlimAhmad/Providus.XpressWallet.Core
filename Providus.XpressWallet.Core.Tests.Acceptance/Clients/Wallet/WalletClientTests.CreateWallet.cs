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
        public async Task ShouldCreateWalletAsync()
        {
            // given
            string randomString = GetRandomString();
            string randomCustomerId = randomString;
            string inputCustomerId = randomCustomerId;

            CreateWallet randomCreateWallet = CreateCreateWalletResponseResult();
            CreateWallet inputCreateWallet = randomCreateWallet;

            ExternalCreateWalletRequest updateCustomerProfileRequest =
                ConvertToWalletRequest(inputCreateWallet);

            ExternalCreateWalletResponse updateCustomerProfileResponse =
                            CreateExternalCreateWalletResponseResult();

            CreateWallet expectedCreateWallet = inputCreateWallet.DeepClone();
            expectedCreateWallet = ConvertToWalletResponse(inputCreateWallet, updateCustomerProfileResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            this.wireMockServer.Given(
                Request.Create()
                .UsingPost()
                    .WithPath($"/wallet")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}")
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithBody(JsonConvert.SerializeObject(
                        updateCustomerProfileRequest,
                        jsonSerializationSettings)))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(updateCustomerProfileResponse));

            // when
            CreateWallet actualResult =
                await this.xPressWalletClient.Wallet.CreateWalletAsync(inputCreateWallet);

            // then
            actualResult.Should().BeEquivalentTo(expectedCreateWallet);
        }
    }
}
