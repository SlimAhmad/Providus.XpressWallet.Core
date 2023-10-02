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
        public async Task ShouldPostMerchantRegistrationWithMerchantRegistrationRequestAsync()
        {
            // given 



            dynamic createRandomMerchantRegistrationRequestProperties =
              CreateRandomMerchantRegistrationRequestProperties();

            dynamic createRandomMerchantRegistrationResponseProperties =
                CreateRandomMerchantRegistrationResponseProperties();


            var randomExternalMerchantRegistrationRequest = new ExternalMerchantRegistrationRequest
            {
                Email = createRandomMerchantRegistrationRequestProperties.Email,
                BusinessType = createRandomMerchantRegistrationRequestProperties.BusinessType,
                BusinessName = createRandomMerchantRegistrationRequestProperties.BusinessName,
                AccountNumber = createRandomMerchantRegistrationRequestProperties.AccountNumber,
                PhoneNumber = createRandomMerchantRegistrationRequestProperties.PhoneNumber,
                LastName = createRandomMerchantRegistrationRequestProperties.LastName,
                FirstName = createRandomMerchantRegistrationRequestProperties.FirstName,
                Password = createRandomMerchantRegistrationRequestProperties.Password,
                SendEmail = createRandomMerchantRegistrationRequestProperties.SendEmail

            };

            var randomExternalMerchantRegistrationResponse = new ExternalMerchantRegistrationResponse
            {
                  RequireVerification = createRandomMerchantRegistrationResponseProperties.RequireVerification, 
                  Message = createRandomMerchantRegistrationResponseProperties.Message,
                  Status = createRandomMerchantRegistrationResponseProperties.Status
                   
            };


            var randomMerchantRegistrationRequest = new MerchantRegistrationRequest
            {
                Email = createRandomMerchantRegistrationRequestProperties.Email,
                BusinessType = createRandomMerchantRegistrationRequestProperties.BusinessType,
                BusinessName = createRandomMerchantRegistrationRequestProperties.BusinessName,
                AccountNumber = createRandomMerchantRegistrationRequestProperties.AccountNumber,
                PhoneNumber = createRandomMerchantRegistrationRequestProperties.PhoneNumber,
                LastName = createRandomMerchantRegistrationRequestProperties.LastName,
                FirstName = createRandomMerchantRegistrationRequestProperties.FirstName,
                Password = createRandomMerchantRegistrationRequestProperties.Password,
                SendEmail = createRandomMerchantRegistrationRequestProperties.SendEmail

            };

            var randomMerchantRegistrationResponse = new MerchantRegistrationResponse
            {
                RequireVerification = createRandomMerchantRegistrationResponseProperties.RequireVerification,
                Message = createRandomMerchantRegistrationResponseProperties.Message,
                Status = createRandomMerchantRegistrationResponseProperties.Status
            };


            var randomMerchantRegistration = new MerchantRegistration
            {
                Request = randomMerchantRegistrationRequest,
            };

           

            MerchantRegistration inputMerchantRegistration = randomMerchantRegistration;
            MerchantRegistration expectedMerchantRegistration = inputMerchantRegistration.DeepClone();
            expectedMerchantRegistration.Response = randomMerchantRegistrationResponse;

            ExternalMerchantRegistrationRequest mappedExternalMerchantRegistrationRequest =
               randomExternalMerchantRegistrationRequest;

            ExternalMerchantRegistrationResponse returnedExternalMerchantRegistrationResponse =
                randomExternalMerchantRegistrationResponse;

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostMerchantRegistrationAsync(It.Is(
                      SameExternalMerchantRegistrationRequestAs(mappedExternalMerchantRegistrationRequest))))
                     .ReturnsAsync(returnedExternalMerchantRegistrationResponse);

            // when
            MerchantRegistration actualCreateMerchantRegistration =
               await this.merchantService.PostMerchantRegistrationRequestAsync(inputMerchantRegistration);

            // then
            actualCreateMerchantRegistration.Should().BeEquivalentTo(expectedMerchantRegistration);

            this.xPressWalletBrokerMock.Verify(broker =>
               broker.PostMerchantRegistrationAsync(It.Is(
                   SameExternalMerchantRegistrationRequestAs(mappedExternalMerchantRegistrationRequest))),
                   Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
        }
    }
}
