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
        public async Task ShouldPostCreditWalletWithCreditWalletRequestAsync()
        {
            // given 



            dynamic createRandomCreditWalletRequestProperties =
              CreateRandomCreditWalletRequestProperties();

            dynamic createRandomCreditWalletResponseProperties =
                CreateRandomCreditWalletResponseProperties();


            var randomExternalCreditWalletRequest = new ExternalCreditWalletRequest
            {
                Metadata = new ExternalCreditWalletRequest.ExternalMetadata
                {
                    MoreData = createRandomCreditWalletRequestProperties.Metadata.MoreData,
                    SomeData = createRandomCreditWalletRequestProperties.Metadata.SomeData
                },
                Amount = createRandomCreditWalletRequestProperties.Amount,
                CustomerId = createRandomCreditWalletRequestProperties.CustomerId,
                Reference = createRandomCreditWalletRequestProperties.Reference,

            };

            var randomExternalCreditWalletResponse = new ExternalCreditWalletResponse
            {

                Reference = createRandomCreditWalletResponseProperties.Reference,
                Amount = createRandomCreditWalletResponseProperties.Amount,
                Message = createRandomCreditWalletResponseProperties.Message,
                Status = createRandomCreditWalletResponseProperties.Status

            };


            var randomCreditWalletRequest = new CreditWalletRequest
            {
                Metadata = new CreditWalletRequest.MetadataResponse
                {
                    MoreData = createRandomCreditWalletRequestProperties.Metadata.MoreData,
                    SomeData = createRandomCreditWalletRequestProperties.Metadata.SomeData
                },
                Amount = createRandomCreditWalletRequestProperties.Amount,
                CustomerId = createRandomCreditWalletRequestProperties.CustomerId,
                Reference = createRandomCreditWalletRequestProperties.Reference,
            };

            var randomCreditWalletResponse = new CreditWalletResponse
            {
                Reference = createRandomCreditWalletResponseProperties.Reference,
                Amount = createRandomCreditWalletResponseProperties.Amount,
                Message = createRandomCreditWalletResponseProperties.Message,
                Status = createRandomCreditWalletResponseProperties.Status
            };


            var randomCreditWallet = new CreditWallet
            {
                Request = randomCreditWalletRequest,
            };

           

            CreditWallet inputCreditWallet = randomCreditWallet;
            CreditWallet expectedCreditWallet = inputCreditWallet.DeepClone();
            expectedCreditWallet.Response = randomCreditWalletResponse;

            ExternalCreditWalletRequest mappedExternalCreditWalletRequest =
               randomExternalCreditWalletRequest;

            ExternalCreditWalletResponse returnedExternalCreditWalletResponse =
                randomExternalCreditWalletResponse;

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostCreditWalletAsync(It.Is(
                      SameExternalCreditWalletRequestAs(mappedExternalCreditWalletRequest))))
                     .ReturnsAsync(returnedExternalCreditWalletResponse);

            // when
            CreditWallet actualCreateCreditWallet =
               await this.walletService.PostCreditWalletRequestAsync(inputCreditWallet);

            // then
            actualCreateCreditWallet.Should().BeEquivalentTo(expectedCreditWallet);

            this.xPressWalletBrokerMock.Verify(broker =>
               broker.PostCreditWalletAsync(It.Is(
                   SameExternalCreditWalletRequestAs(mappedExternalCreditWalletRequest))),
                   Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
        }
    }
}
