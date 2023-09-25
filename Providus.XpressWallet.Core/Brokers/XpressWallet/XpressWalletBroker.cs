using Providus.XpressWallet.Core.Models.Configurations;
using RESTFulSense.Clients;
using System.Net.Http.Headers;


namespace Providus.XpressWallet.Core.Brokers.XpressWallet
{
    internal partial class XpressWalletBroker : IXpressWalletBroker
    {

        private readonly ApiConfigurations xPressWalletConfigurations;
        private readonly IRESTFulApiFactoryClient apiClient;
        private readonly HttpClient httpClient;


        public XpressWalletBroker(ApiConfigurations xPressWalletConfigurations)
        {
            this.xPressWalletConfigurations = xPressWalletConfigurations;
            this.httpClient = SetupHttpClient();
            this.apiClient = SetupApiClient();
        }


        private async ValueTask<T> GetAsync<T>(string relativeUrl) =>
           await this.apiClient.GetContentAsync<T>(relativeUrl);

        private async ValueTask<T> PostAsync<T>(string relativeUrl, T content) =>
            await this.apiClient.PostContentAsync(relativeUrl, content);

        private async ValueTask<TResult> PostAsync<TRequest, TResult>(string relativeUrl, TRequest content)
        {
            return await this.apiClient.PostContentAsync<TRequest, TResult>(
                relativeUrl,
                content,
                mediaType: "application/json",
                ignoreDefaultValues: true);
        }


        private async ValueTask<TResult> PostFormAsync<TRequest, TResult>(string relativeUrl, TRequest content)
            where TRequest : class
        {
            return await this.apiClient.PostFormAsync<TRequest, TResult>(
                relativeUrl,
                content);
        }



        private async ValueTask<TResult> PutAsync<TRequest, TResult>(string relativeUrl, TRequest content) =>
            await this.apiClient.PutContentAsync<TRequest, TResult>(
                relativeUrl,
                content,
                mediaType: "application/json",
                ignoreDefaultValues: true);

        private async ValueTask<T> PutAsync<T>(string relativeUrl, T content) =>
            await this.apiClient.PutContentAsync(relativeUrl, content);

        private async ValueTask<T> DeleteAsync<T>(string relativeUrl) =>
            await this.apiClient.DeleteContentAsync<T>(relativeUrl);

        private HttpClient SetupHttpClient()
        {
            var httpClient = new HttpClient()
            {
                BaseAddress =
                    new Uri(uriString: this.xPressWalletConfigurations.ApiUrl),
            };

            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(
                    scheme: "Bearer",
                    parameter: this.xPressWalletConfigurations.ApiKey);

            return httpClient;
        }

        private IRESTFulApiFactoryClient SetupApiClient() =>
            new RESTFulApiFactoryClient(this.httpClient);


    }
}

