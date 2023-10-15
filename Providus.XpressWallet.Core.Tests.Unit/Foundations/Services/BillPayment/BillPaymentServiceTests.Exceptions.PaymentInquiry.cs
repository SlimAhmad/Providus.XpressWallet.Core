using FluentAssertions;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.Exceptions;
using Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.PaymentInquiry;
using RESTFulSense.Exceptions;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.BillPayment
{
    public partial class BillPaymentServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPaymentInquiryRequestIfUrlNotFoundAsync()
        {
            // given
            var inputTransactionReference = GetRandomString();


            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException();

            var invalidConfigurationBillPaymentException =
                new InvalidConfigurationBillPaymentException(
                    message: "Invalid BillPayment configuration error occurred, contact support.",
                    httpResponseUrlNotFoundException);

            var expectedBillPaymentDependencyException =
                new BillPaymentDependencyException(
                    message: "BillPayment dependency error occurred, contact support.",
                    invalidConfigurationBillPaymentException);

            this.proviPayBrokerMock.Setup(broker =>
                broker.GetPaymentInquiryAsync(It.IsAny<string>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<PaymentInquiry> retrievePaymentInquiryTask =
               this.billPaymentService.GetPaymentInquiryRequestAsync(inputTransactionReference);

            BillPaymentDependencyException
                actualBillPaymentDependencyException =
                    await Assert.ThrowsAsync<BillPaymentDependencyException>(
                        retrievePaymentInquiryTask.AsTask);

            // then
            actualBillPaymentDependencyException.Should().BeEquivalentTo(
                expectedBillPaymentDependencyException);

            this.proviPayBrokerMock.Verify(broker =>
                broker.GetPaymentInquiryAsync(It.IsAny<string>()),
                    Times.Once);

            this.proviPayBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnPaymentInquiryRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            var inputTransactionReference = GetRandomString();

        
            var unauthorizedBillPaymentException =
                new UnauthorizedBillPaymentException(unauthorizedException);

            var expectedBillPaymentDependencyException =
                new BillPaymentDependencyException(unauthorizedBillPaymentException);

            this.proviPayBrokerMock.Setup(broker =>
                 broker.GetPaymentInquiryAsync(It.IsAny<string>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<PaymentInquiry> retrievePaymentInquiryTask =
               this.billPaymentService.GetPaymentInquiryRequestAsync(inputTransactionReference);

            BillPaymentDependencyException
                actualBillPaymentDependencyException =
                    await Assert.ThrowsAsync<BillPaymentDependencyException>(
                        retrievePaymentInquiryTask.AsTask);

            // then
            actualBillPaymentDependencyException.Should().BeEquivalentTo(
                expectedBillPaymentDependencyException);

            this.proviPayBrokerMock.Verify(broker =>
                broker.GetPaymentInquiryAsync(It.IsAny<string>()),
                    Times.Once);

            this.proviPayBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPaymentInquiryRequestIfNotFoundOccurredAsync()
        {
            // given
            var inputTransactionReference = GetRandomString();



            var httpResponseNotFoundException =
                new HttpResponseNotFoundException();

            var notFoundBillPaymentException =
                new NotFoundBillPaymentException(
                    message: "Not found BillPayment error occurred, fix errors and try again.",
                    httpResponseNotFoundException);

            var expectedBillPaymentDependencyValidationException =
                new BillPaymentDependencyValidationException(
                    message: "BillPayment dependency validation error occurred, contact support.",
                    notFoundBillPaymentException);

            this.proviPayBrokerMock.Setup(broker =>
                broker.GetPaymentInquiryAsync(It.IsAny<string>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<PaymentInquiry> retrievePaymentInquiryTask =
               this.billPaymentService.GetPaymentInquiryRequestAsync(inputTransactionReference);

            BillPaymentDependencyValidationException
                actualBillPaymentDependencyValidationException =
                    await Assert.ThrowsAsync<BillPaymentDependencyValidationException>(
                        retrievePaymentInquiryTask.AsTask);

            // then
            actualBillPaymentDependencyValidationException.Should().BeEquivalentTo(
                expectedBillPaymentDependencyValidationException);

            this.proviPayBrokerMock.Verify(broker =>
                broker.GetPaymentInquiryAsync(It.IsAny<string>()),
                    Times.Once);

            this.proviPayBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPaymentInquiryRequestIfBadRequestOccurredAsync()
        {
            // given
            var inputTransactionReference = GetRandomString();

                

            var httpResponseBadRequestException =
                new HttpResponseBadRequestException();

            var invalidBillPaymentException =
                new InvalidBillPaymentException(
                    message: "Invalid BillPayment error occurred, fix errors and try again.",
                    httpResponseBadRequestException);

            var expectedBillPaymentDependencyValidationException =
                new BillPaymentDependencyValidationException(
                    message: "BillPayment dependency validation error occurred, contact support.",
                    invalidBillPaymentException);

            this.proviPayBrokerMock.Setup(broker =>
                broker.GetPaymentInquiryAsync(It.IsAny<string>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<PaymentInquiry> retrievePaymentInquiryTask =
               this.billPaymentService.GetPaymentInquiryRequestAsync(inputTransactionReference);

            BillPaymentDependencyValidationException
                actualBillPaymentDependencyValidationException =
                    await Assert.ThrowsAsync<BillPaymentDependencyValidationException>(
                        retrievePaymentInquiryTask.AsTask);

            // then
            actualBillPaymentDependencyValidationException.Should().BeEquivalentTo(
                expectedBillPaymentDependencyValidationException);

            this.proviPayBrokerMock.Verify(broker =>
                broker.GetPaymentInquiryAsync(It.IsAny<string>()),
                    Times.Once);

            this.proviPayBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPaymentInquiryRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            var inputTransactionReference = GetRandomString();

                

            var httpResponseTooManyRequestsException =
                new HttpResponseTooManyRequestsException();

            var excessiveCallBillPaymentException =
                new ExcessiveCallBillPaymentException(
                    message: "Excessive call error occurred, limit your calls.",
                    httpResponseTooManyRequestsException);

            var expectedBillPaymentDependencyValidationException =
                new BillPaymentDependencyValidationException(
                    message: "BillPayment dependency validation error occurred, contact support.",
                    excessiveCallBillPaymentException);

            this.proviPayBrokerMock.Setup(broker =>
                 broker.GetPaymentInquiryAsync(It.IsAny<string>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<PaymentInquiry> retrievePaymentInquiryTask =
               this.billPaymentService.GetPaymentInquiryRequestAsync(inputTransactionReference);

            BillPaymentDependencyValidationException actualBillPaymentDependencyValidationException =
                await Assert.ThrowsAsync<BillPaymentDependencyValidationException>(
                    retrievePaymentInquiryTask.AsTask);

            // then
            actualBillPaymentDependencyValidationException.Should().BeEquivalentTo(
                expectedBillPaymentDependencyValidationException);

            this.proviPayBrokerMock.Verify(broker =>
                broker.GetPaymentInquiryAsync(It.IsAny<string>()),
                    Times.Once);

            this.proviPayBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPaymentInquiryRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            var inputTransactionReference = GetRandomString();

                

            var httpResponseException =
                new HttpResponseException();

            var failedServerBillPaymentException =
                new FailedServerBillPaymentException(
                    message: "Failed BillPayment server error occurred, contact support.",
                    httpResponseException);

            var expectedBillPaymentDependencyException =
                new BillPaymentDependencyException(
                    message: "BillPayment dependency error occurred, contact support.",
                    failedServerBillPaymentException);

            this.proviPayBrokerMock.Setup(broker =>
                 broker.GetPaymentInquiryAsync(It.IsAny<string>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<PaymentInquiry> retrievePaymentInquiryTask =
               this.billPaymentService.GetPaymentInquiryRequestAsync(inputTransactionReference);

            BillPaymentDependencyException actualBillPaymentDependencyException =
                await Assert.ThrowsAsync<BillPaymentDependencyException>(
                    retrievePaymentInquiryTask.AsTask);

            // then
            actualBillPaymentDependencyException.Should().BeEquivalentTo(
                expectedBillPaymentDependencyException);

            this.proviPayBrokerMock.Verify(broker =>
                broker.GetPaymentInquiryAsync(It.IsAny<string>()),
                    Times.Once);

            this.proviPayBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnPaymentInquiryRequestIfServiceErrorOccurredAsync()
        {
            // given
            var inputTransactionReference = GetRandomString();

                
            var serviceException = new Exception();

            var failedBillPaymentServiceException =
                new FailedBillPaymentServiceException(serviceException);

            var expectedBillPaymentServiceException =
                new BillPaymentServiceException(failedBillPaymentServiceException);

            this.proviPayBrokerMock.Setup(broker =>
                broker.GetPaymentInquiryAsync(It.IsAny<string>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<PaymentInquiry> retrievePaymentInquiryTask =
               this.billPaymentService.GetPaymentInquiryRequestAsync(inputTransactionReference);

            BillPaymentServiceException actualBillPaymentServiceException =
                await Assert.ThrowsAsync<BillPaymentServiceException>(
                    retrievePaymentInquiryTask.AsTask);

            // then
            actualBillPaymentServiceException.Should().BeEquivalentTo(
                expectedBillPaymentServiceException);

            this.proviPayBrokerMock.Verify(broker =>
                broker.GetPaymentInquiryAsync(It.IsAny<string>()),
                    Times.Once);

            this.proviPayBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
