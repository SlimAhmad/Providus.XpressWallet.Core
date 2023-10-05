using FluentAssertions;
using HandlebarsDotNet.Helpers.Enums;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalTransactions;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transactions;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;


namespace Providus.XpressWallet.Core.Tests.Acceptance.Clients.Transactions
{
    public partial class TransactionsClientTests
    {
        [Fact]
        public async Task ShouldRetrieveBatchTransactionsAsync()
        {
            // given
            var inputPage = GetRandomNumber();
            var inputType = GetRandomString();
            var inputPerPage = GetRandomNumber();
            var inputCategory = GetRandomString();
            var inputSearch = GetRandomString();
       

            ExternalBatchTransactionsResponse randomExternalBatchTransactionsResponse =
                CreateExternalBatchTransactionsResponseResult();

            ExternalBatchTransactionsResponse retrievedBatchTransactionsResult =
                randomExternalBatchTransactionsResponse;

            BatchTransactions expectedBatchTransactionsResponse =
                ConvertToTransactionsResponse(retrievedBatchTransactionsResult);

            this.wireMockServer.Given(
            Request.Create()
            .UsingGet()
                    .WithPath($"/transaction/batch")
                    .WithParam("search", inputSearch)
                    .WithParam("category", inputCategory)
                    .WithParam("type",inputType)
                    .WithParam("page", inputPage.ToString())
                    .WithParam("perPage", inputPerPage.ToString())
                    .WithHeader("Authorization", $"Bearer {this.apiKey}"))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(retrievedBatchTransactionsResult));

            // when
            BatchTransactions actualResult =
                await this.xPressWalletClient.Transactions.RetrieveBatchTransactionsAsync(
                    inputSearch,inputCategory,inputType,inputPage,inputPerPage);

            // then
            actualResult.Should().BeEquivalentTo(expectedBatchTransactionsResponse);
        }
    }
}
