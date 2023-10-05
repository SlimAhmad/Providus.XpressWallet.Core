using Providus.XpressWallet.Core.Clients;
using Providus.XpressWallet.Core.Clients.Auth;
using Providus.XpressWallet.Core.Models.Configurations;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalTransactions;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transactions;
using Tynamix.ObjectFiller;
using WireMock.Server;

namespace Providus.XpressWallet.Core.Tests.Acceptance.Clients.Transactions
{
    public partial class TransactionsClientTests : IDisposable
    {
        private readonly string apiKey;
        private readonly WireMockServer wireMockServer;
        private readonly IXpressWalletClient xPressWalletClient;

        public TransactionsClientTests()
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

        private static int GetRandomNumber() =>
    new IntRange(min: 2, max: 10).GetValue();

        private static string GetRandomString() =>
            new MnemonicString().GetValue();

        private static ExternalReverseBatchTransactionRequest ConvertToTransactionsRequest(ReverseBatchTransaction reverseBatchTransaction)
        {

            return new ExternalReverseBatchTransactionRequest
            {
                BatchReference = reverseBatchTransaction.Request.BatchReference,
            };



        }
        private static ExternalApproveTransactionRequest ConvertToTransactionsRequest(ApproveTransaction approveTransaction)
        {

            return new ExternalApproveTransactionRequest
            {
                TransactionId = approveTransaction.Request.TransactionId,

            };



        }





        private static ReverseBatchTransaction ConvertToTransactionsResponse(
            ReverseBatchTransaction reverseBatchTransaction,
            ExternalReverseBatchTransactionResponse externalReverseBatchTransactionResponse)
        {
            reverseBatchTransaction.Response = new ReverseBatchTransactionResponse
            {
                Message = externalReverseBatchTransactionResponse.Message,
                Status = externalReverseBatchTransactionResponse.Status,
            };
            return reverseBatchTransaction;

        }
        private static ApproveTransaction ConvertToTransactionsResponse(
            ApproveTransaction approveTransaction,
            ExternalApproveTransactionResponse externalApproveTransactionResponse)
        {
            approveTransaction.Response = new ApproveTransactionResponse
            {
                Message = externalApproveTransactionResponse.Message,
                Status = externalApproveTransactionResponse.Status
            };
            return approveTransaction;

        }
        private static MerchantTransactions ConvertToTransactionsResponse(
            ExternalMerchantTransactionsResponse externalMerchantTransactionsResponse)
        {
            return new MerchantTransactions
            {
                Response = new MerchantTransactionsResponse
                {
                    Status = externalMerchantTransactionsResponse.Status,
                    Metadata = new MerchantTransactionsResponse.MetadataResponse
                    {
                        Amount = externalMerchantTransactionsResponse.Metadata.Amount,
                        Bvn = externalMerchantTransactionsResponse.Metadata.Bvn,
                        BVNFirstName = externalMerchantTransactionsResponse.Metadata.BVNFirstName,
                        BVNLastName = externalMerchantTransactionsResponse.Metadata.BVNLastName,
                        Currency = externalMerchantTransactionsResponse.Metadata.Currency,
                        CustomerName = externalMerchantTransactionsResponse.Metadata.CustomerName,
                        CustomerWallet = externalMerchantTransactionsResponse.Metadata.CustomerWallet,
                        DateOfBirth = externalMerchantTransactionsResponse.Metadata.DateOfBirth,
                        DestinationAccountNumber = externalMerchantTransactionsResponse.Metadata.DestinationAccountNumber,
                        DestinationBankCode = externalMerchantTransactionsResponse.Metadata.DestinationBankCode,
                        Email = externalMerchantTransactionsResponse.Metadata.Email,
                        FirstName = externalMerchantTransactionsResponse.Metadata.FirstName,
                        LastName = externalMerchantTransactionsResponse.Metadata.LastName,
                        NameMatch = externalMerchantTransactionsResponse.Metadata.NameMatch,
                        Page = externalMerchantTransactionsResponse.Metadata.Page,
                        PhoneNumber = externalMerchantTransactionsResponse.Metadata.PhoneNumber,
                        TotalPages = externalMerchantTransactionsResponse.Metadata.TotalPages,
                        TotalRecords = externalMerchantTransactionsResponse.Metadata.TotalRecords,
                    },
                    Transactions = externalMerchantTransactionsResponse.Transactions.Select(transactions =>
                    {
                        return new MerchantTransactionsResponse.Transaction
                        {
                            Amount = transactions.Amount,
                            BalanceAfter = transactions.BalanceAfter,
                            BalanceBefore = transactions.BalanceBefore,
                            Category = transactions.Category,
                            Completed = transactions.Completed,
                            CreatedAt = transactions.CreatedAt,
                            Currency = transactions.Currency,
                            Description = transactions.Description,
                            Destination = transactions.Destination,
                            Id = transactions.Id,
                            Mode = transactions.Mode,
                            Reference = transactions.Reference,
                            Source = transactions.Source,
                            Type = transactions.Type,
                            UpdatedAt = transactions.UpdatedAt,
                            Metadata = new MerchantTransactionsResponse.MetadataResponse
                            {
                                Amount = transactions.Metadata.Amount,
                                Bvn = transactions.Metadata.Bvn,
                                BVNFirstName = transactions.Metadata.BVNFirstName,
                                BVNLastName = transactions.Metadata.BVNLastName,
                                Currency = transactions.Metadata.Currency,
                                CustomerName = transactions.Metadata.CustomerName,
                                CustomerWallet = transactions.Metadata.CustomerWallet,
                                DateOfBirth = transactions.Metadata.DateOfBirth,
                                DestinationAccountNumber = transactions.Metadata.DestinationAccountNumber,
                                DestinationBankCode = transactions.Metadata.DestinationBankCode,
                                Email = transactions.Metadata.Email,
                                FirstName = transactions.Metadata.FirstName,
                                LastName = transactions.Metadata.LastName,
                                NameMatch = transactions.Metadata.NameMatch,
                                Page = transactions.Metadata.Page,
                                PhoneNumber = transactions.Metadata.PhoneNumber,
                                TotalPages = transactions.Metadata.TotalPages,
                                TotalRecords = transactions.Metadata.TotalRecords,
                            }
                        };
                    }).ToList(),

                }
            };

        }
        private static TransactionDetails ConvertToTransactionsResponse(ExternalTransactionDetailsResponse externalTransactionDetailsResponse)
        {
            return new TransactionDetails
            {
                Response = new TransactionDetailsResponse
                {
                    Status = externalTransactionDetailsResponse.Status,
                    Transaction = new TransactionDetailsResponse.TransactionResponse
                    {
                        Amount = externalTransactionDetailsResponse.Transaction.Amount,
                        BalanceAfter = externalTransactionDetailsResponse.Transaction.BalanceAfter,
                        BalanceBefore = externalTransactionDetailsResponse.Transaction.BalanceBefore,
                        Category = externalTransactionDetailsResponse.Transaction.Category,
                        Completed = externalTransactionDetailsResponse.Transaction.Completed,
                        CreatedAt = externalTransactionDetailsResponse.Transaction.CreatedAt,
                        Currency = externalTransactionDetailsResponse.Transaction.Currency,
                        Description = externalTransactionDetailsResponse.Transaction.Description,
                        Destination = externalTransactionDetailsResponse.Transaction.Destination,
                        Id = externalTransactionDetailsResponse.Transaction.Id,
                        Metadata = externalTransactionDetailsResponse.Transaction.Metadata,
                        Reference = externalTransactionDetailsResponse.Transaction.Reference,
                        Source = externalTransactionDetailsResponse.Transaction.Source,
                        Type = externalTransactionDetailsResponse.Transaction.Type,
                        UpdatedAt = externalTransactionDetailsResponse.Transaction.UpdatedAt,
                    }
                }
            };

        }
        private static CustomerTransactions ConvertToTransactionsResponse(
            ExternalCustomerTransactionsResponse externalCustomerTransactionsResponse)
        {
            return new CustomerTransactions
            {
                Response = new CustomerTransactionsResponse
                {
                    Metadata = new CustomerTransactionsResponse.MetadataResponse
                    {
                        Page = externalCustomerTransactionsResponse.Metadata.Page,
                        TotalPages = externalCustomerTransactionsResponse.Metadata.TotalPages,
                        TotalRecords = externalCustomerTransactionsResponse.Metadata.TotalRecords,

                    },
                    Transactions = externalCustomerTransactionsResponse.Transactions.Select(transactions =>
                    {
                        return new CustomerTransactionsResponse.Transaction
                        {
                            Amount = transactions.Amount,
                            BalanceAfter = transactions.BalanceAfter,
                            BalanceBefore = transactions.BalanceBefore,
                            Category = transactions.Category,
                            Completed = transactions.Completed,
                            CreatedAt = transactions.CreatedAt,
                            Currency = transactions.Currency,
                            Description = transactions.Description,
                            Destination = transactions.Destination,
                            Id = transactions.Id,
                            Metadata = transactions.Metadata,
                            Mode = transactions.Mode,
                            Reference = transactions.Reference,
                            Source = transactions.Source,
                            Type = transactions.Type,
                            UpdatedAt = transactions.UpdatedAt,
                            UserId = transactions.UserId,
                        };
                    }).ToList(),
                    Status = externalCustomerTransactionsResponse.Status
                }
            };

        }
        private static BatchTransactions ConvertToTransactionsResponse(ExternalBatchTransactionsResponse externalBatchTransactionsResponse)
        {
            return new BatchTransactions
            {
                Response = new BatchTransactionsResponse
                {
                    Status = externalBatchTransactionsResponse.Status,
                    Data = externalBatchTransactionsResponse.Data.Select(data =>
                    {
                        return new BatchTransactionsResponse.Datum
                        {
                            AllReferences = data.AllReferences,
                            CreatedAt = data.CreatedAt,
                            FailedReferences = data.FailedReferences,
                            Id = data.Id,
                            PassedReferences = data.PassedReferences,
                            Reference = data.Reference,
                            Reversed = data.Reversed,
                            Source = new BatchTransactionsResponse.Source
                            {
                                Type = data.Source.Type,
                                UserId = data.Source.UserId,
                                WalletId = data.Source.WalletId,
                            },
                            Type = data.Type,
                            UpdatedAt = data.UpdatedAt,
                        };
                    }).ToList(),
                    Metadata = new BatchTransactionsResponse.MetadataResponse
                    {
                        Page = externalBatchTransactionsResponse.Metadata.Page,
                        TotalPages = externalBatchTransactionsResponse.Metadata.TotalPages,
                        TotalRecords = externalBatchTransactionsResponse.Metadata.TotalRecords,
                    }
                }
            };

        }
        private static BatchTransactionDetails ConvertToTransactionsResponse(ExternalBatchTransactionDetailsResponse externalBatchTransactionDetailsResponse)
        {
            return new BatchTransactionDetails
            {
                Response = new BatchTransactionDetailsResponse
                {
                    Status = externalBatchTransactionDetailsResponse.Status,
                    Data = new BatchTransactionDetailsResponse.DataResponse
                    {
                        AllReferences = externalBatchTransactionDetailsResponse.Data.AllReferences,
                        CreatedAt = externalBatchTransactionDetailsResponse.Data.CreatedAt,
                        FailedReferences = externalBatchTransactionDetailsResponse.Data.FailedReferences,
                        Id = externalBatchTransactionDetailsResponse.Data.Id,
                        PassedReferences = externalBatchTransactionDetailsResponse.Data.PassedReferences,
                        Reference = externalBatchTransactionDetailsResponse.Data.Reference,
                        Reversed = externalBatchTransactionDetailsResponse.Data.Reversed,
                        Source = new BatchTransactionDetailsResponse.Source
                        {
                            Type = externalBatchTransactionDetailsResponse.Data.Source.Type,
                            UserId = externalBatchTransactionDetailsResponse.Data.Source.UserId,
                            WalletId = externalBatchTransactionDetailsResponse.Data.Source.WalletId
                        },
                        Type = externalBatchTransactionDetailsResponse.Data.Type,
                        UpdatedAt = externalBatchTransactionDetailsResponse.Data.UpdatedAt
                    }
                }
            };

        }
        private static PendingTransaction ConvertToTransactionsResponse(ExternalPendingTransactionResponse externalPendingTransactionResponse)
        {
            return new PendingTransaction
            {
                Response = new PendingTransactionResponse
                {
                    Status = externalPendingTransactionResponse.Status,
                    Data = externalPendingTransactionResponse.Data.Select(data =>
                    {
                        return new PendingTransactionResponse.Datum
                        {
                            Category = data.Category,
                            Creator = data.Creator,
                            MerchantId = data.MerchantId,
                            Metadata = new PendingTransactionResponse.MetadataResponse
                            {
                                Amount = data.Metadata.Amount,
                                AccountName = data.Metadata.AccountName,
                                AccountNumber = data.Metadata.AccountNumber,
                                BankName = data.Metadata.BankName,
                                CustomData = new PendingTransactionResponse.CustomData
                                {
                                    CustomerData = data.Metadata.CustomData.CustomerData
                                },
                                CustomerId = data.Metadata.CustomerId,
                                Narration = data.Metadata.Narration,
                                Page = data.Metadata.Page,
                                SortCode = data.Metadata.SortCode,
                                TotalPages = data.Metadata.TotalPages,
                                TotalRecords = data.Metadata.TotalRecords,
                            },
                            Mode = data.Mode,
                            Status = data.Status,
                            CreatedAt = data.CreatedAt,
                            ApprovedBy = data.ApprovedBy,
                            Id = data.Id,
                            Amount = data.Amount,
                            Type = data.Type,
                            UpdatedAt = data.UpdatedAt,
                        };
                    }).ToList(),
                    Metadata = new PendingTransactionResponse.MetadataResponse
                    {
                        AccountName = externalPendingTransactionResponse.Metadata.AccountName,
                        AccountNumber = externalPendingTransactionResponse.Metadata.AccountNumber,
                        Amount = externalPendingTransactionResponse.Metadata.Amount,
                        BankName = externalPendingTransactionResponse.Metadata.BankName,
                        CustomData = new PendingTransactionResponse.CustomData
                        {
                            CustomerData = externalPendingTransactionResponse.Metadata.CustomData.CustomerData
                        },
                        CustomerId = externalPendingTransactionResponse.Metadata.CustomerId,
                        Narration = externalPendingTransactionResponse.Metadata.Narration,
                        SortCode = externalPendingTransactionResponse.Metadata.SortCode,
                        Page = externalPendingTransactionResponse.Metadata.Page,
                        TotalPages = externalPendingTransactionResponse.Metadata.TotalPages,
                        TotalRecords = externalPendingTransactionResponse.Metadata.TotalRecords,
                    }
                }
            };

        }
        private static DeclinePendingTransaction ConvertToTransactionsResponse(ExternalDeclinePendingTransactionResponse externalDeclinePendingTransactionResponse)
        {
            return new DeclinePendingTransaction
            {
                Response = new DeclinePendingTransactionResponse
                {
                    Status = externalDeclinePendingTransactionResponse.Status,
                    Message = externalDeclinePendingTransactionResponse.Message,
                }
            };

        }
        private static DownloadCustomerTransaction ConvertToTransactionsResponse(ExternalDownloadCustomerTransactionResponse externalDownloadCustomerTransactionResponse)
        {
            return new DownloadCustomerTransaction
            {
                Response = new DownloadCustomerTransactionResponse
                {
                    Status = externalDownloadCustomerTransactionResponse.Status,
                    Data = externalDownloadCustomerTransactionResponse.Data.Select(data =>
                    {
                        return new DownloadCustomerTransactionResponse.Datum
                        {

                            CreatedAt = data.CreatedAt,
                            Status = data.Status,
                            Destination = data.Destination,
                            Description = data.Description,
                            Currency = data.Currency,
                            Category = data.Category,
                            Amount = data.Amount,
                            BalanceAfter = data.BalanceAfter,
                            BalanceBefore = data.BalanceBefore,
                            Fee = data.Fee,
                            Id = data.Id,
                            Reference = data.Reference,
                            Source = data.Source,
                            Total = data.Total,
                            Vat = data.Vat,

                            Metadata = new DownloadCustomerTransactionResponse.Metadata
                            {
                                BankName = data.Metadata.BankName,
                                Charges = data.Metadata.Charges,
                                MerchantId = data.Metadata.MerchantId,
                                NameEnquiryRef = data.Metadata.NameEnquiryRef,
                                SessionID = data.Metadata.SessionID,
                                TotalAmount = data.Metadata.TotalAmount,
                                Vat = data.Metadata.Vat,
                                WalletAccountName = data.Metadata.WalletAccountName,
                                WalletAccountNumber = data.Metadata.WalletAccountNumber,
                                WalletId = data.Metadata.WalletId,
                                AdditionalMetadata = new DownloadCustomerTransactionResponse.AdditionalMetadata
                                {
                                    CustomerData = data.Metadata.AdditionalMetadata.CustomerData
                                },
                                Fee = data.Metadata?.Fee,
                                AccountName = data.Metadata?.AccountName,
                                AccountNumber = data.Metadata?.AccountNumber,
                                Amount = data.Metadata.Amount,

                                CustomData = new DownloadCustomerTransactionResponse.CustomData
                                {

                                    MoreData = data.Metadata?.CustomData.MoreData,
                                    SomeData = data.Metadata?.CustomData.SomeData,

                                },
                                CustomerId = data.Metadata?.CustomerId,
                                CustomerName = data.Metadata?.CustomerName,
                                CustomerWallet = data.Metadata?.CustomerWallet,
                                Narration = data.Metadata?.Narration,
                                SortCode = data.Metadata?.SortCode,
                                SourceCustomerId = data.Metadata?.SourceCustomerId,
                                SourceCustomerWallet = data.Metadata?.SourceCustomerWallet,
                                TargetCustomerId = data.Metadata?.TargetCustomerId,
                                TargetCustomerWallet = data.Metadata?.TargetCustomerWallet,


                            },
                            Type = data.Type,
                            UpdatedAt = data.UpdatedAt,
                        };
                    }).ToList(),


                }
            };

        }
        private static DownloadMerchantTransaction ConvertToTransactionsResponse(ExternalDownloadMerchantTransactionResponse externalDownloadMerchantTransactionResponse)
        {
            return new DownloadMerchantTransaction
            {
                Response = new DownloadMerchantTransactionResponse
                {
                    Status = externalDownloadMerchantTransactionResponse.Status,
                    Data = externalDownloadMerchantTransactionResponse.Data.Select(data =>
                    {
                        return new DownloadMerchantTransactionResponse.Datum
                        {

                            CreatedAt = data.CreatedAt,
                            Status = data.Status,
                            Destination = data.Destination,
                            Description = data.Description,
                            Currency = data.Currency,
                            Category = data.Category,
                            Amount = data.Amount,
                            BalanceAfter = data.BalanceAfter,
                            BalanceBefore = data.BalanceBefore,
                            Fee = data.Fee,
                            Id = data.Id,
                            Reference = data.Reference,
                            Source = data.Source,
                            Total = data.Total,
                            Vat = data.Vat,
                            Metadata = data.Metadata,
                            Type = data.Type,
                            UpdatedAt = data.UpdatedAt,
                        };
                    }).ToList(),


                }
            };

        }




        private static ExternalApproveTransactionResponse CreateExternalApproveTransactionResponseResult() =>
                CreateExternalApproveTransactionResponseFiller().Create();

        private static ExternalDownloadMerchantTransactionResponse CreateExternalDownloadMerchantTransactionResponseResult() =>
           CreateExternalDownloadMerchantTransactionResponseFiller().Create();

        private static ExternalDownloadCustomerTransactionResponse CreateExternalDownloadCustomerTransactionResponseResult() =>
          CreateExternalDownloadCustomerTransactionResponseFiller().Create();

        private static ExternalDeclinePendingTransactionResponse CreateExternalDeclinePendingTransactionResponseResult() =>
           CreateExternalDeclinePendingTransactionResponseFiller().Create();
        private static ExternalReverseBatchTransactionResponse CreateExternalReverseBatchTransactionResponseResult() =>
            CreateExternalReverseBatchTransactionResponseFiller().Create();

        private static ExternalPendingTransactionResponse CreateExternalPendingTransactionResponseResult() =>
            CreateExternalPendingTransactionResponseFiller().Create();

        private static ExternalBatchTransactionDetailsResponse CreateExternalBatchTransactionDetailsResponseResult() =>
             CreateExternalBatchTransactionDetailsResponseFiller().Create();

        private static ExternalBatchTransactionsResponse CreateExternalBatchTransactionsResponseResult() =>
             CreateExternalBatchTransactionsResponseFiller().Create();

        private static ExternalCustomerTransactionsResponse CreateExternalCustomerTransactionsResponseResult() =>
            CreateExternalCustomerTransactionsResponseFiller().Create();
        private static ExternalTransactionDetailsResponse CreateExternalTransactionDetailsResponseResult() =>
             CreateExternalTransactionDetailsResponseFiller().Create();

        private static ExternalMerchantTransactionsResponse CreateExternalMerchantTransactionsResponseResult() =>
             CreateExternalMerchantTransactionsResponseFiller().Create();


        private static ApproveTransaction CreateApproveTransactionResponseResult() =>
          CreateApproveTransactionFiller().Create();
        private static ReverseBatchTransaction CreateReverseBatchTransactionResponseResult() =>
          CreateReverseBatchTransactionFiller().Create();



        private static Filler<ExternalApproveTransactionResponse> CreateExternalApproveTransactionResponseFiller()
        {
            var filler = new Filler<ExternalApproveTransactionResponse>();

            filler.Setup()
               .OnType<object>().IgnoreIt();

            return filler;
        }
        private static Filler<ExternalDownloadMerchantTransactionResponse> CreateExternalDownloadMerchantTransactionResponseFiller()
        {
            var filler = new Filler<ExternalDownloadMerchantTransactionResponse>();

            filler.Setup()
               .OnType<object>().IgnoreIt();

            return filler;
        }
        private static Filler<ExternalDeclinePendingTransactionResponse> CreateExternalDeclinePendingTransactionResponseFiller()
        {
            var filler = new Filler<ExternalDeclinePendingTransactionResponse>();

            filler.Setup()
               .OnType<object>().IgnoreIt();

            return filler;
        }
        private static Filler<ExternalDownloadCustomerTransactionResponse> CreateExternalDownloadCustomerTransactionResponseFiller()
        {
            var filler = new Filler<ExternalDownloadCustomerTransactionResponse>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<ExternalReverseBatchTransactionResponse> CreateExternalReverseBatchTransactionResponseFiller()
        {
            var filler = new Filler<ExternalReverseBatchTransactionResponse>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<ExternalPendingTransactionResponse> CreateExternalPendingTransactionResponseFiller()
        {
            var filler = new Filler<ExternalPendingTransactionResponse>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<ExternalBatchTransactionDetailsResponse> CreateExternalBatchTransactionDetailsResponseFiller()
        {
            var filler = new Filler<ExternalBatchTransactionDetailsResponse>();

            filler.Setup()
                .OnType<List<object>>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<ExternalBatchTransactionsResponse> CreateExternalBatchTransactionsResponseFiller()
        {
            var filler = new Filler<ExternalBatchTransactionsResponse>();

            filler.Setup()
                .OnType<List<object>>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<ExternalCustomerTransactionsResponse> CreateExternalCustomerTransactionsResponseFiller()
        {
            var filler = new Filler<ExternalCustomerTransactionsResponse>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<ExternalTransactionDetailsResponse> CreateExternalTransactionDetailsResponseFiller()
        {
            var filler = new Filler<ExternalTransactionDetailsResponse>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<ExternalMerchantTransactionsResponse> CreateExternalMerchantTransactionsResponseFiller()
        {
            var filler = new Filler<ExternalMerchantTransactionsResponse>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }


        private static Filler<ApproveTransaction> CreateApproveTransactionFiller()
        {
            var filler = new Filler<ApproveTransaction>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<ReverseBatchTransaction> CreateReverseBatchTransactionFiller()
        {
            var filler = new Filler<ReverseBatchTransaction>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }

        public void Dispose() => wireMockServer.Stop();
    }
}
