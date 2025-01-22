namespace HigLabo.GoogleAI;

public class GoogleAIServerError
{
    public string Code { get; set; } = "";
    public string Message { get; set; } = "";
    public string Param { get; set; } = "";
    public string Type { get; set; } = "";
}
public class GoogleAIServerErrorResponse
{
    public GoogleAIServerError Error { get; set; } = new();
}
public class GoogleAIServerException : Exception
{
    public object Parameter { get; set; }
    public HttpRequestMessage Request { get; set; }
    public string RequestBodyText { get; set; } 
    public HttpResponseMessage Response { get; set; }
    public string ResponseBodyText { get; set; } = "";
    public GoogleAIServerErrorResponse Error { get; set; } 

    public GoogleAIServerException(object parameter, HttpRequestMessage request, string requestBodyText
        , HttpResponseMessage response, string responseBodyText, GoogleAIServerErrorResponse error)
        : base(error.Error.Message)
    {
        this.Parameter = parameter;
        this.Request = request;
        this.RequestBodyText = requestBodyText;
        this.Response = response;
        this.ResponseBodyText = responseBodyText;
        this.Error = error;
    }
}
