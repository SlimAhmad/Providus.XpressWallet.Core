using FluentAssertions;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalCustomers;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Customers;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.Customers
{
    public partial class CustomersServiceTests
    {
        [Fact]
        public async Task ShouldPostAllCustomersWithAllCustomersRequestAsync()
        {
            // given 


            dynamic createRandomAllCustomersResponseProperties =
                CreateRandomAllCustomersResponseProperties();



            var randomExternalAllCustomersResponse = new ExternalAllCustomersResponse
            {

                Customers = ((List<dynamic>)createRandomAllCustomersResponseProperties.Customer).Select(customers =>
                {
                    return new ExternalAllCustomersResponse.Customer
                    {
                        FirstName = customers.FirstName,
                        Id = customers.Id,
                        LastName = customers.LastName,
                        WalletId = customers.WalletId,
                        Bvn = customers.Bvn,
                        BVNFirstName = customers.BVNFirstName,
                        BVNLastName = customers.BVNLastName,
                        CreatedAt = customers.CreatedAt,
                        DateOfBirth = customers.DateOfBirth,
                        Email = customers.Email,
                        NameMatch = customers.NameMatch,
                        PhoneNumber = customers.PhoneNumber,
                        UpdatedAt = customers.UpdatedAt,
                        Metadata = new ExternalAllCustomersResponse.ExternalMetadata
                        {
                            AdditionalData = customers.Metadata.AdditionalData,
                            EvenMore = customers.Metadata.EvenMore,
                            Page = customers.Metadata.Page,
                            TotalPages = customers.Metadata.TotalPages,
                            TotalRecords = customers.Metadata.TotalRecords,
                        },
                        DeletedAt = customers.DeletedAt,
                        Address = customers.Address,
                        Tier = customers.Tier,

                    };
                }).ToList(),
                Metadata = new ExternalAllCustomersResponse.ExternalMetadata
              {
                    EvenMore = createRandomAllCustomersResponseProperties.Metadata.EvenMore,
                    AdditionalData = createRandomAllCustomersResponseProperties.Metadata.AdditionalData,
                    Page = createRandomAllCustomersResponseProperties.Metadata.Page,
                    TotalPages = createRandomAllCustomersResponseProperties.Metadata.TotalPages,
                    TotalRecords = createRandomAllCustomersResponseProperties.Metadata.TotalRecords
                },
              Status = createRandomAllCustomersResponseProperties.Status
                   
            };


   
            var randomAllCustomersResponse = new AllCustomersResponse
            {
                Customers = ((List<dynamic>)createRandomAllCustomersResponseProperties.Customer).Select(customers =>
                {
                    return new AllCustomersResponse.Customer
                    {
                        FirstName = customers.FirstName,
                        Id = customers.Id,
                        LastName = customers.LastName,
                        WalletId = customers.WalletId,
                        Bvn = customers.Bvn,
                        BVNFirstName = customers.BVNFirstName,
                        BVNLastName = customers.BVNLastName,
                        CreatedAt = customers.CreatedAt,
                        DateOfBirth = customers.DateOfBirth,
                        Email = customers.Email,
                        NameMatch = customers.NameMatch,
                        PhoneNumber = customers.PhoneNumber,
                        UpdatedAt = customers.UpdatedAt,
                        Metadata = new AllCustomersResponse.MetadataResponse
                        {
                           AdditionalData = customers.Metadata.AdditionalData,
                           EvenMore = customers.Metadata.EvenMore,
                           Page = customers.Metadata.Page,
                           TotalPages = customers.Metadata.TotalPages,
                           TotalRecords = customers.Metadata.TotalRecords,
                        },
                        DeletedAt = customers.DeletedAt,
                        Address = customers.Address,
                        Tier = customers.Tier,

                    };
                }).ToList(),
                Metadata = new AllCustomersResponse.MetadataResponse
                {
                    EvenMore = createRandomAllCustomersResponseProperties.Metadata.EvenMore,
                    AdditionalData = createRandomAllCustomersResponseProperties.Metadata.AdditionalData,
                    Page = createRandomAllCustomersResponseProperties.Metadata.Page,
                    TotalPages = createRandomAllCustomersResponseProperties.Metadata.TotalPages,
                    TotalRecords = createRandomAllCustomersResponseProperties.Metadata.TotalRecords
                },
                Status = createRandomAllCustomersResponseProperties.Status

            };



            var expectedResponse = new AllCustomers
            {
                Response = randomAllCustomersResponse
            };

           

            ExternalAllCustomersResponse returnedExternalAllCustomersResponse =
                randomExternalAllCustomersResponse;

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.GetAllCustomersAsync())
                     .ReturnsAsync(returnedExternalAllCustomersResponse);

            // when
            AllCustomers actualCreateAllCustomers =
               await this.authService.GetAllCustomersRequestAsync();

            // then
            actualCreateAllCustomers.Should().BeEquivalentTo(expectedResponse);

            this.xPressWalletBrokerMock.Verify(broker =>
               broker.GetAllCustomersAsync(),
                   Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
        }
    }
}
