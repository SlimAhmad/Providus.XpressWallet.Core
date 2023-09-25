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

        public async ValueTask<AllWallets> GetAllWalletsAsync()
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

        public async ValueTask<CustomerWallet> GetCustomerWalletAsync(string customerId)
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

        public async ValueTask<BatchCreditCustomerWallets> PostBatchCreditCustomerWalletsAsync(BatchCreditCustomerWallets batchCreditCustomerWallets)
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

        public async ValueTask<BatchDebitCustomerWallets> PostBatchDebitCustomerWalletsAsync(BatchDebitCustomerWallets batchDebitCustomerWallets)
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

        public async ValueTask<CreateWallet> PostCreateWalletAsync(CreateWallet createWallet)
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

        public async ValueTask<CreditWallet> PostCreditWalletAsync(CreditWallet creditWallet)
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

        public async ValueTask<CustomerCreditCustomerWallet> PostCustomerCreditCustomerWalletAsync(CustomerCreditCustomerWallet customerCreditCustomerWallet)
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

        public async ValueTask<DebitWallet> PostDebitWalletAsync(DebitWallet debitWallet)
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

        public async ValueTask<FreezeWallet> PostFreezeWalletAsync(FreezeWallet freezeWallet)
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

        public async ValueTask<FundMerchantSandBoxWallet> PostFundMerchantSandBoxWalletAsync(FundMerchantSandBoxWallet fundMerchantSandBoxWallet)
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

        public async ValueTask<UnfreezeWallet> PostUnfreezeWalletAsync(UnfreezeWallet unfreezeWallet)
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
    }
}
