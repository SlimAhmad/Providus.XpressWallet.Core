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
        public async Task ShouldDeclinePendingTransactionAsync()
        {
            // given
            string randomString = GetRandomString();
            string randomApiKey = randomString;
            string inputTransactionId= randomApiKey;

            ExternalDeclinePendingTransactionResponse randomExternalDeclinePendingTransactionResponse =
                CreateExternalDeclinePendingTransactionResponseResult();

            ExternalDeclinePendingTransactionResponse retrievedDeclinePendingTransactionResult =
                randomExternalDeclinePendingTransactionResponse;

            DeclinePendingTransaction expectedDeclinePendingTransactionResponse =
                ConvertToTransactionsResponse(retrievedDeclinePendingTransactionResult);

            this.wireMockServer.Given(
                Request.Create()
                .UsingDelete()
                    .WithPath($"/transaction/{inputTransactionId}")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}"))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(retrievedDeclinePendingTransactionResult));

            // when
            DeclinePendingTransaction actualResult =
                await this.xPressWalletClient.Transactions.DeclinePendingTransactionAsync(inputTransactionId);

            // then
            actualResult.Should().BeEquivalentTo(expectedDeclinePendingTransactionResponse);
        }
    }
}
