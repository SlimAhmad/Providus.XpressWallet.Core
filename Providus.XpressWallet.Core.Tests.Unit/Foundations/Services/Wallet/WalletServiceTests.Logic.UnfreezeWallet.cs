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
        public async Task ShouldPostUnfreezeWalletWithUnfreezeWalletRequestAsync()
        {
            // given 



            dynamic createRandomUnfreezeWalletRequestProperties =
              CreateRandomUnfreezeWalletRequestProperties();

            dynamic createRandomUnfreezeWalletResponseProperties =
                CreateRandomUnfreezeWalletResponseProperties();


            var randomExternalUnfreezeWalletRequest = new ExternalUnfreezeWalletRequest
            {
                CustomerId = createRandomUnfreezeWalletRequestProperties.CustomerId,

            };

            var randomExternalUnfreezeWalletResponse = new ExternalUnfreezeWalletResponse
            {

                
                Message = createRandomUnfreezeWalletResponseProperties.Message,
                Status = createRandomUnfreezeWalletResponseProperties.Status

            };


            var randomUnfreezeWalletRequest = new UnfreezeWalletRequest
            {
                CustomerId = createRandomUnfreezeWalletRequestProperties.CustomerId,
            };

            var randomUnfreezeWalletResponse = new UnfreezeWalletResponse
            {
                
                Message = createRandomUnfreezeWalletResponseProperties.Message,
                Status = createRandomUnfreezeWalletResponseProperties.Status
            };


            var randomUnfreezeWallet = new UnfreezeWallet
            {
                Request = randomUnfreezeWalletRequest,
            };

           

            UnfreezeWallet inputUnfreezeWallet = randomUnfreezeWallet;
            UnfreezeWallet expectedUnfreezeWallet = inputUnfreezeWallet.DeepClone();
            expectedUnfreezeWallet.Response = randomUnfreezeWalletResponse;

            ExternalUnfreezeWalletRequest mappedExternalUnfreezeWalletRequest =
               randomExternalUnfreezeWalletRequest;

            ExternalUnfreezeWalletResponse returnedExternalUnfreezeWalletResponse =
                randomExternalUnfreezeWalletResponse;

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostUnfreezeWalletAsync(It.Is(
                      SameExternalUnfreezeWalletRequestAs(mappedExternalUnfreezeWalletRequest))))
                     .ReturnsAsync(returnedExternalUnfreezeWalletResponse);

            // when
            UnfreezeWallet actualCreateUnfreezeWallet =
               await this.walletService.PostUnfreezeWalletRequestAsync(inputUnfreezeWallet);

            // then
            actualCreateUnfreezeWallet.Should().BeEquivalentTo(expectedUnfreezeWallet);

            this.xPressWalletBrokerMock.Verify(broker =>
               broker.PostUnfreezeWalletAsync(It.Is(
                   SameExternalUnfreezeWalletRequestAs(mappedExternalUnfreezeWalletRequest))),
                   Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
        }
    }
}
