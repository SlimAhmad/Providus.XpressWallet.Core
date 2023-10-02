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
        public async Task ShouldPostBatchDebitCustomerWalletsWithBatchDebitCustomerWalletsRequestAsync()
        {
            // given 



            dynamic createRandomBatchDebitCustomerWalletsRequestProperties =
              CreateRandomBatchDebitCustomerWalletsRequestProperties();

            dynamic createRandomBatchDebitCustomerWalletsResponseProperties =
                CreateRandomBatchDebitCustomerWalletsResponseProperties();


            var randomExternalBatchDebitCustomerWalletsRequest = new ExternalBatchDebitCustomerWalletsRequest
            {
                BatchReference = createRandomBatchDebitCustomerWalletsRequestProperties.BatchReference,
                Transactions = ((List<dynamic>)createRandomBatchDebitCustomerWalletsRequestProperties.Transactions).Select(transactions =>
                {
                    return new ExternalBatchDebitCustomerWalletsRequest.Transaction
                    {
                        Amount = transactions.Amount,
                        CustomerId = transactions.CustomerId,
                    };

                }).ToList()

            };

            var randomExternalBatchDebitCustomerWalletsResponse = new ExternalBatchDebitCustomerWalletsResponse
            {

                Data = new ExternalBatchDebitCustomerWalletsResponse.ExternalData
                {
                    Accepted = ((List<dynamic>)createRandomBatchDebitCustomerWalletsResponseProperties.Data.Accepted).Select(accpeted =>
                    {
                        return new ExternalBatchDebitCustomerWalletsResponse.Accepted
                        {
                            CustomerId = accpeted.CustomerId,
                            Amount = accpeted.Amount,
                            Reference = accpeted.Reference,
                        };
                    }).ToList(),
                    Rejected = createRandomBatchDebitCustomerWalletsResponseProperties.Data.Rejected,
                    BatchReference = createRandomBatchDebitCustomerWalletsResponseProperties.Data.BatchReference
                },
                Message = createRandomBatchDebitCustomerWalletsResponseProperties.Message,
                Status = createRandomBatchDebitCustomerWalletsResponseProperties.Status

            };


            var randomBatchDebitCustomerWalletsRequest = new BatchDebitCustomerWalletsRequest
            {
                BatchReference = createRandomBatchDebitCustomerWalletsRequestProperties.BatchReference,
                Transactions = ((List<dynamic>)createRandomBatchDebitCustomerWalletsRequestProperties.Transactions).Select(transactions =>
                {
                    return new BatchDebitCustomerWalletsRequest.Transaction
                    {
                        Amount = transactions.Amount,
                        CustomerId = transactions.CustomerId,
                    };

                }).ToList()
            };

            var randomBatchDebitCustomerWalletsResponse = new BatchDebitCustomerWalletsResponse
            {
                Data = new BatchDebitCustomerWalletsResponse.DataResponse
                {
                    Accepted = ((List<dynamic>)createRandomBatchDebitCustomerWalletsResponseProperties.Data.Accepted).Select(accpeted =>
                    {
                        return new BatchDebitCustomerWalletsResponse.Accepted
                        {
                            CustomerId = accpeted.CustomerId,
                            Amount = accpeted.Amount,
                            Reference = accpeted.Reference,
                        };
                    }).ToList(),
                    Rejected = createRandomBatchDebitCustomerWalletsResponseProperties.Data.Rejected,
                    BatchReference = createRandomBatchDebitCustomerWalletsResponseProperties.Data.BatchReference
                },
                Message = createRandomBatchDebitCustomerWalletsResponseProperties.Message,
                Status = createRandomBatchDebitCustomerWalletsResponseProperties.Status
            };


            var randomBatchDebitCustomerWallets = new BatchDebitCustomerWallets
            {
                Request = randomBatchDebitCustomerWalletsRequest,
            };

           

            BatchDebitCustomerWallets inputBatchDebitCustomerWallets = randomBatchDebitCustomerWallets;
            BatchDebitCustomerWallets expectedBatchDebitCustomerWallets = inputBatchDebitCustomerWallets.DeepClone();
            expectedBatchDebitCustomerWallets.Response = randomBatchDebitCustomerWalletsResponse;

            ExternalBatchDebitCustomerWalletsRequest mappedExternalBatchDebitCustomerWalletsRequest =
               randomExternalBatchDebitCustomerWalletsRequest;

            ExternalBatchDebitCustomerWalletsResponse returnedExternalBatchDebitCustomerWalletsResponse =
                randomExternalBatchDebitCustomerWalletsResponse;

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostBatchDebitCustomerWalletsAsync(It.Is(
                      SameExternalBatchDebitCustomerWalletsRequestAs(mappedExternalBatchDebitCustomerWalletsRequest))))
                     .ReturnsAsync(returnedExternalBatchDebitCustomerWalletsResponse);

            // when
            BatchDebitCustomerWallets actualCreateBatchDebitCustomerWallets =
               await this.walletService.PostBatchDebitCustomerWalletsRequestAsync(inputBatchDebitCustomerWallets);

            // then
            actualCreateBatchDebitCustomerWallets.Should().BeEquivalentTo(expectedBatchDebitCustomerWallets);

            this.xPressWalletBrokerMock.Verify(broker =>
               broker.PostBatchDebitCustomerWalletsAsync(It.Is(
                   SameExternalBatchDebitCustomerWalletsRequestAs(mappedExternalBatchDebitCustomerWalletsRequest))),
                   Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
        }
    }
}
