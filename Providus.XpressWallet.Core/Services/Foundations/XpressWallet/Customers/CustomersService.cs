﻿using Providus.XpressWallet.Core.Brokers.DateTimes;
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
                        BVNFirstName = externalCustomerDetailsResponse.Customer.FirstName,
                        BVNLastName = externalCustomerDetailsResponse.Customer.LastName,
                        CreatedAt = externalCustomerDetailsResponse.Customer.CreatedAt,
                        DateOfBirth = externalCustomerDetailsResponse.Customer.DateOfBirth,
                        Email = externalCustomerDetailsResponse.Customer.Email,
                        FirstName = externalCustomerDetailsResponse.Customer.FirstName,
                        Id = externalCustomerDetailsResponse.Customer.Id,
                        LastName = externalCustomerDetailsResponse.Customer.LastName,
                        NameMatch = externalCustomerDetailsResponse.Customer.NameMatch,
                        PhoneNumber = externalCustomerDetailsResponse.Customer.PhoneNumber,
                        UpdatedAt = externalCustomerDetailsResponse.Customer.CreatedAt,
                        WalletId = externalCustomerDetailsResponse.Customer.WalletId,
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
                         BVNFirstName = customers.Bvn,
                         BVNLastName = customers.Bvn,
                         CreatedAt = customers.CreatedAt,
                         DateOfBirth = customers.DateOfBirth,
                         FirstName = customers.Bvn,
                         Id = customers.Id,
                         LastName = customers.Bvn,
                         NameMatch = customers.NameMatch,
                         PhoneNumber = customers.PhoneNumber,
                         UpdatedAt = customers.UpdatedAt,
                         WalletId = customers.WalletId,
                     }).ToList(),
                    Metadata = new AllCustomersResponse.MetadataResponse
                    {
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
