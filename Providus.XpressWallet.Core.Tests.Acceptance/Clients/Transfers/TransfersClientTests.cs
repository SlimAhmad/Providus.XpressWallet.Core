using Providus.XpressWallet.Core.Clients;
using Providus.XpressWallet.Core.Clients.Auth;
using Providus.XpressWallet.Core.Models.Configurations;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalTransfers;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transfers;
using Tynamix.ObjectFiller;
using WireMock.Server;

namespace Providus.XpressWallet.Core.Tests.Acceptance.Clients.Transfers
{
    public partial class TransfersClientTests : IDisposable
    {
        private readonly string apiKey;
        private readonly WireMockServer wireMockServer;
        private readonly IXpressWalletClient xPressWalletClient;

        public TransfersClientTests()
        {
            apiKey = GetRandomString();
            wireMockServer = WireMockServer.Start();

            var apiConfigurations = new ApiConfigurations
            {
                ApiUrl = wireMockServer.Url,
                ApiKey = apiKey,

            };

            xPressWalletClient = new XpressWalletClient(apiConfigurations);
        }

        private static DateTimeOffset GetRandomDate() =>
             new DateTimeRange(earliestDate: new DateTime()).GetValue();

        private static string GetRandomString() =>
            new MnemonicString().GetValue();


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
            CustomerBankTransfer customerBankTransfer)
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

            foreach (var merchant in merchantBatchBankTransfer.Request)
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
            CustomerToCustomerWalletTransfer customerToCustomerWalletTransfer)
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
        private static BankAccountDetails ConvertToTransfersResponse(
            ExternalBankAccountDetailsResponse externalBankAccountDetailsResponse)
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





        private static ExternalBankAccountDetailsResponse CreateExternalBankAccountDetailsResponseResult() =>
           CreateExternalBankAccountDetailsResponseFiller().Create();
        private static ExternalBankListResponse CreateExternalBankListResponseResult() =>
            CreateExternalBankListResponseFiller().Create();

        private static ExternalMerchantBankTransferResponse CreateExternalMerchantBankTransferResponseResult() =>
            CreateExternalMerchantBankTransferResponseFiller().Create();

        private static ExternalCustomerBankTransferResponse CreateExternalCustomerBankTransferResponseResult() =>
             CreateExternalCustomerBankTransferResponseFiller().Create();

        private static ExternalMerchantBatchBankTransferResponse CreateExternalMerchantBatchBankTransferResponseResult() =>
             CreateExternalMerchantBatchBankTransferResponseFiller().Create();

        private static ExternalCustomerToCustomerWalletTransferResponse CreateExternalCustomerToCustomerWalletTransferResponseResult() =>
            CreateExternalCustomerToCustomerWalletTransferResponseFiller().Create();



    
        private static MerchantBankTransfer CreateMerchantBankTransferResponseResult() =>
          CreateMerchantBankTransferFiller().Create();
        private static CustomerBankTransfer CreateCustomerBankTransferResponseResult() =>
          CreateCustomerBankTransferFiller().Create();
        private static MerchantBatchBankTransfer CreateMerchantBatchBankTransferResponseResult() =>
          CreateMerchantBatchBankTransferFiller().Create();
        private static CustomerToCustomerWalletTransfer CreateCustomerToCustomerWalletTransferResponseResult() =>
          CreateCustomerToCustomerWalletTransferFiller().Create();


     
        private static Filler<ExternalMerchantBankTransferResponse> CreateExternalMerchantBankTransferResponseFiller()
        {
            var filler = new Filler<ExternalMerchantBankTransferResponse>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<ExternalCustomerBankTransferResponse> CreateExternalCustomerBankTransferResponseFiller()
        {
            var filler = new Filler<ExternalCustomerBankTransferResponse>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<ExternalMerchantBatchBankTransferResponse> CreateExternalMerchantBatchBankTransferResponseFiller()
        {
            var filler = new Filler<ExternalMerchantBatchBankTransferResponse>();

            filler.Setup()
                .OnType<List<object>>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<ExternalCustomerToCustomerWalletTransferResponse> CreateExternalCustomerToCustomerWalletTransferResponseFiller()
        {
            var filler = new Filler<ExternalCustomerToCustomerWalletTransferResponse>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<ExternalBankAccountDetailsResponse> CreateExternalBankAccountDetailsResponseFiller()
        {
            var filler = new Filler<ExternalBankAccountDetailsResponse>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<ExternalBankListResponse> CreateExternalBankListResponseFiller()
        {
            var filler = new Filler<ExternalBankListResponse>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }



        private static Filler<MerchantBankTransfer> CreateMerchantBankTransferFiller()
        {
            var filler = new Filler<MerchantBankTransfer>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<CustomerBankTransfer> CreateCustomerBankTransferFiller()
        {
            var filler = new Filler<CustomerBankTransfer>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<MerchantBatchBankTransfer> CreateMerchantBatchBankTransferFiller()
        {
            var filler = new Filler<MerchantBatchBankTransfer>();

            filler.Setup()
                .OnType<List<object>>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<CustomerToCustomerWalletTransfer> CreateCustomerToCustomerWalletTransferFiller()
        {
            var filler = new Filler<CustomerToCustomerWalletTransfer>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }
        public void Dispose() => wireMockServer.Stop();
    }
}
