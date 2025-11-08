using Providus.XpressWallet.Core.Models.Clients.Wallet.Exceptions;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Wallet;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Wallet.Exceptions;
using Providus.XpressWallet.Core.Services.Foundations.XpressWallet.Wallet;
using Xeptions;

namespace Providus.XpressWallet.Core.Clients.Wallet
{
    internal class WalletClient : IWalletClient
    {
        private readonly IWalletService walletService;
        public WalletClient(IWalletService walletsService) =>
            walletService = walletsService;

        public async ValueTask<AllWallets> RetrieveAllWalletsAsync()
        {
            try
            {
                return await walletService.GetAllWalletsRequestAsync();
            }
            catch (WalletValidationException WalletValidationException)
            {

                throw new WalletClientValidationException(
                    WalletValidationException.InnerException as Xeption);
            }
            catch (WalletDependencyValidationException WalletDependencyValidationException)
            {


                throw new WalletClientValidationException(
                    WalletDependencyValidationException.InnerException as Xeption);
            }
            catch (WalletDependencyException WalletDependencyException)
            {
                throw new WalletClientDependencyException(
                    WalletDependencyException.InnerException as Xeption);
            }
            catch (WalletServiceException WalletServiceException)
            {
                throw new WalletClientServiceException(
                    WalletServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<CustomerWallet> RetrieveCustomerWalletAsync(string customerId)
        {
            try
            {
                return await walletService.GetCustomerWalletRequestAsync(customerId);
            }
            catch (WalletValidationException WalletValidationException)
            {

                throw new WalletClientValidationException(
                    WalletValidationException.InnerException as Xeption);
            }
            catch (WalletDependencyValidationException WalletDependencyValidationException)
            {


                throw new WalletClientValidationException(
                    WalletDependencyValidationException.InnerException as Xeption);
            }
            catch (WalletDependencyException WalletDependencyException)
            {
                throw new WalletClientDependencyException(
                    WalletDependencyException.InnerException as Xeption);
            }
            catch (WalletServiceException WalletServiceException)
            {
                throw new WalletClientServiceException(
                    WalletServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<BatchCreditCustomerWallets> BatchCreditCustomerWalletsAsync(BatchCreditCustomerWallets batchCreditCustomerWallets)
        {
            try
            {
                return await walletService.PostBatchCreditCustomerWalletsRequestAsync(batchCreditCustomerWallets);
            }
            catch (WalletValidationException WalletValidationException)
            {

                throw new WalletClientValidationException(
                    WalletValidationException.InnerException as Xeption);
            }
            catch (WalletDependencyValidationException WalletDependencyValidationException)
            {


                throw new WalletClientValidationException(
                    WalletDependencyValidationException.InnerException as Xeption);
            }
            catch (WalletDependencyException WalletDependencyException)
            {
                throw new WalletClientDependencyException(
                    WalletDependencyException.InnerException as Xeption);
            }
            catch (WalletServiceException WalletServiceException)
            {
                throw new WalletClientServiceException(
                    WalletServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<BatchDebitCustomerWallets> BatchDebitCustomerWalletsAsync(BatchDebitCustomerWallets batchDebitCustomerWallets)
        {
            try
            {
                return await walletService.PostBatchDebitCustomerWalletsRequestAsync(batchDebitCustomerWallets);
            }
            catch (WalletValidationException WalletValidationException)
            {

                throw new WalletClientValidationException(
                    WalletValidationException.InnerException as Xeption);
            }
            catch (WalletDependencyValidationException WalletDependencyValidationException)
            {


                throw new WalletClientValidationException(
                    WalletDependencyValidationException.InnerException as Xeption);
            }
            catch (WalletDependencyException WalletDependencyException)
            {
                throw new WalletClientDependencyException(
                    WalletDependencyException.InnerException as Xeption);
            }
            catch (WalletServiceException WalletServiceException)
            {
                throw new WalletClientServiceException(
                    WalletServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<CreateWallet> CreateWalletAsync(CreateWallet createWallet)
        {
            try
            {
                return await walletService.PostCreateWalletRequestAsync(createWallet);
            }
            catch (WalletValidationException WalletValidationException)
            {

                throw new WalletClientValidationException(
                    WalletValidationException.InnerException as Xeption);
            }
            catch (WalletDependencyValidationException WalletDependencyValidationException)
            {


                throw new WalletClientValidationException(
                    WalletDependencyValidationException.InnerException as Xeption);
            }
            catch (WalletDependencyException WalletDependencyException)
            {
                throw new WalletClientDependencyException(
                    WalletDependencyException.InnerException as Xeption);
            }
            catch (WalletServiceException WalletServiceException)
            {
                throw new WalletClientServiceException(
                    WalletServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<CreditWallet> CreditWalletAsync(CreditWallet creditWallet)
        {
            try
            {
                return await walletService.PostCreditWalletRequestAsync(creditWallet);
            }
            catch (WalletValidationException WalletValidationException)
            {

                throw new WalletClientValidationException(
                    WalletValidationException.InnerException as Xeption);
            }
            catch (WalletDependencyValidationException WalletDependencyValidationException)
            {


                throw new WalletClientValidationException(
                    WalletDependencyValidationException.InnerException as Xeption);
            }
            catch (WalletDependencyException WalletDependencyException)
            {
                throw new WalletClientDependencyException(
                    WalletDependencyException.InnerException as Xeption);
            }
            catch (WalletServiceException WalletServiceException)
            {
                throw new WalletClientServiceException(
                    WalletServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<CustomerCreditCustomerWallet> CustomerCreditCustomerWalletAsync(CustomerCreditCustomerWallet customerCreditCustomerWallet)
        {
            try
            {
                return await walletService.PostCustomerCreditCustomerWalletRequestAsync(customerCreditCustomerWallet);
            }
            catch (WalletValidationException WalletValidationException)
            {

                throw new WalletClientValidationException(
                    WalletValidationException.InnerException as Xeption);
            }
            catch (WalletDependencyValidationException WalletDependencyValidationException)
            {


                throw new WalletClientValidationException(
                    WalletDependencyValidationException.InnerException as Xeption);
            }
            catch (WalletDependencyException WalletDependencyException)
            {
                throw new WalletClientDependencyException(
                    WalletDependencyException.InnerException as Xeption);
            }
            catch (WalletServiceException WalletServiceException)
            {
                throw new WalletClientServiceException(
                    WalletServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<DebitWallet> DebitWalletAsync(DebitWallet debitWallet)
        {
            try
            {
                return await walletService.PostDebitWalletRequestAsync(debitWallet);
            }
            catch (WalletValidationException WalletValidationException)
            {

                throw new WalletClientValidationException(
                    WalletValidationException.InnerException as Xeption);
            }
            catch (WalletDependencyValidationException WalletDependencyValidationException)
            {


                throw new WalletClientValidationException(
                    WalletDependencyValidationException.InnerException as Xeption);
            }
            catch (WalletDependencyException WalletDependencyException)
            {
                throw new WalletClientDependencyException(
                    WalletDependencyException.InnerException as Xeption);
            }
            catch (WalletServiceException WalletServiceException)
            {
                throw new WalletClientServiceException(
                    WalletServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<FreezeWallet> FreezeWalletAsync(FreezeWallet freezeWallet)
        {
            try
            {
                return await walletService.PostFreezeWalletRequestAsync(freezeWallet);
            }
            catch (WalletValidationException WalletValidationException)
            {

                throw new WalletClientValidationException(
                    WalletValidationException.InnerException as Xeption);
            }
            catch (WalletDependencyValidationException WalletDependencyValidationException)
            {


                throw new WalletClientValidationException(
                    WalletDependencyValidationException.InnerException as Xeption);
            }
            catch (WalletDependencyException WalletDependencyException)
            {
                throw new WalletClientDependencyException(
                    WalletDependencyException.InnerException as Xeption);
            }
            catch (WalletServiceException WalletServiceException)
            {
                throw new WalletClientServiceException(
                    WalletServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<FundMerchantSandBoxWallet> FundMerchantSandBoxWalletAsync(FundMerchantSandBoxWallet fundMerchantSandBoxWallet)
        {
            try
            {
                return await walletService.PostFundMerchantSandBoxWalletRequestAsync(fundMerchantSandBoxWallet);
            }
            catch (WalletValidationException WalletValidationException)
            {

                throw new WalletClientValidationException(
                    WalletValidationException.InnerException as Xeption);
            }
            catch (WalletDependencyValidationException WalletDependencyValidationException)
            {


                throw new WalletClientValidationException(
                    WalletDependencyValidationException.InnerException as Xeption);
            }
            catch (WalletDependencyException WalletDependencyException)
            {
                throw new WalletClientDependencyException(
                    WalletDependencyException.InnerException as Xeption);
            }
            catch (WalletServiceException WalletServiceException)
            {
                throw new WalletClientServiceException(
                    WalletServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<UnfreezeWallet> UnfreezeWalletAsync(UnfreezeWallet unfreezeWallet)
        {
            try
            {
                return await walletService.PostUnfreezeWalletRequestAsync(unfreezeWallet);
            }
            catch (WalletValidationException WalletValidationException)
            {

                throw new WalletClientValidationException(
                    WalletValidationException.InnerException as Xeption);
            }
            catch (WalletDependencyValidationException WalletDependencyValidationException)
            {


                throw new WalletClientValidationException(
                    WalletDependencyValidationException.InnerException as Xeption);
            }
            catch (WalletDependencyException WalletDependencyException)
            {
                throw new WalletClientDependencyException(
                    WalletDependencyException.InnerException as Xeption);
            }
            catch (WalletServiceException WalletServiceException)
            {
                throw new WalletClientServiceException(
                    WalletServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<UpgradeCustomerWallet> UpgradeCustomerWalletAsync(
            UpgradeCustomerWallet upgradeCustomerWallet)
        {
            try
            {
                return await walletService.PostUpgradeCustomerWalletRequestAsync(upgradeCustomerWallet);
            }
            catch (WalletValidationException WalletValidationException)
            {

                throw new WalletClientValidationException(
                    WalletValidationException.InnerException as Xeption);
            }
            catch (WalletDependencyValidationException WalletDependencyValidationException)
            {

                throw new WalletClientValidationException(
                    WalletDependencyValidationException.InnerException as Xeption);
            }
            catch (WalletDependencyException WalletDependencyException)
            {
                throw new WalletClientDependencyException(
                    WalletDependencyException.InnerException as Xeption);
            }
            catch (WalletServiceException WalletServiceException)
            {
                throw new WalletClientServiceException(
                    WalletServiceException.InnerException as Xeption);
            }
        }
    }
}
