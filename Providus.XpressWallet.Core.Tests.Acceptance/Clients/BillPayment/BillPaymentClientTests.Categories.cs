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
        public async Task ShouldRetrieveCategoriesAsync()
        {
            // given
           

            List<ExternalCategoriesResponse> randomExternalCategoriesResponse =
                CreateExternalCategoriesResponseResult();

            List<ExternalCategoriesResponse> retrievedCategoriesResult =
                randomExternalCategoriesResponse;

            Categories expectedCategoriesResponse =
                ConvertToBillPaymentResponse(retrievedCategoriesResult);

            string credentials = Convert.ToBase64String(
               Encoding.ASCII.GetBytes($"{this.userName}:{this.password}"));

            this.wireMockServer.Given(
                Request.Create()
                .UsingGet()
                    .WithPath($"/provipay/webapi/categories")
                    .WithHeader("Authorization", $"Basic {credentials}")
                    )
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(retrievedCategoriesResult));

            // when
            Categories actualResult =
                await this.xPressWalletClient.BillPayment.RetrieveCategoriesAsync();

            // then
            actualResult.Should().BeEquivalentTo(expectedCategoriesResponse);
        }
    }
}
