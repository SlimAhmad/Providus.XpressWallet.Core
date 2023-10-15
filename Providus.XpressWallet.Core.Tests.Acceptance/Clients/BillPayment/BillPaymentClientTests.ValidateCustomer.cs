using FluentAssertions;
using Force.DeepCloner;
using Newtonsoft.Json;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalProviPay.ExternalValidate;
using Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.Validate;
using System.Text;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace Providus.XpressWallet.Core.Tests.Acceptance.Clients.BillPayment
{
    public partial class BillPaymentClientTests
    {
        [Fact]
        public async Task ShouldValidateCustomerAsync()
        {
            // given
            string randomString = GetRandomString();
            string randomCustomerId = randomString;
            string inputBillId = randomCustomerId;

            Validate randomValidate = CreateValidateResponseResult();
            Validate inputValidate = randomValidate;

            ExternalValidateRequest updateValidateCustomerRequest =
                ConvertToBillPaymentRequest(inputValidate);

            ExternalValidateResponse updateValidateCustomerResponse =
                            CreateExternalValidateResponseResult();

            Validate expectedValidate = inputValidate.DeepClone();
            expectedValidate = ConvertToBillPaymentResponse(inputValidate, updateValidateCustomerResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            string credentials = Convert.ToBase64String(
               Encoding.ASCII.GetBytes($"{this.userName}:{this.password}"));

            this.wireMockServer.Given(
                Request.Create()
                .UsingPost()
                    .WithPath($"/provipay/webapi/validate/{inputBillId}/customer")
                    .WithHeader("Authorization", $"Basic {credentials}")
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithBody(JsonConvert.SerializeObject(
                        updateValidateCustomerRequest,
                        jsonSerializationSettings)))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(updateValidateCustomerResponse));

            // when
            Validate actualResult =
                await this.xPressWalletClient.BillPayment.ValidateCustomerAsync(inputValidate, inputBillId);

            // then
            actualResult.Should().BeEquivalentTo(expectedValidate);
        }
    }
}
