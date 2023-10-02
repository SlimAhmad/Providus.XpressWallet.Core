using FluentAssertions;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalMerchant;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Merchant;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.Merchant
{
    public partial class MerchantServiceTests
    {
        [Fact]
        public async Task ShouldPostMerchantWalletWithMerchantWalletRequestAsync()
        {
            // given 


            dynamic createRandomMerchantWalletResponseProperties =
                CreateRandomMerchantWalletResponseProperties();



            var randomExternalMerchantWalletResponse = new ExternalMerchantWalletResponse
            {

                Data = new ExternalMerchantWalletResponse.ExternalData
                {
                     AccountName = createRandomMerchantWalletResponseProperties.Data.AccountName,
                     AccountNumber = createRandomMerchantWalletResponseProperties.Data.AccountNumber,
                     AccountReference = createRandomMerchantWalletResponseProperties.Data.AccountReference,
                     AvailableBalance = createRandomMerchantWalletResponseProperties.Data.AvailableBalance,
                     BankCode = createRandomMerchantWalletResponseProperties.Data.BankCode,
                     BankName = createRandomMerchantWalletResponseProperties.Data.BankName,
                     BookedBalance = createRandomMerchantWalletResponseProperties.Data.BookedBalance,
                     BusinessName = createRandomMerchantWalletResponseProperties.Data.BusinessName,
                     CreatedAt = createRandomMerchantWalletResponseProperties.Data.CreatedAt,
                     Email = createRandomMerchantWalletResponseProperties.Data.Email,
                     Id = createRandomMerchantWalletResponseProperties.Data.Id,
                     UpdatedAt = createRandomMerchantWalletResponseProperties.Data.UpdatedAt
                },
               
                Status = createRandomMerchantWalletResponseProperties.Status
                   
            };


   
            var randomMerchantWalletResponse = new MerchantWalletResponse
            {
                Data = new MerchantWalletResponse.DataResponse
                {
                    AccountName = createRandomMerchantWalletResponseProperties.Data.AccountName,
                    AccountNumber = createRandomMerchantWalletResponseProperties.Data.AccountNumber,
                    AccountReference = createRandomMerchantWalletResponseProperties.Data.AccountReference,
                    AvailableBalance = createRandomMerchantWalletResponseProperties.Data.AvailableBalance,
                    BankCode = createRandomMerchantWalletResponseProperties.Data.BankCode,
                    BankName = createRandomMerchantWalletResponseProperties.Data.BankName,
                    BookedBalance = createRandomMerchantWalletResponseProperties.Data.BookedBalance,
                    BusinessName = createRandomMerchantWalletResponseProperties.Data.BusinessName,
                    CreatedAt = createRandomMerchantWalletResponseProperties.Data.CreatedAt,
                    Email = createRandomMerchantWalletResponseProperties.Data.Email,
                    Id = createRandomMerchantWalletResponseProperties.Data.Id,
                    UpdatedAt = createRandomMerchantWalletResponseProperties.Data.UpdatedAt
                },
                Status = createRandomMerchantWalletResponseProperties.Status

            };



            var expectedResponse = new MerchantWallet
            {
                Response = randomMerchantWalletResponse
            };

           

            ExternalMerchantWalletResponse returnedExternalMerchantWalletResponse =
                randomExternalMerchantWalletResponse;

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.GetMerchantWalletAsync())
                     .ReturnsAsync(returnedExternalMerchantWalletResponse);

            // when
            MerchantWallet actualCreateMerchantWallet =
               await this.merchantService.GetMerchantWalletRequestAsync();

            // then
            actualCreateMerchantWallet.Should().BeEquivalentTo(expectedResponse);

            this.xPressWalletBrokerMock.Verify(broker =>
               broker.GetMerchantWalletAsync(),
                   Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
        }
    }
}
