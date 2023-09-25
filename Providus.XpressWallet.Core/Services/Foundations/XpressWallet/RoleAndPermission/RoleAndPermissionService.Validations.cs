using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.RoleAndPermission;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.RoleAndPermission.Exceptions;

namespace Providus.XpressWallet.Core.Services.Foundations.XpressWallet.RoleAndPermission
{
    internal partial class RoleAndPermissionService
    {
        private static void ValidateUpdateRole(UpdateRole updateRole,string roleId)
        {
            ValidateUpdateRoleNotNull(updateRole);
            ValidateUpdateRoleRequest(updateRole.Request);
            Validate(
                (Rule: IsInvalid(updateRole.Request), Parameter: nameof(updateRole.Request)));

            Validate(
                (Rule: IsInvalid(updateRole.Request.Name), Parameter: nameof(UpdateRoleRequest.Name)),
                (Rule: IsInvalid(roleId), Parameter: nameof(UpdateRole)),
                (Rule: IsInvalid(updateRole.Request.Permissions), Parameter: nameof(UpdateRoleRequest.Permissions))
                
                );

        }

        private static void ValidateCreateRole(CreateRole createRole)
        {
            ValidateCreateRoleNotNull(createRole);
            ValidateCreateRoleRequest(createRole.Request);
            Validate(
                (Rule: IsInvalid(createRole.Request), Parameter: nameof(createRole.Request)));

            Validate(
                (Rule: IsInvalid(createRole.Request.Name), Parameter: nameof(CreateRoleRequest.Name)),
                (Rule: IsInvalid(createRole.Request.Permissions), Parameter: nameof(CreateRoleRequest.Permissions))
        

                );

        }

    

        private static void ValidateCreateRoleNotNull(CreateRole createRole)
        {
            if (createRole is null)
            {
                throw new NullRoleAndPermissionException();
            }
        }

        private static void ValidateCreateRoleRequest(CreateRoleRequest createRole)
        {
            Validate((Rule: IsInvalid(createRole), Parameter: nameof(CreateRoleRequest)));
        }
        private static void ValidateUpdateRoleNotNull(UpdateRole createRole)
        {
            if (createRole is null)
            {
                throw new NullRoleAndPermissionException();
            }
        }

        private static void ValidateUpdateRoleRequest(UpdateRoleRequest createRoleRequest)
        {
            Validate((Rule: IsInvalid(createRoleRequest), Parameter: nameof(UpdateRoleRequest)));
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
            var invalidcreateRoleException = new InvalidRoleAndPermissionException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidcreateRoleException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidcreateRoleException.ThrowIfContainsErrors();
        }
    }
}