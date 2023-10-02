using FluentAssertions;
using Force.DeepCloner;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalTeam;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Team;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.Team
{
    public partial class TeamServiceTests
    {
        [Fact]
        public async Task ShouldPostSwitchMerchantWithSwitchMerchantRequestAsync()
        {
            // given 



            dynamic createRandomSwitchMerchantRequestProperties =
              CreateRandomSwitchMerchantRequestProperties();

            dynamic createRandomSwitchMerchantResponseProperties =
                CreateRandomSwitchMerchantResponseProperties();


            var randomExternalSwitchMerchantRequest = new ExternalSwitchMerchantRequest
            {

                MerchantId = createRandomSwitchMerchantRequestProperties.MerchantId,


            };

            var randomExternalSwitchMerchantResponse = new ExternalSwitchMerchantResponse
            {
                
                Message = createRandomSwitchMerchantResponseProperties.Message,
                Status = createRandomSwitchMerchantResponseProperties.Status
                   
            };


            var randomSwitchMerchantRequest = new SwitchMerchantRequest
            {
                
               MerchantId = createRandomSwitchMerchantRequestProperties.MerchantId,
               

            };

            var randomSwitchMerchantResponse = new SwitchMerchantResponse
            {
              
                Message = createRandomSwitchMerchantResponseProperties.Message,
                Status = createRandomSwitchMerchantResponseProperties.Status
            };


            var randomSwitchMerchant = new SwitchMerchant
            {
                Request = randomSwitchMerchantRequest,
            };

           

            SwitchMerchant inputSwitchMerchant = randomSwitchMerchant;
            SwitchMerchant expectedSwitchMerchant = inputSwitchMerchant.DeepClone();
            expectedSwitchMerchant.Response = randomSwitchMerchantResponse;

            ExternalSwitchMerchantRequest mappedExternalSwitchMerchantRequest =
               randomExternalSwitchMerchantRequest;

            ExternalSwitchMerchantResponse returnedExternalSwitchMerchantResponse =
                randomExternalSwitchMerchantResponse;

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostSwitchMerchantAsync(It.Is(
                      SameExternalSwitchMerchantRequestAs(mappedExternalSwitchMerchantRequest))))
                     .ReturnsAsync(returnedExternalSwitchMerchantResponse);

            // when
            SwitchMerchant actualCreateSwitchMerchant =
               await this.teamService.PostSwitchMerchantRequestAsync(inputSwitchMerchant);

            // then
            actualCreateSwitchMerchant.Should().BeEquivalentTo(expectedSwitchMerchant);

            this.xPressWalletBrokerMock.Verify(broker =>
               broker.PostSwitchMerchantAsync(It.Is(
                   SameExternalSwitchMerchantRequestAs(mappedExternalSwitchMerchantRequest))),
                   Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
        }
    }
}
