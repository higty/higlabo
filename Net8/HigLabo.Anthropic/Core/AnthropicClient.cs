using HigLabo.Core;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Anthropic;

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
        if (this.Settings.UseBeta)
        {
            req.Headers.TryAddWithoutValidation("anthropic-beta", "tools-2024-04-04");
        }
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

    public async ValueTask<MessagesObjectResponse> MessagesAsync(MessagesParameter parameter)
    {
        return await this.MessagesAsync(parameter, CancellationToken.None);
    }
    public async ValueTask<MessagesObjectResponse> MessagesAsync(MessagesParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendJsonAsync<MessagesParameter, MessagesObjectResponse>(parameter, cancellationToken);
    }

    public async IAsyncEnumerable<string> MessagesStreamAsync(string message, string modelName)
    {
        var p = new MessagesParameter();
        p.AddUserMessage(message);
        p.Model = modelName;
        p.Stream = true;
        await foreach (var item in this.GetStreamAsync(p, null, CancellationToken.None))
        {
            yield return item;
        }
    }
    public async IAsyncEnumerable<string> MessagesStreamAsync(string message, string modelName, MessagesStreamResult result, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var p = new MessagesParameter();
        p.AddUserMessage(message);
        p.Model = modelName;
        p.Stream = true;
        await foreach (var item in this.GetStreamAsync(p, result, cancellationToken))
        {
            yield return item;
        }
    }
    public async IAsyncEnumerable<string> MessagesStreamAsync(string message, string modelName, int maxTokens, MessagesStreamResult result, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var p = new MessagesParameter();
        p.AddUserMessage(message);
        p.Model = modelName;
        p.Max_Tokens = maxTokens;
        p.Stream = true;
        await foreach (var item in this.GetStreamAsync(p, result, cancellationToken))
        {
            yield return item;
        }
    }
    public async IAsyncEnumerable<string> MessagesStreamAsync(MessagesParameter parameter)
    {
        await foreach (var item in this.GetStreamAsync(parameter, null, CancellationToken.None))
        {
            yield return item;
        }
    }
    public async IAsyncEnumerable<string> MessagesStreamAsync(MessagesParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        parameter.Stream = true;
        await foreach (var item in this.GetStreamAsync(parameter, null, cancellationToken))
        {
            yield return item;
        }
    }
    public async IAsyncEnumerable<string> MessagesStreamAsync(MessagesParameter parameter, MessagesStreamResult result, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        parameter.Stream = true;
        await foreach (var item in this.GetStreamAsync(parameter, result, cancellationToken))
        {
            yield return item;
        }
    }

    public async IAsyncEnumerable<ServerSentEventLine> GetStreamAsync<TParameter>(TParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
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
                await foreach (var line in sseProcessor.Process(cancellationToken))
                {
                    yield return line;
                }
            }
            finally
            {
                stream.Close();
            }
        }
    }
    public async IAsyncEnumerable<string> GetStreamAsync(MessagesParameter parameter, MessagesStreamResult? result, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var eventName = "";
        await foreach (var line in this.GetStreamAsync(parameter, cancellationToken))
        {
            if (line.IsEvent())
            {
                eventName = line.GetText();
            }
            if (line.IsData())
            {
                var text = line.GetText();
                if (string.Equals(text, "[DONE]", StringComparison.OrdinalIgnoreCase)) { continue; }

                if (string.Equals(eventName, "content_block_delta", StringComparison.OrdinalIgnoreCase))
                {
                    var delta = this.JsonConverter.DeserializeObject<MessageContentBlockDelta>(text);
                    if (result != null)
                    {
                        result.DeltaList.Add(delta);
                    }
                    yield return delta.Delta.Text;
                }
                else
                {
                    if (result != null)
                    {
                        if (string.Equals(eventName, "message_start", StringComparison.OrdinalIgnoreCase))
                        {
                            var o = this.JsonConverter.DeserializeObject<MessageStart>(text);
                            result.Message = o.Message;
                        }
                        else if (eventName.StartsWith("message_delta", StringComparison.OrdinalIgnoreCase))
                        {
                            result.MessageDelta = this.JsonConverter.DeserializeObject<MessageDelta>(text);
                        }
                    }
                }
            }

        }
    }
}
