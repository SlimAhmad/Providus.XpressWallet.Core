using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Customers;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Customers.Exceptions;

namespace Providus.XpressWallet.Core.Services.Foundations.XpressWallet.Customers
{
    internal partial class CustomersService
    {
        private static void ValidateUpdateCustomerProfile(UpdateCustomerProfile updateCustomerProfile, string customerId)
        {
            ValidateUpdateCustomerProfileNotNull(updateCustomerProfile);
            ValidateUpdateCustomerProfileRequest(updateCustomerProfile.Request);
            Validate(
                (Rule: IsInvalid(updateCustomerProfile.Request), Parameter: nameof(updateCustomerProfile.Request)));

            Validate(
                (Rule: IsInvalid(updateCustomerProfile.Request.PhoneNumber), Parameter: nameof(UpdateCustomerProfileRequest.PhoneNumber)),
                (Rule: IsInvalid(updateCustomerProfile.Request.FirstName), Parameter: nameof(UpdateCustomerProfileRequest.FirstName)),
                (Rule: IsInvalid(updateCustomerProfile.Request.LastName), Parameter: nameof(UpdateCustomerProfileRequest.LastName)),
                (Rule: IsInvalid(updateCustomerProfile.Request.Address), Parameter: nameof(UpdateCustomerProfileRequest.Address)),
                (Rule: IsInvalid(updateCustomerProfile.Request.Metadata), Parameter: nameof(UpdateCustomerProfileRequest)),
                (Rule: IsInvalid(customerId), Parameter: nameof(UpdateCustomerProfileRequest))  
                );

        }



        private static void ValidateUpdateCustomerProfileNotNull(UpdateCustomerProfile Customers)
        {
            if (Customers is null)
            {
                throw new NullCustomersException();
            }
        }

        private static void ValidateUpdateCustomerProfileRequest(UpdateCustomerProfileRequest CustomersRequest)
        {
            Validate((Rule: IsInvalid(CustomersRequest), Parameter: nameof(UpdateCustomerProfileRequest)));
        }


        private static void ValidateCustomerDetailsParameters(string text) =>
             Validate((Rule: IsInvalid(text), Parameter: nameof(CustomerDetails)));
        private static void ValidateFindByPhoneNumberParameters(string text) =>
             Validate((Rule: IsInvalid(text), Parameter: nameof(FindByPhoneNumber)));

        private static dynamic IsInvalid(object @object) => new
        {
            Condition = @object is null,
            Message = "Value is required"
        };


        private static dynamic IsInvalid(string text) => new
        {
            Condition = String.IsNullOrWhiteSpace(text),
            Message = "Value is required"
        };

        private static dynamic IsInvalid(double number) => new
        {
            Condition = number <= 0,
            Message = "Value is required"
        };

        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidCustomersException = new InvalidCustomersException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidCustomersException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidCustomersException.ThrowIfContainsErrors();
        }
    }
}