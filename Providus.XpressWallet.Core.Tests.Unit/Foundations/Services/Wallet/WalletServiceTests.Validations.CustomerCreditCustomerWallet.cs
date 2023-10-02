using FluentAssertions;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalWallet;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Wallet;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Wallet.Exceptions;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.Wallet
{
    public partial class WalletServiceTests
    {

        [Fact]
        public async Task ShouldThrowValidationExceptionOnCustomerCreditCustomerWalletIfCustomerCreditCustomerWalletIsNullAsync()
        {
            // given
            CustomerCreditCustomerWallet nullCustomerCreditCustomerWallet = null;
            var nullCustomerCreditCustomerWalletException = new NullWalletException();

        

            var exceptedWalletValidationException =
                new WalletValidationException(nullCustomerCreditCustomerWalletException);

            // when
            ValueTask<CustomerCreditCustomerWallet> CustomerCreditCustomerWalletTask =
                this.walletService.PostCustomerCreditCustomerWalletRequestAsync(nullCustomerCreditCustomerWallet);

            WalletValidationException actualWalletValidationException =
                await Assert.ThrowsAsync<WalletValidationException>(
                    CustomerCreditCustomerWalletTask.AsTask);

            // then
            actualWalletValidationException.Should()
                .BeEquivalentTo(exceptedWalletValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostCustomerCreditCustomerWalletAsync(
                    It.IsAny<ExternalCustomerCreditCustomerWalletRequest>()),
                        Times.Never);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnCustomerCreditCustomerWalletIfRequestIsNullAsync()
        {
            // given
            var invalidCustomerCreditCustomerWallet = new CustomerCreditCustomerWallet();
            invalidCustomerCreditCustomerWallet.Request = null;
        

            var invalidCustomerCreditCustomerWalletException =
                new InvalidWalletException();

            invalidCustomerCreditCustomerWalletException.AddData(
                key: nameof(CustomerCreditCustomerWalletRequest),
                values: "Value is required");

            var expectedWalletValidationException =
                new WalletValidationException(
                    invalidCustomerCreditCustomerWalletException);

            // when
            ValueTask<CustomerCreditCustomerWallet> CustomerCreditCustomerWalletTask =
                this.walletService.PostCustomerCreditCustomerWalletRequestAsync(invalidCustomerCreditCustomerWallet);

            WalletValidationException actualWalletValidationException =
                await Assert.ThrowsAsync<WalletValidationException>(
                    CustomerCreditCustomerWalletTask.AsTask);

            // then
            actualWalletValidationException.Should()
                .BeEquivalentTo(expectedWalletValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostCustomerCreditCustomerWalletAsync(
                    It.IsAny<ExternalCustomerCreditCustomerWalletRequest>()),
                        Times.Never);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null,null)]
        [InlineData("","")]
        [InlineData("  "," ")]
        public async Task ShouldThrowValidationExceptionOnPostCustomerCreditCustomerWalletIfCustomerCreditCustomerWalletIsInvalidAsync(
           string invalidCustomerId, string invalidBatchReference)
        {
            // given
            var accountVerificationRequest = new CustomerCreditCustomerWallet
            {
                Request = new CustomerCreditCustomerWalletRequest
                {

                      CustomerId = invalidCustomerId,
                      BatchReference = invalidBatchReference
                       
                }
            };

            var invalidCustomerCreditCustomerWalletException = new InvalidWalletException();

          

            invalidCustomerCreditCustomerWalletException.AddData(
                    key: nameof(CustomerCreditCustomerWalletRequest.CustomerId),
                    values: "Value is required");


            invalidCustomerCreditCustomerWalletException.AddData(
                key: nameof(CustomerCreditCustomerWalletRequest.BatchReference),
                values: "Value is required");

            invalidCustomerCreditCustomerWalletException.AddData(
                    key: nameof(CustomerCreditCustomerWalletRequest.Recipients),
                    values: "Value is required");


           


            var expectedWalletValidationException =
                new WalletValidationException(invalidCustomerCreditCustomerWalletException);

            // when
            ValueTask<CustomerCreditCustomerWallet> CustomerCreditCustomerWalletTask =
                this.walletService.PostCustomerCreditCustomerWalletRequestAsync(accountVerificationRequest);

            WalletValidationException actualWalletValidationException =
                await Assert.ThrowsAsync<WalletValidationException>(CustomerCreditCustomerWalletTask.AsTask);

            // then
            actualWalletValidationException.Should().BeEquivalentTo(
                expectedWalletValidationException);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostCustomerCreditCustomerWalletIfPostCustomerCreditCustomerWalletIsEmptyAsync()
        {
            // given
            var accountVerificationRequest = new CustomerCreditCustomerWallet
            {
                Request = new CustomerCreditCustomerWalletRequest
                {

                   CustomerId = string.Empty,
                   BatchReference = string.Empty,
                  

                }
            };
            

            var invalidCustomerCreditCustomerWalletException = new InvalidWalletException();


            invalidCustomerCreditCustomerWalletException.AddData(
                   key: nameof(CustomerCreditCustomerWalletRequest.BatchReference),
                   values: "Value is required");


            invalidCustomerCreditCustomerWalletException.AddData(
                key: nameof(CustomerCreditCustomerWalletRequest.Recipients),
                values: "Value is required");



            invalidCustomerCreditCustomerWalletException.AddData(
                key: nameof(CustomerCreditCustomerWalletRequest.CustomerId),
                values: "Value is required");





            var expectedWalletValidationException =
                new WalletValidationException(invalidCustomerCreditCustomerWalletException);

            // when
            ValueTask<CustomerCreditCustomerWallet> CustomerCreditCustomerWalletTask =
                this.walletService.PostCustomerCreditCustomerWalletRequestAsync(accountVerificationRequest);

            WalletValidationException actualWalletValidationException =
                await Assert.ThrowsAsync<WalletValidationException>(
                    CustomerCreditCustomerWalletTask.AsTask);

            // then
            actualWalletValidationException.Should().BeEquivalentTo(
                expectedWalletValidationException);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

    }
}