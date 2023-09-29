using FluentAssertions;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalCustomers;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Customers;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Customers.Exceptions;
using RESTFulSense.Exceptions;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.Customers
{
    public partial class CustomersServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnAllCustomersRequestIfUrlNotFoundAsync()
        {
            // given
            


            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException();

            var invalidConfigurationCustomersException =
                new InvalidConfigurationCustomersException(
                    message: "Invalid Customers configuration error occurred, contact support.",
                    httpResponseUrlNotFoundException);

            var expectedCustomersDependencyException =
                new CustomersDependencyException(
                    message: "Customers dependency error occurred, contact support.",
                    invalidConfigurationCustomersException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.GetAllCustomersAsync())
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<AllCustomers> retrieveAllCustomersTask =
               this.authService.GetAllCustomersRequestAsync();

            CustomersDependencyException
                actualCustomersDependencyException =
                    await Assert.ThrowsAsync<CustomersDependencyException>(
                        retrieveAllCustomersTask.AsTask);

            // then
            actualCustomersDependencyException.Should().BeEquivalentTo(
                expectedCustomersDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetAllCustomersAsync(),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnAllCustomersRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            

        
            var unauthorizedCustomersException =
                new UnauthorizedCustomersException(unauthorizedException);

            var expectedCustomersDependencyException =
                new CustomersDependencyException(unauthorizedCustomersException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.GetAllCustomersAsync())
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<AllCustomers> retrieveAllCustomersTask =
               this.authService.GetAllCustomersRequestAsync();

            CustomersDependencyException
                actualCustomersDependencyException =
                    await Assert.ThrowsAsync<CustomersDependencyException>(
                        retrieveAllCustomersTask.AsTask);

            // then
            actualCustomersDependencyException.Should().BeEquivalentTo(
                expectedCustomersDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetAllCustomersAsync(),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnAllCustomersRequestIfNotFoundOccurredAsync()
        {
            // given
            



            var httpResponseNotFoundException =
                new HttpResponseNotFoundException();

            var notFoundCustomersException =
                new NotFoundCustomersException(
                    message: "Not found Customers error occurred, fix errors and try again.",
                    httpResponseNotFoundException);

            var expectedCustomersDependencyValidationException =
                new CustomersDependencyValidationException(
                    message: "Customers dependency validation error occurred, contact support.",
                    notFoundCustomersException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.GetAllCustomersAsync())
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<AllCustomers> retrieveAllCustomersTask =
               this.authService.GetAllCustomersRequestAsync();

            CustomersDependencyValidationException
                actualCustomersDependencyValidationException =
                    await Assert.ThrowsAsync<CustomersDependencyValidationException>(
                        retrieveAllCustomersTask.AsTask);

            // then
            actualCustomersDependencyValidationException.Should().BeEquivalentTo(
                expectedCustomersDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetAllCustomersAsync(),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnAllCustomersRequestIfBadRequestOccurredAsync()
        {
            // given
            

                

            var httpResponseBadRequestException =
                new HttpResponseBadRequestException();

            var invalidCustomersException =
                new InvalidCustomersException(
                    message: "Invalid Customers error occurred, fix errors and try again.",
                    httpResponseBadRequestException);

            var expectedCustomersDependencyValidationException =
                new CustomersDependencyValidationException(
                    message: "Customers dependency validation error occurred, contact support.",
                    invalidCustomersException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.GetAllCustomersAsync())
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<AllCustomers> retrieveAllCustomersTask =
               this.authService.GetAllCustomersRequestAsync();

            CustomersDependencyValidationException
                actualCustomersDependencyValidationException =
                    await Assert.ThrowsAsync<CustomersDependencyValidationException>(
                        retrieveAllCustomersTask.AsTask);

            // then
            actualCustomersDependencyValidationException.Should().BeEquivalentTo(
                expectedCustomersDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetAllCustomersAsync(),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnAllCustomersRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            

                

            var httpResponseTooManyRequestsException =
                new HttpResponseTooManyRequestsException();

            var excessiveCallCustomersException =
                new ExcessiveCallCustomersException(
                    message: "Excessive call error occurred, limit your calls.",
                    httpResponseTooManyRequestsException);

            var expectedCustomersDependencyValidationException =
                new CustomersDependencyValidationException(
                    message: "Customers dependency validation error occurred, contact support.",
                    excessiveCallCustomersException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.GetAllCustomersAsync())
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<AllCustomers> retrieveAllCustomersTask =
               this.authService.GetAllCustomersRequestAsync();

            CustomersDependencyValidationException actualCustomersDependencyValidationException =
                await Assert.ThrowsAsync<CustomersDependencyValidationException>(
                    retrieveAllCustomersTask.AsTask);

            // then
            actualCustomersDependencyValidationException.Should().BeEquivalentTo(
                expectedCustomersDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetAllCustomersAsync(),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnAllCustomersRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            

                

            var httpResponseException =
                new HttpResponseException();

            var failedServerCustomersException =
                new FailedServerCustomersException(
                    message: "Failed Customers server error occurred, contact support.",
                    httpResponseException);

            var expectedCustomersDependencyException =
                new CustomersDependencyException(
                    message: "Customers dependency error occurred, contact support.",
                    failedServerCustomersException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.GetAllCustomersAsync())
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<AllCustomers> retrieveAllCustomersTask =
               this.authService.GetAllCustomersRequestAsync();

            CustomersDependencyException actualCustomersDependencyException =
                await Assert.ThrowsAsync<CustomersDependencyException>(
                    retrieveAllCustomersTask.AsTask);

            // then
            actualCustomersDependencyException.Should().BeEquivalentTo(
                expectedCustomersDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetAllCustomersAsync(),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnAllCustomersRequestIfServiceErrorOccurredAsync()
        {
            // given
            

                
            var serviceException = new Exception();

            var failedCustomersServiceException =
                new FailedCustomersServiceException(serviceException);

            var expectedCustomersServiceException =
                new CustomersServiceException(failedCustomersServiceException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.GetAllCustomersAsync())
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<AllCustomers> retrieveAllCustomersTask =
               this.authService.GetAllCustomersRequestAsync();

            CustomersServiceException actualCustomersServiceException =
                await Assert.ThrowsAsync<CustomersServiceException>(
                    retrieveAllCustomersTask.AsTask);

            // then
            actualCustomersServiceException.Should().BeEquivalentTo(
                expectedCustomersServiceException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetAllCustomersAsync(),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
