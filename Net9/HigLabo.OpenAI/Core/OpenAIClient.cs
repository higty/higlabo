using HigLabo.Core;
using Newtonsoft.Json.Linq;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Data.Common;
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
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace HigLabo.OpenAI;

public class HttpRequestMessageEventArgs : EventArgs
{
    public HttpRequestMessage RequestMessage { get; init; }

    public HttpRequestMessageEventArgs(HttpRequestMessage requestMessage)
    {
        this.RequestMessage = requestMessage;
    }
}
public partial class OpenAIClient
{
    public static IJsonConverter JsonConverter { get; set; } = new OpenAIJsonConverter();

    public event EventHandler<HttpRequestMessageEventArgs>? PreSendRequest;

    public ServiceProvider ServiceProvider { get; init; } = ServiceProvider.OpenAI;
    public string ApiUrl
    {
        get
        {
            switch (this.ServiceProvider)
            {
                case ServiceProvider.OpenAI: return "https://api.openai.com/v1";
                case ServiceProvider.Azure: return $"{this.AzureSettings!.EndpointUrl}/openai";
                case ServiceProvider.Groq: return "https://api.groq.com/openai/v1";
                case ServiceProvider.DeepSeek: return "https://api.deepseek.com/v1";
                default: throw SwitchStatementNotImplementException.Create(this.ServiceProvider);
            }
        }
    }
    public HttpClient HttpClient { get; set; } = new();

    public OpenAISettings OpenAISettings { get; init; } = new();
    public AzureSettings AzureSettings { get; init; } = new();
    public GroqSettings GroqSettings { get; init; } = new();
    public DeepSeekSettings DeepSeekSettings { get; init; } = new();

    public OpenAIClient()
    {
    }
    public OpenAIClient(string apiKey)
    {
        this.ServiceProvider = ServiceProvider.OpenAI;
        this.OpenAISettings.ApiKey = apiKey;
        this.HttpClient.Timeout = TimeSpan.FromMinutes(5);
    }
    public OpenAIClient(OpenAISettings settings)
    {
        this.ServiceProvider = ServiceProvider.OpenAI;
        this.OpenAISettings = settings;
        this.HttpClient.Timeout = TimeSpan.FromMinutes(5);
    }
    public OpenAIClient(OpenAISettings settings, HttpClient httpClient)
    {
        this.ServiceProvider = ServiceProvider.OpenAI;
        this.OpenAISettings = settings;
        this.HttpClient = httpClient;
    }
    public OpenAIClient(AzureSettings setting)
    {
        this.ServiceProvider = ServiceProvider.Azure;
        this.AzureSettings = setting;
        this.HttpClient.Timeout = TimeSpan.FromMinutes(5);
    }
    public OpenAIClient(AzureSettings setting, HttpClient httpClient)
    {
        this.ServiceProvider = ServiceProvider.Azure;
        this.AzureSettings = setting;
        this.HttpClient = httpClient;
    }
    public OpenAIClient(GroqSettings settings)
    {
        this.ServiceProvider = ServiceProvider.Groq;
        this.GroqSettings = settings;
        this.HttpClient.Timeout = TimeSpan.FromMinutes(5);
    }
    public OpenAIClient(DeepSeekSettings settings)
    {
        this.ServiceProvider = ServiceProvider.DeepSeek;
        this.DeepSeekSettings = settings;
        this.HttpClient.Timeout = TimeSpan.FromMinutes(5);
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
        var q = p as IQueryParameterProperty;
        if (q != null)
        {
            var queryString = q.QueryParameter.GetQueryString();
            if (queryString.IsNullOrEmpty() == false)
            {
                apiPath += "?" + queryString;
            }
        }
        if (this.ServiceProvider == ServiceProvider.Azure)
        {
            if (apiPath.Contains("?"))
            {
                apiPath += "&";
            }
            else
            {
                apiPath += "?";
            }
            if (this.AzureSettings.ApiVersion.HasValue())
            {
                apiPath += $"api-version={this.AzureSettings.ApiVersion}";
            }
        }

        var requestUrl = this.ApiUrl + apiPath;
        if (this.ServiceProvider == ServiceProvider.Azure)
        {
            if (p is IAssistantApiParameter)
            {
                requestUrl = $"{this.ApiUrl}{apiPath}";
            }
            else
            {
                if (this.AzureSettings.DeploymentInQueryString == true)
                {
                    requestUrl = $"{this.ApiUrl}{apiPath}&deployment=" + this.AzureSettings.DeploymentId;
                }
                else
                {
                    requestUrl = $"{this.ApiUrl}/deployments/{this.AzureSettings.DeploymentId}{apiPath}";
                }
            }
        }
        var req = new HttpRequestMessage(httpMethod, requestUrl);
        switch (this.ServiceProvider)
        {
            case ServiceProvider.OpenAI:
                req.Headers.Authorization = new AuthenticationHeaderValue("Bearer", this.OpenAISettings.ApiKey);
                break;
            case ServiceProvider.Azure:
                req.Headers.TryAddWithoutValidation("API-Key", this.AzureSettings.ApiKey);
                break;
            case ServiceProvider.Groq:
                req.Headers.Authorization = new AuthenticationHeaderValue("Bearer", this.GroqSettings.ApiKey);
                break;
            case ServiceProvider.DeepSeek:
                req.Headers.Authorization = new AuthenticationHeaderValue("Bearer", this.DeepSeekSettings.ApiKey);
                break;
            default:
                break;
        }
        if (this.OpenAISettings.Organization.IsNullOrEmpty() == false)
        {
            req.Headers.TryAddWithoutValidation("OpenAI-Organization", this.OpenAISettings.Organization);
        }

        if (this.OpenAISettings.OpenAIBeta.HasValue())
        {
            req.Headers.TryAddWithoutValidation("OpenAI-Beta", this.OpenAISettings.OpenAIBeta);
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
            if (parameter is FileContentGetParameter ||
                parameter is AudioSpeechParameter)
            {
					var o = new TResponse();
                await o.SetProperty(parameter, requestBodyText, request, response);
                return o;
				}
            else
            {
                var o = OpenAIClient.JsonConverter.DeserializeObject<TResponse>(bodyText);
					o.SetProperty(parameter, requestBodyText, request, res, bodyText);
					return o;
				}
        }
        else
        {
            var errorResponse = OpenAIClient.JsonConverter.DeserializeObject<OpenAIServerErrorResponse>(bodyText);
            throw new OpenAIServerException(parameter, request, requestBodyText, response, bodyText, errorResponse.Error);
        }
    }

    public async ValueTask<TResponse> SendJsonAsync<TParameter, TResponse>(TParameter parameter)
        where TParameter : RestApiParameter, IRestApiParameter
        where TResponse : RestApiResponse, new()
    {
        return await this.SendJsonAsync<TParameter, TResponse>(parameter, CancellationToken.None);
    }
    public async ValueTask<TResponse> SendJsonAsync<TParameter, TResponse>(TParameter parameter, CancellationToken cancellationToken)
        where TParameter: RestApiParameter, IRestApiParameter
        where TResponse: RestApiResponse, new()
    {
        var p = parameter as IRestApiParameter;
        var req = this.CreateRequestMessage(parameter);
        var requestBodyText = "";
        if (string.Equals(p.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase) == false)
        {
            requestBodyText = OpenAIClient.JsonConverter.SerializeObject(parameter.GetRequestBody());
            req.Content = new StringContent(requestBodyText, Encoding.UTF8, new MediaTypeHeaderValue("application/json"));
        }
        Debug.WriteLine(requestBodyText);
        var res = await this.SendRequestAsync(req, HttpCompletionOption.ResponseContentRead, cancellationToken);
        return await this.CreateResponse<TResponse>(parameter, req, requestBodyText, res);
    }
    public async ValueTask<TResponse> SendFormDataAsync<TParameter, TResponse>(TParameter parameter, CancellationToken cancellationToken)
        where TParameter : RestApiParameter, IRestApiParameter, IFormDataParameter
        where TResponse : RestApiResponse
    {
        var p = parameter as IRestApiParameter;
        var req = this.CreateRequestMessage(parameter);

        var requestContent = new MultipartFormDataContent();
        var fileParameter = p as IFileParameter;
        if (fileParameter != null)
        {
            foreach (var item in fileParameter.GetFileParameters())
            {
                if (item.FileName == null) { continue; }
                var stream = item.GetFileStream();
                if (stream != null)
                {
                    stream.Position = 0;
                    var fileContent = new StreamContent(stream);
                    requestContent.Add(fileContent, item.Name, item.FileName);
                }
            }
        }
        var d = parameter.CreateFormDataParameter();
        foreach (var key in d.Keys)
        {
            requestContent.Add(new StringContent(d[key]), key);
        }
        req.Content = requestContent;

        var requestBodyText = JsonConverter.SerializeObject(d);

        Debug.WriteLine(requestBodyText);
        var res = await this.SendRequestAsync(req, HttpCompletionOption.ResponseContentRead, cancellationToken);

        var bodyText = await res.Content.ReadAsStringAsync();
        var o = OpenAIClient.JsonConverter.DeserializeObject<TResponse>(bodyText);
        o.SetProperty(parameter, requestBodyText, req, res, bodyText);

        return o;
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
            var errorRes = OpenAIClient.JsonConverter.DeserializeObject<OpenAIServerErrorResponse>(responseBodyText);
            throw new OpenAIServerException(parameter, req, requestBodyText, res, responseBodyText, errorRes.Error);
        }

        using (var stream = await res.Content.ReadAsStreamAsync())
        {
            try
            {
                var processor = new ServerSentEventProcessor(stream);
                await foreach (var line in processor.Process(cancellationToken))
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
    public async IAsyncEnumerable<string> GetStreamAsync(ChatCompletionCreateParameter parameter, ChatCompletionStreamResult? result, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        await foreach (var line in this.GetStreamAsync(parameter, cancellationToken))
        {
            if (line.IsData())
            {
                var text = line.GetText();
                if (string.Equals(text, "[DONE]", StringComparison.OrdinalIgnoreCase)) { continue; }

                var chunk = OpenAIClient.JsonConverter.DeserializeObject<ChatCompletionChunk>(text);
                if (result != null)
                {
                    result.Process(chunk);
                }
                foreach (var choice in chunk.Choices)
                {
                    if (choice.Delta.Content != null)
                    {
                        yield return choice.Delta.Content;
                    }
                    else if (choice.Delta.Tool_Calls != null)
                    {
                        foreach (var tool in choice.Delta.Tool_Calls)
                        {
                            if (tool.Function != null)
                            {
                                if (tool.Function.Name.IsNullOrEmpty() == false)
                                {
                                    yield return tool.Function.Name;
                                }
                                else if (tool.Function.Arguments.IsNullOrEmpty() == false)
                                {
                                    yield return tool.Function.Arguments;
                                }
                            }
                        }
                    }
                }
            }

        }
    }
    public async IAsyncEnumerable<string> GetStreamAsync<TParameter>(TParameter parameter, AssistantMessageStreamResult? result, [EnumeratorCancellation] CancellationToken cancellationToken)
        where TParameter : RestApiParameter, IRestApiParameter, IAssistantMessageParameter
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

                if (string.Equals(eventName, "thread.message.delta", StringComparison.OrdinalIgnoreCase))
                {
                    var delta = OpenAIClient.JsonConverter.DeserializeObject<AssistantDeltaObject>(text);
                    if (result != null)
                    {
                        result.DeltaList.Add(delta);
                    }
                    foreach (var content in delta.Delta.Content)
                    {
                        yield return content.Text.Value;
                    }
                }
                else
                {
                    if (result != null)
                    {
                        if (string.Equals(eventName, "thread.created", StringComparison.OrdinalIgnoreCase) ||
                            string.Equals(eventName, "thread.message.completed", StringComparison.OrdinalIgnoreCase))
                        {
                            result.Thread = OpenAIClient.JsonConverter.DeserializeObject<ThreadObject>(text);
                        }
                        else if (eventName.StartsWith("thread.run.step.", StringComparison.OrdinalIgnoreCase))
                        {
                            result.RunStep = OpenAIClient.JsonConverter.DeserializeObject<RunStepObject>(text);
                        }
                        else if (eventName.StartsWith("thread.run.", StringComparison.OrdinalIgnoreCase))
                        {
                            result.Run = OpenAIClient.JsonConverter.DeserializeObject<RunObject>(text);
                        }
                        else if (eventName.StartsWith("thread.message.", StringComparison.OrdinalIgnoreCase))
                        {
                            result.Message = OpenAIClient.JsonConverter.DeserializeObject<MessageObject>(text);
                        }
                    }
                }
            }

        }
    }
    public async IAsyncEnumerable<string> GetStreamAsync<TParameter>(TParameter parameter, ResponseStreamResult? result, [EnumeratorCancellation] CancellationToken cancellationToken)
        where TParameter : RestApiParameter, IRestApiParameter, IResponseCreateParameter
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

                if (result != null)
                {
                    result.EventList.Add(new ResponseStreamEvent(eventName, text));
                }
                if (string.Equals(eventName, "response.output_text.delta", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(eventName, "response.refusal.delta", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(eventName, "response.function_call_arguments.delta", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(eventName, "response.reasoning_summary_text.delta", StringComparison.OrdinalIgnoreCase))
                {
                    var delta = OpenAIClient.JsonConverter.DeserializeObject<ResponseDeltaObject>(text);
                    if (delta != null)
                    {
                        if (result != null)
                        {
                            result.Text += delta.Delta;
                        }
                        if (delta.Delta != null)
                        {
                            yield return delta.Delta;
                        }
                    }
                }
                else if (string.Equals(eventName, "error", StringComparison.OrdinalIgnoreCase))
                {
                    var error = OpenAIClient.JsonConverter.DeserializeObject<OpenAIServerError>(text);
                    throw new OpenAIServerSentEventException(error);
                }
            }

        }
    }
    public async IAsyncEnumerable<ResponseStreamEvent> GetEventStreamAsync<TParameter>(TParameter parameter, ResponseStreamResult? result, [EnumeratorCancellation] CancellationToken cancellationToken)
    where TParameter : RestApiParameter, IRestApiParameter, IResponseCreateParameter
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

                var rEvent = new ResponseStreamEvent(eventName, text);
                if (result != null)
                {
                    result.EventList.Add(rEvent);
                }
                yield return rEvent;
                
                if (string.Equals(eventName, "error", StringComparison.OrdinalIgnoreCase))
                {
                    var error = OpenAIClient.JsonConverter.DeserializeObject<OpenAIServerError>(text);
                    throw new OpenAIServerSentEventException(error);
                }
            }

        }
    }

    public async IAsyncEnumerable<string> ChatCompletionCreateStreamAsync(string message, string model)
    {
        var p = new ChatCompletionCreateParameter();
        p.AddUserMessage(message);
        p.Model = model;
        p.Stream = true;
        await foreach (var item in this.GetStreamAsync(p, null, CancellationToken.None))
        {
            yield return item;
        }
    }
    public async IAsyncEnumerable<string> ChatCompletionCreateStreamAsync(string message, string model, ChatCompletionStreamResult result)
    {
        var p = new ChatCompletionCreateParameter();
        p.AddUserMessage(message);
        p.Model = model;
        p.Stream = true;
        await foreach (var item in this.GetStreamAsync(p, result, CancellationToken.None))
        {
            yield return item;
        }
    }
    public async IAsyncEnumerable<string> ChatCompletionCreateStreamAsync(string message, string model, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var p = new ChatCompletionCreateParameter();
        p.AddUserMessage(message);
        p.Model = model;
        p.Stream = true;
        await foreach (var item in this.GetStreamAsync(p, null, cancellationToken))
        {
            yield return item;
        }
    }
    public async IAsyncEnumerable<string> ChatCompletionCreateStreamAsync(string message, string model, ChatCompletionStreamResult result, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var p = new ChatCompletionCreateParameter();
        p.AddUserMessage(message);
        p.Model = model;
        p.Stream = true;
        await foreach (var item in this.GetStreamAsync(p, result, cancellationToken))
        {
            yield return item;
        }
    }
    public async IAsyncEnumerable<string> ChatCompletionCreateStreamAsync(ChatMessage message, string model, ChatCompletionStreamResult result, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var p = new ChatCompletionCreateParameter();
        p.Messages.Add(message);
        p.Model = model;
        p.Stream = true;
        await foreach (var item in this.GetStreamAsync(p, result, cancellationToken))
        {
            yield return item;
        }
    }

    public async IAsyncEnumerable<string> ResponseCreateStreamAsync(string message, string model)
    {
        var p = new ResponseCreateParameter();
        p.Input.AddUserMessage(message);
        p.Model = model;
        p.Stream = true;
        await foreach (var item in this.GetStreamAsync(p, null, CancellationToken.None))
        {
            yield return item;
        }
    }
    public async IAsyncEnumerable<string> ResponseCreateStreamAsync(string message, string model, ResponseStreamResult result)
    {
        var p = new ResponseCreateParameter();
        p.Input.AddUserMessage(message);
        p.Model = model;
        p.Stream = true;
        await foreach (var item in this.GetStreamAsync(p, result, CancellationToken.None))
        {
            yield return item;
        }
    }
    public async IAsyncEnumerable<string> ResponseCreateStreamAsync(string message, string model, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var p = new ResponseCreateParameter();
        p.Input.AddUserMessage(message);
        p.Model = model;
        p.Stream = true;
        await foreach (var item in this.GetStreamAsync(p, null, cancellationToken))
        {
            yield return item;
        }
    }
    public async IAsyncEnumerable<string> ResponseCreateStreamAsync(string message, string model, ResponseStreamResult result, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var p = new ResponseCreateParameter();
        p.Input.AddUserMessage(message);
        p.Model = model;
        p.Stream = true;
        await foreach (var item in this.GetStreamAsync(p, result, cancellationToken))
        {
            yield return item;
        }
    }
}
