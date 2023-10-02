using FluentAssertions;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalMerchant;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Merchant;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.Merchant
{
    public partial class MerchantServiceTests
    {
        [Fact]
        public async Task ShouldPostMerchantAccessKeysWithMerchantAccessKeysRequestAsync()
        {
            // given 


            dynamic createRandomMerchantAccessKeysResponseProperties =
                CreateRandomMerchantAccessKeysResponseProperties();



            var randomExternalMerchantAccessKeysResponse = new ExternalMerchantAccessKeysResponse
            {

                Data = new ExternalMerchantAccessKeysResponse.ExternalData
                {
                    PrivateKey = createRandomMerchantAccessKeysResponseProperties.Data.PrivateKey,
                    PublicKey = createRandomMerchantAccessKeysResponseProperties.Data.PublicKey,
                },
                Status = createRandomMerchantAccessKeysResponseProperties.Status
                   
            };


   
            var randomMerchantAccessKeysResponse = new MerchantAccessKeysResponse
            {
                Data = new MerchantAccessKeysResponse.DataResponse
                {
                    PrivateKey = createRandomMerchantAccessKeysResponseProperties.Data.PrivateKey,
                    PublicKey = createRandomMerchantAccessKeysResponseProperties.Data.PublicKey,
                },
                Status = createRandomMerchantAccessKeysResponseProperties.Status

            };



            var expectedResponse = new MerchantAccessKeys
            {
                Response = randomMerchantAccessKeysResponse
            };

           

            ExternalMerchantAccessKeysResponse returnedExternalMerchantAccessKeysResponse =
                randomExternalMerchantAccessKeysResponse;

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.GetMerchantAccessKeysAsync())
                     .ReturnsAsync(returnedExternalMerchantAccessKeysResponse);

            // when
            MerchantAccessKeys actualCreateMerchantAccessKeys =
               await this.merchantService.GetMerchantAccessKeysRequestAsync();

            // then
            actualCreateMerchantAccessKeys.Should().BeEquivalentTo(expectedResponse);

            this.xPressWalletBrokerMock.Verify(broker =>
               broker.GetMerchantAccessKeysAsync(),
                   Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
        }
    }
}
