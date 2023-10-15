using FluentAssertions;
using Force.DeepCloner;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalProviPay.ExternalPayment;
using Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.Payment;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.BillPayment
{
    public partial class BillPaymentServiceTests
    {
        [Fact]
        public async Task ShouldPostChargePaymentWithChargePaymentRequestAsync()
        {
            // given 



            dynamic createRandomPaymentRequestProperties =
              CreateRandomPaymentRequestProperties();

            dynamic createRandomPaymentResponseProperties =
                CreateRandomPaymentResponseProperties();


            var randomExternalPaymentRequest = new ExternalPaymentRequest
            {
                BillId = createRandomPaymentRequestProperties.BillId,
                ChannelRef = createRandomPaymentRequestProperties.ChannelRef,
                CustomerAccountNo = createRandomPaymentRequestProperties.CustomerAccountNo,
                Inputs = ((List<dynamic>)createRandomPaymentRequestProperties.Inputs).Select(inputs =>
                {
                    return new ExternalPaymentRequest.Input
                    {
                        Key = inputs.Key,
                        Value = inputs.Value
                    };
                }).ToList(),

            };

            var randomExternalPaymentResponse = new ExternalPaymentResponse
            {

                Data = createRandomPaymentResponseProperties.Data,
                Message = createRandomPaymentResponseProperties.Message,
                ResponseCode = createRandomPaymentResponseProperties.ResponseCode,
                ResponseMessage = createRandomPaymentResponseProperties.ResponseMessage,
             
                   
            };


            var randomPaymentRequest = new PaymentRequest
            {
                BillId = createRandomPaymentRequestProperties.BillId,
                ChannelRef = createRandomPaymentRequestProperties.ChannelRef,
                CustomerAccountNo = createRandomPaymentRequestProperties.CustomerAccountNo,
                Inputs = ((List<dynamic>)createRandomPaymentRequestProperties.Inputs).Select(inputs =>
                {
                    return new PaymentRequest.Input
                    {
                        Key = inputs.Key,
                        Value = inputs.Value
                    };
                }).ToList(),

            };

            var randomPaymentResponse = new PaymentResponse
            {
                Data = createRandomPaymentResponseProperties.Data,
                Message = createRandomPaymentResponseProperties.Message,
                ResponseCode = createRandomPaymentResponseProperties.ResponseCode,
                ResponseMessage = createRandomPaymentResponseProperties.ResponseMessage,

            };


            var randomPayment = new Payment
            {
                Request = randomPaymentRequest,
            };

            var inputBillId = GetRandomString();

            Payment inputPayment = randomPayment;
            Payment expectedPayment = inputPayment.DeepClone();
            expectedPayment.Response = randomPaymentResponse;

            ExternalPaymentRequest mappedExternalPaymentRequest =
               randomExternalPaymentRequest;

            ExternalPaymentResponse returnedExternalPaymentResponse =
                randomExternalPaymentResponse;

            this.proviPayBrokerMock.Setup(broker =>
                broker.PostPaymentAsync(It.Is(
                      SameExternalPaymentRequestAs(mappedExternalPaymentRequest))))
                     .ReturnsAsync(returnedExternalPaymentResponse);

            // when
            Payment actualCreatePayment =
               await this.billPaymentService.PostPaymentRequestAsync(inputPayment);

            // then
            actualCreatePayment.Should().BeEquivalentTo(expectedPayment);

            this.proviPayBrokerMock.Verify(broker =>
               broker.PostPaymentAsync(It.Is(
                   SameExternalPaymentRequestAs(mappedExternalPaymentRequest))),
                   Times.Once);

            this.proviPayBrokerMock.VerifyNoOtherCalls();
        }
    }
}
