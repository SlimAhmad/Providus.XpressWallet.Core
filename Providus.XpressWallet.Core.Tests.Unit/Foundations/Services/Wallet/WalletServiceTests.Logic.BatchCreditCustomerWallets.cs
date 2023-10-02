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
        public async Task ShouldPostBatchCreditCustomerWalletsWithBatchCreditCustomerWalletsRequestAsync()
        {
            // given 



            dynamic createRandomBatchCreditCustomerWalletsRequestProperties =
              CreateRandomBatchCreditCustomerWalletsRequestProperties();

            dynamic createRandomBatchCreditCustomerWalletsResponseProperties =
                CreateRandomBatchCreditCustomerWalletsResponseProperties();


            var randomExternalBatchCreditCustomerWalletsRequest = new ExternalBatchCreditCustomerWalletsRequest
            {
                BatchReference = createRandomBatchCreditCustomerWalletsRequestProperties.BatchReference,
                Transactions = ((List<dynamic>)createRandomBatchCreditCustomerWalletsRequestProperties.Transactions).Select(transactions =>
                {
                    return new ExternalBatchCreditCustomerWalletsRequest.Transaction
                    {
                        Amount = transactions.Amount,
                        CustomerId = transactions.CustomerId,
                    };

                }).ToList()

            };

            var randomExternalBatchCreditCustomerWalletsResponse = new ExternalBatchCreditCustomerWalletsResponse
            {

                Data = new ExternalBatchCreditCustomerWalletsResponse.ExternalData
                {
                    Accepted = ((List<dynamic>)createRandomBatchCreditCustomerWalletsResponseProperties.Data.Accepted).Select(accpeted =>
                    {
                        return new ExternalBatchCreditCustomerWalletsResponse.Accepted
                        {
                            CustomerId = accpeted.CustomerId,
                            Amount = accpeted.Amount,
                            Reference = accpeted.Reference,
                        };
                    }).ToList(),
                    Rejected = ((List<dynamic>)createRandomBatchCreditCustomerWalletsResponseProperties.Data.Rejected).Select(rejected =>
                    {
                        return new ExternalBatchCreditCustomerWalletsResponse.Rejected
                        {
                            CustomerId = rejected.CustomerId,
                            Amount = rejected.Amount,
                            Reference = rejected.Reference,
                            Reason = rejected.Reason,
                            ReferenceExists = rejected.ReferenceExists,

                        };
                    }).ToList(),
                    BatchReference = createRandomBatchCreditCustomerWalletsResponseProperties.Data.BatchReference
                },
                Message = createRandomBatchCreditCustomerWalletsResponseProperties.Message,
                Status = createRandomBatchCreditCustomerWalletsResponseProperties.Status

            };


            var randomBatchCreditCustomerWalletsRequest = new BatchCreditCustomerWalletsRequest
            {
                BatchReference = createRandomBatchCreditCustomerWalletsRequestProperties.BatchReference,
                Transactions = ((List<dynamic>)createRandomBatchCreditCustomerWalletsRequestProperties.Transactions).Select(transactions =>
                {
                    return new BatchCreditCustomerWalletsRequest.Transaction
                    {
                        Amount = transactions.Amount,
                        CustomerId = transactions.CustomerId,
                    };

                }).ToList()
            };

            var randomBatchCreditCustomerWalletsResponse = new BatchCreditCustomerWalletsResponse
            {
                Data = new BatchCreditCustomerWalletsResponse.DataResponse
                {
                    Accepted = ((List<dynamic>)createRandomBatchCreditCustomerWalletsResponseProperties.Data.Accepted).Select(accpeted =>
                    {
                        return new BatchCreditCustomerWalletsResponse.Accepted
                        {
                            CustomerId = accpeted.CustomerId,
                            Amount = accpeted.Amount,
                            Reference = accpeted.Reference,
                        };
                    }).ToList(),
                    Rejected = ((List<dynamic>)createRandomBatchCreditCustomerWalletsResponseProperties.Data.Rejected).Select(rejected =>
                    {
                        return new BatchCreditCustomerWalletsResponse.Rejected
                        {
                            CustomerId = rejected.CustomerId,
                            Amount = rejected.Amount,
                            Reference = rejected.Reference,
                            Reason = rejected.Reason,
                            ReferenceExists = rejected.ReferenceExists,

                        };
                    }).ToList(),
                    BatchReference = createRandomBatchCreditCustomerWalletsResponseProperties.Data.BatchReference
                },
                Message = createRandomBatchCreditCustomerWalletsResponseProperties.Message,
                Status = createRandomBatchCreditCustomerWalletsResponseProperties.Status
            };


            var randomBatchCreditCustomerWallets = new BatchCreditCustomerWallets
            {
                Request = randomBatchCreditCustomerWalletsRequest,
            };

           

            BatchCreditCustomerWallets inputBatchCreditCustomerWallets = randomBatchCreditCustomerWallets;
            BatchCreditCustomerWallets expectedBatchCreditCustomerWallets = inputBatchCreditCustomerWallets.DeepClone();
            expectedBatchCreditCustomerWallets.Response = randomBatchCreditCustomerWalletsResponse;

            ExternalBatchCreditCustomerWalletsRequest mappedExternalBatchCreditCustomerWalletsRequest =
               randomExternalBatchCreditCustomerWalletsRequest;

            ExternalBatchCreditCustomerWalletsResponse returnedExternalBatchCreditCustomerWalletsResponse =
                randomExternalBatchCreditCustomerWalletsResponse;

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostBatchCreditCustomerWalletsAsync(It.Is(
                      SameExternalBatchCreditCustomerWalletsRequestAs(mappedExternalBatchCreditCustomerWalletsRequest))))
                     .ReturnsAsync(returnedExternalBatchCreditCustomerWalletsResponse);

            // when
            BatchCreditCustomerWallets actualCreateBatchCreditCustomerWallets =
               await this.walletService.PostBatchCreditCustomerWalletsRequestAsync(inputBatchCreditCustomerWallets);

            // then
            actualCreateBatchCreditCustomerWallets.Should().BeEquivalentTo(expectedBatchCreditCustomerWallets);

            this.xPressWalletBrokerMock.Verify(broker =>
               broker.PostBatchCreditCustomerWalletsAsync(It.Is(
                   SameExternalBatchCreditCustomerWalletsRequestAs(mappedExternalBatchCreditCustomerWalletsRequest))),
                   Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
        }
    }
}
