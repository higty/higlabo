using HigLabo.Core;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace HigLabo.OpenAI
{
    public interface IRestApiParameter
    {
        string GetApiPath();
        string HttpMethod { get; }
    }
    public interface IJsonConverter
    {
        string SerializeObject(object obj);
        T DeserializeObject<T>(String json);
    }
    public partial class OpenAIClient
    {
        public string ApiUrl { get; set; } = "https://api.openai.com/v1";
        public HttpClient HttpClient { get; set; } = new();
        public string ApiKey { get; set; } = "";
        public string Organization { get; set; } = "";
        public IJsonConverter JsonConverter { get; set; } = new OpenAIJsonConverter();

        public OpenAIClient()
        {
        }
        public OpenAIClient(string apiKey)
        {
            this.SetProperty(null, null, apiKey);
        }
        public OpenAIClient(HttpClient httpClient, IJsonConverter jsonConverter, string apiKey)
        {
            this.SetProperty(null, jsonConverter, apiKey);
        }

        private void SetProperty(HttpClient? httpClient, IJsonConverter? jsonConverter, string apiKey)
        {
            if (httpClient == null)
            {
                this.HttpClient.Timeout = TimeSpan.FromMinutes(5);
            }
            else
            {
                this.HttpClient = httpClient;
            }
            if (jsonConverter != null)
            {
                this.JsonConverter = jsonConverter;
            }
            this.ApiKey = apiKey;

        }
        private static bool IsErrorResponse(byte[] buffer)
        {
            var bb = buffer;
            if (bb.Length < 8) { return false; }
            var index = 0;
            if (bb[index++] == 123 &&
                bb[index++] == 34 &&
                bb[index++] == 101 &&
                bb[index++] == 114 &&
                bb[index++] == 114 &&
                bb[index++] == 111 &&
                bb[index++] == 114)
            { return true; }
            return false;
        }
        public static string RemoveIfStartWith(string text, string search)
        {
            var pos = text.IndexOf(search, StringComparison.Ordinal);
            return pos != 0 ? text : text.Substring(search.Length);
        }
        private HttpRequestMessage CreateRequestMessage<TParameter>(TParameter parameter)
                 where TParameter : IRestApiParameter
        {
            var p = parameter as IRestApiParameter;
            var req = p.HttpMethod.ToUpper() switch
            {
                "GET" => new HttpRequestMessage(HttpMethod.Get, this.ApiUrl + p.GetApiPath()),
                "POST" => new HttpRequestMessage(HttpMethod.Post, this.ApiUrl + p.GetApiPath()),
                _ => throw SwitchStatementNotImplementException.Create(p.HttpMethod),
            };
            req.Headers.Authorization = new AuthenticationHeaderValue("Bearer", this.ApiKey);

            return req;
        }
        private async Task<TResponse> CreateResponse<TResponse>(object parameter, HttpRequestMessage request, string requestBodyText, HttpResponseMessage response)
                 where TResponse : RestApiResponse
        {
            var res = response;
            var bodyText = await res.Content.ReadAsStringAsync();
            if (res.IsSuccessStatusCode)
            {
                var o = this.JsonConverter.DeserializeObject<TResponse>(bodyText);
                o.SetProperty(parameter, requestBodyText, request, res, bodyText);
                return o;
            }
            else
            {
                var errorResponse = this.JsonConverter.DeserializeObject<OpenAIServerErrorResponse>(bodyText);
                throw new OpenAIServerException(bodyText, errorResponse.Error);
            }
        }

        public async ValueTask<TResponse> SendJsonAsync<TParameter, TResponse>(TParameter parameter)
            where TParameter : IRestApiParameter
            where TResponse : RestApiResponse
        {
            return await this.SendJsonAsync<TParameter, TResponse>(parameter, CancellationToken.None);
        }
        public async ValueTask<TResponse> SendJsonAsync<TParameter, TResponse>(TParameter parameter, CancellationToken cancellationToken)
            where TParameter: IRestApiParameter
            where TResponse: RestApiResponse
        {
            var p = parameter as IRestApiParameter;
            var req = this.CreateRequestMessage(parameter);
            var requestBodyText = "";
            if (string.Equals(p.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase) == false && requestBodyText.IsNullOrEmpty() == false)
            {
                requestBodyText = JsonConverter.SerializeObject(parameter);
                req.Content = new StringContent(requestBodyText, Encoding.UTF8, new MediaTypeHeaderValue("application/json"));
            }
            var res = await this.HttpClient.SendAsync(req);
            return await this.CreateResponse<TResponse>(parameter, req, requestBodyText, res);
        }
        public async IAsyncEnumerable<ChatCompletionChunk> GetStreamAsync<TParameter>(TParameter parameter)
            where TParameter : IRestApiParameter
        {
            await foreach (var item in this.GetStreamAsync(parameter, CancellationToken.None))
            {
                yield return item;
            }
        }
        public async IAsyncEnumerable<ChatCompletionChunk> GetStreamAsync<TParameter>(TParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
            where TParameter : IRestApiParameter
        {
            var p = parameter as IRestApiParameter;
            var req= this.CreateRequestMessage(parameter);
            req.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("text/event-stream"));
            var requestBodyText = "";
            if (string.Equals(p.HttpMethod, "POST", StringComparison.OrdinalIgnoreCase))
            {
                requestBodyText = JsonConverter.SerializeObject(parameter);
            }

            var res = await this.HttpClient.SendAsync(req, HttpCompletionOption.ResponseHeadersRead, cancellationToken);

            var sseResponse = new ServerSentEventResponse();
            var previousLineList = new List<ServerSentEventLine>();

            try
            {
                using (var stream = await res.Content.ReadAsStreamAsync())
                {
                    var loopIndex = 0;
                    while (true)
                    {
                        sseResponse.Clear();
                        var readCount = await stream.ReadAsync(sseResponse.Buffer, cancellationToken);
                        sseResponse.BufferLength = readCount;

                        Debug.WriteLine($"■Read={readCount} {Encoding.UTF8.GetString(sseResponse.Buffer)}");
                        if (readCount == 0) { break; }

                        if (IsErrorResponse(sseResponse.Buffer))
                        {
                            var json = Encoding.UTF8.GetString(sseResponse.Buffer);
                            var eRes = this.JsonConverter.DeserializeObject<OpenAIServerErrorResponse>(json);
                            throw new OpenAIServerException(json, eRes.Error);
                        }

                        foreach (var line in sseResponse.GetLines(previousLineList))
                        {
                            if (line.IsEmpty()) { continue; }
                            if (line.IsDone()) { yield break; }
                            if (line.Complete == false)
                            {
                                previousLineList.Add(line);
                                continue;
                            }
                            if (line.IsData())
                            {
                                var text = Encoding.UTF8.GetString(line.GetValue());
                                yield return this.JsonConverter.DeserializeObject<ChatCompletionChunk>(text);
                            }
                        }
                        loopIndex++;
                    }

                }
            }
            finally
            {
            }
        }
        public async ValueTask<TResponse> SendFormDataAsync<TParameter, TResponse>(TParameter parameter, CancellationToken cancellationToken)
            where TParameter : IRestApiParameter, IFormDataParameter
            where TResponse : RestApiResponse
        {
            var p = parameter as IRestApiParameter;
            var req = this.CreateRequestMessage(parameter);

            var requestContent = new MultipartFormDataContent();
            var fileParameter = p as IFileParameter;
            if (fileParameter != null)
            {
                var stream = fileParameter.GetFileStream();
                stream.Position = 0;
                var fileContent = new StreamContent(stream);
                //fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("audio/wav");
                requestContent.Add(fileContent, fileParameter.ParameterName, "MyFile.mp3");
            }
            var d = parameter.CreateFormDataParameter();
            foreach (var key in d.Keys)
            {
                requestContent.Add(new StringContent(d[key]), key);
            }
            req.Content = requestContent;

            var requestBodyText = JsonConverter.SerializeObject(d);

            var res = await this.HttpClient.SendAsync(req);
            var bodyText = await res.Content.ReadAsStringAsync();
            var o = this.JsonConverter.DeserializeObject<TResponse>(bodyText);
            o.SetProperty(parameter, requestBodyText, req, res, bodyText);

            return o;
        }

        public async IAsyncEnumerable<ChatCompletionChunk> ChatCompletionsStreamAsync(string message, string model, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            await foreach (var item in this.ChatCompletionsStreamAsync(new ChatMessage(ChatMessageRole.user, message), model, cancellationToken))
            {
                yield return item;
            }
        }
        public async IAsyncEnumerable<ChatCompletionChunk> ChatCompletionsStreamAsync(ChatMessage message, string model, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var p = new ChatCompletionsParameter();
            p.Messages.Add(message);
            p.Model = model;
            p.Stream = true;
            await foreach (var item in this.GetStreamAsync(p, cancellationToken))
            {
                yield return item;
            }
        }
    }
}
