using FluentAssertions;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalProviPay.ExternalCategories;
using Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.Categories;
using System.Text;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;


namespace Providus.XpressWallet.Core.Tests.Acceptance.Clients.BillPayment
{
    public partial class BillPaymentClientTests
    {
        [Fact]
        public async Task ShouldRetrieveBillsByCategoryAsync()
        {
            // given
            string randomString = GetRandomString();
            string randomApiKey = randomString;
            string inputCategoryId = randomApiKey;

            List<ExternalBillsByCategoryResponse> randomExternalBillsByCategoryResponse =
                CreateExternalBillsByCategoryResponseResult();

            List<ExternalBillsByCategoryResponse> retrievedBillsByCategoryResult =
                randomExternalBillsByCategoryResponse;

            BillsByCategory expectedBillsByCategoryResponse =
                ConvertToBillPaymentResponse(retrievedBillsByCategoryResult);

            string credentials = Convert.ToBase64String(
               Encoding.ASCII.GetBytes($"{this.userName}:{this.password}"));

            this.wireMockServer.Given(
                Request.Create()
                .UsingGet()
                    .WithPath($"/provipay/webapi/bill/assigned/byCategoryId/{inputCategoryId}")
                    .WithHeader("Authorization", $"Basic {credentials}"))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(retrievedBillsByCategoryResult));

            // when
            BillsByCategory actualResult =
                await this.xPressWalletClient.BillPayment.RetrieveBillsByCategoryAsync(inputCategoryId);

            // then
            actualResult.Should().BeEquivalentTo(expectedBillsByCategoryResponse);
        } 
    }
}
