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
        public async Task ShouldRetrieveBatchTransactionAsync()
        {
            // given
            string randomString = GetRandomString();
            string randomCustomerId = randomString;
            string inputCustomerId = randomCustomerId;

            ApproveTransaction randomApproveTransaction = CreateApproveTransactionResponseResult();
            ApproveTransaction inputApproveTransaction = randomApproveTransaction;

            ExternalApproveTransactionRequest updateCustomerProfileRequest =
                ConvertToTransactionsRequest(inputApproveTransaction);

            ExternalApproveTransactionResponse updateCustomerProfileResponse =
                            CreateExternalApproveTransactionResponseResult();

            ApproveTransaction expectedApproveTransaction = inputApproveTransaction.DeepClone();
            expectedApproveTransaction = ConvertToTransactionsResponse(inputApproveTransaction, updateCustomerProfileResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            this.wireMockServer.Given(
                Request.Create()
                .UsingPost()
                    .WithPath($"/transaction/approve")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}")
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithBody(JsonConvert.SerializeObject(
                        updateCustomerProfileRequest,
                        jsonSerializationSettings)))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(updateCustomerProfileResponse));

            // when
            ApproveTransaction actualResult =
                await this.xPressWalletClient.Transactions.ApproveTransactionAsync(inputApproveTransaction);

            // then
            actualResult.Should().BeEquivalentTo(expectedApproveTransaction);
        }
    }
}
