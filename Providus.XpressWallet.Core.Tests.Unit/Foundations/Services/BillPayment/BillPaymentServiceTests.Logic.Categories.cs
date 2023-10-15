using FluentAssertions;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalProviPay.ExternalCategories;
using Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.Categories;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.BillPayment
{
    public partial class BillPaymentServiceTests
    {
        [Fact]
        public async Task ShouldRetrieveCategoriesWithCategoriesRequestAsync()
        {
            // given 


            dynamic createRandomCategoriesResponseProperties =
                CreateRandomCategoriesResponseProperties();



            var randomExternalCategoriesResponse = ((List<dynamic>)createRandomCategoriesResponseProperties).Select(response =>
            {
                return new ExternalCategoriesResponse
                {
                    CategoryId = response.CategoryId,
                    Name = response.Name,
                    ListOrder = response.ListOrder,
                };
            }).ToList();



            var randomCategoriesResponse = ((List<dynamic>)createRandomCategoriesResponseProperties).Select(response =>
            {
                return new CategoriesResponse
                {
                    CategoryId = response.CategoryId,
                    Name = response.Name,
                    ListOrder = response.ListOrder,
                };
            }).ToList();



            var expectedResponse = new Categories
            {
                Response = randomCategoriesResponse
            };

           

            List<ExternalCategoriesResponse> returnedExternalCategoriesResponse =
                randomExternalCategoriesResponse;

            this.proviPayBrokerMock.Setup(broker =>
                broker.GetCategoriesAsync())
                     .ReturnsAsync(returnedExternalCategoriesResponse);

            // when
            Categories actualCreateCategories =
               await this.billPaymentService.GetCategoriesRequestAsync();

            // then
            actualCreateCategories.Should().BeEquivalentTo(expectedResponse);

            this.proviPayBrokerMock.Verify(broker =>
               broker.GetCategoriesAsync(),
                   Times.Once);

            this.proviPayBrokerMock.VerifyNoOtherCalls();
        }
    }
}
