using FluentAssertions;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalCustomers;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Customers;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Customers.Exceptions;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.Customers
{
    public partial class CustomersServiceTests
    {

        [Fact]
        public async Task ShouldThrowValidationExceptionOnUpdateCustomerProfileIfUpdateCustomerProfileIsNullAsync()
        {
            // given
            UpdateCustomerProfile nullUpdateCustomerProfile = null;
            var nullUpdateCustomerProfileException = new NullCustomersException();

            var inputCustomerId = GetRandomString();

            var exceptedCustomersValidationException =
                new CustomersValidationException(nullUpdateCustomerProfileException);

            // when
            ValueTask<UpdateCustomerProfile> UpdateCustomerProfileTask =
                this.authService.UpdateCustomerProfileRequestAsync(nullUpdateCustomerProfile,inputCustomerId);

            CustomersValidationException actualCustomersValidationException =
                await Assert.ThrowsAsync<CustomersValidationException>(
                    UpdateCustomerProfileTask.AsTask);

            // then
            actualCustomersValidationException.Should()
                .BeEquivalentTo(exceptedCustomersValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.UpdateCustomerProfileAsync(
                    It.IsAny<ExternalUpdateCustomerProfileRequest>(),It.IsAny<string>()),
                        Times.Never);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnUpdateCustomerProfileIfRequestIsNullAsync()
        {
            // given
            var invalidUpdateCustomerProfile = new UpdateCustomerProfile();
            invalidUpdateCustomerProfile.Request = null;
            var inputCustomerId = GetRandomString();

            var invalidUpdateCustomerProfileException =
                new InvalidCustomersException();

            invalidUpdateCustomerProfileException.AddData(
                key: nameof(UpdateCustomerProfileRequest),
                values: "Value is required");

            var expectedCustomersValidationException =
                new CustomersValidationException(
                    invalidUpdateCustomerProfileException);

            // when
            ValueTask<UpdateCustomerProfile> UpdateCustomerProfileTask =
                this.authService.UpdateCustomerProfileRequestAsync(invalidUpdateCustomerProfile,inputCustomerId);

            CustomersValidationException actualCustomersValidationException =
                await Assert.ThrowsAsync<CustomersValidationException>(
                    UpdateCustomerProfileTask.AsTask);

            // then
            actualCustomersValidationException.Should()
                .BeEquivalentTo(expectedCustomersValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.UpdateCustomerProfileAsync(
                    It.IsAny<ExternalUpdateCustomerProfileRequest>(),It.IsAny<string>()),
                        Times.Never);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null, null,null,null,null,null)]
        [InlineData("", "","","","","")]
        [InlineData("  ", "  "," "," "," "," ")]
        public async Task ShouldThrowValidationExceptionOnPostUpdateCustomerProfileIfUpdateCustomerProfileIsInvalidAsync(
           string invalidLastName, string invalidAddress,string invalidFirstName, 
           string invalidPhoneNumber, string invalidOthers, string invalidCustomerId)
        {
            // given
            var updateCustomerProfile = new UpdateCustomerProfile
            {
                Request = new UpdateCustomerProfileRequest
                {
                      
                   LastName = invalidLastName,
                   Address = invalidAddress,
                   FirstName = invalidFirstName,
                   PhoneNumber = invalidPhoneNumber,
                   Metadata = new UpdateCustomerProfileRequest.MetadataResponse
                   {
                        Others= invalidOthers
                   }

                    

                }
            };

            var invalidUpdateCustomerProfileException = new InvalidCustomersException();

          

            invalidUpdateCustomerProfileException.AddData(
                    key: nameof(UpdateCustomerProfileRequest.Address),
                    values: "Value is required");

            invalidUpdateCustomerProfileException.AddData(
                key: nameof(UpdateCustomerProfileRequest.LastName),
                values: "Value is required");

            invalidUpdateCustomerProfileException.AddData(
               key: nameof(UpdateCustomerProfileRequest.FirstName),
               values: "Value is required");

            invalidUpdateCustomerProfileException.AddData(
              key: nameof(UpdateCustomerProfileRequest),
              values: "Value is required");

            invalidUpdateCustomerProfileException.AddData(
              key: nameof(UpdateCustomerProfileRequest.PhoneNumber),
              values: "Value is required");



            var expectedCustomersValidationException =
                new CustomersValidationException(invalidUpdateCustomerProfileException);

            // when
            ValueTask<UpdateCustomerProfile> UpdateCustomerProfileTask =
                this.authService.UpdateCustomerProfileRequestAsync(updateCustomerProfile,invalidCustomerId);

            CustomersValidationException actualCustomersValidationException =
                await Assert.ThrowsAsync<CustomersValidationException>(UpdateCustomerProfileTask.AsTask);

            // then
            actualCustomersValidationException.Should().BeEquivalentTo(
                expectedCustomersValidationException);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostUpdateCustomerProfileIfPostUpdateCustomerProfileIsEmptyAsync()
        {
            // given
            var updateCustomerProfile = new UpdateCustomerProfile
            {
                Request = new UpdateCustomerProfileRequest
                {

                    LastName = string.Empty,
                    Address = string.Empty,
                    FirstName = string.Empty,
                    PhoneNumber = string.Empty,
                    Metadata = new UpdateCustomerProfileRequest.MetadataResponse
                    {
                        Others = string.Empty,
                    }


                }
            };
            var customerId = string.Empty;

            var invalidUpdateCustomerProfileException = new InvalidCustomersException();


            invalidUpdateCustomerProfileException.AddData(
                       key: nameof(UpdateCustomerProfileRequest.Address),
                       values: "Value is required");

            invalidUpdateCustomerProfileException.AddData(
                key: nameof(UpdateCustomerProfileRequest.LastName),
                values: "Value is required");

            invalidUpdateCustomerProfileException.AddData(
               key: nameof(UpdateCustomerProfileRequest.FirstName),
               values: "Value is required");
            invalidUpdateCustomerProfileException.AddData(
              key: nameof(UpdateCustomerProfileRequest),
              values: "Value is required");
            invalidUpdateCustomerProfileException.AddData(
              key: nameof(UpdateCustomerProfileRequest.PhoneNumber),
              values: "Value is required");





            var expectedCustomersValidationException =
                new CustomersValidationException(invalidUpdateCustomerProfileException);

            // when
            ValueTask<UpdateCustomerProfile> UpdateCustomerProfileTask =
                this.authService.UpdateCustomerProfileRequestAsync(updateCustomerProfile,customerId);

            CustomersValidationException actualCustomersValidationException =
                await Assert.ThrowsAsync<CustomersValidationException>(
                    UpdateCustomerProfileTask.AsTask);

            // then
            actualCustomersValidationException.Should().BeEquivalentTo(
                expectedCustomersValidationException);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

    }
}