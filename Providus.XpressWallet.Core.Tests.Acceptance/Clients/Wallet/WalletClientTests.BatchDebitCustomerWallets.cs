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
        public async Task ShouldBatchDebitCustomerWalletsAsync()
        {
            // given
            string randomString = GetRandomString();
            string randomCustomerId = randomString;
            string inputCustomerId = randomCustomerId;

            BatchDebitCustomerWallets randomBatchDebitCustomerWallets = CreateBatchDebitCustomerWalletsResponseResult();
            BatchDebitCustomerWallets inputBatchDebitCustomerWallets = randomBatchDebitCustomerWallets;

            ExternalBatchDebitCustomerWalletsRequest batchDebitCustomerWalletsRequest =
                ConvertToWalletRequest(inputBatchDebitCustomerWallets);

            ExternalBatchDebitCustomerWalletsResponse batchDebitCustomerWalletsResponse =
                            CreateExternalBatchDebitCustomerWalletsResponseResult();

            BatchDebitCustomerWallets expectedBatchDebitCustomerWallets = inputBatchDebitCustomerWallets.DeepClone();
            expectedBatchDebitCustomerWallets = ConvertToWalletResponse(inputBatchDebitCustomerWallets, batchDebitCustomerWalletsResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            this.wireMockServer.Given(
                Request.Create()
                .UsingPost()
                    .WithPath($"/wallet/batch-debit-customer-wallet")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}")
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithBody(JsonConvert.SerializeObject(
                        batchDebitCustomerWalletsRequest,
                        jsonSerializationSettings)))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(batchDebitCustomerWalletsResponse));

            // when
            BatchDebitCustomerWallets actualResult =
                await this.xPressWalletClient.Wallet.BatchDebitCustomerWalletsAsync(inputBatchDebitCustomerWallets);

            // then
            actualResult.Should().BeEquivalentTo(expectedBatchDebitCustomerWallets);
        }
    }
}
