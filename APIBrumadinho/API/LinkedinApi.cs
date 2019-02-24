using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using APIBrumadinho.Logger;

namespace APIBrumadinho.API
{
    public class LinkedinApi
    {
        static Lazy<LinkedinApi> lazyApi = new Lazy<LinkedinApi>(() => new LinkedinApi(), true);

        public static LinkedinApi Current => lazyApi.Value;

        readonly HttpClient client;

        DebugLogger log;

        LinkedinApi()
        {
            client = new HttpClient();

            client.DefaultRequestHeaders.ConnectionClose = false;
        }

        public void Init(string clientId, string clientSecret, LogLevel level = LogLevel.None)
        {
            log = new DebugLogger(level);
            LinkedinEndPoints.ClientId = clientId;
            LinkedinEndPoints.ClientSecret = clientSecret;

            // client.DefaultRequestHeaders.Add("grant_type", "client_credentials");
            // client.DefaultRequestHeaders.Add("client_id", LinkedinEndPoints.ClientId);
            // client.DefaultRequestHeaders.Add("client_secret", LinkedinEndPoints.ClientSecret);
        }

        public async Task Auth()
        {
            using (var request = new HttpRequestMessage(HttpMethod.Post, LinkedinEndPoints.TOKEN))
            {
                var content = new Dictionary<string, string>
                {
                    { "grant_type", "client_credentials" },
                    { "client_id", LinkedinEndPoints.ClientId },
                    { "client_secret", LinkedinEndPoints.ClientSecret }
                };

                request.Content = new FormUrlEncodedContent(content);

                log?.LogRequest(request);

                using (var response = await client.SendAsync(request).ConfigureAwait(false))
                {
                    log?.LogResponse(response);

                    var json = await response.Content.ReadAsStringAsync();
                }
            }
        }
    }
}
