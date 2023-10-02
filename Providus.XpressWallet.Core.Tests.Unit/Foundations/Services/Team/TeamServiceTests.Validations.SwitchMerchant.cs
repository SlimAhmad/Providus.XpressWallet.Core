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
        public async Task ShouldThrowValidationExceptionOnSwitchMerchantIfSwitchMerchantIsNullAsync()
        {
            // given
            SwitchMerchant nullSwitchMerchant = null;
            var nullSwitchMerchantException = new NullTeamException();

        

            var exceptedTeamValidationException =
                new TeamValidationException(nullSwitchMerchantException);

            // when
            ValueTask<SwitchMerchant> SwitchMerchantTask =
                this.teamService.PostSwitchMerchantRequestAsync(nullSwitchMerchant);

            TeamValidationException actualTeamValidationException =
                await Assert.ThrowsAsync<TeamValidationException>(
                    SwitchMerchantTask.AsTask);

            // then
            actualTeamValidationException.Should()
                .BeEquivalentTo(exceptedTeamValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostSwitchMerchantAsync(
                    It.IsAny<ExternalSwitchMerchantRequest>()),
                        Times.Never);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnSwitchMerchantIfRequestIsNullAsync()
        {
            // given
            var invalidSwitchMerchant = new SwitchMerchant();
            invalidSwitchMerchant.Request = null;
        

            var invalidSwitchMerchantException =
                new InvalidTeamException();

            invalidSwitchMerchantException.AddData(
                key: nameof(SwitchMerchantRequest),
                values: "Value is required");

            var expectedTeamValidationException =
                new TeamValidationException(
                    invalidSwitchMerchantException);

            // when
            ValueTask<SwitchMerchant> SwitchMerchantTask =
                this.teamService.PostSwitchMerchantRequestAsync(invalidSwitchMerchant);

            TeamValidationException actualTeamValidationException =
                await Assert.ThrowsAsync<TeamValidationException>(
                    SwitchMerchantTask.AsTask);

            // then
            actualTeamValidationException.Should()
                .BeEquivalentTo(expectedTeamValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostSwitchMerchantAsync(
                    It.IsAny<ExternalSwitchMerchantRequest>()),
                        Times.Never);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }



        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostSwitchMerchantIfPostSwitchMerchantIsEmptyAsync()
        {
            // given
            var accountVerificationRequest = new SwitchMerchant
            {
                Request = new SwitchMerchantRequest
                {

                    MerchantId = string.Empty,
                   


                }
            };
            

            var invalidSwitchMerchantException = new InvalidTeamException();


            invalidSwitchMerchantException.AddData(
                       key: nameof(SwitchMerchantRequest.MerchantId),
                       values: "Value is required");

       

            var expectedTeamValidationException =
                new TeamValidationException(invalidSwitchMerchantException);

            // when
            ValueTask<SwitchMerchant> SwitchMerchantTask =
                this.teamService.PostSwitchMerchantRequestAsync(accountVerificationRequest);

            TeamValidationException actualTeamValidationException =
                await Assert.ThrowsAsync<TeamValidationException>(
                    SwitchMerchantTask.AsTask);

            // then
            actualTeamValidationException.Should().BeEquivalentTo(
                expectedTeamValidationException);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

    }
}