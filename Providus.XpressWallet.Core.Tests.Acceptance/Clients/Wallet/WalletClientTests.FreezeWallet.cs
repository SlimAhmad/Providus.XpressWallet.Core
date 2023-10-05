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
        public async Task ShouldFreezeWalletAsync()
        {
            // given
            string randomString = GetRandomString();
            string randomCustomerId = randomString;
            string inputCustomerId = randomCustomerId;

            FreezeWallet randomFreezeWallet = CreateFreezeWalletResponseResult();
            FreezeWallet inputFreezeWallet = randomFreezeWallet;

            ExternalFreezeWalletRequest updateCustomerProfileRequest =
                ConvertToWalletRequest(inputFreezeWallet);

            ExternalFreezeWalletResponse updateCustomerProfileResponse =
                            CreateExternalFreezeWalletResponseResult();

            FreezeWallet expectedFreezeWallet = inputFreezeWallet.DeepClone();
            expectedFreezeWallet = ConvertToWalletResponse(inputFreezeWallet, updateCustomerProfileResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            this.wireMockServer.Given(
                Request.Create()
                .UsingPost()
                    .WithPath($"/wallet/close")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}")
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithBody(JsonConvert.SerializeObject(
                        updateCustomerProfileRequest,
                        jsonSerializationSettings)))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(updateCustomerProfileResponse));

            // when
            FreezeWallet actualResult =
                await this.xPressWalletClient.Wallet.FreezeWalletAsync(inputFreezeWallet);

            // then
            actualResult.Should().BeEquivalentTo(expectedFreezeWallet);
        }
    }
}
