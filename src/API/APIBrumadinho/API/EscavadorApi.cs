using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using APIBrumadinho.Helpers;
using APIBrumadinho.Logger;
using APIBrumadinho.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace APIBrumadinho.API
{
    public class EscavadorApi
    {
        static readonly Lazy<EscavadorApi> lazyApi = new Lazy<EscavadorApi>(() => new EscavadorApi(), true);

        public static EscavadorApi Current => lazyApi.Value;

        HttpClient client;

        DebugLogger log;
        HttpRequestProcessor processor;

        EscavadorApi()
        {
            client = new HttpClient();

            client.DefaultRequestHeaders.ConnectionClose = false;
        }

        public void Init(string username, string password, LogLevel level = LogLevel.None)
        {
            EscavadorEndPoints.UserName = username;
            EscavadorEndPoints.Password = password;
            log = new DebugLogger(level);
            processor = new HttpRequestProcessor(log, client);
        }

        public async Task<IResult<bool>> AuthAsync()
        {
            try
            {
                using (var request = new HttpRequestMessage(HttpMethod.Post, EscavadorEndPoints.TOKEN))
                {
                    var content = new Dictionary<string, string>
                    {
                        { "username", EscavadorEndPoints.UserName },
                        { "password", EscavadorEndPoints.Password }
                    };

                    request.Content = new FormUrlEncodedContent(content);

                    using (var response = await processor.SendAsync(request).ConfigureAwait(false))
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var json = JObject.Parse(result);
                        if (response.IsSuccessStatusCode)
                        {
                            EscavadorEndPoints.AccessToken = json["access_token"]?.ToString();
                            EscavadorEndPoints.RefreshToken = json["refresh_token"]?.ToString();
                            log.LogInfo("Get the AccessToken and RefreshToke");
                            return Result.Success(true);
                        }

                        return Result.Fail<bool>("Error");
                    }
                }
            }
            catch (Exception ex)
            {
                log.LogException(ex);
                return Result.Fail<bool>(ex);
            }
        }

        public async Task<IResult<string>> GetCreditsAsync()
        {
            try
            {
                using (var request = new HttpRequestMessage(HttpMethod.Get, EscavadorEndPoints.CREDITS))
                {
                    var json = await processor.SendAndGetJsonAuthAsync(request)
                                              .ConfigureAwait(false);

                    var credit = JObject.Parse(json);

                    var value = credit["quantidade_creditos"].ToString();

                    return Result.Success(value);
                }
            }
            catch (Exception ex)
            {
                log.LogException(ex);
                return Result.Fail(ex, "Shit's happens...");
            }
        }

        // TODO pegar json da resposta e criar modelo
        public async Task SearchAsync(Enumerators.EscavadorEntity entity, string term, int? page = null)
        {
            var url = $"{EscavadorEndPoints.SEARCH}?qo{entity.Entity2String()}&q={term}";

            url += (page is null) ? string.Empty : $"&page={page}";

            using (var request = new HttpRequestMessage(HttpMethod.Get, url))
            using (var response = await processor.SendAuthAsync(request).ConfigureAwait(false))
            {
                var result = await response.Content.ReadAsStringAsync();
            }
        }

        public async Task<IResult<PeopleResult>> SearchPeopleAsync(int id)
        {
            try
            {
                var url = string.Format(EscavadorEndPoints.SEARCHPEOPLE, id);
                using (var request = new HttpRequestMessage(HttpMethod.Get, url))
                using (var response = await processor.SendAuthAsync(request).ConfigureAwait(false))
                {
                    if (!response.IsSuccessStatusCode)
                        return Result.Fail<PeopleResult>("Can't get the people", default);

                    var json = await response.Content.ReadAsStringAsync();

                    return Result.Success(JsonConvert.DeserializeObject<PeopleResult>(json));
                }
            }
            catch (Exception ex)
            {
                log.LogException(ex);
                return Result.Fail<PeopleResult>(ex);
            }
        }

        public async Task SearchInstitutionAsync(int id)
        {
            try
            {
                var url = string.Format(EscavadorEndPoints.INSTITUTION, id);

                using (var request = new HttpRequestMessage(HttpMethod.Get, url))
                using (var response = await processor.SendAuthAsync(request).ConfigureAwait(false))
                {
                    var json = await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                log.LogException(ex);
                throw;
            }
        }

        // TODO artigo URL  url += $"&f[c][]={}";
    }
}
