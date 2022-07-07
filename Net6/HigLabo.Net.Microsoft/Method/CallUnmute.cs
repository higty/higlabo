using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class CallUnmuteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Communications_Calls_Id_Unmute,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Communications_Calls_Id_Unmute: return $"/communications/calls/{Id}/unmute";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? ClientContext { get; set; }
        public string Id { get; set; }
    }
    public partial class CallUnmuteResponse : RestApiResponse
    {
        public string? ClientContext { get; set; }
        public string? Id { get; set; }
        public ResultInfo? ResultInfo { get; set; }
        public string? Status { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/call-unmute?view=graph-rest-1.0
        /// </summary>
        public async Task<CallUnmuteResponse> CallUnmuteAsync()
        {
            var p = new CallUnmuteParameter();
            return await this.SendAsync<CallUnmuteParameter, CallUnmuteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/call-unmute?view=graph-rest-1.0
        /// </summary>
        public async Task<CallUnmuteResponse> CallUnmuteAsync(CancellationToken cancellationToken)
        {
            var p = new CallUnmuteParameter();
            return await this.SendAsync<CallUnmuteParameter, CallUnmuteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/call-unmute?view=graph-rest-1.0
        /// </summary>
        public async Task<CallUnmuteResponse> CallUnmuteAsync(CallUnmuteParameter parameter)
        {
            return await this.SendAsync<CallUnmuteParameter, CallUnmuteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/call-unmute?view=graph-rest-1.0
        /// </summary>
        public async Task<CallUnmuteResponse> CallUnmuteAsync(CallUnmuteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CallUnmuteParameter, CallUnmuteResponse>(parameter, cancellationToken);
        }
    }
}
