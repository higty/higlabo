namespace HigLabo.Bing
{
    public class BingServerError
    {
        public string Code { get; set; } = "";
        public string Message { get; set; } = "";
        public string MoreDetails { get; set; } = "";
        public string Parameter { get; set; } = "";
        public string SubCode { get; set; } = "";
        public string Value { get; set; } = "";
    }
    public class BingServerErrorResponse
    {
        public string _Type { get; set; } = "";
        public List<BingServerError> Errors { get; set; } = new();
    }
    public class BingServerException : Exception
    {
        public object Parameter { get; set; }
        public HttpRequestMessage Request { get; set; }
        public string RequestBodyText { get; set; } 
        public HttpResponseMessage Response { get; set; }
        public string ResponseBodyText { get; set; } = "";
        public List<BingServerError> ErrorList { get; set; }

        public BingServerException(object parameter, HttpRequestMessage request, string requestBodyText
            , HttpResponseMessage response, string responseBodyText, List<BingServerError> errorList)
            : base(errorList.FirstOrDefault()?.Message ?? "")
        {
            this.Parameter = parameter;
            this.Request = request;
            this.RequestBodyText = requestBodyText;
            this.Response = response;
            this.ResponseBodyText = responseBodyText;
            this.ErrorList = errorList;
        }
    }
}
