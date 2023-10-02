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
        public async Task ShouldThrowDependencyExceptionOnInviteTeamMembersRequestIfUrlNotFoundAsync()
        {
            // given
            

            dynamic createRandomInviteTeamMembersRequestProperties =
                 CreateRandomInviteTeamMembersRequestProperties();

            var createInviteTeamMembersRequest = new ExternalInviteTeamMembersRequest
            {
                ApprovalLimit = createRandomInviteTeamMembersRequestProperties.ApprovalLimit,
                Email = createRandomInviteTeamMembersRequestProperties.Email,
                RoleId = createRandomInviteTeamMembersRequestProperties.RoleId,
             
            };

            var createInviteTeamMembers = new InviteTeamMembers
            {
                Request = new InviteTeamMembersRequest
                {
                    ApprovalLimit = createRandomInviteTeamMembersRequestProperties.ApprovalLimit,
                    Email = createRandomInviteTeamMembersRequestProperties.Email,
                    RoleId = createRandomInviteTeamMembersRequestProperties.RoleId,
                },
            };




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
                broker.PostInviteTeamMemberAsync(It.IsAny<ExternalInviteTeamMembersRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<InviteTeamMembers> retrieveInviteTeamMembersTask =
               this.teamService.PostInviteTeamMemberRequestAsync(createInviteTeamMembers);

            TeamDependencyException
                actualTeamDependencyException =
                    await Assert.ThrowsAsync<TeamDependencyException>(
                        retrieveInviteTeamMembersTask.AsTask);

            // then
            actualTeamDependencyException.Should().BeEquivalentTo(
                expectedTeamDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostInviteTeamMemberAsync(It.IsAny<ExternalInviteTeamMembersRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnInviteTeamMembersRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            

            dynamic createRandomInviteTeamMembersRequestProperties =
             CreateRandomInviteTeamMembersRequestProperties();

            var createInviteTeamMembersRequest = new ExternalInviteTeamMembersRequest
            {
                ApprovalLimit = createRandomInviteTeamMembersRequestProperties.ApprovalLimit,
                Email = createRandomInviteTeamMembersRequestProperties.Email,
                RoleId = createRandomInviteTeamMembersRequestProperties.RoleId,

            };

            var createInviteTeamMembers = new InviteTeamMembers
            {
                Request = new InviteTeamMembersRequest
                {
                    ApprovalLimit = createRandomInviteTeamMembersRequestProperties.ApprovalLimit,
                    Email = createRandomInviteTeamMembersRequestProperties.Email,
                    RoleId = createRandomInviteTeamMembersRequestProperties.RoleId,
                },
            };


            var unauthorizedTeamException =
                new UnauthorizedTeamException(unauthorizedException);

            var expectedTeamDependencyException =
                new TeamDependencyException(unauthorizedTeamException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.PostInviteTeamMemberAsync(It.IsAny<ExternalInviteTeamMembersRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<InviteTeamMembers> retrieveInviteTeamMembersTask =
               this.teamService.PostInviteTeamMemberRequestAsync(createInviteTeamMembers);

            TeamDependencyException
                actualTeamDependencyException =
                    await Assert.ThrowsAsync<TeamDependencyException>(
                        retrieveInviteTeamMembersTask.AsTask);

            // then
            actualTeamDependencyException.Should().BeEquivalentTo(
                expectedTeamDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostInviteTeamMemberAsync(It.IsAny<ExternalInviteTeamMembersRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnInviteTeamMembersRequestIfNotFoundOccurredAsync()
        {
            // given
            

                dynamic createRandomInviteTeamMembersRequestProperties =
                 CreateRandomInviteTeamMembersRequestProperties();

            var createInviteTeamMembersRequest = new ExternalInviteTeamMembersRequest
            {
                ApprovalLimit = createRandomInviteTeamMembersRequestProperties.ApprovalLimit,
                Email = createRandomInviteTeamMembersRequestProperties.Email,
                RoleId = createRandomInviteTeamMembersRequestProperties.RoleId,
            };

            var createInviteTeamMembers = new InviteTeamMembers
            {
                Request = new InviteTeamMembersRequest
                {
                    ApprovalLimit = createRandomInviteTeamMembersRequestProperties.ApprovalLimit,
                    Email = createRandomInviteTeamMembersRequestProperties.Email,
                    RoleId = createRandomInviteTeamMembersRequestProperties.RoleId,
                },
            };


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
                broker.PostInviteTeamMemberAsync(It.IsAny<ExternalInviteTeamMembersRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<InviteTeamMembers> retrieveInviteTeamMembersTask =
               this.teamService.PostInviteTeamMemberRequestAsync(createInviteTeamMembers);

            TeamDependencyValidationException
                actualTeamDependencyValidationException =
                    await Assert.ThrowsAsync<TeamDependencyValidationException>(
                        retrieveInviteTeamMembersTask.AsTask);

            // then
            actualTeamDependencyValidationException.Should().BeEquivalentTo(
                expectedTeamDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostInviteTeamMemberAsync(It.IsAny<ExternalInviteTeamMembersRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnInviteTeamMembersRequestIfBadRequestOccurredAsync()
        {
            // given
            

                dynamic createRandomInviteTeamMembersRequestProperties =
                 CreateRandomInviteTeamMembersRequestProperties();

            var createInviteTeamMembersRequest = new ExternalInviteTeamMembersRequest
            {
                    ApprovalLimit = createRandomInviteTeamMembersRequestProperties.ApprovalLimit,
                Email = createRandomInviteTeamMembersRequestProperties.Email,
                RoleId = createRandomInviteTeamMembersRequestProperties.RoleId,
            };

            var createInviteTeamMembers = new InviteTeamMembers
            {
                Request = new InviteTeamMembersRequest
                {
                        ApprovalLimit = createRandomInviteTeamMembersRequestProperties.ApprovalLimit,
                Email = createRandomInviteTeamMembersRequestProperties.Email,
                RoleId = createRandomInviteTeamMembersRequestProperties.RoleId,
                },
            };

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
                broker.PostInviteTeamMemberAsync(It.IsAny<ExternalInviteTeamMembersRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<InviteTeamMembers> retrieveInviteTeamMembersTask =
               this.teamService.PostInviteTeamMemberRequestAsync(createInviteTeamMembers);

            TeamDependencyValidationException
                actualTeamDependencyValidationException =
                    await Assert.ThrowsAsync<TeamDependencyValidationException>(
                        retrieveInviteTeamMembersTask.AsTask);

            // then
            actualTeamDependencyValidationException.Should().BeEquivalentTo(
                expectedTeamDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostInviteTeamMemberAsync(It.IsAny<ExternalInviteTeamMembersRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnInviteTeamMembersRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            

                dynamic createRandomInviteTeamMembersRequestProperties =
                 CreateRandomInviteTeamMembersRequestProperties();

            var createInviteTeamMembersRequest = new ExternalInviteTeamMembersRequest
            {
                ApprovalLimit = createRandomInviteTeamMembersRequestProperties.ApprovalLimit,
                Email = createRandomInviteTeamMembersRequestProperties.Email,
                RoleId = createRandomInviteTeamMembersRequestProperties.RoleId,
            };

            var createInviteTeamMembers = new InviteTeamMembers
            {
                Request = new InviteTeamMembersRequest
                {
                    ApprovalLimit = createRandomInviteTeamMembersRequestProperties.ApprovalLimit,
                    Email = createRandomInviteTeamMembersRequestProperties.Email,
                    RoleId = createRandomInviteTeamMembersRequestProperties.RoleId,
                },
            };

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
                 broker.PostInviteTeamMemberAsync(It.IsAny<ExternalInviteTeamMembersRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<InviteTeamMembers> retrieveInviteTeamMembersTask =
               this.teamService.PostInviteTeamMemberRequestAsync(createInviteTeamMembers);

            TeamDependencyValidationException actualTeamDependencyValidationException =
                await Assert.ThrowsAsync<TeamDependencyValidationException>(
                    retrieveInviteTeamMembersTask.AsTask);

            // then
            actualTeamDependencyValidationException.Should().BeEquivalentTo(
                expectedTeamDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostInviteTeamMemberAsync(It.IsAny<ExternalInviteTeamMembersRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnInviteTeamMembersRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            

                dynamic createRandomInviteTeamMembersRequestProperties =
                 CreateRandomInviteTeamMembersRequestProperties();

            var createInviteTeamMembersRequest = new ExternalInviteTeamMembersRequest
            {
                ApprovalLimit = createRandomInviteTeamMembersRequestProperties.ApprovalLimit,
                Email = createRandomInviteTeamMembersRequestProperties.Email,
                RoleId = createRandomInviteTeamMembersRequestProperties.RoleId,
            };

            var createInviteTeamMembers = new InviteTeamMembers
            {
                Request = new InviteTeamMembersRequest
                {
                        ApprovalLimit = createRandomInviteTeamMembersRequestProperties.ApprovalLimit,
                Email = createRandomInviteTeamMembersRequestProperties.Email,
                RoleId = createRandomInviteTeamMembersRequestProperties.RoleId,
                },
            };

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
                 broker.PostInviteTeamMemberAsync(It.IsAny<ExternalInviteTeamMembersRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<InviteTeamMembers> retrieveInviteTeamMembersTask =
               this.teamService.PostInviteTeamMemberRequestAsync(createInviteTeamMembers);

            TeamDependencyException actualTeamDependencyException =
                await Assert.ThrowsAsync<TeamDependencyException>(
                    retrieveInviteTeamMembersTask.AsTask);

            // then
            actualTeamDependencyException.Should().BeEquivalentTo(
                expectedTeamDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostInviteTeamMemberAsync(It.IsAny<ExternalInviteTeamMembersRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnInviteTeamMembersRequestIfServiceErrorOccurredAsync()
        {
            // given
            

                dynamic createRandomInviteTeamMembersRequestProperties =
                 CreateRandomInviteTeamMembersRequestProperties();

            var createInviteTeamMembersRequest = new ExternalInviteTeamMembersRequest
            {
                                        ApprovalLimit = createRandomInviteTeamMembersRequestProperties.ApprovalLimit,
                Email = createRandomInviteTeamMembersRequestProperties.Email,
                RoleId = createRandomInviteTeamMembersRequestProperties.RoleId,
            };

            var createInviteTeamMembers = new InviteTeamMembers
            {
                Request = new InviteTeamMembersRequest
                {
                        ApprovalLimit = createRandomInviteTeamMembersRequestProperties.ApprovalLimit,
                Email = createRandomInviteTeamMembersRequestProperties.Email,
                RoleId = createRandomInviteTeamMembersRequestProperties.RoleId,
                },
            };
            var serviceException = new Exception();

            var failedTeamServiceException =
                new FailedTeamServiceException(serviceException);

            var expectedTeamServiceException =
                new TeamServiceException(failedTeamServiceException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostInviteTeamMemberAsync(It.IsAny<ExternalInviteTeamMembersRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<InviteTeamMembers> retrieveInviteTeamMembersTask =
               this.teamService.PostInviteTeamMemberRequestAsync(createInviteTeamMembers);

            TeamServiceException actualTeamServiceException =
                await Assert.ThrowsAsync<TeamServiceException>(
                    retrieveInviteTeamMembersTask.AsTask);

            // then
            actualTeamServiceException.Should().BeEquivalentTo(
                expectedTeamServiceException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostInviteTeamMemberAsync(It.IsAny<ExternalInviteTeamMembersRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
