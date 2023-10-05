using FluentAssertions;
using Force.DeepCloner;
using Newtonsoft.Json;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalWallet;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Wallet;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace Providus.XpressWallet.Core.Tests.Acceptance.Clients.Wallet
{
    public partial class WalletClientTests
    {
        [Fact]
        public async Task ShouldFundMerchantSandBoxWalletAsync()
        {
            // given
            string randomString = GetRandomString();
            string randomCustomerId = randomString;
            string inputCustomerId = randomCustomerId;

            FundMerchantSandBoxWallet randomFundMerchantSandBoxWallet = CreateFundMerchantSandBoxWalletResponseResult();
            FundMerchantSandBoxWallet inputFundMerchantSandBoxWallet = randomFundMerchantSandBoxWallet;

            ExternalFundMerchantSandBoxWalletRequest updateCustomerProfileRequest =
                ConvertToWalletRequest(inputFundMerchantSandBoxWallet);

            ExternalFundMerchantSandBoxWalletResponse updateCustomerProfileResponse =
                            CreateExternalFundMerchantSandBoxWalletResponseResult();

            FundMerchantSandBoxWallet expectedFundMerchantSandBoxWallet = inputFundMerchantSandBoxWallet.DeepClone();
            expectedFundMerchantSandBoxWallet = ConvertToWalletResponse(inputFundMerchantSandBoxWallet, updateCustomerProfileResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            this.wireMockServer.Given(
                Request.Create()
                .UsingPost()
                    .WithPath($"/merchant/fund-wallet")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}")
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithBody(JsonConvert.SerializeObject(
                        updateCustomerProfileRequest,
                        jsonSerializationSettings)))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(updateCustomerProfileResponse));

            // when
            FundMerchantSandBoxWallet actualResult =
                await this.xPressWalletClient.Wallet.FundMerchantSandBoxWalletAsync(inputFundMerchantSandBoxWallet);

            // then
            actualResult.Should().BeEquivalentTo(expectedFundMerchantSandBoxWallet);
        }
    }
}
