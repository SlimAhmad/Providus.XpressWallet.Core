using FluentAssertions;
using Force.DeepCloner;
using Newtonsoft.Json;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalTransactions;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transactions;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace Providus.XpressWallet.Core.Tests.Acceptance.Clients.Transactions
{
    public partial class TransactionsClientTests
    {
        [Fact]
        public async Task ShouldReverseBatchTransactionAsync()
        {
            // given
           

            ReverseBatchTransaction randomReverseBatchTransaction = CreateReverseBatchTransactionResponseResult();
            ReverseBatchTransaction inputReverseBatchTransaction = randomReverseBatchTransaction;

            ExternalReverseBatchTransactionRequest updateCustomerProfileRequest =
                ConvertToTransactionsRequest(inputReverseBatchTransaction);

            ExternalReverseBatchTransactionResponse updateCustomerProfileResponse =
                            CreateExternalReverseBatchTransactionResponseResult();

            ReverseBatchTransaction expectedReverseBatchTransaction = inputReverseBatchTransaction.DeepClone();
            expectedReverseBatchTransaction = ConvertToTransactionsResponse(inputReverseBatchTransaction, updateCustomerProfileResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            this.wireMockServer.Given(
                Request.Create()
                .UsingPost()
                    .WithPath($"/wallet/reverse-batch-transaction")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}")
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithBody(JsonConvert.SerializeObject(
                        updateCustomerProfileRequest,
                        jsonSerializationSettings)))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(updateCustomerProfileResponse));

            // when
            ReverseBatchTransaction actualResult =
                await this.xPressWalletClient.Transactions.ReverseBatchTransactionAsync(inputReverseBatchTransaction);

            // then
            actualResult.Should().BeEquivalentTo(expectedReverseBatchTransaction);
        }
    }
}
