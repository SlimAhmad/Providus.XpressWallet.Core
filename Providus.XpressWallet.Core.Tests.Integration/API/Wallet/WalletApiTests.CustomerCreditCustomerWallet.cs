using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Wallet;

namespace Providus.XpressWallet.Core.Tests.Integration.API.Wallet
{
    public partial class WalletApiTests
    {
        [Fact(Skip = "This test is only for releases")]
        public async Task ShouldCustomerCreditCustomerWalletAsync()
        {
            // given
            var request = new CustomerCreditCustomerWallet
            {
                Request = new CustomerCreditCustomerWalletRequest
                {
                    BatchReference = "testcustomer3customer@energywalletng",
                    CustomerId = "e8a17512-0f30-4e82-a648-16540baf746e",
                    Recipients = new List<CustomerCreditCustomerWalletRequest.Recipient> 
                    { 
                        new CustomerCreditCustomerWalletRequest.Recipient
                        {
                           Amount = 50,
                           CustomerId = "183adcd3-4695-496a-8c25-10715cdfc45f",
                           Reference = "testcustomer2customer@energywallet"
                        } 
                    }
                }
            };


            // when
            CustomerCreditCustomerWallet retrievedTransferModel =
              await this.xPressWalletClient.Wallet.CustomerCreditCustomerWalletAsync(request);

            // then
            Assert.NotNull(retrievedTransferModel);
        }
    }
}
