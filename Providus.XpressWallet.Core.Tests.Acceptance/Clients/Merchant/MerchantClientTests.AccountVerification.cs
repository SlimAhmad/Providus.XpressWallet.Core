using FluentAssertions;
using Force.DeepCloner;
using Newtonsoft.Json;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalMerchant;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Merchant;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace Providus.XpressWallet.Core.Tests.Acceptance.Clients.Merchant
{
    public partial class MerchantClientTests
    {
        [Fact]
        public async Task ShouldSendAccountVerificationAsync()
        {
            // given
            string randomString = GetRandomString();
            string randomCustomerId = randomString;
            string inputCustomerId = randomCustomerId;

            AccountVerification randomAccountVerification = CreateAccountVerificationResponseResult();
            AccountVerification inputAccountVerification = randomAccountVerification;

            ExternalAccountVerificationRequest updateCustomerProfileRequest =
                ConvertToMerchantRequest(inputAccountVerification);

            ExternalAccountVerificationResponse updateCustomerProfileResponse =
                            CreateExternalAccountVerificationResponseResult();

            AccountVerification expectedAccountVerification = inputAccountVerification.DeepClone();
            expectedAccountVerification = ConvertToMerchantResponse(inputAccountVerification, updateCustomerProfileResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            this.wireMockServer.Given(
                Request.Create()
                .UsingPut()
                    .WithPath($"/merchant/verify")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}")
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithBody(JsonConvert.SerializeObject(
                        updateCustomerProfileRequest,
                        jsonSerializationSettings)))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(updateCustomerProfileResponse));

            // when
            AccountVerification actualResult =
                await this.xPressWalletClient.Merchant.AccountVerificationAsync(inputAccountVerification);

            // then
            actualResult.Should().BeEquivalentTo(expectedAccountVerification);
        }
    }
}
