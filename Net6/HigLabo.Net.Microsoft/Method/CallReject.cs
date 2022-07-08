using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class CallRejectParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Communications_Calls_Id_Reject: return $"/communications/calls/{Id}/reject";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Communications_Calls_Id_Reject,
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
        public string? Reason { get; set; }
        public string? CallbackUri { get; set; }
    }
    public partial class CallRejectResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/call-reject?view=graph-rest-1.0
        /// </summary>
        public async Task<CallRejectResponse> CallRejectAsync()
        {
            var p = new CallRejectParameter();
            return await this.SendAsync<CallRejectParameter, CallRejectResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/call-reject?view=graph-rest-1.0
        /// </summary>
        public async Task<CallRejectResponse> CallRejectAsync(CancellationToken cancellationToken)
        {
            var p = new CallRejectParameter();
            return await this.SendAsync<CallRejectParameter, CallRejectResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/call-reject?view=graph-rest-1.0
        /// </summary>
        public async Task<CallRejectResponse> CallRejectAsync(CallRejectParameter parameter)
        {
            return await this.SendAsync<CallRejectParameter, CallRejectResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/call-reject?view=graph-rest-1.0
        /// </summary>
        public async Task<CallRejectResponse> CallRejectAsync(CallRejectParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CallRejectParameter, CallRejectResponse>(parameter, cancellationToken);
        }
    }
}
