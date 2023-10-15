using Providus.XpressWallet.Core.Clients.Auth;
using Providus.XpressWallet.Core.Clients.BillPayment;
using Providus.XpressWallet.Core.Clients.Card;
using Providus.XpressWallet.Core.Clients.Customers;
using Providus.XpressWallet.Core.Clients.Merchant;
using Providus.XpressWallet.Core.Clients.RoleAndPermission;
using Providus.XpressWallet.Core.Clients.Team;
using Providus.XpressWallet.Core.Clients.Transactions;
using Providus.XpressWallet.Core.Clients.Transfers;
using Providus.XpressWallet.Core.Clients.User;
using Providus.XpressWallet.Core.Clients.Wallet;

namespace Providus.XpressWallet.Core.Clients
{
    public interface IXpressWalletClient
    {
        IAuthClient Auth { get; }
        ICardClient Card { get; }
        ITransactionsClient Transactions { get; }
        ITransfersClient Transfers { get; }
        IWalletClient Wallet { get; }
        IUserClient User { get; }
        ITeamClient Team { get; }
        IRoleAndPermissionClient RoleAndPermission { get; }
        IMerchantClient Merchant { get; }
        ICustomersClient Customers { get; }
        IBillPaymentClient BillPayment { get; }

    }
}
