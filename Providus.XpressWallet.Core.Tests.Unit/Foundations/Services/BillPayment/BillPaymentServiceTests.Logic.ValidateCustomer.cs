using FluentAssertions;
using Force.DeepCloner;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalProviPay.ExternalValidate;
using Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.Validate;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.BillPayment
{
    public partial class BillPaymentServiceTests
    {
        [Fact]
        public async Task ShouldPostValidateCustomerWithValidateCustomerRequestAsync()
        {
            // given 



            dynamic createRandomValidateRequestProperties =
              CreateRandomValidateRequestProperties();

            dynamic createRandomValidateResponseProperties =
                CreateRandomValidateResponseProperties();


            var randomExternalValidateRequest = new ExternalValidateRequest
            {
                BillId = createRandomValidateRequestProperties.BillId,
                ChannelRef = createRandomValidateRequestProperties.ChannelRef,
                CustomerAccountNo = createRandomValidateRequestProperties.CustomerAccountNo,
                Inputs = ((List<dynamic>)createRandomValidateRequestProperties.Inputs).Select(inputs =>
                {
                    return new ExternalValidateRequest.Input
                    {
                        Key = inputs.Key,
                        Value = inputs.Value
                    };
                }).ToList(),

            };

            var randomExternalValidateResponse = new ExternalValidateResponse
            {

               Balance = createRandomValidateResponseProperties.Balance,
               CustomerName = createRandomValidateResponseProperties.CustomerName,
               Message = createRandomValidateResponseProperties.Message,
               Successful = createRandomValidateResponseProperties.Successful
                   
            };


            var randomValidateRequest = new ValidateRequest
            {
                BillId = createRandomValidateRequestProperties.BillId,
                ChannelRef = createRandomValidateRequestProperties.ChannelRef,
                CustomerAccountNo = createRandomValidateRequestProperties.CustomerAccountNo,
                Inputs = ((List<dynamic>)createRandomValidateRequestProperties.Inputs).Select(inputs =>
                {
                    return new ValidateRequest.Input
                    {
                        Key = inputs.Key,
                        Value = inputs.Value
                    };
                }).ToList(),

            };

            var randomValidateResponse = new ValidateResponse
            {
                Balance = createRandomValidateResponseProperties.Balance,
                CustomerName = createRandomValidateResponseProperties.CustomerName,
                Message = createRandomValidateResponseProperties.Message,
                Successful = createRandomValidateResponseProperties.Successful
            };


            var randomValidate = new Validate
            {
                Request = randomValidateRequest,
            };

            var inputBillId = GetRandomString();

            Validate inputValidate = randomValidate;
            Validate expectedValidate = inputValidate.DeepClone();
            expectedValidate.Response = randomValidateResponse;

            ExternalValidateRequest mappedExternalValidateRequest =
               randomExternalValidateRequest;

            ExternalValidateResponse returnedExternalValidateResponse =
                randomExternalValidateResponse;

            this.proviPayBrokerMock.Setup(broker =>
                broker.PostValidateCustomerAsync(It.Is(
                      SameExternalValidateRequestAs(mappedExternalValidateRequest)),inputBillId))
                     .ReturnsAsync(returnedExternalValidateResponse);

            // when
            Validate actualCreateValidate =
               await this.billPaymentService.PostValidateCustomerRequestAsync(inputValidate,inputBillId);

            // then
            actualCreateValidate.Should().BeEquivalentTo(expectedValidate);

            this.proviPayBrokerMock.Verify(broker =>
               broker.PostValidateCustomerAsync(It.Is(
                   SameExternalValidateRequestAs(mappedExternalValidateRequest)), inputBillId),
                   Times.Once);

            this.proviPayBrokerMock.VerifyNoOtherCalls();
        }
    }
}
