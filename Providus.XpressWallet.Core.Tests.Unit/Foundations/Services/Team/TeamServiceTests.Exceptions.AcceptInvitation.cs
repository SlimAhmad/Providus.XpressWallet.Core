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
        public async Task ShouldThrowDependencyExceptionOnAcceptInvitationRequestIfUrlNotFoundAsync()
        {
            // given
            

            dynamic createRandomAcceptInvitationRequestProperties =
                 CreateRandomAcceptInvitationRequestProperties();

            var createAcceptInvitationRequest = new ExternalAcceptInvitationRequest
            {

                FirstName = createRandomAcceptInvitationRequestProperties.FirstName,
                InvitationCode = createRandomAcceptInvitationRequestProperties.InvitationCode,
                LastName = createRandomAcceptInvitationRequestProperties.LastName,
                Password = createRandomAcceptInvitationRequestProperties.Password,
                PhoneNumber = createRandomAcceptInvitationRequestProperties.PhoneNumber


            };

            var createAcceptInvitation = new AcceptInvitation
            {
                Request = new AcceptInvitationRequest
                {
                    
                     FirstName = createRandomAcceptInvitationRequestProperties.FirstName,
                InvitationCode = createRandomAcceptInvitationRequestProperties.InvitationCode,
                LastName = createRandomAcceptInvitationRequestProperties.LastName,
                Password = createRandomAcceptInvitationRequestProperties.Password,
                PhoneNumber = createRandomAcceptInvitationRequestProperties.PhoneNumber
                    
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
                broker.PostAcceptInvitationAsync(It.IsAny<ExternalAcceptInvitationRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<AcceptInvitation> retrieveAcceptInvitationTask =
               this.teamService.PostAcceptInvitationRequestAsync(createAcceptInvitation);

            TeamDependencyException
                actualTeamDependencyException =
                    await Assert.ThrowsAsync<TeamDependencyException>(
                        retrieveAcceptInvitationTask.AsTask);

            // then
            actualTeamDependencyException.Should().BeEquivalentTo(
                expectedTeamDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostAcceptInvitationAsync(It.IsAny<ExternalAcceptInvitationRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnAcceptInvitationRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            

            dynamic createRandomAcceptInvitationRequestProperties =
             CreateRandomAcceptInvitationRequestProperties();

            var createAcceptInvitationRequest = new ExternalAcceptInvitationRequest
            {
                
                 FirstName = createRandomAcceptInvitationRequestProperties.FirstName,
                InvitationCode = createRandomAcceptInvitationRequestProperties.InvitationCode,
                LastName = createRandomAcceptInvitationRequestProperties.LastName,
                Password = createRandomAcceptInvitationRequestProperties.Password,
                PhoneNumber = createRandomAcceptInvitationRequestProperties.PhoneNumber
                

            };

            var createAcceptInvitation = new AcceptInvitation
            {
                Request = new AcceptInvitationRequest
                {
                    
                     FirstName = createRandomAcceptInvitationRequestProperties.FirstName,
                InvitationCode = createRandomAcceptInvitationRequestProperties.InvitationCode,
                LastName = createRandomAcceptInvitationRequestProperties.LastName,
                Password = createRandomAcceptInvitationRequestProperties.Password,
                PhoneNumber = createRandomAcceptInvitationRequestProperties.PhoneNumber
                    
                },
            };


            var unauthorizedTeamException =
                new UnauthorizedTeamException(unauthorizedException);

            var expectedTeamDependencyException =
                new TeamDependencyException(unauthorizedTeamException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.PostAcceptInvitationAsync(It.IsAny<ExternalAcceptInvitationRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<AcceptInvitation> retrieveAcceptInvitationTask =
               this.teamService.PostAcceptInvitationRequestAsync(createAcceptInvitation);

            TeamDependencyException
                actualTeamDependencyException =
                    await Assert.ThrowsAsync<TeamDependencyException>(
                        retrieveAcceptInvitationTask.AsTask);

            // then
            actualTeamDependencyException.Should().BeEquivalentTo(
                expectedTeamDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostAcceptInvitationAsync(It.IsAny<ExternalAcceptInvitationRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnAcceptInvitationRequestIfNotFoundOccurredAsync()
        {
            // given
            

                dynamic createRandomAcceptInvitationRequestProperties =
                 CreateRandomAcceptInvitationRequestProperties();

            var createAcceptInvitationRequest = new ExternalAcceptInvitationRequest
            {
                
                 FirstName = createRandomAcceptInvitationRequestProperties.FirstName,
                InvitationCode = createRandomAcceptInvitationRequestProperties.InvitationCode,
                LastName = createRandomAcceptInvitationRequestProperties.LastName,
                Password = createRandomAcceptInvitationRequestProperties.Password,
                PhoneNumber = createRandomAcceptInvitationRequestProperties.PhoneNumber
                
            };

            var createAcceptInvitation = new AcceptInvitation
            {
                Request = new AcceptInvitationRequest
                {
                    
                     FirstName = createRandomAcceptInvitationRequestProperties.FirstName,
                InvitationCode = createRandomAcceptInvitationRequestProperties.InvitationCode,
                LastName = createRandomAcceptInvitationRequestProperties.LastName,
                Password = createRandomAcceptInvitationRequestProperties.Password,
                PhoneNumber = createRandomAcceptInvitationRequestProperties.PhoneNumber
                    
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
                broker.PostAcceptInvitationAsync(It.IsAny<ExternalAcceptInvitationRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<AcceptInvitation> retrieveAcceptInvitationTask =
               this.teamService.PostAcceptInvitationRequestAsync(createAcceptInvitation);

            TeamDependencyValidationException
                actualTeamDependencyValidationException =
                    await Assert.ThrowsAsync<TeamDependencyValidationException>(
                        retrieveAcceptInvitationTask.AsTask);

            // then
            actualTeamDependencyValidationException.Should().BeEquivalentTo(
                expectedTeamDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostAcceptInvitationAsync(It.IsAny<ExternalAcceptInvitationRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnAcceptInvitationRequestIfBadRequestOccurredAsync()
        {
            // given
            

                dynamic createRandomAcceptInvitationRequestProperties =
                 CreateRandomAcceptInvitationRequestProperties();

            var createAcceptInvitationRequest = new ExternalAcceptInvitationRequest
            {
                    
                 FirstName = createRandomAcceptInvitationRequestProperties.FirstName,
                InvitationCode = createRandomAcceptInvitationRequestProperties.InvitationCode,
                LastName = createRandomAcceptInvitationRequestProperties.LastName,
                Password = createRandomAcceptInvitationRequestProperties.Password,
                PhoneNumber = createRandomAcceptInvitationRequestProperties.PhoneNumber
                
            };

            var createAcceptInvitation = new AcceptInvitation
            {
                Request = new AcceptInvitationRequest
                {
                        
                 FirstName = createRandomAcceptInvitationRequestProperties.FirstName,
                InvitationCode = createRandomAcceptInvitationRequestProperties.InvitationCode,
                LastName = createRandomAcceptInvitationRequestProperties.LastName,
                Password = createRandomAcceptInvitationRequestProperties.Password,
                PhoneNumber = createRandomAcceptInvitationRequestProperties.PhoneNumber
                
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
                broker.PostAcceptInvitationAsync(It.IsAny<ExternalAcceptInvitationRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<AcceptInvitation> retrieveAcceptInvitationTask =
               this.teamService.PostAcceptInvitationRequestAsync(createAcceptInvitation);

            TeamDependencyValidationException
                actualTeamDependencyValidationException =
                    await Assert.ThrowsAsync<TeamDependencyValidationException>(
                        retrieveAcceptInvitationTask.AsTask);

            // then
            actualTeamDependencyValidationException.Should().BeEquivalentTo(
                expectedTeamDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostAcceptInvitationAsync(It.IsAny<ExternalAcceptInvitationRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnAcceptInvitationRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            

                dynamic createRandomAcceptInvitationRequestProperties =
                 CreateRandomAcceptInvitationRequestProperties();

            var createAcceptInvitationRequest = new ExternalAcceptInvitationRequest
            {
                
                 FirstName = createRandomAcceptInvitationRequestProperties.FirstName,
                InvitationCode = createRandomAcceptInvitationRequestProperties.InvitationCode,
                LastName = createRandomAcceptInvitationRequestProperties.LastName,
                Password = createRandomAcceptInvitationRequestProperties.Password,
                PhoneNumber = createRandomAcceptInvitationRequestProperties.PhoneNumber
                
            };

            var createAcceptInvitation = new AcceptInvitation
            {
                Request = new AcceptInvitationRequest
                {
                    
                     FirstName = createRandomAcceptInvitationRequestProperties.FirstName,
                InvitationCode = createRandomAcceptInvitationRequestProperties.InvitationCode,
                LastName = createRandomAcceptInvitationRequestProperties.LastName,
                Password = createRandomAcceptInvitationRequestProperties.Password,
                PhoneNumber = createRandomAcceptInvitationRequestProperties.PhoneNumber
                    
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
                 broker.PostAcceptInvitationAsync(It.IsAny<ExternalAcceptInvitationRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<AcceptInvitation> retrieveAcceptInvitationTask =
               this.teamService.PostAcceptInvitationRequestAsync(createAcceptInvitation);

            TeamDependencyValidationException actualTeamDependencyValidationException =
                await Assert.ThrowsAsync<TeamDependencyValidationException>(
                    retrieveAcceptInvitationTask.AsTask);

            // then
            actualTeamDependencyValidationException.Should().BeEquivalentTo(
                expectedTeamDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostAcceptInvitationAsync(It.IsAny<ExternalAcceptInvitationRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnAcceptInvitationRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            

                dynamic createRandomAcceptInvitationRequestProperties =
                 CreateRandomAcceptInvitationRequestProperties();

            var createAcceptInvitationRequest = new ExternalAcceptInvitationRequest
            {
                
                 FirstName = createRandomAcceptInvitationRequestProperties.FirstName,
                InvitationCode = createRandomAcceptInvitationRequestProperties.InvitationCode,
                LastName = createRandomAcceptInvitationRequestProperties.LastName,
                Password = createRandomAcceptInvitationRequestProperties.Password,
                PhoneNumber = createRandomAcceptInvitationRequestProperties.PhoneNumber
                
            };

            var createAcceptInvitation = new AcceptInvitation
            {
                Request = new AcceptInvitationRequest
                {
                        
                 FirstName = createRandomAcceptInvitationRequestProperties.FirstName,
                InvitationCode = createRandomAcceptInvitationRequestProperties.InvitationCode,
                LastName = createRandomAcceptInvitationRequestProperties.LastName,
                Password = createRandomAcceptInvitationRequestProperties.Password,
                PhoneNumber = createRandomAcceptInvitationRequestProperties.PhoneNumber
                
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
                 broker.PostAcceptInvitationAsync(It.IsAny<ExternalAcceptInvitationRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<AcceptInvitation> retrieveAcceptInvitationTask =
               this.teamService.PostAcceptInvitationRequestAsync(createAcceptInvitation);

            TeamDependencyException actualTeamDependencyException =
                await Assert.ThrowsAsync<TeamDependencyException>(
                    retrieveAcceptInvitationTask.AsTask);

            // then
            actualTeamDependencyException.Should().BeEquivalentTo(
                expectedTeamDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostAcceptInvitationAsync(It.IsAny<ExternalAcceptInvitationRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnAcceptInvitationRequestIfServiceErrorOccurredAsync()
        {
            // given
            

                dynamic createRandomAcceptInvitationRequestProperties =
                 CreateRandomAcceptInvitationRequestProperties();

            var createAcceptInvitationRequest = new ExternalAcceptInvitationRequest
            {
                                        
                 FirstName = createRandomAcceptInvitationRequestProperties.FirstName,
                InvitationCode = createRandomAcceptInvitationRequestProperties.InvitationCode,
                LastName = createRandomAcceptInvitationRequestProperties.LastName,
                Password = createRandomAcceptInvitationRequestProperties.Password,
                PhoneNumber = createRandomAcceptInvitationRequestProperties.PhoneNumber
                
            };

            var createAcceptInvitation = new AcceptInvitation
            {
                Request = new AcceptInvitationRequest
                {
                        
                 FirstName = createRandomAcceptInvitationRequestProperties.FirstName,
                InvitationCode = createRandomAcceptInvitationRequestProperties.InvitationCode,
                LastName = createRandomAcceptInvitationRequestProperties.LastName,
                Password = createRandomAcceptInvitationRequestProperties.Password,
                PhoneNumber = createRandomAcceptInvitationRequestProperties.PhoneNumber
                
                },
            };
            var serviceException = new Exception();

            var failedTeamServiceException =
                new FailedTeamServiceException(serviceException);

            var expectedTeamServiceException =
                new TeamServiceException(failedTeamServiceException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostAcceptInvitationAsync(It.IsAny<ExternalAcceptInvitationRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<AcceptInvitation> retrieveAcceptInvitationTask =
               this.teamService.PostAcceptInvitationRequestAsync(createAcceptInvitation);

            TeamServiceException actualTeamServiceException =
                await Assert.ThrowsAsync<TeamServiceException>(
                    retrieveAcceptInvitationTask.AsTask);

            // then
            actualTeamServiceException.Should().BeEquivalentTo(
                expectedTeamServiceException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostAcceptInvitationAsync(It.IsAny<ExternalAcceptInvitationRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
