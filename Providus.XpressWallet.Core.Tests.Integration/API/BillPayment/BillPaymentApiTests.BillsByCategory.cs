using Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.Categories;

namespace Providus.XpressWallet.Core.Tests.Integration.API.BillPayment
{
    public partial class BillPaymentApiTests
    {
        [Fact]
        public async Task ShouldRetrieveBillsByCategoryAsync()
        {
            // given
            string categoryId = "1";

            // when
            BillsByCategory retrievedBillPaymentModel =
              await this.xPressWalletClient.BillPayment.RetrieveBillsByCategoryAsync(categoryId);

            // then
            Assert.NotNull(retrievedBillPaymentModel);
        }
    }
}
