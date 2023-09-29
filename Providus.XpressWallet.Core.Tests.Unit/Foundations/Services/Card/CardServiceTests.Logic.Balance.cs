using FluentAssertions;
using Force.DeepCloner;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalCard;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Auth;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Card;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.Card
{
    public partial class CardServiceTests
    {
        [Fact]
        public async Task ShouldPostBalanceWithBalanceRequestAsync()
        {
            // given 


            dynamic createRandomBalanceResponseProperties =
                CreateRandomBalanceResponseProperties();



            var randomExternalBalanceResponse = new ExternalBalanceResponse
            {

              Data = new ExternalBalanceResponse.ExternalData
              {
                  AvailableBalance = createRandomBalanceResponseProperties.Data.AvailableBalance,
                  CardNotPresentLimit = createRandomBalanceResponseProperties.Data.CardNotPresentLimit,
                  CashLimit = createRandomBalanceResponseProperties.Data.CashLimit,
                  CashNrTransLimit = createRandomBalanceResponseProperties.Data.CashNrTransLimit,
                  CreatedAt = createRandomBalanceResponseProperties.Data.CreatedAt,
                  DeletedAt = createRandomBalanceResponseProperties.Data.DeletedAt,
                  DepositCreditLimit = createRandomBalanceResponseProperties.Data.DepositCreditLimit,
                  GoodsLimit = createRandomBalanceResponseProperties.Data.GoodsLimit,
                  GoodsNrTransLimit = createRandomBalanceResponseProperties.Data.GoodsNrTransLimit,
                  Id = createRandomBalanceResponseProperties.Data.Id,
                  LedgerBalance = createRandomBalanceResponseProperties.Data.LedgerBalance,
                  PaymentLimit = createRandomBalanceResponseProperties.Data.PaymentLimit,
                  PaymentNrTransLimit = createRandomBalanceResponseProperties.Data.PaymentNrTransLimit,
                  UpdatedAt = createRandomBalanceResponseProperties.Data.UpdatedAt,
                   
              },
              Status = createRandomBalanceResponseProperties.Status
                   
            };


   
            var randomBalanceResponse = new BalanceResponse
            {
                Data = new BalanceResponse.DataResponse
                {
                    AvailableBalance = createRandomBalanceResponseProperties.Data.AvailableBalance,
                    CardNotPresentLimit = createRandomBalanceResponseProperties.Data.CardNotPresentLimit,
                    CashLimit = createRandomBalanceResponseProperties.Data.CashLimit,
                    CashNrTransLimit = createRandomBalanceResponseProperties.Data.CashNrTransLimit,
                    CreatedAt = createRandomBalanceResponseProperties.Data.CreatedAt,
                    DeletedAt = createRandomBalanceResponseProperties.Data.DeletedAt,
                    DepositCreditLimit = createRandomBalanceResponseProperties.Data.DepositCreditLimit,
                    GoodsLimit = createRandomBalanceResponseProperties.Data.GoodsLimit,
                    GoodsNrTransLimit = createRandomBalanceResponseProperties.Data.GoodsNrTransLimit,
                    Id = createRandomBalanceResponseProperties.Data.Id,
                    LedgerBalance = createRandomBalanceResponseProperties.Data.LedgerBalance,
                    PaymentLimit = createRandomBalanceResponseProperties.Data.PaymentLimit,
                    PaymentNrTransLimit = createRandomBalanceResponseProperties.Data.PaymentNrTransLimit,
                    UpdatedAt = createRandomBalanceResponseProperties.Data.UpdatedAt,

                },
                Status = createRandomBalanceResponseProperties.Status
            };



            var expectedResponse = new Balance
            {
                Response = randomBalanceResponse
            };

            var inputCustomerId = GetRandomString();

            ExternalBalanceResponse returnedExternalBalanceResponse =
                randomExternalBalanceResponse;

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.GetBalanceAsync(It.IsAny<string>()))
                     .ReturnsAsync(returnedExternalBalanceResponse);

            // when
            Balance actualCreateBalance =
               await this.authService.GetBalanceRequestAsync(inputCustomerId);

            // then
            actualCreateBalance.Should().BeEquivalentTo(expectedResponse);

            this.xPressWalletBrokerMock.Verify(broker =>
               broker.GetBalanceAsync(It.IsAny<string>()),
                   Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
        }
    }
}
