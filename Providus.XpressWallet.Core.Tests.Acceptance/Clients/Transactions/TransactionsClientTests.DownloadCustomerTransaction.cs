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
        public async Task ShouldDownloadCustomerTransactionAsync()
        {
            // given
            string randomString = GetRandomString();
            string randomApiKey = randomString;
            string inputCustomerId = randomApiKey;

            ExternalDownloadCustomerTransactionResponse randomExternalDownloadCustomerTransactionResponse =
                CreateExternalDownloadCustomerTransactionResponseResult();

            ExternalDownloadCustomerTransactionResponse retrievedDownloadCustomerTransactionResult =
                randomExternalDownloadCustomerTransactionResponse;

            DownloadCustomerTransaction expectedDownloadCustomerTransactionResponse =
                ConvertToTransactionsResponse(retrievedDownloadCustomerTransactionResult);

            this.wireMockServer.Given(
                Request.Create()
                .UsingGet()
                    .WithPath($"/transaction/download/customer")
                    .WithParam("customerId", inputCustomerId)
                    .WithHeader("Authorization", $"Bearer {this.apiKey}"))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(retrievedDownloadCustomerTransactionResult));

            // when
            DownloadCustomerTransaction actualResult =
                await this.xPressWalletClient.Transactions.DownloadCustomerTransactionAsync(inputCustomerId);

            // then
            actualResult.Should().BeEquivalentTo(expectedDownloadCustomerTransactionResponse);
        } 
    }
}
