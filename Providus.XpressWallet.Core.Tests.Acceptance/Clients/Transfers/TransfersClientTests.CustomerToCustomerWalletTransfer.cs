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
        public async Task ShouldSendCustomerToCustomerWalletTransferAsync()
        {
            // given
            string randomString = GetRandomString();
            string randomCustomerId = randomString;
            string inputCustomerId = randomCustomerId;

            CustomerToCustomerWalletTransfer randomCustomerToCustomerWalletTransfer = CreateCustomerToCustomerWalletTransferResponseResult();
            CustomerToCustomerWalletTransfer inputCustomerToCustomerWalletTransfer = randomCustomerToCustomerWalletTransfer;

            ExternalCustomerToCustomerWalletTransferRequest updateCustomerProfileRequest =
                ConvertToTransfersRequest(inputCustomerToCustomerWalletTransfer);

            ExternalCustomerToCustomerWalletTransferResponse updateCustomerProfileResponse =
                            CreateExternalCustomerToCustomerWalletTransferResponseResult();

            CustomerToCustomerWalletTransfer expectedCustomerToCustomerWalletTransfer = inputCustomerToCustomerWalletTransfer.DeepClone();
            expectedCustomerToCustomerWalletTransfer = ConvertToTransfersResponse(inputCustomerToCustomerWalletTransfer, updateCustomerProfileResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            this.wireMockServer.Given(
                Request.Create()
                .UsingPost()
                    .WithPath($"/transfer/wallet")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}")
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithBody(JsonConvert.SerializeObject(
                        updateCustomerProfileRequest,
                        jsonSerializationSettings)))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(updateCustomerProfileResponse));

            // when
            CustomerToCustomerWalletTransfer actualResult =
                await this.xPressWalletClient.Transfers.CustomerToCustomerWalletTransferAsync(inputCustomerToCustomerWalletTransfer);

            // then
            actualResult.Should().BeEquivalentTo(expectedCustomerToCustomerWalletTransfer);
        }
    }
}
