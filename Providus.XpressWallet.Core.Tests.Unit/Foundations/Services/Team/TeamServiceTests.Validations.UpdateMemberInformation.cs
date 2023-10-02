using FluentAssertions;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalTeam;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Team;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Team.Exceptions;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.Team
{
    public partial class TeamServiceTests
    {

        [Fact]
        public async Task ShouldThrowValidationExceptionOnUpdateMemberInformationIfUpdateMemberInformationIsNullAsync()
        {
            // given
            var inputMemberId = GetRandomString();
            UpdateMemberInformation nullUpdateMemberInformation = null;
            var nullUpdateMemberInformationException = new NullTeamException();

        

            var exceptedTeamValidationException =
                new TeamValidationException(nullUpdateMemberInformationException);

            // when
            ValueTask<UpdateMemberInformation> UpdateMemberInformationTask =
                this.teamService.UpdateMemberInformationRequestAsync(nullUpdateMemberInformation, inputMemberId);

            TeamValidationException actualTeamValidationException =
                await Assert.ThrowsAsync<TeamValidationException>(
                    UpdateMemberInformationTask.AsTask);

            // then
            actualTeamValidationException.Should()
                .BeEquivalentTo(exceptedTeamValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.UpdateMemberInformationAsync(
                    It.IsAny<ExternalUpdateMemberInformationRequest>(), It.IsAny<string>()),
                        Times.Never);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnUpdateMemberInformationIfRequestIsNullAsync()
        {
            // given
            var inputMemberId = GetRandomString();
            var invalidUpdateMemberInformation = new UpdateMemberInformation();
            invalidUpdateMemberInformation.Request = null;
        

            var invalidUpdateMemberInformationException =
                new InvalidTeamException();

            invalidUpdateMemberInformationException.AddData(
                key: nameof(UpdateMemberInformationRequest),
                values: "Value is required");

            var expectedTeamValidationException =
                new TeamValidationException(
                    invalidUpdateMemberInformationException);

            // when
            ValueTask<UpdateMemberInformation> UpdateMemberInformationTask =
                this.teamService.UpdateMemberInformationRequestAsync(invalidUpdateMemberInformation,inputMemberId);

            TeamValidationException actualTeamValidationException =
                await Assert.ThrowsAsync<TeamValidationException>(
                    UpdateMemberInformationTask.AsTask);

            // then
            actualTeamValidationException.Should()
                .BeEquivalentTo(expectedTeamValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.UpdateMemberInformationAsync(
                    It.IsAny<ExternalUpdateMemberInformationRequest>(), It.IsAny<string>()),
                        Times.Never);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }



        [Fact]
        public async Task ShouldThrowValidationExceptionOnUpdateMemberInformationIfUpdateMemberInformationIsEmptyAsync()
        {
            // given
            var inputMemberId = string.Empty;
            var accountVerificationRequest = new UpdateMemberInformation
            {
                Request = new UpdateMemberInformationRequest
                {

                     RoleId = string.Empty,
                   


                }
            };
            

            var invalidUpdateMemberInformationException = new InvalidTeamException();


            invalidUpdateMemberInformationException.AddData(
                       key: nameof(UpdateMemberInformationRequest.RoleId),
                       values: "Value is required");

            invalidUpdateMemberInformationException.AddData(
                           key: nameof(UpdateMemberInformationRequest.ApprovalLimit),
                           values: "Value is required");

            var expectedTeamValidationException =
                new TeamValidationException(invalidUpdateMemberInformationException);

            // when
            ValueTask<UpdateMemberInformation> UpdateMemberInformationTask =
                this.teamService.UpdateMemberInformationRequestAsync(accountVerificationRequest, inputMemberId);

            TeamValidationException actualTeamValidationException =
                await Assert.ThrowsAsync<TeamValidationException>(
                    UpdateMemberInformationTask.AsTask);

            // then
            actualTeamValidationException.Should().BeEquivalentTo(
                expectedTeamValidationException);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

    }
}