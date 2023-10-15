using FluentAssertions;
using Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.Categories;
using Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.Exceptions;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.BillPayment
{
    public partial class BillPaymentServiceTests
    {



        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public async Task ShouldThrowValidationExceptionOnGetBillsByCategoryIfBillsByCategoryIsInvalidAsync(
           string invalidCategoryId)
        {
            // given


            var invalidBillsByCategoryException = new InvalidBillPaymentException();

            invalidBillsByCategoryException.AddData(
                key: nameof(BillsByCategory),
                values: "Value is required");

;
            var expectedBillPaymentValidationException =
                new BillPaymentValidationException(invalidBillsByCategoryException);

            // when
            ValueTask<BillsByCategory> BillsByCategoryTask =
                this.billPaymentService.GetBillsByCategoryRequestAsync(invalidCategoryId);

            BillPaymentValidationException actualBillPaymentValidationException =
                await Assert.ThrowsAsync<BillPaymentValidationException>(BillsByCategoryTask.AsTask);

            // then
            actualBillPaymentValidationException.Should().BeEquivalentTo(
                expectedBillPaymentValidationException);

            this.proviPayBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnGetBillsByCategoryIfGetBillsByCategoryIsEmptyAsync()
        {
            // given
            var inputPhoneNumber = string.Empty;

            var invalidBillsByCategoryException = new InvalidBillPaymentException();


            invalidBillsByCategoryException.AddData(
                 key: nameof(BillsByCategory),
                 values: "Value is required");


            var expectedBillPaymentValidationException =
                new BillPaymentValidationException(invalidBillsByCategoryException);

            // when
            ValueTask<BillsByCategory> BillsByCategoryTask =
                this.billPaymentService.GetBillsByCategoryRequestAsync(inputPhoneNumber);

            BillPaymentValidationException actualBillPaymentValidationException =
                await Assert.ThrowsAsync<BillPaymentValidationException>(
                    BillsByCategoryTask.AsTask);

            // then
            actualBillPaymentValidationException.Should().BeEquivalentTo(
                expectedBillPaymentValidationException);

            this.proviPayBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

    }
}