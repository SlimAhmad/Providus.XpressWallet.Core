using Providus.XpressWallet.Core.Clients;
using Providus.XpressWallet.Core.Clients.Auth;
using Providus.XpressWallet.Core.Clients.Customers;
using Providus.XpressWallet.Core.Models.Configurations;

namespace Providus.XpressWallet.Core.Tests.Integration.API.Customers
{
    public partial class CustomersApiTests
    {
        private readonly IXpressWalletClient xPressWalletClient;

        public CustomersApiTests()
        {
            var apiConfigurations = new ApiConfigurations
            {
              
                ApiKey = Environment.GetEnvironmentVariable("ApiKey"),
       

            };

            this.xPressWalletClient = new XpressWalletClient(apiConfigurations);
        }
    }
}
