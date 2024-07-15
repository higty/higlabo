namespace HigLabo.RestApi
{
    public class HttpRequestMessageEventArgs : EventArgs
    {
        public HttpRequestMessage RequestMessage { get; init; }

        public HttpRequestMessageEventArgs(HttpRequestMessage requestMessage)
        {
            this.RequestMessage = requestMessage;
        }
    }
}
