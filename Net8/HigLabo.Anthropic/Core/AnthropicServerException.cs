namespace HigLabo.Anthropic;

public class AnthropicServerError
{
    public string Code { get; set; } = "";
    public string Message { get; set; } = "";
    public string Param { get; set; } = "";
    public string Type { get; set; } = "";
}
public class AnthropicServerErrorResponse
{
    public AnthropicServerError Error { get; set; } = new();
}
public class AnthropicServerException : Exception
{
    public object Parameter { get; set; }
    public HttpRequestMessage Request { get; set; }
    public string RequestBodyText { get; set; } 
    public HttpResponseMessage Response { get; set; }
    public string ResponseBodyText { get; set; } = "";
    public AnthropicServerError Error { get; set; }

    public AnthropicServerException(object parameter, HttpRequestMessage request, string requestBodyText
        , HttpResponseMessage response, string responseBodyText, AnthropicServerError error)
        : base(error.Message)
    {
        this.Parameter = parameter;
        this.Request = request;
        this.RequestBodyText = requestBodyText;
        this.Response = response;
        this.ResponseBodyText = responseBodyText;
        this.Error = error;
    }
}
