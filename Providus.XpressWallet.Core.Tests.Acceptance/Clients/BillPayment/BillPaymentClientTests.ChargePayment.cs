using FluentAssertions;
using Force.DeepCloner;
using Newtonsoft.Json;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalProviPay.ExternalPayment;
using Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.Payment;
using System.Text;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace Providus.XpressWallet.Core.Tests.Acceptance.Clients.BillPayment
{
    public partial class BillPaymentClientTests
    {
        [Fact]
        public async Task ShouldChargePaymentAsync()
        {
            // given
     

            Payment randomPayment = CreatePaymentResponseResult();
            Payment inputPayment = randomPayment;

            ExternalPaymentRequest updatePaymentRequest =
                ConvertToBillPaymentRequest(inputPayment);

            ExternalPaymentResponse updatePaymentResponse =
                            CreateExternalPaymentResponseResult();

            Payment expectedPayment = inputPayment.DeepClone();
            expectedPayment = ConvertToBillPaymentResponse(inputPayment, updatePaymentResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            string credentials = Convert.ToBase64String(
               Encoding.ASCII.GetBytes($"{this.userName}:{this.password}"));

            this.wireMockServer.Given(
                Request.Create()
                .UsingPost()
                    .WithPath($"/provipay/webapi/makepayment")
                    .WithHeader("Authorization", $"Basic {credentials}")
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithBody(JsonConvert.SerializeObject(
                        updatePaymentRequest,
                        jsonSerializationSettings)))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(updatePaymentResponse));

            // when
            Payment actualResult =
                await this.xPressWalletClient.BillPayment.ChargePaymentAsync(inputPayment);

            // then
            actualResult.Should().BeEquivalentTo(expectedPayment);
        }
    }
}
