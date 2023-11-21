using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/call-delete?view=graph-rest-1.0
    /// </summary>
    public partial class CallDeleteParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Communications_Calls_Id: return $"/communications/calls/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Communications_Calls_Id,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
    }
    public partial class CallDeleteResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/call-delete?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/call-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<CallDeleteResponse> CallDeleteAsync()
        {
            var p = new CallDeleteParameter();
            return await this.SendAsync<CallDeleteParameter, CallDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/call-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<CallDeleteResponse> CallDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new CallDeleteParameter();
            return await this.SendAsync<CallDeleteParameter, CallDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/call-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<CallDeleteResponse> CallDeleteAsync(CallDeleteParameter parameter)
        {
            return await this.SendAsync<CallDeleteParameter, CallDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/call-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<CallDeleteResponse> CallDeleteAsync(CallDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CallDeleteParameter, CallDeleteResponse>(parameter, cancellationToken);
        }
    }
}
