using FluentAssertions;
using Force.DeepCloner;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalWallet;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Wallet;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.Wallet
{
    public partial class WalletServiceTests
    {
        [Fact]
        public async Task ShouldPostFundMerchantSandBoxWalletWithFundMerchantSandBoxWalletRequestAsync()
        {
            // given 



            dynamic createRandomFundMerchantSandBoxWalletRequestProperties =
              CreateRandomFundMerchantSandBoxWalletRequestProperties();

            dynamic createRandomFundMerchantSandBoxWalletResponseProperties =
                CreateRandomFundMerchantSandBoxWalletResponseProperties();


            var randomExternalFundMerchantSandBoxWalletRequest = new ExternalFundMerchantSandBoxWalletRequest
            {
               Amount = createRandomFundMerchantSandBoxWalletRequestProperties.Amount,

            };

            var randomExternalFundMerchantSandBoxWalletResponse = new ExternalFundMerchantSandBoxWalletResponse
            {

               
                Message = createRandomFundMerchantSandBoxWalletResponseProperties.Message,
                Status = createRandomFundMerchantSandBoxWalletResponseProperties.Status

            };


            var randomFundMerchantSandBoxWalletRequest = new FundMerchantSandBoxWalletRequest
            {
                Amount = createRandomFundMerchantSandBoxWalletRequestProperties.Amount,
            };

            var randomFundMerchantSandBoxWalletResponse = new FundMerchantSandBoxWalletResponse
            {

                Message = createRandomFundMerchantSandBoxWalletResponseProperties.Message,
                Status = createRandomFundMerchantSandBoxWalletResponseProperties.Status
            };


            var randomFundMerchantSandBoxWallet = new FundMerchantSandBoxWallet
            {
                Request = randomFundMerchantSandBoxWalletRequest,
            };

           

            FundMerchantSandBoxWallet inputFundMerchantSandBoxWallet = randomFundMerchantSandBoxWallet;
            FundMerchantSandBoxWallet expectedFundMerchantSandBoxWallet = inputFundMerchantSandBoxWallet.DeepClone();
            expectedFundMerchantSandBoxWallet.Response = randomFundMerchantSandBoxWalletResponse;

            ExternalFundMerchantSandBoxWalletRequest mappedExternalFundMerchantSandBoxWalletRequest =
               randomExternalFundMerchantSandBoxWalletRequest;

            ExternalFundMerchantSandBoxWalletResponse returnedExternalFundMerchantSandBoxWalletResponse =
                randomExternalFundMerchantSandBoxWalletResponse;

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostFundMerchantSandBoxWalletAsync(It.Is(
                      SameExternalFundMerchantSandBoxWalletRequestAs(mappedExternalFundMerchantSandBoxWalletRequest))))
                     .ReturnsAsync(returnedExternalFundMerchantSandBoxWalletResponse);

            // when
            FundMerchantSandBoxWallet actualCreateFundMerchantSandBoxWallet =
               await this.walletService.PostFundMerchantSandBoxWalletRequestAsync(inputFundMerchantSandBoxWallet);

            // then
            actualCreateFundMerchantSandBoxWallet.Should().BeEquivalentTo(expectedFundMerchantSandBoxWallet);

            this.xPressWalletBrokerMock.Verify(broker =>
               broker.PostFundMerchantSandBoxWalletAsync(It.Is(
                   SameExternalFundMerchantSandBoxWalletRequestAs(mappedExternalFundMerchantSandBoxWalletRequest))),
                   Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
        }
    }
}
