using FluentAssertions.Equivalency;
using KellermanSoftware.CompareNetObjects;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.DataCollection;
using Moq;
using Providus.XpressWallet.Core.Brokers.DateTimes;
using Providus.XpressWallet.Core.Brokers.XpressWallet;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalTransactions;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Wallet;
using Providus.XpressWallet.Core.Services.Foundations.XpressWallet.Transactions;
using RESTFulSense.Exceptions;
using System.Data;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using Tynamix.ObjectFiller;


namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.Transactions
{
    public partial class TransactionsServiceTests
    {

        private readonly Mock<IXpressWalletBroker> xPressWalletBrokerMock;
        private readonly Mock<IDateTimeBroker> dateTimeBrokerMock;
        private readonly ICompareLogic compareLogic;
        private readonly ITransactionsService transactionsService;

        public TransactionsServiceTests()
        {
            xPressWalletBrokerMock = new Mock<IXpressWalletBroker>();
            dateTimeBrokerMock = new Mock<IDateTimeBroker>();
            compareLogic = new CompareLogic();

            transactionsService = new TransactionsService(
                xPressWalletBrokerMock.Object,
                dateTimeBroker: dateTimeBrokerMock.Object);
        }


        private Expression<Func<ExternalReverseBatchTransactionRequest, bool>> SameExternalReverseBatchTransactionRequestAs(
             ExternalReverseBatchTransactionRequest expectedExternalReverseBatchTransactionRequest)
        {
            return actualExternalReverseBatchTransactionRequest =>
                this.compareLogic.Compare(
                    expectedExternalReverseBatchTransactionRequest,
                    actualExternalReverseBatchTransactionRequest)
                        .AreEqual;
        }

        private Expression<Func<ExternalApproveTransactionRequest, bool>> SameExternalApproveTransactionRequestAs(
             ExternalApproveTransactionRequest expectedExternalApproveTransactionRequest)
        {
            return actualExternalApproveTransactionRequest =>
                this.compareLogic.Compare(
                    expectedExternalApproveTransactionRequest,
                    actualExternalApproveTransactionRequest)
                        .AreEqual;
        }

   

        private static DateTime GetRandomDate() =>
            new DateTimeRange(earliestDate: new DateTime()).GetValue();

        private static string GetRandomString() =>
           new MnemonicString().GetValue();

        private static int GetRandomNumber() =>
            new IntRange(min: 2, max: 10).GetValue();

        private static string[] CreateRandomStringArray() =>
            new Filler<string[]>().Create();

        private static List<string> GetRandomStringList() =>
          new Filler<List<string>>().Create();


        private static bool GetRandomBoolean() =>
            Randomizer<bool>.Create();

        private static Dictionary<string, int> CreateRandomDictionary() =>
            new Filler<Dictionary<string, int>>().Create();


        #region ReverseBatchTransactionRequest 

        private static dynamic CreateRandomReverseBatchTransactionRequestProperties()
        {
            return new
            {

                BatchReference = GetRandomString(),
       

            };
        }




        #endregion

        #region ReverseBatchTransactionResponse 

        private static dynamic CreateRandomReverseBatchTransactionResponseProperties()
        {
            return new
            {
                
                 Status = GetRandomBoolean(),
                 Message = GetRandomString(),
    
            };
        }


        #endregion

        #region ApproveTransactionRequest 

        private static dynamic CreateRandomApproveTransactionRequestProperties()
        {
            return new
            {

                TransactionId = GetRandomString(),

            };
        }




        #endregion

        #region ApproveTransactionResponse 

        private static dynamic CreateRandomApproveTransactionResponseProperties()
        {
            return new
            {

                Status = GetRandomBoolean(),
                Message = GetRandomString(),

            };
        }


        #endregion

        #region MerchantTransactionsResponse 

        private static dynamic CreateRandomMerchantTransactionsResponseProperties()
        {
            return new
            {

                Status = GetRandomBoolean(),
                Transactions = GetRandomMerchantTransactionsResponseTransactions(),
                Metadata = GetRandomMerchantTransactionsResponseMetaData(),

            };
        } 

        private static dynamic GetRandomMerchantTransactionsResponseMetaData()
        {

            return  new
            {

                Amount = GetRandomString(),
                Currency = GetRandomString(),
                DestinationBankCode = GetRandomString(),
                DestinationAccountNumber = GetRandomString(),
                Bvn = GetRandomString(),
                DateOfBirth = GetRandomString(),
                PhoneNumber = GetRandomString(),
                LastName = GetRandomString(),
                FirstName = GetRandomString(),
                BVNLastName = GetRandomString(),
                BVNFirstName = GetRandomString(),
                NameMatch = GetRandomBoolean(),
                Email = GetRandomString(),
                CustomerWallet = GetRandomString(),
                CustomerName = GetRandomString(),
                Page = GetRandomNumber(),
                TotalRecords = GetRandomNumber(),
                TotalPages = GetRandomNumber(),




            };

        }

        private static List<dynamic> GetRandomMerchantTransactionsResponseTransactions()
        {

            return Enumerable.Range(0, GetRandomNumber()).Select(
            item => new
            {
                Id = GetRandomString(),
                Category = GetRandomString(),
                Currency = GetRandomString(),
                Amount = GetRandomNumber(),
                Metadata = GetRandomMerchantTransactionsResponseMetaData(),
                BalanceAfter = GetRandomNumber(),
                BalanceBefore = GetRandomNumber(),
                Reference = GetRandomString(),
                Source = GetRandomString(),
                Destination = GetRandomString(),
                Type = GetRandomString(),
                Description = GetRandomString(),
                Mode = GetRandomString(),
                Completed = GetRandomBoolean(),
                CreatedAt = GetRandomDate(),
                UpdatedAt = GetRandomDate(),




            }).ToList<dynamic>();

        }

        #endregion

        #region TransactionDetailsResponse 

        private static dynamic CreateRandomTransactionDetailsResponseProperties()
        {
            return new
            {

                Status = GetRandomBoolean(),
                Transaction = GetRandomTransactionDetailsResponseMetaData(),

            };
        }

        private static dynamic GetRandomTransactionDetailsResponseMetaData()
        {

            return new
            {

                Id = GetRandomString(),
                Category = GetRandomString(),
                Currency = GetRandomString(),
                Amount = GetRandomNumber(),
                Metadata = new object(),
                BalanceAfter = GetRandomNumber(),
                BalanceBefore = GetRandomNumber(),
                Reference = GetRandomString(),
                Source = new object(),
                Destination = new object(),
                Type = GetRandomString(),
                Description = GetRandomString(),
                Completed = GetRandomBoolean(),
                CreatedAt = GetRandomDate(),
                UpdatedAt = GetRandomDate(),





            };

        }



        #endregion

        #region CustomerTransactionsResponse 

        private static dynamic CreateRandomCustomerTransactionsResponseProperties()
        {
            return new
            {

                Status = GetRandomBoolean(),
                Transactions = GetRandomCustomerTransactionsResponseTransactions(),
                Metadata = GetRandomCustomerTransactionsResponseMetaData(),

            };
        }

        private static dynamic GetRandomCustomerTransactionsResponseMetaData()
        {

            return new
            {

                Page = GetRandomNumber(),
                TotalRecords = GetRandomNumber(),
                TotalPages = GetRandomNumber(),

            };

        }

        private static List<dynamic> GetRandomCustomerTransactionsResponseTransactions()
        {

            return Enumerable.Range(0, GetRandomNumber()).Select(
            item => new
            {
                Id = GetRandomString(),
                UserId = GetRandomString(),
                Category = GetRandomString(),
                Currency = GetRandomString(),
                Amount = GetRandomNumber(),
                Metadata = new object(),
                BalanceAfter = GetRandomNumber(),
                BalanceBefore = GetRandomNumber(),
                Reference = GetRandomString(),
                Source = new object(),
                Destination = new object(),
                Type = GetRandomString(),
                Description = GetRandomString(),
                Mode = GetRandomString(),
                Completed = GetRandomBoolean(),
                CreatedAt = GetRandomDate(),
                UpdatedAt = GetRandomDate(),





            }).ToList<dynamic>();

        }

        #endregion

        #region BatchTransactionsResponse 

        private static dynamic CreateRandomBatchTransactionsResponseProperties()
        {
            return new
            {

                Status = GetRandomBoolean(),
                Data = GetRandomBatchTransactionsResponseData(),
                Metadata = GetRandomBatchTransactionsResponseMetaData(),

            };
        }

        private static dynamic GetRandomBatchTransactionsResponseMetaData()
        {

            return new
            {

                Page = GetRandomNumber(),
                TotalRecords = GetRandomNumber(),
                TotalPages = GetRandomNumber(),

            };

        }

        private static dynamic GetRandomBatchTransactionsResponseSource()
        {

            return new
            {

                Type = GetRandomString(),
                UserId = GetRandomString(),
                WalletId = GetRandomString(),


            };

        }

        private static List<dynamic> GetRandomBatchTransactionsResponseData()
        {

            return Enumerable.Range(0, GetRandomNumber()).Select(
            item => new
            {
                Id = GetRandomString(),
                Type = GetRandomString(),
                Source = GetRandomBatchTransactionsResponseSource(),
                Reference = GetRandomString(),
                Reversed = GetRandomBoolean(),
                AllReferences = GetRandomStringList(),
                PassedReferences = GetRandomStringList(),
                FailedReferences = new List<object>(),
                CreatedAt = GetRandomDate(),
                UpdatedAt = GetRandomDate(),






            }).ToList<dynamic>();

        }

        #endregion

        #region BatchTransactionDetailsResponse 

        private static dynamic CreateRandomBatchTransactionDetailsResponseProperties()
        {
            return new
            {

                Status = GetRandomBoolean(),
                Data = GetRandomBatchTransactionDetailsResponseData(),
       

            };
        }

   

        private static dynamic GetRandomBatchTransactionDetailsResponseSource()
        {

            return new
            {

                Type = GetRandomString(),
                UserId = GetRandomString(),
                WalletId = GetRandomString(),


            };

        }

        private static dynamic GetRandomBatchTransactionDetailsResponseData()
        {

            return  new
            {
                Id = GetRandomString(),
                Type = GetRandomString(),
                Source = GetRandomBatchTransactionDetailsResponseSource(),
                Reference = GetRandomString(),
                Reversed = GetRandomBoolean(),
                AllReferences = GetRandomStringList(),
                PassedReferences = GetRandomStringList(),
                FailedReferences = new List<object>(),
                CreatedAt = GetRandomDate(),
                UpdatedAt = GetRandomDate(),






            };

        }

        #endregion

        #region PendingTransactionResponse 

        private static dynamic CreateRandomPendingTransactionResponseProperties()
        {
            return new
            {

                Status = GetRandomBoolean(),
                Data = GetRandomPendingTransactionResponseData(),
                Metadata = GetRandomPendingTransactionResponseMetaData(),

            };
        }

        private static dynamic GetRandomPendingTransactionResponseMetaData()
        {

            return new
            {

                Amount = GetRandomNumber(),
                SortCode = GetRandomString(),
                Narration = GetRandomString(),
                CustomerId = GetRandomString(),
                AccountName = GetRandomString(),
                CustomData = GetRandomPendingTransactionResponseCustomDataData(),
                AccountNumber = GetRandomString(),
                BankName = GetRandomString(),
                Page = GetRandomNumber(),
                TotalRecords = GetRandomNumber(),
                TotalPages = GetRandomNumber(),


            };

        }

        private static dynamic GetRandomPendingTransactionResponseCustomDataData()
        {

            return new
            {

                CustomerData = GetRandomString(),
               


            };

        }

        private static dynamic GetRandomPendingTransactionResponseSource()
        {

            return new
            {

                Type = GetRandomString(),
                UserId = GetRandomString(),
                WalletId = GetRandomString(),


            };

        }

        private static List<dynamic> GetRandomPendingTransactionResponseData()
        {

            return Enumerable.Range(0, GetRandomNumber()).Select(
            item => new
            {
                
                Id = GetRandomString(),
                Mode = GetRandomString(),
                Type = GetRandomString(),
                Creator = GetRandomString(),
                Status = GetRandomString(),
                MerchantId = GetRandomString(),
                Category = GetRandomString(),
                ApprovedBy = new object(),
                Metadata = GetRandomPendingTransactionResponseMetaData(),
                Amount = GetRandomNumber(),
                CreatedAt = GetRandomDate(),
                UpdatedAt = GetRandomDate(),





            }).ToList<dynamic>();

        }

        #endregion

        #region DeclinePendingTransactionResponse 

        private static dynamic CreateRandomDeclinePendingTransactionResponseProperties()
        {
            return new
            {

                Status = GetRandomBoolean(),
                Message = GetRandomString(),

            };
        }


        #endregion

        #region DownloadCustomerTransactionResponse 

        private static dynamic CreateRandomDownloadCustomerTransactionResponseProperties()
        {
            return new
            {

                Status = GetRandomBoolean(),
                Data = GetRandomDownloadCustomerTransactionResponseData(),
          

            };
        }

        private static dynamic GetRandomDownloadCustomerTransactionResponseMetaData()
        {

            return new
            {

                TargetCustomerId = GetRandomString(),
                SourceCustomerId = GetRandomString(),
                TargetCustomerWallet = GetRandomString(),
                SourceCustomerWallet = GetRandomString(),
                Amount = GetRandomNumber(),
                Charges = GetRandomNumber(),
                BankName = GetRandomString(),
                Vat = GetRandomNumber(),
                WalletId = GetRandomString(),
                SortCode = GetRandomString(),
                Narration = GetRandomString(),
                CustomerId = GetRandomString(),
                AccountName = GetRandomString(),
                TotalAmount = GetRandomNumber(),
                AccountNumber = GetRandomString(),
                WalletAccountName = GetRandomString(),
                AdditionalMetadata = GetRandomDownloadCustomerTransactionResponseAdditionalMetaData(),
                WalletAccountNumber = GetRandomString(),
                MerchantId = GetRandomString(),
                NameEnquiryRef = GetRandomString(),
                SessionID = GetRandomString(),
                Fee = GetRandomNumber(),
                CustomData = GetRandomDownloadCustomerTransactionResponseCustomData(),
                CustomerWallet = GetRandomString(),
                CustomerName = GetRandomString(),




            };

        }

        private static dynamic GetRandomDownloadCustomerTransactionResponseCustomData()
        {

            return new
            {

                SomeData = GetRandomString(),
                MoreData = GetRandomString(),
       




            };

        }

        private static dynamic GetRandomDownloadCustomerTransactionResponseAdditionalMetaData()
        {

            return new
            {

         
                CustomerData = GetRandomString(),




            };

        }

        private static List<dynamic> GetRandomDownloadCustomerTransactionResponseData()
        {

            return Enumerable.Range(0, GetRandomNumber()).Select(
            item => new
            {

                SomeData = GetRandomString(),
                MoreData = GetRandomString(),
                Id = GetRandomString(),
                Fee = GetRandomNumber(),
                Vat = GetRandomNumber(),
                Total = GetRandomNumber(),
                Category = GetRandomString(),
                Currency = GetRandomString(),
                Amount = GetRandomNumber(),
                Metadata = GetRandomDownloadCustomerTransactionResponseMetaData(),
                BalanceAfter = GetRandomNumber(),
                BalanceBefore = GetRandomNumber(),
                Reference = GetRandomString(),
                Source = GetRandomString(),
                Destination = GetRandomString(),
                Type = GetRandomString(),
                Description = GetRandomString(),
                Status = GetRandomString(),
                CreatedAt = GetRandomDate(),
                UpdatedAt = GetRandomDate(),







            }).ToList<dynamic>();

        }

        #endregion

        #region DownloadMerchantTransactionResponse 

        private static dynamic CreateRandomDownloadMerchantTransactionResponseProperties()
        {
            return new
            {

                Status = GetRandomBoolean(),
                Data = GetRandomDownloadMerchantTransactionResponseData(),

            };
        }

        private static List<dynamic> GetRandomDownloadMerchantTransactionResponseData()
        {

            return Enumerable.Range(0, GetRandomNumber()).Select(
            item => new
            {
                Id = GetRandomString(),
                Fee = GetRandomNumber(),
                Vat = GetRandomNumber(),
                Total = GetRandomNumber(),
                Category = GetRandomString(),
                Currency = GetRandomString(),
                Amount = GetRandomNumber(),
                Metadata = new object(),
                BalanceAfter = GetRandomNumber(),
                BalanceBefore = GetRandomNumber(),
                Reference = GetRandomString(),
                Source = GetRandomString(),
                Destination = GetRandomString(),
                Type = GetRandomString(),
                Description = GetRandomString(),
                Status = GetRandomString(),
                CreatedAt = GetRandomDate(),
                UpdatedAt = GetRandomDate(),




            }).ToList<dynamic>();

        }

        #endregion

    
       

        public static TheoryData UnauthorizedExceptions()
        {
            return new TheoryData<HttpResponseException>
            {
                new HttpResponseUnauthorizedException(),
                new HttpResponseForbiddenException()
            };
        }



    }
}
