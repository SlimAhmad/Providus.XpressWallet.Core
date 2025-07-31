using Providus.XpressWallet.Core.Clients;
using Providus.XpressWallet.Core.Clients.Auth;
using Providus.XpressWallet.Core.Clients.Wallet;
using Providus.XpressWallet.Core.Models.Configurations;

namespace Providus.XpressWallet.Core.Tests.Integration.API.Wallet
{
    public partial class WalletApiTests
    {
        private readonly IXpressWalletClient xPressWalletClient;

        public WalletApiTests()
        {
            var apiConfigurations = new ApiConfigurations
            {
              
               //ApiKey = Environment.GetEnvironmentVariable("ApiKey"),
               ApiKey = "sk_live_ztSSXpjfy9Pa4GzVOqD1xcoRFDeSIRM02XA5UQsukl9VFnE1"

            };

            this.xPressWalletClient = new XpressWalletClient(apiConfigurations);
        }
    }
}
