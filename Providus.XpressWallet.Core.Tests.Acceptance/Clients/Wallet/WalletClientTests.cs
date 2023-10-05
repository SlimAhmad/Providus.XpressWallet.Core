using Providus.XpressWallet.Core.Clients;
using Providus.XpressWallet.Core.Clients.Auth;
using Providus.XpressWallet.Core.Models.Configurations;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalWallet;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Wallet;
using Tynamix.ObjectFiller;
using WireMock.Server;

namespace Providus.XpressWallet.Core.Tests.Acceptance.Clients.Wallet
{
    public partial class WalletClientTests : IDisposable
    {
        private readonly string apiKey;
        private readonly WireMockServer wireMockServer;
        private readonly IXpressWalletClient xPressWalletClient;

        public WalletClientTests()
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


        private static ExternalBatchCreditCustomerWalletsRequest ConvertToWalletRequest(
           BatchCreditCustomerWallets batchCreditCustomerWallets)
        {

            return new ExternalBatchCreditCustomerWalletsRequest
            {
                BatchReference = batchCreditCustomerWallets.Request.BatchReference,
                Transactions = batchCreditCustomerWallets.Request.Transactions.Select(transactions =>
                {
                    return new ExternalBatchCreditCustomerWalletsRequest.Transaction
                    {
                        Amount = transactions.Amount,
                        CustomerId = transactions.CustomerId,

                    };
                }).ToList()
            };



        }
        private static ExternalBatchDebitCustomerWalletsRequest ConvertToWalletRequest(
            BatchDebitCustomerWallets batchDebitCustomerWallets)
        {

            return new ExternalBatchDebitCustomerWalletsRequest
            {
                BatchReference = batchDebitCustomerWallets.Request.BatchReference,
                Transactions = batchDebitCustomerWallets.Request.Transactions.Select(transactions =>
                {
                    return new ExternalBatchDebitCustomerWalletsRequest.Transaction
                    {
                        CustomerId = transactions.CustomerId,
                        Amount = transactions.Amount,
                        Reference = transactions.Reference,

                    };
                }).ToList()

            };



        }
        private static ExternalCreateWalletRequest ConvertToWalletRequest(CreateWallet createWallet)
        {

            return new ExternalCreateWalletRequest
            {
                Address = createWallet.Request.Address,
                Bvn = createWallet.Request.Bvn,
                DateOfBirth = createWallet.Request.DateOfBirth,
                Email = createWallet.Request.Email,
                FirstName = createWallet.Request.FirstName,
                LastName = createWallet.Request.LastName,
                PhoneNumber = createWallet.Request.PhoneNumber,
                Metadata = new ExternalCreateWalletRequest.ExternalMetadata
                {
                    AdditionalData = createWallet.Request.Metadata.AdditionalData,
                    EvenMore = createWallet.Request.Metadata.EvenMore
                }
            };



        }
        private static ExternalCreditWalletRequest ConvertToWalletRequest(CreditWallet creditWallet)
        {

            return new ExternalCreditWalletRequest
            {
                Amount = creditWallet.Request.Amount,
                CustomerId = creditWallet.Request.CustomerId,
                Reference = creditWallet.Request.Reference,
                Metadata = new ExternalCreditWalletRequest.ExternalMetadata
                {
                    MoreData = creditWallet.Request.Metadata.MoreData,
                    SomeData = creditWallet.Request.Metadata.SomeData,
                }

            };



        }
        private static ExternalCustomerCreditCustomerWalletRequest ConvertToWalletRequest(
            CustomerCreditCustomerWallet customerCreditCustomerWallet)
        {

            return new ExternalCustomerCreditCustomerWalletRequest
            {
                BatchReference = customerCreditCustomerWallet.Request.BatchReference,
                CustomerId = customerCreditCustomerWallet.Request.CustomerId,
                Recipients = customerCreditCustomerWallet.Request.Recipients.Select(recipients =>
                {
                    return new ExternalCustomerCreditCustomerWalletRequest.Recipient
                    {
                        CustomerId = recipients.CustomerId,
                        Amount = recipients.Amount,
                        Reference = recipients.Reference,
                    };
                }).ToList(),

            };



        }
        private static ExternalDebitWalletRequest ConvertToWalletRequest(DebitWallet debitWallet)
        {

            return new ExternalDebitWalletRequest
            {
                Reference = debitWallet.Request.Reference,
                Amount = debitWallet.Request.Amount,
                CustomerId = debitWallet.Request.CustomerId,
                Metadata = new ExternalDebitWalletRequest.ExternalMetadata
                {
                    MoreData = debitWallet.Request.Metadata.MoreData,
                    SomeData = debitWallet.Request.Metadata.SomeData
                }
            };



        }
        private static ExternalFreezeWalletRequest ConvertToWalletRequest(FreezeWallet freezeWallet)
        {

            return new ExternalFreezeWalletRequest
            {
                CustomerId = freezeWallet.Request.CustomerId,
            };



        }
        private static ExternalFundMerchantSandBoxWalletRequest ConvertToWalletRequest(
            FundMerchantSandBoxWallet fundMerchantSandBoxWallet)
        {

            return new ExternalFundMerchantSandBoxWalletRequest
            {
                Amount = fundMerchantSandBoxWallet.Request.Amount,
            };



        }
        private static ExternalUnfreezeWalletRequest ConvertToWalletRequest(UnfreezeWallet unfreezeWallet)
        {

            return new ExternalUnfreezeWalletRequest
            {
                CustomerId = unfreezeWallet.Request.CustomerId,
            };



        }





        private static BatchCreditCustomerWallets ConvertToWalletResponse(
            BatchCreditCustomerWallets batchCreditCustomerWallet,
            ExternalBatchCreditCustomerWalletsResponse externalBatchCreditCustomerWalletsResponse)
        {
            batchCreditCustomerWallet.Response = new BatchCreditCustomerWalletsResponse
            {
                Message = externalBatchCreditCustomerWalletsResponse.Message,
                Status = externalBatchCreditCustomerWalletsResponse.Status,
                Data = new BatchCreditCustomerWalletsResponse.DataResponse
                {
                    Accepted = externalBatchCreditCustomerWalletsResponse.Data.Accepted.Select(accepted =>
                    {
                        return new BatchCreditCustomerWalletsResponse.Accepted
                        {
                            Reference = accepted.Reference,
                            CustomerId = accepted.CustomerId,
                            Amount = accepted.Amount,
                        };
                    }).ToList(),
                    BatchReference = externalBatchCreditCustomerWalletsResponse.Data.BatchReference,
                    Rejected = externalBatchCreditCustomerWalletsResponse.Data.Rejected.Select(rejected =>
                    {
                        return new BatchCreditCustomerWalletsResponse.Rejected
                        {
                            Amount = rejected.Amount,
                            CustomerId = rejected.CustomerId,
                            Reason = rejected.Reason,
                            Reference = rejected.Reference,
                            ReferenceExists = rejected.ReferenceExists,
                        };
                    }).ToList(),
                }
            };
            return batchCreditCustomerWallet;

        }

        private static BatchDebitCustomerWallets ConvertToWalletResponse(
            BatchDebitCustomerWallets batchDebitCustomerWallet,
            ExternalBatchDebitCustomerWalletsResponse externalBatchDebitCustomerWalletsResponse)
        {
            batchDebitCustomerWallet.Response = new BatchDebitCustomerWalletsResponse
            {
                Message = externalBatchDebitCustomerWalletsResponse.Message,
                Data = new BatchDebitCustomerWalletsResponse.DataResponse
                {
                    AllReferences = externalBatchDebitCustomerWalletsResponse.Data.AllReferences,
                    MerchantId = externalBatchDebitCustomerWalletsResponse.Data.MerchantId,
                    Reference = externalBatchDebitCustomerWalletsResponse.Data.Reference,
                    PassedReferences = externalBatchDebitCustomerWalletsResponse.Data.PassedReferences,
                    FailedReferences = externalBatchDebitCustomerWalletsResponse?.Data?.FailedReferences,
                    Results = externalBatchDebitCustomerWalletsResponse.Data.Results.Select(results =>
                    {
                        return new BatchDebitCustomerWalletsResponse.Result
                        {
                            Amount = results.Amount,
                            CustomerId = results.CustomerId,
                            Reason = results.Reason,
                            Reference = results.Reference,
                            Status = results.Status,
                        };
                    }).ToList()


                },
                Status = externalBatchDebitCustomerWalletsResponse.Status
            };
            return batchDebitCustomerWallet;

        }

        private static AllWallets ConvertToWalletResponse(
             ExternalAllWalletsResponse externalAllWalletsResponse)
        {

            return new AllWallets
            {
                Response = new AllWalletsResponse
                {
                    Status = externalAllWalletsResponse.Status,
                    Wallets = externalAllWalletsResponse.Wallets.Select(wallets =>
                    {
                        return new AllWalletsResponse.Wallet
                        {
                            AccountName = wallets.AccountName,
                            Status = wallets.Status,
                            AccountNumber = wallets.AccountNumber,
                            AccountReference = wallets.AccountReference,
                            AvailableBalance = wallets.AvailableBalance,
                            BankCode = wallets.BankCode,
                            BankName = wallets.BankName,
                            BookedBalance = wallets.BookedBalance,
                            CreatedAt = wallets.CreatedAt,
                            Email = wallets.Email,
                            FirstName = wallets.FirstName,
                            Id = wallets.Id,
                            LastName = wallets.LastName,
                            UpdatedAt = wallets.UpdatedAt,
                        };
                    }).ToList(),
                }
            };
        }

        private static CustomerWallet ConvertToWalletResponse(
             ExternalCustomerWalletResponse externalCustomerWalletResponse)
        {

            return new CustomerWallet
            {
                Response = new CustomerWalletResponse
                {
                    Status = externalCustomerWalletResponse.Status,
                    Wallet = new CustomerWalletResponse.WalletResponse
                    {
                        UpdatedAt = externalCustomerWalletResponse.Wallet.UpdatedAt,
                        LastName = externalCustomerWalletResponse.Wallet.LastName,
                        Id = externalCustomerWalletResponse.Wallet.Id,
                        FirstName = externalCustomerWalletResponse.Wallet.FirstName,
                        Email = externalCustomerWalletResponse.Wallet.Email,
                        AccountName = externalCustomerWalletResponse.Wallet.AccountName,
                        AccountNumber = externalCustomerWalletResponse.Wallet.AccountNumber,
                        AccountReference = externalCustomerWalletResponse.Wallet.AccountReference,
                        AvailableBalance = externalCustomerWalletResponse.Wallet.AvailableBalance,
                        BankCode = externalCustomerWalletResponse.Wallet.BankCode,
                        BankName = externalCustomerWalletResponse.Wallet.BankName,
                        BookedBalance = externalCustomerWalletResponse.Wallet.BookedBalance,
                        CreatedAt = externalCustomerWalletResponse.Wallet.CreatedAt,
                        CustomerId = externalCustomerWalletResponse.Wallet.CustomerId,
                        Status = externalCustomerWalletResponse.Wallet.Status,
                    },
                }
            };
        }

        private static DebitWallet ConvertToWalletResponse(DebitWallet debitWallet, ExternalDebitWalletResponse externalDebitWalletResponse)
        {
            debitWallet.Response = new DebitWalletResponse
            {
                Message = externalDebitWalletResponse.Message,
                Status = externalDebitWalletResponse.Status,
                Data = new DebitWalletResponse.DataResponse
                {
                    Amount = externalDebitWalletResponse.Data.Amount,
                    CustomerId = externalDebitWalletResponse.Data.CustomerId,
                    CustomerWalletId = externalDebitWalletResponse.Data.CustomerWalletId,
                    Reference = externalDebitWalletResponse.Data.Reference,
                    TransactionFee = externalDebitWalletResponse.Data.TransactionFee,
                    Metadata = new DebitWalletResponse.Metadata
                    {
                        MoreData = externalDebitWalletResponse.Data.Metadata.MoreData,
                        SomeData = externalDebitWalletResponse.Data.Metadata.SomeData
                    }
                }
            };
            return debitWallet;

        }

        private static CustomerCreditCustomerWallet ConvertToWalletResponse(
            CustomerCreditCustomerWallet customerCreditCustomerWallet,
            ExternalCustomerCreditCustomerWalletResponse externalCustomerCreditCustomerWalletResponse)
        {
            customerCreditCustomerWallet.Response = new CustomerCreditCustomerWalletResponse
            {
                Message = externalCustomerCreditCustomerWalletResponse.Message,
                Status = externalCustomerCreditCustomerWalletResponse.Status,
                Data = new CustomerCreditCustomerWalletResponse.DataResponse
                {
                    Accepted = externalCustomerCreditCustomerWalletResponse.Data.Accepted.Select(accepted =>
                    {
                        return new CustomerCreditCustomerWalletResponse.Accepted
                        {
                            Amount = accepted.Amount,
                            CustomerId = accepted.CustomerId,
                            Reference = accepted.Reference,
                        };
                    }).ToList(),
                    Rejected = externalCustomerCreditCustomerWalletResponse.Data.Rejected.Select(rejected =>
                    {
                        return new CustomerCreditCustomerWalletResponse.Rejected
                        {
                            Amount = rejected.Amount,
                            CustomerId = rejected.CustomerId,
                            Reference = rejected.Reference,
                            Reason = rejected.Reason,
                            ReferenceExists = rejected.ReferenceExists,
                        };
                    }).ToList(),
                    BatchReference = externalCustomerCreditCustomerWalletResponse.Data.BatchReference
                }
            };
            return customerCreditCustomerWallet;

        }

        private static CreateWallet ConvertToWalletResponse(
            CreateWallet createWallet,
            ExternalCreateWalletResponse externalCreateWalletResponse)
        {
            createWallet.Response = new CreateWalletResponse
            {
                Customer = new CreateWalletResponse.CustomerResponse
                {
                    Address = externalCreateWalletResponse.Customer.Address,
                    Bvn = externalCreateWalletResponse.Customer.Bvn,
                    BVNFirstName = externalCreateWalletResponse.Customer.BVNFirstName,
                    Currency = externalCreateWalletResponse.Customer.Currency,
                    FirstName = externalCreateWalletResponse.Customer.FirstName,
                    BVNLastName = externalCreateWalletResponse.Customer.BVNLastName,
                    CreatedAt = externalCreateWalletResponse.Customer.CreatedAt,
                    DateOfBirth = externalCreateWalletResponse.Customer.DateOfBirth,
                    Email = externalCreateWalletResponse.Customer.Email,
                    Id = externalCreateWalletResponse.Customer.Id,
                    LastName = externalCreateWalletResponse.Customer.LastName,
                    MerchantId = externalCreateWalletResponse.Customer.MerchantId,
                    Mode = externalCreateWalletResponse.Customer.Mode,
                    NameMatch = externalCreateWalletResponse.Customer.NameMatch,
                    PhoneNumber = externalCreateWalletResponse.Customer.PhoneNumber,
                    Tier = externalCreateWalletResponse.Customer.Tier,
                    UpdatedAt = externalCreateWalletResponse.Customer.UpdatedAt,
                    Metadata = new CreateWalletResponse.Metadata
                    {
                        AdditionalData = externalCreateWalletResponse.Customer.Metadata.AdditionalData,
                        EvenMore = externalCreateWalletResponse.Customer.Metadata.EvenMore
                    }
                },
                Status = externalCreateWalletResponse.Status,
                Wallet = new CreateWalletResponse.WalletResponse
                {
                    Email = externalCreateWalletResponse.Wallet.Email,
                    Status = externalCreateWalletResponse.Wallet.Status,
                    AccountName = externalCreateWalletResponse.Wallet.AccountName,
                    AccountNumber = externalCreateWalletResponse.Wallet.AccountNumber,
                    AccountReference = externalCreateWalletResponse.Wallet.AccountReference,
                    AvailableBalance = externalCreateWalletResponse.Wallet.AvailableBalance,
                    BankCode = externalCreateWalletResponse.Wallet.BankCode,
                    BankName = externalCreateWalletResponse.Wallet.BankName,
                    BookedBalance = externalCreateWalletResponse.Wallet.BookedBalance,
                    CreatedAt = externalCreateWalletResponse.Wallet.CreatedAt,
                    Currency = externalCreateWalletResponse.Wallet.Currency,
                    Id = externalCreateWalletResponse.Wallet.Id,
                    Mode = externalCreateWalletResponse.Wallet.Mode,
                    Updated = externalCreateWalletResponse.Wallet.Updated,
                    UpdatedAt = externalCreateWalletResponse.Wallet.UpdatedAt,
                    WalletId = externalCreateWalletResponse.Wallet.WalletId,
                    WalletType = externalCreateWalletResponse.Wallet.WalletType,
                },

            };
            return createWallet;

        }

        private static CreditWallet ConvertToWalletResponse(CreditWallet creditWallet, ExternalCreditWalletResponse externalCreditWalletResponse)
        {
            creditWallet.Response = new CreditWalletResponse
            {
                Amount = externalCreditWalletResponse.Amount,
                Message = externalCreditWalletResponse.Message,
                Reference = externalCreditWalletResponse.Reference,
                Status = externalCreditWalletResponse.Status,
            };
            return creditWallet;

        }

        private static FreezeWallet ConvertToWalletResponse(FreezeWallet freezeWallet, ExternalFreezeWalletResponse externalFreezeWalletResponse)
        {
            freezeWallet.Response = new FreezeWalletResponse
            {

                Message = externalFreezeWalletResponse.Message,
                Status = externalFreezeWalletResponse.Status,
            };
            return freezeWallet;

        }

        private static FundMerchantSandBoxWallet ConvertToWalletResponse(FundMerchantSandBoxWallet fundMerchantSandBoxWallet, ExternalFundMerchantSandBoxWalletResponse externalFundMerchantSandBoxWalletResponse)
        {
            fundMerchantSandBoxWallet.Response = new FundMerchantSandBoxWalletResponse
            {

                Message = externalFundMerchantSandBoxWalletResponse.Message,
                Status = externalFundMerchantSandBoxWalletResponse.Status,
            };
            return fundMerchantSandBoxWallet;

        }

        private static UnfreezeWallet ConvertToWalletResponse(UnfreezeWallet unfreezeWallet, ExternalUnfreezeWalletResponse externalUnfreezeWalletResponse)
        {
            unfreezeWallet.Response = new UnfreezeWalletResponse
            {

                Message = externalUnfreezeWalletResponse.Message,
                Status = externalUnfreezeWalletResponse.Status,
            };
            return unfreezeWallet;

        }



        private static ExternalUnfreezeWalletResponse CreateExternalUnfreezeWalletResponseResult() =>
                CreateExternalUnfreezeWalletResponseFiller().Create();

        private static ExternalBatchDebitCustomerWalletsResponse CreateExternalBatchDebitCustomerWalletsResponseResult() =>
           CreateExternalBatchDebitCustomerWalletsResponseFiller().Create();
        private static ExternalBatchCreditCustomerWalletsResponse CreateExternalBatchCreditCustomerWalletsResponseResult() =>
           CreateExternalBatchCreditCustomerWalletsResponseFiller().Create();

        private static ExternalAllWalletsResponse CreateExternalAllWalletsResponseResult() =>
          CreateExternalAllWalletsResponseFiller().Create();

        private static ExternalDebitWalletResponse CreateExternalDebitWalletResponseResult() =>
           CreateExternalDebitWalletResponseFiller().Create();
        private static ExternalFundMerchantSandBoxWalletResponse CreateExternalFundMerchantSandBoxWalletResponseResult() =>
            CreateExternalFundMerchantSandBoxWalletResponseFiller().Create();

        private static ExternalFreezeWalletResponse CreateExternalFreezeWalletResponseResult() =>
            CreateExternalFreezeWalletResponseFiller().Create();

        private static ExternalCreditWalletResponse CreateExternalCreditWalletResponseResult() =>
             CreateExternalCreditWalletResponseFiller().Create();

        private static ExternalCreateWalletResponse CreateExternalCreateWalletResponseResult() =>
             CreateExternalCreateWalletResponseFiller().Create();

        private static ExternalCustomerCreditCustomerWalletResponse CreateExternalCustomerCreditCustomerWalletResponseResult() =>
            CreateExternalCustomerCreditCustomerWalletResponseFiller().Create();
        private static ExternalCustomerWalletResponse CreateExternalCustomerWalletResponseResult() =>
             CreateExternalCustomerWalletResponseFiller().Create();


        private static UnfreezeWallet CreateUnfreezeWalletResponseResult() =>
          CreateUnfreezeWalletFiller().Create();
        private static FundMerchantSandBoxWallet CreateFundMerchantSandBoxWalletResponseResult() =>
          CreateFundMerchantSandBoxWalletFiller().Create();
        private static FreezeWallet CreateFreezeWalletResponseResult() =>
          CreateFreezeWalletFiller().Create();
        private static CreditWallet CreateCreditWalletResponseResult() =>
          CreateCreditWalletFiller().Create();
        private static CreateWallet CreateCreateWalletResponseResult() =>
          CreateCreateWalletFiller().Create();
        private static DebitWallet CreateDebitWalletResponseResult() =>
          CreateDebitWalletFiller().Create();
        private static BatchCreditCustomerWallets CreateBatchCreditCustomerWalletsResponseResult() =>
        CreateBatchCreditCustomerWalletsFiller().Create();
        private static BatchDebitCustomerWallets CreateBatchDebitCustomerWalletsResponseResult() =>
          CreateBatchDebitCustomerWalletsFiller().Create();
        private static CustomerCreditCustomerWallet CreateCustomerCreditCustomerWalletResponseResult() =>
          CreateCustomerCreditCustomerWalletFiller().Create();


        private static Filler<ExternalUnfreezeWalletResponse> CreateExternalUnfreezeWalletResponseFiller()
        {
            var filler = new Filler<ExternalUnfreezeWalletResponse>();

            filler.Setup()
               .OnType<object>().IgnoreIt();

            return filler;
        }
        private static Filler<ExternalBatchDebitCustomerWalletsResponse> CreateExternalBatchDebitCustomerWalletsResponseFiller()
        {
            var filler = new Filler<ExternalBatchDebitCustomerWalletsResponse>();

            filler.Setup()
               .OnType<List<object>>().IgnoreIt();

            return filler;
        }
        private static Filler<ExternalBatchCreditCustomerWalletsResponse> CreateExternalBatchCreditCustomerWalletsResponseFiller()
        {
            var filler = new Filler<ExternalBatchCreditCustomerWalletsResponse>();

            filler.Setup()
               .OnType<object>().IgnoreIt();

            return filler;
        }
        private static Filler<ExternalDebitWalletResponse> CreateExternalDebitWalletResponseFiller()
        {
            var filler = new Filler<ExternalDebitWalletResponse>();

            filler.Setup()
               .OnType<object>().IgnoreIt();

            return filler;
        }
        private static Filler<ExternalAllWalletsResponse> CreateExternalAllWalletsResponseFiller()
        {
            var filler = new Filler<ExternalAllWalletsResponse>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<ExternalFundMerchantSandBoxWalletResponse> CreateExternalFundMerchantSandBoxWalletResponseFiller()
        {
            var filler = new Filler<ExternalFundMerchantSandBoxWalletResponse>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<ExternalFreezeWalletResponse> CreateExternalFreezeWalletResponseFiller()
        {
            var filler = new Filler<ExternalFreezeWalletResponse>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<ExternalCreditWalletResponse> CreateExternalCreditWalletResponseFiller()
        {
            var filler = new Filler<ExternalCreditWalletResponse>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<ExternalCreateWalletResponse> CreateExternalCreateWalletResponseFiller()
        {
            var filler = new Filler<ExternalCreateWalletResponse>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<ExternalCustomerCreditCustomerWalletResponse> CreateExternalCustomerCreditCustomerWalletResponseFiller()
        {
            var filler = new Filler<ExternalCustomerCreditCustomerWalletResponse>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<ExternalCustomerWalletResponse> CreateExternalCustomerWalletResponseFiller()
        {
            var filler = new Filler<ExternalCustomerWalletResponse>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }


        private static Filler<UnfreezeWallet> CreateUnfreezeWalletFiller()
        {
            var filler = new Filler<UnfreezeWallet>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<FundMerchantSandBoxWallet> CreateFundMerchantSandBoxWalletFiller()
        {
            var filler = new Filler<FundMerchantSandBoxWallet>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<FreezeWallet> CreateFreezeWalletFiller()
        {
            var filler = new Filler<FreezeWallet>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<CreditWallet> CreateCreditWalletFiller()
        {
            var filler = new Filler<CreditWallet>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<CreateWallet> CreateCreateWalletFiller()
        {
            var filler = new Filler<CreateWallet>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<BatchDebitCustomerWallets> CreateBatchDebitCustomerWalletsFiller()
        {
            var filler = new Filler<BatchDebitCustomerWallets>();

            filler.Setup()
                .OnType<List<object>>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<DebitWallet> CreateDebitWalletFiller()
        {
            var filler = new Filler<DebitWallet>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<BatchCreditCustomerWallets> CreateBatchCreditCustomerWalletsFiller()
        {
            var filler = new Filler<BatchCreditCustomerWallets>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<CustomerCreditCustomerWallet> CreateCustomerCreditCustomerWalletFiller()
        {
            var filler = new Filler<CustomerCreditCustomerWallet>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }
        public void Dispose() => wireMockServer.Stop();
    }
}
