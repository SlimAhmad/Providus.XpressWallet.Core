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
        public async Task ShouldThrowValidationExceptionOnForgetPasswordIfForgetPasswordIsNullAsync()
        {
            // given
            ForgetPassword nullForgetPassword = null;
            var nullForgetPasswordException = new NullAuthException();

            var exceptedAuthValidationException =
                new AuthValidationException(nullForgetPasswordException);

            // when
            ValueTask<ForgetPassword> ForgetPasswordTask =
                this.authService.PostForgetPasswordRequestsAsync(nullForgetPassword);

            AuthValidationException actualAuthValidationException =
                await Assert.ThrowsAsync<AuthValidationException>(
                    ForgetPasswordTask.AsTask);

            // then
            actualAuthValidationException.Should()
                .BeEquivalentTo(exceptedAuthValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostForgetPasswordAsync(
                    It.IsAny<ExternalForgetPasswordRequest>()),
                        Times.Never);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnForgetPasswordIfRequestIsNullAsync()
        {
            // given
            var invalidLogin = new ForgetPassword();
            invalidLogin.Request = null;

            var invalidLoginException =
                new InvalidAuthException();

            invalidLoginException.AddData(
                key: nameof(ForgetPasswordRequest),
                values: "Value is required");

            var expectedAuthValidationException =
                new AuthValidationException(
                    invalidLoginException);

            // when
            ValueTask<ForgetPassword> ForgetPasswordTask =
                this.authService.PostForgetPasswordRequestsAsync(invalidLogin);

            AuthValidationException actualAuthValidationException =
                await Assert.ThrowsAsync<AuthValidationException>(
                    ForgetPasswordTask.AsTask);

            // then
            actualAuthValidationException.Should()
                .BeEquivalentTo(expectedAuthValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostForgetPasswordAsync(
                    It.IsAny<ExternalForgetPasswordRequest>()),
                        Times.Never);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public async Task ShouldThrowValidationExceptionOnPostForgetPasswordIfForgetPasswordIsInvalidAsync(
           string invalidEmail)
        {
            // given
            var ForgetPassword = new ForgetPassword
            {
                Request = new ForgetPasswordRequest
                {
                    Email = invalidEmail,
              
                }
            };

            var invalidLoginException = new InvalidAuthException();

            invalidLoginException.AddData(
                key: nameof(ForgetPasswordRequest.Email),
                values: "Value is required");


            var expectedAuthValidationException =
                new AuthValidationException(invalidLoginException);

            // when
            ValueTask<ForgetPassword> ForgetPasswordTask =
                this.authService.PostForgetPasswordRequestsAsync(ForgetPassword);

            AuthValidationException actualAuthValidationException =
                await Assert.ThrowsAsync<AuthValidationException>(ForgetPasswordTask.AsTask);

            // then
            actualAuthValidationException.Should().BeEquivalentTo(
                expectedAuthValidationException);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostForgetPasswordIfPostForgetPasswordIsEmptyAsync()
        {
            // given
            var ForgetPassword = new ForgetPassword
            {
                Request = new ForgetPasswordRequest
                {

                    Email = string.Empty,
                  



                }
            };

            var invalidLoginException = new InvalidAuthException();


            invalidLoginException.AddData(
                key: nameof(ForgetPasswordRequest.Email),
                values: "Value is required");


            var expectedAuthValidationException =
                new AuthValidationException(invalidLoginException);

            // when
            ValueTask<ForgetPassword> ForgetPasswordTask =
                this.authService.PostForgetPasswordRequestsAsync(ForgetPassword);

            AuthValidationException actualAuthValidationException =
                await Assert.ThrowsAsync<AuthValidationException>(
                    ForgetPasswordTask.AsTask);

            // then
            actualAuthValidationException.Should().BeEquivalentTo(
                expectedAuthValidationException);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

    }
}