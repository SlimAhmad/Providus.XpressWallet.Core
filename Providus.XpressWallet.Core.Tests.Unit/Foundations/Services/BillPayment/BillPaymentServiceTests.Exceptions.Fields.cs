using FluentAssertions;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.Exceptions;
using Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.Fields;
using RESTFulSense.Exceptions;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.BillPayment
{
    public partial class BillPaymentServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnFieldsRequestIfUrlNotFoundAsync()
        {
            // given
            var inputBillId = GetRandomString();


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
                broker.GetFieldsAsync(It.IsAny<string>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<Fields> retrieveFieldsTask =
               this.billPaymentService.GetFieldsRequestAsync(inputBillId);

            BillPaymentDependencyException
                actualBillPaymentDependencyException =
                    await Assert.ThrowsAsync<BillPaymentDependencyException>(
                        retrieveFieldsTask.AsTask);

            // then
            actualBillPaymentDependencyException.Should().BeEquivalentTo(
                expectedBillPaymentDependencyException);

            this.proviPayBrokerMock.Verify(broker =>
                broker.GetFieldsAsync(It.IsAny<string>()),
                    Times.Once);

            this.proviPayBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnFieldsRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            var inputBillId = GetRandomString();

        
            var unauthorizedBillPaymentException =
                new UnauthorizedBillPaymentException(unauthorizedException);

            var expectedBillPaymentDependencyException =
                new BillPaymentDependencyException(unauthorizedBillPaymentException);

            this.proviPayBrokerMock.Setup(broker =>
                 broker.GetFieldsAsync(It.IsAny<string>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<Fields> retrieveFieldsTask =
               this.billPaymentService.GetFieldsRequestAsync(inputBillId);

            BillPaymentDependencyException
                actualBillPaymentDependencyException =
                    await Assert.ThrowsAsync<BillPaymentDependencyException>(
                        retrieveFieldsTask.AsTask);

            // then
            actualBillPaymentDependencyException.Should().BeEquivalentTo(
                expectedBillPaymentDependencyException);

            this.proviPayBrokerMock.Verify(broker =>
                broker.GetFieldsAsync(It.IsAny<string>()),
                    Times.Once);

            this.proviPayBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnFieldsRequestIfNotFoundOccurredAsync()
        {
            // given
            var inputBillId = GetRandomString();



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
                broker.GetFieldsAsync(It.IsAny<string>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<Fields> retrieveFieldsTask =
               this.billPaymentService.GetFieldsRequestAsync(inputBillId);

            BillPaymentDependencyValidationException
                actualBillPaymentDependencyValidationException =
                    await Assert.ThrowsAsync<BillPaymentDependencyValidationException>(
                        retrieveFieldsTask.AsTask);

            // then
            actualBillPaymentDependencyValidationException.Should().BeEquivalentTo(
                expectedBillPaymentDependencyValidationException);

            this.proviPayBrokerMock.Verify(broker =>
                broker.GetFieldsAsync(It.IsAny<string>()),
                    Times.Once);

            this.proviPayBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnFieldsRequestIfBadRequestOccurredAsync()
        {
            // given
            var inputBillId = GetRandomString();

                

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
                broker.GetFieldsAsync(It.IsAny<string>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<Fields> retrieveFieldsTask =
               this.billPaymentService.GetFieldsRequestAsync(inputBillId);

            BillPaymentDependencyValidationException
                actualBillPaymentDependencyValidationException =
                    await Assert.ThrowsAsync<BillPaymentDependencyValidationException>(
                        retrieveFieldsTask.AsTask);

            // then
            actualBillPaymentDependencyValidationException.Should().BeEquivalentTo(
                expectedBillPaymentDependencyValidationException);

            this.proviPayBrokerMock.Verify(broker =>
                broker.GetFieldsAsync(It.IsAny<string>()),
                    Times.Once);

            this.proviPayBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnFieldsRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            var inputBillId = GetRandomString();

                

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
                 broker.GetFieldsAsync(It.IsAny<string>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<Fields> retrieveFieldsTask =
               this.billPaymentService.GetFieldsRequestAsync(inputBillId);

            BillPaymentDependencyValidationException actualBillPaymentDependencyValidationException =
                await Assert.ThrowsAsync<BillPaymentDependencyValidationException>(
                    retrieveFieldsTask.AsTask);

            // then
            actualBillPaymentDependencyValidationException.Should().BeEquivalentTo(
                expectedBillPaymentDependencyValidationException);

            this.proviPayBrokerMock.Verify(broker =>
                broker.GetFieldsAsync(It.IsAny<string>()),
                    Times.Once);

            this.proviPayBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnFieldsRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            var inputBillId = GetRandomString();

                

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
                 broker.GetFieldsAsync(It.IsAny<string>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<Fields> retrieveFieldsTask =
               this.billPaymentService.GetFieldsRequestAsync(inputBillId);

            BillPaymentDependencyException actualBillPaymentDependencyException =
                await Assert.ThrowsAsync<BillPaymentDependencyException>(
                    retrieveFieldsTask.AsTask);

            // then
            actualBillPaymentDependencyException.Should().BeEquivalentTo(
                expectedBillPaymentDependencyException);

            this.proviPayBrokerMock.Verify(broker =>
                broker.GetFieldsAsync(It.IsAny<string>()),
                    Times.Once);

            this.proviPayBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnFieldsRequestIfServiceErrorOccurredAsync()
        {
            // given
            var inputBillId = GetRandomString();

                
            var serviceException = new Exception();

            var failedBillPaymentServiceException =
                new FailedBillPaymentServiceException(serviceException);

            var expectedBillPaymentServiceException =
                new BillPaymentServiceException(failedBillPaymentServiceException);

            this.proviPayBrokerMock.Setup(broker =>
                broker.GetFieldsAsync(It.IsAny<string>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<Fields> retrieveFieldsTask =
               this.billPaymentService.GetFieldsRequestAsync(inputBillId);

            BillPaymentServiceException actualBillPaymentServiceException =
                await Assert.ThrowsAsync<BillPaymentServiceException>(
                    retrieveFieldsTask.AsTask);

            // then
            actualBillPaymentServiceException.Should().BeEquivalentTo(
                expectedBillPaymentServiceException);

            this.proviPayBrokerMock.Verify(broker =>
                broker.GetFieldsAsync(It.IsAny<string>()),
                    Times.Once);

            this.proviPayBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
