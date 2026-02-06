namespace HigLabo.X;

public class XServerErrorResponse
{
    public string Type { get; set; } = "";
    public string Title { get; set; } = "";
    public string Detail { get; set; } = "";
    public int Status { get; set; }
    public List<XApiError> Errors { get; set; } = new();
}
public class XServerException : Exception
{
    public object Parameter { get; set; }
    public HttpRequestMessage Request { get; set; }
    public string RequestBodyText { get; set; }
    public HttpResponseMessage Response { get; set; }
    public string ResponseBodyText { get; set; } = "";
    public XServerErrorResponse Error { get; set; }

    public XServerException(object parameter, HttpRequestMessage request, string requestBodyText
        , HttpResponseMessage response, string responseBodyText, XServerErrorResponse error)
        : base($"{request.RequestUri}\n{responseBodyText}")
    {
        this.Parameter = parameter;
        this.Request = request;
        this.RequestBodyText = requestBodyText;
        this.Response = response;
        this.ResponseBodyText = responseBodyText;
        this.Error = error;
    }
}
