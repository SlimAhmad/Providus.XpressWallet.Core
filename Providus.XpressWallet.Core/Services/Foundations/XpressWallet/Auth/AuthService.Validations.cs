using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Auth;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Auth.Exceptions;

namespace Providus.XpressWallet.Core.Services.Foundations.XpressWallet.Auth
{
    internal partial class AuthService
    {
        private static void ValidateLogin(Login  login)
        {
            ValidateLoginNotNull(login);
            ValidateLoginRequest(login.Request);
            Validate(
                (Rule: IsInvalid(login.Request), Parameter: nameof(login.Request)));

            Validate(
                (Rule: IsInvalid(login.Request.Email), Parameter: nameof(LoginRequest.Email)),
                (Rule: IsInvalid(login.Request.Password), Parameter: nameof(LoginRequest.Password))
                
                );

        }

        private static void ValidateForgetPassword(ForgetPassword login)
        {
            ValidateForgetPasswordNotNull(login);
            ValidateForgetPasswordRequest(login.Request);
            Validate(
                (Rule: IsInvalid(login.Request), Parameter: nameof(login.Request)));

            Validate(
                (Rule: IsInvalid(login.Request.Email), Parameter: nameof(ForgetPasswordRequest.Email))


                );

        }

        private static void ValidateResetPassword(ResetPassword resetPassword)
        {
            ValidateResetPasswordNotNull(resetPassword);
            ValidateResetPasswordRequest(resetPassword.Request);
            Validate(
                (Rule: IsInvalid(resetPassword.Request), Parameter: nameof(resetPassword.Request)));

            Validate(
                (Rule: IsInvalid(resetPassword.Request.ResetCode), Parameter: nameof(ResetPasswordRequest.ResetCode)),
                (Rule: IsInvalid(resetPassword.Request.Password), Parameter: nameof(ResetPasswordRequest.Password))

                );

        }


        private static void ValidateLoginNotNull(Login login)
        {
            if (login is null)
            {
                throw new NullAuthException();
            }
        }

        private static void ValidateLoginRequest(LoginRequest loginRequest)
        {
            Validate((Rule: IsInvalid(loginRequest), Parameter: nameof(LoginRequest)));
        }

        private static void ValidateForgetPasswordNotNull(ForgetPassword forgetPassword)
        {
            if (forgetPassword is null)
            {
                throw new NullAuthException();
            }
        }

        private static void ValidateForgetPasswordRequest(ForgetPasswordRequest forgetPasswordRequest)
        {
            Validate((Rule: IsInvalid(forgetPasswordRequest), Parameter: nameof(ForgetPasswordRequest)));
        }
        private static void ValidateResetPasswordNotNull(ResetPassword resetPassword)
        {
            if (resetPassword is null)
            {
                throw new NullAuthException();
            }
        }

        private static void ValidateResetPasswordRequest(ResetPasswordRequest resetPasswordRequest)
        {
            Validate((Rule: IsInvalid(resetPasswordRequest), Parameter: nameof(ResetPasswordRequest)));
        }
 



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
            Condition = number >= 0,
            Message = "Value is required"
        };

        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidresetPasswordException = new InvalidAuthException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidresetPasswordException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidresetPasswordException.ThrowIfContainsErrors();
        }
    }
}