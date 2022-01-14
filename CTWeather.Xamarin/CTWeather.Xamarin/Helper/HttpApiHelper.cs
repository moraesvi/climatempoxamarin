using Polly;
using Polly.Retry;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TocaTudoPlayer.Xamarim
{
    public class HttpApiHelper
    {
        private static readonly int _maxRetryAttempts = 3;
        private static readonly TimeSpan _pauseBetweenFailures = TimeSpan.FromSeconds(2);
        private static readonly AsyncRetryPolicy _retryPolicy = Policy.Handle<HttpRequestException>().WaitAndRetryAsync(_maxRetryAttempts, i => _pauseBetweenFailures);
        public static async Task<T> Get<T>(string url) where T : class
        {
            return await _retryPolicy.ExecuteAsync(async () =>
            {
                using (HttpClient http = new HttpClient())
                {
                    T result = null;
                    HttpResponseMessage httpResp = await http.GetAsync(url);

                    if (httpResp.IsSuccessStatusCode)
                    {
                        Stream json = await httpResp.Content.ReadAsStreamAsync();
                        result = await JsonSerializer.DeserializeAsync<T>(json, new JsonSerializerOptions()
                        {
                            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                            PropertyNameCaseInsensitive = true
                        });
                    }

                    return result;
                }
            });
        }
        public static async Task<T> Post<T>(string url, object objRequest) where T : class
        {
            return await _retryPolicy.ExecuteAsync(async () =>
            {
                using (HttpClient http = new HttpClient())
                {
                    T result = null;

                    http.DefaultRequestHeaders.Accept.Clear();
                    http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    string jsonRequest = JsonSerializer.Serialize(objRequest);
                    StringContent requestContent = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                    HttpResponseMessage httpResp = await http.PostAsync(url, requestContent);

                    if (httpResp.IsSuccessStatusCode)
                    {
                        Stream json = await httpResp.Content.ReadAsStreamAsync();
                        result = await JsonSerializer.DeserializeAsync<T>(json, new JsonSerializerOptions()
                        {
                            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                            PropertyNameCaseInsensitive = true
                        });
                    }

                    return result;
                }
            });
        }
    }
}
