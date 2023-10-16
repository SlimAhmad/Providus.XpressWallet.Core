using Providus.XpressWallet.Core.Clients;
using Providus.XpressWallet.Core.Clients.Auth;
using Providus.XpressWallet.Core.Models.Configurations;

namespace Providus.XpressWallet.Core.Tests.Integration.API.BillPayment
{
    public partial class BillPaymentApiTests
    {
        private readonly IXpressWalletClient xPressWalletClient;

        public BillPaymentApiTests()
        {
            var apiConfigurations = new ApiConfigurations
            {
              
                //UserName = Environment.GetEnvironmentVariable("UserName"),
                //Password = Environment.GetEnvironmentVariable("Password")
                Password = "test",
                UserName = "test",
                ApiUrl = "http://154.113.16.142:9999/"


            };

            this.xPressWalletClient = new XpressWalletClient(apiConfigurations);
        }
    }
}
