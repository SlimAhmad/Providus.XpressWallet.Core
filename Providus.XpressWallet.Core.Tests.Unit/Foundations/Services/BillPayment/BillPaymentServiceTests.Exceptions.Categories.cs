using FluentAssertions;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.Categories;
using Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.Exceptions;
using RESTFulSense.Exceptions;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.BillPayment
{
    public partial class BillPaymentServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnCategoriesRequestIfUrlNotFoundAsync()
        {
            // given
            


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
                broker.GetCategoriesAsync())
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<Categories> retrieveCategoriesTask =
               this.billPaymentService.GetCategoriesRequestAsync();

            BillPaymentDependencyException
                actualBillPaymentDependencyException =
                    await Assert.ThrowsAsync<BillPaymentDependencyException>(
                        retrieveCategoriesTask.AsTask);

            // then
            actualBillPaymentDependencyException.Should().BeEquivalentTo(
                expectedBillPaymentDependencyException);

            this.proviPayBrokerMock.Verify(broker =>
                broker.GetCategoriesAsync(),
                    Times.Once);

            this.proviPayBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnCategoriesRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            

        
            var unauthorizedBillPaymentException =
                new UnauthorizedBillPaymentException(unauthorizedException);

            var expectedBillPaymentDependencyException =
                new BillPaymentDependencyException(unauthorizedBillPaymentException);

            this.proviPayBrokerMock.Setup(broker =>
                 broker.GetCategoriesAsync())
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<Categories> retrieveCategoriesTask =
               this.billPaymentService.GetCategoriesRequestAsync();

            BillPaymentDependencyException
                actualBillPaymentDependencyException =
                    await Assert.ThrowsAsync<BillPaymentDependencyException>(
                        retrieveCategoriesTask.AsTask);

            // then
            actualBillPaymentDependencyException.Should().BeEquivalentTo(
                expectedBillPaymentDependencyException);

            this.proviPayBrokerMock.Verify(broker =>
                broker.GetCategoriesAsync(),
                    Times.Once);

            this.proviPayBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnCategoriesRequestIfNotFoundOccurredAsync()
        {
            // given
            



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
                broker.GetCategoriesAsync())
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<Categories> retrieveCategoriesTask =
               this.billPaymentService.GetCategoriesRequestAsync();

            BillPaymentDependencyValidationException
                actualBillPaymentDependencyValidationException =
                    await Assert.ThrowsAsync<BillPaymentDependencyValidationException>(
                        retrieveCategoriesTask.AsTask);

            // then
            actualBillPaymentDependencyValidationException.Should().BeEquivalentTo(
                expectedBillPaymentDependencyValidationException);

            this.proviPayBrokerMock.Verify(broker =>
                broker.GetCategoriesAsync(),
                    Times.Once);

            this.proviPayBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnCategoriesRequestIfBadRequestOccurredAsync()
        {
            // given
            

                

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
                broker.GetCategoriesAsync())
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<Categories> retrieveCategoriesTask =
               this.billPaymentService.GetCategoriesRequestAsync();

            BillPaymentDependencyValidationException
                actualBillPaymentDependencyValidationException =
                    await Assert.ThrowsAsync<BillPaymentDependencyValidationException>(
                        retrieveCategoriesTask.AsTask);

            // then
            actualBillPaymentDependencyValidationException.Should().BeEquivalentTo(
                expectedBillPaymentDependencyValidationException);

            this.proviPayBrokerMock.Verify(broker =>
                broker.GetCategoriesAsync(),
                    Times.Once);

            this.proviPayBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnCategoriesRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            

                

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
                 broker.GetCategoriesAsync())
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<Categories> retrieveCategoriesTask =
               this.billPaymentService.GetCategoriesRequestAsync();

            BillPaymentDependencyValidationException actualBillPaymentDependencyValidationException =
                await Assert.ThrowsAsync<BillPaymentDependencyValidationException>(
                    retrieveCategoriesTask.AsTask);

            // then
            actualBillPaymentDependencyValidationException.Should().BeEquivalentTo(
                expectedBillPaymentDependencyValidationException);

            this.proviPayBrokerMock.Verify(broker =>
                broker.GetCategoriesAsync(),
                    Times.Once);

            this.proviPayBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnCategoriesRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            

                

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
                 broker.GetCategoriesAsync())
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<Categories> retrieveCategoriesTask =
               this.billPaymentService.GetCategoriesRequestAsync();

            BillPaymentDependencyException actualBillPaymentDependencyException =
                await Assert.ThrowsAsync<BillPaymentDependencyException>(
                    retrieveCategoriesTask.AsTask);

            // then
            actualBillPaymentDependencyException.Should().BeEquivalentTo(
                expectedBillPaymentDependencyException);

            this.proviPayBrokerMock.Verify(broker =>
                broker.GetCategoriesAsync(),
                    Times.Once);

            this.proviPayBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnCategoriesRequestIfServiceErrorOccurredAsync()
        {
            // given
            

                
            var serviceException = new Exception();

            var failedBillPaymentServiceException =
                new FailedBillPaymentServiceException(serviceException);

            var expectedBillPaymentServiceException =
                new BillPaymentServiceException(failedBillPaymentServiceException);

            this.proviPayBrokerMock.Setup(broker =>
                broker.GetCategoriesAsync())
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<Categories> retrieveCategoriesTask =
               this.billPaymentService.GetCategoriesRequestAsync();

            BillPaymentServiceException actualBillPaymentServiceException =
                await Assert.ThrowsAsync<BillPaymentServiceException>(
                    retrieveCategoriesTask.AsTask);

            // then
            actualBillPaymentServiceException.Should().BeEquivalentTo(
                expectedBillPaymentServiceException);

            this.proviPayBrokerMock.Verify(broker =>
                broker.GetCategoriesAsync(),
                    Times.Once);

            this.proviPayBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
