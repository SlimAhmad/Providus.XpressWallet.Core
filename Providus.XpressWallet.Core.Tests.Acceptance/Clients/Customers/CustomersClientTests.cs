using Providus.XpressWallet.Core.Clients;
using Providus.XpressWallet.Core.Clients.Auth;
using Providus.XpressWallet.Core.Models.Configurations;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalCustomers;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Customers;
using Tynamix.ObjectFiller;
using WireMock.Server;

namespace Providus.XpressWallet.Core.Tests.Acceptance.Clients.Customers
{
    public partial class CustomersClientTests : IDisposable
    {
        private readonly string apiKey;
        private readonly WireMockServer wireMockServer;
        private readonly IXpressWalletClient xPressWalletClient;

        public CustomersClientTests()
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

        private static ExternalUpdateCustomerProfileRequest ConvertToCustomersRequest(
           UpdateCustomerProfile updateCustomerProfile)
        {

            return new ExternalUpdateCustomerProfileRequest
            {
                Address = updateCustomerProfile.Request.Address,
                PhoneNumber = updateCustomerProfile.Request.PhoneNumber,
                FirstName = updateCustomerProfile.Request.FirstName,
                LastName = updateCustomerProfile.Request.LastName,
                Metadata = new ExternalUpdateCustomerProfileRequest.ExternalMetadata
                {
                    Others = updateCustomerProfile.Request.Metadata.Others
                },

            };



        }
        private static UpdateCustomerProfile ConvertToCustomersResponse(
            UpdateCustomerProfile updateCustomerProfile, ExternalUpdateCustomerProfileResponse externalUpdateCustomerProfileResponse)
        {
            updateCustomerProfile.Response = new UpdateCustomerProfileResponse
            {
                Customer = new UpdateCustomerProfileResponse.CustomerResponse
                {
                    LastName = externalUpdateCustomerProfileResponse.Customer.LastName,
                    FirstName = externalUpdateCustomerProfileResponse.Customer.FirstName,
                    DateOfBirth = externalUpdateCustomerProfileResponse.Customer.DateOfBirth,
                    Email = externalUpdateCustomerProfileResponse.Customer.Email,
                    PhoneNumber = externalUpdateCustomerProfileResponse.Customer.PhoneNumber
                },
                Status = externalUpdateCustomerProfileResponse.Status
            };
            return updateCustomerProfile;

        }
        private static CustomerDetails ConvertToCustomersResponse(
             ExternalCustomerDetailsResponse externalCustomerDetailsResponse)
        {
            return new CustomerDetails
            {
                Response = new CustomerDetailsResponse
                {
                    Customer = new CustomerDetailsResponse.CustomerResponse
                    {
                        Bvn = externalCustomerDetailsResponse.Customer.Bvn,
                        BVNFirstName = externalCustomerDetailsResponse.Customer.BVNFirstName,
                        BVNLastName = externalCustomerDetailsResponse.Customer.BVNLastName,
                        CreatedAt = externalCustomerDetailsResponse.Customer.CreatedAt,
                        DateOfBirth = externalCustomerDetailsResponse.Customer.DateOfBirth,
                        Email = externalCustomerDetailsResponse.Customer.Email,
                        FirstName = externalCustomerDetailsResponse.Customer.FirstName,
                        Id = externalCustomerDetailsResponse.Customer.Id,
                        LastName = externalCustomerDetailsResponse.Customer.LastName,
                        NameMatch = externalCustomerDetailsResponse.Customer.NameMatch,
                        PhoneNumber = externalCustomerDetailsResponse.Customer.PhoneNumber,
                        UpdatedAt = externalCustomerDetailsResponse.Customer.UpdatedAt,
                        WalletId = externalCustomerDetailsResponse.Customer.WalletId,
                        Metadata = new CustomerDetailsResponse.Metadata
                        {
                           EvenMore = externalCustomerDetailsResponse.Customer.Metadata.EvenMore,
                           AdditionalData = externalCustomerDetailsResponse.Customer.Metadata.AdditionalData
                        },
                        Address = externalCustomerDetailsResponse.Customer.Address,
                        DeletedAt = externalCustomerDetailsResponse.Customer.DeletedAt,
                        Tier = externalCustomerDetailsResponse.Customer.Tier
                    },
                    Status = externalCustomerDetailsResponse.Status
                }
            };


        }
        private static FindByPhoneNumber ConvertToCustomersResponse(
             ExternalFindByPhoneNumberResponse externalFindByPhoneNumberResponse)
        {
            return new FindByPhoneNumber
            {
                Response = new FindByPhoneNumberResponse
                {
                    Customer = new FindByPhoneNumberResponse.CustomerResponse
                    {
                        WalletId = externalFindByPhoneNumberResponse.Customer.WalletId,
                        FirstName = externalFindByPhoneNumberResponse.Customer.FirstName,
                        Id = externalFindByPhoneNumberResponse.Customer.Id,
                        LastName = externalFindByPhoneNumberResponse.Customer.LastName
                    },
                    Status = externalFindByPhoneNumberResponse.Status
                }
            };

        }
        private static AllCustomers ConvertToCustomersResponse(
      ExternalAllCustomersResponse externalAllCustomersResponse)
        {
            return new AllCustomers
            {
                Response = new AllCustomersResponse
                {
                    Customers = externalAllCustomersResponse.Customers.Select(customers =>
                     new AllCustomersResponse.Customer
                     {

                         Email = customers.Email,
                         Bvn = customers.Bvn,
                         BVNFirstName = customers.BVNFirstName,
                         BVNLastName = customers.BVNLastName,
                         CreatedAt = customers.CreatedAt,
                         DateOfBirth = customers.DateOfBirth,
                         FirstName = customers.FirstName,
                         Id = customers.Id,
                         LastName = customers.LastName,
                         NameMatch = customers.NameMatch,
                         PhoneNumber = customers.PhoneNumber,
                         UpdatedAt = customers.UpdatedAt,
                         WalletId = customers.WalletId,
                         Address = customers.Address,
                         DeletedAt = customers.DeletedAt,
                         Tier = customers.Tier,
                         Metadata = new AllCustomersResponse.MetadataResponse
                         {
                             EvenMore = customers.Metadata.EvenMore,
                             AdditionalData = customers.Metadata.AdditionalData,
                             Page = customers.Metadata.Page,
                             TotalPages = customers.Metadata.TotalPages,
                             TotalRecords = customers.Metadata.TotalRecords,

                         }
                     }).ToList(),
                    Metadata = new AllCustomersResponse.MetadataResponse
                    {
                        AdditionalData = externalAllCustomersResponse.Metadata.AdditionalData,
                        EvenMore = externalAllCustomersResponse.Metadata.EvenMore,
                        Page = externalAllCustomersResponse.Metadata.Page,
                        TotalPages = externalAllCustomersResponse.Metadata.TotalPages,
                        TotalRecords = externalAllCustomersResponse.Metadata.TotalRecords,

                    },
                    Status = externalAllCustomersResponse.Status,
                }
            };


        }


        private static ExternalUpdateCustomerProfileResponse CreateExternalUpdateCustomerProfileResponseResult() =>
                CreateExternalUpdateCustomerProfileResponseFiller().Create();

        private static ExternalAllCustomersResponse CreateExternalAllCustomersResponseResult() =>
           CreateExternalAllCustomersResponseFiller().Create();

        private static ExternalCustomerDetailsResponse CreateExternalCustomerDetailsResponseResult() =>
          CreateExternalCustomerDetailsResponseFiller().Create();

        private static ExternalFindByPhoneNumberResponse CreateExternalFindByPhoneNumberResponseResult() =>
           CreateExternalExternalFindByPhoneNumberResponseFiller().Create();

        

        private static UpdateCustomerProfile CreateUpdateCustomerProfileResponseResult() =>
          CreateUpdateCustomerProfileFiller().Create();

   

        private static Filler<ExternalUpdateCustomerProfileResponse> CreateExternalUpdateCustomerProfileResponseFiller()
        {
            var filler = new Filler<ExternalUpdateCustomerProfileResponse>();

            filler.Setup()
               .OnType<object>().IgnoreIt();

            return filler;
        }
        private static Filler<ExternalAllCustomersResponse> CreateExternalAllCustomersResponseFiller()
        {
            var filler = new Filler<ExternalAllCustomersResponse>();

            filler.Setup()
               .OnType<object>().IgnoreIt();

            return filler;
        }
        private static Filler<ExternalFindByPhoneNumberResponse> CreateExternalExternalFindByPhoneNumberResponseFiller()
        {
            var filler = new Filler<ExternalFindByPhoneNumberResponse>();

            filler.Setup()
               .OnType<object>().IgnoreIt();

            return filler;
        }
        private static Filler<ExternalCustomerDetailsResponse> CreateExternalCustomerDetailsResponseFiller()
        {
            var filler = new Filler<ExternalCustomerDetailsResponse>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }


        private static Filler<UpdateCustomerProfile> CreateUpdateCustomerProfileFiller()
        {
            var filler = new Filler<UpdateCustomerProfile>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }
 
        
        public void Dispose() => wireMockServer.Stop();
    }
}
