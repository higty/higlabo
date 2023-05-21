using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/call-subscribetotone?view=graph-rest-1.0
    /// </summary>
    public partial class CallSubscribetotoneParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Communications_Calls_Id_SubscribeToTone: return $"/communications/calls/{Id}/subscribeToTone";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Communications_Calls_Id_SubscribeToTone,
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
        public string? ClientContext { get; set; }
    }
    public partial class CallSubscribetotoneResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/call-subscribetotone?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/call-subscribetotone?view=graph-rest-1.0
        /// </summary>
        public async Task<CallSubscribetotoneResponse> CallSubscribetotoneAsync()
        {
            var p = new CallSubscribetotoneParameter();
            return await this.SendAsync<CallSubscribetotoneParameter, CallSubscribetotoneResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/call-subscribetotone?view=graph-rest-1.0
        /// </summary>
        public async Task<CallSubscribetotoneResponse> CallSubscribetotoneAsync(CancellationToken cancellationToken)
        {
            var p = new CallSubscribetotoneParameter();
            return await this.SendAsync<CallSubscribetotoneParameter, CallSubscribetotoneResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/call-subscribetotone?view=graph-rest-1.0
        /// </summary>
        public async Task<CallSubscribetotoneResponse> CallSubscribetotoneAsync(CallSubscribetotoneParameter parameter)
        {
            return await this.SendAsync<CallSubscribetotoneParameter, CallSubscribetotoneResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/call-subscribetotone?view=graph-rest-1.0
        /// </summary>
        public async Task<CallSubscribetotoneResponse> CallSubscribetotoneAsync(CallSubscribetotoneParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CallSubscribetotoneParameter, CallSubscribetotoneResponse>(parameter, cancellationToken);
        }
    }
}
