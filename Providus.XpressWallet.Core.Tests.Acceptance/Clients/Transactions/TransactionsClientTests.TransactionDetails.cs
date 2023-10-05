using FluentAssertions;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalTransactions;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transactions;
using System.Security.Cryptography.Xml;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;


namespace Providus.XpressWallet.Core.Tests.Acceptance.Clients.Transactions
{
    public partial class TransactionsClientTests
    {
        [Fact]
        public async Task ShouldRetrieveTransactionDetailsAsync()
        {
            // given
            string randomString = GetRandomString();
            string randomTransactionReference = randomString;
            string inputTransactionReference = randomTransactionReference;

            ExternalTransactionDetailsResponse randomExternalTransactionDetailsResponse =
                CreateExternalTransactionDetailsResponseResult();

            ExternalTransactionDetailsResponse retrievedTransactionDetailsResult =
                randomExternalTransactionDetailsResponse;

            TransactionDetails expectedTransactionDetailsResponse =
                ConvertToTransactionsResponse(retrievedTransactionDetailsResult);

            this.wireMockServer.Given(
                Request.Create()
            .UsingGet()
                    .WithPath($"/merchant/transaction/{inputTransactionReference}")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}"))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(retrievedTransactionDetailsResult));

            // when
            TransactionDetails actualResult =
                await this.xPressWalletClient.Transactions.RetrieveTransactionDetailsAsync(inputTransactionReference);

            // then
            actualResult.Should().BeEquivalentTo(expectedTransactionDetailsResponse);
        }
    }
}
