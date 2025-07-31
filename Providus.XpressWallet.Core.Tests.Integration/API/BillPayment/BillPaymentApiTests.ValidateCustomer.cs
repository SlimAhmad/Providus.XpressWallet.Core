using Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.Validate;

namespace Providus.XpressWallet.Core.Tests.Integration.API.BillPayment
{
    public partial class BillPaymentApiTests
    {
        [Fact]
        public async Task ShouldPostValidateAsync()
        {
            // given
            var request = new Validate
            {
                Request = new ValidateRequest
                {
                    BillId = "1086",
                    ChannelRef = Guid.NewGuid().ToString(),
                    CustomerAccountNo = "1701130656",
                    Inputs = new List<ValidateRequest.Input>
                    { 
                       new ValidateRequest.Input
                       {
                           Value = "MTNVTU",
                           Key = "serviceType"
                       },
                        new ValidateRequest.Input
                       {
                           Value = "100",
                           Key = "amount"
                       },
                         new ValidateRequest.Input
                       {
                           Value = "07064415311",
                           Key = "phoneNumber"
                       },
                    },
                    
                }
            };

            var billId = "1086";
            // when
            Validate retrievedCustomerModel =
              await this.xPressWalletClient.BillPayment.ValidateCustomerAsync(request,billId);

            // then
            Assert.NotNull(retrievedCustomerModel);
        }
    }
}
