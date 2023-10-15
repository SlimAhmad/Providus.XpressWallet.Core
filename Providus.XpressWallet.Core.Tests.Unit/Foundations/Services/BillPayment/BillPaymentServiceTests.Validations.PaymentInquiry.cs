using FluentAssertions;
using Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.Exceptions;
using Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.PaymentInquiry;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.BillPayment
{
    public partial class BillPaymentServiceTests
    {



        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public async Task ShouldThrowValidationExceptionOnGetPaymentInquiryIfPaymentInquiryIsInvalidAsync(
           string invalidBillId)
        {
            // given


            var invalidPaymentInquiryException = new InvalidBillPaymentException();

            invalidPaymentInquiryException.AddData(
                key: nameof(PaymentInquiry),
                values: "Value is required");

;
            var expectedBillPaymentValidationException =
                new BillPaymentValidationException(invalidPaymentInquiryException);

            // when
            ValueTask<PaymentInquiry> PaymentInquiryTask =
                this.billPaymentService.GetPaymentInquiryRequestAsync(invalidBillId);

            BillPaymentValidationException actualBillPaymentValidationException =
                await Assert.ThrowsAsync<BillPaymentValidationException>(PaymentInquiryTask.AsTask);

            // then
            actualBillPaymentValidationException.Should().BeEquivalentTo(
                expectedBillPaymentValidationException);

            this.proviPayBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnGetPaymentInquiryIfGetPaymentInquiryIsEmptyAsync()
        {
            // given
            var inputBillId = string.Empty;

            var invalidPaymentInquiryException = new InvalidBillPaymentException();


            invalidPaymentInquiryException.AddData(
                 key: nameof(PaymentInquiry),
                 values: "Value is required");


            var expectedBillPaymentValidationException =
                new BillPaymentValidationException(invalidPaymentInquiryException);

            // when
            ValueTask<PaymentInquiry> PaymentInquiryTask =
                this.billPaymentService.GetPaymentInquiryRequestAsync(inputBillId);

            BillPaymentValidationException actualBillPaymentValidationException =
                await Assert.ThrowsAsync<BillPaymentValidationException>(
                    PaymentInquiryTask.AsTask);

            // then
            actualBillPaymentValidationException.Should().BeEquivalentTo(
                expectedBillPaymentValidationException);

            this.proviPayBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

    }
}