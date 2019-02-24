using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace APIBrumadinho.Logger
{
    public class DebugLogger
    {
        readonly LogLevel logLevel;

        public DebugLogger(LogLevel log) =>
            logLevel = log;

        public void LogRequest(HttpRequestMessage request)
        {
            if (logLevel < LogLevel.Request)
                return;
            Write($"\n Request: {request.Method} {request.RequestUri}");
            WriteReaders(request.Headers);
            WriteProperties(request.Properties);
            if (request.Method == HttpMethod.Post)
                WriteRequestContent(request.Content);
        }

        public void LogRequest(Uri uri)
        {
            if (logLevel < LogLevel.Request)
                return;
            Write($"\n Request: {uri}");
        }

        public void LogInfo(string info)
        {
            if (logLevel < LogLevel.Info)
                return;
            Write($"\n info: \n {info}");
        }

        public void LogException(Exception ex, [CallerMemberName] string caller = null)
        {
            if (logLevel < LogLevel.Exceptions)
                return;

            Console.WriteLine($"\n Throw Exception in {caller}\n");
            Console.WriteLine($"\n Exception: {ex}");
            Console.WriteLine($"\n StackTrace: {ex.StackTrace}");
            Console.WriteLine($"\n Message: {ex.Message}");
        }

        public void LogResponse(HttpResponseMessage response)
        {
            if (logLevel < LogLevel.Response)
                return;

            Write($"\n Response: {response.RequestMessage.Method} {response.RequestMessage.RequestUri} [{response.StatusCode}]");
            WriteContent(response.Content, Formatting.Indented, 0);
        }

        #region [ Internals ]

        void WriteContent(HttpContent content, Formatting formatting, int maxLength = 0)
        {
            Write("\n Content:");
            var rawTask = content.ReadAsStringAsync();
            rawTask.ContinueWith(rawT =>
            {
                var raw = rawT.Result;
                if (formatting == Formatting.Indented)
                    raw = FormatJson(raw);
                raw = raw.Contains("<!DOCTYPE html>") ? "got html content!" : raw;

                if ((raw.Length > maxLength) & (maxLength != 0))
                    raw = raw.Substring(0, maxLength);
                Write(raw);
            });
        }

        public string FormatJson(string raw) =>
            JsonConvert.SerializeObject(JsonConvert.DeserializeObject(raw), Formatting.Indented);

        void WriteRequestContent(HttpContent content, int maxLenght = 0)
        {
            Write("\n Content:");
            var rawTask = content.ReadAsStringAsync();
            rawTask.ContinueWith(rawT =>
            {
                var raw = rawT.Result;
                if ((raw.Length > maxLenght) & (maxLenght != 0))
                    raw = raw.Substring(0, maxLenght);

                Write(WebUtility.UrlDecode(raw));
            });
        }

        void WriteProperties(IDictionary<string, object> properties)
        {
            if (properties is null || properties.Count == 0)
                return;
            Write($"\n Properties:\n {JsonConvert.SerializeObject(properties, Formatting.Indented)}");
        }

        void WriteReaders(HttpRequestHeaders headers)
        {
            if (headers is null)
                return;

            if (!headers.Any())
                return;
            Write("\n Hearders:");
            headers.ForEach(x => Write($"{x.Key} :{JsonConvert.SerializeObject(x.Value)} "));
        }

        void Write(string message) =>
            Console.WriteLine($"\n {DateTime.Now}: \t {message}");

        #endregion
    }
}
