using HigLabo.Core;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;

namespace HigLabo.X;

public class HttpRequestMessageEventArgs : EventArgs
{
    public HttpRequestMessage RequestMessage { get; init; }

    public HttpRequestMessageEventArgs(HttpRequestMessage requestMessage)
    {
        this.RequestMessage = requestMessage;
    }
}
public partial class XClient
{
    public static IJsonConverter JsonConverter { get; set; } = new XJsonConverter();
    public static HttpClient DefaultHttpClient { get; } = new HttpClient()
    {
        Timeout = TimeSpan.FromMinutes(10),
    };

    public event EventHandler<HttpRequestMessageEventArgs>? PreSendRequest;

    public HttpClient HttpClient { get; set; } = DefaultHttpClient;
    public XSettings Settings { get; init; } = new();

    public string ApiUrl
    {
        get { return this.Settings.ApiUrl; }
    }

    public XClient(string accessToken)
    {
        this.Settings.AccessToken = accessToken;
    }
    public XClient(string accessToken, HttpClient httpClient)
    {
        this.Settings.AccessToken = accessToken;
        this.HttpClient = httpClient;
    }
    public XClient(XSettings settings)
    {
        this.Settings = settings;
    }
    public XClient(XSettings settings, HttpClient httpClient)
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
            "PUT" => HttpMethod.Put,
            "DELETE" => HttpMethod.Delete,
            _ => throw SwitchStatementNotImplementException.Create(p.HttpMethod),
        };
        var apiPath = p.GetApiPath();
        var requestUrl = $"{this.ApiUrl}{apiPath}";
        if (parameter is IQueryParameterProperty q)
        {
            var d = q.CreateQueryParameter();
            if (d.Count > 0)
            {
                var queryString = new QueryStringConverter().Write(d);
                requestUrl += "?" + queryString;
            }
        }

        var req = new HttpRequestMessage(httpMethod, requestUrl);
        req.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        if (this.Settings.AccessToken.HasValue())
        {
            req.Headers.Authorization = new AuthenticationHeaderValue("Bearer", this.Settings.AccessToken);
        }
        if (this.Settings.UserAgent.HasValue())
        {
            req.Headers.TryAddWithoutValidation("User-Agent", this.Settings.UserAgent);
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
            var o = XClient.JsonConverter.DeserializeObject<TResponse>(bodyText);
            o.SetProperty(parameter, requestBodyText, request, res, bodyText);
            return o;
        }

        var errorResponse = XClient.JsonConverter.DeserializeObject<XServerErrorResponse>(bodyText);
        throw new XServerException(parameter, request, requestBodyText, response, bodyText, errorResponse);
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
        if (string.Equals(p.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase) == false &&
            string.Equals(p.HttpMethod, "DELETE", StringComparison.OrdinalIgnoreCase) == false)
        {
            requestBodyText = XClient.JsonConverter.SerializeObject(parameter.GetRequestBody());
            req.Content = new StringContent(requestBodyText, Encoding.UTF8, new MediaTypeHeaderValue("application/json"));
        }
        Debug.WriteLine(requestBodyText);
        var res = await this.SendRequestAsync(req, HttpCompletionOption.ResponseContentRead, cancellationToken);
        return await this.CreateResponse<TResponse>(parameter, req, requestBodyText, res);
    }

    public async IAsyncEnumerable<ServerSentEventLine> GetStreamAsync<TParameter>(TParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        where TParameter : RestApiParameter, IRestApiParameter
    {
        var p = parameter as IRestApiParameter;
        var req = this.CreateRequestMessage(parameter);
        req.Headers.Accept.Clear();
        req.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("text/event-stream"));
        var requestBodyText = "";
        if (string.Equals(p.HttpMethod, "POST", StringComparison.OrdinalIgnoreCase) ||
            string.Equals(p.HttpMethod, "PUT", StringComparison.OrdinalIgnoreCase))
        {
            requestBodyText = XClient.JsonConverter.SerializeObject(parameter.GetRequestBody());
            req.Content = new StringContent(requestBodyText, Encoding.UTF8, new MediaTypeHeaderValue("application/json"));
        }

        Debug.WriteLine(requestBodyText);
        var res = await this.SendRequestAsync(req, HttpCompletionOption.ResponseHeadersRead, cancellationToken);

        if (res.IsSuccessStatusCode == false)
        {
            var responseBodyText = await res.Content.ReadAsStringAsync();
            var errorResponse = XClient.JsonConverter.DeserializeObject<XServerErrorResponse>(responseBodyText);
            throw new XServerException(parameter, req, requestBodyText, res, responseBodyText, errorResponse);
        }

        using (var stream = await res.Content.ReadAsStreamAsync())
        {
            var processor = new ServerSentEventProcessor(stream);
            await foreach (var line in processor.Process(cancellationToken))
            {
                yield return line;
            }
        }
    }

    public async IAsyncEnumerable<XFilteredStreamResponse> GetFilteredStreamAsync(TweetsSearchStreamParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        await foreach (var line in this.GetStreamAsync(parameter, cancellationToken))
        {
            if (line.IsData() == false) { continue; }
            var text = line.GetText();
            if (string.Equals(text, "[DONE]", StringComparison.OrdinalIgnoreCase)) { continue; }
            yield return XClient.JsonConverter.DeserializeObject<XFilteredStreamResponse>(text);
        }
    }
    public async IAsyncEnumerable<XFilteredStreamResponse> GetFilteredStreamAsync([EnumeratorCancellation] CancellationToken cancellationToken)
    {
        await foreach (var item in this.GetFilteredStreamAsync(TweetsSearchStreamParameter.Empty, cancellationToken))
        {
            yield return item;
        }
    }
    public async IAsyncEnumerable<XSampleStreamResponse> GetSampleStreamAsync(TweetsSampleStreamParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        await foreach (var line in this.GetStreamAsync(parameter, cancellationToken))
        {
            if (line.IsData() == false) { continue; }
            var text = line.GetText();
            if (string.Equals(text, "[DONE]", StringComparison.OrdinalIgnoreCase)) { continue; }
            yield return XClient.JsonConverter.DeserializeObject<XSampleStreamResponse>(text);
        }
    }
    public async IAsyncEnumerable<XSampleStreamResponse> GetSampleStreamAsync([EnumeratorCancellation] CancellationToken cancellationToken)
    {
        await foreach (var item in this.GetSampleStreamAsync(TweetsSampleStreamParameter.Empty, cancellationToken))
        {
            yield return item;
        }
    }
}
