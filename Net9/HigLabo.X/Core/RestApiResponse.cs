using System.Net;
using System.Text;

namespace HigLabo.X;

public interface IRestApiResponse
{
    object? Parameter { get; }
    HttpRequestMessage Request { get; }
    string RequestBodyText { get; }
    HttpStatusCode StatusCode { get; }
    Dictionary<string, string> Headers { get; }
    Stream? Stream { get; }
    string ResponseBodyText { get; }
}
public abstract class RestApiResponse : IRestApiResponse
{
    private object? _Parameter = null;
    private HttpRequestMessage? _Request = null;
    private string _RequestBodyText = "";
    private HttpStatusCode _StatusCode = HttpStatusCode.OK;
    private Dictionary<string, string> _Headers = new Dictionary<string, string>();
    private Stream? _Stream = null;
    private string _ResponseBodyText = "";

    object? IRestApiResponse.Parameter
    {
        get { return _Parameter; }
    }
    HttpRequestMessage IRestApiResponse.Request
    {
        get { return _Request!; }
    }
    string IRestApiResponse.RequestBodyText
    {
        get { return _RequestBodyText; }
    }
    HttpStatusCode IRestApiResponse.StatusCode
    {
        get { return _StatusCode; }
    }
    Dictionary<string, string> IRestApiResponse.Headers
    {
        get { return _Headers; }
    }
    Stream? IRestApiResponse.Stream
    {
        get { return _Stream; }
    }
    string IRestApiResponse.ResponseBodyText
    {
        get { return _ResponseBodyText; }
    }

    public async ValueTask SetProperty(object? parameter, string requestBodyText, HttpRequestMessage request, HttpResponseMessage response)
    {
        var res = response;
        _Parameter = parameter;
        _Request = request;
        _RequestBodyText = requestBodyText;
        _StatusCode = res.StatusCode;
        foreach (var header in res.Headers)
        {
            _Headers[header.Key] = string.Join(' ', header.Value);
        }
        _Stream = await res.Content.ReadAsStreamAsync();
    }
    public void SetProperty(object? parameter, string requestBodyText, HttpRequestMessage request, HttpResponseMessage response, string bodyText)
    {
        var res = response;
        _Parameter = parameter;
        _Request = request;
        _RequestBodyText = requestBodyText;
        _StatusCode = res.StatusCode;
        foreach (var header in res.Headers)
        {
            _Headers[header.Key] = string.Join(' ', header.Value);
        }
        _ResponseBodyText = bodyText;
    }
    public string GetHeaderText()
    {
        var sb = new StringBuilder();
        foreach (var key in this._Headers.Keys)
        {
            sb.Append(key).Append(": ").AppendLine(_Headers[key]);
        }
        return sb.ToString();
    }
    public string GetResponseBodyText()
    {
        return _ResponseBodyText;
    }

    public override string ToString()
    {
        return _ResponseBodyText;
    }
}
