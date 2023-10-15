using FluentAssertions;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalProviPay.ExternalPaymentInquiry;
using Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.PaymentInquiry;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.BillPayment
{
    public partial class BillPaymentServiceTests
    {
        [Fact]
        public async Task ShouldRetrievePaymentInquiryWithPaymentInquiryRequestAsync()
        {
            // given 


            dynamic createRandomPaymentInquiryResponseProperties =
                CreateRandomPaymentInquiryResponseProperties();



            var randomExternalPaymentInquiryResponse = new ExternalPaymentInquiryResponse
            {

                Status = createRandomPaymentInquiryResponseProperties.Status,
                   
            };


   
            var randomPaymentInquiryResponse = new PaymentInquiryResponse
            {
                Status = createRandomPaymentInquiryResponseProperties.Status

            };



            var expectedResponse = new PaymentInquiry
            {
                Response = randomPaymentInquiryResponse
            };

            var inputBillId = GetRandomString();

            ExternalPaymentInquiryResponse returnedExternalPaymentInquiryResponse =
                randomExternalPaymentInquiryResponse;

            this.proviPayBrokerMock.Setup(broker =>
                broker.GetPaymentInquiryAsync(It.IsAny<string>()))
                     .ReturnsAsync(returnedExternalPaymentInquiryResponse);

            // when
            PaymentInquiry actualCreatePaymentInquiry =
               await this.billPaymentService.GetPaymentInquiryRequestAsync(inputBillId);

            // then
            actualCreatePaymentInquiry.Should().BeEquivalentTo(expectedResponse);

            this.proviPayBrokerMock.Verify(broker =>
               broker.GetPaymentInquiryAsync(It.IsAny<string>()),
                   Times.Once);

            this.proviPayBrokerMock.VerifyNoOtherCalls();
        }
    }
}
