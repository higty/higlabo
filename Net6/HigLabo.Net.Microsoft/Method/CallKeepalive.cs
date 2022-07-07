using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class CallKeepaliveParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Communications_Calls_Id_KeepAlive,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Communications_Calls_Id_KeepAlive: return $"/communications/calls/{Id}/keepAlive";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Id { get; set; }
    }
    public partial class CallKeepaliveResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/call-keepalive?view=graph-rest-1.0
        /// </summary>
        public async Task<CallKeepaliveResponse> CallKeepaliveAsync()
        {
            var p = new CallKeepaliveParameter();
            return await this.SendAsync<CallKeepaliveParameter, CallKeepaliveResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/call-keepalive?view=graph-rest-1.0
        /// </summary>
        public async Task<CallKeepaliveResponse> CallKeepaliveAsync(CancellationToken cancellationToken)
        {
            var p = new CallKeepaliveParameter();
            return await this.SendAsync<CallKeepaliveParameter, CallKeepaliveResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/call-keepalive?view=graph-rest-1.0
        /// </summary>
        public async Task<CallKeepaliveResponse> CallKeepaliveAsync(CallKeepaliveParameter parameter)
        {
            return await this.SendAsync<CallKeepaliveParameter, CallKeepaliveResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/call-keepalive?view=graph-rest-1.0
        /// </summary>
        public async Task<CallKeepaliveResponse> CallKeepaliveAsync(CallKeepaliveParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CallKeepaliveParameter, CallKeepaliveResponse>(parameter, cancellationToken);
        }
    }
}
