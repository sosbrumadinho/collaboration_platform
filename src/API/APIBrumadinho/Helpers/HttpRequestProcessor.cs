using System;
using System.Net.Http;
using System.Threading.Tasks;
using APIBrumadinho.Logger;

namespace APIBrumadinho.Helpers
{
    internal class HttpRequestProcessor
    {
        readonly HttpClient client;
        readonly DebugLogger log;

        internal HttpRequestProcessor(DebugLogger debug, HttpClient http)
        {
            log = debug;
            client = http;
        }

        public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
        {
            log.LogRequest(request);

            var response = await client.SendAsync(request).ConfigureAwait(false);
            log.LogResponse(response);
            return response;
        }

        public Task<HttpResponseMessage> SendAuthAsync(HttpRequestMessage request)
        {
            request.Headers.Add("Authorization", $"Bearer {EscavadorEndPoints.AccessToken}");
            return SendAsync(request);
        }

        public async Task<HttpResponseMessage> GetAsync(Uri uri)
        {
            log.LogRequest(uri);
            var response = await client.GetAsync(uri).ConfigureAwait(false);
            log.LogResponse(response);
            return response;
        }

        public async Task<string> SendAndGetJsonAsync(HttpRequestMessage request)
        {
            log.LogRequest(request);

            var response = await client.SendAsync(request).ConfigureAwait(false);
            log.LogResponse(response);

            return await response.Content.ReadAsStringAsync();
        }

        public Task<string> SendAndGetJsonAuthAsync(HttpRequestMessage request)
        {
            request.Headers.Add("Authorization", $"Bearer {EscavadorEndPoints.AccessToken}");
            return SendAndGetJsonAsync(request);
        }

        public async Task<string> GetJsonAsync(Uri uri)
        {
            log.LogRequest(uri);

            var response = await client.GetAsync(uri).ConfigureAwait(false);
            log.LogResponse(response);

            return await response.Content.ReadAsStringAsync();
        }
    }
}
