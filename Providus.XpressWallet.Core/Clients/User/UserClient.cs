using Providus.XpressWallet.Core.Models.Clients.User.Exceptions;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.User;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.User.Exceptions;
using Providus.XpressWallet.Core.Services.Foundations.XpressWallet.User;
using Xeptions;

namespace Providus.XpressWallet.Core.Clients.User
{
    internal class UserClient : IUserClient
    {
        private readonly IUserService userService;
        public UserClient(IUserService usersService) =>
        userService = usersService;

        public async ValueTask<ChangePassword> ChangePasswordAsync(ChangePassword changePassword)
        {
            try
            {
                return await userService.PostChangePasswordRequestAsync(changePassword);
            }
            catch (UserValidationException usersValidationException)
            {

                throw new UserClientValidationException(
                    usersValidationException.InnerException as Xeption);
            }
            catch (UserDependencyValidationException usersDependencyValidationException)
            {


                throw new UserClientValidationException(
                    usersDependencyValidationException.InnerException as Xeption);
            }
            catch (UserDependencyException UserDependencyException)
            {
                throw new UserClientDependencyException(
                    UserDependencyException.InnerException as Xeption);
            }
            catch (UserServiceException UserServiceException)
            {
                throw new UserClientServiceException(
                    UserServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<UserProfile> RetrieveUserProfileAsync()
        {
            try
            {
                return await userService.GetUserProfileRequestAsync();
            }
            catch (UserValidationException usersValidationException)
            {

                throw new UserClientValidationException(
                    usersValidationException.InnerException as Xeption);
            }
            catch (UserDependencyValidationException usersDependencyValidationException)
            {


                throw new UserClientValidationException(
                    usersDependencyValidationException.InnerException as Xeption);
            }
            catch (UserDependencyException UserDependencyException)
            {
                throw new UserClientDependencyException(
                    UserDependencyException.InnerException as Xeption);
            }
            catch (UserServiceException UserServiceException)
            {
                throw new UserClientServiceException(
                    UserServiceException.InnerException as Xeption);
            }
        }
    }
}
