using Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.Fields;

namespace Providus.XpressWallet.Core.Tests.Integration.API.BillPayment
{
    public partial class BillPaymentApiTests
    {
        [Fact]
        public async Task ShouldRetrieveFieldsAsync()
        {
            // given
            string billId = "1086";

            // when
            Fields retrievedBillPaymentModel =
              await this.xPressWalletClient.BillPayment.RetrieveFieldsAsync(billId);

            // then
            Assert.NotNull(retrievedBillPaymentModel);
        }
    }
}
