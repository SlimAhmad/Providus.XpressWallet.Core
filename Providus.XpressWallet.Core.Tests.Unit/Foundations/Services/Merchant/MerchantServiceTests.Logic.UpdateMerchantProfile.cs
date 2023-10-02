using FluentAssertions;
using Force.DeepCloner;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalMerchant;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Merchant;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.Merchant
{
    public partial class MerchantServiceTests
    {
        [Fact]
        public async Task ShouldPostUpdateMerchantProfileWithUpdateMerchantProfileRequestAsync()
        {
            // given 



            dynamic createRandomUpdateMerchantProfileRequestProperties =
              CreateRandomUpdateMerchantProfileRequestProperties();

            dynamic createRandomUpdateMerchantProfileResponseProperties =
                CreateRandomUpdateMerchantProfileResponseProperties();


            var randomExternalUpdateMerchantProfileRequest = new ExternalUpdateMerchantProfileRequest
            {
                CallbackURL = createRandomUpdateMerchantProfileRequestProperties.CallbackURL,
                CanLogin = createRandomUpdateMerchantProfileRequestProperties.CanLogin,
                SandboxCallbackURL = createRandomUpdateMerchantProfileRequestProperties.SandboxCallbackURL,
                SendEmail = createRandomUpdateMerchantProfileRequestProperties.SendEmail

            };

            var randomExternalUpdateMerchantProfileResponse = new ExternalUpdateMerchantProfileResponse
            {
             
              Message = createRandomUpdateMerchantProfileResponseProperties.Message,
              Status = createRandomUpdateMerchantProfileResponseProperties.Status
                   
            };


            var randomUpdateMerchantProfileRequest = new UpdateMerchantProfileRequest
            {
                    CallbackURL = createRandomUpdateMerchantProfileRequestProperties.CallbackURL,
                    CanLogin = createRandomUpdateMerchantProfileRequestProperties.CanLogin,
                    SandboxCallbackURL = createRandomUpdateMerchantProfileRequestProperties.SandboxCallbackURL,
                    SendEmail = createRandomUpdateMerchantProfileRequestProperties.SendEmail

            };

            var randomUpdateMerchantProfileResponse = new UpdateMerchantProfileResponse
            {
                Message = createRandomUpdateMerchantProfileResponseProperties.Message,
                Status = createRandomUpdateMerchantProfileResponseProperties.Status
            };


            var randomUpdateMerchantProfile = new UpdateMerchantProfile
            {
                Request = randomUpdateMerchantProfileRequest,
            };

           

            UpdateMerchantProfile inputUpdateMerchantProfile = randomUpdateMerchantProfile;
            UpdateMerchantProfile expectedUpdateMerchantProfile = inputUpdateMerchantProfile.DeepClone();
            expectedUpdateMerchantProfile.Response = randomUpdateMerchantProfileResponse;

            ExternalUpdateMerchantProfileRequest mappedExternalUpdateMerchantProfileRequest =
               randomExternalUpdateMerchantProfileRequest;

            ExternalUpdateMerchantProfileResponse returnedExternalUpdateMerchantProfileResponse =
                randomExternalUpdateMerchantProfileResponse;

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.UpdateMerchantProfileAsync(It.Is(
                      SameExternalUpdateMerchantProfileRequestAs(mappedExternalUpdateMerchantProfileRequest))))
                     .ReturnsAsync(returnedExternalUpdateMerchantProfileResponse);

            // when
            UpdateMerchantProfile actualCreateUpdateMerchantProfile =
               await this.merchantService.UpdateMerchantProfileRequestAsync(inputUpdateMerchantProfile);

            // then
            actualCreateUpdateMerchantProfile.Should().BeEquivalentTo(expectedUpdateMerchantProfile);

            this.xPressWalletBrokerMock.Verify(broker =>
               broker.UpdateMerchantProfileAsync(It.Is(
                   SameExternalUpdateMerchantProfileRequestAs(mappedExternalUpdateMerchantProfileRequest))),
                   Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
        }
    }
}
