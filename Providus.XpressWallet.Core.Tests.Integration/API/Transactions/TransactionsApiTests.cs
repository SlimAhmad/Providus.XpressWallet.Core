using Providus.XpressWallet.Core.Clients;
using Providus.XpressWallet.Core.Clients.Auth;
using Providus.XpressWallet.Core.Clients.Transactions;
using Providus.XpressWallet.Core.Models.Configurations;

namespace Providus.XpressWallet.Core.Tests.Integration.API.Transactions
{
    public partial class TransactionsApiTests
    {
        private readonly IXpressWalletClient xPressWalletClient;

        public TransactionsApiTests()
        {
            var apiConfigurations = new ApiConfigurations
            {
              
                ApiKey = Environment.GetEnvironmentVariable("ApiKey"),
            

            };

            this.xPressWalletClient = new XpressWalletClient(apiConfigurations);
        }
    }
}
