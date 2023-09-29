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
        public async Task ShouldThrowDependencyExceptionOnCustomerDetailsRequestIfUrlNotFoundAsync()
        {
            // given
            var inputCustomerId = GetRandomString();


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
                broker.GetCustomerDetailsAsync(It.IsAny<string>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<CustomerDetails> retrieveCustomerDetailsTask =
               this.authService.GetCustomerDetailsRequestAsync(inputCustomerId);

            CustomersDependencyException
                actualCustomersDependencyException =
                    await Assert.ThrowsAsync<CustomersDependencyException>(
                        retrieveCustomerDetailsTask.AsTask);

            // then
            actualCustomersDependencyException.Should().BeEquivalentTo(
                expectedCustomersDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetCustomerDetailsAsync(It.IsAny<string>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnCustomerDetailsRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            var inputCustomerId = GetRandomString();

        
            var unauthorizedCustomersException =
                new UnauthorizedCustomersException(unauthorizedException);

            var expectedCustomersDependencyException =
                new CustomersDependencyException(unauthorizedCustomersException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.GetCustomerDetailsAsync(It.IsAny<string>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<CustomerDetails> retrieveCustomerDetailsTask =
               this.authService.GetCustomerDetailsRequestAsync(inputCustomerId);

            CustomersDependencyException
                actualCustomersDependencyException =
                    await Assert.ThrowsAsync<CustomersDependencyException>(
                        retrieveCustomerDetailsTask.AsTask);

            // then
            actualCustomersDependencyException.Should().BeEquivalentTo(
                expectedCustomersDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetCustomerDetailsAsync(It.IsAny<string>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnCustomerDetailsRequestIfNotFoundOccurredAsync()
        {
            // given
            var inputCustomerId = GetRandomString();



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
                broker.GetCustomerDetailsAsync(It.IsAny<string>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<CustomerDetails> retrieveCustomerDetailsTask =
               this.authService.GetCustomerDetailsRequestAsync(inputCustomerId);

            CustomersDependencyValidationException
                actualCustomersDependencyValidationException =
                    await Assert.ThrowsAsync<CustomersDependencyValidationException>(
                        retrieveCustomerDetailsTask.AsTask);

            // then
            actualCustomersDependencyValidationException.Should().BeEquivalentTo(
                expectedCustomersDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetCustomerDetailsAsync(It.IsAny<string>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnCustomerDetailsRequestIfBadRequestOccurredAsync()
        {
            // given
            var inputCustomerId = GetRandomString();

                

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
                broker.GetCustomerDetailsAsync(It.IsAny<string>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<CustomerDetails> retrieveCustomerDetailsTask =
               this.authService.GetCustomerDetailsRequestAsync(inputCustomerId);

            CustomersDependencyValidationException
                actualCustomersDependencyValidationException =
                    await Assert.ThrowsAsync<CustomersDependencyValidationException>(
                        retrieveCustomerDetailsTask.AsTask);

            // then
            actualCustomersDependencyValidationException.Should().BeEquivalentTo(
                expectedCustomersDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetCustomerDetailsAsync(It.IsAny<string>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnCustomerDetailsRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            var inputCustomerId = GetRandomString();

                

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
                 broker.GetCustomerDetailsAsync(It.IsAny<string>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<CustomerDetails> retrieveCustomerDetailsTask =
               this.authService.GetCustomerDetailsRequestAsync(inputCustomerId);

            CustomersDependencyValidationException actualCustomersDependencyValidationException =
                await Assert.ThrowsAsync<CustomersDependencyValidationException>(
                    retrieveCustomerDetailsTask.AsTask);

            // then
            actualCustomersDependencyValidationException.Should().BeEquivalentTo(
                expectedCustomersDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetCustomerDetailsAsync(It.IsAny<string>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnCustomerDetailsRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            var inputCustomerId = GetRandomString();

                

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
                 broker.GetCustomerDetailsAsync(It.IsAny<string>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<CustomerDetails> retrieveCustomerDetailsTask =
               this.authService.GetCustomerDetailsRequestAsync(inputCustomerId);

            CustomersDependencyException actualCustomersDependencyException =
                await Assert.ThrowsAsync<CustomersDependencyException>(
                    retrieveCustomerDetailsTask.AsTask);

            // then
            actualCustomersDependencyException.Should().BeEquivalentTo(
                expectedCustomersDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetCustomerDetailsAsync(It.IsAny<string>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnCustomerDetailsRequestIfServiceErrorOccurredAsync()
        {
            // given
            var inputCustomerId = GetRandomString();

                
            var serviceException = new Exception();

            var failedCustomersServiceException =
                new FailedCustomersServiceException(serviceException);

            var expectedCustomersServiceException =
                new CustomersServiceException(failedCustomersServiceException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.GetCustomerDetailsAsync(It.IsAny<string>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<CustomerDetails> retrieveCustomerDetailsTask =
               this.authService.GetCustomerDetailsRequestAsync(inputCustomerId);

            CustomersServiceException actualCustomersServiceException =
                await Assert.ThrowsAsync<CustomersServiceException>(
                    retrieveCustomerDetailsTask.AsTask);

            // then
            actualCustomersServiceException.Should().BeEquivalentTo(
                expectedCustomersServiceException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetCustomerDetailsAsync(It.IsAny<string>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
