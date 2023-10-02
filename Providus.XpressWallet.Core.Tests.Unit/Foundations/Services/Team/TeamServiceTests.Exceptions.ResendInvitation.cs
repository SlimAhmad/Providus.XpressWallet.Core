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
        public async Task ShouldThrowDependencyExceptionOnResendInvitationRequestIfUrlNotFoundAsync()
        {
            // given
            

            dynamic createRandomResendInvitationRequestProperties =
                 CreateRandomResendInvitationRequestProperties();

            var createResendInvitationRequest = new ExternalResendInvitationRequest
            {
                
                Email = createRandomResendInvitationRequestProperties.Email,
                
             
            };

            var createResendInvitation = new ResendInvitation
            {
                Request = new ResendInvitationRequest
                {
                    
                    Email = createRandomResendInvitationRequestProperties.Email,
                    
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
                broker.PostResendInvitationAsync(It.IsAny<ExternalResendInvitationRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<ResendInvitation> retrieveResendInvitationTask =
               this.teamService.PostResendInvitationRequestAsync(createResendInvitation);

            TeamDependencyException
                actualTeamDependencyException =
                    await Assert.ThrowsAsync<TeamDependencyException>(
                        retrieveResendInvitationTask.AsTask);

            // then
            actualTeamDependencyException.Should().BeEquivalentTo(
                expectedTeamDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostResendInvitationAsync(It.IsAny<ExternalResendInvitationRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnResendInvitationRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            

            dynamic createRandomResendInvitationRequestProperties =
             CreateRandomResendInvitationRequestProperties();

            var createResendInvitationRequest = new ExternalResendInvitationRequest
            {
                
                Email = createRandomResendInvitationRequestProperties.Email,
                

            };

            var createResendInvitation = new ResendInvitation
            {
                Request = new ResendInvitationRequest
                {
                    
                    Email = createRandomResendInvitationRequestProperties.Email,
                    
                },
            };


            var unauthorizedTeamException =
                new UnauthorizedTeamException(unauthorizedException);

            var expectedTeamDependencyException =
                new TeamDependencyException(unauthorizedTeamException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.PostResendInvitationAsync(It.IsAny<ExternalResendInvitationRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<ResendInvitation> retrieveResendInvitationTask =
               this.teamService.PostResendInvitationRequestAsync(createResendInvitation);

            TeamDependencyException
                actualTeamDependencyException =
                    await Assert.ThrowsAsync<TeamDependencyException>(
                        retrieveResendInvitationTask.AsTask);

            // then
            actualTeamDependencyException.Should().BeEquivalentTo(
                expectedTeamDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostResendInvitationAsync(It.IsAny<ExternalResendInvitationRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnResendInvitationRequestIfNotFoundOccurredAsync()
        {
            // given
            

                dynamic createRandomResendInvitationRequestProperties =
                 CreateRandomResendInvitationRequestProperties();

            var createResendInvitationRequest = new ExternalResendInvitationRequest
            {
                
                Email = createRandomResendInvitationRequestProperties.Email,
                
            };

            var createResendInvitation = new ResendInvitation
            {
                Request = new ResendInvitationRequest
                {
                    
                    Email = createRandomResendInvitationRequestProperties.Email,
                    
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
                broker.PostResendInvitationAsync(It.IsAny<ExternalResendInvitationRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<ResendInvitation> retrieveResendInvitationTask =
               this.teamService.PostResendInvitationRequestAsync(createResendInvitation);

            TeamDependencyValidationException
                actualTeamDependencyValidationException =
                    await Assert.ThrowsAsync<TeamDependencyValidationException>(
                        retrieveResendInvitationTask.AsTask);

            // then
            actualTeamDependencyValidationException.Should().BeEquivalentTo(
                expectedTeamDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostResendInvitationAsync(It.IsAny<ExternalResendInvitationRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnResendInvitationRequestIfBadRequestOccurredAsync()
        {
            // given
            

                dynamic createRandomResendInvitationRequestProperties =
                 CreateRandomResendInvitationRequestProperties();

            var createResendInvitationRequest = new ExternalResendInvitationRequest
            {
                    
                Email = createRandomResendInvitationRequestProperties.Email,
                
            };

            var createResendInvitation = new ResendInvitation
            {
                Request = new ResendInvitationRequest
                {
                        
                Email = createRandomResendInvitationRequestProperties.Email,
                
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
                broker.PostResendInvitationAsync(It.IsAny<ExternalResendInvitationRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<ResendInvitation> retrieveResendInvitationTask =
               this.teamService.PostResendInvitationRequestAsync(createResendInvitation);

            TeamDependencyValidationException
                actualTeamDependencyValidationException =
                    await Assert.ThrowsAsync<TeamDependencyValidationException>(
                        retrieveResendInvitationTask.AsTask);

            // then
            actualTeamDependencyValidationException.Should().BeEquivalentTo(
                expectedTeamDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostResendInvitationAsync(It.IsAny<ExternalResendInvitationRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnResendInvitationRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            

                dynamic createRandomResendInvitationRequestProperties =
                 CreateRandomResendInvitationRequestProperties();

            var createResendInvitationRequest = new ExternalResendInvitationRequest
            {
                
                Email = createRandomResendInvitationRequestProperties.Email,
                
            };

            var createResendInvitation = new ResendInvitation
            {
                Request = new ResendInvitationRequest
                {
                    
                    Email = createRandomResendInvitationRequestProperties.Email,
                    
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
                 broker.PostResendInvitationAsync(It.IsAny<ExternalResendInvitationRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<ResendInvitation> retrieveResendInvitationTask =
               this.teamService.PostResendInvitationRequestAsync(createResendInvitation);

            TeamDependencyValidationException actualTeamDependencyValidationException =
                await Assert.ThrowsAsync<TeamDependencyValidationException>(
                    retrieveResendInvitationTask.AsTask);

            // then
            actualTeamDependencyValidationException.Should().BeEquivalentTo(
                expectedTeamDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostResendInvitationAsync(It.IsAny<ExternalResendInvitationRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnResendInvitationRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            

                dynamic createRandomResendInvitationRequestProperties =
                 CreateRandomResendInvitationRequestProperties();

            var createResendInvitationRequest = new ExternalResendInvitationRequest
            {
                
                Email = createRandomResendInvitationRequestProperties.Email,
                
            };

            var createResendInvitation = new ResendInvitation
            {
                Request = new ResendInvitationRequest
                {
                        
                Email = createRandomResendInvitationRequestProperties.Email,
                
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
                 broker.PostResendInvitationAsync(It.IsAny<ExternalResendInvitationRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<ResendInvitation> retrieveResendInvitationTask =
               this.teamService.PostResendInvitationRequestAsync(createResendInvitation);

            TeamDependencyException actualTeamDependencyException =
                await Assert.ThrowsAsync<TeamDependencyException>(
                    retrieveResendInvitationTask.AsTask);

            // then
            actualTeamDependencyException.Should().BeEquivalentTo(
                expectedTeamDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostResendInvitationAsync(It.IsAny<ExternalResendInvitationRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnResendInvitationRequestIfServiceErrorOccurredAsync()
        {
            // given
            

                dynamic createRandomResendInvitationRequestProperties =
                 CreateRandomResendInvitationRequestProperties();

            var createResendInvitationRequest = new ExternalResendInvitationRequest
            {
                                        
                Email = createRandomResendInvitationRequestProperties.Email,
                
            };

            var createResendInvitation = new ResendInvitation
            {
                Request = new ResendInvitationRequest
                {
                        
                Email = createRandomResendInvitationRequestProperties.Email,
                
                },
            };
            var serviceException = new Exception();

            var failedTeamServiceException =
                new FailedTeamServiceException(serviceException);

            var expectedTeamServiceException =
                new TeamServiceException(failedTeamServiceException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostResendInvitationAsync(It.IsAny<ExternalResendInvitationRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<ResendInvitation> retrieveResendInvitationTask =
               this.teamService.PostResendInvitationRequestAsync(createResendInvitation);

            TeamServiceException actualTeamServiceException =
                await Assert.ThrowsAsync<TeamServiceException>(
                    retrieveResendInvitationTask.AsTask);

            // then
            actualTeamServiceException.Should().BeEquivalentTo(
                expectedTeamServiceException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostResendInvitationAsync(It.IsAny<ExternalResendInvitationRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
