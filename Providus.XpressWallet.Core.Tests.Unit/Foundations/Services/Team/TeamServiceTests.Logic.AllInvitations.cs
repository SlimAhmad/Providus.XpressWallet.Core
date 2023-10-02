using FluentAssertions;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalTeam;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Team;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.Team
{
    public partial class TeamServiceTests
    {
        [Fact]
        public async Task ShouldPostAllInvitationsWithAllInvitationsRequestAsync()
        {
            // given 
            var inputPage = GetRandomNumber();
            var inputPerPage = GetRandomNumber();

            dynamic createRandomAllInvitationsResponseProperties =
                CreateRandomAllInvitationsResponseProperties();



            var randomExternalAllInvitationsResponse = new ExternalAllInvitationsResponse
            {

                Data = ((List<dynamic>)createRandomAllInvitationsResponseProperties.Data).Select(data => 
                {
                    return new ExternalAllInvitationsResponse.Datum
                    {
                        Accepted = data.Accepted,
                        CreatedAt = data.CreatedAt,
                        Email = data.Email,
                        Id = data.Id,
                        Role = data.Role,
                        UpdatedAt = data.UpdatedAt,
                    };
                }).ToList(),
               
                Status = createRandomAllInvitationsResponseProperties.Status
                   
            };


   
            var randomAllInvitationsResponse = new AllInvitationsResponse
            {
                Data = ((List<dynamic>)createRandomAllInvitationsResponseProperties.Data).Select(data =>
                {
                    return new AllInvitationsResponse.Datum
                    {
                        Accepted = data.Accepted,
                        CreatedAt = data.CreatedAt,
                        Email = data.Email,
                        Id = data.Id,
                        Role = data.Role,
                        UpdatedAt = data.UpdatedAt,
                    };
                }).ToList(),
                
                Status = createRandomAllInvitationsResponseProperties.Status

            };



            var expectedResponse = new AllInvitations
            {
                Response = randomAllInvitationsResponse
            };

           

            ExternalAllInvitationsResponse returnedExternalAllInvitationsResponse =
                randomExternalAllInvitationsResponse;

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.GetAllInvitationsAsync(inputPage, inputPerPage))
                     .ReturnsAsync(returnedExternalAllInvitationsResponse);

            // when
            AllInvitations actualCreateAllInvitations =
               await this.teamService.GetAllInvitationsRequestAsync(inputPage, inputPerPage);

            // then
            actualCreateAllInvitations.Should().BeEquivalentTo(expectedResponse);

            this.xPressWalletBrokerMock.Verify(broker =>
               broker.GetAllInvitationsAsync(inputPage, inputPerPage),
                   Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
        }
    }
}
