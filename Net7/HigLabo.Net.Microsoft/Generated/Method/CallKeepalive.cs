using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/call-keepalive?view=graph-rest-1.0
    /// </summary>
    public partial class CallKeepaliveParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Communications_Calls_Id_KeepAlive: return $"/communications/calls/{Id}/keepAlive";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Communications_Calls_Id_KeepAlive,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
    }
    public partial class CallKeepaliveResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/call-keepalive?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/call-keepalive?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<CallKeepaliveResponse> CallKeepaliveAsync()
        {
            var p = new CallKeepaliveParameter();
            return await this.SendAsync<CallKeepaliveParameter, CallKeepaliveResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/call-keepalive?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<CallKeepaliveResponse> CallKeepaliveAsync(CancellationToken cancellationToken)
        {
            var p = new CallKeepaliveParameter();
            return await this.SendAsync<CallKeepaliveParameter, CallKeepaliveResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/call-keepalive?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<CallKeepaliveResponse> CallKeepaliveAsync(CallKeepaliveParameter parameter)
        {
            return await this.SendAsync<CallKeepaliveParameter, CallKeepaliveResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/call-keepalive?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<CallKeepaliveResponse> CallKeepaliveAsync(CallKeepaliveParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CallKeepaliveParameter, CallKeepaliveResponse>(parameter, cancellationToken);
        }
    }
}
