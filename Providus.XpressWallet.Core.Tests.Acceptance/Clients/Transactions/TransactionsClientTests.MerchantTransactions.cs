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
        public async Task ShouldRetrieveMerchantTransactionsAsync()
        {
            // given
            var inputPage = GetRandomNumber();
            var inputType = GetRandomString();
            var inputStatus = GetRandomString();

            ExternalMerchantTransactionsResponse randomExternalMerchantTransactionsResponse =
                CreateExternalMerchantTransactionsResponseResult();

            ExternalMerchantTransactionsResponse retrievedMerchantTransactionsResult =
                randomExternalMerchantTransactionsResponse;

            MerchantTransactions expectedMerchantTransactionsResponse =
                ConvertToTransactionsResponse(retrievedMerchantTransactionsResult);

            this.wireMockServer.Given(
                Request.Create()
            .UsingGet()
                    .WithPath($"/merchant/transactions")
                    .WithParam("page", inputPage.ToString())
                    .WithParam("type", inputType)
                    .WithParam("status", inputStatus)
                    .WithHeader("Authorization", $"Bearer {this.apiKey}"))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(retrievedMerchantTransactionsResult));

            // when
            MerchantTransactions actualResult =
                await this.xPressWalletClient.Transactions.RetrieveMerchantTransactionsAsync(inputPage,inputType,inputStatus);

            // then
            actualResult.Should().BeEquivalentTo(expectedMerchantTransactionsResponse);
        }
    }
}
