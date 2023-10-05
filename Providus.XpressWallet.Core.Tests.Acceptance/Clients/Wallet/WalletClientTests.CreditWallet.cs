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
        public async Task ShouldCreditWalletAsync()
        {
            // given
            string randomString = GetRandomString();
            string randomCustomerId = randomString;
            string inputCustomerId = randomCustomerId;

            CreditWallet randomCreditWallet = CreateCreditWalletResponseResult();
            CreditWallet inputCreditWallet = randomCreditWallet;

            ExternalCreditWalletRequest updateCustomerProfileRequest =
                ConvertToWalletRequest(inputCreditWallet);

            ExternalCreditWalletResponse updateCustomerProfileResponse =
                            CreateExternalCreditWalletResponseResult();

            CreditWallet expectedCreditWallet = inputCreditWallet.DeepClone();
            expectedCreditWallet = ConvertToWalletResponse(inputCreditWallet, updateCustomerProfileResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            this.wireMockServer.Given(
                Request.Create()
                .UsingPost()
                    .WithPath($"/wallet/credit")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}")
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithBody(JsonConvert.SerializeObject(
                        updateCustomerProfileRequest,
                        jsonSerializationSettings)))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(updateCustomerProfileResponse));

            // when
            CreditWallet actualResult =
                await this.xPressWalletClient.Wallet.CreditWalletAsync(inputCreditWallet);

            // then
            actualResult.Should().BeEquivalentTo(expectedCreditWallet);
        }
    }
}
