using FluentAssertions;
using Force.DeepCloner;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalTeam;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Team;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.Team
{
    public partial class TeamServiceTests
    {
        [Fact]
        public async Task ShouldPostResendInvitationWithResendInvitationRequestAsync()
        {
            // given 



            dynamic createRandomResendInvitationRequestProperties =
              CreateRandomResendInvitationRequestProperties();

            dynamic createRandomResendInvitationResponseProperties =
                CreateRandomResendInvitationResponseProperties();


            var randomExternalResendInvitationRequest = new ExternalResendInvitationRequest
            {
                
                Email = createRandomResendInvitationRequestProperties.Email,


            };

            var randomExternalResendInvitationResponse = new ExternalResendInvitationResponse
            {
                
                Message = createRandomResendInvitationResponseProperties.Message,
                Status = createRandomResendInvitationResponseProperties.Status
                   
            };


            var randomResendInvitationRequest = new ResendInvitationRequest
            {
                
                Email = createRandomResendInvitationRequestProperties.Email,
               

            };

            var randomResendInvitationResponse = new ResendInvitationResponse
            {
              
                Message = createRandomResendInvitationResponseProperties.Message,
                Status = createRandomResendInvitationResponseProperties.Status
            };


            var randomResendInvitation = new ResendInvitation
            {
                Request = randomResendInvitationRequest,
            };

           

            ResendInvitation inputResendInvitation = randomResendInvitation;
            ResendInvitation expectedResendInvitation = inputResendInvitation.DeepClone();
            expectedResendInvitation.Response = randomResendInvitationResponse;

            ExternalResendInvitationRequest mappedExternalResendInvitationRequest =
               randomExternalResendInvitationRequest;

            ExternalResendInvitationResponse returnedExternalResendInvitationResponse =
                randomExternalResendInvitationResponse;

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostResendInvitationAsync(It.Is(
                      SameExternalResendInvitationRequestAs(mappedExternalResendInvitationRequest))))
                     .ReturnsAsync(returnedExternalResendInvitationResponse);

            // when
            ResendInvitation actualCreateResendInvitation =
               await this.teamService.PostResendInvitationRequestAsync(inputResendInvitation);

            // then
            actualCreateResendInvitation.Should().BeEquivalentTo(expectedResendInvitation);

            this.xPressWalletBrokerMock.Verify(broker =>
               broker.PostResendInvitationAsync(It.Is(
                   SameExternalResendInvitationRequestAs(mappedExternalResendInvitationRequest))),
                   Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
        }
    }
}
