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
        public async Task ShouldDebitWalletAsync()
        {
            // given
            string randomString = GetRandomString();
            string randomCustomerId = randomString;
            string inputCustomerId = randomCustomerId;

            DebitWallet randomDebitWallet = CreateDebitWalletResponseResult();
            DebitWallet inputDebitWallet = randomDebitWallet;

            ExternalDebitWalletRequest updateCustomerProfileRequest =
                ConvertToWalletRequest(inputDebitWallet);

            ExternalDebitWalletResponse updateCustomerProfileResponse =
                            CreateExternalDebitWalletResponseResult();

            DebitWallet expectedDebitWallet = inputDebitWallet.DeepClone();
            expectedDebitWallet = ConvertToWalletResponse(inputDebitWallet, updateCustomerProfileResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            this.wireMockServer.Given(
                Request.Create()
                .UsingPost()
                    .WithPath($"/wallet/debit")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}")
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithBody(JsonConvert.SerializeObject(
                        updateCustomerProfileRequest,
                        jsonSerializationSettings)))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(updateCustomerProfileResponse));

            // when
            DebitWallet actualResult =
                await this.xPressWalletClient.Wallet.DebitWalletAsync(inputDebitWallet);

            // then
            actualResult.Should().BeEquivalentTo(expectedDebitWallet);
        }
    }
}
