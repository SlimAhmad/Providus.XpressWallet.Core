using Providus.XpressWallet.Core.Brokers.DateTimes;
using Providus.XpressWallet.Core.Brokers.XpressWallet;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalTransfers;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transfers;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Providus.XpressWallet.Core.Services.Foundations.XpressWallet.Transfers
{
    internal partial class TransfersService : ITransfersService
    {
        private readonly IXpressWalletBroker xPressWalletBroker;
        private readonly IDateTimeBroker dateTimeBroker;

        public TransfersService(
            IXpressWalletBroker xPressWalletBroker,
            IDateTimeBroker dateTimeBroker)
        {
            this.xPressWalletBroker = xPressWalletBroker;
            this.dateTimeBroker = dateTimeBroker;
        }



        public ValueTask<BankList> GetBankListRequestAsync() =>
        TryCatch(async () =>
        {

            ExternalBankListResponse externalBankListResponse =
                await xPressWalletBroker.GetBankListAsync();
            return ConvertToTransfersResponse(externalBankListResponse);
        });


        public ValueTask<BankAccountDetails> GetBankAccountDetailsRequestAsync(
            string sortCode, string accountNumber)=>
        TryCatch(async () =>
        {
            ValidateBankAccountDetailsParameters(sortCode);
            ValidateBankAccountDetailsParameters(accountNumber);
            ExternalBankAccountDetailsResponse externalBankAccountDetailsResponse = 
                await xPressWalletBroker.GetBankAccountDetailsAsync(sortCode,accountNumber);
            return ConvertToTransfersResponse(externalBankAccountDetailsResponse);
        });


        public ValueTask<MerchantBankTransfer> PostMerchantBankTransferRequestAsync(
            MerchantBankTransfer externalMerchantBankTransfer)=>
        TryCatch(async () =>
        {
            ValidateMerchantBankTransfer(externalMerchantBankTransfer);
            ExternalMerchantBankTransferRequest externalMerchantBankTransferRequest = ConvertToTransfersRequest(externalMerchantBankTransfer);
            ExternalMerchantBankTransferResponse externalMerchantBankTransferResponse = 
                await xPressWalletBroker.PostMerchantBankTransferAsync(externalMerchantBankTransferRequest);
            return ConvertToTransfersResponse(externalMerchantBankTransfer, externalMerchantBankTransferResponse);
        });


        public ValueTask<CustomerBankTransfer> PostCustomerBankTransferRequestAsync(
            CustomerBankTransfer externalCustomerBankTransfer)=>
        TryCatch(async () =>
        {
            ValidateCustomerBankTransfer(externalCustomerBankTransfer);
            ExternalCustomerBankTransferRequest externalCustomerBankTransferRequest = ConvertToTransfersRequest(externalCustomerBankTransfer);
            ExternalCustomerBankTransferResponse externalCustomerBankTransferResponse = await xPressWalletBroker.PostCustomerBankTransferAsync(externalCustomerBankTransferRequest);
            return ConvertToTransfersResponse(externalCustomerBankTransfer, externalCustomerBankTransferResponse);
        });


        public ValueTask<MerchantBatchBankTransfer> PostMerchantBatchBankTransferRequestAsync(
            MerchantBatchBankTransfer externalMerchantBatchBankTransfer)=>
        TryCatch(async () =>
        {
            ValidateMerchantBatchBankTransfer(externalMerchantBatchBankTransfer);
            List<ExternalMerchantBatchBankTransferRequest> externalMerchantBatchBankTransferRequest = ConvertToTransfersRequest(externalMerchantBatchBankTransfer);
            ExternalMerchantBatchBankTransferResponse externalMerchantBatchBankTransferResponse = await xPressWalletBroker.PostMerchantBatchBankTransferAsync(externalMerchantBatchBankTransferRequest);
            return ConvertToTransfersResponse(externalMerchantBatchBankTransfer, externalMerchantBatchBankTransferResponse);
        });


        public ValueTask<CustomerToCustomerWalletTransfer> PostCustomerToCustomerWalletTransferRequestAsync(
            CustomerToCustomerWalletTransfer externalCustomerToCustomerWalletTransfer)=>
        TryCatch(async () =>
        {
            ValidateCustomerToCustomerWalletTransfer(externalCustomerToCustomerWalletTransfer);
            ExternalCustomerToCustomerWalletTransferRequest externalCustomerToCustomerWalletTransferRequest =
                ConvertToTransfersRequest(externalCustomerToCustomerWalletTransfer);
            ExternalCustomerToCustomerWalletTransferResponse externalCustomerToCustomerWalletTransferResponse =
                await xPressWalletBroker.PostCustomerToCustomerWalletTransferAsync(externalCustomerToCustomerWalletTransferRequest);
            return ConvertToTransfersResponse(externalCustomerToCustomerWalletTransfer, externalCustomerToCustomerWalletTransferResponse);
        });





        private static ExternalMerchantBankTransferRequest ConvertToTransfersRequest(
            MerchantBankTransfer merchantBankTransfer)
        {

            return new ExternalMerchantBankTransferRequest
            {
               AccountName = merchantBankTransfer.Request.AccountName,
               Metadata = new ExternalMerchantBankTransferRequest.ExternalMetadata
               {
                  CustomerData = merchantBankTransfer.Request.Metadata.CustomerData
               },
               AccountNumber = merchantBankTransfer.Request.AccountNumber,
               Amount = merchantBankTransfer.Request.Amount,
               Narration = merchantBankTransfer.Request.Narration,
               SortCode = merchantBankTransfer.Request.SortCode,
            };



        }
        private static ExternalCustomerBankTransferRequest ConvertToTransfersRequest(
            CustomerBankTransfer  customerBankTransfer)
        {

            return new ExternalCustomerBankTransferRequest
            {
                AccountName = customerBankTransfer.Request.AccountName,
                Metadata = new ExternalCustomerBankTransferRequest.ExternalMetadata
                {
                    CustomerData = customerBankTransfer.Request.Metadata.CustomerData
                },
                AccountNumber = customerBankTransfer.Request.AccountNumber,
                Amount = customerBankTransfer.Request.Amount,
                Narration = customerBankTransfer.Request.Narration,
                SortCode = customerBankTransfer.Request.SortCode,
                CustomerId = customerBankTransfer.Request.CustomerId,

            };



        }

        private static List<ExternalMerchantBatchBankTransferRequest> ConvertToTransfersRequest(MerchantBatchBankTransfer merchantBatchBankTransfer)
        {
            var batchTransfers = new List<ExternalMerchantBatchBankTransferRequest>();

            foreach(var merchant in merchantBatchBankTransfer.Request)
            {
                batchTransfers.Add(new ExternalMerchantBatchBankTransferRequest
                {
                    AccountName = merchant.AccountName,
                    Metadata = new ExternalMerchantBatchBankTransferRequest.ExternalMetadata
                    {
                        CustomerData = merchant.Metadata.CustomerData
                    },
                    AccountNumber = merchant.AccountNumber,
                    Amount = merchant.Amount,
                    Narration = merchant.Narration,
                    SortCode = merchant.SortCode,
                });
            }
            return batchTransfers;



        }
        private static ExternalCustomerToCustomerWalletTransferRequest ConvertToTransfersRequest(
            CustomerToCustomerWalletTransfer  customerToCustomerWalletTransfer)
        {

            return new ExternalCustomerToCustomerWalletTransferRequest
            {
               Amount = customerToCustomerWalletTransfer.Request.Amount,
               FromCustomerId = customerToCustomerWalletTransfer.Request.FromCustomerId,
               ToCustomerId = customerToCustomerWalletTransfer.Request.ToCustomerId
            };

        }




        private static BankList ConvertToTransfersResponse(ExternalBankListResponse externalBankListResponse)
        {

            return new BankList
            {
                Response = new BankListResponse
                {
                    Banks = externalBankListResponse.Banks.Select(banks =>
                    {
                        return new BankListResponse.Bank
                        {
                            Code = banks.Code,
                            Name = banks.Name,
                        };
                    }).ToList(),
                    Status = externalBankListResponse.Status,
                    
                }
            };
        }
        private static BankAccountDetails ConvertToTransfersResponse(ExternalBankAccountDetailsResponse externalBankAccountDetailsResponse)
        {
            return new BankAccountDetails
            {
                Response = new BankAccountDetailsResponse
                {
                    Status = externalBankAccountDetailsResponse.Status,
                    Account = new BankAccountDetailsResponse.AccountResponse
                    {
                        AccountName = externalBankAccountDetailsResponse.Account.AccountName,
                        AccountNumber = externalBankAccountDetailsResponse.Account.AccountNumber,
                        BankCode = externalBankAccountDetailsResponse.Account.BankCode,
                    },
                  
                }
            };

        }
        private static MerchantBankTransfer ConvertToTransfersResponse(
            MerchantBankTransfer merchantBankTransfer, 
            ExternalMerchantBankTransferResponse externalMerchantBankTransferResponse)
        {
            merchantBankTransfer.Response = new MerchantBankTransferResponse
            {
                  Message = externalMerchantBankTransferResponse.Message,
                  Status = externalMerchantBankTransferResponse.Status,
                  Transfer = new MerchantBankTransferResponse.TransferResponse
                  {
                     Amount = externalMerchantBankTransferResponse.Transfer.Amount,
                     Charges = externalMerchantBankTransferResponse.Transfer.Charges,
                     Description = externalMerchantBankTransferResponse.Transfer.Description,
                     Destination = externalMerchantBankTransferResponse.Transfer.Destination,
                     Reference = externalMerchantBankTransferResponse.Transfer.Reference,
                     SessionId = externalMerchantBankTransferResponse.Transfer.SessionId,
                     Total = externalMerchantBankTransferResponse.Transfer.Total,
                     TransactionReference = externalMerchantBankTransferResponse.Transfer.TransactionReference,
                     Vat = externalMerchantBankTransferResponse.Transfer.Vat,
                     Metadata = new MerchantBankTransferResponse.Metadata
                     {
                         CustomerData = externalMerchantBankTransferResponse.Transfer.Metadata.CustomerData,
                         
                     }
                  }
            };
            return merchantBankTransfer;

        }
        private static CustomerBankTransfer ConvertToTransfersResponse(
            CustomerBankTransfer customerBankTransfer, 
            ExternalCustomerBankTransferResponse externalCustomerBankTransferResponse)
        {
            customerBankTransfer.Response = new CustomerBankTransferResponse
            {
                   Transfer = new CustomerBankTransferResponse.TransferResponse
                   {
                        
                       Amount = externalCustomerBankTransferResponse.Transfer.Amount,
                       Charges = externalCustomerBankTransferResponse.Transfer.Charges,
                       Description = externalCustomerBankTransferResponse.Transfer.Description,
                       Destination = externalCustomerBankTransferResponse.Transfer.Destination,
                       Reference = externalCustomerBankTransferResponse.Transfer.Reference,
                       SessionId = externalCustomerBankTransferResponse.Transfer.SessionId,
                       Total = externalCustomerBankTransferResponse.Transfer.Total,
                       TransactionReference = externalCustomerBankTransferResponse.Transfer.TransactionReference,
                       Vat = externalCustomerBankTransferResponse.Transfer.Vat,
                       Metadata = new CustomerBankTransferResponse.Metadata
                       {
                           CustomerData = externalCustomerBankTransferResponse.Transfer.Metadata.CustomerData,

                       }

                   },
                   Message = externalCustomerBankTransferResponse.Message,
                   Status = externalCustomerBankTransferResponse.Status
            };
            return customerBankTransfer;

        }
        private static MerchantBatchBankTransfer ConvertToTransfersResponse(
            MerchantBatchBankTransfer merchantBatchBankTransfer,
            ExternalMerchantBatchBankTransferResponse externalMerchantBatchBankTransferResponse)
        {
            merchantBatchBankTransfer.Response = new MerchantBatchBankTransferResponse
            {
                 Message = externalMerchantBatchBankTransferResponse.Message,
                 Status = externalMerchantBatchBankTransferResponse.Status,
                 Data = new MerchantBatchBankTransferResponse.DataResponse
                 {
                     Accepted = externalMerchantBatchBankTransferResponse.Data.Accepted.Select(accepted =>
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
                             Metadata = new MerchantBatchBankTransferResponse.Metadata
                             {
                                 SessionId = accepted.Metadata.SessionId,
                                 TransactionReference = accepted.Metadata.TransactionReference
                             },
                             Total = accepted.Total,
                             Vat = accepted.Vat,
                         };
                     }).ToList(),
                     Rejected = externalMerchantBatchBankTransferResponse.Data.Rejected,
                     All = externalMerchantBatchBankTransferResponse.Data.All.Select(all =>
                     {
                         return new MerchantBatchBankTransferResponse.All
                         {
                             Vat = all.Vat,
                             Total = all.Total,
                             AccountName = all.AccountName,
                             AccountNumber = all.AccountNumber,
                             Amount = all.Amount,
                             Fee = all.Fee,
                             Narration = all.Narration,
                             Reference = all.Reference,
                             SortCode = all.SortCode,

                         };
                     }).ToList(),    
                 }
            };
            return merchantBatchBankTransfer;

        }
        private static CustomerToCustomerWalletTransfer ConvertToTransfersResponse(
            CustomerToCustomerWalletTransfer customerToCustomerWalletTransfer, 
            ExternalCustomerToCustomerWalletTransferResponse externalCustomerToCustomerWalletTransferResponse)
        {
            customerToCustomerWalletTransfer.Response = new CustomerToCustomerWalletTransferResponse
            {
              Status = externalCustomerToCustomerWalletTransferResponse.Status,
              Message = externalCustomerToCustomerWalletTransferResponse.Message,
              Data = new CustomerToCustomerWalletTransferResponse.DataResponse
              {
                 Amount = externalCustomerToCustomerWalletTransferResponse.Data.Amount,
                 Description = externalCustomerToCustomerWalletTransferResponse.Data.Description,
                 Reference = externalCustomerToCustomerWalletTransferResponse.Data.Reference,
                 SourceCustomerId = externalCustomerToCustomerWalletTransferResponse.Data.SourceCustomerId,
                 SourceCustomerWallet = externalCustomerToCustomerWalletTransferResponse.Data.SourceCustomerWallet,
                 TargetCustomerId = externalCustomerToCustomerWalletTransferResponse.Data.TargetCustomerId,
                 TargetCustomerWallet = externalCustomerToCustomerWalletTransferResponse.Data.TargetCustomerWallet,
                 Total = externalCustomerToCustomerWalletTransferResponse.Data.Total,
                 TransactionFee = externalCustomerToCustomerWalletTransferResponse.Data.TransactionFee,
                 
              }
            };
            return customerToCustomerWalletTransfer;

        }





       
    }
}
