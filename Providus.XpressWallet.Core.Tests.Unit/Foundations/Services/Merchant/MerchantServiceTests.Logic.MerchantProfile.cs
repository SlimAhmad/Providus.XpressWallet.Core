using FluentAssertions;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalMerchant;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Merchant;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.Merchant
{
    public partial class MerchantServiceTests
    {
        [Fact]
        public async Task ShouldPostMerchantProfileWithMerchantProfileRequestAsync()
        {
            // given 


            dynamic createRandomMerchantProfileResponseProperties =
                CreateRandomMerchantProfileResponseProperties();



            var randomExternalMerchantProfileResponse = new ExternalMerchantProfileResponse
            {

                Data = new ExternalMerchantProfileResponse.ExternalData
                {
                    AirtimeCharge = createRandomMerchantProfileResponseProperties.Data.AirtimeCharge,
                    ApiKey = createRandomMerchantProfileResponseProperties.Data.ApiKey,
                    AutoCardFunding = createRandomMerchantProfileResponseProperties.Data.AutoCardFunding,
                    BaseCustomerWalletCredit = createRandomMerchantProfileResponseProperties.Data.BaseCustomerWalletCredit,
                    BusinessName = createRandomMerchantProfileResponseProperties.Data.BusinessName,
                    BusinessType = createRandomMerchantProfileResponseProperties.Data.BusinessType,
                    Bvn = createRandomMerchantProfileResponseProperties.Data.Bvn,
                    BvnChargeV1 = createRandomMerchantProfileResponseProperties.Data.BvnChargeV1,
                    BvnVerificationCharge = createRandomMerchantProfileResponseProperties.Data.BvnVerificationCharge,
                    CallbackURL = createRandomMerchantProfileResponseProperties.Data.CallbackURL,
                    CanLogin = createRandomMerchantProfileResponseProperties.Data.CanLogin,
                    ContractCode = createRandomMerchantProfileResponseProperties.Data.ContractCode,
                    CreatedAt = createRandomMerchantProfileResponseProperties.Data.CreatedAt,
                    Email = createRandomMerchantProfileResponseProperties.Data.Email,
                    FundingRate = createRandomMerchantProfileResponseProperties.Data.FundingRate,
                    FundingRateMax = createRandomMerchantProfileResponseProperties.Data.FundingRateMax,
                    Id = createRandomMerchantProfileResponseProperties.Data.Id,
                    MerchantType = createRandomMerchantProfileResponseProperties.Data.MerchantType,
                    Mode = createRandomMerchantProfileResponseProperties.Data.Mode,
                    PhoneNumber = createRandomMerchantProfileResponseProperties.Data.PhoneNumber,
                    Review = createRandomMerchantProfileResponseProperties.Data.Review,
                    SandboxCallbackURL = createRandomMerchantProfileResponseProperties.Data.SandboxCallbackURL,
                    SecretKey = createRandomMerchantProfileResponseProperties.Data.SecretKey,
                    SendEmail = createRandomMerchantProfileResponseProperties.Data.SendEmail,
                    Slug = createRandomMerchantProfileResponseProperties.Data.Slug,
                    Tier1DailyLimit = createRandomMerchantProfileResponseProperties.Data.Tier1DailyLimit,
                    Tier1MinBalance = createRandomMerchantProfileResponseProperties.Data.Tier1MinBalance,
                    Tier2DailyLimit = createRandomMerchantProfileResponseProperties.Data.Tier2DailyLimit,
                    Tier2MinBalance = createRandomMerchantProfileResponseProperties.Data.Tier2MinBalance,
                    Tier3DailyLimit = createRandomMerchantProfileResponseProperties.Data.Tier3DailyLimit,
                    Tier3MinBalance = createRandomMerchantProfileResponseProperties.Data.Tier3MinBalance,
                    TransferCharges =new ExternalMerchantProfileResponse.TransferCharges
                    {
                         Max5000 = createRandomMerchantProfileResponseProperties.Data.TransferCharges.Max5000,
                         Max50000 = createRandomMerchantProfileResponseProperties.Data.TransferCharges.Max50000,
                         Min50000 = createRandomMerchantProfileResponseProperties.Data.TransferCharges.Min50000
                    },
                    UpdatedAt = createRandomMerchantProfileResponseProperties.Data.UpdatedAt,
                    WalletReservationCharge = createRandomMerchantProfileResponseProperties.Data.WalletReservationCharge,
                    WalletToWalletTransfer = createRandomMerchantProfileResponseProperties.Data.WalletToWalletTransfer
                
                },
                Status = createRandomMerchantProfileResponseProperties.Status
                   
            };


   
            var randomMerchantProfileResponse = new MerchantProfileResponse
            {
                Data = new MerchantProfileResponse.DataResponse
                {
                    AirtimeCharge = createRandomMerchantProfileResponseProperties.Data.AirtimeCharge,
                    ApiKey = createRandomMerchantProfileResponseProperties.Data.ApiKey,
                    AutoCardFunding = createRandomMerchantProfileResponseProperties.Data.AutoCardFunding,
                    BaseCustomerWalletCredit = createRandomMerchantProfileResponseProperties.Data.BaseCustomerWalletCredit,
                    BusinessName = createRandomMerchantProfileResponseProperties.Data.BusinessName,
                    BusinessType = createRandomMerchantProfileResponseProperties.Data.BusinessType,
                    Bvn = createRandomMerchantProfileResponseProperties.Data.Bvn,
                    BvnChargeV1 = createRandomMerchantProfileResponseProperties.Data.BvnChargeV1,
                    BvnVerificationCharge = createRandomMerchantProfileResponseProperties.Data.BvnVerificationCharge,
                    CallbackURL = createRandomMerchantProfileResponseProperties.Data.CallbackURL,
                    CanLogin = createRandomMerchantProfileResponseProperties.Data.CanLogin,
                    ContractCode = createRandomMerchantProfileResponseProperties.Data.ContractCode,
                    CreatedAt = createRandomMerchantProfileResponseProperties.Data.CreatedAt,
                    Email = createRandomMerchantProfileResponseProperties.Data.Email,
                    FundingRate = createRandomMerchantProfileResponseProperties.Data.FundingRate,
                    FundingRateMax = createRandomMerchantProfileResponseProperties.Data.FundingRateMax,
                    Id = createRandomMerchantProfileResponseProperties.Data.Id,
                    MerchantType = createRandomMerchantProfileResponseProperties.Data.MerchantType,
                    Mode = createRandomMerchantProfileResponseProperties.Data.Mode,
                    PhoneNumber = createRandomMerchantProfileResponseProperties.Data.PhoneNumber,
                    Review = createRandomMerchantProfileResponseProperties.Data.Review,
                    SandboxCallbackURL = createRandomMerchantProfileResponseProperties.Data.SandboxCallbackURL,
                    SecretKey = createRandomMerchantProfileResponseProperties.Data.SecretKey,
                    SendEmail = createRandomMerchantProfileResponseProperties.Data.SendEmail,
                    Slug = createRandomMerchantProfileResponseProperties.Data.Slug,
                    Tier1DailyLimit = createRandomMerchantProfileResponseProperties.Data.Tier1DailyLimit,
                    Tier1MinBalance = createRandomMerchantProfileResponseProperties.Data.Tier1MinBalance,
                    Tier2DailyLimit = createRandomMerchantProfileResponseProperties.Data.Tier2DailyLimit,
                    Tier2MinBalance = createRandomMerchantProfileResponseProperties.Data.Tier2MinBalance,
                    Tier3DailyLimit = createRandomMerchantProfileResponseProperties.Data.Tier3DailyLimit,
                    Tier3MinBalance = createRandomMerchantProfileResponseProperties.Data.Tier3MinBalance,
                    TransferCharges = new MerchantProfileResponse.TransferCharges
                    {
                        Max5000 = createRandomMerchantProfileResponseProperties.Data.TransferCharges.Max5000,
                        Max50000 = createRandomMerchantProfileResponseProperties.Data.TransferCharges.Max50000,
                        Min50000 = createRandomMerchantProfileResponseProperties.Data.TransferCharges.Min50000
                    },
                    UpdatedAt = createRandomMerchantProfileResponseProperties.Data.UpdatedAt,
                    WalletReservationCharge = createRandomMerchantProfileResponseProperties.Data.WalletReservationCharge,
                    WalletToWalletTransfer = createRandomMerchantProfileResponseProperties.Data.WalletToWalletTransfer

                },
                Status = createRandomMerchantProfileResponseProperties.Status

            };



            var expectedResponse = new MerchantProfile
            {
                Response = randomMerchantProfileResponse
            };

           

            ExternalMerchantProfileResponse returnedExternalMerchantProfileResponse =
                randomExternalMerchantProfileResponse;

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.GetMerchantProfileAsync())
                     .ReturnsAsync(returnedExternalMerchantProfileResponse);

            // when
            MerchantProfile actualCreateMerchantProfile =
               await this.merchantService.GetMerchantProfileRequestAsync();

            // then
            actualCreateMerchantProfile.Should().BeEquivalentTo(expectedResponse);

            this.xPressWalletBrokerMock.Verify(broker =>
               broker.GetMerchantProfileAsync(),
                   Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
        }
    }
}
