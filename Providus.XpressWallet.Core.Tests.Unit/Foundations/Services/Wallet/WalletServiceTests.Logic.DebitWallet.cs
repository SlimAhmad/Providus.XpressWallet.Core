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
        public async Task ShouldPostDebitWalletWithDebitWalletRequestAsync()
        {
            // given 



            dynamic createRandomDebitWalletRequestProperties =
              CreateRandomDebitWalletRequestProperties();

            dynamic createRandomDebitWalletResponseProperties =
                CreateRandomDebitWalletResponseProperties();


            var randomExternalDebitWalletRequest = new ExternalDebitWalletRequest
            {
                Metadata = new ExternalDebitWalletRequest.ExternalMetadata
                {
                    MoreData = createRandomDebitWalletRequestProperties.Metadata.MoreData,
                    SomeData = createRandomDebitWalletRequestProperties.Metadata.SomeData
                },
                Amount = createRandomDebitWalletRequestProperties.Amount,
                CustomerId = createRandomDebitWalletRequestProperties.CustomerId,
                Reference = createRandomDebitWalletRequestProperties.Reference,

            };

            var randomExternalDebitWalletResponse = new ExternalDebitWalletResponse
            {

                Data = new ExternalDebitWalletResponse.ExternalData
                {
                  Reference = createRandomDebitWalletResponseProperties.Data.Reference,
                  Amount = createRandomDebitWalletResponseProperties.Data.Amount,
                  CustomerId = createRandomDebitWalletResponseProperties.Data.CustomerId,
                  CustomerWalletId = createRandomDebitWalletResponseProperties.Data.CustomerWalletId,
                  TransactionFee = createRandomDebitWalletResponseProperties.Data.TransactionFee,
                  Metadata = new ExternalDebitWalletResponse.Metadata
                  {
                     MoreData = createRandomDebitWalletResponseProperties.Data.Metadata.MoreData,
                     SomeData = createRandomDebitWalletResponseProperties.Data.Metadata.SomeData
                     
                  }
                },
                Message = createRandomDebitWalletResponseProperties.Message,
                Status = createRandomDebitWalletResponseProperties.Status

            };


            var randomDebitWalletRequest = new DebitWalletRequest
            {
                Metadata = new DebitWalletRequest.MetadataResponse
                {
                    MoreData = createRandomDebitWalletRequestProperties.Metadata.MoreData,
                    SomeData = createRandomDebitWalletRequestProperties.Metadata.SomeData
                },
                Amount = createRandomDebitWalletRequestProperties.Amount,
                CustomerId = createRandomDebitWalletRequestProperties.CustomerId,
                Reference = createRandomDebitWalletRequestProperties.Reference,
            };

            var randomDebitWalletResponse = new DebitWalletResponse
            {
                Data = new DebitWalletResponse.DataResponse
                {
                    Reference = createRandomDebitWalletResponseProperties.Data.Reference,
                    Amount = createRandomDebitWalletResponseProperties.Data.Amount,
                    CustomerId = createRandomDebitWalletResponseProperties.Data.CustomerId,
                    CustomerWalletId = createRandomDebitWalletResponseProperties.Data.CustomerWalletId,
                    TransactionFee = createRandomDebitWalletResponseProperties.Data.TransactionFee,
                    Metadata = new DebitWalletResponse.Metadata
                    {
                        MoreData = createRandomDebitWalletResponseProperties.Data.Metadata.MoreData,
                        SomeData = createRandomDebitWalletResponseProperties.Data.Metadata.SomeData

                    }
                },
                Message = createRandomDebitWalletResponseProperties.Message,
                Status = createRandomDebitWalletResponseProperties.Status
            };


            var randomDebitWallet = new DebitWallet
            {
                Request = randomDebitWalletRequest,
            };

           

            DebitWallet inputDebitWallet = randomDebitWallet;
            DebitWallet expectedDebitWallet = inputDebitWallet.DeepClone();
            expectedDebitWallet.Response = randomDebitWalletResponse;

            ExternalDebitWalletRequest mappedExternalDebitWalletRequest =
               randomExternalDebitWalletRequest;

            ExternalDebitWalletResponse returnedExternalDebitWalletResponse =
                randomExternalDebitWalletResponse;

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostDebitWalletAsync(It.Is(
                      SameExternalDebitWalletRequestAs(mappedExternalDebitWalletRequest))))
                     .ReturnsAsync(returnedExternalDebitWalletResponse);

            // when
            DebitWallet actualCreateDebitWallet =
               await this.walletService.PostDebitWalletRequestAsync(inputDebitWallet);

            // then
            actualCreateDebitWallet.Should().BeEquivalentTo(expectedDebitWallet);

            this.xPressWalletBrokerMock.Verify(broker =>
               broker.PostDebitWalletAsync(It.Is(
                   SameExternalDebitWalletRequestAs(mappedExternalDebitWalletRequest))),
                   Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
        }
    }
}
