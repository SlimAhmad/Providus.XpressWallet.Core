using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transfers;

namespace Providus.XpressWallet.Core.Tests.Integration.API.Transfers
{
    public partial class TransfersApiTests
    {
        [Fact(Skip = "This test is only for releases")]
        public async Task ShouldRetrieveBankAccountDetailsAsync()
        {
            // given
            string sortCode = "000014";
            string accountNumber = "0812158322";

            // when
            BankAccountDetails retrievedBankAccountModel =
              await this.xPressWalletClient.Transfers.RetrieveBankAccountDetailsAsync(sortCode,accountNumber);

            // then
            Assert.NotNull(retrievedBankAccountModel);
        }
    }
}
