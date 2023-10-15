using FluentAssertions;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalProviPay.ExternalFields;
using Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.Fields;
using System.Text;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;


namespace Providus.XpressWallet.Core.Tests.Acceptance.Clients.BillPayment
{
    public partial class BillPaymentClientTests
    {
        [Fact]
        public async Task ShouldRetrieveFieldsAsync()
        {
            // given
            string randomString = GetRandomString();
            string randomApiKey = randomString;
            string inputBillId = randomApiKey;

            ExternalFieldsResponse randomExternalFieldsResponse =
                CreateExternalFieldsResponseResult();

            ExternalFieldsResponse retrievedFieldsResult =
                randomExternalFieldsResponse;

            Fields expectedFieldsResponse =
                ConvertToBillPaymentResponse(retrievedFieldsResult);

            string credentials = Convert.ToBase64String(
               Encoding.ASCII.GetBytes($"{this.userName}:{this.password}"));

            this.wireMockServer.Given(
                Request.Create()
                .UsingGet()
                    .WithPath($"/provipay/webapi/field/assigned/byBillId/{inputBillId}")
                    .WithHeader("Authorization", $"Basic {credentials}")
                    )
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(retrievedFieldsResult));

            // when
            Fields actualResult =
                await this.xPressWalletClient.BillPayment.RetrieveFieldsAsync(inputBillId);

            // then
            actualResult.Should().BeEquivalentTo(expectedFieldsResponse);
        }
    }
}
