using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace ParaBankPractice.API.Services
{
    public class BaseService
    {
        protected readonly RestClient _client;
        protected readonly string _acceptedContentType = "application/json";

        public BaseService(string baseUrl)
        {
            var options = new RestClientOptions(baseUrl);
            _client = new RestClient(options);
        }
        
        public async Task<RestResponse> DeleteAsync(string endpoint)
        {
            return await _client.ExecuteAsync(new RestRequest(endpoint, Method.Delete));
        }

        public async Task<RestResponse<T>> DeleteAsync<T>(string endpoint, T body)
        {
            var jsonBody = JsonConvert.SerializeObject(body);

            var restRequest = new RestRequest(endpoint, Method.Delete)
                .AddParameter(_acceptedContentType, jsonBody, ParameterType.RequestBody);

            return await _client.ExecuteAsync<T>(restRequest);
        }

        public async Task<RestResponse<T>> GetAsync<T>(string endpoint)
        {
            var restRequest = new RestRequest(endpoint, Method.Get);
            Console.WriteLine(_client.Options.BaseUrl + endpoint);
            return await _client.ExecuteAsync<T>(restRequest);
        }

        public async Task<RestResponse<T>> PostAsync<T>(string endpoint, T body)
        {
            var jsonBody = JsonConvert.SerializeObject(body);
            Console.WriteLine(jsonBody);
            Console.WriteLine(_client.Options.BaseUrl + endpoint);

            var restRequest = new RestRequest(endpoint, Method.Get)
                .AddParameter(_acceptedContentType, jsonBody, ParameterType.RequestBody);

            return await _client.ExecuteAsync<T>(restRequest);
        }

        public async Task<RestResponse<W>> PostAsync<T,W>(string endpoint, T body)
        {
            string jsonBody = JsonConvert.SerializeObject(body);
            var restRequest = new RestRequest(endpoint, Method.Post)
                .AddParameter(_acceptedContentType, jsonBody, ParameterType.RequestBody);

            return await _client.ExecuteAsync<W>(restRequest);
        }

        public async Task<RestResponse> ExecuteAsync(RestRequest request)
        {
            return await _client.ExecuteAsync(request);
        }
    }
}