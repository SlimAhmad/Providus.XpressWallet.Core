using FluentAssertions;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalCustomers;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Customers;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Customers.Exceptions;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.Customers
{
    public partial class CustomersServiceTests
    {



        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public async Task ShouldThrowValidationExceptionOnGetCustomerDetailsIfCustomerDetailsIsInvalidAsync(
           string invalidCustomerId)
        {
            // given


            var invalidCustomerDetailsException = new InvalidCustomersException();

            invalidCustomerDetailsException.AddData(
                key: nameof(CustomerDetails),
                values: "Value is required");

;
            var expectedCustomersValidationException =
                new CustomersValidationException(invalidCustomerDetailsException);

            // when
            ValueTask<CustomerDetails> CustomerDetailsTask =
                this.authService.GetCustomerDetailsRequestAsync(invalidCustomerId);

            CustomersValidationException actualCustomersValidationException =
                await Assert.ThrowsAsync<CustomersValidationException>(CustomerDetailsTask.AsTask);

            // then
            actualCustomersValidationException.Should().BeEquivalentTo(
                expectedCustomersValidationException);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnGetCustomerDetailsIfGetCustomerDetailsIsEmptyAsync()
        {
            // given
            var inputPhoneNumber = string.Empty;

            var invalidCustomerDetailsException = new InvalidCustomersException();


            invalidCustomerDetailsException.AddData(
                 key: nameof(CustomerDetails),
                 values: "Value is required");


            var expectedCustomersValidationException =
                new CustomersValidationException(invalidCustomerDetailsException);

            // when
            ValueTask<CustomerDetails> CustomerDetailsTask =
                this.authService.GetCustomerDetailsRequestAsync(inputPhoneNumber);

            CustomersValidationException actualCustomersValidationException =
                await Assert.ThrowsAsync<CustomersValidationException>(
                    CustomerDetailsTask.AsTask);

            // then
            actualCustomersValidationException.Should().BeEquivalentTo(
                expectedCustomersValidationException);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

    }
}