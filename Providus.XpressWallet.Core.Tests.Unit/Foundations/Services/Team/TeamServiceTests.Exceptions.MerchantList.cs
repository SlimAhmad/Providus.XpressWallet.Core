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
        public async Task ShouldThrowDependencyExceptionOnMerchantListRequestIfUrlNotFoundAsync()
        {
            // given
            


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
                broker.GetMerchantListAsync())
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<MerchantList> retrieveMerchantListTask =
               this.teamService.GetMerchantListRequestAsync();

            TeamDependencyException
                actualTeamDependencyException =
                    await Assert.ThrowsAsync<TeamDependencyException>(
                        retrieveMerchantListTask.AsTask);

            // then
            actualTeamDependencyException.Should().BeEquivalentTo(
                expectedTeamDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetMerchantListAsync(),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnMerchantListRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            

        
            var unauthorizedTeamException =
                new UnauthorizedTeamException(unauthorizedException);

            var expectedTeamDependencyException =
                new TeamDependencyException(unauthorizedTeamException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.GetMerchantListAsync())
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<MerchantList> retrieveMerchantListTask =
               this.teamService.GetMerchantListRequestAsync();

            TeamDependencyException
                actualTeamDependencyException =
                    await Assert.ThrowsAsync<TeamDependencyException>(
                        retrieveMerchantListTask.AsTask);

            // then
            actualTeamDependencyException.Should().BeEquivalentTo(
                expectedTeamDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetMerchantListAsync(),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnMerchantListRequestIfNotFoundOccurredAsync()
        {
            // given
            



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
                broker.GetMerchantListAsync())
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<MerchantList> retrieveMerchantListTask =
               this.teamService.GetMerchantListRequestAsync();

            TeamDependencyValidationException
                actualTeamDependencyValidationException =
                    await Assert.ThrowsAsync<TeamDependencyValidationException>(
                        retrieveMerchantListTask.AsTask);

            // then
            actualTeamDependencyValidationException.Should().BeEquivalentTo(
                expectedTeamDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetMerchantListAsync(),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnMerchantListRequestIfBadRequestOccurredAsync()
        {
            // given
            

                

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
                broker.GetMerchantListAsync())
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<MerchantList> retrieveMerchantListTask =
               this.teamService.GetMerchantListRequestAsync();

            TeamDependencyValidationException
                actualTeamDependencyValidationException =
                    await Assert.ThrowsAsync<TeamDependencyValidationException>(
                        retrieveMerchantListTask.AsTask);

            // then
            actualTeamDependencyValidationException.Should().BeEquivalentTo(
                expectedTeamDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetMerchantListAsync(),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnMerchantListRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            

                

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
                 broker.GetMerchantListAsync())
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<MerchantList> retrieveMerchantListTask =
               this.teamService.GetMerchantListRequestAsync();

            TeamDependencyValidationException actualTeamDependencyValidationException =
                await Assert.ThrowsAsync<TeamDependencyValidationException>(
                    retrieveMerchantListTask.AsTask);

            // then
            actualTeamDependencyValidationException.Should().BeEquivalentTo(
                expectedTeamDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetMerchantListAsync(),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnMerchantListRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            

                

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
                 broker.GetMerchantListAsync())
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<MerchantList> retrieveMerchantListTask =
               this.teamService.GetMerchantListRequestAsync();

            TeamDependencyException actualTeamDependencyException =
                await Assert.ThrowsAsync<TeamDependencyException>(
                    retrieveMerchantListTask.AsTask);

            // then
            actualTeamDependencyException.Should().BeEquivalentTo(
                expectedTeamDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetMerchantListAsync(),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnMerchantListRequestIfServiceErrorOccurredAsync()
        {
            // given
            

                
            var serviceException = new Exception();

            var failedTeamServiceException =
                new FailedTeamServiceException(serviceException);

            var expectedTeamServiceException =
                new TeamServiceException(failedTeamServiceException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.GetMerchantListAsync())
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<MerchantList> retrieveMerchantListTask =
               this.teamService.GetMerchantListRequestAsync();

            TeamServiceException actualTeamServiceException =
                await Assert.ThrowsAsync<TeamServiceException>(
                    retrieveMerchantListTask.AsTask);

            // then
            actualTeamServiceException.Should().BeEquivalentTo(
                expectedTeamServiceException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetMerchantListAsync(),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
