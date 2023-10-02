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
        public async Task ShouldThrowDependencyExceptionOnUpdateMemberInformationRequestIfUrlNotFoundAsync()
        {
            // given
            var inputMemberId = GetRandomString();
            

            dynamic createRandomUpdateMemberInformationRequestProperties =
                 CreateRandomUpdateMemberInformationRequestProperties();

            var createUpdateMemberInformationRequest = new ExternalUpdateMemberInformationRequest
            {
                
                 ApprovalLimit = createRandomUpdateMemberInformationRequestProperties.ApprovalLimit,
                 RoleId = createRandomUpdateMemberInformationRequestProperties.RoleId,
                
             
            };

            var createUpdateMemberInformation = new UpdateMemberInformation
            {
                Request = new UpdateMemberInformationRequest
                {

                    ApprovalLimit = createRandomUpdateMemberInformationRequestProperties.ApprovalLimit,
                    RoleId = createRandomUpdateMemberInformationRequestProperties.RoleId,

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
                broker.UpdateMemberInformationAsync(It.IsAny<ExternalUpdateMemberInformationRequest>(),It.IsAny<string>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<UpdateMemberInformation> retrieveUpdateMemberInformationTask =
               this.teamService.UpdateMemberInformationRequestAsync(createUpdateMemberInformation, inputMemberId);

            TeamDependencyException
                actualTeamDependencyException =
                    await Assert.ThrowsAsync<TeamDependencyException>(
                        retrieveUpdateMemberInformationTask.AsTask);

            // then
            actualTeamDependencyException.Should().BeEquivalentTo(
                expectedTeamDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.UpdateMemberInformationAsync(It.IsAny<ExternalUpdateMemberInformationRequest>(),It.IsAny<string>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnUpdateMemberInformationRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            var inputMemberId = GetRandomString();
            

            dynamic createRandomUpdateMemberInformationRequestProperties =
             CreateRandomUpdateMemberInformationRequestProperties();

            var createUpdateMemberInformationRequest = new ExternalUpdateMemberInformationRequest
            {
                
                ApprovalLimit = createRandomUpdateMemberInformationRequestProperties.ApprovalLimit,
                 RoleId = createRandomUpdateMemberInformationRequestProperties.RoleId,
                

            };

            var createUpdateMemberInformation = new UpdateMemberInformation
            {
                Request = new UpdateMemberInformationRequest
                {

                    ApprovalLimit = createRandomUpdateMemberInformationRequestProperties.ApprovalLimit,
                 RoleId = createRandomUpdateMemberInformationRequestProperties.RoleId,

                },
            };


            var unauthorizedTeamException =
                new UnauthorizedTeamException(unauthorizedException);

            var expectedTeamDependencyException =
                new TeamDependencyException(unauthorizedTeamException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.UpdateMemberInformationAsync(It.IsAny<ExternalUpdateMemberInformationRequest>(),It.IsAny<string>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<UpdateMemberInformation> retrieveUpdateMemberInformationTask =
               this.teamService.UpdateMemberInformationRequestAsync(createUpdateMemberInformation, inputMemberId);

            TeamDependencyException
                actualTeamDependencyException =
                    await Assert.ThrowsAsync<TeamDependencyException>(
                        retrieveUpdateMemberInformationTask.AsTask);

            // then
            actualTeamDependencyException.Should().BeEquivalentTo(
                expectedTeamDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.UpdateMemberInformationAsync(It.IsAny<ExternalUpdateMemberInformationRequest>(),It.IsAny<string>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnUpdateMemberInformationRequestIfNotFoundOccurredAsync()
        {
            // given
            var inputMemberId = GetRandomString();
            

                dynamic createRandomUpdateMemberInformationRequestProperties =
                 CreateRandomUpdateMemberInformationRequestProperties();

            var createUpdateMemberInformationRequest = new ExternalUpdateMemberInformationRequest
            {
                
                ApprovalLimit = createRandomUpdateMemberInformationRequestProperties.ApprovalLimit,
                 RoleId = createRandomUpdateMemberInformationRequestProperties.RoleId,
                
            };

            var createUpdateMemberInformation = new UpdateMemberInformation
            {
                Request = new UpdateMemberInformationRequest
                {
                    
                    ApprovalLimit = createRandomUpdateMemberInformationRequestProperties.ApprovalLimit,
                 RoleId = createRandomUpdateMemberInformationRequestProperties.RoleId,
                    
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
                broker.UpdateMemberInformationAsync(It.IsAny<ExternalUpdateMemberInformationRequest>(),It.IsAny<string>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<UpdateMemberInformation> retrieveUpdateMemberInformationTask =
               this.teamService.UpdateMemberInformationRequestAsync(createUpdateMemberInformation, inputMemberId);

            TeamDependencyValidationException
                actualTeamDependencyValidationException =
                    await Assert.ThrowsAsync<TeamDependencyValidationException>(
                        retrieveUpdateMemberInformationTask.AsTask);

            // then
            actualTeamDependencyValidationException.Should().BeEquivalentTo(
                expectedTeamDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.UpdateMemberInformationAsync(It.IsAny<ExternalUpdateMemberInformationRequest>(),It.IsAny<string>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnUpdateMemberInformationRequestIfBadRequestOccurredAsync()
        {
            // given
            var inputMemberId = GetRandomString();
            

                dynamic createRandomUpdateMemberInformationRequestProperties =
                 CreateRandomUpdateMemberInformationRequestProperties();

            var createUpdateMemberInformationRequest = new ExternalUpdateMemberInformationRequest
            {
                    
                ApprovalLimit = createRandomUpdateMemberInformationRequestProperties.ApprovalLimit,
                 RoleId = createRandomUpdateMemberInformationRequestProperties.RoleId,
                
            };

            var createUpdateMemberInformation = new UpdateMemberInformation
            {
                Request = new UpdateMemberInformationRequest
                {
                        
                ApprovalLimit = createRandomUpdateMemberInformationRequestProperties.ApprovalLimit,
                 RoleId = createRandomUpdateMemberInformationRequestProperties.RoleId,
                
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
                broker.UpdateMemberInformationAsync(It.IsAny<ExternalUpdateMemberInformationRequest>(),It.IsAny<string>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<UpdateMemberInformation> retrieveUpdateMemberInformationTask =
               this.teamService.UpdateMemberInformationRequestAsync(createUpdateMemberInformation, inputMemberId);

            TeamDependencyValidationException
                actualTeamDependencyValidationException =
                    await Assert.ThrowsAsync<TeamDependencyValidationException>(
                        retrieveUpdateMemberInformationTask.AsTask);

            // then
            actualTeamDependencyValidationException.Should().BeEquivalentTo(
                expectedTeamDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.UpdateMemberInformationAsync(It.IsAny<ExternalUpdateMemberInformationRequest>(),It.IsAny<string>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnUpdateMemberInformationRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            var inputMemberId = GetRandomString();
            

                dynamic createRandomUpdateMemberInformationRequestProperties =
                 CreateRandomUpdateMemberInformationRequestProperties();

            var createUpdateMemberInformationRequest = new ExternalUpdateMemberInformationRequest
            {
                
                ApprovalLimit = createRandomUpdateMemberInformationRequestProperties.ApprovalLimit,
                 RoleId = createRandomUpdateMemberInformationRequestProperties.RoleId,
                
            };

            var createUpdateMemberInformation = new UpdateMemberInformation
            {
                Request = new UpdateMemberInformationRequest
                {
                    
                    ApprovalLimit = createRandomUpdateMemberInformationRequestProperties.ApprovalLimit,
                 RoleId = createRandomUpdateMemberInformationRequestProperties.RoleId,
                    
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
                 broker.UpdateMemberInformationAsync(It.IsAny<ExternalUpdateMemberInformationRequest>(),It.IsAny<string>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<UpdateMemberInformation> retrieveUpdateMemberInformationTask =
               this.teamService.UpdateMemberInformationRequestAsync(createUpdateMemberInformation, inputMemberId);

            TeamDependencyValidationException actualTeamDependencyValidationException =
                await Assert.ThrowsAsync<TeamDependencyValidationException>(
                    retrieveUpdateMemberInformationTask.AsTask);

            // then
            actualTeamDependencyValidationException.Should().BeEquivalentTo(
                expectedTeamDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.UpdateMemberInformationAsync(It.IsAny<ExternalUpdateMemberInformationRequest>(),It.IsAny<string>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnUpdateMemberInformationRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            var inputMemberId = GetRandomString();
            

                dynamic createRandomUpdateMemberInformationRequestProperties =
                 CreateRandomUpdateMemberInformationRequestProperties();

            var createUpdateMemberInformationRequest = new ExternalUpdateMemberInformationRequest
            {
                
                ApprovalLimit = createRandomUpdateMemberInformationRequestProperties.ApprovalLimit,
                 RoleId = createRandomUpdateMemberInformationRequestProperties.RoleId,
                
            };

            var createUpdateMemberInformation = new UpdateMemberInformation
            {
                Request = new UpdateMemberInformationRequest
                {
                        
                ApprovalLimit = createRandomUpdateMemberInformationRequestProperties.ApprovalLimit,
                 RoleId = createRandomUpdateMemberInformationRequestProperties.RoleId,
                
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
                 broker.UpdateMemberInformationAsync(It.IsAny<ExternalUpdateMemberInformationRequest>(),It.IsAny<string>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<UpdateMemberInformation> retrieveUpdateMemberInformationTask =
               this.teamService.UpdateMemberInformationRequestAsync(createUpdateMemberInformation, inputMemberId);

            TeamDependencyException actualTeamDependencyException =
                await Assert.ThrowsAsync<TeamDependencyException>(
                    retrieveUpdateMemberInformationTask.AsTask);

            // then
            actualTeamDependencyException.Should().BeEquivalentTo(
                expectedTeamDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.UpdateMemberInformationAsync(It.IsAny<ExternalUpdateMemberInformationRequest>(),It.IsAny<string>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnUpdateMemberInformationRequestIfServiceErrorOccurredAsync()
        {
            // given
            var inputMemberId = GetRandomString();
            

                dynamic createRandomUpdateMemberInformationRequestProperties =
                 CreateRandomUpdateMemberInformationRequestProperties();

            var createUpdateMemberInformationRequest = new ExternalUpdateMemberInformationRequest
            {
                                        
                ApprovalLimit = createRandomUpdateMemberInformationRequestProperties.ApprovalLimit,
                 RoleId = createRandomUpdateMemberInformationRequestProperties.RoleId,
                
            };

            var createUpdateMemberInformation = new UpdateMemberInformation
            {
                Request = new UpdateMemberInformationRequest
                {
                        
                ApprovalLimit = createRandomUpdateMemberInformationRequestProperties.ApprovalLimit,
                 RoleId = createRandomUpdateMemberInformationRequestProperties.RoleId,
                
                },
            };
            var serviceException = new Exception();

            var failedTeamServiceException =
                new FailedTeamServiceException(serviceException);

            var expectedTeamServiceException =
                new TeamServiceException(failedTeamServiceException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.UpdateMemberInformationAsync(It.IsAny<ExternalUpdateMemberInformationRequest>(),It.IsAny<string>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<UpdateMemberInformation> retrieveUpdateMemberInformationTask =
               this.teamService.UpdateMemberInformationRequestAsync(createUpdateMemberInformation, inputMemberId);

            TeamServiceException actualTeamServiceException =
                await Assert.ThrowsAsync<TeamServiceException>(
                    retrieveUpdateMemberInformationTask.AsTask);

            // then
            actualTeamServiceException.Should().BeEquivalentTo(
                expectedTeamServiceException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.UpdateMemberInformationAsync(It.IsAny<ExternalUpdateMemberInformationRequest>(),It.IsAny<string>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
