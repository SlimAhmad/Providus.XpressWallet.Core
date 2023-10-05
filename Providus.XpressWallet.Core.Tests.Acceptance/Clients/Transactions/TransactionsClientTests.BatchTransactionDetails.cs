using FluentAssertions;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalTransactions;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transactions;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;


namespace Providus.XpressWallet.Core.Tests.Acceptance.Clients.Transactions
{
    public partial class TransactionsClientTests
    {
        [Fact]
        public async Task ShouldRetrieveBatchTransactionDetailsAsync()
        {
            // given
            string randomString = GetRandomString();
            string randomReference = randomString;
            string inputReference = randomReference;

            ExternalBatchTransactionDetailsResponse randomExternalBatchTransactionDetailsResponse =
                CreateExternalBatchTransactionDetailsResponseResult();

            ExternalBatchTransactionDetailsResponse retrievedBatchTransactionDetailsResult =
                randomExternalBatchTransactionDetailsResponse;

            BatchTransactionDetails expectedBatchTransactionDetailsResponse =
                ConvertToTransactionsResponse(retrievedBatchTransactionDetailsResult);

            this.wireMockServer.Given(
                Request.Create()
            .UsingGet()
                    .WithPath($"/transaction/batch/{inputReference}")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}"))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(retrievedBatchTransactionDetailsResult));

            // when
            BatchTransactionDetails actualResult =
                await this.xPressWalletClient.Transactions.RetrieveBatchTransactionDetailsAsync(inputReference);

            // then
            actualResult.Should().BeEquivalentTo(expectedBatchTransactionDetailsResponse);
        }
    }
}
