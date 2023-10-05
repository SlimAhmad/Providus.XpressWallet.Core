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
                     Address = "<Address>",
                     Bvn = "<bvn>",
                     DateOfBirth = "dateofbirth",
                     Email = "<Email>",
                     FirstName = "<FirstName>",
                     LastName = "LastName",
                     Metadata = new CreateWalletRequest.MetadataResponse
                     {
                        AdditionalData = "null",
                        EvenMore = "null"
                     },
                     PhoneNumber = "<PhoneNumber>",
                     
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
