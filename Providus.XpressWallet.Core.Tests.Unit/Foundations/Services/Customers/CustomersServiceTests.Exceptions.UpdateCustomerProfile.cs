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
        public async Task ShouldThrowDependencyExceptionOnUpdateCustomerProfileRequestIfUrlNotFoundAsync()
        {
            // given
            var inputCustomerId = GetRandomString();

            dynamic createRandomUpdateCustomerProfileRequestProperties =
                 CreateRandomUpdateCustomerProfileRequestProperties();

            var createCustomersRequest = new ExternalUpdateCustomerProfileRequest
            {
                Address = createRandomUpdateCustomerProfileRequestProperties.Address,
                FirstName = createRandomUpdateCustomerProfileRequestProperties.FirstName,
                LastName = createRandomUpdateCustomerProfileRequestProperties.LastName,
                Metadata = new ExternalUpdateCustomerProfileRequest.ExternalMetadata
                {
                   Others = createRandomUpdateCustomerProfileRequestProperties.Metadata.Others
                },
                PhoneNumber = createRandomUpdateCustomerProfileRequestProperties.PhoneNumber,
             
            };

            var createCustomers = new UpdateCustomerProfile
            {
                Request = new UpdateCustomerProfileRequest
                {
                    Address = createRandomUpdateCustomerProfileRequestProperties.Address,
                    FirstName = createRandomUpdateCustomerProfileRequestProperties.FirstName,
                    LastName = createRandomUpdateCustomerProfileRequestProperties.LastName,
                    Metadata = new UpdateCustomerProfileRequest.MetadataResponse
                    {
                        Others = createRandomUpdateCustomerProfileRequestProperties.Metadata.Others
                    },
                    PhoneNumber = createRandomUpdateCustomerProfileRequestProperties.PhoneNumber,
                },
            };




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
                broker.UpdateCustomerProfileAsync(It.IsAny<ExternalUpdateCustomerProfileRequest>(),inputCustomerId))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<UpdateCustomerProfile> retrieveUpdateCustomerProfileTask =
               this.authService.UpdateCustomerProfileRequestAsync(createCustomers, inputCustomerId);

            CustomersDependencyException
                actualCustomersDependencyException =
                    await Assert.ThrowsAsync<CustomersDependencyException>(
                        retrieveUpdateCustomerProfileTask.AsTask);

            // then
            actualCustomersDependencyException.Should().BeEquivalentTo(
                expectedCustomersDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.UpdateCustomerProfileAsync(It.IsAny<ExternalUpdateCustomerProfileRequest>(),inputCustomerId),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnUpdateCustomerProfileRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            var inputCustomerId = GetRandomString();

            dynamic createRandomUpdateCustomerProfileRequestProperties =
             CreateRandomUpdateCustomerProfileRequestProperties();

            var createCustomersRequest = new ExternalUpdateCustomerProfileRequest
            {
                Address = createRandomUpdateCustomerProfileRequestProperties.Address,
                FirstName = createRandomUpdateCustomerProfileRequestProperties.FirstName,
                LastName = createRandomUpdateCustomerProfileRequestProperties.LastName,
                Metadata = new ExternalUpdateCustomerProfileRequest.ExternalMetadata
                {
                    Others = createRandomUpdateCustomerProfileRequestProperties.Metadata.Others
                },
                PhoneNumber = createRandomUpdateCustomerProfileRequestProperties.PhoneNumber,

            };

            var createCustomers = new UpdateCustomerProfile
            {
                Request = new UpdateCustomerProfileRequest
                {
                    Address = createRandomUpdateCustomerProfileRequestProperties.Address,
                    FirstName = createRandomUpdateCustomerProfileRequestProperties.FirstName,
                    LastName = createRandomUpdateCustomerProfileRequestProperties.LastName,
                    Metadata = new UpdateCustomerProfileRequest.MetadataResponse
                    {
                        Others = createRandomUpdateCustomerProfileRequestProperties.Metadata.Others
                    },
                    PhoneNumber = createRandomUpdateCustomerProfileRequestProperties.PhoneNumber,
                },
            };


            var unauthorizedCustomersException =
                new UnauthorizedCustomersException(unauthorizedException);

            var expectedCustomersDependencyException =
                new CustomersDependencyException(unauthorizedCustomersException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.UpdateCustomerProfileAsync(It.IsAny<ExternalUpdateCustomerProfileRequest>(),inputCustomerId))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<UpdateCustomerProfile> retrieveUpdateCustomerProfileTask =
               this.authService.UpdateCustomerProfileRequestAsync(createCustomers, inputCustomerId);

            CustomersDependencyException
                actualCustomersDependencyException =
                    await Assert.ThrowsAsync<CustomersDependencyException>(
                        retrieveUpdateCustomerProfileTask.AsTask);

            // then
            actualCustomersDependencyException.Should().BeEquivalentTo(
                expectedCustomersDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.UpdateCustomerProfileAsync(It.IsAny<ExternalUpdateCustomerProfileRequest>(),inputCustomerId),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnUpdateCustomerProfileRequestIfNotFoundOccurredAsync()
        {
            // given
            var inputCustomerId = GetRandomString();

                dynamic createRandomUpdateCustomerProfileRequestProperties =
                 CreateRandomUpdateCustomerProfileRequestProperties();

            var createCustomersRequest = new ExternalUpdateCustomerProfileRequest
            {
                    Address = createRandomUpdateCustomerProfileRequestProperties.Address,
                FirstName = createRandomUpdateCustomerProfileRequestProperties.FirstName,
                LastName = createRandomUpdateCustomerProfileRequestProperties.LastName,
                Metadata = new ExternalUpdateCustomerProfileRequest.ExternalMetadata
                {
                    Others = createRandomUpdateCustomerProfileRequestProperties.Metadata.Others
                },
                PhoneNumber = createRandomUpdateCustomerProfileRequestProperties.PhoneNumber,
            };

            var createCustomers = new UpdateCustomerProfile
            {
                Request = new UpdateCustomerProfileRequest
                {
                Address = createRandomUpdateCustomerProfileRequestProperties.Address,
                FirstName = createRandomUpdateCustomerProfileRequestProperties.FirstName,
                LastName = createRandomUpdateCustomerProfileRequestProperties.LastName,
                Metadata = new UpdateCustomerProfileRequest.MetadataResponse
                {
                    Others = createRandomUpdateCustomerProfileRequestProperties.Metadata.Others
                },
                PhoneNumber = createRandomUpdateCustomerProfileRequestProperties.PhoneNumber,
                },
            };


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
                broker.UpdateCustomerProfileAsync(It.IsAny<ExternalUpdateCustomerProfileRequest>(),inputCustomerId))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<UpdateCustomerProfile> retrieveUpdateCustomerProfileTask =
               this.authService.UpdateCustomerProfileRequestAsync(createCustomers, inputCustomerId);

            CustomersDependencyValidationException
                actualCustomersDependencyValidationException =
                    await Assert.ThrowsAsync<CustomersDependencyValidationException>(
                        retrieveUpdateCustomerProfileTask.AsTask);

            // then
            actualCustomersDependencyValidationException.Should().BeEquivalentTo(
                expectedCustomersDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.UpdateCustomerProfileAsync(It.IsAny<ExternalUpdateCustomerProfileRequest>(),inputCustomerId),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnUpdateCustomerProfileRequestIfBadRequestOccurredAsync()
        {
            // given
            var inputCustomerId = GetRandomString();

                dynamic createRandomUpdateCustomerProfileRequestProperties =
                 CreateRandomUpdateCustomerProfileRequestProperties();

            var createCustomersRequest = new ExternalUpdateCustomerProfileRequest
            {
                Address = createRandomUpdateCustomerProfileRequestProperties.Address,
                FirstName = createRandomUpdateCustomerProfileRequestProperties.FirstName,
                LastName = createRandomUpdateCustomerProfileRequestProperties.LastName,
                Metadata = new ExternalUpdateCustomerProfileRequest.ExternalMetadata
                {
                    Others = createRandomUpdateCustomerProfileRequestProperties.Metadata.Others
                },
                PhoneNumber = createRandomUpdateCustomerProfileRequestProperties.PhoneNumber,
            };

            var createCustomers = new UpdateCustomerProfile
            {
                Request = new UpdateCustomerProfileRequest
                {
                    Address = createRandomUpdateCustomerProfileRequestProperties.Address,
                    FirstName = createRandomUpdateCustomerProfileRequestProperties.FirstName,
                    LastName = createRandomUpdateCustomerProfileRequestProperties.LastName,
                    Metadata = new UpdateCustomerProfileRequest.MetadataResponse
                    {
                        Others = createRandomUpdateCustomerProfileRequestProperties.Metadata.Others
                    },
                    PhoneNumber = createRandomUpdateCustomerProfileRequestProperties.PhoneNumber,
                },
            };

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
                broker.UpdateCustomerProfileAsync(It.IsAny<ExternalUpdateCustomerProfileRequest>(),inputCustomerId))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<UpdateCustomerProfile> retrieveUpdateCustomerProfileTask =
               this.authService.UpdateCustomerProfileRequestAsync(createCustomers, inputCustomerId);

            CustomersDependencyValidationException
                actualCustomersDependencyValidationException =
                    await Assert.ThrowsAsync<CustomersDependencyValidationException>(
                        retrieveUpdateCustomerProfileTask.AsTask);

            // then
            actualCustomersDependencyValidationException.Should().BeEquivalentTo(
                expectedCustomersDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.UpdateCustomerProfileAsync(It.IsAny<ExternalUpdateCustomerProfileRequest>(),inputCustomerId),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnUpdateCustomerProfileRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            var inputCustomerId = GetRandomString();

                dynamic createRandomUpdateCustomerProfileRequestProperties =
                 CreateRandomUpdateCustomerProfileRequestProperties();

            var createCustomersRequest = new ExternalUpdateCustomerProfileRequest
            {
                Address = createRandomUpdateCustomerProfileRequestProperties.Address,
                FirstName = createRandomUpdateCustomerProfileRequestProperties.FirstName,
                LastName = createRandomUpdateCustomerProfileRequestProperties.LastName,
                Metadata = new ExternalUpdateCustomerProfileRequest.ExternalMetadata
                {
                    Others = createRandomUpdateCustomerProfileRequestProperties.Metadata.Others
                },
                PhoneNumber = createRandomUpdateCustomerProfileRequestProperties.PhoneNumber,
            };

            var createCustomers = new UpdateCustomerProfile
            {
                Request = new UpdateCustomerProfileRequest
                {
                        Address = createRandomUpdateCustomerProfileRequestProperties.Address,
                FirstName = createRandomUpdateCustomerProfileRequestProperties.FirstName,
                LastName = createRandomUpdateCustomerProfileRequestProperties.LastName,
                Metadata = new UpdateCustomerProfileRequest.MetadataResponse
                {
                    Others = createRandomUpdateCustomerProfileRequestProperties.Metadata.Others
                },
                PhoneNumber = createRandomUpdateCustomerProfileRequestProperties.PhoneNumber,
                },
            };

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
                 broker.UpdateCustomerProfileAsync(It.IsAny<ExternalUpdateCustomerProfileRequest>(),inputCustomerId))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<UpdateCustomerProfile> retrieveUpdateCustomerProfileTask =
               this.authService.UpdateCustomerProfileRequestAsync(createCustomers, inputCustomerId);

            CustomersDependencyValidationException actualCustomersDependencyValidationException =
                await Assert.ThrowsAsync<CustomersDependencyValidationException>(
                    retrieveUpdateCustomerProfileTask.AsTask);

            // then
            actualCustomersDependencyValidationException.Should().BeEquivalentTo(
                expectedCustomersDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.UpdateCustomerProfileAsync(It.IsAny<ExternalUpdateCustomerProfileRequest>(),inputCustomerId),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnUpdateCustomerProfileRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            var inputCustomerId = GetRandomString();

                dynamic createRandomUpdateCustomerProfileRequestProperties =
                 CreateRandomUpdateCustomerProfileRequestProperties();

            var createCustomersRequest = new ExternalUpdateCustomerProfileRequest
            {
                Address = createRandomUpdateCustomerProfileRequestProperties.Address,
                FirstName = createRandomUpdateCustomerProfileRequestProperties.FirstName,
                LastName = createRandomUpdateCustomerProfileRequestProperties.LastName,
                Metadata = new ExternalUpdateCustomerProfileRequest.ExternalMetadata
                {
                    Others = createRandomUpdateCustomerProfileRequestProperties.Metadata.Others
                },
                PhoneNumber = createRandomUpdateCustomerProfileRequestProperties.PhoneNumber,
            };

            var createCustomers = new UpdateCustomerProfile
            {
                Request = new UpdateCustomerProfileRequest
                {
                        Address = createRandomUpdateCustomerProfileRequestProperties.Address,
                FirstName = createRandomUpdateCustomerProfileRequestProperties.FirstName,
                LastName = createRandomUpdateCustomerProfileRequestProperties.LastName,
                Metadata = new UpdateCustomerProfileRequest.MetadataResponse
                {
                    Others = createRandomUpdateCustomerProfileRequestProperties.Metadata.Others
                },
                PhoneNumber = createRandomUpdateCustomerProfileRequestProperties.PhoneNumber,
                },
            };

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
                 broker.UpdateCustomerProfileAsync(It.IsAny<ExternalUpdateCustomerProfileRequest>(),inputCustomerId))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<UpdateCustomerProfile> retrieveUpdateCustomerProfileTask =
               this.authService.UpdateCustomerProfileRequestAsync(createCustomers, inputCustomerId);

            CustomersDependencyException actualCustomersDependencyException =
                await Assert.ThrowsAsync<CustomersDependencyException>(
                    retrieveUpdateCustomerProfileTask.AsTask);

            // then
            actualCustomersDependencyException.Should().BeEquivalentTo(
                expectedCustomersDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.UpdateCustomerProfileAsync(It.IsAny<ExternalUpdateCustomerProfileRequest>(),inputCustomerId),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnUpdateCustomerProfileRequestIfServiceErrorOccurredAsync()
        {
            // given
            var inputCustomerId = GetRandomString();

                dynamic createRandomUpdateCustomerProfileRequestProperties =
                 CreateRandomUpdateCustomerProfileRequestProperties();

            var createCustomersRequest = new ExternalUpdateCustomerProfileRequest
            {
                    Address = createRandomUpdateCustomerProfileRequestProperties.Address,
                FirstName = createRandomUpdateCustomerProfileRequestProperties.FirstName,
                LastName = createRandomUpdateCustomerProfileRequestProperties.LastName,
                Metadata = new ExternalUpdateCustomerProfileRequest.ExternalMetadata
                {
                    Others = createRandomUpdateCustomerProfileRequestProperties.Metadata.Others
                },
                PhoneNumber = createRandomUpdateCustomerProfileRequestProperties.PhoneNumber,
            };

            var createCustomers = new UpdateCustomerProfile
            {
                Request = new UpdateCustomerProfileRequest
                {
                Address = createRandomUpdateCustomerProfileRequestProperties.Address,
                FirstName = createRandomUpdateCustomerProfileRequestProperties.FirstName,
                LastName = createRandomUpdateCustomerProfileRequestProperties.LastName,
                Metadata = new UpdateCustomerProfileRequest.MetadataResponse
                {
                    Others = createRandomUpdateCustomerProfileRequestProperties.Metadata.Others
                },
                PhoneNumber = createRandomUpdateCustomerProfileRequestProperties.PhoneNumber,
                },
            };
            var serviceException = new Exception();

            var failedCustomersServiceException =
                new FailedCustomersServiceException(serviceException);

            var expectedCustomersServiceException =
                new CustomersServiceException(failedCustomersServiceException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.UpdateCustomerProfileAsync(It.IsAny<ExternalUpdateCustomerProfileRequest>(),inputCustomerId))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<UpdateCustomerProfile> retrieveUpdateCustomerProfileTask =
               this.authService.UpdateCustomerProfileRequestAsync(createCustomers, inputCustomerId);

            CustomersServiceException actualCustomersServiceException =
                await Assert.ThrowsAsync<CustomersServiceException>(
                    retrieveUpdateCustomerProfileTask.AsTask);

            // then
            actualCustomersServiceException.Should().BeEquivalentTo(
                expectedCustomersServiceException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.UpdateCustomerProfileAsync(It.IsAny<ExternalUpdateCustomerProfileRequest>(),inputCustomerId),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
