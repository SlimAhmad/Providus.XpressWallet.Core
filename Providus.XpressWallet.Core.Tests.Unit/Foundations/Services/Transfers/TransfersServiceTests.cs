using KellermanSoftware.CompareNetObjects;
using Moq;
using Providus.XpressWallet.Core.Brokers.DateTimes;
using Providus.XpressWallet.Core.Brokers.XpressWallet;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalTransfers;
using Providus.XpressWallet.Core.Services.Foundations.XpressWallet.Transfers;
using System.Linq.Expressions;
using Tynamix.ObjectFiller;
using RESTFulSense.Exceptions;
using System.Net;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.DataCollection;
using System.Runtime.InteropServices;


namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.Transfers
{
    public partial class TransfersServiceTests
    {

        private readonly Mock<IXpressWalletBroker> xPressWalletBrokerMock;
        private readonly Mock<IDateTimeBroker> dateTimeBrokerMock;
        private readonly ICompareLogic compareLogic;
        private readonly ITransfersService transfersService;

        public TransfersServiceTests()
        {
            xPressWalletBrokerMock = new Mock<IXpressWalletBroker>();
            dateTimeBrokerMock = new Mock<IDateTimeBroker>();
            compareLogic = new CompareLogic();

            transfersService = new TransfersService(
                xPressWalletBrokerMock.Object,
                dateTimeBroker: dateTimeBrokerMock.Object);
        }


        private Expression<Func<ExternalMerchantBankTransferRequest, bool>> SameExternalMerchantBankTransferRequestAs(
             ExternalMerchantBankTransferRequest expectedExternalMerchantBankTransferRequest)
        {
            return actualExternalMerchantBankTransferRequest =>
                this.compareLogic.Compare(
                    expectedExternalMerchantBankTransferRequest,
                    actualExternalMerchantBankTransferRequest)
                        .AreEqual;
        }

        private Expression<Func<ExternalCustomerBankTransferRequest, bool>> SameExternalCustomerBankTransferRequestAs(
          ExternalCustomerBankTransferRequest expectedExternalCustomerBankTransferRequest)
        {
            return actualExternalCustomerBankTransferRequest =>
                this.compareLogic.Compare(
                    expectedExternalCustomerBankTransferRequest,
                    actualExternalCustomerBankTransferRequest)
                        .AreEqual;
        }

        private Expression<Func<ExternalMerchantBatchBankTransferRequest, bool>> SameExternalMerchantBatchBankTransferRequestAs(
            ExternalMerchantBatchBankTransferRequest expectedExternalMerchantBatchBankTransferRequest)
        {
            return actualExternalMerchantBatchBankTransferRequest =>
                this.compareLogic.Compare(
                    expectedExternalMerchantBatchBankTransferRequest,
                    actualExternalMerchantBatchBankTransferRequest)
                        .AreEqual;
        }

        private Expression<Func<ExternalCustomerToCustomerWalletTransferRequest, bool>> SameExternalCustomerToCustomerWalletTransferRequestAs(
              ExternalCustomerToCustomerWalletTransferRequest expectedExternalCustomerToCustomerWalletTransferRequest)
        {
            return actualExternalCustomerToCustomerWalletTransferRequest =>
                this.compareLogic.Compare(
                    expectedExternalCustomerToCustomerWalletTransferRequest,
                    actualExternalCustomerToCustomerWalletTransferRequest)
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


        #region MerchantBankTransferRequest 

        private static dynamic CreateRandomMerchantBankTransferRequestProperties()
        {
            return new
            {

                Amount = GetRandomNumber(),
                SortCode = GetRandomString(),
                Narration = GetRandomString(),
                AccountNumber = GetRandomString(),
                AccountName = GetRandomString(),
                Metadata = GetRandomMerchantBankTransferRequestMetaData(),

            };
        }

        private static dynamic GetRandomMerchantBankTransferRequestMetaData()
        {
            return new
            {

                CustomerData = GetRandomString(),
              

            };
        }


        #endregion

        #region MerchantBankTransferResponse 

        private static dynamic CreateRandomMerchantBankTransferResponseProperties()
        {
            return new
            {
                
                 Status = GetRandomBoolean(),
                 Message = GetRandomString(),
                 Transfer = GetRandomMerchantBankTransferResponseData(),
    
            };
        }

        private static dynamic GetRandomMerchantBankTransferResponseMetaData()
        {
            return new
            {

                 CustomerData = GetRandomString(),
               

            };
        }

        private static dynamic GetRandomMerchantBankTransferResponseData()
        {
            return new
            {

                Amount = GetRandomNumber(),
                Charges = GetRandomNumber(),
                Vat = GetRandomNumber(),
                Reference = GetRandomString(),
                Total = GetRandomNumber(),
                Metadata = GetRandomMerchantBankTransferResponseMetaData(),
                SessionId = GetRandomString(),
                Destination = GetRandomString(),
                TransactionReference = GetRandomString(),
                Description = GetRandomString(),





            };
        }


        #endregion

        #region CustomerBankTransferRequest 

        private static dynamic CreateRandomCustomerBankTransferRequestProperties()
        {
            return new
            {

                Amount = GetRandomNumber(),
                SortCode = GetRandomString(),
                Narration = GetRandomString(),
                AccountNumber = GetRandomString(),
                AccountName = GetRandomString(),
                CustomerId = GetRandomString(),
                Metadata = GetRandomCustomerBankTransferRequestMetaData(),

            };
        }

        private static dynamic GetRandomCustomerBankTransferRequestMetaData()
        {
            return new
            {

                CustomerData = GetRandomString(),


            };
        }


        #endregion

        #region CustomerBankTransferResponse 

        private static dynamic CreateRandomCustomerBankTransferResponseProperties()
        {
            return new
            {

                Status = GetRandomBoolean(),
                Message = GetRandomString(),
                Transfer = GetRandomCustomerBankTransferResponseData(),

            };
        }

        private static dynamic GetRandomCustomerBankTransferResponseMetaData()
        {
            return new
            {

                CustomerData = GetRandomString(),


            };
        }

        private static dynamic GetRandomCustomerBankTransferResponseData()
        {
            return new
            {

                Amount = GetRandomNumber(),
                Charges = GetRandomNumber(),
                Vat = GetRandomNumber(),
                Reference = GetRandomString(),
                Total = GetRandomNumber(),
                Metadata = GetRandomCustomerBankTransferResponseMetaData(),
                SessionId = GetRandomString(),
                Destination = GetRandomString(),
                TransactionReference = GetRandomString(),
                Description = GetRandomString(),





            };
        }


        #endregion

        #region MerchantBatchBankTransferRequest 

        private static dynamic CreateRandomMerchantBatchBankTransferRequestProperties()
        {
            return new
            {

                Amount = GetRandomNumber(),
                SortCode = GetRandomString(),
                Narration = GetRandomString(),
                AccountNumber = GetRandomString(),
                AccountName = GetRandomString(),
                Metadata = GetRandomMerchantBatchBankTransferRequestMetaData(),

            };
        }

        private static dynamic GetRandomMerchantBatchBankTransferRequestMetaData()
        {
            return new
            {

                CustomerData = GetRandomString(),


            };
        }


        #endregion

        #region MerchantBatchBankTransferResponse 

        private static dynamic CreateRandomMerchantBatchBankTransferResponseProperties()
        {
            return new
            {

                Status = GetRandomBoolean(),
                Message = GetRandomString(),
                Data = GetRandomMerchantBatchBankTransferResponseData(),

            };
        }

        private static dynamic GetRandomMerchantBatchBankTransferResponseMetaData()
        {
            return new
            {

                TransactionReference = GetRandomString(),
                SessionId = GetRandomString(),

            };
        }

        private static List<dynamic> GetRandomMerchantBatchBankTransferResponseAccepted()
        {

            return Enumerable.Range(0, GetRandomNumber()).Select(
            item => new
            {

                Amount = GetRandomNumber(),
                Vat = GetRandomNumber(),
                BankName = GetRandomString(),
                SortCode = GetRandomString(),
                Metadata = GetRandomMerchantBatchBankTransferResponseMetaData(),
                Reference = GetRandomString(),
                Narration = GetRandomString(),
                AccountName = GetRandomString(),
                Fee = GetRandomNumber(),
                AccountNumber = GetRandomString(),
                Total = GetRandomNumber(),



            }).ToList<dynamic>();

        }

        private static List<dynamic> GetRandomMerchantBatchBankTransferResponseAll()
        {

            return Enumerable.Range(0, GetRandomNumber()).Select(
            item => new
            {

                Amount = GetRandomNumber(),
                Vat = GetRandomNumber(),
                SortCode = GetRandomString(),
                Reference = GetRandomString(),
                Narration = GetRandomString(),
                AccountName = GetRandomString(),
                Fee = GetRandomNumber(),
                AccountNumber = GetRandomString(),
                Total = GetRandomNumber(),




            }).ToList<dynamic>();

        }


        private static dynamic GetRandomMerchantBatchBankTransferResponseData()
        {
            return new
            {
                All = GetRandomMerchantBatchBankTransferResponseAll(),
                Rejected = new List<object>(),
                Accepted = GetRandomMerchantBatchBankTransferResponseAccepted(),

            };
        }



        #endregion

        #region CustomerToCustomerWalletTransferRequest 

        private static dynamic CreateRandomCustomerToCustomerWalletTransferRequestProperties()
        {
            return new
            {

                Amount = GetRandomNumber(),
                FromCustomerId = GetRandomString(),
                ToCustomerId = GetRandomString(),

            };
        }




        #endregion

        #region CustomerToCustomerWalletTransferResponse 

        private static dynamic CreateRandomCustomerToCustomerWalletTransferResponseProperties()
        {
            return new
            {

                Status = GetRandomBoolean(),
                Message = GetRandomString(),
                Data = GetRandomCustomerToCustomerWalletTransferResponseData(),

            };
        }



        private static dynamic GetRandomCustomerToCustomerWalletTransferResponseData()
        {
            return new
            {

                Amount = GetRandomNumber(),
                Reference = GetRandomString(),
                TransactionFee = GetRandomNumber(),
                Total = GetRandomNumber(),
                TargetCustomerId = GetRandomString(),
                SourceCustomerId = GetRandomString(),
                TargetCustomerWallet = GetRandomString(),
                SourceCustomerWallet = GetRandomString(),
                Description = GetRandomString(),





            };
        }


        #endregion

        #region BankAccountDetailsResponse 

        private static dynamic CreateRandomBankAccountDetailsResponseProperties()
        {
            return new
            {

                Status = GetRandomBoolean(),
                Account = GetRandomBankAccountDetailsResponseAccount(),

            };
        }
        private static dynamic GetRandomBankAccountDetailsResponseAccount()
        {
            return new
            {

                BankCode = GetRandomString(),
                AccountName = GetRandomString(),
                AccountNumber = GetRandomString(),



            };
        }


        #endregion

        #region BankListResponse 

        private static dynamic CreateRandomBankListResponseProperties()
        {
            return new
            {

                Status = GetRandomBoolean(),
                Banks = GetRandomBankListResponseData(),
        

            };
        }

        private static List<dynamic> GetRandomBankListResponseData()
        {

            return Enumerable.Range(0, GetRandomNumber()).Select(
            item => new
            {

                Code = GetRandomString(),
                Name = GetRandomString(),
          


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
