using FluentAssertions;
using Force.DeepCloner;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalCustomers;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Auth;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Customers;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.Customers
{
    public partial class CustomersServiceTests
    {
        [Fact]
        public async Task ShouldPostFindByPhoneNumberWithFindByPhoneNumberRequestAsync()
        {
            // given 


            dynamic createRandomFindByPhoneNumberResponseProperties =
                CreateRandomFindByPhoneNumberResponseProperties();



            var randomExternalFindByPhoneNumberResponse = new ExternalFindByPhoneNumberResponse
            {

              Customer = new ExternalFindByPhoneNumberResponse.ExternalCustomer
              {
                 FirstName = createRandomFindByPhoneNumberResponseProperties.Customer.FirstName,
                 Id = createRandomFindByPhoneNumberResponseProperties.Customer.Id,
                 LastName = createRandomFindByPhoneNumberResponseProperties.Customer.LastName,
                 WalletId = createRandomFindByPhoneNumberResponseProperties.Customer.WalletId
              },
              Status = createRandomFindByPhoneNumberResponseProperties.Status
                   
            };


   
            var randomFindByPhoneNumberResponse = new FindByPhoneNumberResponse
            {
                Customer = new FindByPhoneNumberResponse.CustomerResponse
                {
                    FirstName = createRandomFindByPhoneNumberResponseProperties.Customer.FirstName,
                    Id = createRandomFindByPhoneNumberResponseProperties.Customer.Id,
                    LastName = createRandomFindByPhoneNumberResponseProperties.Customer.LastName,
                    WalletId = createRandomFindByPhoneNumberResponseProperties.Customer.WalletId
                },
                Status = createRandomFindByPhoneNumberResponseProperties.Status

            };



            var expectedResponse = new FindByPhoneNumber
            {
                Response = randomFindByPhoneNumberResponse
            };

            var inputCustomerId = GetRandomString();

            ExternalFindByPhoneNumberResponse returnedExternalFindByPhoneNumberResponse =
                randomExternalFindByPhoneNumberResponse;

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.GetFindByPhoneNumberAsync(It.IsAny<string>()))
                     .ReturnsAsync(returnedExternalFindByPhoneNumberResponse);

            // when
            FindByPhoneNumber actualCreateFindByPhoneNumber =
               await this.authService.GetFindByPhoneNumberRequestAsync(inputCustomerId);

            // then
            actualCreateFindByPhoneNumber.Should().BeEquivalentTo(expectedResponse);

            this.xPressWalletBrokerMock.Verify(broker =>
               broker.GetFindByPhoneNumberAsync(It.IsAny<string>()),
                   Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
        }
    }
}
