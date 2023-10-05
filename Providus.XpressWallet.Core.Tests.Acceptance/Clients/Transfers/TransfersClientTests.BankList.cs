using FluentAssertions;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalTransfers;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transfers;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;


namespace Providus.XpressWallet.Core.Tests.Acceptance.Clients.Transfers
{
    public partial class TransfersClientTests
    {
        [Fact]
        public async Task ShouldRetrieveBankListAsync()
        {
            // given
           

            ExternalBankListResponse randomExternalBankListResponse =
                CreateExternalBankListResponseResult();

            ExternalBankListResponse retrievedBankListResult =
                randomExternalBankListResponse;

            BankList expectedBankListResponse =
                ConvertToTransfersResponse(retrievedBankListResult);

            this.wireMockServer.Given(
                Request.Create()
                .UsingGet()
                    .WithPath($"/transfer/banks")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}"))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(retrievedBankListResult));

            // when
            BankList actualResult =
                await this.xPressWalletClient.Transfers.RetrieveBankListAsync();

            // then
            actualResult.Should().BeEquivalentTo(expectedBankListResponse);
        }
    }
}
