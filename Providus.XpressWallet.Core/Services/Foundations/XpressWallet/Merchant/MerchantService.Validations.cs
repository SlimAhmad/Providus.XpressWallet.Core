using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Merchant;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Merchant.Exceptions;

namespace Providus.XpressWallet.Core.Services.Foundations.XpressWallet.Merchant
{
    internal partial class MerchantService
    {
        private static void ValidateAccountVerification(AccountVerification accountVerfication)
        {
            ValidateAccountVerificationNotNull(accountVerfication);
            ValidateAccountVerificationRequest(accountVerfication.Request);
            Validate(
                (Rule: IsInvalid(accountVerfication.Request), Parameter: nameof(accountVerfication.Request)));

            Validate(
                (Rule: IsInvalid(accountVerfication.Request.ActivationCode), Parameter: nameof(AccountVerificationRequest.ActivationCode))
                );

        }

        private static void ValidateResendVerification(ResendVerification resendVerification)
        {
            ValidateResendVerificationNotNull(resendVerification);
            ValidateResendVerificationRequest(resendVerification.Request);
            Validate(
                (Rule: IsInvalid(resendVerification.Request), Parameter: nameof(resendVerification.Request)));

            Validate(
                (Rule: IsInvalid(resendVerification.Request.Email), Parameter: nameof(ResendVerificationRequest.Email))
        

                );

        }

        private static void ValidateMerchantKYC(MerchantKYC merchantKYC)
        {
            ValidateMerchantKYCNotNull(merchantKYC);
            ValidateMerchantKYCRequest(merchantKYC.Request);
            Validate(
                (Rule: IsInvalid(merchantKYC.Request), Parameter: nameof(merchantKYC.Request)));

            Validate(
                (Rule: IsInvalid(merchantKYC.Request.MerchantId), Parameter: nameof(MerchantKYCRequest.MerchantId)),
                (Rule: IsInvalid(merchantKYC.Request.CacPack), Parameter: nameof(MerchantKYCRequest.CacPack)),
                (Rule: IsInvalid(merchantKYC.Request.DirectorsBVN), Parameter: nameof(MerchantKYCRequest.DirectorsBVN))
                );

        }

        private static void ValidateUpdateMerchantProfile(UpdateMerchantProfile updateMerchantProfile)
        {
            ValidateUpdateMerchantProfileNotNull(updateMerchantProfile);
            ValidateUpdateMerchantProfileRequest(updateMerchantProfile.Request);
            Validate(
                (Rule: IsInvalid(updateMerchantProfile.Request), Parameter: nameof(updateMerchantProfile.Request)));

            Validate(
                (Rule: IsInvalid(updateMerchantProfile.Request.SendEmail), Parameter: nameof(UpdateMerchantProfileRequest.SendEmail)),
                (Rule: IsInvalid(updateMerchantProfile.Request.SandboxCallbackURL), Parameter: nameof(UpdateMerchantProfileRequest.SandboxCallbackURL)),
                (Rule: IsInvalid(updateMerchantProfile.Request.CallbackURL), Parameter: nameof(UpdateMerchantProfileRequest.CallbackURL))

                );

        }

        private static void ValidateSwitchAccountMode(SwitchAccountMode switchAccountMode)
        {
            ValidateSwitchAccountModeNotNull(switchAccountMode);
            ValidateSwitchAccountModeRequest(switchAccountMode.Request);
            Validate(
                (Rule: IsInvalid(switchAccountMode.Request), Parameter: nameof(switchAccountMode.Request)));

            Validate(
                (Rule: IsInvalid(switchAccountMode.Request.Mode), Parameter: nameof(SwitchAccountModeRequest.Mode))
      
                );

        }

        private static void ValidateMerchantRegistration(MerchantRegistration merchantRegistration)
        {
            ValidateMerchantRegistrationNotNull(merchantRegistration);
            ValidateMerchantRegistrationRequest(merchantRegistration.Request);
            Validate(
                (Rule: IsInvalid(merchantRegistration.Request), Parameter: nameof(merchantRegistration.Request)));

            Validate(
                (Rule: IsInvalid(merchantRegistration.Request.BusinessName), Parameter: nameof(MerchantRegistrationRequest.BusinessName)),
                (Rule: IsInvalid(merchantRegistration.Request.BusinessType), Parameter: nameof(MerchantRegistrationRequest.BusinessType)),
                (Rule: IsInvalid(merchantRegistration.Request.PhoneNumber), Parameter: nameof(MerchantRegistrationRequest.PhoneNumber)),
                (Rule: IsInvalid(merchantRegistration.Request.FirstName), Parameter: nameof(MerchantRegistrationRequest.FirstName)),
                (Rule: IsInvalid(merchantRegistration.Request.LastName), Parameter: nameof(MerchantRegistrationRequest.LastName)),
                (Rule: IsInvalid(merchantRegistration.Request.AccountNumber), Parameter: nameof(MerchantRegistrationRequest.AccountNumber)),
                (Rule: IsInvalid(merchantRegistration.Request.Password), Parameter: nameof(MerchantRegistrationRequest.Password)),
                (Rule: IsInvalid(merchantRegistration.Request.Email), Parameter: nameof(MerchantRegistrationRequest.Email))


                );

        }


        private static void ValidateMerchantRegistrationNotNull(MerchantRegistration merchantRegistration)
        {
            if (merchantRegistration is null)
            {
                throw new NullMerchantException();
            }
        }

        private static void ValidateMerchantRegistrationRequest(MerchantRegistrationRequest merchantRegistration)
        {
            Validate((Rule: IsInvalid(merchantRegistration), Parameter: nameof(MerchantRegistrationRequest)));
        }
        private static void ValidateSwitchAccountModeNotNull(SwitchAccountMode switchAccountMode)
        {
            if (switchAccountMode is null)
            {
                throw new NullMerchantException();
            }
        }

        private static void ValidateSwitchAccountModeRequest(SwitchAccountModeRequest switchAccountMode)
        {
            Validate((Rule: IsInvalid(switchAccountMode), Parameter: nameof(SwitchAccountModeRequest)));
        }
        private static void ValidateUpdateMerchantProfileNotNull(UpdateMerchantProfile updateMerchantProfile)
        {
            if (updateMerchantProfile is null)
            {
                throw new NullMerchantException();
            }
        }

        private static void ValidateUpdateMerchantProfileRequest(UpdateMerchantProfileRequest updateMerchantProfile)
        {
            Validate((Rule: IsInvalid(updateMerchantProfile), Parameter: nameof(UpdateMerchantProfileRequest)));
        }

        private static void ValidateMerchantKYCNotNull(MerchantKYC merchantKYC)
        {
            if (merchantKYC is null)
            {
                throw new NullMerchantException();
            }
        }

        private static void ValidateMerchantKYCRequest(MerchantKYCRequest merchantKYC)
        {
            Validate((Rule: IsInvalid(merchantKYC), Parameter: nameof(MerchantKYCRequest)));
        }

        private static void ValidateResendVerificationNotNull(ResendVerification resendVerification)
        {
            if (resendVerification is null)
            {
                throw new NullMerchantException();
            }
        }

        private static void ValidateResendVerificationRequest(ResendVerificationRequest resendVerification)
        {
            Validate((Rule: IsInvalid(resendVerification), Parameter: nameof(ResendVerificationRequest)));
        }
        private static void ValidateAccountVerificationNotNull(AccountVerification resendVerification)
        {
            if (resendVerification is null)
            {
                throw new NullMerchantException();
            }
        }

        private static void ValidateAccountVerificationRequest(AccountVerificationRequest resendVerificationRequest)
        {
            Validate((Rule: IsInvalid(resendVerificationRequest), Parameter: nameof(AccountVerificationRequest)));
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
            Condition = number <= 0,
            Message = "Value is required"
        };

        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidresendVerificationException = new InvalidMerchantException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidresendVerificationException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidresendVerificationException.ThrowIfContainsErrors();
        }
    }
}