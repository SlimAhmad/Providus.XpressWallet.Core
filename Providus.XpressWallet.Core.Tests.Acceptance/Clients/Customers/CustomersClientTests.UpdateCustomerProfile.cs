using FluentAssertions;
using Force.DeepCloner;
using Newtonsoft.Json;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalCustomers;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Customers;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace Providus.XpressWallet.Core.Tests.Acceptance.Clients.Customers
{
    public partial class CustomersClientTests
    {
        [Fact]
        public async Task ShouldUpdateCustomerProfileAsync()
        {
            // given
            string randomString = GetRandomString();
            string randomCustomerId = randomString;
            string inputCustomerId = randomCustomerId;

            UpdateCustomerProfile randomUpdateCustomerProfile = CreateUpdateCustomerProfileResponseResult();
            UpdateCustomerProfile inputUpdateCustomerProfile = randomUpdateCustomerProfile;

            ExternalUpdateCustomerProfileRequest updateCustomerProfileRequest =
                ConvertToCustomersRequest(inputUpdateCustomerProfile);

            ExternalUpdateCustomerProfileResponse updateCustomerProfileResponse =
                            CreateExternalUpdateCustomerProfileResponseResult();

            UpdateCustomerProfile expectedUpdateCustomerProfile = inputUpdateCustomerProfile.DeepClone();
            expectedUpdateCustomerProfile = ConvertToCustomersResponse(inputUpdateCustomerProfile, updateCustomerProfileResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            this.wireMockServer.Given(
                Request.Create()
                .UsingPut()
                    .WithPath($"/customer/{inputCustomerId}")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}")
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithBody(JsonConvert.SerializeObject(
                        updateCustomerProfileRequest,
                        jsonSerializationSettings)))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(updateCustomerProfileResponse));

            // when
            UpdateCustomerProfile actualResult =
                await this.xPressWalletClient.Customers.UpdateCustomerProfileAsync(inputUpdateCustomerProfile, inputCustomerId);

            // then
            actualResult.Should().BeEquivalentTo(expectedUpdateCustomerProfile);
        }
    }
}
