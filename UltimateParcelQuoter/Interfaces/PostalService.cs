using RestSharp;

namespace UltimateParcelQuoter.Interfaces
{
    public abstract class PostalService<T,TResult>
    {
        private readonly RestClient _restClient;

        public PostalService(string baseUrl, string bearerToken)
        {
            var options = new RestClientOptions()
            {
                BaseUrl = new Uri(baseUrl)
            };

            _restClient = new RestClient(options);
            _restClient.AddDefaultHeader("Authorization", $"Bearer {bearerToken}");
        }

        public abstract Task<TResult> Quote(T entity);

        public async Task<TResult> ExecuteRequest<TResult>(RestRequest request)
        {
            return await _restClient.GetAsync<TResult>(request);
        }
    }
}
