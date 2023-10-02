using FluentAssertions;
using Force.DeepCloner;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalUser;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.User;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.User
{
    public partial class UserServiceTests
    {
        [Fact]
        public async Task ShouldPostChangePasswordWithChangePasswordRequestAsync()
        {
            // given 



            dynamic createRandomChangePasswordRequestProperties =
              CreateRandomChangePasswordRequestProperties();

            dynamic createRandomChangePasswordResponseProperties =
                CreateRandomChangePasswordResponseProperties();


            var randomExternalChangePasswordRequest = new ExternalChangePasswordRequest
            {

                 Password = createRandomChangePasswordRequestProperties.Password,


            };

            var randomExternalChangePasswordResponse = new ExternalChangePasswordResponse
            {
                
                Message = createRandomChangePasswordResponseProperties.Message,
                Status = createRandomChangePasswordResponseProperties.Status
                   
            };


            var randomChangePasswordRequest = new ChangePasswordRequest
            {

                Password = createRandomChangePasswordRequestProperties.Password,


            };

            var randomChangePasswordResponse = new ChangePasswordResponse
            {
              
                Message = createRandomChangePasswordResponseProperties.Message,
                Status = createRandomChangePasswordResponseProperties.Status
            };


            var randomChangePassword = new ChangePassword
            {
                Request = randomChangePasswordRequest,
            };

           

            ChangePassword inputChangePassword = randomChangePassword;
            ChangePassword expectedChangePassword = inputChangePassword.DeepClone();
            expectedChangePassword.Response = randomChangePasswordResponse;

            ExternalChangePasswordRequest mappedExternalChangePasswordRequest =
               randomExternalChangePasswordRequest;

            ExternalChangePasswordResponse returnedExternalChangePasswordResponse =
                randomExternalChangePasswordResponse;

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostChangePasswordAsync(It.Is(
                      SameExternalChangePasswordRequestAs(mappedExternalChangePasswordRequest))))
                     .ReturnsAsync(returnedExternalChangePasswordResponse);

            // when
            ChangePassword actualCreateChangePassword =
               await this.userService.PostChangePasswordRequestAsync(inputChangePassword);

            // then
            actualCreateChangePassword.Should().BeEquivalentTo(expectedChangePassword);

            this.xPressWalletBrokerMock.Verify(broker =>
               broker.PostChangePasswordAsync(It.Is(
                   SameExternalChangePasswordRequestAs(mappedExternalChangePasswordRequest))),
                   Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
        }
    }
}
