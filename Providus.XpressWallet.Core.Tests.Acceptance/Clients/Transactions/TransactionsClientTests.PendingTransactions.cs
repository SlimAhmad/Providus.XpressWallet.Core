using FluentAssertions;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalTransactions;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transactions;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;


namespace Providus.XpressWallet.Core.Tests.Acceptance.Clients.Transactions
{
    public partial class TransactionsClientTests
    {
        [Fact]
        public async Task ShouldRetrievePendingTransactionAsync()
        {
            // given
            var inputPage = GetRandomNumber();
            var inputType = GetRandomString();

            ExternalPendingTransactionResponse randomExternalPendingTransactionResponse =
                CreateExternalPendingTransactionResponseResult();

            ExternalPendingTransactionResponse retrievedPendingTransactionResult =
                randomExternalPendingTransactionResponse;

            PendingTransaction expectedPendingTransactionResponse =
                ConvertToTransactionsResponse(retrievedPendingTransactionResult);

            this.wireMockServer.Given(
                Request.Create()
            .UsingGet()
                    .WithPath($"/transaction/pending")
                    .WithParam("page",inputPage.ToString())
                    .WithParam("type",inputType)
                    .WithHeader("Authorization", $"Bearer {this.apiKey}"))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(retrievedPendingTransactionResult));

            // when
            PendingTransaction actualResult =
                await this.xPressWalletClient.Transactions.RetrievePendingTransactionsAsync(inputPage,inputType);

            // then
            actualResult.Should().BeEquivalentTo(expectedPendingTransactionResponse);
        }
    }
}
