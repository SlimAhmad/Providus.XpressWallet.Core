using FluentAssertions;
using Force.DeepCloner;
using Newtonsoft.Json;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalTransfers;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transfers;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace Providus.XpressWallet.Core.Tests.Acceptance.Clients.Transfers
{
    public partial class TransfersClientTests
    {
        [Fact]
        public async Task ShouldSendCustomerBankTransferAsync()
        {
            // given
            string randomString = GetRandomString();
            string randomCustomerId = randomString;
            string inputCustomerId = randomCustomerId;

            CustomerBankTransfer randomCustomerBankTransfer = CreateCustomerBankTransferResponseResult();
            CustomerBankTransfer inputCustomerBankTransfer = randomCustomerBankTransfer;

            ExternalCustomerBankTransferRequest customerBankTransferRequest =
                ConvertToTransfersRequest(inputCustomerBankTransfer);

            ExternalCustomerBankTransferResponse customerBankTransferResponse =
                            CreateExternalCustomerBankTransferResponseResult();

            CustomerBankTransfer expectedCustomerBankTransfer = inputCustomerBankTransfer.DeepClone();
            expectedCustomerBankTransfer = ConvertToTransfersResponse(inputCustomerBankTransfer, customerBankTransferResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            this.wireMockServer.Given(
                Request.Create()
                .UsingPost()
                    .WithPath($"/transfer/bank/customer")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}")
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithBody(JsonConvert.SerializeObject(
                        customerBankTransferRequest,
                        jsonSerializationSettings)))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(customerBankTransferResponse));

            // when
            CustomerBankTransfer actualResult =
                await this.xPressWalletClient.Transfers.CustomerBankTransferAsync(inputCustomerBankTransfer);

            // then
            actualResult.Should().BeEquivalentTo(expectedCustomerBankTransfer);
        }
    }
}
