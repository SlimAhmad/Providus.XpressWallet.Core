using Providus.XpressWallet.Core.Models.Configurations;
using RESTFulSense.Clients;
using System.Net.Http.Headers;
using System.Text;


namespace Providus.XpressWallet.Core.Brokers.ProviPay
{
    internal partial class ProviPayBroker : IProviPayBroker
    {

        private readonly ApiConfigurations proviPayConfigurations;
        private readonly IRESTFulApiFactoryClient apiClient;
        private readonly HttpClient httpClient;


        public ProviPayBroker(ApiConfigurations proviPayConfigurations)
        {
            this.proviPayConfigurations = proviPayConfigurations;
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
            string credentials = Convert.ToBase64String(
                Encoding.ASCII.GetBytes($"{proviPayConfigurations.UserName}:{proviPayConfigurations.Password}"));

            var httpClient = new HttpClient()
            {
                BaseAddress =
                    new Uri(uriString: this.proviPayConfigurations.ApiUrl),
            };

            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(
                    scheme: "Basic",
                    parameter: credentials);

            return httpClient;
        }

        private IRESTFulApiFactoryClient SetupApiClient() =>
            new RESTFulApiFactoryClient(this.httpClient);


    }
}

