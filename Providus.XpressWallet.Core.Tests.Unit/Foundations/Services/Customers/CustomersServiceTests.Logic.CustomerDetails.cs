using FluentAssertions;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalCustomers;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Customers;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.Customers
{
    public partial class CustomersServiceTests
    {
        [Fact]
        public async Task ShouldPostCustomerDetailsWithCustomerDetailsRequestAsync()
        {
            // given 


            dynamic createRandomCustomerDetailsResponseProperties =
                CreateRandomCustomerDetailsResponseProperties();



            var randomExternalCustomerDetailsResponse = new ExternalCustomerDetailsResponse
            {

              Customer = new ExternalCustomerDetailsResponse.ExternalCustomer
              {
                 FirstName = createRandomCustomerDetailsResponseProperties.Customer.FirstName,
                 Id = createRandomCustomerDetailsResponseProperties.Customer.Id,
                 LastName = createRandomCustomerDetailsResponseProperties.Customer.LastName,
                 WalletId = createRandomCustomerDetailsResponseProperties.Customer.WalletId,
                 Bvn = createRandomCustomerDetailsResponseProperties.Customer.Bvn,
                 BVNFirstName = createRandomCustomerDetailsResponseProperties.Customer.BVNFirstName,
                 BVNLastName = createRandomCustomerDetailsResponseProperties.Customer.BVNLastName,
                 CreatedAt = createRandomCustomerDetailsResponseProperties.Customer.CreatedAt,
                 DateOfBirth = createRandomCustomerDetailsResponseProperties.Customer.DateOfBirth,
                 Email = createRandomCustomerDetailsResponseProperties.Customer.Email,
                 NameMatch = createRandomCustomerDetailsResponseProperties.Customer.NameMatch,
                 PhoneNumber = createRandomCustomerDetailsResponseProperties.Customer.PhoneNumber,
                 UpdatedAt = createRandomCustomerDetailsResponseProperties.Customer.UpdatedAt,
                 
              },
              
              Status = createRandomCustomerDetailsResponseProperties.Status
                   
            };


   
            var randomCustomerDetailsResponse = new CustomerDetailsResponse
            {
                Customer = new CustomerDetailsResponse.CustomerResponse
                {
                    FirstName = createRandomCustomerDetailsResponseProperties.Customer.FirstName,
                    Id = createRandomCustomerDetailsResponseProperties.Customer.Id,
                    LastName = createRandomCustomerDetailsResponseProperties.Customer.LastName,
                    WalletId = createRandomCustomerDetailsResponseProperties.Customer.WalletId,
                    Bvn = createRandomCustomerDetailsResponseProperties.Customer.Bvn,
                    BVNFirstName = createRandomCustomerDetailsResponseProperties.Customer.BVNFirstName,
                    BVNLastName = createRandomCustomerDetailsResponseProperties.Customer.BVNLastName,
                    CreatedAt = createRandomCustomerDetailsResponseProperties.Customer.CreatedAt,
                    DateOfBirth = createRandomCustomerDetailsResponseProperties.Customer.DateOfBirth,
                    Email = createRandomCustomerDetailsResponseProperties.Customer.Email,
                    NameMatch = createRandomCustomerDetailsResponseProperties.Customer.NameMatch,
                    PhoneNumber = createRandomCustomerDetailsResponseProperties.Customer.PhoneNumber,
                    UpdatedAt = createRandomCustomerDetailsResponseProperties.Customer.UpdatedAt,
                },
                Status = createRandomCustomerDetailsResponseProperties.Status

            };



            var expectedResponse = new CustomerDetails
            {
                Response = randomCustomerDetailsResponse
            };

            var inputCustomerId = GetRandomString();

            ExternalCustomerDetailsResponse returnedExternalCustomerDetailsResponse =
                randomExternalCustomerDetailsResponse;

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.GetCustomerDetailsAsync(It.IsAny<string>()))
                     .ReturnsAsync(returnedExternalCustomerDetailsResponse);

            // when
            CustomerDetails actualCreateCustomerDetails =
               await this.authService.GetCustomerDetailsRequestAsync(inputCustomerId);

            // then
            actualCreateCustomerDetails.Should().BeEquivalentTo(expectedResponse);

            this.xPressWalletBrokerMock.Verify(broker =>
               broker.GetCustomerDetailsAsync(It.IsAny<string>()),
                   Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
        }
    }
}
