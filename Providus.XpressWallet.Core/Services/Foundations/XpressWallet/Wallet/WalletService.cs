using Providus.XpressWallet.Core.Brokers.DateTimes;
using Providus.XpressWallet.Core.Brokers.XpressWallet;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalWallet;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Wallet;

namespace Providus.XpressWallet.Core.Services.Foundations.XpressWallet.Wallet
{
    internal partial class WalletService : IWalletService
    {
        private readonly IXpressWalletBroker xPressWalletBroker;
        private readonly IDateTimeBroker dateTimeBroker;

        public WalletService(
            IXpressWalletBroker xPressWalletBroker,
            IDateTimeBroker dateTimeBroker)
        {
            this.xPressWalletBroker = xPressWalletBroker;
            this.dateTimeBroker = dateTimeBroker;
        }

        public ValueTask<AllWallets> GetAllWalletsRequestAsync()=>
        TryCatch(async () =>
        {
            ExternalAllWalletsResponse externalAllWalletsResponse = await xPressWalletBroker.GetAllWalletsAsync();
            return ConvertToWalletResponse(externalAllWalletsResponse);
        });

        public ValueTask<CustomerWallet> GetCustomerWalletRequestAsync(string customerId) =>
        TryCatch(async () =>
        {
            ValidateCustomerWalletParameters(customerId);
            ExternalCustomerWalletResponse externalCustomerWalletResponse = 
                await xPressWalletBroker.GetCustomerWalletAsync(customerId);
            return ConvertToWalletResponse(externalCustomerWalletResponse);
        });

        public ValueTask<BatchCreditCustomerWallets> PostBatchCreditCustomerWalletsRequestAsync(
            BatchCreditCustomerWallets externalBatchCreditCustomerWallets)=>
        TryCatch(async () =>
        {
            ValidateBatchCreditCustomerWallets(externalBatchCreditCustomerWallets);
            ExternalBatchCreditCustomerWalletsRequest externalBatchCreditCustomerWalletsRequest = ConvertToWalletRequest(externalBatchCreditCustomerWallets);
            ExternalBatchCreditCustomerWalletsResponse externalBatchCreditCustomerWalletsResponse = await xPressWalletBroker.PostBatchCreditCustomerWalletsAsync(externalBatchCreditCustomerWalletsRequest);
            return ConvertToWalletResponse(externalBatchCreditCustomerWallets, externalBatchCreditCustomerWalletsResponse);
        });

        public ValueTask<BatchDebitCustomerWallets> PostBatchDebitCustomerWalletsRequestAsync(
            BatchDebitCustomerWallets externalBatchDebitCustomerWallets)=>
        TryCatch(async () =>
        {
            ValidateBatchDebitCustomerWallets(externalBatchDebitCustomerWallets);
            ExternalBatchDebitCustomerWalletsRequest externalBatchDebitCustomerWalletsRequest = 
                ConvertToWalletRequest(externalBatchDebitCustomerWallets);
            ExternalBatchDebitCustomerWalletsResponse externalBatchDebitCustomerWalletsResponse = 
                await xPressWalletBroker.PostBatchDebitCustomerWalletsAsync(externalBatchDebitCustomerWalletsRequest);
            return ConvertToWalletResponse(externalBatchDebitCustomerWallets, externalBatchDebitCustomerWalletsResponse);
        });

        public ValueTask<CreateWallet> PostCreateWalletRequestAsync(
            CreateWallet externalCreateWallet)=>
        TryCatch(async () =>
        {
            ValidateCreateWallet(externalCreateWallet);
            ExternalCreateWalletRequest externalCreateWalletRequest =
                ConvertToWalletRequest(externalCreateWallet);
            ExternalCreateWalletResponse externalCreateWalletResponse = 
                await xPressWalletBroker.PostCreateWalletAsync(externalCreateWalletRequest);
            return ConvertToWalletResponse(externalCreateWallet, externalCreateWalletResponse);
        });

        public ValueTask<CreditWallet> PostCreditWalletRequestAsync(
            CreditWallet externalCreditWallet)=>
        TryCatch(async () =>
        {
            ValidateCreditWallet(externalCreditWallet);
            ExternalCreditWalletRequest externalCreditWalletRequest = ConvertToWalletRequest(externalCreditWallet);
            ExternalCreditWalletResponse externalCreditWalletResponse = await xPressWalletBroker.PostCreditWalletAsync(externalCreditWalletRequest);
            return ConvertToWalletResponse(externalCreditWallet, externalCreditWalletResponse);
        });

        public ValueTask<CustomerCreditCustomerWallet> PostCustomerCreditCustomerWalletRequestAsync(
            CustomerCreditCustomerWallet externalCustomerCreditCustomerWallet)=>
        TryCatch(async () =>
        {
            ValidateCustomerCreditCustomerWallet(externalCustomerCreditCustomerWallet);
            ExternalCustomerCreditCustomerWalletRequest externalCustomerCreditCustomerWalletRequest =
                ConvertToWalletRequest(externalCustomerCreditCustomerWallet);
            ExternalCustomerCreditCustomerWalletResponse externalCustomerCreditCustomerWalletResponse =
                await xPressWalletBroker.PostCustomerCreditCustomerWalletAsync(externalCustomerCreditCustomerWalletRequest);
            return ConvertToWalletResponse(externalCustomerCreditCustomerWallet, externalCustomerCreditCustomerWalletResponse);
        });

        public ValueTask<DebitWallet> PostDebitWalletRequestAsync(
            DebitWallet externalDebitWallet)=>
        TryCatch(async () =>
        {
            ValidateDebitWallet(externalDebitWallet);
            ExternalDebitWalletRequest externalDebitWalletRequest = ConvertToWalletRequest(externalDebitWallet);
            ExternalDebitWalletResponse externalDebitWalletResponse = await xPressWalletBroker.PostDebitWalletAsync(externalDebitWalletRequest);
            return ConvertToWalletResponse(externalDebitWallet, externalDebitWalletResponse);
        });

        public ValueTask<FreezeWallet> PostFreezeWalletRequestAsync(
            FreezeWallet externalFreezeWallet)=>
        TryCatch(async () =>
        {
            ValidateFreezeWallet(externalFreezeWallet);
            ExternalFreezeWalletRequest externalFreezeWalletRequest = ConvertToWalletRequest(externalFreezeWallet);
            ExternalFreezeWalletResponse externalFreezeWalletResponse = await xPressWalletBroker.PostFreezeWalletAsync(externalFreezeWalletRequest);
            return ConvertToWalletResponse(externalFreezeWallet, externalFreezeWalletResponse);
        });

        public ValueTask<FundMerchantSandBoxWallet> PostFundMerchantSandBoxWalletRequestAsync(
            FundMerchantSandBoxWallet externalFundMerchantSandBoxWallet)=>
        TryCatch(async () =>
        {
            ValidateFundMerchantSandBoxWallet(externalFundMerchantSandBoxWallet);
            ExternalFundMerchantSandBoxWalletRequest externalFundMerchantSandBoxWalletRequest = ConvertToWalletRequest(externalFundMerchantSandBoxWallet);
            ExternalFundMerchantSandBoxWalletResponse externalFundMerchantSandBoxWalletResponse = await xPressWalletBroker.PostFundMerchantSandBoxWalletAsync(externalFundMerchantSandBoxWalletRequest);
            return ConvertToWalletResponse(externalFundMerchantSandBoxWallet, externalFundMerchantSandBoxWalletResponse);
        });

        public ValueTask<UnfreezeWallet> PostUnfreezeWalletRequestAsync(
            UnfreezeWallet externalUnfreezeWallet)=>
        TryCatch(async () =>
        {
            ValidateUnfreezeWallet(externalUnfreezeWallet);
            ExternalUnfreezeWalletRequest externalUnfreezeWalletRequest = 
                ConvertToWalletRequest(externalUnfreezeWallet);
            ExternalUnfreezeWalletResponse externalUnfreezeWalletResponse =
                await xPressWalletBroker.PostUnfreezeWalletAsync(externalUnfreezeWalletRequest);
            return ConvertToWalletResponse(externalUnfreezeWallet, externalUnfreezeWalletResponse);
        });





        private static ExternalBatchCreditCustomerWalletsRequest ConvertToWalletRequest(
            BatchCreditCustomerWallets  batchCreditCustomerWallets)
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
            BatchDebitCustomerWallets  batchDebitCustomerWallets)
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
        private static ExternalCreateWalletRequest ConvertToWalletRequest(CreateWallet  createWallet)
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
        private static ExternalCreditWalletRequest ConvertToWalletRequest(CreditWallet  creditWallet)
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
        private static ExternalUnfreezeWalletRequest ConvertToWalletRequest(UnfreezeWallet  unfreezeWallet)
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

    }
}
