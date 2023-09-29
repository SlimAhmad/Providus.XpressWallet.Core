using FluentAssertions;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalAuth;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Auth;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Auth.Exceptions;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.Auth
{
    public partial class AuthServiceTests
    {

        [Fact]
        public async Task ShouldThrowValidationExceptionOnResetPasswordIfResetPasswordIsNullAsync()
        {
            // given

            ResetPassword nullResetPassword = null;
            var nullResetPasswordException = new NullAuthException();

            var exceptedAuthValidationException =
                new AuthValidationException(nullResetPasswordException);

            // when
            ValueTask<ResetPassword> ResetPasswordTask =
                this.authService.PostResetPasswordRequestsAsync(nullResetPassword);

            AuthValidationException actualAuthValidationException =
                await Assert.ThrowsAsync<AuthValidationException>(
                    ResetPasswordTask.AsTask);

            // then
            actualAuthValidationException.Should()
                .BeEquivalentTo(exceptedAuthValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostResetPasswordAsync(
                    It.IsAny<ExternalResetPasswordRequest>()),
                        Times.Never);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnResetPasswordIfRequestIsNullAsync()
        {
            // given
            var invalidLogin = new ResetPassword();
            invalidLogin.Request = null;

            var invalidLoginException =
                new InvalidAuthException();

            invalidLoginException.AddData(
                key: nameof(ResetPasswordRequest),
                values: "Value is required");

            var expectedAuthValidationException =
                new AuthValidationException(
                    invalidLoginException);

            // when
            ValueTask<ResetPassword> ResetPasswordTask =
                this.authService.PostResetPasswordRequestsAsync(invalidLogin);

            AuthValidationException actualAuthValidationException =
                await Assert.ThrowsAsync<AuthValidationException>(
                    ResetPasswordTask.AsTask);

            // then
            actualAuthValidationException.Should()
                .BeEquivalentTo(expectedAuthValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostResetPasswordAsync(
                    It.IsAny<ExternalResetPasswordRequest>()),
                        Times.Never);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null,null)]
        [InlineData("","")]
        [InlineData("  "," ")]
        public async Task ShouldThrowValidationExceptionOnPostResetPasswordIfResetPasswordIsInvalidAsync(
           string invalidPassword,string invalidResetCode)
        {
            // given
            var ResetPassword = new ResetPassword
            {
                Request = new ResetPasswordRequest
                {
                    Password = invalidPassword,
                    ResetCode = invalidResetCode
              
                }
            };

            var invalidLoginException = new InvalidAuthException();

            invalidLoginException.AddData(
                key: nameof(ResetPasswordRequest.Password),
                values: "Value is required");

            invalidLoginException.AddData(
                 key: nameof(ResetPasswordRequest.ResetCode),
                 values: "Value is required");


            var expectedAuthValidationException =
                new AuthValidationException(invalidLoginException);

            // when
            ValueTask<ResetPassword> ResetPasswordTask =
                this.authService.PostResetPasswordRequestsAsync(ResetPassword);

            AuthValidationException actualAuthValidationException =
                await Assert.ThrowsAsync<AuthValidationException>(ResetPasswordTask.AsTask);

            // then
            actualAuthValidationException.Should().BeEquivalentTo(
                expectedAuthValidationException);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostResetPasswordIfPostResetPasswordIsEmptyAsync()
        {
            // given
            var ResetPassword = new ResetPassword
            {
                Request = new ResetPasswordRequest
                {

                    Password = string.Empty,
                    ResetCode = string.Empty,

                }
            };

            var invalidLoginException = new InvalidAuthException();


            invalidLoginException.AddData(
                key: nameof(ResetPasswordRequest.Password),
                values: "Value is required");

            invalidLoginException.AddData(
                 key: nameof(ResetPasswordRequest.ResetCode),
                 values: "Value is required");


            var expectedAuthValidationException =
                new AuthValidationException(invalidLoginException);

            // when
            ValueTask<ResetPassword> ResetPasswordTask =
                this.authService.PostResetPasswordRequestsAsync(ResetPassword);

            AuthValidationException actualAuthValidationException =
                await Assert.ThrowsAsync<AuthValidationException>(
                    ResetPasswordTask.AsTask);

            // then
            actualAuthValidationException.Should().BeEquivalentTo(
                expectedAuthValidationException);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

    }
}