using Microsoft.Net.Http.Headers;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace AHL.UI.Areas.Admin.HttpApiServices
{
    public class HttpApiService : IHttpApiService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public HttpApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<T> GetData<T>(string endPoint, string token = null)
        {
            var baseAddress = "http://localhost:5017/api";

            var client = _httpClientFactory.CreateClient();

            var requestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{baseAddress}{endPoint}"),
                Headers =
                {
                    { HeaderNames.Accept, "application/json" }
                }
            };

            if(!string.IsNullOrEmpty(token))
            
               requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);  
          
            var responseMessage = await client.SendAsync(requestMessage);

            var jsonResponse = await responseMessage.Content.ReadAsStringAsync();

            var response = JsonSerializer.Deserialize<T>(jsonResponse,
               new JsonSerializerOptions() { PropertyNameCaseInsensitive = true} );

            return response!;
        }

        public async Task<T> PostData<T>(string endPoint, string jsonData)
        {
            var baseAddress = "http://localhost:5017/api";

            var client = _httpClientFactory.CreateClient();

            var requestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"{baseAddress}{endPoint}"),
                Headers =
                {
                    { HeaderNames.Accept, "application/json" }
                },
                Content = new StringContent(jsonData, Encoding.UTF8, "application/json")
            };

            var responseMessage = await client.SendAsync(requestMessage);

            var jsonResponse = await responseMessage.Content.ReadAsStringAsync();

            var response = JsonSerializer.Deserialize<T>(jsonResponse,
               new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            return response!;
        }

        public async Task<T> DeleteData<T>(string endPoint, string token = null)
        {
            var baseAddress = "http://localhost:5017/api";

            var client = _httpClientFactory.CreateClient();

            var requestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri($"{baseAddress}{endPoint}"),
                Headers =
        {
          {HeaderNames.Accept , "application/json"}
        }
            };

            if (!string.IsNullOrEmpty(token))

                requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var responseMessage = await client.SendAsync(requestMessage);

            var jsonResponse = await responseMessage.Content.ReadAsStringAsync();

            var response =
              JsonSerializer.Deserialize<T>(jsonResponse,
              new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            return response!;
        }

        public async Task<T> PutData<T>(string endPoint, string jsonData)
        {
            var baseAddress = "http://localhost:5017/api";

            var client = _httpClientFactory.CreateClient();
            var requestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri($"{baseAddress}{endPoint}"),
                Headers = { { HeaderNames.Accept, "application/json" } },
                Content = new StringContent(jsonData, Encoding.UTF8, "application/json")
            };

            var responseMessage = await client.SendAsync(requestMessage);
            var jsonResponse = await responseMessage.Content.ReadAsStringAsync();
            var response = JsonSerializer.Deserialize<T>(jsonResponse,
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            return response;
        }


    }
}
