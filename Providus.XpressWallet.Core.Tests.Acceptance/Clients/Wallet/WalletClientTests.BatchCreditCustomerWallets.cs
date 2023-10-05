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
        public async Task ShouldBatchCreditCustomerWalletsAsync()
        {
            // given
            string randomString = GetRandomString();
            string randomCustomerId = randomString;
            string inputCustomerId = randomCustomerId;

            BatchCreditCustomerWallets randomBatchCreditCustomerWallets = CreateBatchCreditCustomerWalletsResponseResult();
            BatchCreditCustomerWallets inputBatchCreditCustomerWallets = randomBatchCreditCustomerWallets;

            ExternalBatchCreditCustomerWalletsRequest batchCreditCustomerWalletRequest =
                ConvertToWalletRequest(inputBatchCreditCustomerWallets);

            ExternalBatchCreditCustomerWalletsResponse batchCreditCustomerWalletResponse =
                            CreateExternalBatchCreditCustomerWalletsResponseResult();

            BatchCreditCustomerWallets expectedBatchCreditCustomerWallets = inputBatchCreditCustomerWallets.DeepClone();
            expectedBatchCreditCustomerWallets = ConvertToWalletResponse(inputBatchCreditCustomerWallets, batchCreditCustomerWalletResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            this.wireMockServer.Given(
                Request.Create()
                .UsingPost()
                    .WithPath($"/wallet/batch-credit-customer-wallet")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}")
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithBody(JsonConvert.SerializeObject(
                        batchCreditCustomerWalletRequest,
                        jsonSerializationSettings)))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(batchCreditCustomerWalletResponse));

            // when
            BatchCreditCustomerWallets actualResult =
                await this.xPressWalletClient.Wallet.BatchCreditCustomerWalletsAsync(inputBatchCreditCustomerWallets);

            // then
            actualResult.Should().BeEquivalentTo(expectedBatchCreditCustomerWallets);
        }
    }
}
