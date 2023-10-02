using FluentAssertions;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalTeam;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Team;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.Team
{
    public partial class TeamServiceTests
    {
        [Fact]
        public async Task ShouldPostTeamMembersWithTeamMembersRequestAsync()
        {
            // given 


            dynamic createRandomTeamMembersResponseProperties =
                CreateRandomTeamMembersResponseProperties();



            var randomExternalTeamMembersResponse = new ExternalTeamMembersResponse
            {

                Data = ((List<dynamic>)createRandomTeamMembersResponseProperties.Data).Select(data => 
                {
                    return new ExternalTeamMembersResponse.Datum
                    {
                        Role = data.Role,
                        Id = data.Id,
                        Email = data.Email,
                        ApprovalLimit = data.ApprovalLimit,
                        FirstName = data.FirstName,
                        LastName = data.LastName,
                    };
                }).ToList(),
               
                Status = createRandomTeamMembersResponseProperties.Status
                   
            };


   
            var randomTeamMembersResponse = new TeamMembersResponse
            {
                Data = ((List<dynamic>)createRandomTeamMembersResponseProperties.Data).Select(data =>
                {
                    return new TeamMembersResponse.Datum
                    {
                        Role = data.Role,
                        Id = data.Id,
                        Email = data.Email,
                        ApprovalLimit = data.ApprovalLimit,
                        FirstName = data.FirstName,
                        LastName = data.LastName,
                    };
                }).ToList(),

                Status = createRandomTeamMembersResponseProperties.Status

            };



            var expectedResponse = new TeamMembers
            {
                Response = randomTeamMembersResponse
            };

           

            ExternalTeamMembersResponse returnedExternalTeamMembersResponse =
                randomExternalTeamMembersResponse;

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.GetTeamMembersAsync())
                     .ReturnsAsync(returnedExternalTeamMembersResponse);

            // when
            TeamMembers actualCreateTeamMembers =
               await this.teamService.GetTeamMembersRequestAsync();

            // then
            actualCreateTeamMembers.Should().BeEquivalentTo(expectedResponse);

            this.xPressWalletBrokerMock.Verify(broker =>
               broker.GetTeamMembersAsync(),
                   Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
        }
    }
}
