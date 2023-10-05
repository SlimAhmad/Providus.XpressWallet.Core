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
                    BatchReference = Guid.NewGuid().ToString(),
                    CustomerId = Guid.NewGuid().ToString(),
                    Recipients = new List<CustomerCreditCustomerWalletRequest.Recipient> 
                    { 
                        new CustomerCreditCustomerWalletRequest.Recipient
                        {
                           Amount = 50,
                           CustomerId = Guid.NewGuid().ToString(),
                           Reference = Guid.NewGuid().ToString()
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
