using Providus.XpressWallet.Core.Clients;
using Providus.XpressWallet.Core.Clients.Auth;
using Providus.XpressWallet.Core.Clients.Transfers;
using Providus.XpressWallet.Core.Models.Configurations;

namespace Providus.XpressWallet.Core.Tests.Integration.API.Transfers
{
    public partial class TransfersApiTests
    {
        private readonly IXpressWalletClient xPressWalletClient;

        public TransfersApiTests()
        {
            var apiConfigurations = new ApiConfigurations
            {
              
                ApiKey = "sk_live_cLZvpa0BCGkEq8EsoV7xNCquC4taJFIY63DQgzGuAEVnUwez",
 

            };

            this.xPressWalletClient = new XpressWalletClient(apiConfigurations);
        }
    }
}
