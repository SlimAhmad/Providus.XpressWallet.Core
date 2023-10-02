using FluentAssertions;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalTransfers;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transfers;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.Transfers
{
    public partial class TransfersServiceTests
    {
        [Fact]
        public async Task ShouldPostBankAccountDetailsWithBankAccountDetailsRequestAsync()
        {
            // given 
            var inputSortCode = GetRandomString();
            var inputAccountNumber = GetRandomString();

            dynamic createRandomBankAccountDetailsResponseProperties =
                CreateRandomBankAccountDetailsResponseProperties();



            var randomExternalBankAccountDetailsResponse = new ExternalBankAccountDetailsResponse
            {
                    
                Account = new ExternalBankAccountDetailsResponse.ExternalAccount
                {
                  AccountName = createRandomBankAccountDetailsResponseProperties.Account.AccountName,
                  AccountNumber = createRandomBankAccountDetailsResponseProperties.Account.AccountNumber,
                  BankCode = createRandomBankAccountDetailsResponseProperties.Account.BankCode
                },
                Status = createRandomBankAccountDetailsResponseProperties.Status
                   
            };


   
            var randomBankAccountDetailsResponse = new BankAccountDetailsResponse
            {
                Account = new BankAccountDetailsResponse.AccountResponse
                {
                    AccountName = createRandomBankAccountDetailsResponseProperties.Account.AccountName,
                    AccountNumber = createRandomBankAccountDetailsResponseProperties.Account.AccountNumber,
                    BankCode = createRandomBankAccountDetailsResponseProperties.Account.BankCode
                },
                Status = createRandomBankAccountDetailsResponseProperties.Status

            };



            var expectedResponse = new BankAccountDetails
            {
                Response = randomBankAccountDetailsResponse
            };

           

            ExternalBankAccountDetailsResponse returnedExternalBankAccountDetailsResponse =
                randomExternalBankAccountDetailsResponse;

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.GetBankAccountDetailsAsync(inputSortCode, inputAccountNumber))
                     .ReturnsAsync(returnedExternalBankAccountDetailsResponse);

            // when
            BankAccountDetails actualCreateBankAccountDetails =
               await this.transfersService.GetBankAccountDetailsRequestAsync(inputSortCode, inputAccountNumber);

            // then
            actualCreateBankAccountDetails.Should().BeEquivalentTo(expectedResponse);

            this.xPressWalletBrokerMock.Verify(broker =>
               broker.GetBankAccountDetailsAsync(inputSortCode, inputAccountNumber),
                   Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
        }
    }
}
