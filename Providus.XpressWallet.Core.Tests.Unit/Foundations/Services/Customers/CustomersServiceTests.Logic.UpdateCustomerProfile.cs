using FluentAssertions;
using Force.DeepCloner;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalCustomers;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Customers;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.Customers
{
    public partial class CustomersServiceTests
    {
        [Fact]
        public async Task ShouldPostUpdateCustomerProfileWithUpdateCustomerProfileRequestAsync()
        {
            // given 



            dynamic createRandomUpdateCustomerProfileRequestProperties =
              CreateRandomUpdateCustomerProfileRequestProperties();

            dynamic createRandomUpdateCustomerProfileResponseProperties =
                CreateRandomUpdateCustomerProfileResponseProperties();


            var randomExternalUpdateCustomerProfileRequest = new ExternalUpdateCustomerProfileRequest
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

            var randomExternalUpdateCustomerProfileResponse = new ExternalUpdateCustomerProfileResponse
            {

              Customer = new ExternalUpdateCustomerProfileResponse.ExternalCustomer
              {
                   DateOfBirth = createRandomUpdateCustomerProfileResponseProperties.Customer.DateOfBirth,
                   Email = createRandomUpdateCustomerProfileResponseProperties.Customer.Email,
                   FirstName = createRandomUpdateCustomerProfileResponseProperties.Customer.FirstName,
                   LastName = createRandomUpdateCustomerProfileResponseProperties.Customer.LastName,
                   PhoneNumber = createRandomUpdateCustomerProfileResponseProperties.Customer.PhoneNumber
              },
              Status = createRandomUpdateCustomerProfileResponseProperties.Status
                   
            };


            var randomUpdateCustomerProfileRequest = new UpdateCustomerProfileRequest
            {
                Address = createRandomUpdateCustomerProfileRequestProperties.Address,
                FirstName = createRandomUpdateCustomerProfileRequestProperties.FirstName,
                LastName = createRandomUpdateCustomerProfileRequestProperties.LastName,
                Metadata = new UpdateCustomerProfileRequest.MetadataResponse
                {
                    Others = createRandomUpdateCustomerProfileRequestProperties.Metadata.Others
                },
                PhoneNumber = createRandomUpdateCustomerProfileRequestProperties.PhoneNumber,

            };

            var randomUpdateCustomerProfileResponse = new UpdateCustomerProfileResponse
            {
                Customer = new UpdateCustomerProfileResponse.CustomerResponse
                {
                    DateOfBirth = createRandomUpdateCustomerProfileResponseProperties.Customer.DateOfBirth,
                    Email = createRandomUpdateCustomerProfileResponseProperties.Customer.Email,
                    FirstName = createRandomUpdateCustomerProfileResponseProperties.Customer.FirstName,
                    LastName = createRandomUpdateCustomerProfileResponseProperties.Customer.LastName,
                    PhoneNumber = createRandomUpdateCustomerProfileResponseProperties.Customer.PhoneNumber
                },
                Status = createRandomUpdateCustomerProfileResponseProperties.Status
            };


            var randomUpdateCustomerProfile = new UpdateCustomerProfile
            {
                Request = randomUpdateCustomerProfileRequest,
            };

            var inputCustomerId = GetRandomString();

            UpdateCustomerProfile inputUpdateCustomerProfile = randomUpdateCustomerProfile;
            UpdateCustomerProfile expectedUpdateCustomerProfile = inputUpdateCustomerProfile.DeepClone();
            expectedUpdateCustomerProfile.Response = randomUpdateCustomerProfileResponse;

            ExternalUpdateCustomerProfileRequest mappedExternalUpdateCustomerProfileRequest =
               randomExternalUpdateCustomerProfileRequest;

            ExternalUpdateCustomerProfileResponse returnedExternalUpdateCustomerProfileResponse =
                randomExternalUpdateCustomerProfileResponse;

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.UpdateCustomerProfileAsync(It.Is(
                      SameExternalUpdateCustomerProfileRequestAs(mappedExternalUpdateCustomerProfileRequest)),inputCustomerId))
                     .ReturnsAsync(returnedExternalUpdateCustomerProfileResponse);

            // when
            UpdateCustomerProfile actualCreateUpdateCustomerProfile =
               await this.authService.UpdateCustomerProfileRequestAsync(inputUpdateCustomerProfile,inputCustomerId);

            // then
            actualCreateUpdateCustomerProfile.Should().BeEquivalentTo(expectedUpdateCustomerProfile);

            this.xPressWalletBrokerMock.Verify(broker =>
               broker.UpdateCustomerProfileAsync(It.Is(
                   SameExternalUpdateCustomerProfileRequestAs(mappedExternalUpdateCustomerProfileRequest)), inputCustomerId),
                   Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
        }
    }
}
