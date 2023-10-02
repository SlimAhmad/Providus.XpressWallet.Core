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
        public async Task ShouldThrowDependencyExceptionOnSwitchMerchantRequestIfUrlNotFoundAsync()
        {
            // given
            

            dynamic createRandomSwitchMerchantRequestProperties =
                 CreateRandomSwitchMerchantRequestProperties();

            var createSwitchMerchantRequest = new ExternalSwitchMerchantRequest
            {
                
                MerchantId = createRandomSwitchMerchantRequestProperties.MerchantId,
                
             
            };

            var createSwitchMerchant = new SwitchMerchant
            {
                Request = new SwitchMerchantRequest
                {

                    MerchantId = createRandomSwitchMerchantRequestProperties.MerchantId,

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
                broker.PostSwitchMerchantAsync(It.IsAny<ExternalSwitchMerchantRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<SwitchMerchant> retrieveSwitchMerchantTask =
               this.teamService.PostSwitchMerchantRequestAsync(createSwitchMerchant);

            TeamDependencyException
                actualTeamDependencyException =
                    await Assert.ThrowsAsync<TeamDependencyException>(
                        retrieveSwitchMerchantTask.AsTask);

            // then
            actualTeamDependencyException.Should().BeEquivalentTo(
                expectedTeamDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostSwitchMerchantAsync(It.IsAny<ExternalSwitchMerchantRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnSwitchMerchantRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            

            dynamic createRandomSwitchMerchantRequestProperties =
             CreateRandomSwitchMerchantRequestProperties();

            var createSwitchMerchantRequest = new ExternalSwitchMerchantRequest
            {
                
                MerchantId = createRandomSwitchMerchantRequestProperties.MerchantId,
                

            };

            var createSwitchMerchant = new SwitchMerchant
            {
                Request = new SwitchMerchantRequest
                {

                    MerchantId = createRandomSwitchMerchantRequestProperties.MerchantId,

                },
            };


            var unauthorizedTeamException =
                new UnauthorizedTeamException(unauthorizedException);

            var expectedTeamDependencyException =
                new TeamDependencyException(unauthorizedTeamException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.PostSwitchMerchantAsync(It.IsAny<ExternalSwitchMerchantRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<SwitchMerchant> retrieveSwitchMerchantTask =
               this.teamService.PostSwitchMerchantRequestAsync(createSwitchMerchant);

            TeamDependencyException
                actualTeamDependencyException =
                    await Assert.ThrowsAsync<TeamDependencyException>(
                        retrieveSwitchMerchantTask.AsTask);

            // then
            actualTeamDependencyException.Should().BeEquivalentTo(
                expectedTeamDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostSwitchMerchantAsync(It.IsAny<ExternalSwitchMerchantRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnSwitchMerchantRequestIfNotFoundOccurredAsync()
        {
            // given
            

                dynamic createRandomSwitchMerchantRequestProperties =
                 CreateRandomSwitchMerchantRequestProperties();

            var createSwitchMerchantRequest = new ExternalSwitchMerchantRequest
            {
                
                MerchantId = createRandomSwitchMerchantRequestProperties.MerchantId,
                
            };

            var createSwitchMerchant = new SwitchMerchant
            {
                Request = new SwitchMerchantRequest
                {
                    
                    MerchantId = createRandomSwitchMerchantRequestProperties.MerchantId,
                    
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
                broker.PostSwitchMerchantAsync(It.IsAny<ExternalSwitchMerchantRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<SwitchMerchant> retrieveSwitchMerchantTask =
               this.teamService.PostSwitchMerchantRequestAsync(createSwitchMerchant);

            TeamDependencyValidationException
                actualTeamDependencyValidationException =
                    await Assert.ThrowsAsync<TeamDependencyValidationException>(
                        retrieveSwitchMerchantTask.AsTask);

            // then
            actualTeamDependencyValidationException.Should().BeEquivalentTo(
                expectedTeamDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostSwitchMerchantAsync(It.IsAny<ExternalSwitchMerchantRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnSwitchMerchantRequestIfBadRequestOccurredAsync()
        {
            // given
            

                dynamic createRandomSwitchMerchantRequestProperties =
                 CreateRandomSwitchMerchantRequestProperties();

            var createSwitchMerchantRequest = new ExternalSwitchMerchantRequest
            {
                    
                MerchantId = createRandomSwitchMerchantRequestProperties.MerchantId,
                
            };

            var createSwitchMerchant = new SwitchMerchant
            {
                Request = new SwitchMerchantRequest
                {
                        
                MerchantId = createRandomSwitchMerchantRequestProperties.MerchantId,
                
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
                broker.PostSwitchMerchantAsync(It.IsAny<ExternalSwitchMerchantRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<SwitchMerchant> retrieveSwitchMerchantTask =
               this.teamService.PostSwitchMerchantRequestAsync(createSwitchMerchant);

            TeamDependencyValidationException
                actualTeamDependencyValidationException =
                    await Assert.ThrowsAsync<TeamDependencyValidationException>(
                        retrieveSwitchMerchantTask.AsTask);

            // then
            actualTeamDependencyValidationException.Should().BeEquivalentTo(
                expectedTeamDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostSwitchMerchantAsync(It.IsAny<ExternalSwitchMerchantRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnSwitchMerchantRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            

                dynamic createRandomSwitchMerchantRequestProperties =
                 CreateRandomSwitchMerchantRequestProperties();

            var createSwitchMerchantRequest = new ExternalSwitchMerchantRequest
            {
                
                MerchantId = createRandomSwitchMerchantRequestProperties.MerchantId,
                
            };

            var createSwitchMerchant = new SwitchMerchant
            {
                Request = new SwitchMerchantRequest
                {
                    
                    MerchantId = createRandomSwitchMerchantRequestProperties.MerchantId,
                    
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
                 broker.PostSwitchMerchantAsync(It.IsAny<ExternalSwitchMerchantRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<SwitchMerchant> retrieveSwitchMerchantTask =
               this.teamService.PostSwitchMerchantRequestAsync(createSwitchMerchant);

            TeamDependencyValidationException actualTeamDependencyValidationException =
                await Assert.ThrowsAsync<TeamDependencyValidationException>(
                    retrieveSwitchMerchantTask.AsTask);

            // then
            actualTeamDependencyValidationException.Should().BeEquivalentTo(
                expectedTeamDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostSwitchMerchantAsync(It.IsAny<ExternalSwitchMerchantRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnSwitchMerchantRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            

                dynamic createRandomSwitchMerchantRequestProperties =
                 CreateRandomSwitchMerchantRequestProperties();

            var createSwitchMerchantRequest = new ExternalSwitchMerchantRequest
            {
                
                MerchantId = createRandomSwitchMerchantRequestProperties.MerchantId,
                
            };

            var createSwitchMerchant = new SwitchMerchant
            {
                Request = new SwitchMerchantRequest
                {
                        
                MerchantId = createRandomSwitchMerchantRequestProperties.MerchantId,
                
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
                 broker.PostSwitchMerchantAsync(It.IsAny<ExternalSwitchMerchantRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<SwitchMerchant> retrieveSwitchMerchantTask =
               this.teamService.PostSwitchMerchantRequestAsync(createSwitchMerchant);

            TeamDependencyException actualTeamDependencyException =
                await Assert.ThrowsAsync<TeamDependencyException>(
                    retrieveSwitchMerchantTask.AsTask);

            // then
            actualTeamDependencyException.Should().BeEquivalentTo(
                expectedTeamDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostSwitchMerchantAsync(It.IsAny<ExternalSwitchMerchantRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnSwitchMerchantRequestIfServiceErrorOccurredAsync()
        {
            // given
            

                dynamic createRandomSwitchMerchantRequestProperties =
                 CreateRandomSwitchMerchantRequestProperties();

            var createSwitchMerchantRequest = new ExternalSwitchMerchantRequest
            {
                                        
                MerchantId = createRandomSwitchMerchantRequestProperties.MerchantId,
                
            };

            var createSwitchMerchant = new SwitchMerchant
            {
                Request = new SwitchMerchantRequest
                {
                        
                MerchantId = createRandomSwitchMerchantRequestProperties.MerchantId,
                
                },
            };
            var serviceException = new Exception();

            var failedTeamServiceException =
                new FailedTeamServiceException(serviceException);

            var expectedTeamServiceException =
                new TeamServiceException(failedTeamServiceException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostSwitchMerchantAsync(It.IsAny<ExternalSwitchMerchantRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<SwitchMerchant> retrieveSwitchMerchantTask =
               this.teamService.PostSwitchMerchantRequestAsync(createSwitchMerchant);

            TeamServiceException actualTeamServiceException =
                await Assert.ThrowsAsync<TeamServiceException>(
                    retrieveSwitchMerchantTask.AsTask);

            // then
            actualTeamServiceException.Should().BeEquivalentTo(
                expectedTeamServiceException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostSwitchMerchantAsync(It.IsAny<ExternalSwitchMerchantRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
