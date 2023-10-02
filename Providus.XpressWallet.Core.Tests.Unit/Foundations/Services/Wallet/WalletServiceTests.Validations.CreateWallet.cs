using FluentAssertions;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalWallet;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Wallet;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Wallet.Exceptions;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.Wallet
{
    public partial class WalletServiceTests
    {

        [Fact]
        public async Task ShouldThrowValidationExceptionOnCreateWalletIfCreateWalletIsNullAsync()
        {
            // given
            CreateWallet nullCreateWallet = null;
            var nullCreateWalletException = new NullWalletException();

        

            var exceptedWalletValidationException =
                new WalletValidationException(nullCreateWalletException);

            // when
            ValueTask<CreateWallet> CreateWalletTask =
                this.walletService.PostCreateWalletRequestAsync(nullCreateWallet);

            WalletValidationException actualWalletValidationException =
                await Assert.ThrowsAsync<WalletValidationException>(
                    CreateWalletTask.AsTask);

            // then
            actualWalletValidationException.Should()
                .BeEquivalentTo(exceptedWalletValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostCreateWalletAsync(
                    It.IsAny<ExternalCreateWalletRequest>()),
                        Times.Never);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnCreateWalletIfRequestIsNullAsync()
        {
            // given
            var invalidCreateWallet = new CreateWallet();
            invalidCreateWallet.Request = null;
        

            var invalidCreateWalletException =
                new InvalidWalletException();

            invalidCreateWalletException.AddData(
                key: nameof(CreateWalletRequest),
                values: "Value is required");

            var expectedWalletValidationException =
                new WalletValidationException(
                    invalidCreateWalletException);

            // when
            ValueTask<CreateWallet> CreateWalletTask =
                this.walletService.PostCreateWalletRequestAsync(invalidCreateWallet);

            WalletValidationException actualWalletValidationException =
                await Assert.ThrowsAsync<WalletValidationException>(
                    CreateWalletTask.AsTask);

            // then
            actualWalletValidationException.Should()
                .BeEquivalentTo(expectedWalletValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostCreateWalletAsync(
                    It.IsAny<ExternalCreateWalletRequest>()),
                        Times.Never);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null,null,null,null,null,null,null)]
        [InlineData("","","","","","","")]
        [InlineData("  "," "," "," "," "," "," ")]
        public async Task ShouldThrowValidationExceptionOnPostCreateWalletIfCreateWalletIsInvalidAsync(
           string invalidPhoneNumber, string invalidAddress, string invalidBvn,string invalidFirstName, string invalidLastName,
           string invalidDateOfBirth,string invalidEmail)
        {
            // given
            var accountVerificationRequest = new CreateWallet
            {
                Request = new CreateWalletRequest
                {

                    PhoneNumber = invalidPhoneNumber,
                    Address = invalidAddress,
                    Bvn = invalidBvn,
                    FirstName = invalidFirstName,
                    LastName = invalidLastName,
                    DateOfBirth = invalidDateOfBirth,
                    Email = invalidEmail,
                    
               

                }
            };

            var invalidCreateWalletException = new InvalidWalletException();

          

            invalidCreateWalletException.AddData(
                    key: nameof(CreateWalletRequest.PhoneNumber),
                    values: "Value is required");


            invalidCreateWalletException.AddData(
                key: nameof(CreateWalletRequest.Address),
                values: "Value is required");

            invalidCreateWalletException.AddData(
                    key: nameof(CreateWalletRequest.Bvn),
                    values: "Value is required");


            invalidCreateWalletException.AddData(
                key: nameof(CreateWalletRequest.FirstName),
                values: "Value is required");

            invalidCreateWalletException.AddData(
                    key: nameof(CreateWalletRequest.LastName),
                    values: "Value is required");


            invalidCreateWalletException.AddData(
                key: nameof(CreateWalletRequest.DateOfBirth),
                values: "Value is required");

            invalidCreateWalletException.AddData(
                    key: nameof(CreateWalletRequest.Email),
                    values: "Value is required");



            invalidCreateWalletException.AddData(
                key: nameof(CreateWalletRequest.Metadata),
                values: "Value is required");



            var expectedWalletValidationException =
                new WalletValidationException(invalidCreateWalletException);

            // when
            ValueTask<CreateWallet> CreateWalletTask =
                this.walletService.PostCreateWalletRequestAsync(accountVerificationRequest);

            WalletValidationException actualWalletValidationException =
                await Assert.ThrowsAsync<WalletValidationException>(CreateWalletTask.AsTask);

            // then
            actualWalletValidationException.Should().BeEquivalentTo(
                expectedWalletValidationException);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostCreateWalletIfPostCreateWalletIsEmptyAsync()
        {
            // given
            var accountVerificationRequest = new CreateWallet
            {
                Request = new CreateWalletRequest
                {

                   PhoneNumber = string.Empty,
                   Address = string.Empty,
                   LastName = string.Empty,
                   FirstName = string.Empty,
                   DateOfBirth = string.Empty,
                   Email = string.Empty,
                   Bvn = string.Empty


                }
            };
            

            var invalidCreateWalletException = new InvalidWalletException();


            invalidCreateWalletException.AddData(
                               key: nameof(CreateWalletRequest.PhoneNumber),
                               values: "Value is required");


            invalidCreateWalletException.AddData(
                key: nameof(CreateWalletRequest.Address),
                values: "Value is required");

            invalidCreateWalletException.AddData(
                    key: nameof(CreateWalletRequest.Bvn),
                    values: "Value is required");


            invalidCreateWalletException.AddData(
                key: nameof(CreateWalletRequest.FirstName),
                values: "Value is required");

            invalidCreateWalletException.AddData(
                    key: nameof(CreateWalletRequest.LastName),
                    values: "Value is required");


            invalidCreateWalletException.AddData(
                key: nameof(CreateWalletRequest.DateOfBirth),
                values: "Value is required");

            invalidCreateWalletException.AddData(
                    key: nameof(CreateWalletRequest.Email),
                    values: "Value is required");



            invalidCreateWalletException.AddData(
                key: nameof(CreateWalletRequest.Metadata),
                values: "Value is required");




            var expectedWalletValidationException =
                new WalletValidationException(invalidCreateWalletException);

            // when
            ValueTask<CreateWallet> CreateWalletTask =
                this.walletService.PostCreateWalletRequestAsync(accountVerificationRequest);

            WalletValidationException actualWalletValidationException =
                await Assert.ThrowsAsync<WalletValidationException>(
                    CreateWalletTask.AsTask);

            // then
            actualWalletValidationException.Should().BeEquivalentTo(
                expectedWalletValidationException);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

    }
}