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
        public async Task ShouldSendMerchantBankTransferAsync()
        {
            // given
            string randomString = GetRandomString();
            string randomCustomerId = randomString;
            string inputCustomerId = randomCustomerId;

            MerchantBankTransfer randomMerchantBankTransfer = CreateMerchantBankTransferResponseResult();
            MerchantBankTransfer inputMerchantBankTransfer = randomMerchantBankTransfer;

            ExternalMerchantBankTransferRequest updateCustomerProfileRequest =
                ConvertToTransfersRequest(inputMerchantBankTransfer);

            ExternalMerchantBankTransferResponse updateCustomerProfileResponse =
                            CreateExternalMerchantBankTransferResponseResult();

            MerchantBankTransfer expectedMerchantBankTransfer = inputMerchantBankTransfer.DeepClone();
            expectedMerchantBankTransfer = ConvertToTransfersResponse(inputMerchantBankTransfer, updateCustomerProfileResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            this.wireMockServer.Given(
                Request.Create()
                .UsingPost()
                    .WithPath($"/transfer/bank")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}")
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithBody(JsonConvert.SerializeObject(
                        updateCustomerProfileRequest,
                        jsonSerializationSettings)))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(updateCustomerProfileResponse));

            // when
            MerchantBankTransfer actualResult =
                await this.xPressWalletClient.Transfers.MerchantBankTransferAsync(inputMerchantBankTransfer);

            // then
            actualResult.Should().BeEquivalentTo(expectedMerchantBankTransfer);
        }
    }
}
