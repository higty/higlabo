using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class CallUpdaterecordingstatusParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Communications_Calls_Id_UpdateRecordingStatus,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Communications_Calls_Id_UpdateRecordingStatus: return $"/communications/calls/{Id}/updateRecordingStatus";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? ClientContext { get; set; }
        public string? Status { get; set; }
        public string Id { get; set; }
    }
    public partial class CallUpdaterecordingstatusResponse : RestApiResponse
    {
        public string? ClientContext { get; set; }
        public string? Id { get; set; }
        public ResultInfo? ResultInfo { get; set; }
        public string? Status { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/call-updaterecordingstatus?view=graph-rest-1.0
        /// </summary>
        public async Task<CallUpdaterecordingstatusResponse> CallUpdaterecordingstatusAsync()
        {
            var p = new CallUpdaterecordingstatusParameter();
            return await this.SendAsync<CallUpdaterecordingstatusParameter, CallUpdaterecordingstatusResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/call-updaterecordingstatus?view=graph-rest-1.0
        /// </summary>
        public async Task<CallUpdaterecordingstatusResponse> CallUpdaterecordingstatusAsync(CancellationToken cancellationToken)
        {
            var p = new CallUpdaterecordingstatusParameter();
            return await this.SendAsync<CallUpdaterecordingstatusParameter, CallUpdaterecordingstatusResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/call-updaterecordingstatus?view=graph-rest-1.0
        /// </summary>
        public async Task<CallUpdaterecordingstatusResponse> CallUpdaterecordingstatusAsync(CallUpdaterecordingstatusParameter parameter)
        {
            return await this.SendAsync<CallUpdaterecordingstatusParameter, CallUpdaterecordingstatusResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/call-updaterecordingstatus?view=graph-rest-1.0
        /// </summary>
        public async Task<CallUpdaterecordingstatusResponse> CallUpdaterecordingstatusAsync(CallUpdaterecordingstatusParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CallUpdaterecordingstatusParameter, CallUpdaterecordingstatusResponse>(parameter, cancellationToken);
        }
    }
}
