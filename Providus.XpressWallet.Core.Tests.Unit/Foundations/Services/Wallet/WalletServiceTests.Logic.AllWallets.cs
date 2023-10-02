using FluentAssertions;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalWallet;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Wallet;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.Wallet
{
    public partial class WalletServiceTests
    {
        [Fact]
        public async Task ShouldRetrieveAllWalletsAsync()
        {
            // given 
           
            dynamic createRandomAllWalletsResponseProperties =
                CreateRandomAllWalletsResponseProperties();

            var randomExternalAllWalletsResponse = new ExternalAllWalletsResponse
            {
                Wallets = ((List<dynamic>)createRandomAllWalletsResponseProperties.Wallet).Select(wallets =>
                {
                    return new ExternalAllWalletsResponse.Wallet
                    {
                        AccountName = wallets.AccountName,
                        AccountNumber = wallets.AccountNumber,
                        AccountReference = wallets.AccountReference,
                        AvailableBalance = wallets.AvailableBalance,
                        BankCode = wallets.BankCode,
                        BankName = wallets.BankName,
                        BookedBalance = wallets.BookedBalance,
                        CreatedAt = wallets.CreatedAt,
                        Email = wallets.Email,
                        FirstName = wallets.FirstName,
                        Id = wallets.Id,
                        LastName = wallets.LastName,
                        Status = wallets.Status,
                        UpdatedAt = wallets.UpdatedAt,

                    };
                }).ToList(),
                Status = createRandomAllWalletsResponseProperties.Status

            };



            var randomAllWalletsResponse = new AllWalletsResponse
            {
                Wallets = ((List<dynamic>)createRandomAllWalletsResponseProperties.Wallet).Select(wallets =>
                {
                    return new AllWalletsResponse.Wallet
                    {
                        AccountName = wallets.AccountName,
                        AccountNumber = wallets.AccountNumber,
                        AccountReference = wallets.AccountReference,
                        AvailableBalance = wallets.AvailableBalance,
                        BankCode = wallets.BankCode,
                        BankName = wallets.BankName,
                        BookedBalance = wallets.BookedBalance,
                        CreatedAt = wallets.CreatedAt,
                        Email = wallets.Email,
                        FirstName = wallets.FirstName,
                        Id = wallets.Id,
                        LastName = wallets.LastName,
                        Status = wallets.Status,
                        UpdatedAt = wallets.UpdatedAt,

                    };
                }).ToList(),
                Status = createRandomAllWalletsResponseProperties.Status
            };



            var expectedResponse = new AllWallets
            {
                Response = randomAllWalletsResponse
            };



            ExternalAllWalletsResponse returnedExternalAllWalletsResponse =
                randomExternalAllWalletsResponse;

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.GetAllWalletsAsync())
                     .ReturnsAsync(returnedExternalAllWalletsResponse);

            // when
            AllWallets actualCreateAllWallets =
               await this.walletService.GetAllWalletsRequestAsync();

            // then
            actualCreateAllWallets.Should().BeEquivalentTo(expectedResponse);

            this.xPressWalletBrokerMock.Verify(broker =>
               broker.GetAllWalletsAsync(),
                   Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
        }
    }
}
