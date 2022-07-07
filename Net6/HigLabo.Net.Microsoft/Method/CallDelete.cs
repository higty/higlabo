using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class CallDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Communications_Calls_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Communications_Calls_Id: return $"/communications/calls/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string Id { get; set; }
    }
    public partial class CallDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/call-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<CallDeleteResponse> CallDeleteAsync()
        {
            var p = new CallDeleteParameter();
            return await this.SendAsync<CallDeleteParameter, CallDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/call-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<CallDeleteResponse> CallDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new CallDeleteParameter();
            return await this.SendAsync<CallDeleteParameter, CallDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/call-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<CallDeleteResponse> CallDeleteAsync(CallDeleteParameter parameter)
        {
            return await this.SendAsync<CallDeleteParameter, CallDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/call-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<CallDeleteResponse> CallDeleteAsync(CallDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CallDeleteParameter, CallDeleteResponse>(parameter, cancellationToken);
        }
    }
}
