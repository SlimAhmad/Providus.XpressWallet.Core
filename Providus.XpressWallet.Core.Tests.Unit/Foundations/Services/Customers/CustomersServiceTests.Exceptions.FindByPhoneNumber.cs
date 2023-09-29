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
        public async Task ShouldThrowDependencyExceptionOnFindByPhoneNumberRequestIfUrlNotFoundAsync()
        {
            // given
            var inputPhoneNumber = GetRandomString();


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
                broker.GetFindByPhoneNumberAsync(It.IsAny<string>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<FindByPhoneNumber> retrieveFindByPhoneNumberTask =
               this.authService.GetFindByPhoneNumberRequestAsync(inputPhoneNumber);

            CustomersDependencyException
                actualCustomersDependencyException =
                    await Assert.ThrowsAsync<CustomersDependencyException>(
                        retrieveFindByPhoneNumberTask.AsTask);

            // then
            actualCustomersDependencyException.Should().BeEquivalentTo(
                expectedCustomersDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetFindByPhoneNumberAsync(It.IsAny<string>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnFindByPhoneNumberRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            var inputPhoneNumber = GetRandomString();

        
            var unauthorizedCustomersException =
                new UnauthorizedCustomersException(unauthorizedException);

            var expectedCustomersDependencyException =
                new CustomersDependencyException(unauthorizedCustomersException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.GetFindByPhoneNumberAsync(It.IsAny<string>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<FindByPhoneNumber> retrieveFindByPhoneNumberTask =
               this.authService.GetFindByPhoneNumberRequestAsync(inputPhoneNumber);

            CustomersDependencyException
                actualCustomersDependencyException =
                    await Assert.ThrowsAsync<CustomersDependencyException>(
                        retrieveFindByPhoneNumberTask.AsTask);

            // then
            actualCustomersDependencyException.Should().BeEquivalentTo(
                expectedCustomersDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetFindByPhoneNumberAsync(It.IsAny<string>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnFindByPhoneNumberRequestIfNotFoundOccurredAsync()
        {
            // given
            var inputPhoneNumber = GetRandomString();



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
                broker.GetFindByPhoneNumberAsync(It.IsAny<string>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<FindByPhoneNumber> retrieveFindByPhoneNumberTask =
               this.authService.GetFindByPhoneNumberRequestAsync(inputPhoneNumber);

            CustomersDependencyValidationException
                actualCustomersDependencyValidationException =
                    await Assert.ThrowsAsync<CustomersDependencyValidationException>(
                        retrieveFindByPhoneNumberTask.AsTask);

            // then
            actualCustomersDependencyValidationException.Should().BeEquivalentTo(
                expectedCustomersDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetFindByPhoneNumberAsync(It.IsAny<string>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnFindByPhoneNumberRequestIfBadRequestOccurredAsync()
        {
            // given
            var inputPhoneNumber = GetRandomString();

                

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
                broker.GetFindByPhoneNumberAsync(It.IsAny<string>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<FindByPhoneNumber> retrieveFindByPhoneNumberTask =
               this.authService.GetFindByPhoneNumberRequestAsync(inputPhoneNumber);

            CustomersDependencyValidationException
                actualCustomersDependencyValidationException =
                    await Assert.ThrowsAsync<CustomersDependencyValidationException>(
                        retrieveFindByPhoneNumberTask.AsTask);

            // then
            actualCustomersDependencyValidationException.Should().BeEquivalentTo(
                expectedCustomersDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetFindByPhoneNumberAsync(It.IsAny<string>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnFindByPhoneNumberRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            var inputPhoneNumber = GetRandomString();

                

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
                 broker.GetFindByPhoneNumberAsync(It.IsAny<string>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<FindByPhoneNumber> retrieveFindByPhoneNumberTask =
               this.authService.GetFindByPhoneNumberRequestAsync(inputPhoneNumber);

            CustomersDependencyValidationException actualCustomersDependencyValidationException =
                await Assert.ThrowsAsync<CustomersDependencyValidationException>(
                    retrieveFindByPhoneNumberTask.AsTask);

            // then
            actualCustomersDependencyValidationException.Should().BeEquivalentTo(
                expectedCustomersDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetFindByPhoneNumberAsync(It.IsAny<string>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnFindByPhoneNumberRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            var inputPhoneNumber = GetRandomString();

                

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
                 broker.GetFindByPhoneNumberAsync(It.IsAny<string>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<FindByPhoneNumber> retrieveFindByPhoneNumberTask =
               this.authService.GetFindByPhoneNumberRequestAsync(inputPhoneNumber);

            CustomersDependencyException actualCustomersDependencyException =
                await Assert.ThrowsAsync<CustomersDependencyException>(
                    retrieveFindByPhoneNumberTask.AsTask);

            // then
            actualCustomersDependencyException.Should().BeEquivalentTo(
                expectedCustomersDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetFindByPhoneNumberAsync(It.IsAny<string>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnFindByPhoneNumberRequestIfServiceErrorOccurredAsync()
        {
            // given
            var inputPhoneNumber = GetRandomString();

                
            var serviceException = new Exception();

            var failedCustomersServiceException =
                new FailedCustomersServiceException(serviceException);

            var expectedCustomersServiceException =
                new CustomersServiceException(failedCustomersServiceException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.GetFindByPhoneNumberAsync(It.IsAny<string>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<FindByPhoneNumber> retrieveFindByPhoneNumberTask =
               this.authService.GetFindByPhoneNumberRequestAsync(inputPhoneNumber);

            CustomersServiceException actualCustomersServiceException =
                await Assert.ThrowsAsync<CustomersServiceException>(
                    retrieveFindByPhoneNumberTask.AsTask);

            // then
            actualCustomersServiceException.Should().BeEquivalentTo(
                expectedCustomersServiceException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetFindByPhoneNumberAsync(It.IsAny<string>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
