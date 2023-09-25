using Providus.XpressWallet.Core.Models.Clients.Customers.Exceptions;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Customers;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Customers.Exceptions;
using Providus.XpressWallet.Core.Services.Foundations.XpressWallet.Customers;
using Xeptions;

namespace Providus.XpressWallet.Core.Clients.Customers
{
    internal class CustomersClient : ICustomersClient
    {
        private readonly ICustomersService customersService;

        public CustomersClient(ICustomersService customersService) =>
        this.customersService = customersService;

        public async ValueTask<AllCustomers> RetrieveAllCustomersAsync()
        {
            try
            {
                return await customersService.GetAllCustomersRequestAsync();
            }
            catch (CustomersValidationException CustomersValidationException)
            {

                throw new CustomersClientValidationException(
                    CustomersValidationException.InnerException as Xeption);
            }
            catch (CustomersDependencyValidationException CustomersDependencyValidationException)
            {


                throw new CustomersClientValidationException(
                    CustomersDependencyValidationException.InnerException as Xeption);
            }
            catch (CustomersDependencyException CustomersDependencyException)
            {
                throw new CustomersClientDependencyException(
                    CustomersDependencyException.InnerException as Xeption);
            }
            catch (CustomersServiceException CustomersServiceException)
            {
                throw new CustomersClientServiceException(
                    CustomersServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<CustomerDetails> RetrieveCustomerDetailsAsync(string customerId)
        {
            try
            {
                return await customersService.GetCustomerDetailsRequestAsync(customerId);
            }
            catch (CustomersValidationException CustomersValidationException)
            {

                throw new CustomersClientValidationException(
                    CustomersValidationException.InnerException as Xeption);
            }
            catch (CustomersDependencyValidationException CustomersDependencyValidationException)
            {


                throw new CustomersClientValidationException(
                    CustomersDependencyValidationException.InnerException as Xeption);
            }
            catch (CustomersDependencyException CustomersDependencyException)
            {
                throw new CustomersClientDependencyException(
                    CustomersDependencyException.InnerException as Xeption);
            }
            catch (CustomersServiceException CustomersServiceException)
            {
                throw new CustomersClientServiceException(
                    CustomersServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<FindByPhoneNumber> RetrieveFindByPhoneNumberAsync(string phoneNumber)
        {
             try
            {
                return await customersService.GetFindByPhoneNumberRequestAsync(phoneNumber);
            }
            catch (CustomersValidationException CustomersValidationException)
            {

                throw new CustomersClientValidationException(
                    CustomersValidationException.InnerException as Xeption);
            }
            catch (CustomersDependencyValidationException CustomersDependencyValidationException)
            {


                throw new CustomersClientValidationException(
                    CustomersDependencyValidationException.InnerException as Xeption);
            }
            catch (CustomersDependencyException CustomersDependencyException)
            {
                throw new CustomersClientDependencyException(
                    CustomersDependencyException.InnerException as Xeption);
            }
            catch (CustomersServiceException CustomersServiceException)
            {
                throw new CustomersClientServiceException(
                    CustomersServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<UpdateCustomerProfile> UpdateCustomerProfileAsync(UpdateCustomerProfile updateCustomerProfile, string customerId)
        {
             try
            {
                return await customersService.UpdateCustomerProfileRequestAsync(updateCustomerProfile,customerId);
            }
            catch (CustomersValidationException CustomersValidationException)
            {

                throw new CustomersClientValidationException(
                    CustomersValidationException.InnerException as Xeption);
            }
            catch (CustomersDependencyValidationException CustomersDependencyValidationException)
            {


                throw new CustomersClientValidationException(
                    CustomersDependencyValidationException.InnerException as Xeption);
            }
            catch (CustomersDependencyException CustomersDependencyException)
            {
                throw new CustomersClientDependencyException(
                    CustomersDependencyException.InnerException as Xeption);
            }
            catch (CustomersServiceException CustomersServiceException)
            {
                throw new CustomersClientServiceException(
                    CustomersServiceException.InnerException as Xeption);
            }
        }
    }
}
