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
                        Reference = transactions.Reference,
                    };

                }).ToList()

            };

            var randomExternalBatchDebitCustomerWalletsResponse = new ExternalBatchDebitCustomerWalletsResponse
            {

                Data = new ExternalBatchDebitCustomerWalletsResponse.DataResponse
                {
                    Results = ((List<dynamic>)createRandomBatchDebitCustomerWalletsResponseProperties.Data.Results).Select(results =>
                    {
                        return new ExternalBatchDebitCustomerWalletsResponse.Result
                        {
                            CustomerId = results.CustomerId,
                            Amount = results.Amount,
                            Reference = results.Reference,
                            Status = results.Status,
                            Reason = results.Reason,

                        };
                    }).ToList(),
                    FailedReferences = createRandomBatchDebitCustomerWalletsResponseProperties.Data.FailedReferences,
                    AllReferences = createRandomBatchDebitCustomerWalletsResponseProperties.Data.AllReferences
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
                        Reference = transactions.Reference,
                    };

                }).ToList()
            };

            var randomBatchDebitCustomerWalletsResponse = new BatchDebitCustomerWalletsResponse
            {
                Data = new BatchDebitCustomerWalletsResponse.DataResponse
                {
                    Results = ((List<dynamic>)createRandomBatchDebitCustomerWalletsResponseProperties.Data.Results).Select(results =>
                    {
                        return new BatchDebitCustomerWalletsResponse.Result
                        {
                            CustomerId = results.CustomerId,
                            Amount = results.Amount,
                            Reference = results.Reference,
                            Status = results.Status,
                            Reason = results.Reason,
                           
                        };
                    }).ToList(),
                    FailedReferences = createRandomBatchDebitCustomerWalletsResponseProperties.Data.FailedReferences,
                    AllReferences = createRandomBatchDebitCustomerWalletsResponseProperties.Data.AllReferences
                },
                Message = createRandomBatchDebitCustomerWalletsResponseProperties.Message,
                Status = createRandomBatchDebitCustomerWalletsResponseProperties.Status,
               
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
