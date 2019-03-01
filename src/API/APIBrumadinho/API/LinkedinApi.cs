using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using APIBrumadinho.Helpers;
using APIBrumadinho.Logger;
using Newtonsoft.Json.Linq;

namespace APIBrumadinho.API
{
    public class LinkedinApi
    {
        static readonly Lazy<LinkedinApi> lazyApi = new Lazy<LinkedinApi>(() => new LinkedinApi(), true);

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
        }

        public string AuthUrl() => string.Format(
            "https://www.linkedin.com/oauth/v2/authorization?response_type=code&client_id={0}&redirect_uri={1}&state=DCEeFWf45A53sdfKef424scope=r_basicprofile",
            LinkedinEndPoints.ClientId,
            LinkedinEndPoints.REDIRECTURL);

        public async Task<IResult<bool>> AuthAsync()
        {
            try
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

                        if (response.IsSuccessStatusCode)
                            return Result.Success(await response.Content.ReadAsStringAsync(), true);

                        return Result.Fail<bool>(await response.Content.ReadAsStringAsync());
                    }
                }
            }
            catch (Exception ex)
            {
                log?.LogException(ex);
                return Result.Fail<bool>(ex);
            }
        }

        public void GetCode(string url)
        {
            var code = url.Split('&')[0];
            code = code.Split('=')[1];
            LinkedinEndPoints.AuthCode = code;
        }

        public async Task<IResult<bool>> GetTokenAsync()
        {
            try
            {
                if (LinkedinEndPoints.REDIRECTURL.IsNullOrEmpty() &&
                    LinkedinEndPoints.ClientSecret.IsNullOrEmpty() &&
                    LinkedinEndPoints.ClientId.IsNullOrEmpty())
                {
                    throw new ArgumentNullException("Please run the Init method first!");
                }

                using (var request = new HttpRequestMessage(HttpMethod.Post, LinkedinEndPoints.TOKEN))
                {
                    var content = new Dictionary<string, string>
                    {
                        { "grant_type", "authorization_code" },
                        { "code", LinkedinEndPoints.AuthCode },
                        { "redirect_uri", LinkedinEndPoints.REDIRECTURL },
                        { "client_id", LinkedinEndPoints.ClientId },
                        { "client_secret", LinkedinEndPoints.ClientSecret }
                    };

                    request.Content = new FormUrlEncodedContent(content);

                    using (var response = await client.SendAsync(request).ConfigureAwait(false))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var tokenString = JObject.Parse(await response.Content.ReadAsStringAsync());

                            LinkedinEndPoints.AccessToken = tokenString["access_token"].ToString();
                            LinkedinEndPoints.ExpiresIn = tokenString["expires_in"].ToString();
                            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {LinkedinEndPoints.AccessToken}");

                            return Result.Success(true);
                        }
                        return Result.Fail<bool>(await response.Content.ReadAsStringAsync());
                    }
                }
            }
            catch (Exception ex)
            {
                log?.LogException(ex);
                return Result.Fail<bool>(ex);
            }
        }

        public async Task<IResult<string>> GetPersonAsync(string args = null)
        {
            string uri;
            if (args.IsNullOrEmpty())
                uri = "https://api.linkedin.com/v1/people/~?format=json";
            else
                uri = string.Format("https://api.linkedin.com/v1/people/~:({0})?format=json", args);

            try
            {
                using (var response = await client.GetAsync(uri).ConfigureAwait(false))
                {
                    if (response.IsSuccessStatusCode)
                        return Result.Success(await response.Content.ReadAsStringAsync());

                    return Result.Fail<string>(await response.Content.ReadAsStringAsync());
                }
            }
            catch (Exception ex)
            {
                log?.LogException(ex);
                return Result.Fail<string>(ex);
            }
        }
    }
}
