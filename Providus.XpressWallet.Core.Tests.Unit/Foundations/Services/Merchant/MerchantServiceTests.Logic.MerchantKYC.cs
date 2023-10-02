using FluentAssertions;
using Force.DeepCloner;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalMerchant;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Merchant;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.Merchant
{
    public partial class MerchantServiceTests
    {
        [Fact]
        public async Task ShouldPutMerchantKYCWithMerchantKYCRequestAsync()
        {
            // given 



            dynamic createRandomMerchantKYCRequestProperties =
              CreateRandomMerchantKYCRequestProperties();

            dynamic createRandomMerchantKYCResponseProperties =
                CreateRandomMerchantKYCResponseProperties();


            var randomExternalMerchantKYCRequest = new ExternalMerchantKYCRequest
            {
                CacPack = createRandomMerchantKYCRequestProperties.CacPack,
                DirectorsBVN = createRandomMerchantKYCRequestProperties.DirectorsBVN,
                MerchantId = createRandomMerchantKYCRequestProperties.MerchantId

            };

            var randomExternalMerchantKYCResponse = new ExternalMerchantKYCResponse
            {
              
              Message = createRandomMerchantKYCResponseProperties.Message,
              Status = createRandomMerchantKYCResponseProperties.Status
                   
            };


            var randomMerchantKYCRequest = new MerchantKYCRequest
            {
                CacPack = createRandomMerchantKYCRequestProperties.CacPack,
                 DirectorsBVN = createRandomMerchantKYCRequestProperties.DirectorsBVN,
                 MerchantId = createRandomMerchantKYCRequestProperties.MerchantId

            };

            var randomMerchantKYCResponse = new MerchantKYCResponse
            {
                Message = createRandomMerchantKYCResponseProperties.Message,
                Status = createRandomMerchantKYCResponseProperties.Status
            };


            var randomMerchantKYC = new MerchantKYC
            {
                Request = randomMerchantKYCRequest,
            };

           

            MerchantKYC inputMerchantKYC = randomMerchantKYC;
            MerchantKYC expectedMerchantKYC = inputMerchantKYC.DeepClone();
            expectedMerchantKYC.Response = randomMerchantKYCResponse;

            ExternalMerchantKYCRequest mappedExternalMerchantKYCRequest =
               randomExternalMerchantKYCRequest;

            ExternalMerchantKYCResponse returnedExternalMerchantKYCResponse =
                randomExternalMerchantKYCResponse;

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PutMerchantKYCAsync(It.Is(
                      SameExternalMerchantKYCRequestAs(mappedExternalMerchantKYCRequest))))
                     .ReturnsAsync(returnedExternalMerchantKYCResponse);

            // when
            MerchantKYC actualCreateMerchantKYC =
               await this.merchantService.PutMerchantKYCRequestAsync(inputMerchantKYC);

            // then
            actualCreateMerchantKYC.Should().BeEquivalentTo(expectedMerchantKYC);

            this.xPressWalletBrokerMock.Verify(broker =>
               broker.PutMerchantKYCAsync(It.Is(
                   SameExternalMerchantKYCRequestAs(mappedExternalMerchantKYCRequest))),
                   Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
        }
    }
}
