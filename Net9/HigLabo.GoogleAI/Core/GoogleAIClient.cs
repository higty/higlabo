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

namespace HigLabo.GoogleAI;

public class HttpRequestMessageEventArgs : EventArgs
{
    public HttpRequestMessage RequestMessage { get; init; }

    public HttpRequestMessageEventArgs(HttpRequestMessage requestMessage)
    {
        this.RequestMessage = requestMessage;
    }
}
public partial class GoogleAIClient
{
    public static HttpClient DefaultHttpClient { get; } = new HttpClient()
    {
        Timeout = TimeSpan.FromMinutes(10),
    };
    
    public event EventHandler<HttpRequestMessageEventArgs>? PreSendRequest;

    public string ApiUrl
    {
        get
        {
            return $"https://generativelanguage.googleapis.com/v1beta/";
        }
    }
    public HttpClient HttpClient { get; set; } = DefaultHttpClient;
    public IJsonConverter JsonConverter { get; set; } = new GoogleAIJsonConverter();
    public GoogleAISettings Settings { get; init; } = new();

    public GoogleAIClient(string apiKey)
    {
        this.Settings.ApiKey = apiKey;
    }
    public GoogleAIClient(GoogleAISettings settings)
    {
        this.Settings = settings;
    }
    public GoogleAIClient(GoogleAISettings settings, HttpClient httpClient)
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
        var url = $"{this.ApiUrl}{apiPath}?key={this.Settings.ApiKey}";
        if (p is ModelsGenerateContentParameter p1)
        {
            if (p1.Stream)
            {
                url += "&alt=sse";
            }
        }
        var req = new HttpRequestMessage(httpMethod, url);
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
            var errorResponse = this.JsonConverter.DeserializeObject<GoogleAIServerErrorResponse>(bodyText);
            throw new GoogleAIServerException(parameter, request, requestBodyText, response, bodyText, errorResponse);
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

}
