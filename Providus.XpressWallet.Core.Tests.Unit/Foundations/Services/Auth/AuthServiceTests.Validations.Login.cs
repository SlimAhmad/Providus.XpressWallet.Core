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
        public async Task ShouldThrowValidationExceptionOnLoginIfLoginIsNullAsync()
        {
            // given
            Login nullLogin = null;
            var nullLoginException = new NullAuthException();

            var exceptedAuthValidationException =
                new AuthValidationException(nullLoginException);

            // when
            ValueTask<Login> LoginTask =
                this.authService.PostLoginRequestsAsync(nullLogin);

            AuthValidationException actualAuthValidationException =
                await Assert.ThrowsAsync<AuthValidationException>(
                    LoginTask.AsTask);

            // then
            actualAuthValidationException.Should()
                .BeEquivalentTo(exceptedAuthValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostLoginAsync(
                    It.IsAny<ExternalLoginRequest>()),
                        Times.Never);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnLoginIfRequestIsNullAsync()
        {
            // given
            var invalidLogin = new Login();
            invalidLogin.Request = null;

            var invalidLoginException =
                new InvalidAuthException();

            invalidLoginException.AddData(
                key: nameof(LoginRequest),
                values: "Value is required");

            var expectedAuthValidationException =
                new AuthValidationException(
                    invalidLoginException);

            // when
            ValueTask<Login> LoginTask =
                this.authService.PostLoginRequestsAsync(invalidLogin);

            AuthValidationException actualAuthValidationException =
                await Assert.ThrowsAsync<AuthValidationException>(
                    LoginTask.AsTask);

            // then
            actualAuthValidationException.Should()
                .BeEquivalentTo(expectedAuthValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostLoginAsync(
                    It.IsAny<ExternalLoginRequest>()),
                        Times.Never);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData("", "")]
        [InlineData("  ", "  ")]
        public async Task ShouldThrowValidationExceptionOnPostLoginIfLoginIsInvalidAsync(
           string invalidEmail, string invalidPassword)
        {
            // given
            var Login = new Login
            {
                Request = new LoginRequest
                {
                    Email = invalidEmail,
                    Password = invalidPassword



                }
            };

            var invalidLoginException = new InvalidAuthException();

            invalidLoginException.AddData(
                key: nameof(LoginRequest.Password),
                values: "Value is required");

            invalidLoginException.AddData(
                key: nameof(LoginRequest.Email),
                values: "Value is required");







            var expectedAuthValidationException =
                new AuthValidationException(invalidLoginException);

            // when
            ValueTask<Login> LoginTask =
                this.authService.PostLoginRequestsAsync(Login);

            AuthValidationException actualAuthValidationException =
                await Assert.ThrowsAsync<AuthValidationException>(LoginTask.AsTask);

            // then
            actualAuthValidationException.Should().BeEquivalentTo(
                expectedAuthValidationException);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostLoginIfPostLoginIsEmptyAsync()
        {
            // given
            var Login = new Login
            {
                Request = new LoginRequest
                {

                    Email = string.Empty,
                    Password = string.Empty,



                }
            };

            var invalidLoginException = new InvalidAuthException();


            invalidLoginException.AddData(
                key: nameof(LoginRequest.Email),
                values: "Value is required");

            invalidLoginException.AddData(
                key: nameof(LoginRequest.Password),
                values: "Value is required");







            var expectedAuthValidationException =
                new AuthValidationException(invalidLoginException);

            // when
            ValueTask<Login> LoginTask =
                this.authService.PostLoginRequestsAsync(Login);

            AuthValidationException actualAuthValidationException =
                await Assert.ThrowsAsync<AuthValidationException>(
                    LoginTask.AsTask);

            // then
            actualAuthValidationException.Should().BeEquivalentTo(
                expectedAuthValidationException);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

    }
}