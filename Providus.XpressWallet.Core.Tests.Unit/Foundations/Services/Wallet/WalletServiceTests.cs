using FluentAssertions.Equivalency;
using FluentAssertions.Execution;
using KellermanSoftware.CompareNetObjects;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Moq;
using Providus.XpressWallet.Core.Brokers.DateTimes;
using Providus.XpressWallet.Core.Brokers.XpressWallet;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalWallet;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Wallet;
using Providus.XpressWallet.Core.Services.Foundations.XpressWallet.Wallet;
using RESTFulSense.Exceptions;
using System.Data;
using System.Linq.Expressions;
using System.Net;
using System.Net.NetworkInformation;
using Tynamix.ObjectFiller;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.Wallet
{
    public partial class WalletServiceTests
    {

        private readonly Mock<IXpressWalletBroker> xPressWalletBrokerMock;
        private readonly Mock<IDateTimeBroker> dateTimeBrokerMock;
        private readonly ICompareLogic compareLogic;
        private readonly IWalletService walletService;

        public WalletServiceTests()
        {
            xPressWalletBrokerMock = new Mock<IXpressWalletBroker>();
            dateTimeBrokerMock = new Mock<IDateTimeBroker>();
            compareLogic = new CompareLogic();

            walletService = new WalletService(
                xPressWalletBrokerMock.Object,
                dateTimeBroker: dateTimeBrokerMock.Object);
        }


        private Expression<Func<ExternalFundMerchantSandBoxWalletRequest, bool>> SameExternalFundMerchantSandBoxWalletRequestAs(
             ExternalFundMerchantSandBoxWalletRequest expectedExternalFundMerchantSandBoxWalletRequest)
        {
            return actualExternalFundMerchantSandBoxWalletRequest =>
                this.compareLogic.Compare(
                    expectedExternalFundMerchantSandBoxWalletRequest,
                    actualExternalFundMerchantSandBoxWalletRequest)
                        .AreEqual;
        }

        private Expression<Func<ExternalCustomerCreditCustomerWalletRequest, bool>> SameExternalCustomerCreditCustomerWalletRequestAs(
             ExternalCustomerCreditCustomerWalletRequest expectedExternalCustomerCreditCustomerWalletRequest)
        {
            return actualExternalCustomerCreditCustomerWalletRequest =>
                this.compareLogic.Compare(
                    expectedExternalCustomerCreditCustomerWalletRequest,
                    actualExternalCustomerCreditCustomerWalletRequest)
                        .AreEqual;
        }

        private Expression<Func<ExternalBatchCreditCustomerWalletsRequest, bool>> SameExternalBatchCreditCustomerWalletsRequestAs(
            ExternalBatchCreditCustomerWalletsRequest expectedExternalBatchCreditCustomerWalletsRequest)
        {
            return actualExternalBatchCreditCustomerWalletsRequest =>
                this.compareLogic.Compare(
                    expectedExternalBatchCreditCustomerWalletsRequest,
                    actualExternalBatchCreditCustomerWalletsRequest)
                        .AreEqual;
        }

        private Expression<Func<ExternalBatchDebitCustomerWalletsRequest, bool>> SameExternalBatchDebitCustomerWalletsRequestAs(
            ExternalBatchDebitCustomerWalletsRequest expectedExternalBatchDebitCustomerWalletsRequest)
        {
            return actualExternalBatchDebitCustomerWalletsRequest =>
                this.compareLogic.Compare(
                    expectedExternalBatchDebitCustomerWalletsRequest,
                    actualExternalBatchDebitCustomerWalletsRequest)
                        .AreEqual;
        }

        private Expression<Func<ExternalUnfreezeWalletRequest, bool>> SameExternalUnfreezeWalletRequestAs(
          ExternalUnfreezeWalletRequest expectedExternalUnfreezeWalletRequest)
        {
            return actualExternalUnfreezeWalletRequest =>
                this.compareLogic.Compare(
                    expectedExternalUnfreezeWalletRequest,
                    actualExternalUnfreezeWalletRequest)
                        .AreEqual;
        }


        private Expression<Func<ExternalFreezeWalletRequest, bool>> SameExternalFreezeWalletRequestAs(
             ExternalFreezeWalletRequest expectedExternalFreezeWalletRequest)
        {
            return actualExternalFreezeWalletRequest =>
                this.compareLogic.Compare(
                    expectedExternalFreezeWalletRequest,
                    actualExternalFreezeWalletRequest)
                        .AreEqual;
        }

        private Expression<Func<ExternalDebitWalletRequest, bool>> SameExternalDebitWalletRequestAs(
             ExternalDebitWalletRequest expectedExternalDebitWalletRequest)
        {
            return actualExternalDebitWalletRequest =>
                this.compareLogic.Compare(
                    expectedExternalDebitWalletRequest,
                    actualExternalDebitWalletRequest)
                        .AreEqual;
        }

        private Expression<Func<ExternalCreditWalletRequest, bool>> SameExternalCreditWalletRequestAs(
            ExternalCreditWalletRequest expectedExternalCreditWalletRequest)
        {
            return actualExternalCreditWalletRequest =>
                this.compareLogic.Compare(
                    expectedExternalCreditWalletRequest,
                    actualExternalCreditWalletRequest)
                        .AreEqual;
        }

        private Expression<Func<ExternalCreateWalletRequest, bool>> SameExternalCreateWalletRequestAs(
             ExternalCreateWalletRequest expectedExternalCreateWalletRequest)
        {
            return actualExternalCreateWalletRequest =>
                this.compareLogic.Compare(
                    expectedExternalCreateWalletRequest,
                    actualExternalCreateWalletRequest)
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

        private static List<string> CreateRandomStringList() =>
          new Filler<List<string>>().Create();

        private static bool GetRandomBoolean() =>
            Randomizer<bool>.Create();

        private static Dictionary<string, int> CreateRandomDictionary() =>
            new Filler<Dictionary<string, int>>().Create();


        #region FundMerchantSandBoxWalletRequest 

        private static dynamic CreateRandomFundMerchantSandBoxWalletRequestProperties()
        {
            return new
            {

                Amount = GetRandomNumber(),


            };
        }




        #endregion

        #region FundMerchantSandBoxWalletResponse 

        private static dynamic CreateRandomFundMerchantSandBoxWalletResponseProperties()
        {
            return new
            {
                
                 Status = GetRandomBoolean(),
                 Message = GetRandomString(),
    
            };
        }

      

        #endregion

        #region CustomerCreditCustomerWalletRequest 

        private static dynamic CreateRandomCustomerCreditCustomerWalletRequestProperties()
        {
            return new
            {

                BatchReference = GetRandomString(),
                CustomerId = GetRandomString(),
                Recipients = GetRandomCustomerCreditCustomerWalletRequestData(),


            };
        }


        private static List<dynamic> GetRandomCustomerCreditCustomerWalletRequestData()
        {

            return Enumerable.Range(0, GetRandomNumber()).Select(
            item => new
            {
                Amount = GetRandomNumber(),
                Reference = GetRandomString(),
                CustomerId = GetRandomString(),




            }).ToList<dynamic>();

        }

        #endregion

        #region CustomerCreditCustomerWalletResponse 

        private static dynamic CreateRandomCustomerCreditCustomerWalletResponseProperties()
        {

            return new
            {
                Status = GetRandomBoolean(),
                Data = GetRandomCustomerCreditCustomerWalletResponseData(),
                Message = GetRandomString(),

            };

        }


        private static dynamic GetRandomCustomerCreditCustomerWalletResponseData()
        {

            return new
            {
                Accepted = GetRandomCustomerCreditCustomerWalletResponseAccepted(),
                Rejected = GetRandomCustomerCreditCustomerWalletResponseRejected(),
                BatchReference = GetRandomString(),


            };

        }

        private static List<dynamic> GetRandomCustomerCreditCustomerWalletResponseAccepted()
        {

           return Enumerable.Range(0, GetRandomNumber()).Select(
           item => new
           {
                Amount = GetRandomNumber(),
                Reference = GetRandomString(),
                CustomerId = GetRandomString(),

            }).ToList<dynamic>();

        }

        private static List<dynamic> GetRandomCustomerCreditCustomerWalletResponseRejected()
        {

            return Enumerable.Range(0, GetRandomNumber()).Select(
           item => new
           {
                Amount = GetRandomNumber(),
                Reference = GetRandomString(),
                CustomerId = GetRandomString(),
                Reason = GetRandomString(),
                ReferenceExists = GetRandomBoolean(),

            }).ToList<dynamic>();

        }

        #endregion

        #region BatchCreditCustomerWalletsRequest 

        private static dynamic CreateRandomBatchCreditCustomerWalletsRequestProperties()
        {
            return new
            {

                BatchReference = GetRandomString(),
                Transactions = GetRandomBatchCreditCustomerWalletsRequestTransactions(),


            };
        }


        private static List<dynamic> GetRandomBatchCreditCustomerWalletsRequestTransactions()
        {

            return Enumerable.Range(0, GetRandomNumber()).Select(
            item => new
            {
                Amount = GetRandomNumber(),
                CustomerId = GetRandomString(),

            }).ToList<dynamic>();

        }



        #endregion

        #region BatchCreditCustomerWalletsResponse 

        private static dynamic CreateRandomBatchCreditCustomerWalletsResponseProperties()
        {

            return new
            {
                Status = GetRandomBoolean(),
                Data = GetRandomBatchCreditCustomerWalletsResponseData(),
                Message = GetRandomString(),

            };

        }


        private static dynamic GetRandomBatchCreditCustomerWalletsResponseData()
        {

            return new
            {
                Accepted = GetRandomBatchCreditCustomerWalletsResponseAccepted(),
                Rejected = GetRandomBatchCreditCustomerWalletsResponseRejected(),
                BatchReference = GetRandomString(),


            };

        }

        private static List<dynamic> GetRandomBatchCreditCustomerWalletsResponseAccepted()
        {

            return Enumerable.Range(0, GetRandomNumber()).Select(
            item => new
            {
                Amount = GetRandomNumber(),
                Reference = GetRandomString(),
                CustomerId = GetRandomString(),

            }).ToList<dynamic>();

        }

        private static List<dynamic> GetRandomBatchCreditCustomerWalletsResponseRejected()
        {

            return Enumerable.Range(0, GetRandomNumber()).Select(
           item => new
           {
               Amount = GetRandomNumber(),
               Reference = GetRandomString(),
               CustomerId = GetRandomString(),
               Reason = GetRandomString(),
               ReferenceExists = GetRandomBoolean(),

           }).ToList<dynamic>();

        }

        #endregion

        #region BatchDebitCustomerWalletsRequest 

        private static dynamic CreateRandomBatchDebitCustomerWalletsRequestProperties()
        {
            return new
            {

                BatchReference = GetRandomString(),
                Transactions = GetRandomBatchDebitCustomerWalletsRequestTransactions(),


            };
        }


        private static List<dynamic> GetRandomBatchDebitCustomerWalletsRequestTransactions()
        {

            return Enumerable.Range(0, GetRandomNumber()).Select(
            item => new
            {
                Amount = GetRandomNumber(),
                CustomerId = GetRandomString(),
                Reference = GetRandomString(),

            }).ToList<dynamic>();

        }





        #endregion

        #region BatchDebitCustomerWalletsResponse 


        private static dynamic CreateRandomBatchDebitCustomerWalletsResponseProperties()
        {

            return new
            {
                Status = GetRandomBoolean(),
                Data = GetRandomBatchDebitCustomerWalletsResponseData(),
                Message = GetRandomString(),

            };

        }


        private static dynamic GetRandomBatchDebitCustomerWalletsResponseData()
        {

            return new
            {
                Accepted = GetRandomBatchDebitCustomerWalletsResponseAccepted(),
                Rejected = GetRandomBatchDebitCustomerWalletsResponseRejected(),
                BatchReference = GetRandomString(),


            };

        }

        private static List<dynamic> GetRandomBatchDebitCustomerWalletsResponseAccepted()
        {

            return Enumerable.Range(0, GetRandomNumber()).Select(
            item => new
            {
                Amount = GetRandomNumber(),
                Reference = GetRandomString(),
                CustomerId = GetRandomString(),
                WalletId = GetRandomString(),

            }).ToList<dynamic>();

        }

        private static List<object> GetRandomBatchDebitCustomerWalletsResponseRejected()
        {

           return Enumerable.Range(0, GetRandomNumber()).Select(
           item => new
           {

           }).ToList<dynamic>();

        }



        #endregion

        #region UnfreezeWalletRequest 

        private static dynamic CreateRandomUnfreezeWalletRequestProperties()
        {
            return new
            {

                CustomerId = GetRandomString(),

            };
        }


        #endregion

        #region UnfreezeWalletResponse 


        private static dynamic CreateRandomUnfreezeWalletResponseProperties()
        {

            return new
            {
                Status = GetRandomBoolean(),
                Message = GetRandomString(),

            };

        }

        #endregion

        #region FreezeWalletRequest 

        private static dynamic CreateRandomFreezeWalletRequestProperties()
        {
            return new
            {

                CustomerId = GetRandomString(),

            };
        }


        #endregion

        #region FreezeWalletResponse 


        private static dynamic CreateRandomFreezeWalletResponseProperties()
        {

            return new
            {
                Status = GetRandomBoolean(),
                Message = GetRandomString(),

            };

        }

        #endregion

        #region DebitWalletRequest 

        private static dynamic CreateRandomDebitWalletRequestProperties()
        {
            return new
            {

                Amount = GetRandomNumber(),
                Reference = GetRandomString(),
                CustomerId = GetRandomString(),
                Metadata = DebitRandomDebitWalletRequestMetadata(),


            };
        }

        private static dynamic DebitRandomDebitWalletRequestMetadata()
        {
            return new
            {

                SomeData = GetRandomString(),
                MoreData = GetRandomString(),

            };
        }

        #endregion

        #region DebitWalletResponse 


        private static dynamic CreateRandomDebitWalletResponseProperties()
        {

            return new
            {
                Status = GetRandomNumber(),
                Message = GetRandomString(),
                Data = GetRandomDebitWalletResponseData(),


            };

        }

        private static dynamic GetRandomDebitWalletResponseData()
        {

            return new
            {
                Amount = GetRandomNumber(),
                Reference = GetRandomString(),
                CustomerId = GetRandomString(),
                Metadata = GetRandomDebitWalletResponseMetadata(),
                TransactionFee = GetRandomNumber(),
                CustomerWalletId = GetRandomString(),



            };

        }

        private static dynamic GetRandomDebitWalletResponseMetadata()
        {

            return new
            {

                SomeData = GetRandomString(),
                MoreData = GetRandomString(),


            };

        }

        #endregion

        #region CreditWalletRequest 

        private static dynamic CreateRandomCreditWalletRequestProperties()
        {
            return new
            {

                Amount = GetRandomNumber(),
                Reference = GetRandomString(),
                CustomerId = GetRandomString(),
                Metadata = GetRandomCreditWalletRequestMetadata(),


            };
        }

        private static dynamic GetRandomCreditWalletRequestMetadata()
        {
            return new
            {

                SomeData = GetRandomString(),
                MoreData = GetRandomString(),

            };
        }

        #endregion

        #region CreditWalletResponse 


        private static dynamic CreateRandomCreditWalletResponseProperties()
        {

            return new
            {
                Status = GetRandomBoolean(),
                Message = GetRandomString(),
                Reference = GetRandomString(),
                Amount = GetRandomNumber(),
            };

        }



        #endregion

        #region CreateWalletRequest 

        private static dynamic CreateRandomCreateWalletRequestProperties()
        {
            return new
            {

                Bvn = GetRandomString(),
                FirstName = GetRandomString(),
                LastName = GetRandomString(),
                DateOfBirth = GetRandomString(),
                PhoneNumber = GetRandomString(),
                Email = GetRandomString(),
                Address = GetRandomString(),
                Metadata = GetRandomCreateWalletRequestMetadata(),

            };
        }

        private static dynamic GetRandomCreateWalletRequestMetadata()
        {
            return new
            {

                EvenMore = GetRandomString(),
                AdditionalData = GetRandomString(),

            };
        }

        #endregion

        #region CreateWalletResponse 


        private static dynamic CreateRandomCreateWalletResponseProperties()
        {

            return new
            {
                Status = GetRandomBoolean(),
                Customer = GetRandomCreateWalletResponseCustomer(),
                Wallet = GetRandomCreateWalletResponseWallet(),

            };

        }

        private static dynamic GetRandomCreateWalletResponseCustomer()
        {

            return new
            {
                Id = GetRandomString(),
                Metadata = GetRandomCreateWalletResponseMeta(),
                Bvn = GetRandomString(),
                Currency = GetRandomString(),
                DateOfBirth = GetRandomString(),
                PhoneNumber = GetRandomString(),
                LastName = GetRandomString(),
                FirstName = GetRandomString(),
                BVNLastName = GetRandomString(),
                BVNFirstName = GetRandomString(),
                NameMatch = GetRandomBoolean(),
                Email = GetRandomString(),
                Mode = GetRandomString(),
                MerchantId = GetRandomString(),
                Tier = GetRandomString(),
                UpdatedAt = GetRandomDate(),
                CreatedAt = GetRandomDate(),
                Address = new object(),


            };

        }

        private static dynamic GetRandomCreateWalletResponseWallet()
        {

            return new
            {
                Id = GetRandomString(),
                Mode = GetRandomString(),
                Email = GetRandomString(),
                Currency = GetRandomString(),
                BankName = GetRandomString(),
                BankCode = GetRandomString(),
                AccountName = GetRandomString(),
                AccountNumber = GetRandomString(),
                AccountReference = GetRandomString(),
                UpdatedAt = GetRandomDate(),
                CreatedAt = GetRandomDate(),
                BookedBalance = GetRandomNumber(),
                AvailableBalance = GetRandomNumber(),
                Status = GetRandomString(),
                Updated = GetRandomBoolean(),
                WalletType = GetRandomString(),
                WalletId = GetRandomString(),


            };

        }

        private static dynamic GetRandomCreateWalletResponseMeta()
        {

            return new
            {
                EvenMore = GetRandomString(),
                AdditionalData = GetRandomString(),

            };

        }

        #endregion

        #region CustomerWalletResponse 

        private static dynamic CreateRandomCustomerWalletResponseProperties()
        {
            return new
            {

                Status = GetRandomString(),
                Wallet = GetRandomCustomerWalletResponseWallet(),

            };
        } 

        private static dynamic GetRandomCustomerWalletResponseWallet()
        {

            return  new
            {

                Id = GetRandomString(),
                Status = GetRandomString(),
                Email = GetRandomString(),
                CustomerId = GetRandomString(),
                LastName = GetRandomString(),
                FirstName = GetRandomString(),
                BankName = GetRandomString(),
                BankCode = GetRandomString(),
                CreatedAt = GetRandomDate(),
                UpdatedAt = GetRandomDate(),
                AccountName = GetRandomString(),
                AccountNumber = GetRandomString(),
                BookedBalance = GetRandomNumber(),
                AvailableBalance = GetRandomNumber(),
                AccountReference = GetRandomString(),




            };

        }

        #endregion

        #region AllWalletsResponse 

        private static dynamic CreateRandomAllWalletsResponseProperties()
        {
            return new
            {

                Status = GetRandomString(),
                Wallet = GetRandomAllWalletsResponseWallet(),

            };
        }

        private static List<dynamic> GetRandomAllWalletsResponseWallet()
        {

            return Enumerable.Range(0, GetRandomNumber()).Select(
            item => new
            {

                Email = GetRandomString(),
                Id = GetRandomString(),
                LastName = GetRandomString(),
                FirstName = GetRandomString(),
                Status = GetRandomString(),
                BankName = GetRandomString(),
                BankCode = GetRandomString(),
                CreatedAt = GetRandomDate(),
                UpdatedAt = GetRandomDate(),
                AccountName = GetRandomString(),
                AccountNumber = GetRandomString(),
                BookedBalance = GetRandomNumber(),
                AvailableBalance = GetRandomNumber(),
                AccountReference = GetRandomString(),



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
