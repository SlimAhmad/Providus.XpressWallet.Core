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
        public async Task ShouldPostFreezeWalletWithFreezeWalletRequestAsync()
        {
            // given 



            dynamic createRandomFreezeWalletRequestProperties =
              CreateRandomFreezeWalletRequestProperties();

            dynamic createRandomFreezeWalletResponseProperties =
                CreateRandomFreezeWalletResponseProperties();


            var randomExternalFreezeWalletRequest = new ExternalFreezeWalletRequest
            {
                
                CustomerId = createRandomFreezeWalletRequestProperties.CustomerId,


            };

            var randomExternalFreezeWalletResponse = new ExternalFreezeWalletResponse
            {

                 
                Message = createRandomFreezeWalletResponseProperties.Message,
                Status = createRandomFreezeWalletResponseProperties.Status

            };


            var randomFreezeWalletRequest = new FreezeWalletRequest
            {
                CustomerId = createRandomFreezeWalletRequestProperties.CustomerId,
            };

            var randomFreezeWalletResponse = new FreezeWalletResponse
            {
            
                Message = createRandomFreezeWalletResponseProperties.Message,
                Status = createRandomFreezeWalletResponseProperties.Status
            };


            var randomFreezeWallet = new FreezeWallet
            {
                Request = randomFreezeWalletRequest,
            };

           

            FreezeWallet inputFreezeWallet = randomFreezeWallet;
            FreezeWallet expectedFreezeWallet = inputFreezeWallet.DeepClone();
            expectedFreezeWallet.Response = randomFreezeWalletResponse;

            ExternalFreezeWalletRequest mappedExternalFreezeWalletRequest =
               randomExternalFreezeWalletRequest;

            ExternalFreezeWalletResponse returnedExternalFreezeWalletResponse =
                randomExternalFreezeWalletResponse;

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostFreezeWalletAsync(It.Is(
                      SameExternalFreezeWalletRequestAs(mappedExternalFreezeWalletRequest))))
                     .ReturnsAsync(returnedExternalFreezeWalletResponse);

            // when
            FreezeWallet actualCreateFreezeWallet =
               await this.walletService.PostFreezeWalletRequestAsync(inputFreezeWallet);

            // then
            actualCreateFreezeWallet.Should().BeEquivalentTo(expectedFreezeWallet);

            this.xPressWalletBrokerMock.Verify(broker =>
               broker.PostFreezeWalletAsync(It.Is(
                   SameExternalFreezeWalletRequestAs(mappedExternalFreezeWalletRequest))),
                   Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
        }
    }
}
