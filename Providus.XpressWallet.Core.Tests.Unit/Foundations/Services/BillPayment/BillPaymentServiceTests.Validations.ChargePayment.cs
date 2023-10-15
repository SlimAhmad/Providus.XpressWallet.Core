using FluentAssertions;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalProviPay.ExternalPayment;
using Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.Exceptions;
using Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.Payment;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.BillPayment
{
    public partial class BillPaymentServiceTests
    {

        [Fact]
        public async Task ShouldThrowValidationExceptionOnChargePaymentIfChargePaymentIsNullAsync()
        {
            // given
            Payment nullPayment = null;
            var nullPaymentException = new NullBillPaymentException();

            

            var exceptedBillPaymentValidationException =
                new BillPaymentValidationException(nullPaymentException);

            // when
            ValueTask<Payment> PaymentTask =
                this.billPaymentService.PostPaymentRequestAsync(nullPayment);

            BillPaymentValidationException actualBillPaymentValidationException =
                await Assert.ThrowsAsync<BillPaymentValidationException>(
                    PaymentTask.AsTask);

            // then
            actualBillPaymentValidationException.Should()
                .BeEquivalentTo(exceptedBillPaymentValidationException);

            this.proviPayBrokerMock.Verify(broker =>
                broker.PostPaymentAsync(
                    It.IsAny<ExternalPaymentRequest>()),
                        Times.Never);

            this.proviPayBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPaymentIfRequestIsNullAsync()
        {
            // given
            var invalidPayment = new Payment();
            invalidPayment.Request = null;
            

            var invalidPaymentException =
                new InvalidBillPaymentException();

            invalidPaymentException.AddData(
                key: nameof(PaymentRequest),
                values: "Value is required");

            var expectedBillPaymentValidationException =
                new BillPaymentValidationException(
                    invalidPaymentException);

            // when
            ValueTask<Payment> PaymentTask =
                this.billPaymentService.PostPaymentRequestAsync(invalidPayment);

            BillPaymentValidationException actualBillPaymentValidationException =
                await Assert.ThrowsAsync<BillPaymentValidationException>(
                    PaymentTask.AsTask);

            // then
            actualBillPaymentValidationException.Should()
                .BeEquivalentTo(expectedBillPaymentValidationException);

            this.proviPayBrokerMock.Verify(broker =>
                broker.PostPaymentAsync(
                    It.IsAny<ExternalPaymentRequest>()),
                        Times.Never);

            this.proviPayBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null, null,null)]
        [InlineData("", "","")]
        [InlineData("  ", "  "," ")]
        public async Task ShouldThrowValidationExceptionOnPostPaymentIfPaymentIsInvalidAsync(
           string invalidBillId, string invalidChannelRef,string invalidCustomerAccountNo)
        {
            // given
            var updateCustomerProfile = new Payment
            {
                Request = new PaymentRequest
                {
                    BillId = invalidBillId,
                    ChannelRef = invalidChannelRef,
                    CustomerAccountNo = invalidCustomerAccountNo,
        
                    

                    
                }
            };

            var invalidPaymentException = new InvalidBillPaymentException();

          

            invalidPaymentException.AddData(
                    key: nameof(PaymentRequest.Inputs),
                    values: "Value is required");

            invalidPaymentException.AddData(
                key: nameof(PaymentRequest.BillId),
                values: "Value is required");

            invalidPaymentException.AddData(
               key: nameof(PaymentRequest.ChannelRef),
               values: "Value is required");


            invalidPaymentException.AddData(
              key: nameof(PaymentRequest.CustomerAccountNo),
              values: "Value is required");



            var expectedBillPaymentValidationException =
                new BillPaymentValidationException(invalidPaymentException);

            // when
            ValueTask<Payment> PaymentTask =
                this.billPaymentService.PostPaymentRequestAsync(updateCustomerProfile);

            BillPaymentValidationException actualBillPaymentValidationException =
                await Assert.ThrowsAsync<BillPaymentValidationException>(PaymentTask.AsTask);

            // then
            actualBillPaymentValidationException.Should().BeEquivalentTo(
                expectedBillPaymentValidationException);

            this.proviPayBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostPaymentIfPostPaymentIsEmptyAsync()
        {
            // given
            var updateCustomerProfile = new Payment
            {
                Request = new PaymentRequest
                {

                  ChannelRef = string.Empty,
                  CustomerAccountNo = string.Empty,
                  BillId = string.Empty,
                


                }
            };
            

            var invalidPaymentException = new InvalidBillPaymentException();


            invalidPaymentException.AddData(
                       key: nameof(PaymentRequest.Inputs),
                       values: "Value is required");

            invalidPaymentException.AddData(
                key: nameof(PaymentRequest.BillId),
                values: "Value is required");

            invalidPaymentException.AddData(
               key: nameof(PaymentRequest.ChannelRef),
               values: "Value is required");

            invalidPaymentException.AddData(
              key: nameof(PaymentRequest.CustomerAccountNo),
              values: "Value is required");





            var expectedBillPaymentValidationException =
                new BillPaymentValidationException(invalidPaymentException);

            // when
            ValueTask<Payment> PaymentTask =
                this.billPaymentService.PostPaymentRequestAsync(updateCustomerProfile);

            BillPaymentValidationException actualBillPaymentValidationException =
                await Assert.ThrowsAsync<BillPaymentValidationException>(
                    PaymentTask.AsTask);

            // then
            actualBillPaymentValidationException.Should().BeEquivalentTo(
                expectedBillPaymentValidationException);

            this.proviPayBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

    }
}