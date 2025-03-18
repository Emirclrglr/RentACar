using System.Text;
using Newtonsoft.Json;
using NuGet.Protocol;
using RentACar.UI.APIConnection;

namespace RentACar.UI.HttpService
{
    public class HttpService<T>
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IApiConfig _apiConfig;
        private readonly HttpClient _client;
        public HttpService(IHttpClientFactory httpClientFactory, IApiConfig apiConfig, HttpClient client)
        {
            _httpClientFactory = httpClientFactory;
            _apiConfig = apiConfig;
            _client = _httpClientFactory.CreateClient();
        }

        /// <summary>
        /// Deletes the data that specified with the id.
        /// </summary>
        /// <param name="requestAddress">Endpoint address to send request</param>
        /// <param name="id">id parameter to delete specified value</param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> HttpDelete(string requestAddress, int id)
        {
            var responseMessage = await _client.DeleteAsync($"{_apiConfig.BaseUrl}{requestAddress}/{id}");
            return responseMessage;
        }

        /// <summary>
        /// Sends a get request to the specified endpoint.
        /// </summary>
        /// <param name="requestAddress">Endpoint address to send request</param>
        /// <param name="id">Gets the values with the specified id</param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> HttpGet(string requestAddress, int? id = default)
        {
            if (id == null)
            {
                var responseMessage = await _client.GetAsync($"{_apiConfig.BaseUrl}{requestAddress}");
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<IEnumerable<T>>(jsonData);
                return values;
            }
            else
            {
                var responseMessage = await _client.GetAsync($"{_apiConfig.BaseUrl}{requestAddress}/{id}");
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<IEnumerable<T>>(jsonData);
                return values;
            }
        }

        /// <summary>
        /// Sends a get request to the specified endpoint and returns a single value.
        /// </summary>
        /// <param name="requestAddress">Endpoint address to send request</param>
        /// <param name="id">Gets the value with the specified id and returns a sigle value.</param>
        /// <returns></returns>
        public async Task<T> HttpGetSingle(string requestAddress, int? id = default)
        {
            if (id == null)
            {
                var responseMessage = await _client.GetAsync($"{_apiConfig.BaseUrl}{requestAddress}");
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                if (jsonData.Trim().StartsWith("{") || jsonData.Trim().StartsWith("["))
                {
                    var values = JsonConvert.DeserializeObject<T>(jsonData);
                    return values;
                }
                else
                {
                    return (T)Convert.ChangeType(jsonData, typeof(T));
                }
            }
            else
            {
                var responseMessage = await _client.GetAsync($"{_apiConfig.BaseUrl}{requestAddress}/{id}");
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<T>(jsonData);
                return values;
            }
           
        }

        /// <summary>
        /// Sends a get request to the specified endpoint and returns a single value that specified with id parameter.
        /// </summary>
        /// <param name="requestAddress">Endpoint address to send request</param>
        /// <param name="id">Gets the values with the specified id</param>
        /// <returns></returns>
        public async Task<T> HttpGetById(string requestAddress, int id)
        {
            var responseMessage = await _client.GetAsync($"{_apiConfig.BaseUrl}{requestAddress}/{id}");

            if (!responseMessage.IsSuccessStatusCode)
            {
                Console.WriteLine($"Error: {responseMessage.StatusCode} - {await responseMessage.Content.ReadAsStringAsync()}");
                return default; 
            }

            var jsonData = await responseMessage.Content.ReadAsStringAsync();

            if (string.IsNullOrWhiteSpace(jsonData))
            {
                Console.WriteLine("Error: API returned null.");
                return default;
            }

            try
            {
                var values = JsonConvert.DeserializeObject<T>(jsonData);
                return values;
            }
            catch (JsonReaderException ex)
            {
                Console.WriteLine($"JSON deserialize error: {ex.Message}");
                return default;
            }
        }

        /// <summary>
        /// Sends a post request to the specified endpoint.
        /// </summary>
        /// <param name="serializeObject">The object to be serialize</param>
        /// <param name="requestAddress">Endpoint address to send request</param>
        /// <param name="encodingType"></param>
        /// <param name="mediaType"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> HttpPost(T serializeObject, string requestAddress, Encoding encodingType, string mediaType = "application/json")
        {
            StringContent content = new(JsonConvert.SerializeObject(serializeObject), encodingType, mediaType);
            var responseMessage = await _client.PostAsync($"{_apiConfig.BaseUrl}{requestAddress}", content);
            return responseMessage;
        }

        /// <summary>
        /// Sends a put request to the specified endpoint.
        /// </summary>
        /// <param name="serializeObject">The object to be serialize</param>
        /// <param name="requestAddress">Endpoint address to send request</param>
        /// <param name="encodingType"></param>
        /// <param name="mediaType"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> HttpPut(T serializeObject, string requestAddress, Encoding encodingType, string mediaType = "application/json")
        {
            StringContent content = new(JsonConvert.SerializeObject(serializeObject), encodingType, mediaType);
            var responseMessage = await _client.PutAsync($"{_apiConfig.BaseUrl}{requestAddress}", content);
            return responseMessage;
        }
    }
}
