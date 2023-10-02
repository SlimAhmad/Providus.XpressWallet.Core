using FluentAssertions;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalUser;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.User;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.User.Exceptions;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.User
{
    public partial class UserServiceTests
    {

        [Fact]
        public async Task ShouldThrowValidationExceptionOnChangePasswordIfChangePasswordIsNullAsync()
        {
            // given
            ChangePassword nullChangePassword = null;
            var nullChangePasswordException = new NullUserException();

        

            var exceptedUserValidationException =
                new UserValidationException(nullChangePasswordException);

            // when
            ValueTask<ChangePassword> ChangePasswordTask =
                this.userService.PostChangePasswordRequestAsync(nullChangePassword);

            UserValidationException actualUserValidationException =
                await Assert.ThrowsAsync<UserValidationException>(
                    ChangePasswordTask.AsTask);

            // then
            actualUserValidationException.Should()
                .BeEquivalentTo(exceptedUserValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostChangePasswordAsync(
                    It.IsAny<ExternalChangePasswordRequest>()),
                        Times.Never);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnChangePasswordIfRequestIsNullAsync()
        {
            // given
            var invalidChangePassword = new ChangePassword();
            invalidChangePassword.Request = null;
        

            var invalidChangePasswordException =
                new InvalidUserException();

            invalidChangePasswordException.AddData(
                key: nameof(ChangePasswordRequest),
                values: "Value is required");

            var expectedUserValidationException =
                new UserValidationException(
                    invalidChangePasswordException);

            // when
            ValueTask<ChangePassword> ChangePasswordTask =
                this.userService.PostChangePasswordRequestAsync(invalidChangePassword);

            UserValidationException actualUserValidationException =
                await Assert.ThrowsAsync<UserValidationException>(
                    ChangePasswordTask.AsTask);

            // then
            actualUserValidationException.Should()
                .BeEquivalentTo(expectedUserValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostChangePasswordAsync(
                    It.IsAny<ExternalChangePasswordRequest>()),
                        Times.Never);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public async Task ShouldThrowValidationExceptionOnPostChangePasswordIfChangePasswordIsInvalidAsync(
             string invalidPassword)
        {
            // given
            var approveTransaction = new ChangePassword
            {
                Request = new ChangePasswordRequest
                {
                  Password = invalidPassword,
                }
            };

            var invalidChangePasswordException = new InvalidUserException();



            invalidChangePasswordException.AddData(
                    key: nameof(ChangePasswordRequest.Password),
                    values: "Value is required");




            var expectedUserValidationException =
                new UserValidationException(invalidChangePasswordException);

            // when
            ValueTask<ChangePassword> ChangePasswordTask =
                this.userService.PostChangePasswordRequestAsync(approveTransaction);

            UserValidationException actualUserValidationException =
                await Assert.ThrowsAsync<UserValidationException>(ChangePasswordTask.AsTask);

            // then
            actualUserValidationException.Should().BeEquivalentTo(
                expectedUserValidationException);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostChangePasswordIfPostChangePasswordIsEmptyAsync()
        {
            // given
            var approveTransaction = new ChangePassword
            {
                Request = new ChangePasswordRequest
                {

                    Password = string.Empty,
                   


                }
            };
            

            var invalidChangePasswordException = new InvalidUserException();


            invalidChangePasswordException.AddData(
                       key: nameof(ChangePasswordRequest.Password),
                       values: "Value is required");

       

            var expectedUserValidationException =
                new UserValidationException(invalidChangePasswordException);

            // when
            ValueTask<ChangePassword> ChangePasswordTask =
                this.userService.PostChangePasswordRequestAsync(approveTransaction);

            UserValidationException actualUserValidationException =
                await Assert.ThrowsAsync<UserValidationException>(
                    ChangePasswordTask.AsTask);

            // then
            actualUserValidationException.Should().BeEquivalentTo(
                expectedUserValidationException);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

    }
}