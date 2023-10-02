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
        public async Task ShouldPostCustomerCreditCustomerWalletWithCustomerCreditCustomerWalletRequestAsync()
        {
            // given 



            dynamic createRandomCustomerCreditCustomerWalletRequestProperties =
              CreateRandomCustomerCreditCustomerWalletRequestProperties();

            dynamic createRandomCustomerCreditCustomerWalletResponseProperties =
                CreateRandomCustomerCreditCustomerWalletResponseProperties();


            var randomExternalCustomerCreditCustomerWalletRequest = new ExternalCustomerCreditCustomerWalletRequest
            {
                BatchReference = createRandomCustomerCreditCustomerWalletRequestProperties.BatchReference,
                CustomerId = createRandomCustomerCreditCustomerWalletRequestProperties.CustomerId,
                Recipients = ((List<dynamic>)createRandomCustomerCreditCustomerWalletRequestProperties.Recipients).Select(recipients =>
                {
                    return new ExternalCustomerCreditCustomerWalletRequest.Recipient
                    {
                        CustomerId = recipients.CustomerId,
                        Amount = recipients.Amount,
                        Reference = recipients.Reference

                    };
                }).ToList()

            };

            var randomExternalCustomerCreditCustomerWalletResponse = new ExternalCustomerCreditCustomerWalletResponse
            {

                Data = new ExternalCustomerCreditCustomerWalletResponse.ExternalData
                {
                    Accepted = ((List<dynamic>)createRandomCustomerCreditCustomerWalletResponseProperties.Data.Accepted).Select(accpeted =>
                    {
                        return new ExternalCustomerCreditCustomerWalletResponse.Accepted
                        {
                            CustomerId = accpeted.CustomerId,
                            Amount = accpeted.Amount,
                            Reference = accpeted.Reference,
                           
                        };
                    }).ToList(),
                    Rejected = ((List<dynamic>)createRandomCustomerCreditCustomerWalletResponseProperties.Data.Rejected).Select(rejected =>
                    {
                        return new ExternalCustomerCreditCustomerWalletResponse.Rejected
                        {
                            CustomerId = rejected.CustomerId,
                            Amount = rejected.Amount,
                            Reference = rejected.Reference,
                            Reason = rejected.Reason,
                            ReferenceExists = rejected.ReferenceExists,
                         

                        };
                    }).ToList(),
                    BatchReference = createRandomCustomerCreditCustomerWalletResponseProperties.Data.BatchReference
                },
                Message = createRandomCustomerCreditCustomerWalletResponseProperties.Message,
                Status = createRandomCustomerCreditCustomerWalletResponseProperties.Status

            };


            var randomCustomerCreditCustomerWalletRequest = new CustomerCreditCustomerWalletRequest
            {
                BatchReference = createRandomCustomerCreditCustomerWalletRequestProperties.BatchReference,
                CustomerId = createRandomCustomerCreditCustomerWalletRequestProperties.CustomerId,
                Recipients = ((List<dynamic>)createRandomCustomerCreditCustomerWalletRequestProperties.Recipients).Select(recipients =>
                {
                    return new CustomerCreditCustomerWalletRequest.Recipient
                    {
                        CustomerId = recipients.CustomerId,
                        Amount = recipients.Amount,
                        Reference = recipients.Reference

                    };
                }).ToList()
            };

            var randomCustomerCreditCustomerWalletResponse = new CustomerCreditCustomerWalletResponse
            {
                Data = new CustomerCreditCustomerWalletResponse.DataResponse
                {
                    Accepted = ((List<dynamic>)createRandomCustomerCreditCustomerWalletResponseProperties.Data.Accepted).Select(accpeted =>
                    {
                        return new CustomerCreditCustomerWalletResponse.Accepted
                        {
                            CustomerId = accpeted.CustomerId,
                            Amount = accpeted.Amount,
                            Reference = accpeted.Reference,

                        };
                    }).ToList(),
                    Rejected = ((List<dynamic>)createRandomCustomerCreditCustomerWalletResponseProperties.Data.Rejected).Select(rejected =>
                    {
                        return new CustomerCreditCustomerWalletResponse.Rejected
                        {
                            CustomerId = rejected.CustomerId,
                            Amount = rejected.Amount,
                            Reference = rejected.Reference,
                            Reason = rejected.Reason,
                            ReferenceExists = rejected.ReferenceExists,


                        };
                    }).ToList(),
                    BatchReference = createRandomCustomerCreditCustomerWalletResponseProperties.Data.BatchReference
                },
                Message = createRandomCustomerCreditCustomerWalletResponseProperties.Message,
                Status = createRandomCustomerCreditCustomerWalletResponseProperties.Status
            };


            var randomCustomerCreditCustomerWallet = new CustomerCreditCustomerWallet
            {
                Request = randomCustomerCreditCustomerWalletRequest,
            };

           

            CustomerCreditCustomerWallet inputCustomerCreditCustomerWallet = randomCustomerCreditCustomerWallet;
            CustomerCreditCustomerWallet expectedCustomerCreditCustomerWallet = inputCustomerCreditCustomerWallet.DeepClone();
            expectedCustomerCreditCustomerWallet.Response = randomCustomerCreditCustomerWalletResponse;

            ExternalCustomerCreditCustomerWalletRequest mappedExternalCustomerCreditCustomerWalletRequest =
               randomExternalCustomerCreditCustomerWalletRequest;

            ExternalCustomerCreditCustomerWalletResponse returnedExternalCustomerCreditCustomerWalletResponse =
                randomExternalCustomerCreditCustomerWalletResponse;

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostCustomerCreditCustomerWalletAsync(It.Is(
                      SameExternalCustomerCreditCustomerWalletRequestAs(mappedExternalCustomerCreditCustomerWalletRequest))))
                     .ReturnsAsync(returnedExternalCustomerCreditCustomerWalletResponse);

            // when
            CustomerCreditCustomerWallet actualCreateCustomerCreditCustomerWallet =
               await this.walletService.PostCustomerCreditCustomerWalletRequestAsync(inputCustomerCreditCustomerWallet);

            // then
            actualCreateCustomerCreditCustomerWallet.Should().BeEquivalentTo(expectedCustomerCreditCustomerWallet);

            this.xPressWalletBrokerMock.Verify(broker =>
               broker.PostCustomerCreditCustomerWalletAsync(It.Is(
                   SameExternalCustomerCreditCustomerWalletRequestAs(mappedExternalCustomerCreditCustomerWalletRequest))),
                   Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
        }
    }
}
