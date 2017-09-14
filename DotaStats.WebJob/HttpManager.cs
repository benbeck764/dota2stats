using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DotaStats.WebJob
{
    public static class HttpManager
    {
        static HttpManager()
        {

        }

        public static async Task<HttpResponseMessage> SendRequest(HttpRequestMessage request)
        {
            var client = InitHttpClient();
            return await client.SendAsync(request).ConfigureAwait(false);
        }

        public static async Task<string> GetResult(HttpResponseMessage response)
        {
            return await response.Content.ReadAsStringAsync();
        }

        private static HttpClient InitHttpClient()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //var accessToken = GetAccessToken();
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            return client;
        }

        //private static string GetAccessToken()
        //{
        //    var authResult = ServicePrincipal.GetS2AccessToken(ResourceIdToUse);
        //    var token = authResult.Result.AccessToken;
        //    return token;
        //}

        public static HttpRequestMessage InitHttpRequest(HttpMethod verb, object objDto, string requestPath)
        {
            var httpMessage = new HttpRequestMessage();
            if (objDto != null)
            {
                httpMessage.Content = new ByteArrayContent(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(objDto)));
                httpMessage.Content.Headers.Add("Content-Type", "application/json");
            }
            httpMessage.Method = verb;
            httpMessage.RequestUri = new Uri(requestPath);
            return httpMessage;
        }
    }
}
