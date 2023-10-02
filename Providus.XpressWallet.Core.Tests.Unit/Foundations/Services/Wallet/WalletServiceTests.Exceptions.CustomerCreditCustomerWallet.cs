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
        public async Task ShouldThrowDependencyExceptionOnCustomerCreditCustomerWalletRequestIfUrlNotFoundAsync()
        {
            // given
            

            dynamic createRandomCustomerCreditCustomerWalletRequestProperties =
                 CreateRandomCustomerCreditCustomerWalletRequestProperties();

            var createCustomerCreditCustomerWalletRequest = new ExternalCustomerCreditCustomerWalletRequest
            {
                 BatchReference = createRandomCustomerCreditCustomerWalletRequestProperties.BatchReference,
                 CustomerId = createRandomCustomerCreditCustomerWalletRequestProperties.CustomerId,
                 Recipients = ((List<dynamic>)createRandomCustomerCreditCustomerWalletRequestProperties.Recipients).Select(recipients =>
                 {
                     return new ExternalCustomerCreditCustomerWalletRequest.Recipient
                     {
                         CustomerId = recipients.CustomerId,
                         Amount = recipients.Amount,
                         Reference = recipients.Reference

                     };
                 }).ToList()
                 
             
            };

            var createCustomerCreditCustomerWallet = new CustomerCreditCustomerWallet
            {
                Request = new CustomerCreditCustomerWalletRequest
                {
                    BatchReference = createRandomCustomerCreditCustomerWalletRequestProperties.BatchReference,
                    CustomerId = createRandomCustomerCreditCustomerWalletRequestProperties.CustomerId,
                    Recipients = ((List<dynamic>)createRandomCustomerCreditCustomerWalletRequestProperties.Recipients).Select(recipients =>
                    {
                        return new CustomerCreditCustomerWalletRequest.Recipient
                        {
                            CustomerId = recipients.CustomerId,
                            Amount = recipients.Amount,
                            Reference = recipients.Reference

                        };
                    }).ToList()
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
                broker.PostCustomerCreditCustomerWalletAsync(It.IsAny<ExternalCustomerCreditCustomerWalletRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<CustomerCreditCustomerWallet> retrieveCustomerCreditCustomerWalletTask =
               this.walletService.PostCustomerCreditCustomerWalletRequestAsync(createCustomerCreditCustomerWallet);

            WalletDependencyException
                actualWalletDependencyException =
                    await Assert.ThrowsAsync<WalletDependencyException>(
                        retrieveCustomerCreditCustomerWalletTask.AsTask);

            // then
            actualWalletDependencyException.Should().BeEquivalentTo(
                expectedWalletDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostCustomerCreditCustomerWalletAsync(It.IsAny<ExternalCustomerCreditCustomerWalletRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnCustomerCreditCustomerWalletRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            

            dynamic createRandomCustomerCreditCustomerWalletRequestProperties =
             CreateRandomCustomerCreditCustomerWalletRequestProperties();

            var createCustomerCreditCustomerWalletRequest = new ExternalCustomerCreditCustomerWalletRequest
            {
                BatchReference = createRandomCustomerCreditCustomerWalletRequestProperties.BatchReference,
                CustomerId = createRandomCustomerCreditCustomerWalletRequestProperties.CustomerId,
                Recipients = ((List<dynamic>)createRandomCustomerCreditCustomerWalletRequestProperties.Recipients).Select(recipients =>
                {
                    return new ExternalCustomerCreditCustomerWalletRequest.Recipient
                    {
                        CustomerId = recipients.CustomerId,
                        Amount = recipients.Amount,
                        Reference = recipients.Reference

                    };
                }).ToList()

            };

            var createCustomerCreditCustomerWallet = new CustomerCreditCustomerWallet
            {
                Request = new CustomerCreditCustomerWalletRequest
                {
                    BatchReference = createRandomCustomerCreditCustomerWalletRequestProperties.BatchReference,
                    CustomerId = createRandomCustomerCreditCustomerWalletRequestProperties.CustomerId,
                    Recipients = ((List<dynamic>)createRandomCustomerCreditCustomerWalletRequestProperties.Recipients).Select(recipients =>
                    {
                        return new CustomerCreditCustomerWalletRequest.Recipient
                        {
                            CustomerId = recipients.CustomerId,
                            Amount = recipients.Amount,
                            Reference = recipients.Reference

                        };
                    }).ToList()
                },
            };


            var unauthorizedWalletException =
                new UnauthorizedWalletException(unauthorizedException);

            var expectedWalletDependencyException =
                new WalletDependencyException(unauthorizedWalletException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.PostCustomerCreditCustomerWalletAsync(It.IsAny<ExternalCustomerCreditCustomerWalletRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<CustomerCreditCustomerWallet> retrieveCustomerCreditCustomerWalletTask =
               this.walletService.PostCustomerCreditCustomerWalletRequestAsync(createCustomerCreditCustomerWallet);

            WalletDependencyException
                actualWalletDependencyException =
                    await Assert.ThrowsAsync<WalletDependencyException>(
                        retrieveCustomerCreditCustomerWalletTask.AsTask);

            // then
            actualWalletDependencyException.Should().BeEquivalentTo(
                expectedWalletDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostCustomerCreditCustomerWalletAsync(It.IsAny<ExternalCustomerCreditCustomerWalletRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnCustomerCreditCustomerWalletRequestIfNotFoundOccurredAsync()
        {
            // given
            

                dynamic createRandomCustomerCreditCustomerWalletRequestProperties =
                 CreateRandomCustomerCreditCustomerWalletRequestProperties();

            var createCustomerCreditCustomerWalletRequest = new ExternalCustomerCreditCustomerWalletRequest
            {
                BatchReference = createRandomCustomerCreditCustomerWalletRequestProperties.BatchReference,
                CustomerId = createRandomCustomerCreditCustomerWalletRequestProperties.CustomerId,
                Recipients = ((List<dynamic>)createRandomCustomerCreditCustomerWalletRequestProperties.Recipients).Select(recipients =>
                {
                    return new ExternalCustomerCreditCustomerWalletRequest.Recipient
                    {
                        CustomerId = recipients.CustomerId,
                        Amount = recipients.Amount,
                        Reference = recipients.Reference

                    };
                }).ToList()
            };

            var createCustomerCreditCustomerWallet = new CustomerCreditCustomerWallet
            {
                Request = new CustomerCreditCustomerWalletRequest
                {
                    BatchReference = createRandomCustomerCreditCustomerWalletRequestProperties.BatchReference,
                    CustomerId = createRandomCustomerCreditCustomerWalletRequestProperties.CustomerId,
                    Recipients = ((List<dynamic>)createRandomCustomerCreditCustomerWalletRequestProperties.Recipients).Select(recipients =>
                    {
                        return new CustomerCreditCustomerWalletRequest.Recipient
                        {
                            CustomerId = recipients.CustomerId,
                            Amount = recipients.Amount,
                            Reference = recipients.Reference

                        };
                    }).ToList()
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
                broker.PostCustomerCreditCustomerWalletAsync(It.IsAny<ExternalCustomerCreditCustomerWalletRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<CustomerCreditCustomerWallet> retrieveCustomerCreditCustomerWalletTask =
               this.walletService.PostCustomerCreditCustomerWalletRequestAsync(createCustomerCreditCustomerWallet);

            WalletDependencyValidationException
                actualWalletDependencyValidationException =
                    await Assert.ThrowsAsync<WalletDependencyValidationException>(
                        retrieveCustomerCreditCustomerWalletTask.AsTask);

            // then
            actualWalletDependencyValidationException.Should().BeEquivalentTo(
                expectedWalletDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostCustomerCreditCustomerWalletAsync(It.IsAny<ExternalCustomerCreditCustomerWalletRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnCustomerCreditCustomerWalletRequestIfBadRequestOccurredAsync()
        {
            // given
            

                dynamic createRandomCustomerCreditCustomerWalletRequestProperties =
                 CreateRandomCustomerCreditCustomerWalletRequestProperties();

            var createCustomerCreditCustomerWalletRequest = new ExternalCustomerCreditCustomerWalletRequest
            {
                BatchReference = createRandomCustomerCreditCustomerWalletRequestProperties.BatchReference,
                 CustomerId = createRandomCustomerCreditCustomerWalletRequestProperties.CustomerId,
                 Recipients = ((List<dynamic>)createRandomCustomerCreditCustomerWalletRequestProperties.Recipients).Select(recipients =>
                 {
                     return new ExternalCustomerCreditCustomerWalletRequest.Recipient
                     {
                         CustomerId = recipients.CustomerId,
                         Amount = recipients.Amount,
                         Reference = recipients.Reference

                     };
                 }).ToList()
            };

            var createCustomerCreditCustomerWallet = new CustomerCreditCustomerWallet
            {
                Request = new CustomerCreditCustomerWalletRequest
                {
                    BatchReference = createRandomCustomerCreditCustomerWalletRequestProperties.BatchReference,
                    CustomerId = createRandomCustomerCreditCustomerWalletRequestProperties.CustomerId,
                    Recipients = ((List<dynamic>)createRandomCustomerCreditCustomerWalletRequestProperties.Recipients).Select(recipients =>
                    {
                        return new CustomerCreditCustomerWalletRequest.Recipient
                        {
                            CustomerId = recipients.CustomerId,
                            Amount = recipients.Amount,
                            Reference = recipients.Reference

                        };
                    }).ToList()
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
                broker.PostCustomerCreditCustomerWalletAsync(It.IsAny<ExternalCustomerCreditCustomerWalletRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<CustomerCreditCustomerWallet> retrieveCustomerCreditCustomerWalletTask =
               this.walletService.PostCustomerCreditCustomerWalletRequestAsync(createCustomerCreditCustomerWallet);

            WalletDependencyValidationException
                actualWalletDependencyValidationException =
                    await Assert.ThrowsAsync<WalletDependencyValidationException>(
                        retrieveCustomerCreditCustomerWalletTask.AsTask);

            // then
            actualWalletDependencyValidationException.Should().BeEquivalentTo(
                expectedWalletDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostCustomerCreditCustomerWalletAsync(It.IsAny<ExternalCustomerCreditCustomerWalletRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnCustomerCreditCustomerWalletRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            

                dynamic createRandomCustomerCreditCustomerWalletRequestProperties =
                 CreateRandomCustomerCreditCustomerWalletRequestProperties();

            var createCustomerCreditCustomerWalletRequest = new ExternalCustomerCreditCustomerWalletRequest
            {
                BatchReference = createRandomCustomerCreditCustomerWalletRequestProperties.BatchReference,
                 CustomerId = createRandomCustomerCreditCustomerWalletRequestProperties.CustomerId,
                 Recipients = ((List<dynamic>)createRandomCustomerCreditCustomerWalletRequestProperties.Recipients).Select(recipients =>
                 {
                     return new ExternalCustomerCreditCustomerWalletRequest.Recipient
                     {
                         CustomerId = recipients.CustomerId,
                         Amount = recipients.Amount,
                         Reference = recipients.Reference

                     };
                 }).ToList()
            };

            var createCustomerCreditCustomerWallet = new CustomerCreditCustomerWallet
            {
                Request = new CustomerCreditCustomerWalletRequest
                {
                    BatchReference = createRandomCustomerCreditCustomerWalletRequestProperties.BatchReference,
                    CustomerId = createRandomCustomerCreditCustomerWalletRequestProperties.CustomerId,
                    Recipients = ((List<dynamic>)createRandomCustomerCreditCustomerWalletRequestProperties.Recipients).Select(recipients =>
                    {
                        return new CustomerCreditCustomerWalletRequest.Recipient
                        {
                            CustomerId = recipients.CustomerId,
                            Amount = recipients.Amount,
                            Reference = recipients.Reference

                        };
                    }).ToList()
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
                 broker.PostCustomerCreditCustomerWalletAsync(It.IsAny<ExternalCustomerCreditCustomerWalletRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<CustomerCreditCustomerWallet> retrieveCustomerCreditCustomerWalletTask =
               this.walletService.PostCustomerCreditCustomerWalletRequestAsync(createCustomerCreditCustomerWallet);

            WalletDependencyValidationException actualWalletDependencyValidationException =
                await Assert.ThrowsAsync<WalletDependencyValidationException>(
                    retrieveCustomerCreditCustomerWalletTask.AsTask);

            // then
            actualWalletDependencyValidationException.Should().BeEquivalentTo(
                expectedWalletDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostCustomerCreditCustomerWalletAsync(It.IsAny<ExternalCustomerCreditCustomerWalletRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnCustomerCreditCustomerWalletRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            

                dynamic createRandomCustomerCreditCustomerWalletRequestProperties =
                 CreateRandomCustomerCreditCustomerWalletRequestProperties();

            var createCustomerCreditCustomerWalletRequest = new ExternalCustomerCreditCustomerWalletRequest
            {
                BatchReference = createRandomCustomerCreditCustomerWalletRequestProperties.BatchReference,
                 CustomerId = createRandomCustomerCreditCustomerWalletRequestProperties.CustomerId,
                 Recipients = ((List<dynamic>)createRandomCustomerCreditCustomerWalletRequestProperties.Recipients).Select(recipients =>
                 {
                     return new ExternalCustomerCreditCustomerWalletRequest.Recipient
                     {
                         CustomerId = recipients.CustomerId,
                         Amount = recipients.Amount,
                         Reference = recipients.Reference

                     };
                 }).ToList()
            };

            var createCustomerCreditCustomerWallet = new CustomerCreditCustomerWallet
            {
                Request = new CustomerCreditCustomerWalletRequest
                {
                    BatchReference = createRandomCustomerCreditCustomerWalletRequestProperties.BatchReference,
                    CustomerId = createRandomCustomerCreditCustomerWalletRequestProperties.CustomerId,
                    Recipients = ((List<dynamic>)createRandomCustomerCreditCustomerWalletRequestProperties.Recipients).Select(recipients =>
                    {
                        return new CustomerCreditCustomerWalletRequest.Recipient
                        {
                            CustomerId = recipients.CustomerId,
                            Amount = recipients.Amount,
                            Reference = recipients.Reference

                        };
                    }).ToList()
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
                 broker.PostCustomerCreditCustomerWalletAsync(It.IsAny<ExternalCustomerCreditCustomerWalletRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<CustomerCreditCustomerWallet> retrieveCustomerCreditCustomerWalletTask =
               this.walletService.PostCustomerCreditCustomerWalletRequestAsync(createCustomerCreditCustomerWallet);

            WalletDependencyException actualWalletDependencyException =
                await Assert.ThrowsAsync<WalletDependencyException>(
                    retrieveCustomerCreditCustomerWalletTask.AsTask);

            // then
            actualWalletDependencyException.Should().BeEquivalentTo(
                expectedWalletDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostCustomerCreditCustomerWalletAsync(It.IsAny<ExternalCustomerCreditCustomerWalletRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnCustomerCreditCustomerWalletRequestIfServiceErrorOccurredAsync()
        {
            // given
            

                dynamic createRandomCustomerCreditCustomerWalletRequestProperties =
                 CreateRandomCustomerCreditCustomerWalletRequestProperties();

            var createCustomerCreditCustomerWalletRequest = new ExternalCustomerCreditCustomerWalletRequest
            {
                BatchReference = createRandomCustomerCreditCustomerWalletRequestProperties.BatchReference,
                 CustomerId = createRandomCustomerCreditCustomerWalletRequestProperties.CustomerId,
                 Recipients = ((List<dynamic>)createRandomCustomerCreditCustomerWalletRequestProperties.Recipients).Select(recipients =>
                 {
                     return new ExternalCustomerCreditCustomerWalletRequest.Recipient
                     {
                         CustomerId = recipients.CustomerId,
                         Amount = recipients.Amount,
                         Reference = recipients.Reference

                     };
                 }).ToList()
            };

            var createCustomerCreditCustomerWallet = new CustomerCreditCustomerWallet
            {
                Request = new CustomerCreditCustomerWalletRequest
                {
                    BatchReference = createRandomCustomerCreditCustomerWalletRequestProperties.BatchReference,
                    CustomerId = createRandomCustomerCreditCustomerWalletRequestProperties.CustomerId,
                    Recipients = ((List<dynamic>)createRandomCustomerCreditCustomerWalletRequestProperties.Recipients).Select(recipients =>
                    {
                        return new CustomerCreditCustomerWalletRequest.Recipient
                        {
                            CustomerId = recipients.CustomerId,
                            Amount = recipients.Amount,
                            Reference = recipients.Reference

                        };
                    }).ToList()
                },
            };
            var serviceException = new Exception();

            var failedWalletServiceException =
                new FailedWalletServiceException(serviceException);

            var expectedWalletServiceException =
                new WalletServiceException(failedWalletServiceException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostCustomerCreditCustomerWalletAsync(It.IsAny<ExternalCustomerCreditCustomerWalletRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<CustomerCreditCustomerWallet> retrieveCustomerCreditCustomerWalletTask =
               this.walletService.PostCustomerCreditCustomerWalletRequestAsync(createCustomerCreditCustomerWallet);

            WalletServiceException actualWalletServiceException =
                await Assert.ThrowsAsync<WalletServiceException>(
                    retrieveCustomerCreditCustomerWalletTask.AsTask);

            // then
            actualWalletServiceException.Should().BeEquivalentTo(
                expectedWalletServiceException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostCustomerCreditCustomerWalletAsync(It.IsAny<ExternalCustomerCreditCustomerWalletRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
