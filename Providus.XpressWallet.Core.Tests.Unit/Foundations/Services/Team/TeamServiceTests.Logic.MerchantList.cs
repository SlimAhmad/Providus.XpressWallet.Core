using FluentAssertions;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalTeam;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Team;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.Team
{
    public partial class TeamServiceTests
    {
        [Fact]
        public async Task ShouldPostMerchantListWithMerchantListRequestAsync()
        {
            // given 


            dynamic createRandomMerchantListResponseProperties =
                CreateRandomMerchantListResponseProperties();



            var randomExternalMerchantListResponse = new ExternalMerchantListResponse
            {

                Data = ((List<dynamic>)createRandomMerchantListResponseProperties.Data).Select(data => 
                {
                    return new ExternalMerchantListResponse.Datum
                    {
                         Role = data.Role,
                         Id = data.Id,
                         Name = data.Name,
                    };
                }).ToList(),
               
                Status = createRandomMerchantListResponseProperties.Status
                   
            };


   
            var randomMerchantListResponse = new MerchantListResponse
            {
                Data = ((List<dynamic>)createRandomMerchantListResponseProperties.Data).Select(data =>
                {
                    return new MerchantListResponse.Datum
                    {
                        Role = data.Role,
                        Id = data.Id,
                        Name = data.Name,
                    };
                }).ToList(),

                Status = createRandomMerchantListResponseProperties.Status

            };



            var expectedResponse = new MerchantList
            {
                Response = randomMerchantListResponse
            };

           

            ExternalMerchantListResponse returnedExternalMerchantListResponse =
                randomExternalMerchantListResponse;

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.GetMerchantListAsync())
                     .ReturnsAsync(returnedExternalMerchantListResponse);

            // when
            MerchantList actualCreateMerchantList =
               await this.teamService.GetMerchantListRequestAsync();

            // then
            actualCreateMerchantList.Should().BeEquivalentTo(expectedResponse);

            this.xPressWalletBrokerMock.Verify(broker =>
               broker.GetMerchantListAsync(),
                   Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
        }
    }
}
