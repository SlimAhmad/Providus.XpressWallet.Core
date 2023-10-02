using FluentAssertions;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalTransfers;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transfers;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.Transfers
{
    public partial class TransfersServiceTests
    {
        [Fact]
        public async Task ShouldPostBankListWithBankListRequestAsync()
        {
            // given 
           

            dynamic createRandomBankListResponseProperties =
                CreateRandomBankListResponseProperties();



            var randomExternalBankListResponse = new ExternalBankListResponse
            {
                    
                Banks = ((List<dynamic>)createRandomBankListResponseProperties.Banks).Select(banks =>
                {
                    return new ExternalBankListResponse.Bank
                    {
                        Code = banks.Code,
                        Name = banks.Name,
                    };
                }).ToList(),
                Status = createRandomBankListResponseProperties.Status
                   
            };


   
            var randomBankListResponse = new BankListResponse
            {
                Banks = ((List<dynamic>)createRandomBankListResponseProperties.Banks).Select(banks =>
                {
                    return new BankListResponse.Bank
                    {
                        Code = banks.Code,
                        Name = banks.Name,
                    };
                }).ToList(),
                Status = createRandomBankListResponseProperties.Status


            };



            var expectedResponse = new BankList
            {
                Response = randomBankListResponse
            };

           

            ExternalBankListResponse returnedExternalBankListResponse =
                randomExternalBankListResponse;

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.GetBankListAsync())
                     .ReturnsAsync(returnedExternalBankListResponse);

            // when
            BankList actualCreateBankList =
               await this.transfersService.GetBankListRequestAsync();

            // then
            actualCreateBankList.Should().BeEquivalentTo(expectedResponse);

            this.xPressWalletBrokerMock.Verify(broker =>
               broker.GetBankListAsync(),
                   Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
        }
    }
}
