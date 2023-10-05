using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Wallet;

namespace Providus.XpressWallet.Core.Tests.Integration.API.Wallet
{
    public partial class WalletApiTests
    {
        [Fact(Skip = "This test is only for releases")]
        public async Task ShouldCreateWalletAsync()
        {
            // given
            var dateOfBirth = new DateTime(1990, 8, 18);

            var request = new CreateWallet
            {
                
                Request = new CreateWalletRequest
                {
                     Address = "5 tafawa ballewa road area bz, ahmad bello university zaria",
                     Bvn = "22262949022",
                     DateOfBirth = dateOfBirth.ToShortDateString(),
                     Email = "pandahumairi@gmail.com",
                     FirstName = "HUMAIRI",
                     LastName = "ABDULRAZZAK",
                     Metadata = new CreateWalletRequest.MetadataResponse
                     {
                        AdditionalData = "null",
                        EvenMore = "null"
                     },
                     PhoneNumber = "08062118754",
                     
                }
            };

            // when
            CreateWallet retrievedWalletModel =
              await this.xPressWalletClient.Wallet.CreateWalletAsync(request);

            // then
            Assert.NotNull(retrievedWalletModel);
        }
    }
}
