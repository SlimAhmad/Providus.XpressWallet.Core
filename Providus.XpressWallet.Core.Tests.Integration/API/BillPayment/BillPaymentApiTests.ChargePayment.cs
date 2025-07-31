using Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.Payment;

namespace Providus.XpressWallet.Core.Tests.Integration.API.BillPayment
{
    public partial class BillPaymentApiTests
    {
        [Fact]
        public async Task ShouldPostPaymentAsync()
        {
            // given
            var request = new Payment
            {
                Request = new PaymentRequest
                {
                    BillId = "1086",
                    ChannelRef = Guid.NewGuid().ToString(),
                    CustomerAccountNo = "1701130656",
                    Inputs = new List<PaymentRequest.Input>
                    {
                       new PaymentRequest.Input
                       {
                           Value = "MTNVTU",
                           Key = "serviceType"
                       },
                        new PaymentRequest.Input
                       {
                           Value = "100",
                           Key = "amount"
                       },
                         new PaymentRequest.Input
                       {
                           Value = "07064415311",
                           Key = "phoneNumber"
                       },
                    },

                }
            };


            // when
            Payment retrievedCustomerModel =
              await this.xPressWalletClient.BillPayment.ChargePaymentAsync(request);

            // then
            Assert.NotNull(retrievedCustomerModel);
        }
    }
}
