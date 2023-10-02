using FluentAssertions;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalTeam;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Team;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Team.Exceptions;
using RESTFulSense.Exceptions;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.Team
{
    public partial class TeamServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnAllInvitationsRequestIfUrlNotFoundAsync()
        {
            // given
            var inputPage = GetRandomNumber();
            var inputPerPage = GetRandomNumber();


            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException();

            var invalidConfigurationTeamException =
                new InvalidConfigurationTeamException(
                    message: "Invalid team configuration error occurred, contact support.",
                    httpResponseUrlNotFoundException);

            var expectedTeamDependencyException =
                new TeamDependencyException(
                    message: "Team dependency error occurred, contact support.",
                    invalidConfigurationTeamException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.GetAllInvitationsAsync(inputPage,inputPerPage))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<AllInvitations> retrieveAllInvitationsTask =
               this.teamService.GetAllInvitationsRequestAsync(inputPage, inputPerPage);

            TeamDependencyException
                actualTeamDependencyException =
                    await Assert.ThrowsAsync<TeamDependencyException>(
                        retrieveAllInvitationsTask.AsTask);

            // then
            actualTeamDependencyException.Should().BeEquivalentTo(
                expectedTeamDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetAllInvitationsAsync(inputPage,inputPerPage),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnAllInvitationsRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            var inputPage = GetRandomNumber();
            var inputPerPage = GetRandomNumber();

        
            var unauthorizedTeamException =
                new UnauthorizedTeamException(unauthorizedException);

            var expectedTeamDependencyException =
                new TeamDependencyException(unauthorizedTeamException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.GetAllInvitationsAsync(inputPage,inputPerPage))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<AllInvitations> retrieveAllInvitationsTask =
               this.teamService.GetAllInvitationsRequestAsync(inputPage,inputPerPage);

            TeamDependencyException
                actualTeamDependencyException =
                    await Assert.ThrowsAsync<TeamDependencyException>(
                        retrieveAllInvitationsTask.AsTask);

            // then
            actualTeamDependencyException.Should().BeEquivalentTo(
                expectedTeamDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetAllInvitationsAsync(inputPage,inputPerPage),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnAllInvitationsRequestIfNotFoundOccurredAsync()
        {
            // given
            var inputPage = GetRandomNumber();
            var inputPerPage = GetRandomNumber();



            var httpResponseNotFoundException =
                new HttpResponseNotFoundException();

            var notFoundTeamException =
                new NotFoundTeamException(
                    message: "Not found team error occurred, fix errors and try again.",
                    httpResponseNotFoundException);

            var expectedTeamDependencyValidationException =
                new TeamDependencyValidationException(
                    message: "Team dependency validation error occurred, contact support.",
                    notFoundTeamException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.GetAllInvitationsAsync(inputPage,inputPerPage))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<AllInvitations> retrieveAllInvitationsTask =
               this.teamService.GetAllInvitationsRequestAsync(inputPage,inputPerPage);

            TeamDependencyValidationException
                actualTeamDependencyValidationException =
                    await Assert.ThrowsAsync<TeamDependencyValidationException>(
                        retrieveAllInvitationsTask.AsTask);

            // then
            actualTeamDependencyValidationException.Should().BeEquivalentTo(
                expectedTeamDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetAllInvitationsAsync(inputPage,inputPerPage),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnAllInvitationsRequestIfBadRequestOccurredAsync()
        {
            // given
            var inputPage = GetRandomNumber();
            var inputPerPage = GetRandomNumber();

                

            var httpResponseBadRequestException =
                new HttpResponseBadRequestException();

            var invalidTeamException =
                new InvalidTeamException(
                    message: "Invalid team error occurred, fix errors and try again.",
                    httpResponseBadRequestException);

            var expectedTeamDependencyValidationException =
                new TeamDependencyValidationException(
                    message: "Team dependency validation error occurred, contact support.",
                    invalidTeamException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.GetAllInvitationsAsync(inputPage,inputPerPage))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<AllInvitations> retrieveAllInvitationsTask =
               this.teamService.GetAllInvitationsRequestAsync(inputPage,inputPerPage);

            TeamDependencyValidationException
                actualTeamDependencyValidationException =
                    await Assert.ThrowsAsync<TeamDependencyValidationException>(
                        retrieveAllInvitationsTask.AsTask);

            // then
            actualTeamDependencyValidationException.Should().BeEquivalentTo(
                expectedTeamDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetAllInvitationsAsync(inputPage,inputPerPage),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnAllInvitationsRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            var inputPage = GetRandomNumber();
            var inputPerPage = GetRandomNumber();

                

            var httpResponseTooManyRequestsException =
                new HttpResponseTooManyRequestsException();

            var excessiveCallTeamException =
                new ExcessiveCallTeamException(
                    message: "Excessive call error occurred, limit your calls.",
                    httpResponseTooManyRequestsException);

            var expectedTeamDependencyValidationException =
                new TeamDependencyValidationException(
                    message: "Team dependency validation error occurred, contact support.",
                    excessiveCallTeamException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.GetAllInvitationsAsync(inputPage,inputPerPage))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<AllInvitations> retrieveAllInvitationsTask =
               this.teamService.GetAllInvitationsRequestAsync(inputPage,inputPerPage);

            TeamDependencyValidationException actualTeamDependencyValidationException =
                await Assert.ThrowsAsync<TeamDependencyValidationException>(
                    retrieveAllInvitationsTask.AsTask);

            // then
            actualTeamDependencyValidationException.Should().BeEquivalentTo(
                expectedTeamDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetAllInvitationsAsync(inputPage,inputPerPage),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnAllInvitationsRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            var inputPage = GetRandomNumber();
            var inputPerPage = GetRandomNumber();

                

            var httpResponseException =
                new HttpResponseException();

            var failedServerTeamException =
                new FailedServerTeamException(
                    message: "Failed team server error occurred, contact support.",
                    httpResponseException);

            var expectedTeamDependencyException =
                new TeamDependencyException(
                    message: "Team dependency error occurred, contact support.",
                    failedServerTeamException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.GetAllInvitationsAsync(inputPage,inputPerPage))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<AllInvitations> retrieveAllInvitationsTask =
               this.teamService.GetAllInvitationsRequestAsync(inputPage,inputPerPage);

            TeamDependencyException actualTeamDependencyException =
                await Assert.ThrowsAsync<TeamDependencyException>(
                    retrieveAllInvitationsTask.AsTask);

            // then
            actualTeamDependencyException.Should().BeEquivalentTo(
                expectedTeamDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetAllInvitationsAsync(inputPage,inputPerPage),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnAllInvitationsRequestIfServiceErrorOccurredAsync()
        {
            // given
            var inputPage = GetRandomNumber();
            var inputPerPage = GetRandomNumber();

                
            var serviceException = new Exception();

            var failedTeamServiceException =
                new FailedTeamServiceException(serviceException);

            var expectedTeamServiceException =
                new TeamServiceException(failedTeamServiceException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.GetAllInvitationsAsync(inputPage,inputPerPage))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<AllInvitations> retrieveAllInvitationsTask =
               this.teamService.GetAllInvitationsRequestAsync(inputPage,inputPerPage);

            TeamServiceException actualTeamServiceException =
                await Assert.ThrowsAsync<TeamServiceException>(
                    retrieveAllInvitationsTask.AsTask);

            // then
            actualTeamServiceException.Should().BeEquivalentTo(
                expectedTeamServiceException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetAllInvitationsAsync(inputPage,inputPerPage),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
