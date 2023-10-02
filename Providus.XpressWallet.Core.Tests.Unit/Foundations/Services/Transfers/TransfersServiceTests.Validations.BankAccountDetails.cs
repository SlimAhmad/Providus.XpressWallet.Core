using FluentAssertions;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalTransfers;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transfers;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transfers.Exceptions;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.Transfers
{
    public partial class TransfersServiceTests
    {



        [Theory]
        [InlineData(null, null)]
        [InlineData("","")]
        [InlineData(" ", " ")]
        public async Task ShouldThrowValidationExceptionOnGetBankAccountDetailsIfBankAccountDetailsIsInvalidAsync(
           string invalidSortCode,string invalidAccountNumber)
        {
            // given


            var invalidBankAccountDetailsException = new InvalidTransfersException();

            invalidBankAccountDetailsException.AddData(
                key: nameof(BankAccountDetails),
                values: "Value is required");

;
            var expectedTransfersValidationException =
                new TransfersValidationException(invalidBankAccountDetailsException);

            // when
            ValueTask<BankAccountDetails> BankAccountDetailsTask =
                this.transfersService.GetBankAccountDetailsRequestAsync(invalidSortCode,invalidAccountNumber);

            TransfersValidationException actualTransfersValidationException =
                await Assert.ThrowsAsync<TransfersValidationException>(BankAccountDetailsTask.AsTask);

            // then
            actualTransfersValidationException.Should().BeEquivalentTo(
                expectedTransfersValidationException);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

 
    }
}