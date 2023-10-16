using Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.Categories;
using Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.PaymentInquiry;

namespace Providus.XpressWallet.Core.Tests.Integration.API.BillPayment
{
    public partial class BillPaymentApiTests
    {
        [Fact]
        public async Task ShouldRetrievePaymentInquiryAsync()
        {
            // given
            string transactionReference = Guid.NewGuid().ToString();

            // when
            PaymentInquiry retrievedBillPaymentModel =
              await this.xPressWalletClient.BillPayment.RetrievePaymentInquiryAsync(transactionReference);

            // then
            Assert.NotNull(retrievedBillPaymentModel);
        }
    }
}
