using Providus.XpressWallet.Core.Models.Clients.Card.Exceptions;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Card;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Card.Exceptions;
using Providus.XpressWallet.Core.Services.Foundations.XpressWallet.Card;
using Xeptions;

namespace Providus.XpressWallet.Core.Clients.Card
{
    internal class CardClient : ICardClient
    {
        private readonly ICardService cardService;

        public CardClient(ICardService  cardService) =>
            this.cardService = cardService;

        public async ValueTask<ActivateCard> ActivateCardAsync(ActivateCard activateCard)
        {
            try
            {
                return await cardService.PostActivateCardRequestAsync(activateCard);
            }
            catch (CardValidationException CardValidationException)
            {

                throw new CardClientValidationException(
                    CardValidationException.InnerException as Xeption);
            }
            catch (CardDependencyValidationException CardDependencyValidationException)
            {


                throw new CardClientValidationException(
                    CardDependencyValidationException.InnerException as Xeption);
            }
            catch (CardDependencyException CardDependencyException)
            {
                throw new CardClientDependencyException(
                    CardDependencyException.InnerException as Xeption);
            }
            catch (CardServiceException CardServiceException)
            {
                throw new CardClientServiceException(
                    CardServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<CreateCard> CreateCardAsync(CreateCard createCard)
        {
            try
            {
                return await cardService.PostCreateCardRequestAsync(createCard);
            }
            catch (CardValidationException CardValidationException)
            {

                throw new CardClientValidationException(
                    CardValidationException.InnerException as Xeption);
            }
            catch (CardDependencyValidationException CardDependencyValidationException)
            {


                throw new CardClientValidationException(
                    CardDependencyValidationException.InnerException as Xeption);
            }
            catch (CardDependencyException CardDependencyException)
            {
                throw new CardClientDependencyException(
                    CardDependencyException.InnerException as Xeption);
            }
            catch (CardServiceException CardServiceException)
            {
                throw new CardClientServiceException(
                    CardServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<FundCard> FundCardAsync(FundCard fundCard)
        {
            try
            {
                return await cardService.PostFundCardRequestAsync(fundCard);
            }
            catch (CardValidationException CardValidationException)
            {

                throw new CardClientValidationException(
                    CardValidationException.InnerException as Xeption);
            }
            catch (CardDependencyValidationException CardDependencyValidationException)
            {


                throw new CardClientValidationException(
                    CardDependencyValidationException.InnerException as Xeption);
            }
            catch (CardDependencyException CardDependencyException)
            {
                throw new CardClientDependencyException(
                    CardDependencyException.InnerException as Xeption);
            }
            catch (CardServiceException CardServiceException)
            {
                throw new CardClientServiceException(
                    CardServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<CardSetup> ModifyCardSetupAsync(CardSetup cardSetup)
        {
            try
            {
                return await cardService.PutCardSetupRequestAsync(cardSetup);
            }
            catch (CardValidationException CardValidationException)
            {

                throw new CardClientValidationException(
                    CardValidationException.InnerException as Xeption);
            }
            catch (CardDependencyValidationException CardDependencyValidationException)
            {


                throw new CardClientValidationException(
                    CardDependencyValidationException.InnerException as Xeption);
            }
            catch (CardDependencyException CardDependencyException)
            {
                throw new CardClientDependencyException(
                    CardDependencyException.InnerException as Xeption);
            }
            catch (CardServiceException CardServiceException)
            {
                throw new CardClientServiceException(
                    CardServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<Balance> RetrieveBalanceAsync(string customerId)
        {
            try
            {
                return await cardService.GetBalanceRequestAsync(customerId);
            }
            catch (CardValidationException CardValidationException)
            {

                throw new CardClientValidationException(
                    CardValidationException.InnerException as Xeption);
            }
            catch (CardDependencyValidationException CardDependencyValidationException)
            {


                throw new CardClientValidationException(
                    CardDependencyValidationException.InnerException as Xeption);
            }
            catch (CardDependencyException CardDependencyException)
            {
                throw new CardClientDependencyException(
                    CardDependencyException.InnerException as Xeption);
            }
            catch (CardServiceException CardServiceException)
            {
                throw new CardClientServiceException(
                    CardServiceException.InnerException as Xeption);
            }
        }
    }
}
