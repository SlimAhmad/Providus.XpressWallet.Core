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
        public async Task ShouldRetrieveBankAccountDetailsAsync()
        {
            // given
            string randomString = GetRandomString();
            string randomApiKey = randomString;
            string inputSortCode = randomApiKey;
            string inputAccountNumber = GetRandomString();

            ExternalBankAccountDetailsResponse randomExternalBankAccountDetailsResponse =
                CreateExternalBankAccountDetailsResponseResult();

            ExternalBankAccountDetailsResponse retrievedBankAccountDetailsResult =
                randomExternalBankAccountDetailsResponse;

            BankAccountDetails expectedBankAccountDetailsResponse =
                ConvertToTransfersResponse(retrievedBankAccountDetailsResult);

            this.wireMockServer.Given(
                Request.Create()
                .UsingGet()
                    .WithPath($"/transfer/account/details")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}")
                    .WithParam("sortCode", inputSortCode)
                    .WithParam("accountNumber", inputAccountNumber))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(retrievedBankAccountDetailsResult));

            // when
            BankAccountDetails actualResult =
                await this.xPressWalletClient.Transfers.RetrieveBankAccountDetailsAsync(inputSortCode,inputAccountNumber);

            // then
            actualResult.Should().BeEquivalentTo(expectedBankAccountDetailsResponse);
        } 
    }
}
