using HigLabo.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Anthropic
{
    public class HttpRequestMessageEventArgs : EventArgs
    {
        public HttpRequestMessage RequestMessage { get; init; }

        public HttpRequestMessageEventArgs(HttpRequestMessage requestMessage)
        {
            this.RequestMessage = requestMessage;
        }
    }
    public partial class AnthropicClient
    {
        public event EventHandler<HttpRequestMessageEventArgs>? PreSendRequest;

        public string ApiUrl
        {
            get
            {
                return "https://api.anthropic.com/v1";
            }
        }
        public HttpClient HttpClient { get; set; } = new();
        public IJsonConverter JsonConverter { get; set; } = new AnthropicJsonConverter();
        public AnthropicSettings Settings { get; init; } = new();

        public AnthropicClient() { }
        public AnthropicClient(string apiKey)
        {
            this.Settings.ApiKey = apiKey;
        }
        public AnthropicClient(AnthropicSettings settings, HttpClient httpClient)
        {
            this.Settings = settings;
            this.HttpClient = httpClient;
        }

        private HttpRequestMessage CreateRequestMessage<TParameter>(TParameter parameter)
                 where TParameter : IRestApiParameter
        {
            var p = parameter as IRestApiParameter;
            var httpMethod = p.HttpMethod.ToUpper() switch
            {
                "GET" => HttpMethod.Get,
                "POST" => HttpMethod.Post,
                "DELETE" => HttpMethod.Delete,
                _ => throw SwitchStatementNotImplementException.Create(p.HttpMethod),
            };
            var apiPath = p.GetApiPath();
            var req = new HttpRequestMessage(httpMethod, this.ApiUrl + apiPath);
            req.Headers.TryAddWithoutValidation("x-api-key", this.Settings.ApiKey);
            req.Headers.TryAddWithoutValidation("anthropic-version", this.Settings.Version);

            return req;
        }
        private async Task<HttpResponseMessage> SendRequestAsync(HttpRequestMessage request, HttpCompletionOption httpCompletionOption, CancellationToken cancellationToken)
        {
            this.PreSendRequest?.Invoke(this, new HttpRequestMessageEventArgs(request));
            var res = await this.HttpClient.SendAsync(request, httpCompletionOption, cancellationToken);
            return res;
        }
        private async Task<TResponse> CreateResponse<TResponse>(object parameter, HttpRequestMessage request, string requestBodyText, HttpResponseMessage response)
                 where TResponse : RestApiResponse, new()
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
                var errorResponse = this.JsonConverter.DeserializeObject<AnthropicServerErrorResponse>(bodyText);
                throw new AnthropicServerException(parameter, request, requestBodyText, response, bodyText, errorResponse.Error);
            }
        }

        public async ValueTask<TResponse> SendJsonAsync<TParameter, TResponse>(TParameter parameter)
            where TParameter : RestApiParameter, IRestApiParameter
            where TResponse : RestApiResponse, new()
        {
            return await this.SendJsonAsync<TParameter, TResponse>(parameter, CancellationToken.None);
        }
        public async ValueTask<TResponse> SendJsonAsync<TParameter, TResponse>(TParameter parameter, CancellationToken cancellationToken)
            where TParameter : RestApiParameter, IRestApiParameter
            where TResponse : RestApiResponse, new()
        {
            var p = parameter as IRestApiParameter;
            var req = this.CreateRequestMessage(parameter);
            var requestBodyText = "";
            if (string.Equals(p.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase) == false)
            {
                requestBodyText = this.JsonConverter.SerializeObject(parameter.GetRequestBody());
                req.Content = new StringContent(requestBodyText, Encoding.UTF8, new MediaTypeHeaderValue("application/json"));
            }
            Debug.WriteLine(requestBodyText);
            var res = await this.SendRequestAsync(req, HttpCompletionOption.ResponseContentRead, cancellationToken);
            return await this.CreateResponse<TResponse>(parameter, req, requestBodyText, res);
        }

        public async IAsyncEnumerable<MessageContentBlockDelta> MessagesStreamAsync(MessagesParameter parameter)
        {
            await foreach (var item in this.GetStreamAsync<MessagesParameter, MessageContentBlockDelta>(parameter, CancellationToken.None))
            {
                yield return item;
            }
        }
        public async IAsyncEnumerable<MessageContentBlockDelta> MessagesStreamAsync(MessagesParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            await foreach (var item in this.GetStreamAsync<MessagesParameter, MessageContentBlockDelta>(parameter, cancellationToken))
            {
                yield return item;
            }
        }
        public async IAsyncEnumerable<MessageContentBlockDelta> MessagesStreamAsync(MessagesParameter parameter, MessagesStreamResult result, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var sseResult = new ServerSentEventResult();
            await foreach (var item in this.GetStreamAsync<MessagesParameter, MessageContentBlockDelta>(parameter, sseResult, cancellationToken))
            {
                result.Process(item);
                yield return item;
            }
            for (int i = 0; i < sseResult.LineList.Count; i++)
            {
                var line = sseResult.LineList[i];
                if (string.Equals(line.GetText(), "message_delta"))
                {
                    if (i + 1 < sseResult.LineList.Count)
                    {
                        var json = sseResult.LineList[i + 1].GetText();
                        var delta = JsonConverter.DeserializeObject<MessageDelta>(json);
                        result.StopReason = delta.Delta.Stop_Reason;
                        result.OutputTokens = delta.Usage.Output_Tokens;
                    }
                    break;
                }
            }
        }

        public async IAsyncEnumerable<TResponse> GetStreamAsync<TParameter, TResponse>(TParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
            where TParameter : RestApiParameter, IRestApiParameter
        {
            await foreach (var item in this.GetStreamAsync<TParameter, TResponse>(parameter, new ServerSentEventResult(), cancellationToken))
            {
                yield return item;
            }
        }
        public async IAsyncEnumerable<TResponse> GetStreamAsync<TParameter, TResponse>(TParameter parameter, ServerSentEventResult serverSentEventResult, [EnumeratorCancellation] CancellationToken cancellationToken)
            where TParameter : RestApiParameter, IRestApiParameter
        {
            var p = parameter as IRestApiParameter;
            var req = this.CreateRequestMessage(parameter);
            req.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("text/event-stream"));
            var requestBodyText = "";
            if (string.Equals(p.HttpMethod, "POST", StringComparison.OrdinalIgnoreCase))
            {
                requestBodyText = JsonConverter.SerializeObject(parameter.GetRequestBody());
            }
            req.Content = new StringContent(requestBodyText, Encoding.UTF8, new MediaTypeHeaderValue("application/json"));

            Debug.WriteLine(requestBodyText);
            var res = await this.SendRequestAsync(req, HttpCompletionOption.ResponseHeadersRead, cancellationToken);

            if (res.IsSuccessStatusCode == false)
            {
                var responseBodyText = await res.Content.ReadAsStringAsync();
                var errorRes = this.JsonConverter.DeserializeObject<AnthropicServerErrorResponse>(responseBodyText);
                throw new AnthropicServerException(parameter, req, requestBodyText, res, responseBodyText, errorRes.Error);
            }

            using (var stream = await res.Content.ReadAsStreamAsync())
            {
                try
                {
                    var sseProcessor = new ServerSentEventProcessor(stream);
                    var isStartDelta = false;
                    await foreach (var line in sseProcessor.Process(cancellationToken))
                    {
                        serverSentEventResult.AddLine(line);
                        var v = line.GetText();
                        if (line.IsEvent())
                        {
                            if (v == "content_block_delta")
                            {
                                isStartDelta = true;
                                continue;
                            }
                            if (v == "content_block_stop")
                            {
                                isStartDelta = false;
                                continue;
                            }
                        }
                        if (isStartDelta && line.IsData())
                        {
                            yield return this.JsonConverter.DeserializeObject<TResponse>(v);
                        }
                    }
                }
                finally
                {
                    stream.Close();
                }
            }
        }
    }
}
