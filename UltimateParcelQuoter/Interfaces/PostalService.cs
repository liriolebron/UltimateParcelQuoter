using RestSharp;
using UltimateParcelQuoter.Models;

namespace UltimateParcelQuoter.Interfaces
{
    public abstract class PostalService<T,TResult> : IPostalService<T, TResult>
    {
        private readonly RestClient _restClient;

        public PostalService(string baseUrl, string bearerToken)
        {
            var options = new RestClientOptions()
            {
                BaseUrl = new Uri(baseUrl)
            };

            _restClient = new RestClient(options);
            //_restClient.AddDefaultHeader("Authorization", $"Bearer {bearerToken}");
        }        

        public async Task<TResult> GetAsync(RestRequest request)
        {
            var result = await _restClient.ExecutePostAsync(request);

            return await _restClient.PostAsync<TResult>(request);
        }

        public abstract Task<TResult> Quote(T entity);
    }
}
