using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace WitAi.DotNet.Api.Extensions
{
    public static class HttpClientExtensions
    {
        public static async Task<HttpResponseMessage> PostAsJsonAsync<T>(this HttpClient httpClient, string url, T data)
        {
            HttpResponseMessage response = null;
            string dataJson = JsonConvert.SerializeObject(data);

            using (StringContent content = new StringContent(dataJson))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await httpClient.PostAsync(url, content);
            }

            return response;
        }

        public static async Task<HttpResponseMessage> PutAsJsonAsync<T>(this HttpClient httpClient, string url, T data)
        {
            HttpResponseMessage response = null;
            string dataJson = JsonConvert.SerializeObject(data);

            using (StringContent content = new StringContent(dataJson))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await httpClient.PutAsync(url, content);
            }

            return response;
        }

        public static async Task<T> ReadAsAsync<T>(this HttpContent content)
        {
            string responseJson = await content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseJson);
        }
    }
}