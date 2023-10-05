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
        public async Task ShouldPostCustomerCreditCustomerWalletAsync()
        {
            // given
            string randomString = GetRandomString();
            string randomCustomerId = randomString;
            string inputCustomerId = randomCustomerId;

            CustomerCreditCustomerWallet randomCustomerCreditCustomerWallet = CreateCustomerCreditCustomerWalletResponseResult();
            CustomerCreditCustomerWallet inputCustomerCreditCustomerWallet = randomCustomerCreditCustomerWallet;

            ExternalCustomerCreditCustomerWalletRequest updateCustomerProfileRequest =
                ConvertToWalletRequest(inputCustomerCreditCustomerWallet);

            ExternalCustomerCreditCustomerWalletResponse updateCustomerProfileResponse =
                            CreateExternalCustomerCreditCustomerWalletResponseResult();

            CustomerCreditCustomerWallet expectedCustomerCreditCustomerWallet = inputCustomerCreditCustomerWallet.DeepClone();
            expectedCustomerCreditCustomerWallet = ConvertToWalletResponse(inputCustomerCreditCustomerWallet, updateCustomerProfileResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            this.wireMockServer.Given(
                Request.Create()
                .UsingPost()
                    .WithPath($"/wallet/customer-batch-credit-customer-wallet")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}")
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithBody(JsonConvert.SerializeObject(
                        updateCustomerProfileRequest,
                        jsonSerializationSettings)))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(updateCustomerProfileResponse));

            // when
            CustomerCreditCustomerWallet actualResult =
                await this.xPressWalletClient.Wallet.CustomerCreditCustomerWalletAsync(inputCustomerCreditCustomerWallet);

            // then
            actualResult.Should().BeEquivalentTo(expectedCustomerCreditCustomerWallet);
        }
    }
}
