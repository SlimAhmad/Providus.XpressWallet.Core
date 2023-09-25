using Providus.XpressWallet.Core.Models.Clients.RoleAndPermission.Exceptions;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Merchant;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.RoleAndPermission;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.RoleAndPermission.Exceptions;
using Providus.XpressWallet.Core.Services.Foundations.XpressWallet.RoleAndPermission;
using Xeptions;

namespace Providus.XpressWallet.Core.Clients.RoleAndPermission
{
    internal class RoleAndPermissionClient : IRoleAndPermissionClient
    {
        private readonly IRoleAndPermissionService roleAndPermissionService;

        public RoleAndPermissionClient(IRoleAndPermissionService roleAndPermissionsService) =>
            roleAndPermissionService = roleAndPermissionsService;

        public async ValueTask<CreateRole> CreateRoleAsync(CreateRole createRole)
        {
            try
            {
                return await roleAndPermissionService.PostCreateRoleRequestAsync(createRole);
            }
            catch (RoleAndPermissionValidationException roleAndPermissionValidationException)
            {

                throw new RoleAndPermissionClientValidationException(
                    roleAndPermissionValidationException.InnerException as Xeption);
            }
            catch (RoleAndPermissionDependencyValidationException roleAndPermissionDependencyValidationException)
            {


                throw new RoleAndPermissionClientValidationException(
                    roleAndPermissionDependencyValidationException.InnerException as Xeption);
            }
            catch (RoleAndPermissionDependencyException RoleAndPermissionDependencyException)
            {
                throw new RoleAndPermissionClientDependencyException(
                    RoleAndPermissionDependencyException.InnerException as Xeption);
            }
            catch (RoleAndPermissionServiceException RoleAndPermissionServiceException)
            {
                throw new RoleAndPermissionClientServiceException(
                    RoleAndPermissionServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<AllPermissions> RetrieveAllPermissionsAsync()
        {
           try
            {
                return await roleAndPermissionService.GetAllPermissionsRequestAsync();
            }
            catch (RoleAndPermissionValidationException roleAndPermissionValidationException)
            {

                throw new RoleAndPermissionClientValidationException(
                    roleAndPermissionValidationException.InnerException as Xeption);
            }
            catch (RoleAndPermissionDependencyValidationException roleAndPermissionDependencyValidationException)
            {


                throw new RoleAndPermissionClientValidationException(
                    roleAndPermissionDependencyValidationException.InnerException as Xeption);
            }
            catch (RoleAndPermissionDependencyException RoleAndPermissionDependencyException)
            {
                throw new RoleAndPermissionClientDependencyException(
                    RoleAndPermissionDependencyException.InnerException as Xeption);
            }
            catch (RoleAndPermissionServiceException RoleAndPermissionServiceException)
            {
                throw new RoleAndPermissionClientServiceException(
                    RoleAndPermissionServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<AllRoles> RetrieveAllRolesAsync()
        {
           try
            {
                return await roleAndPermissionService.GetAllRolesRequestAsync();
            }
            catch (RoleAndPermissionValidationException roleAndPermissionValidationException)
            {

                throw new RoleAndPermissionClientValidationException(
                    roleAndPermissionValidationException.InnerException as Xeption);
            }
            catch (RoleAndPermissionDependencyValidationException roleAndPermissionDependencyValidationException)
            {


                throw new RoleAndPermissionClientValidationException(
                    roleAndPermissionDependencyValidationException.InnerException as Xeption);
            }
            catch (RoleAndPermissionDependencyException RoleAndPermissionDependencyException)
            {
                throw new RoleAndPermissionClientDependencyException(
                    RoleAndPermissionDependencyException.InnerException as Xeption);
            }
            catch (RoleAndPermissionServiceException RoleAndPermissionServiceException)
            {
                throw new RoleAndPermissionClientServiceException(
                    RoleAndPermissionServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<UpdateRole> UpdateRoleAsync(UpdateRole updateRole, string roleId)
        {
           try
            {
                return await roleAndPermissionService.UpdateRoleRequestAsync(updateRole,roleId);
            }
            catch (RoleAndPermissionValidationException roleAndPermissionValidationException)
            {

                throw new RoleAndPermissionClientValidationException(
                    roleAndPermissionValidationException.InnerException as Xeption);
            }
            catch (RoleAndPermissionDependencyValidationException roleAndPermissionDependencyValidationException)
            {


                throw new RoleAndPermissionClientValidationException(
                    roleAndPermissionDependencyValidationException.InnerException as Xeption);
            }
            catch (RoleAndPermissionDependencyException RoleAndPermissionDependencyException)
            {
                throw new RoleAndPermissionClientDependencyException(
                    RoleAndPermissionDependencyException.InnerException as Xeption);
            }
            catch (RoleAndPermissionServiceException RoleAndPermissionServiceException)
            {
                throw new RoleAndPermissionClientServiceException(
                    RoleAndPermissionServiceException.InnerException as Xeption);
            }
        }
    }
}
