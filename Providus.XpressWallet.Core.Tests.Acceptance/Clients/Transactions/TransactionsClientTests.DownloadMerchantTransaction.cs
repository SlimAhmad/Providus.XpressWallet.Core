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
        public async Task ShouldRetrieveDownloadMerchantTransactionAsync()
        {
            // given
           

            ExternalDownloadMerchantTransactionResponse randomExternalDownloadMerchantTransactionResponse =
                CreateExternalDownloadMerchantTransactionResponseResult();

            ExternalDownloadMerchantTransactionResponse retrievedDownloadMerchantTransactionResult =
                randomExternalDownloadMerchantTransactionResponse;

            DownloadMerchantTransaction expectedDownloadMerchantTransactionResponse =
                ConvertToTransactionsResponse(retrievedDownloadMerchantTransactionResult);

            this.wireMockServer.Given(
                Request.Create()
                .UsingGet()
                    .WithPath($"/transaction/download/merchant")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}"))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(retrievedDownloadMerchantTransactionResult));

            // when
            DownloadMerchantTransaction actualResult =
                await this.xPressWalletClient.Transactions.DownloadMerchantTransactionAsync();

            // then
            actualResult.Should().BeEquivalentTo(expectedDownloadMerchantTransactionResponse);
        }
    }
}
