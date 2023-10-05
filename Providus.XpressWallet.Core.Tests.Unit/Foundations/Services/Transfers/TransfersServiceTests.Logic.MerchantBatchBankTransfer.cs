using FluentAssertions;
using Force.DeepCloner;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalTransfers;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalWallet;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transfers;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.Transfers
{
    public partial class TransfersServiceTests
    {
        [Fact]
        public async Task ShouldPostMerchantBatchBankTransferWithMerchantBatchBankTransferRequestAsync()
        {
            // given 



            dynamic createRandomMerchantBatchBankTransferRequestProperties =
              CreateRandomMerchantBatchBankTransferRequestProperties();

            dynamic createRandomMerchantBatchBankTransferResponseProperties =
                CreateRandomMerchantBatchBankTransferResponseProperties();


            var randomExternalMerchantBatchBankTransferRequest = ((List<dynamic>)createRandomMerchantBatchBankTransferRequestProperties).Select(batchTransfer =>
            {
                return new ExternalMerchantBatchBankTransferRequest
                {
                    AccountName = batchTransfer.AccountName,
                    AccountNumber = batchTransfer.AccountNumber,
                    Amount = batchTransfer.Amount,
                    Narration = batchTransfer.Narration,
                    SortCode = batchTransfer.SortCode,
                    Metadata = new ExternalMerchantBatchBankTransferRequest.ExternalMetadata
                    {
                        CustomerData = batchTransfer.Metadata.CustomerData,
                    }
                };
            }).ToList();

            var randomExternalMerchantBatchBankTransferResponse = new ExternalMerchantBatchBankTransferResponse
            {
              
              Data = new ExternalMerchantBatchBankTransferResponse.ExternalData
              {
                 Accepted = ((List<dynamic>)createRandomMerchantBatchBankTransferResponseProperties.Data.Accepted).Select(accepted =>
                 {
                     return new ExternalMerchantBatchBankTransferResponse.Accepted
                     {
                         AccountName = accepted.AccountName,
                         AccountNumber = accepted.AccountNumber,
                         Amount = accepted.Amount,
                         BankName = accepted.BankName,
                         Fee = accepted.Fee,
                         Narration = accepted.Narration,
                         Reference = accepted.Reference,
                         SortCode = accepted.SortCode,
                         Total = accepted.Total,
                         Vat = accepted.Vat,
                         Metadata = new ExternalMerchantBatchBankTransferResponse.Metadata
                         {
                             SessionId = accepted.Metadata.SessionId,
                             TransactionReference = accepted.Metadata.TransactionReference,

                         },

                     };
                 }).ToList(),
                 All = ((List<dynamic>)createRandomMerchantBatchBankTransferResponseProperties.Data.All).Select(all =>
                 {
                     return new ExternalMerchantBatchBankTransferResponse.All
                     {

                         AccountName = all.AccountName,
                         AccountNumber = all.AccountNumber,
                         Amount = all.Amount,
                         Fee = all.Fee,
                         Narration = all.Narration,
                         Reference = all.Reference,
                         SortCode = all.SortCode,
                         Total = all.Total,
                         Vat = all.Vat,


                     };
                 }).ToList(),
                  Rejected = createRandomMerchantBatchBankTransferResponseProperties.Data.Rejected
              },
              Message = createRandomMerchantBatchBankTransferResponseProperties.Message,
              Status = createRandomMerchantBatchBankTransferResponseProperties.Status
                   
            };


            var randomMerchantBatchBankTransferRequest = ((List<dynamic>)createRandomMerchantBatchBankTransferRequestProperties).Select(batchTransfer =>
                {
                    return new MerchantBatchBankTransferRequest
                    {
                        AccountName = batchTransfer.AccountName,
                        AccountNumber = batchTransfer.AccountNumber,
                        Amount = batchTransfer.Amount,
                        Narration = batchTransfer.Narration,
                        SortCode = batchTransfer.SortCode,
                        Metadata = new MerchantBatchBankTransferRequest.MetadataResponse
                        {
                            CustomerData = batchTransfer.Metadata.CustomerData,
                        }
                    };
                }).ToList();

           

            var randomMerchantBatchBankTransferResponse = new MerchantBatchBankTransferResponse
            {
                Data = new MerchantBatchBankTransferResponse.DataResponse
                {
                    Accepted = ((List<dynamic>)createRandomMerchantBatchBankTransferResponseProperties.Data.Accepted).Select(accepted =>
                    {
                        return new MerchantBatchBankTransferResponse.Accepted
                        {
                            AccountName = accepted.AccountName,
                            AccountNumber = accepted.AccountNumber,
                            Amount = accepted.Amount,
                            BankName = accepted.BankName,
                            Fee = accepted.Fee,
                            Narration = accepted.Narration,
                            Reference = accepted.Reference,
                            SortCode = accepted.SortCode,
                            Total = accepted.Total,
                            Vat = accepted.Vat,
                            Metadata = new MerchantBatchBankTransferResponse.Metadata
                            {
                                SessionId = accepted.Metadata.SessionId,
                                TransactionReference = accepted.Metadata.TransactionReference,

                            },

                        };
                    }).ToList(),
                    
                    All = ((List<dynamic>)createRandomMerchantBatchBankTransferResponseProperties.Data.All).Select(all =>
                    {
                        return new MerchantBatchBankTransferResponse.All
                        {

                            AccountName = all.AccountName,
                            AccountNumber = all.AccountNumber,
                            Amount = all.Amount,
                            Fee = all.Fee,
                            Narration = all.Narration,
                            Reference = all.Reference,
                            SortCode = all.SortCode,
                            Total = all.Total,
                            Vat = all.Vat,


                        };
                    }).ToList(),
                    Rejected = createRandomMerchantBatchBankTransferResponseProperties.Data.Rejected
                },
                Message = createRandomMerchantBatchBankTransferResponseProperties.Message,
                Status = createRandomMerchantBatchBankTransferResponseProperties.Status
            };


            var randomMerchantBatchBankTransfer = new MerchantBatchBankTransfer
            {
                Request = randomMerchantBatchBankTransferRequest,
            };

            MerchantBatchBankTransfer inputMerchantBatchBankTransfer = randomMerchantBatchBankTransfer;
            MerchantBatchBankTransfer expectedMerchantBatchBankTransfer = inputMerchantBatchBankTransfer.DeepClone();
            expectedMerchantBatchBankTransfer.Response = randomMerchantBatchBankTransferResponse;

            List<ExternalMerchantBatchBankTransferRequest> mappedExternalMerchantBatchBankTransferRequest =
               randomExternalMerchantBatchBankTransferRequest;

            ExternalMerchantBatchBankTransferResponse returnedExternalMerchantBatchBankTransferResponse =
                randomExternalMerchantBatchBankTransferResponse;

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostMerchantBatchBankTransferAsync(It.Is(
                      SameExternalMerchantBatchBankTransferRequestAs(mappedExternalMerchantBatchBankTransferRequest))))
                     .ReturnsAsync(returnedExternalMerchantBatchBankTransferResponse);

            // when
            MerchantBatchBankTransfer actualCreateMerchantBatchBankTransfer =
               await this.transfersService.PostMerchantBatchBankTransferRequestAsync(inputMerchantBatchBankTransfer);

            // then
            actualCreateMerchantBatchBankTransfer.Should().BeEquivalentTo(expectedMerchantBatchBankTransfer);

            this.xPressWalletBrokerMock.Verify(broker =>
               broker.PostMerchantBatchBankTransferAsync(It.Is(
                   SameExternalMerchantBatchBankTransferRequestAs(mappedExternalMerchantBatchBankTransferRequest))),
                   Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
        }
    }
}
