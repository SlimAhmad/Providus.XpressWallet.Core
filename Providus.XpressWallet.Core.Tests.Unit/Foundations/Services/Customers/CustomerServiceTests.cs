using KellermanSoftware.CompareNetObjects;
using Moq;
using Providus.XpressWallet.Core.Brokers.DateTimes;
using Providus.XpressWallet.Core.Brokers.XpressWallet;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalCustomers;
using Providus.XpressWallet.Core.Services.Foundations.XpressWallet.Customers;
using System.Linq.Expressions;
using Tynamix.ObjectFiller;
using RESTFulSense.Exceptions;
using System.Net;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Customers;


namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.Customers
{
    public partial class CustomersServiceTests
    {

        private readonly Mock<IXpressWalletBroker> xPressWalletBrokerMock;
        private readonly Mock<IDateTimeBroker> dateTimeBrokerMock;
        private readonly ICompareLogic compareLogic;
        private readonly ICustomersService authService;

        public CustomersServiceTests()
        {
            xPressWalletBrokerMock = new Mock<IXpressWalletBroker>();
            dateTimeBrokerMock = new Mock<IDateTimeBroker>();
            compareLogic = new CompareLogic();

            authService = new CustomersService(
                xPressWalletBrokerMock.Object,
                dateTimeBroker: dateTimeBrokerMock.Object);
        }


        private Expression<Func<ExternalUpdateCustomerProfileRequest, bool>> SameExternalUpdateCustomerProfileRequestAs(
             ExternalUpdateCustomerProfileRequest expectedExternalUpdateCustomerProfileRequest)
        {
            return actualExternalUpdateCustomerProfileRequest =>
                this.compareLogic.Compare(
                    expectedExternalUpdateCustomerProfileRequest,
                    actualExternalUpdateCustomerProfileRequest)
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


        #region UpdateCustomerProfileRequest 

        private static dynamic CreateRandomUpdateCustomerProfileRequestProperties()
        {
            return new
            {

                FirstName = GetRandomString(),
                LastName = GetRandomString(),
                Address = GetRandomString(),
                PhoneNumber = GetRandomString(),
                Metadata = GetRandomUpdateCustomerProfileRequestMetaData(),




            };
        }

        private static dynamic GetRandomUpdateCustomerProfileRequestMetaData()
        {
            return new
            {

                Others = GetRandomString(),
              

            };
        }


        #endregion

        #region UpdateCustomerProfileResponse 

        private static dynamic CreateRandomUpdateCustomerProfileResponseProperties()
        {
            return new
            {
                
                 Status = GetRandomBoolean(),
                 Customer = GetRandomUpdateCustomerProfileResponseData(),
    
            };
        }
        private static dynamic GetRandomUpdateCustomerProfileResponseData()
        {
            return new
            {

                FirstName  = GetRandomString(),
                LastName  = GetRandomString(),
                Email  = GetRandomString(),
                PhoneNumber  = GetRandomString(),
                DateOfBirth  = GetRandomString(),




            };
        }


        #endregion

        #region FindByPhoneNumberResponse 

        private static dynamic CreateRandomFindByPhoneNumberResponseProperties()
        {
            return new
            {

                Status = GetRandomBoolean(),
                Customer = GetRandomFindByPhoneNumberResponseData(),

            };
        }
        private static dynamic GetRandomFindByPhoneNumberResponseData()
        {
            return new
            {

                Id = GetRandomString(),
                FirstName = GetRandomString(),
                LastName = GetRandomString(),
                WalletId = GetRandomString(),


            };
        }


        #endregion

        #region CustomerDetailsResponse 

        private static dynamic CreateRandomCustomerDetailsResponseProperties()
        {
            return new
            {

                Status = GetRandomBoolean(),
                Customer = GetRandomCustomerDetailsResponseData(),

            };
        }
        private static dynamic GetRandomCustomerDetailsResponseData()
        {
            return new
            {

                Id = GetRandomString(),
                Bvn = GetRandomString(),
                FirstName = GetRandomString(),
                LastName = GetRandomString(),
                BVNLastName = GetRandomString(),
                BVNFirstName = GetRandomString(),
                Email = GetRandomString(),
                NameMatch = GetRandomBoolean(),
                PhoneNumber = GetRandomString(),
                DateOfBirth = GetRandomString(),
                CreatedAt = GetRandomDate(),
                UpdatedAt = GetRandomDate(),
                WalletId = GetRandomString(),
                Address = GetRandomString(),
                DeletedAt = GetRandomString(),
                Tier = GetRandomString(),
                Metadata = GetRandomCustomerDetailsResponseMetaData()


            };
        }

        private static dynamic GetRandomCustomerDetailsResponseMetaData()
        {
            return new
            {

               
                EvenMore = GetRandomString(),
                AdditionalData = GetRandomString(),
         


            };
        }

        #endregion

        #region AllCustomersResponse 

        private static dynamic CreateRandomAllCustomersResponseProperties()
        {
            return new
            {

                Status = GetRandomBoolean(),
                Customer = GetRandomAllCustomersResponseData(),
                Metadata = GetRandomAllCustomersResponseMetaData()

            };
        }

        private static List<dynamic> GetRandomAllCustomersResponseData()
        {

            return Enumerable.Range(0, GetRandomNumber()).Select(
            item => new
            {

                Id = GetRandomString(),
                Bvn = GetRandomString(),
                FirstName = GetRandomString(),
                LastName = GetRandomString(),
                BVNLastName = GetRandomString(),
                BVNFirstName = GetRandomString(),
                Email = GetRandomString(),
                NameMatch = GetRandomBoolean(),
                PhoneNumber = GetRandomString(),
                DateOfBirth = GetRandomString(),
                CreatedAt = GetRandomDate(),
                UpdatedAt = GetRandomDate(),
                WalletId = GetRandomString(),
                Address = GetRandomString(),
                DeletedAt = GetRandomString(),
                Tier = GetRandomString(),
                Metadata = GetRandomAllCustomersResponseMetaData()

            }).ToList<dynamic>();

        }
   

        private static dynamic GetRandomAllCustomersResponseMetaData()
        {
            return new
            {
                EvenMore = GetRandomString(),
                AdditionalData = GetRandomString(),
                Page = GetRandomNumber(),
                TotalRecords = GetRandomNumber(),
                TotalPages = GetRandomNumber(),


            };
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
