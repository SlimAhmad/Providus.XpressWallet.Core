using FluentAssertions;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalProviPay.ExternalPaymentInquiry;
using Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.PaymentInquiry;
using System.Text;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;


namespace Providus.XpressWallet.Core.Tests.Acceptance.Clients.BillPayment
{
    public partial class BillPaymentClientTests
    {
        [Fact]
        public async Task ShouldRetrievePaymentInquiryAsync()
        {
            // given
            string randomString = GetRandomString();
            string randomApiKey = randomString;
            string inputTransactionReference = randomApiKey;

            ExternalPaymentInquiryResponse randomExternalPaymentInquiryResponse =
                CreateExternalPaymentInquiryResponseResult();

            ExternalPaymentInquiryResponse retrievedPaymentInquiryResult =
                randomExternalPaymentInquiryResponse;

            PaymentInquiry expectedPaymentInquiryResponse =
                ConvertToBillPaymentResponse(retrievedPaymentInquiryResult);

            string credentials = Convert.ToBase64String(
               Encoding.ASCII.GetBytes($"{this.userName}:{this.password}"));

            this.wireMockServer.Given(
                Request.Create()
                .UsingGet()
                    .WithPath($"/provipay/webapi/makepayment/enquiry")
                    .WithHeader("Authorization", $"Basic {credentials}")
                    .WithParam("txn_ref",inputTransactionReference)
                    )
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(retrievedPaymentInquiryResult));

            // when
            PaymentInquiry actualResult =
                await this.xPressWalletClient.BillPayment.RetrievePaymentInquiryAsync(inputTransactionReference);

            // then
            actualResult.Should().BeEquivalentTo(expectedPaymentInquiryResponse);
        }
    }
}
