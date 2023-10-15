using FluentAssertions;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalProviPay.ExternalFields;
using Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.Fields;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.BillPayment
{
    public partial class BillPaymentServiceTests
    {
        [Fact]
        public async Task ShouldRetrieveFieldsWithFieldsRequestAsync()
        {
            // given 


            dynamic createRandomFieldsResponseProperties =
                CreateRandomFieldsResponseProperties();



            var randomExternalFieldsResponse = new ExternalFieldsResponse
            {

                BillId = createRandomFieldsResponseProperties.BillId,
                Fee = createRandomFieldsResponseProperties.Fee,
                FieldId = createRandomFieldsResponseProperties.FieldId,
                Type = createRandomFieldsResponseProperties.Type,
                Validate = createRandomFieldsResponseProperties.Validate,
                Fields = ((List<dynamic>)createRandomFieldsResponseProperties.Fields).Select(fields =>
                {
                    return new ExternalFieldsResponse.Field
                    {
                        CallTag = fields.CallTag,
                        FieldType = fields.FieldType,
                        Key = fields.Key,
                        Name = fields.Name,
                        List = new ExternalFieldsResponse.List
                        {
                           Items = ((List<dynamic>)fields.List.Items).Select(items =>
                           {
                               return new ExternalFieldsResponse.Item
                               {
                                   Name = items.Name,
                                   Amount = items.Amount,
                                   Id = items.Id,
                               };
                           }).ToList()
                        }

                    };
                }).ToList(),
                   
            };


   
            var randomFieldsResponse = new FieldsResponse
            {
                BillId = createRandomFieldsResponseProperties.BillId,
                Fee = createRandomFieldsResponseProperties.Fee,
                FieldId = createRandomFieldsResponseProperties.FieldId,
                Type = createRandomFieldsResponseProperties.Type,
                Validate = createRandomFieldsResponseProperties.Validate,
                Fields = ((List<dynamic>)createRandomFieldsResponseProperties.Fields).Select(fields =>
                {
                    return new FieldsResponse.Field
                    {
                        CallTag = fields.CallTag,
                        FieldType = fields.FieldType,
                        Key = fields.Key,
                        Name = fields.Name,
                        List = new FieldsResponse.List
                        {
                            Items = ((List<dynamic>)fields.List.Items).Select(items =>
                            {
                                return new FieldsResponse.Item
                                {
                                    Name = items.Name,
                                    Amount = items.Amount,
                                    Id = items.Id,
                                };
                            }).ToList()
                        }

                    };
                }).ToList(),

            };



            var expectedResponse = new Fields
            {
                Response = randomFieldsResponse
            };

            var inputBillId = GetRandomString();

            ExternalFieldsResponse returnedExternalFieldsResponse =
                randomExternalFieldsResponse;

            this.proviPayBrokerMock.Setup(broker =>
                broker.GetFieldsAsync(It.IsAny<string>()))
                     .ReturnsAsync(returnedExternalFieldsResponse);

            // when
            Fields actualCreateFields =
               await this.billPaymentService.GetFieldsRequestAsync(inputBillId);

            // then
            actualCreateFields.Should().BeEquivalentTo(expectedResponse);

            this.proviPayBrokerMock.Verify(broker =>
               broker.GetFieldsAsync(It.IsAny<string>()),
                   Times.Once);

            this.proviPayBrokerMock.VerifyNoOtherCalls();
        }
    }
}
