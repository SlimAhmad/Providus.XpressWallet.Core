using Providus.XpressWallet.Core.Brokers.DateTimes;
using Providus.XpressWallet.Core.Brokers.XpressWallet;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalCard;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Card;

namespace Providus.XpressWallet.Core.Services.Foundations.XpressWallet.Card
{
    internal partial class CardService : ICardService
    {
        private readonly IXpressWalletBroker xPressWalletBroker;
        private readonly IDateTimeBroker dateTimeBroker;

        public CardService(
            IXpressWalletBroker xPressWalletBroker,
            IDateTimeBroker dateTimeBroker)
        {
            this.xPressWalletBroker = xPressWalletBroker;
            this.dateTimeBroker = dateTimeBroker;
        }


        public ValueTask<CardSetup> PutCardSetupRequestAsync(CardSetup externalCardSetup) =>
        TryCatch(async () =>
        {
            ValidateCardSetup(externalCardSetup);
            ExternalCardSetupRequest externalCardSetupRequest = ConvertToCardRequest(externalCardSetup);
            ExternalCardSetupResponse externalCardSetupResponse = await xPressWalletBroker.PutCardSetupAsync(externalCardSetupRequest);
            return ConvertToCardResponse(externalCardSetup, externalCardSetupResponse);
        });

        public ValueTask<CreateCard> PostCreateCardRequestAsync(CreateCard externalCreateCard)=>
        TryCatch(async () =>
        {
            ValidateCreateCard(externalCreateCard);
            ExternalCreateCardRequest externalCreateCardRequest = ConvertToCardRequest(externalCreateCard);
            ExternalCreateCardResponse externalCreateCardResponse = await xPressWalletBroker.PostCreateCardAsync(externalCreateCardRequest);
            return ConvertToCardResponse(externalCreateCard, externalCreateCardResponse);
        });

        public ValueTask<ActivateCard> PostActivateCardRequestAsync(ActivateCard externalActivateCard)=>
        TryCatch(async () =>
        {
            ValidateActivateCard(externalActivateCard);
            ExternalActivateCardRequest externalActivateCardRequest = ConvertToCardRequest(externalActivateCard);
            ExternalActivateCardResponse externalActivateCardResponse = await xPressWalletBroker.PostActivateCardAsync(externalActivateCardRequest);
            return ConvertToCardResponse(externalActivateCard, externalActivateCardResponse);
        });

        public ValueTask<Balance> GetBalanceRequestAsync(string customerId)=>
        TryCatch(async () =>
        {
            ValidateBalanceParameters(customerId);
            ExternalBalanceResponse externalBalanceResponse = await xPressWalletBroker.GetBalanceAsync(customerId);
            return ConvertToCardResponse(externalBalanceResponse);
        });

        public ValueTask<FundCard> PostFundCardRequestAsync(FundCard externalFundCard)=>
        TryCatch(async () =>
        {
            ValidateFundCard(externalFundCard);
            ExternalFundCardRequest externalFundCardRequest = ConvertToCardRequest(externalFundCard);
            ExternalFundCardResponse externalFundCardResponse = await xPressWalletBroker.PostFundCardAsync(externalFundCardRequest);
            return ConvertToCardResponse(externalFundCard, externalFundCardResponse);
        });




        


        private static ExternalActivateCardRequest ConvertToCardRequest(ActivateCard activateCard)
        {

            return new ExternalActivateCardRequest
            {
                CustomerId = activateCard.Request.CustomerId,
                Last6 = activateCard.Request.Last6


            };



        }
        private static ExternalCreateCardRequest ConvertToCardRequest(CreateCard createCard)
        {

            return new ExternalCreateCardRequest
            {
                CustomerId = createCard.Request.CustomerId,
                Address1 = createCard.Request.Address1,
                Address2 = createCard.Request.Address2,
            };



        }
        private static ExternalFundCardRequest ConvertToCardRequest(FundCard fundCard)
        {

            return new ExternalFundCardRequest
            {
                CustomerId = fundCard.Request.CustomerId,
                Amount = fundCard.Request.Amount,
                
            };



        }
        private static ExternalCardSetupRequest ConvertToCardRequest(CardSetup cardSetup)
        {

            return new ExternalCardSetupRequest
            {
                AppId = cardSetup.Request.AppId,
                AppKey = cardSetup.Request.AppKey,
                LoadingAccountName = cardSetup.Request.LoadingAccountName,
                LoadingAccountNumber = cardSetup.Request.LoadingAccountNumber,
                LoadingAccountSortcode = cardSetup.Request.LoadingAccountSortcode,
                PrepaidCardPrefix = cardSetup.Request.PrepaidCardPrefix,
           
            };



        }


        private static Balance ConvertToCardResponse(ExternalBalanceResponse externalBalanceResponse)
        {
            return new Balance
            {
                Response = new BalanceResponse
                {
                    Status = externalBalanceResponse.Status,
                    Data = new BalanceResponse.DataResponse
                    {
                        AvailableBalance = externalBalanceResponse.Data.AvailableBalance,
                        CardNotPresentLimit = externalBalanceResponse.Data.CardNotPresentLimit,
                        CashLimit = externalBalanceResponse.Data.CashLimit,
                        CashNrTransLimit = externalBalanceResponse.Data.CashNrTransLimit,
                        CreatedAt = externalBalanceResponse.Data.CreatedAt,
                        DeletedAt = externalBalanceResponse.Data.DeletedAt,
                        DepositCreditLimit = externalBalanceResponse.Data.DepositCreditLimit,
                        GoodsLimit = externalBalanceResponse.Data.GoodsLimit,
                        GoodsNrTransLimit = externalBalanceResponse.Data.GoodsNrTransLimit,
                        Id = externalBalanceResponse.Data.Id,
                        LedgerBalance = externalBalanceResponse.Data.LedgerBalance,
                        PaymentLimit = externalBalanceResponse.Data.PaymentLimit,
                        PaymentNrTransLimit = externalBalanceResponse.Data.PaymentNrTransLimit,
                        UpdatedAt = externalBalanceResponse.Data.UpdatedAt,
                      
                    },
                }
            };



        }
        private static ActivateCard ConvertToCardResponse(
            ActivateCard activateCard,ExternalActivateCardResponse externalActivateCardResponse)
        {
            activateCard.Response = new ActivateCardResponse
            {
                Message = externalActivateCardResponse.Message,
                Status = externalActivateCardResponse.Status,
            };
            return activateCard;



        }
        private static CreateCard ConvertToCardResponse(
            CreateCard createCard,ExternalCreateCardResponse externalCreateCardResponse)
        {
            createCard.Response = new CreateCardResponse
            {
                Status = externalCreateCardResponse.Status,
                Message = externalCreateCardResponse.Message,
            };
            return createCard;


        }
        private static FundCard ConvertToCardResponse(
            FundCard fundCard,ExternalFundCardResponse externalFundCardResponse)
        {
            fundCard.Response = new FundCardResponse
            {
                Status = externalFundCardResponse.Status,
                Message = externalFundCardResponse.Message,
            };
            return fundCard;



        }
        private static CardSetup ConvertToCardResponse(
            CardSetup cardSetup,ExternalCardSetupResponse externalCardSetupResponse)
        {
            cardSetup.Response = new CardSetupResponse
            {
                Status = externalCardSetupResponse.Status,
                Message = externalCardSetupResponse.Message,
            };
            return cardSetup;



        }

      
    }
}
