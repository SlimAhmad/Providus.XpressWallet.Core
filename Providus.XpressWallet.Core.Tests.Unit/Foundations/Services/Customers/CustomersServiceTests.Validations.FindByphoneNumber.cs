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
        public async Task ShouldThrowValidationExceptionOnGetFindByPhoneNumberIfFindByPhoneNumberIsInvalidAsync(
           string invalidCustomerId)
        {
            // given


            var invalidFindByPhoneNumberException = new InvalidCustomersException();

            invalidFindByPhoneNumberException.AddData(
                key: nameof(FindByPhoneNumber),
                values: "Value is required");

;
            var expectedCustomersValidationException =
                new CustomersValidationException(invalidFindByPhoneNumberException);

            // when
            ValueTask<FindByPhoneNumber> FindByPhoneNumberTask =
                this.authService.GetFindByPhoneNumberRequestAsync(invalidCustomerId);

            CustomersValidationException actualCustomersValidationException =
                await Assert.ThrowsAsync<CustomersValidationException>(FindByPhoneNumberTask.AsTask);

            // then
            actualCustomersValidationException.Should().BeEquivalentTo(
                expectedCustomersValidationException);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnGetFindByPhoneNumberIfGetFindByPhoneNumberIsEmptyAsync()
        {
            // given
            var inputPhoneNumber = string.Empty;

            var invalidFindByPhoneNumberException = new InvalidCustomersException();


            invalidFindByPhoneNumberException.AddData(
                 key: nameof(FindByPhoneNumber),
                 values: "Value is required");


            var expectedCustomersValidationException =
                new CustomersValidationException(invalidFindByPhoneNumberException);

            // when
            ValueTask<FindByPhoneNumber> FindByPhoneNumberTask =
                this.authService.GetFindByPhoneNumberRequestAsync(inputPhoneNumber);

            CustomersValidationException actualCustomersValidationException =
                await Assert.ThrowsAsync<CustomersValidationException>(
                    FindByPhoneNumberTask.AsTask);

            // then
            actualCustomersValidationException.Should().BeEquivalentTo(
                expectedCustomersValidationException);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

    }
}