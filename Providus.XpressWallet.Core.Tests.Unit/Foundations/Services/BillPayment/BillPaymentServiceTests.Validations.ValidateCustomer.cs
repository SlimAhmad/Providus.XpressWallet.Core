using FluentAssertions;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalProviPay.ExternalValidate;
using Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.Exceptions;
using Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.Validate;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.BillPayment
{
    public partial class BillPaymentServiceTests
    {

        [Fact]
        public async Task ShouldThrowValidationExceptionOnValidateCustomerIfValidateCustomerIsNullAsync()
        {
            // given
            Validate nullValidate = null;
            var nullValidateException = new NullBillPaymentException();

            var inputCustomerId = GetRandomString();

            var exceptedBillPaymentValidationException =
                new BillPaymentValidationException(nullValidateException);

            // when
            ValueTask<Validate> ValidateTask =
                this.billPaymentService.PostValidateCustomerRequestAsync(nullValidate,inputCustomerId);

            BillPaymentValidationException actualBillPaymentValidationException =
                await Assert.ThrowsAsync<BillPaymentValidationException>(
                    ValidateTask.AsTask);

            // then
            actualBillPaymentValidationException.Should()
                .BeEquivalentTo(exceptedBillPaymentValidationException);

            this.proviPayBrokerMock.Verify(broker =>
                broker.PostValidateCustomerAsync(
                    It.IsAny<ExternalValidateRequest>(),It.IsAny<string>()),
                        Times.Never);

            this.proviPayBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnValidateIfRequestIsNullAsync()
        {
            // given
            var invalidValidate = new Validate();
            invalidValidate.Request = null;
            var inputCustomerId = GetRandomString();

            var invalidValidateException =
                new InvalidBillPaymentException();

            invalidValidateException.AddData(
                key: nameof(ValidateRequest),
                values: "Value is required");

            var expectedBillPaymentValidationException =
                new BillPaymentValidationException(
                    invalidValidateException);

            // when
            ValueTask<Validate> ValidateTask =
                this.billPaymentService.PostValidateCustomerRequestAsync(invalidValidate,inputCustomerId);

            BillPaymentValidationException actualBillPaymentValidationException =
                await Assert.ThrowsAsync<BillPaymentValidationException>(
                    ValidateTask.AsTask);

            // then
            actualBillPaymentValidationException.Should()
                .BeEquivalentTo(expectedBillPaymentValidationException);

            this.proviPayBrokerMock.Verify(broker =>
                broker.PostValidateCustomerAsync(
                    It.IsAny<ExternalValidateRequest>(),It.IsAny<string>()),
                        Times.Never);

            this.proviPayBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null, null,null)]
        [InlineData("", "","")]
        [InlineData("  ", "  "," ")]
        public async Task ShouldThrowValidationExceptionOnPostValidateIfValidateIsInvalidAsync(
           string invalidBillId, string invalidChannelRef,string invalidCustomerAccountNo)
        {
            // given
            var updateCustomerProfile = new Validate
            {
                Request = new ValidateRequest
                {
                    BillId = invalidBillId,
                    ChannelRef = invalidChannelRef,
                    CustomerAccountNo = invalidCustomerAccountNo,
                   

                    
                }
            };

            var invalidValidateException = new InvalidBillPaymentException();

          

            invalidValidateException.AddData(
                    key: nameof(ValidateRequest.Inputs),
                    values: "Value is required");

            invalidValidateException.AddData(
                key: nameof(ValidateRequest.BillId),
                values: "Value is required");

            invalidValidateException.AddData(
               key: nameof(ValidateRequest.ChannelRef),
               values: "Value is required");

            invalidValidateException.AddData(
              key: nameof(ValidateRequest),
              values: "Value is required");

            invalidValidateException.AddData(
              key: nameof(ValidateRequest.CustomerAccountNo),
              values: "Value is required");



            var expectedBillPaymentValidationException =
                new BillPaymentValidationException(invalidValidateException);

            // when
            ValueTask<Validate> ValidateTask =
                this.billPaymentService.PostValidateCustomerRequestAsync(updateCustomerProfile,invalidBillId);

            BillPaymentValidationException actualBillPaymentValidationException =
                await Assert.ThrowsAsync<BillPaymentValidationException>(ValidateTask.AsTask);

            // then
            actualBillPaymentValidationException.Should().BeEquivalentTo(
                expectedBillPaymentValidationException);

            this.proviPayBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostValidateIfPostValidateIsEmptyAsync()
        {
            // given
            var updateCustomerProfile = new Validate
            {
                Request = new ValidateRequest
                {

                  ChannelRef = string.Empty,
                  CustomerAccountNo = string.Empty,
                  BillId = string.Empty,
                 


                }
            };
            var billId = string.Empty;

            var invalidValidateException = new InvalidBillPaymentException();


            invalidValidateException.AddData(
                       key: nameof(ValidateRequest.Inputs),
                       values: "Value is required");

            invalidValidateException.AddData(
                key: nameof(ValidateRequest.BillId),
                values: "Value is required");

            invalidValidateException.AddData(
               key: nameof(ValidateRequest.ChannelRef),
               values: "Value is required");

            invalidValidateException.AddData(
              key: nameof(ValidateRequest),
              values: "Value is required");

            invalidValidateException.AddData(
              key: nameof(ValidateRequest.CustomerAccountNo),
              values: "Value is required");





            var expectedBillPaymentValidationException =
                new BillPaymentValidationException(invalidValidateException);

            // when
            ValueTask<Validate> ValidateTask =
                this.billPaymentService.PostValidateCustomerRequestAsync(updateCustomerProfile,billId);

            BillPaymentValidationException actualBillPaymentValidationException =
                await Assert.ThrowsAsync<BillPaymentValidationException>(
                    ValidateTask.AsTask);

            // then
            actualBillPaymentValidationException.Should().BeEquivalentTo(
                expectedBillPaymentValidationException);

            this.proviPayBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

    }
}