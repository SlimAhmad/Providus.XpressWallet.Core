using FluentAssertions;
using Force.DeepCloner;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalWallet;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Wallet;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.Wallet
{
    public partial class WalletServiceTests
    {
        [Fact]
        public async Task ShouldPostCreateWalletWithCreateWalletRequestAsync()
        {
            // given 



            dynamic createRandomCreateWalletRequestProperties =
              CreateRandomCreateWalletRequestProperties();

            dynamic createRandomCreateWalletResponseProperties =
                CreateRandomCreateWalletResponseProperties();


            var randomExternalCreateWalletRequest = new ExternalCreateWalletRequest
            {
                Address = createRandomCreateWalletRequestProperties.Address,
                Bvn = createRandomCreateWalletRequestProperties.Bvn,
                DateOfBirth = createRandomCreateWalletRequestProperties.DateOfBirth,
                Email = createRandomCreateWalletRequestProperties.Email,
                FirstName = createRandomCreateWalletRequestProperties.FirstName,
                LastName = createRandomCreateWalletRequestProperties.LastName,
                PhoneNumber = createRandomCreateWalletRequestProperties.PhoneNumber,
                Metadata = new ExternalCreateWalletRequest.ExternalMetadata
                {
                    AdditionalData = createRandomCreateWalletRequestProperties.Metadata.AdditionalData,
                    EvenMore = createRandomCreateWalletRequestProperties.Metadata.EvenMore
                }

            };

            var randomExternalCreateWalletResponse = new ExternalCreateWalletResponse
            {

                Customer = new ExternalCreateWalletResponse.ExternalCustomer
                {
                    Address = createRandomCreateWalletResponseProperties.Customer.Address,
                    Bvn = createRandomCreateWalletResponseProperties.Customer.Bvn,
                    BVNFirstName = createRandomCreateWalletResponseProperties.Customer.BVNFirstName,
                    BVNLastName = createRandomCreateWalletResponseProperties.Customer.BVNLastName,
                    CreatedAt = createRandomCreateWalletResponseProperties.Customer.CreatedAt,
                    Currency = createRandomCreateWalletResponseProperties.Customer.Currency,
                    DateOfBirth = createRandomCreateWalletResponseProperties.Customer.DateOfBirth,
                    Email = createRandomCreateWalletResponseProperties.Customer.Email,
                    FirstName = createRandomCreateWalletResponseProperties.Customer.FirstName,
                    Id = createRandomCreateWalletResponseProperties.Customer.Id,
                    LastName = createRandomCreateWalletResponseProperties.Customer.LastName,
                    MerchantId = createRandomCreateWalletResponseProperties.Customer.MerchantId,
                    Mode = createRandomCreateWalletResponseProperties.Customer.Mode,
                    NameMatch = createRandomCreateWalletResponseProperties.Customer.NameMatch,
                    PhoneNumber = createRandomCreateWalletResponseProperties.Customer.PhoneNumber,
                    Tier = createRandomCreateWalletResponseProperties.Customer.Tier,
                    UpdatedAt = createRandomCreateWalletResponseProperties.Customer.UpdatedAt,
                    Metadata = new ExternalCreateWalletResponse.Metadata
                    {
                        AdditionalData = createRandomCreateWalletResponseProperties.Customer.Metadata.AdditionalData,
                        EvenMore = createRandomCreateWalletResponseProperties.Customer.Metadata.EvenMore
                    }

                },
                Wallet = new ExternalCreateWalletResponse.ExternalWallet
                {
                    Id = createRandomCreateWalletResponseProperties.Wallet.Id,
                    UpdatedAt = createRandomCreateWalletResponseProperties.Wallet.UpdatedAt,
                    AccountName = createRandomCreateWalletResponseProperties.Wallet.AccountName,
                    AccountNumber = createRandomCreateWalletResponseProperties.Wallet.AccountNumber,
                    AccountReference = createRandomCreateWalletResponseProperties.Wallet.AccountReference,
                    AvailableBalance = createRandomCreateWalletResponseProperties.Wallet.AvailableBalance,
                    BankCode = createRandomCreateWalletResponseProperties.Wallet.BankCode,
                    BankName = createRandomCreateWalletResponseProperties.Wallet.BankName,
                    BookedBalance = createRandomCreateWalletResponseProperties.Wallet.BookedBalance,
                    CreatedAt = createRandomCreateWalletResponseProperties.Wallet.CreatedAt,
                    Currency = createRandomCreateWalletResponseProperties.Wallet.Currency,
                    Email = createRandomCreateWalletResponseProperties.Wallet.Email,
                    Mode = createRandomCreateWalletResponseProperties.Wallet.Mode,
                    Status = createRandomCreateWalletResponseProperties.Wallet.Status,
                    Updated = createRandomCreateWalletResponseProperties.Wallet.Updated,
                    WalletId = createRandomCreateWalletResponseProperties.Wallet.WalletId,
                    WalletType = createRandomCreateWalletResponseProperties.Wallet.WalletType,

                },
                Status = createRandomCreateWalletResponseProperties.Status

            };


            var randomCreateWalletRequest = new CreateWalletRequest
            {
                Address = createRandomCreateWalletRequestProperties.Address,
                Bvn = createRandomCreateWalletRequestProperties.Bvn,
                DateOfBirth = createRandomCreateWalletRequestProperties.DateOfBirth,
                Email = createRandomCreateWalletRequestProperties.Email,
                FirstName = createRandomCreateWalletRequestProperties.FirstName,
                LastName = createRandomCreateWalletRequestProperties.LastName,
                PhoneNumber = createRandomCreateWalletRequestProperties.PhoneNumber,
                Metadata = new CreateWalletRequest.MetadataResponse
                {
                    AdditionalData = createRandomCreateWalletRequestProperties.Metadata.AdditionalData,
                    EvenMore = createRandomCreateWalletRequestProperties.Metadata.EvenMore
                }
            };

            var randomCreateWalletResponse = new CreateWalletResponse
            {
                Customer = new CreateWalletResponse.CustomerResponse
                {
                   Address =createRandomCreateWalletResponseProperties.Customer.Address,
                   Bvn = createRandomCreateWalletResponseProperties.Customer.Bvn,
                   BVNFirstName = createRandomCreateWalletResponseProperties.Customer.BVNFirstName,
                   BVNLastName = createRandomCreateWalletResponseProperties.Customer.BVNLastName,
                   CreatedAt = createRandomCreateWalletResponseProperties.Customer.CreatedAt,
                   Currency = createRandomCreateWalletResponseProperties.Customer.Currency,
                   DateOfBirth = createRandomCreateWalletResponseProperties.Customer.DateOfBirth,
                   Email = createRandomCreateWalletResponseProperties.Customer.Email,
                   FirstName = createRandomCreateWalletResponseProperties.Customer.FirstName,
                   Id = createRandomCreateWalletResponseProperties.Customer.Id,
                   LastName = createRandomCreateWalletResponseProperties.Customer.LastName,
                   MerchantId = createRandomCreateWalletResponseProperties.Customer.MerchantId,
                   Mode = createRandomCreateWalletResponseProperties.Customer.Mode,
                   NameMatch = createRandomCreateWalletResponseProperties.Customer.NameMatch,
                   PhoneNumber = createRandomCreateWalletResponseProperties.Customer.PhoneNumber,
                   Tier = createRandomCreateWalletResponseProperties.Customer.Tier,
                   UpdatedAt = createRandomCreateWalletResponseProperties.Customer.UpdatedAt,
                   Metadata = new CreateWalletResponse.Metadata
                   {
                     AdditionalData = createRandomCreateWalletResponseProperties.Customer.Metadata.AdditionalData,
                     EvenMore = createRandomCreateWalletResponseProperties.Customer.Metadata.EvenMore
                   }
                  
                },
                Wallet = new CreateWalletResponse.WalletResponse
                {
                 Id  = createRandomCreateWalletResponseProperties.Wallet.Id,
                 UpdatedAt = createRandomCreateWalletResponseProperties.Wallet.UpdatedAt,
                 AccountName = createRandomCreateWalletResponseProperties.Wallet.AccountName,
                 AccountNumber = createRandomCreateWalletResponseProperties.Wallet.AccountNumber,
                 AccountReference = createRandomCreateWalletResponseProperties.Wallet.AccountReference,
                 AvailableBalance = createRandomCreateWalletResponseProperties.Wallet.AvailableBalance,
                 BankCode = createRandomCreateWalletResponseProperties.Wallet.BankCode,
                 BankName = createRandomCreateWalletResponseProperties.Wallet.BankName,
                 BookedBalance = createRandomCreateWalletResponseProperties.Wallet.BookedBalance,
                 CreatedAt = createRandomCreateWalletResponseProperties.Wallet.CreatedAt,
                 Currency = createRandomCreateWalletResponseProperties.Wallet.Currency,
                 Email = createRandomCreateWalletResponseProperties.Wallet.Email,
                 Mode = createRandomCreateWalletResponseProperties.Wallet.Mode,
                 Status = createRandomCreateWalletResponseProperties.Wallet.Status,
                 Updated = createRandomCreateWalletResponseProperties.Wallet.Updated,
                 WalletId = createRandomCreateWalletResponseProperties.Wallet.WalletId,
                 WalletType = createRandomCreateWalletResponseProperties.Wallet.WalletType,
                 
                },
                Status = createRandomCreateWalletResponseProperties.Status
            };


            var randomCreateWallet = new CreateWallet
            {
                Request = randomCreateWalletRequest,
            };

           

            CreateWallet inputCreateWallet = randomCreateWallet;
            CreateWallet expectedCreateWallet = inputCreateWallet.DeepClone();
            expectedCreateWallet.Response = randomCreateWalletResponse;

            ExternalCreateWalletRequest mappedExternalCreateWalletRequest =
               randomExternalCreateWalletRequest;

            ExternalCreateWalletResponse returnedExternalCreateWalletResponse =
                randomExternalCreateWalletResponse;

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostCreateWalletAsync(It.Is(
                      SameExternalCreateWalletRequestAs(mappedExternalCreateWalletRequest))))
                     .ReturnsAsync(returnedExternalCreateWalletResponse);

            // when
            CreateWallet actualCreateCreateWallet =
               await this.walletService.PostCreateWalletRequestAsync(inputCreateWallet);

            // then
            actualCreateCreateWallet.Should().BeEquivalentTo(expectedCreateWallet);

            this.xPressWalletBrokerMock.Verify(broker =>
               broker.PostCreateWalletAsync(It.Is(
                   SameExternalCreateWalletRequestAs(mappedExternalCreateWalletRequest))),
                   Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
        }
    }
}
