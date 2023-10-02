using FluentAssertions;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalWallet;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Wallet;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.Wallet
{
    public partial class WalletServiceTests
    {
        [Fact]
        public async Task ShouldPostCustomerWalletWithCustomerWalletRequestAsync()
        {
            // given 


            dynamic createRandomCustomerWalletResponseProperties =
                CreateRandomCustomerWalletResponseProperties();



            var randomExternalCustomerWalletResponse = new ExternalCustomerWalletResponse
            {

              Wallet = new ExternalCustomerWalletResponse.ExternalWallet
              {
                  AccountName = createRandomCustomerWalletResponseProperties.Wallet.AccountName,
                  AccountNumber = createRandomCustomerWalletResponseProperties.Wallet.AccountNumber,
                  AccountReference = createRandomCustomerWalletResponseProperties.Wallet.AccountReference,
                  AvailableBalance = createRandomCustomerWalletResponseProperties.Wallet.AvailableBalance,
                  BankCode = createRandomCustomerWalletResponseProperties.Wallet.BankCode,
                  BankName = createRandomCustomerWalletResponseProperties.Wallet.BankName,
                  BookedBalance = createRandomCustomerWalletResponseProperties.Wallet.BookedBalance,
                  CreatedAt = createRandomCustomerWalletResponseProperties.Wallet.CreatedAt,
                  Email = createRandomCustomerWalletResponseProperties.Wallet.Email,
                  FirstName = createRandomCustomerWalletResponseProperties.Wallet.FirstName,
                  Id = createRandomCustomerWalletResponseProperties.Wallet.Id,
                  LastName = createRandomCustomerWalletResponseProperties.Wallet.LastName,
                  Status = createRandomCustomerWalletResponseProperties.Wallet.Status,
                  UpdatedAt = createRandomCustomerWalletResponseProperties.Wallet.UpdatedAt,
                  CustomerId = createRandomCustomerWalletResponseProperties.Wallet.CustomerId
              },
              
              Status = createRandomCustomerWalletResponseProperties.Status
                   
            };


   
            var randomCustomerWalletResponse = new CustomerWalletResponse
            {
                Wallet = new CustomerWalletResponse.WalletResponse
                {
                    AccountName = createRandomCustomerWalletResponseProperties.Wallet.AccountName,
                    AccountNumber = createRandomCustomerWalletResponseProperties.Wallet.AccountNumber,
                    AccountReference = createRandomCustomerWalletResponseProperties.Wallet.AccountReference,
                    AvailableBalance = createRandomCustomerWalletResponseProperties.Wallet.AvailableBalance,
                    BankCode = createRandomCustomerWalletResponseProperties.Wallet.BankCode,
                    BankName = createRandomCustomerWalletResponseProperties.Wallet.BankName,
                    BookedBalance = createRandomCustomerWalletResponseProperties.Wallet.BookedBalance,
                    CreatedAt = createRandomCustomerWalletResponseProperties.Wallet.CreatedAt,
                    Email = createRandomCustomerWalletResponseProperties.Wallet.Email,
                    FirstName = createRandomCustomerWalletResponseProperties.Wallet.FirstName,
                    Id = createRandomCustomerWalletResponseProperties.Wallet.Id,
                    LastName = createRandomCustomerWalletResponseProperties.Wallet.LastName,
                    Status = createRandomCustomerWalletResponseProperties.Wallet.Status,
                    UpdatedAt = createRandomCustomerWalletResponseProperties.Wallet.UpdatedAt,
                    CustomerId = createRandomCustomerWalletResponseProperties.Wallet.CustomerId
                },

                Status = createRandomCustomerWalletResponseProperties.Status

            };



            var expectedResponse = new CustomerWallet
            {
                Response = randomCustomerWalletResponse
            };

            var inputCustomerId = GetRandomString();

            ExternalCustomerWalletResponse returnedExternalCustomerWalletResponse =
                randomExternalCustomerWalletResponse;

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.GetCustomerWalletAsync(It.IsAny<string>()))
                     .ReturnsAsync(returnedExternalCustomerWalletResponse);

            // when
            CustomerWallet actualCreateCustomerWallet =
               await this.walletService.GetCustomerWalletRequestAsync(inputCustomerId);

            // then
            actualCreateCustomerWallet.Should().BeEquivalentTo(expectedResponse);

            this.xPressWalletBrokerMock.Verify(broker =>
               broker.GetCustomerWalletAsync(It.IsAny<string>()),
                   Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
        }
    }
}
