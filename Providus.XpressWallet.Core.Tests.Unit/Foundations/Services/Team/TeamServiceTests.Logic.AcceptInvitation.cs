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
        public async Task ShouldPostAcceptInvitationWithAcceptInvitationRequestAsync()
        {
            // given 



            dynamic createRandomAcceptInvitationRequestProperties =
              CreateRandomAcceptInvitationRequestProperties();

            dynamic createRandomAcceptInvitationResponseProperties =
                CreateRandomAcceptInvitationResponseProperties();


            var randomExternalAcceptInvitationRequest = new ExternalAcceptInvitationRequest
            {
                
                FirstName = createRandomAcceptInvitationRequestProperties.FirstName,
                InvitationCode = createRandomAcceptInvitationRequestProperties.InvitationCode,
                LastName = createRandomAcceptInvitationRequestProperties.LastName,
                Password = createRandomAcceptInvitationRequestProperties.Password,
                PhoneNumber = createRandomAcceptInvitationRequestProperties.PhoneNumber


            };

            var randomExternalAcceptInvitationResponse = new ExternalAcceptInvitationResponse
            {
                   
                Message = createRandomAcceptInvitationResponseProperties.Message,
                Status = createRandomAcceptInvitationResponseProperties.Status
                   
            };


            var randomAcceptInvitationRequest = new AcceptInvitationRequest
            {

                FirstName = createRandomAcceptInvitationRequestProperties.FirstName,
                InvitationCode = createRandomAcceptInvitationRequestProperties.InvitationCode,
                LastName = createRandomAcceptInvitationRequestProperties.LastName,
                Password = createRandomAcceptInvitationRequestProperties.Password,
                PhoneNumber = createRandomAcceptInvitationRequestProperties.PhoneNumber



            };

            var randomAcceptInvitationResponse = new AcceptInvitationResponse
            {
              
                Message = createRandomAcceptInvitationResponseProperties.Message,
                Status = createRandomAcceptInvitationResponseProperties.Status
            };


            var randomAcceptInvitation = new AcceptInvitation
            {
                Request = randomAcceptInvitationRequest,
            };

           

            AcceptInvitation inputAcceptInvitation = randomAcceptInvitation;
            AcceptInvitation expectedAcceptInvitation = inputAcceptInvitation.DeepClone();
            expectedAcceptInvitation.Response = randomAcceptInvitationResponse;

            ExternalAcceptInvitationRequest mappedExternalAcceptInvitationRequest =
               randomExternalAcceptInvitationRequest;

            ExternalAcceptInvitationResponse returnedExternalAcceptInvitationResponse =
                randomExternalAcceptInvitationResponse;

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostAcceptInvitationAsync(It.Is(
                      SameExternalAcceptInvitationRequestAs(mappedExternalAcceptInvitationRequest))))
                     .ReturnsAsync(returnedExternalAcceptInvitationResponse);

            // when
            AcceptInvitation actualCreateAcceptInvitation =
               await this.teamService.PostAcceptInvitationRequestAsync(inputAcceptInvitation);

            // then
            actualCreateAcceptInvitation.Should().BeEquivalentTo(expectedAcceptInvitation);

            this.xPressWalletBrokerMock.Verify(broker =>
               broker.PostAcceptInvitationAsync(It.Is(
                   SameExternalAcceptInvitationRequestAs(mappedExternalAcceptInvitationRequest))),
                   Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
        }
    }
}
