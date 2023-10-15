using FluentAssertions;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalProviPay.ExternalCategories;
using Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.Categories;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.BillPayment
{
    public partial class BillPaymentServiceTests
    {
        [Fact]
        public async Task ShouldRetrieveBillsByCategoryWithBillsByCategoryRequestAsync()
        {
            // given 


            dynamic createRandomBillsByCategoryResponseProperties =
                CreateRandomBillsByCategoryResponseProperties();



            var randomExternalBillsByCategoryResponse = ((List<dynamic>)createRandomBillsByCategoryResponseProperties).Select(response =>
            {
                return new ExternalBillsByCategoryResponse
                {
                    BillId = response.BillId,
                    CategoryId = response.CategoryId,
                    Description = response.Description,
                    ListOrder = response.ListOrder,
                    Name = response.Name,
                    SourceId = response.SourceId,
                };
            }).ToList();


   
            var randomBillsByCategoryResponse = ((List<dynamic>)createRandomBillsByCategoryResponseProperties).Select(response =>
            {
                return new BillsByCategoryResponse
                {
                    BillId = response.BillId,
                    CategoryId = response.CategoryId,
                    Description = response.Description,
                    ListOrder = response.ListOrder,
                    Name = response.Name,
                    SourceId = response.SourceId,
                };
            }).ToList();



            var expectedResponse = new BillsByCategory
            {
                Response = randomBillsByCategoryResponse
            };

            var inputCustomerId = GetRandomString();

            List<ExternalBillsByCategoryResponse> returnedExternalBillsByCategoryResponse =
                randomExternalBillsByCategoryResponse;

            this.proviPayBrokerMock.Setup(broker =>
                broker.GetBillsByCategoryAsync(It.IsAny<string>()))
                     .ReturnsAsync(returnedExternalBillsByCategoryResponse);

            // when
            BillsByCategory actualCreateBillsByCategory =
               await this.billPaymentService.GetBillsByCategoryRequestAsync(inputCustomerId);

            // then
            actualCreateBillsByCategory.Should().BeEquivalentTo(expectedResponse);

            this.proviPayBrokerMock.Verify(broker =>
               broker.GetBillsByCategoryAsync(It.IsAny<string>()),
                   Times.Once);

            this.proviPayBrokerMock.VerifyNoOtherCalls();
        }
    }
}
