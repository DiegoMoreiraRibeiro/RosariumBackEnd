using RosariumBackEnd.Service.Interfaces;
using System.Text.Json;

namespace RosariumBackEnd.Service.Utils
{
    public class CustomHttpUtils : ICustomHttpUtils
    {
        private readonly HttpClient _httpClient;
        public string _url { get; set; }

        public CustomHttpUtils(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _url = string.Empty;
        }

        public void SetUrl(string url) { this._url = url; }

        public async Task<T> GetAsync<T>(string authToken = null)
        {
            try
            {

                var request = await MakeRequestAsync(HttpMethod.Get, null, authToken);
                return JsonSerializer.Deserialize<T>(request ?? "", new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public async Task<string> PostAsync(object requestBody, string authToken = null)
        {
            try
            {
                return await MakeRequestAsync(HttpMethod.Post, requestBody, authToken);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<string> PutAsync(object requestBody, string authToken = null)
        {
            try
            {
                return await MakeRequestAsync(HttpMethod.Put, requestBody, authToken);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<string> DeleteAsync(string authToken = null)
        {
            try
            {
                return await MakeRequestAsync(HttpMethod.Delete, null, authToken);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        private async Task<string> MakeRequestAsync(HttpMethod method, object requestBody, string authToken)
        {
            try
            {
                HttpRequestMessage requestMessage = new HttpRequestMessage(method, _url);

                // Adicionar token de autenticação, se fornecido
                if (!string.IsNullOrEmpty(authToken))
                {
                    requestMessage.Headers.Add("Authorization", $"Bearer {authToken}");
                }

                // Adicionar corpo da requisição, se fornecido
                if (requestBody != null)
                {
                    string jsonRequestBody = JsonSerializer.Serialize(requestBody);
                    requestMessage.Content = new StringContent(jsonRequestBody, System.Text.Encoding.UTF8, "application/json");
                }

                HttpResponseMessage response = await _httpClient.SendAsync(requestMessage);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    throw new HttpRequestException($"Erro na requisição HTTP. Código de status: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

    }
}