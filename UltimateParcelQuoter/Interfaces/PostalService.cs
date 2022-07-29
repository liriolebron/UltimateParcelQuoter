using RestSharp;
using RestSharp.Authenticators;

namespace UltimateParcelQuoter.Interfaces
{
    public abstract class PostalService<T, TResult> : IPostalService<T, TResult>
    {
        private readonly RestClient _restClient;

        public PostalService(string baseUrl, string userName, string password)
        {
            var options = new RestClientOptions()
            {
                BaseUrl = new Uri(baseUrl)
            };

            _restClient = new RestClient(options);
            _restClient.Authenticator = new HttpBasicAuthenticator(userName, password);
        }

        public async Task<TResult> GetAsync(RestRequest request)
        {
            return await _restClient.PostAsync<TResult>(request);
        }

        public abstract Task<TResult> Quote(T entity);
    }
}
