using FluentAssertions;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalWallet;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Wallet;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Wallet.Exceptions;
using RESTFulSense.Exceptions;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.Wallet
{
    public partial class WalletServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnCreateWalletRequestIfUrlNotFoundAsync()
        {
            // given
            

            dynamic createRandomCreateWalletRequestProperties =
                 CreateRandomCreateWalletRequestProperties();

            var createCreateWalletRequest = new ExternalCreateWalletRequest
            {
                  Address = createRandomCreateWalletRequestProperties.Address,
                  Bvn = createRandomCreateWalletRequestProperties.Bvn,
                  DateOfBirth = createRandomCreateWalletRequestProperties.DateOfBirth,
                  Email = createRandomCreateWalletRequestProperties.Email,
                  FirstName = createRandomCreateWalletRequestProperties.FirstName,
                  LastName = createRandomCreateWalletRequestProperties.LastName,
                  PhoneNumber = createRandomCreateWalletRequestProperties.PhoneNumber,
                  Metadata = new ExternalCreateWalletRequest.ExternalMetadata
                  {
                     AdditionalData = createRandomCreateWalletRequestProperties.Metadata.AdditionalData,
                     EvenMore = createRandomCreateWalletRequestProperties.Metadata.EvenMore
                  }
             
            };

            var createCreateWallet = new CreateWallet
            {
                Request = new CreateWalletRequest
                {
                    Address = createRandomCreateWalletRequestProperties.Address,
                    Bvn = createRandomCreateWalletRequestProperties.Bvn,
                    DateOfBirth = createRandomCreateWalletRequestProperties.DateOfBirth,
                    Email = createRandomCreateWalletRequestProperties.Email,
                    FirstName = createRandomCreateWalletRequestProperties.FirstName,
                    LastName = createRandomCreateWalletRequestProperties.LastName,
                    PhoneNumber = createRandomCreateWalletRequestProperties.PhoneNumber,
                    Metadata = new CreateWalletRequest.MetadataResponse
                    {
                        AdditionalData = createRandomCreateWalletRequestProperties.Metadata.AdditionalData,
                        EvenMore = createRandomCreateWalletRequestProperties.Metadata.EvenMore
                    }
                },
            };




            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException();

            var invalidConfigurationWalletException =
                new InvalidConfigurationWalletException(
                    message: "Invalid Wallet configuration error occurred, contact support.",
                    httpResponseUrlNotFoundException);

            var expectedWalletDependencyException =
                new WalletDependencyException(
                    message: "Wallet dependency error occurred, contact support.",
                    invalidConfigurationWalletException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostCreateWalletAsync(It.IsAny<ExternalCreateWalletRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<CreateWallet> retrieveCreateWalletTask =
               this.walletService.PostCreateWalletRequestAsync(createCreateWallet);

            WalletDependencyException
                actualWalletDependencyException =
                    await Assert.ThrowsAsync<WalletDependencyException>(
                        retrieveCreateWalletTask.AsTask);

            // then
            actualWalletDependencyException.Should().BeEquivalentTo(
                expectedWalletDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostCreateWalletAsync(It.IsAny<ExternalCreateWalletRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnCreateWalletRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            

            dynamic createRandomCreateWalletRequestProperties =
             CreateRandomCreateWalletRequestProperties();

            var createCreateWalletRequest = new ExternalCreateWalletRequest
            {
                Address = createRandomCreateWalletRequestProperties.Address,
                Bvn = createRandomCreateWalletRequestProperties.Bvn,
                DateOfBirth = createRandomCreateWalletRequestProperties.DateOfBirth,
                Email = createRandomCreateWalletRequestProperties.Email,
                FirstName = createRandomCreateWalletRequestProperties.FirstName,
                LastName = createRandomCreateWalletRequestProperties.LastName,
                PhoneNumber = createRandomCreateWalletRequestProperties.PhoneNumber,
                Metadata = new ExternalCreateWalletRequest.ExternalMetadata
                {
                    AdditionalData = createRandomCreateWalletRequestProperties.Metadata.AdditionalData,
                    EvenMore = createRandomCreateWalletRequestProperties.Metadata.EvenMore
                }

            };

            var createCreateWallet = new CreateWallet
            {
                Request = new CreateWalletRequest
                {
                    Address = createRandomCreateWalletRequestProperties.Address,
                    Bvn = createRandomCreateWalletRequestProperties.Bvn,
                    DateOfBirth = createRandomCreateWalletRequestProperties.DateOfBirth,
                    Email = createRandomCreateWalletRequestProperties.Email,
                    FirstName = createRandomCreateWalletRequestProperties.FirstName,
                    LastName = createRandomCreateWalletRequestProperties.LastName,
                    PhoneNumber = createRandomCreateWalletRequestProperties.PhoneNumber,
                    Metadata = new CreateWalletRequest.MetadataResponse
                    {
                        AdditionalData = createRandomCreateWalletRequestProperties.Metadata.AdditionalData,
                        EvenMore = createRandomCreateWalletRequestProperties.Metadata.EvenMore
                    }
                },
            };


            var unauthorizedWalletException =
                new UnauthorizedWalletException(unauthorizedException);

            var expectedWalletDependencyException =
                new WalletDependencyException(unauthorizedWalletException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.PostCreateWalletAsync(It.IsAny<ExternalCreateWalletRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<CreateWallet> retrieveCreateWalletTask =
               this.walletService.PostCreateWalletRequestAsync(createCreateWallet);

            WalletDependencyException
                actualWalletDependencyException =
                    await Assert.ThrowsAsync<WalletDependencyException>(
                        retrieveCreateWalletTask.AsTask);

            // then
            actualWalletDependencyException.Should().BeEquivalentTo(
                expectedWalletDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostCreateWalletAsync(It.IsAny<ExternalCreateWalletRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnCreateWalletRequestIfNotFoundOccurredAsync()
        {
            // given
            

                dynamic createRandomCreateWalletRequestProperties =
                 CreateRandomCreateWalletRequestProperties();

            var createCreateWalletRequest = new ExternalCreateWalletRequest
            {
                Address = createRandomCreateWalletRequestProperties.Address,
                Bvn = createRandomCreateWalletRequestProperties.Bvn,
                DateOfBirth = createRandomCreateWalletRequestProperties.DateOfBirth,
                Email = createRandomCreateWalletRequestProperties.Email,
                FirstName = createRandomCreateWalletRequestProperties.FirstName,
                LastName = createRandomCreateWalletRequestProperties.LastName,
                PhoneNumber = createRandomCreateWalletRequestProperties.PhoneNumber,
                Metadata = new ExternalCreateWalletRequest.ExternalMetadata
                {
                    AdditionalData = createRandomCreateWalletRequestProperties.Metadata.AdditionalData,
                    EvenMore = createRandomCreateWalletRequestProperties.Metadata.EvenMore
                }
            };

            var createCreateWallet = new CreateWallet
            {
                Request = new CreateWalletRequest
                {
                    Address = createRandomCreateWalletRequestProperties.Address,
                    Bvn = createRandomCreateWalletRequestProperties.Bvn,
                    DateOfBirth = createRandomCreateWalletRequestProperties.DateOfBirth,
                    Email = createRandomCreateWalletRequestProperties.Email,
                    FirstName = createRandomCreateWalletRequestProperties.FirstName,
                    LastName = createRandomCreateWalletRequestProperties.LastName,
                    PhoneNumber = createRandomCreateWalletRequestProperties.PhoneNumber,
                    Metadata = new CreateWalletRequest.MetadataResponse
                    {
                        AdditionalData = createRandomCreateWalletRequestProperties.Metadata.AdditionalData,
                        EvenMore = createRandomCreateWalletRequestProperties.Metadata.EvenMore
                    }
                },
            };


            var httpResponseNotFoundException =
                new HttpResponseNotFoundException();

            var notFoundWalletException =
                new NotFoundWalletException(
                    message: "Not found Wallet error occurred, fix errors and try again.",
                    httpResponseNotFoundException);

            var expectedWalletDependencyValidationException =
                new WalletDependencyValidationException(
                    message: "Wallet dependency validation error occurred, contact support.",
                    notFoundWalletException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostCreateWalletAsync(It.IsAny<ExternalCreateWalletRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<CreateWallet> retrieveCreateWalletTask =
               this.walletService.PostCreateWalletRequestAsync(createCreateWallet);

            WalletDependencyValidationException
                actualWalletDependencyValidationException =
                    await Assert.ThrowsAsync<WalletDependencyValidationException>(
                        retrieveCreateWalletTask.AsTask);

            // then
            actualWalletDependencyValidationException.Should().BeEquivalentTo(
                expectedWalletDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostCreateWalletAsync(It.IsAny<ExternalCreateWalletRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnCreateWalletRequestIfBadRequestOccurredAsync()
        {
            // given
            

                dynamic createRandomCreateWalletRequestProperties =
                 CreateRandomCreateWalletRequestProperties();

            var createCreateWalletRequest = new ExternalCreateWalletRequest
            {
                Address = createRandomCreateWalletRequestProperties.Address,
                Bvn = createRandomCreateWalletRequestProperties.Bvn,
                DateOfBirth = createRandomCreateWalletRequestProperties.DateOfBirth,
                Email = createRandomCreateWalletRequestProperties.Email,
                FirstName = createRandomCreateWalletRequestProperties.FirstName,
                LastName = createRandomCreateWalletRequestProperties.LastName,
                PhoneNumber = createRandomCreateWalletRequestProperties.PhoneNumber,
                Metadata = new ExternalCreateWalletRequest.ExternalMetadata
                {
                    AdditionalData = createRandomCreateWalletRequestProperties.Metadata.AdditionalData,
                    EvenMore = createRandomCreateWalletRequestProperties.Metadata.EvenMore
                }
            };

            var createCreateWallet = new CreateWallet
            {
                Request = new CreateWalletRequest
                {
                    Address = createRandomCreateWalletRequestProperties.Address,
                    Bvn = createRandomCreateWalletRequestProperties.Bvn,
                    DateOfBirth = createRandomCreateWalletRequestProperties.DateOfBirth,
                    Email = createRandomCreateWalletRequestProperties.Email,
                    FirstName = createRandomCreateWalletRequestProperties.FirstName,
                    LastName = createRandomCreateWalletRequestProperties.LastName,
                    PhoneNumber = createRandomCreateWalletRequestProperties.PhoneNumber,
                    Metadata = new CreateWalletRequest.MetadataResponse
                    {
                        AdditionalData = createRandomCreateWalletRequestProperties.Metadata.AdditionalData,
                        EvenMore = createRandomCreateWalletRequestProperties.Metadata.EvenMore
                    }
                },
            };

            var httpResponseBadRequestException =
                new HttpResponseBadRequestException();

            var invalidWalletException =
                new InvalidWalletException(
                    message: "Invalid Wallet error occurred, fix errors and try again.",
                    httpResponseBadRequestException);

            var expectedWalletDependencyValidationException =
                new WalletDependencyValidationException(
                    message: "Wallet dependency validation error occurred, contact support.",
                    invalidWalletException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostCreateWalletAsync(It.IsAny<ExternalCreateWalletRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<CreateWallet> retrieveCreateWalletTask =
               this.walletService.PostCreateWalletRequestAsync(createCreateWallet);

            WalletDependencyValidationException
                actualWalletDependencyValidationException =
                    await Assert.ThrowsAsync<WalletDependencyValidationException>(
                        retrieveCreateWalletTask.AsTask);

            // then
            actualWalletDependencyValidationException.Should().BeEquivalentTo(
                expectedWalletDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostCreateWalletAsync(It.IsAny<ExternalCreateWalletRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnCreateWalletRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            

                dynamic createRandomCreateWalletRequestProperties =
                 CreateRandomCreateWalletRequestProperties();

            var createCreateWalletRequest = new ExternalCreateWalletRequest
            {
                Address = createRandomCreateWalletRequestProperties.Address,
                Bvn = createRandomCreateWalletRequestProperties.Bvn,
                DateOfBirth = createRandomCreateWalletRequestProperties.DateOfBirth,
                Email = createRandomCreateWalletRequestProperties.Email,
                FirstName = createRandomCreateWalletRequestProperties.FirstName,
                LastName = createRandomCreateWalletRequestProperties.LastName,
                PhoneNumber = createRandomCreateWalletRequestProperties.PhoneNumber,
                Metadata = new ExternalCreateWalletRequest.ExternalMetadata
                {
                    AdditionalData = createRandomCreateWalletRequestProperties.Metadata.AdditionalData,
                    EvenMore = createRandomCreateWalletRequestProperties.Metadata.EvenMore
                }
            };

            var createCreateWallet = new CreateWallet
            {
                Request = new CreateWalletRequest
                {
                    Address = createRandomCreateWalletRequestProperties.Address,
                    Bvn = createRandomCreateWalletRequestProperties.Bvn,
                    DateOfBirth = createRandomCreateWalletRequestProperties.DateOfBirth,
                    Email = createRandomCreateWalletRequestProperties.Email,
                    FirstName = createRandomCreateWalletRequestProperties.FirstName,
                    LastName = createRandomCreateWalletRequestProperties.LastName,
                    PhoneNumber = createRandomCreateWalletRequestProperties.PhoneNumber,
                    Metadata = new CreateWalletRequest.MetadataResponse
                    {
                        AdditionalData = createRandomCreateWalletRequestProperties.Metadata.AdditionalData,
                        EvenMore = createRandomCreateWalletRequestProperties.Metadata.EvenMore
                    }
                },
            };

            var httpResponseTooManyRequestsException =
                new HttpResponseTooManyRequestsException();

            var excessiveCallWalletException =
                new ExcessiveCallWalletException(
                    message: "Excessive call error occurred, limit your calls.",
                    httpResponseTooManyRequestsException);

            var expectedWalletDependencyValidationException =
                new WalletDependencyValidationException(
                    message: "Wallet dependency validation error occurred, contact support.",
                    excessiveCallWalletException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.PostCreateWalletAsync(It.IsAny<ExternalCreateWalletRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<CreateWallet> retrieveCreateWalletTask =
               this.walletService.PostCreateWalletRequestAsync(createCreateWallet);

            WalletDependencyValidationException actualWalletDependencyValidationException =
                await Assert.ThrowsAsync<WalletDependencyValidationException>(
                    retrieveCreateWalletTask.AsTask);

            // then
            actualWalletDependencyValidationException.Should().BeEquivalentTo(
                expectedWalletDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostCreateWalletAsync(It.IsAny<ExternalCreateWalletRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnCreateWalletRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            

                dynamic createRandomCreateWalletRequestProperties =
                 CreateRandomCreateWalletRequestProperties();

            var createCreateWalletRequest = new ExternalCreateWalletRequest
            {
                Address = createRandomCreateWalletRequestProperties.Address,
                Bvn = createRandomCreateWalletRequestProperties.Bvn,
                DateOfBirth = createRandomCreateWalletRequestProperties.DateOfBirth,
                Email = createRandomCreateWalletRequestProperties.Email,
                FirstName = createRandomCreateWalletRequestProperties.FirstName,
                LastName = createRandomCreateWalletRequestProperties.LastName,
                PhoneNumber = createRandomCreateWalletRequestProperties.PhoneNumber,
                Metadata = new ExternalCreateWalletRequest.ExternalMetadata
                {
                    AdditionalData = createRandomCreateWalletRequestProperties.Metadata.AdditionalData,
                    EvenMore = createRandomCreateWalletRequestProperties.Metadata.EvenMore
                }
            };

            var createCreateWallet = new CreateWallet
            {
                Request = new CreateWalletRequest
                {
                    Address = createRandomCreateWalletRequestProperties.Address,
                    Bvn = createRandomCreateWalletRequestProperties.Bvn,
                    DateOfBirth = createRandomCreateWalletRequestProperties.DateOfBirth,
                    Email = createRandomCreateWalletRequestProperties.Email,
                    FirstName = createRandomCreateWalletRequestProperties.FirstName,
                    LastName = createRandomCreateWalletRequestProperties.LastName,
                    PhoneNumber = createRandomCreateWalletRequestProperties.PhoneNumber,
                    Metadata = new CreateWalletRequest.MetadataResponse
                    {
                        AdditionalData = createRandomCreateWalletRequestProperties.Metadata.AdditionalData,
                        EvenMore = createRandomCreateWalletRequestProperties.Metadata.EvenMore
                    }
                },
            };

            var httpResponseException =
                new HttpResponseException();

            var failedServerWalletException =
                new FailedServerWalletException(
                    message: "Failed Wallet server error occurred, contact support.",
                    httpResponseException);

            var expectedWalletDependencyException =
                new WalletDependencyException(
                    message: "Wallet dependency error occurred, contact support.",
                    failedServerWalletException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.PostCreateWalletAsync(It.IsAny<ExternalCreateWalletRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<CreateWallet> retrieveCreateWalletTask =
               this.walletService.PostCreateWalletRequestAsync(createCreateWallet);

            WalletDependencyException actualWalletDependencyException =
                await Assert.ThrowsAsync<WalletDependencyException>(
                    retrieveCreateWalletTask.AsTask);

            // then
            actualWalletDependencyException.Should().BeEquivalentTo(
                expectedWalletDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostCreateWalletAsync(It.IsAny<ExternalCreateWalletRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnCreateWalletRequestIfServiceErrorOccurredAsync()
        {
            // given
            

                dynamic createRandomCreateWalletRequestProperties =
                 CreateRandomCreateWalletRequestProperties();

            var createCreateWalletRequest = new ExternalCreateWalletRequest
            {
                Address = createRandomCreateWalletRequestProperties.Address,
                Bvn = createRandomCreateWalletRequestProperties.Bvn,
                DateOfBirth = createRandomCreateWalletRequestProperties.DateOfBirth,
                Email = createRandomCreateWalletRequestProperties.Email,
                FirstName = createRandomCreateWalletRequestProperties.FirstName,
                LastName = createRandomCreateWalletRequestProperties.LastName,
                PhoneNumber = createRandomCreateWalletRequestProperties.PhoneNumber,
                Metadata = new ExternalCreateWalletRequest.ExternalMetadata
                {
                    AdditionalData = createRandomCreateWalletRequestProperties.Metadata.AdditionalData,
                    EvenMore = createRandomCreateWalletRequestProperties.Metadata.EvenMore
                }
            };

            var createCreateWallet = new CreateWallet
            {
                Request = new CreateWalletRequest
                {
                    Address = createRandomCreateWalletRequestProperties.Address,
                    Bvn = createRandomCreateWalletRequestProperties.Bvn,
                    DateOfBirth = createRandomCreateWalletRequestProperties.DateOfBirth,
                    Email = createRandomCreateWalletRequestProperties.Email,
                    FirstName = createRandomCreateWalletRequestProperties.FirstName,
                    LastName = createRandomCreateWalletRequestProperties.LastName,
                    PhoneNumber = createRandomCreateWalletRequestProperties.PhoneNumber,
                    Metadata = new CreateWalletRequest.MetadataResponse
                    {
                        AdditionalData = createRandomCreateWalletRequestProperties.Metadata.AdditionalData,
                        EvenMore = createRandomCreateWalletRequestProperties.Metadata.EvenMore
                    }
                },
            };
            var serviceException = new Exception();

            var failedWalletServiceException =
                new FailedWalletServiceException(serviceException);

            var expectedWalletServiceException =
                new WalletServiceException(failedWalletServiceException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostCreateWalletAsync(It.IsAny<ExternalCreateWalletRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<CreateWallet> retrieveCreateWalletTask =
               this.walletService.PostCreateWalletRequestAsync(createCreateWallet);

            WalletServiceException actualWalletServiceException =
                await Assert.ThrowsAsync<WalletServiceException>(
                    retrieveCreateWalletTask.AsTask);

            // then
            actualWalletServiceException.Should().BeEquivalentTo(
                expectedWalletServiceException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostCreateWalletAsync(It.IsAny<ExternalCreateWalletRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
