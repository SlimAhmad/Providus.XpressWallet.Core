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
        public async Task ShouldPostUpdateMemberInformationWithUpdateMemberInformationRequestAsync()
        {
            // given 
            var inputMemberId = GetRandomString();


            dynamic createRandomUpdateMemberInformationRequestProperties =
              CreateRandomUpdateMemberInformationRequestProperties();

            dynamic createRandomUpdateMemberInformationResponseProperties =
                CreateRandomUpdateMemberInformationResponseProperties();


            var randomExternalUpdateMemberInformationRequest = new ExternalUpdateMemberInformationRequest
            {

                ApprovalLimit = createRandomUpdateMemberInformationRequestProperties.ApprovalLimit,
                RoleId = createRandomUpdateMemberInformationRequestProperties.RoleId


            };

            var randomExternalUpdateMemberInformationResponse = new ExternalUpdateMemberInformationResponse
            {
                
                Message = createRandomUpdateMemberInformationResponseProperties.Message,
                Status = createRandomUpdateMemberInformationResponseProperties.Status
                   
            };


            var randomUpdateMemberInformationRequest = new UpdateMemberInformationRequest
            {

                ApprovalLimit = createRandomUpdateMemberInformationRequestProperties.ApprovalLimit,
                RoleId = createRandomUpdateMemberInformationRequestProperties.RoleId,


            };

            var randomUpdateMemberInformationResponse = new UpdateMemberInformationResponse
            {
              
                Message = createRandomUpdateMemberInformationResponseProperties.Message,
                Status = createRandomUpdateMemberInformationResponseProperties.Status
            };


            var randomUpdateMemberInformation = new UpdateMemberInformation
            {
                Request = randomUpdateMemberInformationRequest,
            };

           

            UpdateMemberInformation inputUpdateMemberInformation = randomUpdateMemberInformation;
            UpdateMemberInformation expectedUpdateMemberInformation = inputUpdateMemberInformation.DeepClone();
            expectedUpdateMemberInformation.Response = randomUpdateMemberInformationResponse;

            ExternalUpdateMemberInformationRequest mappedExternalUpdateMemberInformationRequest =
               randomExternalUpdateMemberInformationRequest;

            ExternalUpdateMemberInformationResponse returnedExternalUpdateMemberInformationResponse =
                randomExternalUpdateMemberInformationResponse;

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.UpdateMemberInformationAsync(It.Is(
                      SameExternalUpdateMemberInformationRequestAs(mappedExternalUpdateMemberInformationRequest)), It.IsAny<string>()))
                     .ReturnsAsync(returnedExternalUpdateMemberInformationResponse);

            // when
            UpdateMemberInformation actualCreateUpdateMemberInformation =
               await this.teamService.UpdateMemberInformationRequestAsync(inputUpdateMemberInformation, inputMemberId);

            // then
            actualCreateUpdateMemberInformation.Should().BeEquivalentTo(expectedUpdateMemberInformation);

            this.xPressWalletBrokerMock.Verify(broker =>
               broker.UpdateMemberInformationAsync(It.Is(
                   SameExternalUpdateMemberInformationRequestAs(mappedExternalUpdateMemberInformationRequest)), It.IsAny<string>()),
                   Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
        }
    }
}
