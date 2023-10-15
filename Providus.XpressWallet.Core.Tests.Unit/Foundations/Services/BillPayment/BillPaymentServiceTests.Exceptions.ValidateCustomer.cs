using FluentAssertions;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalProviPay.ExternalValidate;
using Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.Exceptions;
using Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.Validate;
using RESTFulSense.Exceptions;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.BillPayment
{
    public partial class BillPaymentServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnValidateCustomerRequestIfUrlNotFoundAsync()
        {
            // given
            var inputBillId = GetRandomString();

            dynamic createRandomValidateRequestProperties =
                 CreateRandomValidateRequestProperties();

            var createBillPaymentRequest = new ExternalValidateRequest
            {
                 BillId = createRandomValidateRequestProperties.BillId,
                 ChannelRef = createRandomValidateRequestProperties.ChannelRef,
                 CustomerAccountNo = createRandomValidateRequestProperties.CustomerAccountNo,
                 Inputs = ((List<dynamic>)createRandomValidateRequestProperties.Inputs).Select(inputs =>
                 {
                     return new ExternalValidateRequest.Input
                     {
                         Key = inputs.Key,
                         Value = inputs.Value
                     };
                 }).ToList(),
                 

             
            };

            var createBillPayment = new Validate
            {
                Request = new ValidateRequest
                {
                    BillId = createRandomValidateRequestProperties.BillId,
                    ChannelRef = createRandomValidateRequestProperties.ChannelRef,
                    CustomerAccountNo = createRandomValidateRequestProperties.CustomerAccountNo,
                    Inputs = ((List<dynamic>)createRandomValidateRequestProperties.Inputs).Select(inputs =>
                    {
                        return new ValidateRequest.Input
                        {
                            Key = inputs.Key,
                            Value = inputs.Value
                        };
                    }).ToList(),
                },
            };




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
                broker.PostValidateCustomerAsync(It.IsAny<ExternalValidateRequest>(),inputBillId))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<Validate> retrieveValidateTask =
               this.billPaymentService.PostValidateCustomerRequestAsync(createBillPayment, inputBillId);

            BillPaymentDependencyException
                actualBillPaymentDependencyException =
                    await Assert.ThrowsAsync<BillPaymentDependencyException>(
                        retrieveValidateTask.AsTask);

            // then
            actualBillPaymentDependencyException.Should().BeEquivalentTo(
                expectedBillPaymentDependencyException);

            this.proviPayBrokerMock.Verify(broker =>
                broker.PostValidateCustomerAsync(It.IsAny<ExternalValidateRequest>(),inputBillId),
                    Times.Once);

            this.proviPayBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnValidateRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            var inputBillId = GetRandomString();

            dynamic createRandomValidateRequestProperties =
             CreateRandomValidateRequestProperties();

            var createBillPaymentRequest = new ExternalValidateRequest
            {
                BillId = createRandomValidateRequestProperties.BillId,
                ChannelRef = createRandomValidateRequestProperties.ChannelRef,
                CustomerAccountNo = createRandomValidateRequestProperties.CustomerAccountNo,
                Inputs = ((List<dynamic>)createRandomValidateRequestProperties.Inputs).Select(inputs =>
                {
                    return new ExternalValidateRequest.Input
                    {
                        Key = inputs.Key,
                        Value = inputs.Value
                    };
                }).ToList(),

            };

            var createBillPayment = new Validate
            {
                Request = new ValidateRequest
                {
                    BillId = createRandomValidateRequestProperties.BillId,
                    ChannelRef = createRandomValidateRequestProperties.ChannelRef,
                    CustomerAccountNo = createRandomValidateRequestProperties.CustomerAccountNo,
                    Inputs = ((List<dynamic>)createRandomValidateRequestProperties.Inputs).Select(inputs =>
                    {
                        return new ValidateRequest.Input
                        {
                            Key = inputs.Key,
                            Value = inputs.Value
                        };
                    }).ToList(),
                },
            };


            var unauthorizedBillPaymentException =
                new UnauthorizedBillPaymentException(unauthorizedException);

            var expectedBillPaymentDependencyException =
                new BillPaymentDependencyException(unauthorizedBillPaymentException);

            this.proviPayBrokerMock.Setup(broker =>
                 broker.PostValidateCustomerAsync(It.IsAny<ExternalValidateRequest>(),inputBillId))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<Validate> retrieveValidateTask =
               this.billPaymentService.PostValidateCustomerRequestAsync(createBillPayment, inputBillId);

            BillPaymentDependencyException
                actualBillPaymentDependencyException =
                    await Assert.ThrowsAsync<BillPaymentDependencyException>(
                        retrieveValidateTask.AsTask);

            // then
            actualBillPaymentDependencyException.Should().BeEquivalentTo(
                expectedBillPaymentDependencyException);

            this.proviPayBrokerMock.Verify(broker =>
                broker.PostValidateCustomerAsync(It.IsAny<ExternalValidateRequest>(),inputBillId),
                    Times.Once);

            this.proviPayBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnValidateRequestIfNotFoundOccurredAsync()
        {
            // given
            var inputBillId = GetRandomString();

                dynamic createRandomValidateRequestProperties =
                 CreateRandomValidateRequestProperties();

            var createBillPaymentRequest = new ExternalValidateRequest
            {
                    BillId = createRandomValidateRequestProperties.BillId,
                    ChannelRef = createRandomValidateRequestProperties.ChannelRef,
                    CustomerAccountNo = createRandomValidateRequestProperties.CustomerAccountNo,
                    Inputs = ((List<dynamic>)createRandomValidateRequestProperties.Inputs).Select(inputs =>
                    {
                        return new ExternalValidateRequest.Input
                        {
                            Key = inputs.Key,
                            Value = inputs.Value
                        };
                    }).ToList(),
            };

            var createBillPayment = new Validate
            {
                Request = new ValidateRequest
                {
                    BillId = createRandomValidateRequestProperties.BillId,
                    ChannelRef = createRandomValidateRequestProperties.ChannelRef,
                    CustomerAccountNo = createRandomValidateRequestProperties.CustomerAccountNo,
                    Inputs = ((List<dynamic>)createRandomValidateRequestProperties.Inputs).Select(inputs =>
                    {
                        return new ValidateRequest.Input
                        {
                            Key = inputs.Key,
                            Value = inputs.Value
                        };
                    }).ToList(),
                },
            };


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
                broker.PostValidateCustomerAsync(It.IsAny<ExternalValidateRequest>(),inputBillId))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<Validate> retrieveValidateTask =
               this.billPaymentService.PostValidateCustomerRequestAsync(createBillPayment, inputBillId);

            BillPaymentDependencyValidationException
                actualBillPaymentDependencyValidationException =
                    await Assert.ThrowsAsync<BillPaymentDependencyValidationException>(
                        retrieveValidateTask.AsTask);

            // then
            actualBillPaymentDependencyValidationException.Should().BeEquivalentTo(
                expectedBillPaymentDependencyValidationException);

            this.proviPayBrokerMock.Verify(broker =>
                broker.PostValidateCustomerAsync(It.IsAny<ExternalValidateRequest>(),inputBillId),
                    Times.Once);

            this.proviPayBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnValidateRequestIfBadRequestOccurredAsync()
        {
            // given
            var inputBillId = GetRandomString();

                dynamic createRandomValidateRequestProperties =
                 CreateRandomValidateRequestProperties();

            var createBillPaymentRequest = new ExternalValidateRequest
            {
                BillId = createRandomValidateRequestProperties.BillId,
                ChannelRef = createRandomValidateRequestProperties.ChannelRef,
                CustomerAccountNo = createRandomValidateRequestProperties.CustomerAccountNo,
                Inputs = ((List<dynamic>)createRandomValidateRequestProperties.Inputs).Select(inputs =>
                {
                    return new ExternalValidateRequest.Input
                    {
                        Key = inputs.Key,
                        Value = inputs.Value
                    };
                }).ToList(),
            };

            var createBillPayment = new Validate
            {
                Request = new ValidateRequest
                {
                    BillId = createRandomValidateRequestProperties.BillId,
                    ChannelRef = createRandomValidateRequestProperties.ChannelRef,
                    CustomerAccountNo = createRandomValidateRequestProperties.CustomerAccountNo,
                    Inputs = ((List<dynamic>)createRandomValidateRequestProperties.Inputs).Select(inputs =>
                    {
                        return new ValidateRequest.Input
                        {
                            Key = inputs.Key,
                            Value = inputs.Value
                        };
                    }).ToList(),
                },
            };

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
                broker.PostValidateCustomerAsync(It.IsAny<ExternalValidateRequest>(),inputBillId))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<Validate> retrieveValidateTask =
               this.billPaymentService.PostValidateCustomerRequestAsync(createBillPayment, inputBillId);

            BillPaymentDependencyValidationException
                actualBillPaymentDependencyValidationException =
                    await Assert.ThrowsAsync<BillPaymentDependencyValidationException>(
                        retrieveValidateTask.AsTask);

            // then
            actualBillPaymentDependencyValidationException.Should().BeEquivalentTo(
                expectedBillPaymentDependencyValidationException);

            this.proviPayBrokerMock.Verify(broker =>
                broker.PostValidateCustomerAsync(It.IsAny<ExternalValidateRequest>(),inputBillId),
                    Times.Once);

            this.proviPayBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnValidateRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            var inputBillId = GetRandomString();

                dynamic createRandomValidateRequestProperties =
                 CreateRandomValidateRequestProperties();

            var createBillPaymentRequest = new ExternalValidateRequest
            {
                BillId = createRandomValidateRequestProperties.BillId,
                ChannelRef = createRandomValidateRequestProperties.ChannelRef,
                CustomerAccountNo = createRandomValidateRequestProperties.CustomerAccountNo,
                Inputs = ((List<dynamic>)createRandomValidateRequestProperties.Inputs).Select(inputs =>
                {
                    return new ExternalValidateRequest.Input
                    {
                        Key = inputs.Key,
                        Value = inputs.Value
                    };
                }).ToList(),
            };

            var createBillPayment = new Validate
            {
                Request = new ValidateRequest
                {
                    BillId = createRandomValidateRequestProperties.BillId,
                    ChannelRef = createRandomValidateRequestProperties.ChannelRef,
                    CustomerAccountNo = createRandomValidateRequestProperties.CustomerAccountNo,
                    Inputs = ((List<dynamic>)createRandomValidateRequestProperties.Inputs).Select(inputs =>
                    {
                        return new ValidateRequest.Input
                        {
                            Key = inputs.Key,
                            Value = inputs.Value
                        };
                    }).ToList(),
                },
            };

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
                 broker.PostValidateCustomerAsync(It.IsAny<ExternalValidateRequest>(),inputBillId))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<Validate> retrieveValidateTask =
               this.billPaymentService.PostValidateCustomerRequestAsync(createBillPayment, inputBillId);

            BillPaymentDependencyValidationException actualBillPaymentDependencyValidationException =
                await Assert.ThrowsAsync<BillPaymentDependencyValidationException>(
                    retrieveValidateTask.AsTask);

            // then
            actualBillPaymentDependencyValidationException.Should().BeEquivalentTo(
                expectedBillPaymentDependencyValidationException);

            this.proviPayBrokerMock.Verify(broker =>
                broker.PostValidateCustomerAsync(It.IsAny<ExternalValidateRequest>(),inputBillId),
                    Times.Once);

            this.proviPayBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnValidateRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            var inputBillId = GetRandomString();

                dynamic createRandomValidateRequestProperties =
                 CreateRandomValidateRequestProperties();

            var createBillPaymentRequest = new ExternalValidateRequest
            {
                BillId = createRandomValidateRequestProperties.BillId,
                ChannelRef = createRandomValidateRequestProperties.ChannelRef,
                CustomerAccountNo = createRandomValidateRequestProperties.CustomerAccountNo,
                Inputs = ((List<dynamic>)createRandomValidateRequestProperties.Inputs).Select(inputs =>
                {
                    return new ExternalValidateRequest.Input
                    {
                        Key = inputs.Key,
                        Value = inputs.Value
                    };
                }).ToList(),
            };

            var createBillPayment = new Validate
            {
                Request = new ValidateRequest
                {
                    BillId = createRandomValidateRequestProperties.BillId,
                    ChannelRef = createRandomValidateRequestProperties.ChannelRef,
                    CustomerAccountNo = createRandomValidateRequestProperties.CustomerAccountNo,
                    Inputs = ((List<dynamic>)createRandomValidateRequestProperties.Inputs).Select(inputs =>
                    {
                        return new ValidateRequest.Input
                        {
                            Key = inputs.Key,
                            Value = inputs.Value
                        };
                    }).ToList(),
                },
            };

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
                 broker.PostValidateCustomerAsync(It.IsAny<ExternalValidateRequest>(),inputBillId))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<Validate> retrieveValidateTask =
               this.billPaymentService.PostValidateCustomerRequestAsync(createBillPayment, inputBillId);

            BillPaymentDependencyException actualBillPaymentDependencyException =
                await Assert.ThrowsAsync<BillPaymentDependencyException>(
                    retrieveValidateTask.AsTask);

            // then
            actualBillPaymentDependencyException.Should().BeEquivalentTo(
                expectedBillPaymentDependencyException);

            this.proviPayBrokerMock.Verify(broker =>
                broker.PostValidateCustomerAsync(It.IsAny<ExternalValidateRequest>(),inputBillId),
                    Times.Once);

            this.proviPayBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnValidateRequestIfServiceErrorOccurredAsync()
        {
            // given
            var inputBillId = GetRandomString();

                dynamic createRandomValidateRequestProperties =
                 CreateRandomValidateRequestProperties();

            var createBillPaymentRequest = new ExternalValidateRequest
            {
                    BillId = createRandomValidateRequestProperties.BillId,
                    ChannelRef = createRandomValidateRequestProperties.ChannelRef,
                    CustomerAccountNo = createRandomValidateRequestProperties.CustomerAccountNo,
                    Inputs = ((List<dynamic>)createRandomValidateRequestProperties.Inputs).Select(inputs =>
                    {
                        return new ExternalValidateRequest.Input
                        {
                            Key = inputs.Key,
                            Value = inputs.Value
                        };
                    }).ToList(),
            };

            var createBillPayment = new Validate
            {
                Request = new ValidateRequest
                {
                    BillId = createRandomValidateRequestProperties.BillId,
                    ChannelRef = createRandomValidateRequestProperties.ChannelRef,
                    CustomerAccountNo = createRandomValidateRequestProperties.CustomerAccountNo,
                    Inputs = ((List<dynamic>)createRandomValidateRequestProperties.Inputs).Select(inputs =>
                    {
                        return new ValidateRequest.Input
                        {
                            Key = inputs.Key,
                            Value = inputs.Value
                        };
                    }).ToList(),
                },
            };
            var serviceException = new Exception();

            var failedBillPaymentServiceException =
                new FailedBillPaymentServiceException(serviceException);

            var expectedBillPaymentServiceException =
                new BillPaymentServiceException(failedBillPaymentServiceException);

            this.proviPayBrokerMock.Setup(broker =>
                broker.PostValidateCustomerAsync(It.IsAny<ExternalValidateRequest>(),inputBillId))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<Validate> retrieveValidateTask =
               this.billPaymentService.PostValidateCustomerRequestAsync(createBillPayment, inputBillId);

            BillPaymentServiceException actualBillPaymentServiceException =
                await Assert.ThrowsAsync<BillPaymentServiceException>(
                    retrieveValidateTask.AsTask);

            // then
            actualBillPaymentServiceException.Should().BeEquivalentTo(
                expectedBillPaymentServiceException);

            this.proviPayBrokerMock.Verify(broker =>
                broker.PostValidateCustomerAsync(It.IsAny<ExternalValidateRequest>(),inputBillId),
                    Times.Once);

            this.proviPayBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
