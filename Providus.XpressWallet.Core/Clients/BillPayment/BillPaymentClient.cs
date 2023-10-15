using Providus.XpressWallet.Core.Models.Clients.BillPayment.Exceptions;
using Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.Categories;
using Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.Fields;
using Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.Payment;
using Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.PaymentInquiry;
using Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.Validate;
using Providus.XpressWallet.Core.Services.Foundations.XpressWallet.BillPayment;
using Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.Exceptions;
using Xeptions;
using Providus.XpressWallet.Core.Models.Clients.ProviPay.Exceptions;

namespace Providus.XpressWallet.Core.Clients.BillPayment
{
    internal class BillPaymentClient : IBillPaymentClient
    {
        private readonly IBillPaymentService billPaymentService;

        public BillPaymentClient(IBillPaymentService billPaymentService) =>
        this.billPaymentService = billPaymentService;

        public async ValueTask<Payment> ChargePaymentAsync(Payment externalPayment)
         {
            try
            {
                return await billPaymentService.PostPaymentRequestAsync(externalPayment);
            }
            catch (BillPaymentValidationException BillPaymentValidationException)
            {

                throw new BillPaymentClientValidationException(
                    BillPaymentValidationException.InnerException as Xeption);
            }
            catch (BillPaymentDependencyValidationException BillPaymentDependencyValidationException)
            {


                throw new BillPaymentClientValidationException(
                    BillPaymentDependencyValidationException.InnerException as Xeption);
            }
            catch (BillPaymentDependencyException BillPaymentDependencyException)
            {
                throw new BillPaymentClientDependencyException(
                    BillPaymentDependencyException.InnerException as Xeption);
            }
            catch (BillPaymentServiceException BillPaymentServiceException)
            {
                throw new BillPaymentClientServiceException(
                    BillPaymentServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<BillsByCategory> RetrieveBillsByCategoryAsync(string categoryId)
        {
            try
            {
                return await billPaymentService.GetBillsByCategoryRequestAsync(categoryId);
            }
            catch (BillPaymentValidationException BillPaymentValidationException)
            {

                throw new BillPaymentClientValidationException(
                    BillPaymentValidationException.InnerException as Xeption);
            }
            catch (BillPaymentDependencyValidationException BillPaymentDependencyValidationException)
            {


                throw new BillPaymentClientValidationException(
                    BillPaymentDependencyValidationException.InnerException as Xeption);
            }
            catch (BillPaymentDependencyException BillPaymentDependencyException)
            {
                throw new BillPaymentClientDependencyException(
                    BillPaymentDependencyException.InnerException as Xeption);
            }
            catch (BillPaymentServiceException BillPaymentServiceException)
            {
                throw new BillPaymentClientServiceException(
                    BillPaymentServiceException.InnerException as Xeption);
            }
        }

        public async  ValueTask<Categories> RetrieveCategoriesAsync()
        {
            try
            {
                return await billPaymentService.GetCategoriesRequestAsync();
            }
            catch (BillPaymentValidationException BillPaymentValidationException)
            {

                throw new BillPaymentClientValidationException(
                    BillPaymentValidationException.InnerException as Xeption);
            }
            catch (BillPaymentDependencyValidationException BillPaymentDependencyValidationException)
            {


                throw new BillPaymentClientValidationException(
                    BillPaymentDependencyValidationException.InnerException as Xeption);
            }
            catch (BillPaymentDependencyException BillPaymentDependencyException)
            {
                throw new BillPaymentClientDependencyException(
                    BillPaymentDependencyException.InnerException as Xeption);
            }
            catch (BillPaymentServiceException BillPaymentServiceException)
            {
                throw new BillPaymentClientServiceException(
                    BillPaymentServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<Fields> RetrieveFieldsAsync(string billId)
         {
            try
            {
                return await billPaymentService.GetFieldsRequestAsync(billId);
            }
            catch (BillPaymentValidationException BillPaymentValidationException)
            {

                throw new BillPaymentClientValidationException(
                    BillPaymentValidationException.InnerException as Xeption);
            }
            catch (BillPaymentDependencyValidationException BillPaymentDependencyValidationException)
            {


                throw new BillPaymentClientValidationException(
                    BillPaymentDependencyValidationException.InnerException as Xeption);
            }
            catch (BillPaymentDependencyException BillPaymentDependencyException)
            {
                throw new BillPaymentClientDependencyException(
                    BillPaymentDependencyException.InnerException as Xeption);
            }
            catch (BillPaymentServiceException BillPaymentServiceException)
            {
                throw new BillPaymentClientServiceException(
                    BillPaymentServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<PaymentInquiry> RetrievePaymentInquiryAsync(string transactionReference)
         {
            try
            {
                return await billPaymentService.GetPaymentInquiryRequestAsync(transactionReference);
            }
            catch (BillPaymentValidationException BillPaymentValidationException)
            {

                throw new BillPaymentClientValidationException(
                    BillPaymentValidationException.InnerException as Xeption);
            }
            catch (BillPaymentDependencyValidationException BillPaymentDependencyValidationException)
            {


                throw new BillPaymentClientValidationException(
                    BillPaymentDependencyValidationException.InnerException as Xeption);
            }
            catch (BillPaymentDependencyException BillPaymentDependencyException)
            {
                throw new BillPaymentClientDependencyException(
                    BillPaymentDependencyException.InnerException as Xeption);
            }
            catch (BillPaymentServiceException BillPaymentServiceException)
            {
                throw new BillPaymentClientServiceException(
                    BillPaymentServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<Validate> ValidateCustomerAsync(Validate externalValidate, string billId)
         {
            try
            {
                return await billPaymentService.PostValidateCustomerRequestAsync(externalValidate,billId);
            }
            catch (BillPaymentValidationException BillPaymentValidationException)
            {

                throw new BillPaymentClientValidationException(
                    BillPaymentValidationException.InnerException as Xeption);
            }
            catch (BillPaymentDependencyValidationException BillPaymentDependencyValidationException)
            {


                throw new BillPaymentClientValidationException(
                    BillPaymentDependencyValidationException.InnerException as Xeption);
            }
            catch (BillPaymentDependencyException BillPaymentDependencyException)
            {
                throw new BillPaymentClientDependencyException(
                    BillPaymentDependencyException.InnerException as Xeption);
            }
            catch (BillPaymentServiceException BillPaymentServiceException)
            {
                throw new BillPaymentClientServiceException(
                    BillPaymentServiceException.InnerException as Xeption);
            }
        }
    }
}
