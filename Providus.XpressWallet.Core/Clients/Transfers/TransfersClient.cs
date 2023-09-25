using Providus.XpressWallet.Core.Models.Clients.Transfers.Exceptions;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transactions;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transfers;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transfers.Exceptions;
using Providus.XpressWallet.Core.Services.Foundations.XpressWallet.Transfers;
using Xeptions;

namespace Providus.XpressWallet.Core.Clients.Transfers
{
    internal class TransfersClient : ITransfersClient
    {
        private readonly ITransfersService transfersService;
        public TransfersClient(ITransfersService transferService) =>
        transfersService = transferService;

        public async ValueTask<CustomerToCustomerWalletTransfer> CustomerToCustomerWalletTransferAsync(CustomerToCustomerWalletTransfer customerToCustomerWalletTransfer)
        {
            try
            {
                return await transfersService.PostCustomerToCustomerWalletTransferRequestAsync(customerToCustomerWalletTransfer);
            }
            catch (TransfersValidationException transfersValidationException)
            {

                throw new TransfersClientValidationException(
                    transfersValidationException.InnerException as Xeption);
            }
            catch (TransfersDependencyValidationException transfersDependencyValidationException)
            {


                throw new TransfersClientValidationException(
                    transfersDependencyValidationException.InnerException as Xeption);
            }
            catch (TransfersDependencyException TransfersDependencyException)
            {
                throw new TransfersClientDependencyException(
                    TransfersDependencyException.InnerException as Xeption);
            }
            catch (TransfersServiceException TransfersServiceException)
            {
                throw new TransfersClientServiceException(
                    TransfersServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<MerchantBankTransfer> MerchantBankTransferAsync(MerchantBankTransfer merchantBankTransfer)
        {
            try
            {
                return await transfersService.PostMerchantBankTransferRequestAsync(merchantBankTransfer);
            }
            catch (TransfersValidationException transfersValidationException)
            {

                throw new TransfersClientValidationException(
                    transfersValidationException.InnerException as Xeption);
            }
            catch (TransfersDependencyValidationException transfersDependencyValidationException)
            {


                throw new TransfersClientValidationException(
                    transfersDependencyValidationException.InnerException as Xeption);
            }
            catch (TransfersDependencyException TransfersDependencyException)
            {
                throw new TransfersClientDependencyException(
                    TransfersDependencyException.InnerException as Xeption);
            }
            catch (TransfersServiceException TransfersServiceException)
            {
                throw new TransfersClientServiceException(
                    TransfersServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<CustomerBankTransfer> CustomerBankTransferAsync(CustomerBankTransfer customerBankTransfer)
        {
            try
            {
                return await transfersService.PostCustomerBankTransferRequestAsync(customerBankTransfer);
            }
            catch (TransfersValidationException transfersValidationException)
            {

                throw new TransfersClientValidationException(
                    transfersValidationException.InnerException as Xeption);
            }
            catch (TransfersDependencyValidationException transfersDependencyValidationException)
            {


                throw new TransfersClientValidationException(
                    transfersDependencyValidationException.InnerException as Xeption);
            }
            catch (TransfersDependencyException TransfersDependencyException)
            {
                throw new TransfersClientDependencyException(
                    TransfersDependencyException.InnerException as Xeption);
            }
            catch (TransfersServiceException TransfersServiceException)
            {
                throw new TransfersClientServiceException(
                    TransfersServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<MerchantBatchBankTransfer> MerchantBatchBankTransferAsync(MerchantBatchBankTransfer merchantBatchBankTransfer)
        {
            try
            {
                return await transfersService.PostMerchantBatchBankTransferRequestAsync(merchantBatchBankTransfer);
            }
            catch (TransfersValidationException transfersValidationException)
            {

                throw new TransfersClientValidationException(
                    transfersValidationException.InnerException as Xeption);
            }
            catch (TransfersDependencyValidationException transfersDependencyValidationException)
            {


                throw new TransfersClientValidationException(
                    transfersDependencyValidationException.InnerException as Xeption);
            }
            catch (TransfersDependencyException TransfersDependencyException)
            {
                throw new TransfersClientDependencyException(
                    TransfersDependencyException.InnerException as Xeption);
            }
            catch (TransfersServiceException TransfersServiceException)
            {
                throw new TransfersClientServiceException(
                    TransfersServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<BankAccountDetails> RetrieveBankAccountDetailsAsync(string sortCode, string accountNumber)
        {
            try
            {
                return await transfersService.GetBankAccountDetailsRequestAsync(sortCode,accountNumber);
            }
            catch (TransfersValidationException transfersValidationException)
            {

                throw new TransfersClientValidationException(
                    transfersValidationException.InnerException as Xeption);
            }
            catch (TransfersDependencyValidationException transfersDependencyValidationException)
            {


                throw new TransfersClientValidationException(
                    transfersDependencyValidationException.InnerException as Xeption);
            }
            catch (TransfersDependencyException TransfersDependencyException)
            {
                throw new TransfersClientDependencyException(
                    TransfersDependencyException.InnerException as Xeption);
            }
            catch (TransfersServiceException TransfersServiceException)
            {
                throw new TransfersClientServiceException(
                    TransfersServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<BankList> RetrieveBankListAsync()
        {
            try
            {
                return await transfersService.GetBankListRequestAsync();
            }
            catch (TransfersValidationException transfersValidationException)
            {

                throw new TransfersClientValidationException(
                    transfersValidationException.InnerException as Xeption);
            }
            catch (TransfersDependencyValidationException transfersDependencyValidationException)
            {


                throw new TransfersClientValidationException(
                    transfersDependencyValidationException.InnerException as Xeption);
            }
            catch (TransfersDependencyException TransfersDependencyException)
            {
                throw new TransfersClientDependencyException(
                    TransfersDependencyException.InnerException as Xeption);
            }
            catch (TransfersServiceException TransfersServiceException)
            {
                throw new TransfersClientServiceException(
                    TransfersServiceException.InnerException as Xeption);
            }
        }
    }
}
