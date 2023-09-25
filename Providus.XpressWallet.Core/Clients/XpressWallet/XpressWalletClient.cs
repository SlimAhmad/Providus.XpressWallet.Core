using Microsoft.Extensions.DependencyInjection;
using Providus.XpressWallet.Core.Brokers.DateTimes;
using Providus.XpressWallet.Core.Brokers.XpressWallet;
using Providus.XpressWallet.Core.Clients.Card;
using Providus.XpressWallet.Core.Clients.Customers;
using Providus.XpressWallet.Core.Clients.Merchant;
using Providus.XpressWallet.Core.Clients.RoleAndPermission;
using Providus.XpressWallet.Core.Clients.Team;
using Providus.XpressWallet.Core.Clients.Transactions;
using Providus.XpressWallet.Core.Clients.Transfers;
using Providus.XpressWallet.Core.Clients.User;
using Providus.XpressWallet.Core.Clients.Wallet;
using Providus.XpressWallet.Core.Models.Configurations;
using Providus.XpressWallet.Core.Services.Foundations.XpressWallet.Auth;
using Providus.XpressWallet.Core.Services.Foundations.XpressWallet.Card;
using Providus.XpressWallet.Core.Services.Foundations.XpressWallet.Customers;
using Providus.XpressWallet.Core.Services.Foundations.XpressWallet.Merchant;
using Providus.XpressWallet.Core.Services.Foundations.XpressWallet.RoleAndPermission;
using Providus.XpressWallet.Core.Services.Foundations.XpressWallet.Team;
using Providus.XpressWallet.Core.Services.Foundations.XpressWallet.Transactions;
using Providus.XpressWallet.Core.Services.Foundations.XpressWallet.Transfers;
using Providus.XpressWallet.Core.Services.Foundations.XpressWallet.User;
using Providus.XpressWallet.Core.Services.Foundations.XpressWallet.Wallet;

namespace Providus.XpressWallet.Core.Clients.Auth
{
    public class XpressWalletClient : IXpressWalletClient
    {
        public XpressWalletClient(ApiConfigurations apiConfigurations)
        {
            IServiceProvider serviceProvider = RegisterServices(apiConfigurations);
            InitializeClients(serviceProvider);
        }

        public IXpressWalletClient XpressWallet { get; set; }
        public IAuthClient Auth { get; set; }
        public ICardClient Card { get; set;}
        public ITransactionsClient Transactions { get; set;}
        public ITransfersClient Transfers { get; set;}
        public IWalletClient Wallet { get; set;}
        public IUserClient User { get; set;}
        public ITeamClient Team { get; set;}
        public IRoleAndPermissionClient RoleAndPermission { get; set;}
        public IMerchantClient Merchant { get; set;}
        public ICustomersClient Customers { get; set;}



        private void InitializeClients(IServiceProvider serviceProvider)
        {

          
            Auth = serviceProvider.GetRequiredService<IAuthClient>();
            Card = serviceProvider.GetRequiredService<ICardClient>();
            Transactions = serviceProvider.GetRequiredService<ITransactionsClient>();
            Transfers = serviceProvider.GetRequiredService<ITransfersClient>();
            Wallet = serviceProvider.GetRequiredService<IWalletClient>();
            User = serviceProvider.GetRequiredService<IUserClient>();
            Team = serviceProvider.GetRequiredService<ITeamClient>();
            RoleAndPermission = serviceProvider.GetRequiredService<IRoleAndPermissionClient>();
            Merchant = serviceProvider.GetRequiredService<IMerchantClient>();
            Customers = serviceProvider.GetRequiredService<ICustomersClient>();


        }


        private static IServiceProvider RegisterServices(ApiConfigurations apiConfigurations)
        {
            var serviceCollection = new ServiceCollection()
                .AddTransient<IAuthService, AuthService>()
                .AddTransient<ICardService, CardService>()
                .AddTransient<ICustomersService, CustomersService>()
                .AddTransient<IMerchantService, MerchantService>()
                .AddTransient<IRoleAndPermissionService, RoleAndPermissionService>()
                .AddTransient<ITeamService, TeamService>()
                .AddTransient<ITransactionsService, TransactionsService>()
                .AddTransient<ITransfersService, TransfersService>()
                .AddTransient<IUserService, UserService>()
                .AddTransient<IWalletService, WalletService>()
                .AddTransient<IXpressWalletBroker,XpressWalletBroker>()
                .AddTransient<IDateTimeBroker, DateTimeBroker>()
              

                .AddTransient<IXpressWalletClient, XpressWalletClient>()
                .AddTransient<ICustomersClient, CustomersClient>()
                .AddTransient<IAuthClient, AuthClient>()
                .AddTransient<ICardClient, CardClient>()
                .AddTransient<IMerchantClient, MerchantClient>()
                .AddTransient<IRoleAndPermissionClient, RoleAndPermissionClient>()
                .AddTransient<ITeamClient, TeamClient>()
                .AddTransient<ITransactionsClient, TransactionsClient>()
                .AddTransient<ITransfersClient, TransfersClient>()
                .AddTransient<IUserClient, UserClient>()
                .AddTransient<IWalletClient, WalletClient>()
                .AddSingleton(apiConfigurations);

            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceProvider;
        }
    }
}
