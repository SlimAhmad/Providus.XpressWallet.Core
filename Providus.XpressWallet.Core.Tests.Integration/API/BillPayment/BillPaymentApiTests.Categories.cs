using Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.Categories;

namespace Providus.XpressWallet.Core.Tests.Integration.API.BillPayment
{
    public partial class BillPaymentApiTests
    {
        [Fact]
        public async Task ShouldRetrieveCategoriesAsync()
        {
            // given

            // when
            Categories retrievedBillPaymentModel =
              await this.xPressWalletClient.BillPayment.RetrieveCategoriesAsync();

            // then
            Assert.NotNull(retrievedBillPaymentModel);
        }
    }
}
