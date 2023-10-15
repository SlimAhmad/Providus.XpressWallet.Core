using FluentAssertions;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalProviPay.ExternalPayment;
using Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.Exceptions;
using Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.Payment;
using RESTFulSense.Exceptions;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.BillPayment
{
    public partial class BillPaymentServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnChargePaymentRequestIfUrlNotFoundAsync()
        {
            // given
            

            dynamic createRandomPaymentRequestProperties =
                 CreateRandomPaymentRequestProperties();

            var createBillPaymentRequest = new ExternalPaymentRequest
            {
                
                 BillId = createRandomPaymentRequestProperties.BillId,
                 ChannelRef = createRandomPaymentRequestProperties.ChannelRef,
                 CustomerAccountNo = createRandomPaymentRequestProperties.CustomerAccountNo,
                 Inputs = ((List<dynamic>)createRandomPaymentRequestProperties.Inputs).Select(inputs =>
                 {
                     return new ExternalPaymentRequest.Input
                     {
                         Key = inputs.Key,
                         Value = inputs.Value
                     };
                 }).ToList()
                 

             
            };

            var createBillPayment = new Payment
            {
                Request = new PaymentRequest
                {
                    BillId = createRandomPaymentRequestProperties.BillId,
                    ChannelRef = createRandomPaymentRequestProperties.ChannelRef,
                    CustomerAccountNo = createRandomPaymentRequestProperties.CustomerAccountNo,
                    Inputs = ((List<dynamic>)createRandomPaymentRequestProperties.Inputs).Select(inputs =>
                    {
                        return new PaymentRequest.Input
                        {
                            Key = inputs.Key,
                            Value = inputs.Value
                        };
                    }).ToList()
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
                broker.PostPaymentAsync(It.IsAny<ExternalPaymentRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<Payment> retrievePaymentTask =
               this.billPaymentService.PostPaymentRequestAsync(createBillPayment );

            BillPaymentDependencyException
                actualBillPaymentDependencyException =
                    await Assert.ThrowsAsync<BillPaymentDependencyException>(
                        retrievePaymentTask.AsTask);

            // then
            actualBillPaymentDependencyException.Should().BeEquivalentTo(
                expectedBillPaymentDependencyException);

            this.proviPayBrokerMock.Verify(broker =>
                broker.PostPaymentAsync(It.IsAny<ExternalPaymentRequest>()),
                    Times.Once);

            this.proviPayBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnPaymentRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            

            dynamic createRandomPaymentRequestProperties =
             CreateRandomPaymentRequestProperties();

            var createBillPaymentRequest = new ExternalPaymentRequest
            {
                BillId = createRandomPaymentRequestProperties.BillId,
                ChannelRef = createRandomPaymentRequestProperties.ChannelRef,
                CustomerAccountNo = createRandomPaymentRequestProperties.CustomerAccountNo,
                Inputs = ((List<dynamic>)createRandomPaymentRequestProperties.Inputs).Select(inputs =>
                {
                    return new ExternalPaymentRequest.Input
                    {
                        Key = inputs.Key,
                        Value = inputs.Value
                    };
                }).ToList()

            };

            var createBillPayment = new Payment
            {
                Request = new PaymentRequest
                {
                    BillId = createRandomPaymentRequestProperties.BillId,
                    ChannelRef = createRandomPaymentRequestProperties.ChannelRef,
                    CustomerAccountNo = createRandomPaymentRequestProperties.CustomerAccountNo,
                    Inputs = ((List<dynamic>)createRandomPaymentRequestProperties.Inputs).Select(inputs =>
                    {
                        return new PaymentRequest.Input
                        {
                            Key = inputs.Key,
                            Value = inputs.Value
                        };
                    }).ToList()
                },
            };


            var unauthorizedBillPaymentException =
                new UnauthorizedBillPaymentException(unauthorizedException);

            var expectedBillPaymentDependencyException =
                new BillPaymentDependencyException(unauthorizedBillPaymentException);

            this.proviPayBrokerMock.Setup(broker =>
                 broker.PostPaymentAsync(It.IsAny<ExternalPaymentRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<Payment> retrievePaymentTask =
               this.billPaymentService.PostPaymentRequestAsync(createBillPayment );

            BillPaymentDependencyException
                actualBillPaymentDependencyException =
                    await Assert.ThrowsAsync<BillPaymentDependencyException>(
                        retrievePaymentTask.AsTask);

            // then
            actualBillPaymentDependencyException.Should().BeEquivalentTo(
                expectedBillPaymentDependencyException);

            this.proviPayBrokerMock.Verify(broker =>
                broker.PostPaymentAsync(It.IsAny<ExternalPaymentRequest>()),
                    Times.Once);

            this.proviPayBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPaymentRequestIfNotFoundOccurredAsync()
        {
            // given
            

                dynamic createRandomPaymentRequestProperties =
                 CreateRandomPaymentRequestProperties();

            var createBillPaymentRequest = new ExternalPaymentRequest
            {
                    BillId = createRandomPaymentRequestProperties.BillId,
                    ChannelRef = createRandomPaymentRequestProperties.ChannelRef,
                    CustomerAccountNo = createRandomPaymentRequestProperties.CustomerAccountNo,
                    Inputs = ((List<dynamic>)createRandomPaymentRequestProperties.Inputs).Select(inputs =>
                    {
                        return new ExternalPaymentRequest.Input
                        {
                            Key = inputs.Key,
                            Value = inputs.Value
                        };
                    }).ToList()
            };

            var createBillPayment = new Payment
            {
                Request = new PaymentRequest
                {
                    BillId = createRandomPaymentRequestProperties.BillId,
                    ChannelRef = createRandomPaymentRequestProperties.ChannelRef,
                    CustomerAccountNo = createRandomPaymentRequestProperties.CustomerAccountNo,
                    Inputs = ((List<dynamic>)createRandomPaymentRequestProperties.Inputs).Select(inputs =>
                    {
                        return new PaymentRequest.Input
                        {
                            Key = inputs.Key,
                            Value = inputs.Value
                        };
                    }).ToList()
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
                broker.PostPaymentAsync(It.IsAny<ExternalPaymentRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<Payment> retrievePaymentTask =
               this.billPaymentService.PostPaymentRequestAsync(createBillPayment );

            BillPaymentDependencyValidationException
                actualBillPaymentDependencyValidationException =
                    await Assert.ThrowsAsync<BillPaymentDependencyValidationException>(
                        retrievePaymentTask.AsTask);

            // then
            actualBillPaymentDependencyValidationException.Should().BeEquivalentTo(
                expectedBillPaymentDependencyValidationException);

            this.proviPayBrokerMock.Verify(broker =>
                broker.PostPaymentAsync(It.IsAny<ExternalPaymentRequest>()),
                    Times.Once);

            this.proviPayBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPaymentRequestIfBadRequestOccurredAsync()
        {
            // given
            

                dynamic createRandomPaymentRequestProperties =
                 CreateRandomPaymentRequestProperties();

            var createBillPaymentRequest = new ExternalPaymentRequest
            {
                BillId = createRandomPaymentRequestProperties.BillId,
                ChannelRef = createRandomPaymentRequestProperties.ChannelRef,
                CustomerAccountNo = createRandomPaymentRequestProperties.CustomerAccountNo,
                Inputs = ((List<dynamic>)createRandomPaymentRequestProperties.Inputs).Select(inputs =>
                {
                    return new ExternalPaymentRequest.Input
                    {
                        Key = inputs.Key,
                        Value = inputs.Value
                    };
                }).ToList()
            };

            var createBillPayment = new Payment
            {
                Request = new PaymentRequest
                {
                    BillId = createRandomPaymentRequestProperties.BillId,
                    ChannelRef = createRandomPaymentRequestProperties.ChannelRef,
                    CustomerAccountNo = createRandomPaymentRequestProperties.CustomerAccountNo,
                    Inputs = ((List<dynamic>)createRandomPaymentRequestProperties.Inputs).Select(inputs =>
                    {
                        return new PaymentRequest.Input
                        {
                            Key = inputs.Key,
                            Value = inputs.Value
                        };
                    }).ToList()
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
                broker.PostPaymentAsync(It.IsAny<ExternalPaymentRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<Payment> retrievePaymentTask =
               this.billPaymentService.PostPaymentRequestAsync(createBillPayment );

            BillPaymentDependencyValidationException
                actualBillPaymentDependencyValidationException =
                    await Assert.ThrowsAsync<BillPaymentDependencyValidationException>(
                        retrievePaymentTask.AsTask);

            // then
            actualBillPaymentDependencyValidationException.Should().BeEquivalentTo(
                expectedBillPaymentDependencyValidationException);

            this.proviPayBrokerMock.Verify(broker =>
                broker.PostPaymentAsync(It.IsAny<ExternalPaymentRequest>()),
                    Times.Once);

            this.proviPayBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPaymentRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            

                dynamic createRandomPaymentRequestProperties =
                 CreateRandomPaymentRequestProperties();

            var createBillPaymentRequest = new ExternalPaymentRequest
            {
                BillId = createRandomPaymentRequestProperties.BillId,
                ChannelRef = createRandomPaymentRequestProperties.ChannelRef,
                CustomerAccountNo = createRandomPaymentRequestProperties.CustomerAccountNo,
                Inputs = ((List<dynamic>)createRandomPaymentRequestProperties.Inputs).Select(inputs =>
                {
                    return new ExternalPaymentRequest.Input
                    {
                        Key = inputs.Key,
                        Value = inputs.Value
                    };
                }).ToList()
            };

            var createBillPayment = new Payment
            {
                Request = new PaymentRequest
                {
                    BillId = createRandomPaymentRequestProperties.BillId,
                    ChannelRef = createRandomPaymentRequestProperties.ChannelRef,
                    CustomerAccountNo = createRandomPaymentRequestProperties.CustomerAccountNo,
                    Inputs = ((List<dynamic>)createRandomPaymentRequestProperties.Inputs).Select(inputs =>
                    {
                        return new PaymentRequest.Input
                        {
                            Key = inputs.Key,
                            Value = inputs.Value
                        };
                    }).ToList()
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
                 broker.PostPaymentAsync(It.IsAny<ExternalPaymentRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<Payment> retrievePaymentTask =
               this.billPaymentService.PostPaymentRequestAsync(createBillPayment );

            BillPaymentDependencyValidationException actualBillPaymentDependencyValidationException =
                await Assert.ThrowsAsync<BillPaymentDependencyValidationException>(
                    retrievePaymentTask.AsTask);

            // then
            actualBillPaymentDependencyValidationException.Should().BeEquivalentTo(
                expectedBillPaymentDependencyValidationException);

            this.proviPayBrokerMock.Verify(broker =>
                broker.PostPaymentAsync(It.IsAny<ExternalPaymentRequest>()),
                    Times.Once);

            this.proviPayBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPaymentRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            

                dynamic createRandomPaymentRequestProperties =
                 CreateRandomPaymentRequestProperties();

            var createBillPaymentRequest = new ExternalPaymentRequest
            {
                BillId = createRandomPaymentRequestProperties.BillId,
                ChannelRef = createRandomPaymentRequestProperties.ChannelRef,
                CustomerAccountNo = createRandomPaymentRequestProperties.CustomerAccountNo,
                Inputs = ((List<dynamic>)createRandomPaymentRequestProperties.Inputs).Select(inputs =>
                {
                    return new ExternalPaymentRequest.Input
                    {
                        Key = inputs.Key,
                        Value = inputs.Value
                    };
                }).ToList()
            };

            var createBillPayment = new Payment
            {
                Request = new PaymentRequest
                {
                    BillId = createRandomPaymentRequestProperties.BillId,
                    ChannelRef = createRandomPaymentRequestProperties.ChannelRef,
                    CustomerAccountNo = createRandomPaymentRequestProperties.CustomerAccountNo,
                    Inputs = ((List<dynamic>)createRandomPaymentRequestProperties.Inputs).Select(inputs =>
                    {
                        return new PaymentRequest.Input
                        {
                            Key = inputs.Key,
                            Value = inputs.Value
                        };
                    }).ToList()
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
                 broker.PostPaymentAsync(It.IsAny<ExternalPaymentRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<Payment> retrievePaymentTask =
               this.billPaymentService.PostPaymentRequestAsync(createBillPayment );

            BillPaymentDependencyException actualBillPaymentDependencyException =
                await Assert.ThrowsAsync<BillPaymentDependencyException>(
                    retrievePaymentTask.AsTask);

            // then
            actualBillPaymentDependencyException.Should().BeEquivalentTo(
                expectedBillPaymentDependencyException);

            this.proviPayBrokerMock.Verify(broker =>
                broker.PostPaymentAsync(It.IsAny<ExternalPaymentRequest>()),
                    Times.Once);

            this.proviPayBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnPaymentRequestIfServiceErrorOccurredAsync()
        {
            // given
            

                dynamic createRandomPaymentRequestProperties =
                 CreateRandomPaymentRequestProperties();

            var createBillPaymentRequest = new ExternalPaymentRequest
            {
                    BillId = createRandomPaymentRequestProperties.BillId,
                    ChannelRef = createRandomPaymentRequestProperties.ChannelRef,
                    CustomerAccountNo = createRandomPaymentRequestProperties.CustomerAccountNo,
                    Inputs = ((List<dynamic>)createRandomPaymentRequestProperties.Inputs).Select(inputs =>
                    {
                        return new ExternalPaymentRequest.Input
                        {
                            Key = inputs.Key,
                            Value = inputs.Value
                        };
                    }).ToList()
            };

            var createBillPayment = new Payment
            {
                Request = new PaymentRequest
                {
                    BillId = createRandomPaymentRequestProperties.BillId,
                    ChannelRef = createRandomPaymentRequestProperties.ChannelRef,
                    CustomerAccountNo = createRandomPaymentRequestProperties.CustomerAccountNo,
                    Inputs = ((List<dynamic>)createRandomPaymentRequestProperties.Inputs).Select(inputs =>
                    {
                        return new PaymentRequest.Input
                        {
                            Key = inputs.Key,
                            Value = inputs.Value
                        };
                    }).ToList()
                },
            };
            var serviceException = new Exception();

            var failedBillPaymentServiceException =
                new FailedBillPaymentServiceException(serviceException);

            var expectedBillPaymentServiceException =
                new BillPaymentServiceException(failedBillPaymentServiceException);

            this.proviPayBrokerMock.Setup(broker =>
                broker.PostPaymentAsync(It.IsAny<ExternalPaymentRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<Payment> retrievePaymentTask =
               this.billPaymentService.PostPaymentRequestAsync(createBillPayment );

            BillPaymentServiceException actualBillPaymentServiceException =
                await Assert.ThrowsAsync<BillPaymentServiceException>(
                    retrievePaymentTask.AsTask);

            // then
            actualBillPaymentServiceException.Should().BeEquivalentTo(
                expectedBillPaymentServiceException);

            this.proviPayBrokerMock.Verify(broker =>
                broker.PostPaymentAsync(It.IsAny<ExternalPaymentRequest>()),
                    Times.Once);

            this.proviPayBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
