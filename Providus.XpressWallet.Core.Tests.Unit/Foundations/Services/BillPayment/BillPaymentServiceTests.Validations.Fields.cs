using FluentAssertions;
using Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.Exceptions;
using Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.Fields;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.BillPayment
{
    public partial class BillPaymentServiceTests
    {



        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public async Task ShouldThrowValidationExceptionOnGetFieldsIfFieldsIsInvalidAsync(
           string invalidBillId)
        {
            // given


            var invalidFieldsException = new InvalidBillPaymentException();

            invalidFieldsException.AddData(
                key: nameof(Fields),
                values: "Value is required");

;
            var expectedBillPaymentValidationException =
                new BillPaymentValidationException(invalidFieldsException);

            // when
            ValueTask<Fields> FieldsTask =
                this.billPaymentService.GetFieldsRequestAsync(invalidBillId);

            BillPaymentValidationException actualBillPaymentValidationException =
                await Assert.ThrowsAsync<BillPaymentValidationException>(FieldsTask.AsTask);

            // then
            actualBillPaymentValidationException.Should().BeEquivalentTo(
                expectedBillPaymentValidationException);

            this.proviPayBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnGetFieldsIfGetFieldsIsEmptyAsync()
        {
            // given
            var inputBillId = string.Empty;

            var invalidFieldsException = new InvalidBillPaymentException();


            invalidFieldsException.AddData(
                 key: nameof(Fields),
                 values: "Value is required");


            var expectedBillPaymentValidationException =
                new BillPaymentValidationException(invalidFieldsException);

            // when
            ValueTask<Fields> FieldsTask =
                this.billPaymentService.GetFieldsRequestAsync(inputBillId);

            BillPaymentValidationException actualBillPaymentValidationException =
                await Assert.ThrowsAsync<BillPaymentValidationException>(
                    FieldsTask.AsTask);

            // then
            actualBillPaymentValidationException.Should().BeEquivalentTo(
                expectedBillPaymentValidationException);

            this.proviPayBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

    }
}