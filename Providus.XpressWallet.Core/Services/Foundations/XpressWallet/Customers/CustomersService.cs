using Providus.XpressWallet.Core.Brokers.DateTimes;
using Providus.XpressWallet.Core.Brokers.XpressWallet;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalCustomers;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Customers;

namespace Providus.XpressWallet.Core.Services.Foundations.XpressWallet.Customers
{
    internal partial class CustomersService : ICustomersService
    {
        private readonly IXpressWalletBroker xPressWalletBroker;
        private readonly IDateTimeBroker dateTimeBroker;

        public CustomersService(
            IXpressWalletBroker xPressWalletBroker,
            IDateTimeBroker dateTimeBroker)
        {
            this.xPressWalletBroker = xPressWalletBroker;
            this.dateTimeBroker = dateTimeBroker;
        }

        public ValueTask<AllCustomers> GetAllCustomersRequestAsync() =>
        TryCatch(async () =>
        {

            ExternalAllCustomersResponse externalAllCustomersResponse = await xPressWalletBroker.GetAllCustomersAsync();
            return ConvertToCustomersResponse(externalAllCustomersResponse);
        });
        public ValueTask<CustomerDetails> GetCustomerDetailsRequestAsync(string customerId) =>
        TryCatch(async () =>
        {
            ValidateCustomerDetailsParameters(customerId);
            ExternalCustomerDetailsResponse externalCustomerDetailsResponse = await xPressWalletBroker.GetCustomerDetailsAsync(customerId);
            return ConvertToCustomersResponse(externalCustomerDetailsResponse);
        });
        public ValueTask<FindByPhoneNumber> GetFindByPhoneNumberRequestAsync(string phoneNumber) =>
        TryCatch(async () =>
        {
            ValidateFindByPhoneNumberParameters(phoneNumber);
            ExternalFindByPhoneNumberResponse externalFindByPhoneNumberResponse = await xPressWalletBroker.GetFindByPhoneNumberAsync(phoneNumber);
            return ConvertToCustomersResponse(externalFindByPhoneNumberResponse);
        });
        public ValueTask<UpdateCustomerProfile> UpdateCustomerProfileRequestAsync(
            UpdateCustomerProfile externalUpdateCustomerProfile, string customerId) =>
        TryCatch(async () =>
        {
            ValidateUpdateCustomerProfile(externalUpdateCustomerProfile,customerId);
            ExternalUpdateCustomerProfileRequest externalUpdateCustomerProfileRequest = 
                ConvertToCustomersRequest(externalUpdateCustomerProfile);
            ExternalUpdateCustomerProfileResponse externalUpdateCustomerProfileResponse = 
                await xPressWalletBroker.UpdateCustomerProfileAsync(externalUpdateCustomerProfileRequest,customerId);
            return ConvertToCustomersResponse(externalUpdateCustomerProfile, externalUpdateCustomerProfileResponse);
        });


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
                        Address = externalCustomerDetailsResponse.Customer.Address,
                        DeletedAt = externalCustomerDetailsResponse.Customer.DeletedAt,
                        Tier = externalCustomerDetailsResponse.Customer.Tier,
                        Metadata = new CustomerDetailsResponse.Metadata
                        {
                          AdditionalData = externalCustomerDetailsResponse.Customer.Metadata.AdditionalData,
                          EvenMore = externalCustomerDetailsResponse.Customer.Metadata.EvenMore
                        }
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

  

    }
}
