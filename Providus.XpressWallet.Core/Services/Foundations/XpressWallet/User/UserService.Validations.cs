using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.User;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.User.Exceptions;

namespace Providus.XpressWallet.Core.Services.Foundations.XpressWallet.User
{
    internal partial class UserService
    {
        private static void ValidateChangePassword(ChangePassword changePassword)
        {
            ValidateChangePasswordNotNull(changePassword);
            ValidateChangePasswordRequest(changePassword.Request);
            Validate(
                (Rule: IsInvalid(changePassword.Request), Parameter: nameof(changePassword.Request)));

            Validate(
                (Rule: IsInvalid(changePassword.Request.Password), Parameter: nameof(ChangePasswordRequest.Password))
                );

        }


       

        private static void ValidateChangePasswordNotNull(ChangePassword  changePassword)
        {
            if (changePassword is null)
            {
                throw new NullUserException();
            }
        }

        private static void ValidateChangePasswordRequest(ChangePasswordRequest changePasswordRequest)
        {
            Validate((Rule: IsInvalid(changePasswordRequest), Parameter: nameof(ChangePasswordRequest)));
        }


        private static dynamic IsInvalid(object @object) => new
        {
            Condition = @object is null,
            Message = "Value is required"
        };


        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidUserException = new InvalidUserException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidUserException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidUserException.ThrowIfContainsErrors();
        }
    }
}