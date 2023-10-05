using FluentAssertions;
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
        public async Task ShouldRetrieveCustomerTransactionsAsync()
        {
            // given
            var inputPage = GetRandomNumber();
            var inputType = GetRandomString();
            var inputPerPage = GetRandomNumber();
            var inputCustomerId = GetRandomString();
       

            ExternalCustomerTransactionsResponse randomExternalCustomerTransactionsResponse =
                CreateExternalCustomerTransactionsResponseResult();

            ExternalCustomerTransactionsResponse retrievedCustomerTransactionsResult =
                randomExternalCustomerTransactionsResponse;

            CustomerTransactions expectedCustomerTransactionsResponse =
                ConvertToTransactionsResponse(retrievedCustomerTransactionsResult);

            this.wireMockServer.Given(
                Request.Create()
            .UsingGet()
                    .WithPath($"/transaction/customer")
                        .WithParam("customerId", inputCustomerId)
                        .WithParam("type", inputType)
                        .WithParam("page", inputPage.ToString())
                        .WithParam("perPage", inputPerPage.ToString())
                    .WithHeader("Authorization", $"Bearer {this.apiKey}"))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(retrievedCustomerTransactionsResult));

            // when
            CustomerTransactions actualResult =
                await this.xPressWalletClient.Transactions.RetrieveCustomerTransactionAsync(inputCustomerId,inputPage,inputType,inputPerPage);

            // then
            actualResult.Should().BeEquivalentTo(expectedCustomerTransactionsResponse);
        }
    }
}
