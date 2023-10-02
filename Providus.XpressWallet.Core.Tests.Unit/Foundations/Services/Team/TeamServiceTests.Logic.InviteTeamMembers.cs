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
        public async Task ShouldPostInviteTeamMembersWithInviteTeamMembersRequestAsync()
        {
            // given 



            dynamic createRandomInviteTeamMembersRequestProperties =
              CreateRandomInviteTeamMembersRequestProperties();

            dynamic createRandomInviteTeamMembersResponseProperties =
                CreateRandomInviteTeamMembersResponseProperties();


            var randomExternalInviteTeamMembersRequest = new ExternalInviteTeamMembersRequest
            {
                ApprovalLimit = createRandomInviteTeamMembersRequestProperties.ApprovalLimit,
                Email = createRandomInviteTeamMembersRequestProperties.Email,
                RoleId = createRandomInviteTeamMembersRequestProperties.RoleId,

            };

            var randomExternalInviteTeamMembersResponse = new ExternalInviteTeamMembersResponse
            {
                
                Message = createRandomInviteTeamMembersResponseProperties.Message,
                Status = createRandomInviteTeamMembersResponseProperties.Status
                   
            };


            var randomInviteTeamMembersRequest = new InviteTeamMembersRequest
            {
                ApprovalLimit = createRandomInviteTeamMembersRequestProperties.ApprovalLimit,
                Email = createRandomInviteTeamMembersRequestProperties.Email,
                RoleId = createRandomInviteTeamMembersRequestProperties.RoleId,

            };

            var randomInviteTeamMembersResponse = new InviteTeamMembersResponse
            {
              
                Message = createRandomInviteTeamMembersResponseProperties.Message,
                Status = createRandomInviteTeamMembersResponseProperties.Status
            };


            var randomInviteTeamMembers = new InviteTeamMembers
            {
                Request = randomInviteTeamMembersRequest,
            };

           

            InviteTeamMembers inputInviteTeamMembers = randomInviteTeamMembers;
            InviteTeamMembers expectedInviteTeamMembers = inputInviteTeamMembers.DeepClone();
            expectedInviteTeamMembers.Response = randomInviteTeamMembersResponse;

            ExternalInviteTeamMembersRequest mappedExternalInviteTeamMembersRequest =
               randomExternalInviteTeamMembersRequest;

            ExternalInviteTeamMembersResponse returnedExternalInviteTeamMembersResponse =
                randomExternalInviteTeamMembersResponse;

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostInviteTeamMemberAsync(It.Is(
                      SameExternalInviteTeamMembersRequestAs(mappedExternalInviteTeamMembersRequest))))
                     .ReturnsAsync(returnedExternalInviteTeamMembersResponse);

            // when
            InviteTeamMembers actualCreateInviteTeamMembers =
               await this.teamService.PostInviteTeamMemberRequestAsync(inputInviteTeamMembers);

            // then
            actualCreateInviteTeamMembers.Should().BeEquivalentTo(expectedInviteTeamMembers);

            this.xPressWalletBrokerMock.Verify(broker =>
               broker.PostInviteTeamMemberAsync(It.Is(
                   SameExternalInviteTeamMembersRequestAs(mappedExternalInviteTeamMembersRequest))),
                   Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
        }
    }
}
