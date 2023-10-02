using FluentAssertions;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalMerchant;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Merchant;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.Merchant
{
    public partial class MerchantServiceTests
    {
        [Fact]
        public async Task ShouldGenerateAccessKeysWithGenerateAccessKeysRequestAsync()
        {
            // given 


            dynamic createRandomGenerateAccessKeysResponseProperties =
                CreateRandomGenerateAccessKeysResponseProperties();



            var randomExternalGenerateAccessKeysResponse = new ExternalGenerateAccessKeysResponse
            {

                Data = new ExternalGenerateAccessKeysResponse.ExternalData
                {
                    PrivateKey = createRandomGenerateAccessKeysResponseProperties.Data.PrivateKey,
                    PublicKey = createRandomGenerateAccessKeysResponseProperties.Data.PublicKey,
                },
                Status = createRandomGenerateAccessKeysResponseProperties.Status
                   
            };


   
            var randomGenerateAccessKeysResponse = new GenerateAccessKeysResponse
            {
                Data = new GenerateAccessKeysResponse.DataResponse
                {
                    PrivateKey = createRandomGenerateAccessKeysResponseProperties.Data.PrivateKey,
                    PublicKey = createRandomGenerateAccessKeysResponseProperties.Data.PublicKey,
                },
                Status = createRandomGenerateAccessKeysResponseProperties.Status

            };



            var expectedResponse = new GenerateAccessKeys
            {
                Response = randomGenerateAccessKeysResponse
            };

           

            ExternalGenerateAccessKeysResponse returnedExternalGenerateAccessKeysResponse =
                randomExternalGenerateAccessKeysResponse;

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostGenerateAccessKeysAsync())
                     .ReturnsAsync(returnedExternalGenerateAccessKeysResponse);

            // when
            GenerateAccessKeys actualCreateGenerateAccessKeys =
               await this.merchantService.PostGenerateAccessKeysRequestAsync();

            // then
            actualCreateGenerateAccessKeys.Should().BeEquivalentTo(expectedResponse);

            this.xPressWalletBrokerMock.Verify(broker =>
               broker.PostGenerateAccessKeysAsync(),
                   Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
        }
    }
}
