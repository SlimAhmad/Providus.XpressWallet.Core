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
        public async Task ShouldMerchantBatchBankTransferAsync()
        {
            // given
            string randomString = GetRandomString();
            string randomCustomerId = randomString;
            string inputCustomerId = randomCustomerId;

            MerchantBatchBankTransfer randomMerchantBatchBankTransfer = CreateMerchantBatchBankTransferResponseResult();
            MerchantBatchBankTransfer inputMerchantBatchBankTransfer = randomMerchantBatchBankTransfer;

            List<ExternalMerchantBatchBankTransferRequest> updateCustomerProfileRequest =
                ConvertToTransfersRequest(inputMerchantBatchBankTransfer);

            ExternalMerchantBatchBankTransferResponse updateCustomerProfileResponse =
                            CreateExternalMerchantBatchBankTransferResponseResult();

            MerchantBatchBankTransfer expectedMerchantBatchBankTransfer = inputMerchantBatchBankTransfer.DeepClone();
            expectedMerchantBatchBankTransfer = ConvertToTransfersResponse(inputMerchantBatchBankTransfer, updateCustomerProfileResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            this.wireMockServer.Given(
                Request.Create()
                .UsingPost()
                    .WithPath($"/transfer/bank/batch")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}")
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithBody(JsonConvert.SerializeObject(
                        updateCustomerProfileRequest,
                        jsonSerializationSettings)))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(updateCustomerProfileResponse));

            // when
            MerchantBatchBankTransfer actualResult =
                await this.xPressWalletClient.Transfers.MerchantBatchBankTransferAsync(inputMerchantBatchBankTransfer);

            // then
            actualResult.Should().BeEquivalentTo(expectedMerchantBatchBankTransfer);
        }
    }
}
