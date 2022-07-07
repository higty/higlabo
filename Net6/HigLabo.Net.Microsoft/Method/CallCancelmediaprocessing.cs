using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class CallCancelmediaprocessingParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Communications_Calls_Id_CancelMediaProcessing,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Communications_Calls_Id_CancelMediaProcessing: return $"/communications/calls/{Id}/cancelMediaProcessing";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? ClientContext { get; set; }
        public string Id { get; set; }
    }
    public partial class CallCancelmediaprocessingResponse : RestApiResponse
    {
        public string? ClientContext { get; set; }
        public string? Id { get; set; }
        public ResultInfo? ResultInfo { get; set; }
        public string? Status { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/call-cancelmediaprocessing?view=graph-rest-1.0
        /// </summary>
        public async Task<CallCancelmediaprocessingResponse> CallCancelmediaprocessingAsync()
        {
            var p = new CallCancelmediaprocessingParameter();
            return await this.SendAsync<CallCancelmediaprocessingParameter, CallCancelmediaprocessingResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/call-cancelmediaprocessing?view=graph-rest-1.0
        /// </summary>
        public async Task<CallCancelmediaprocessingResponse> CallCancelmediaprocessingAsync(CancellationToken cancellationToken)
        {
            var p = new CallCancelmediaprocessingParameter();
            return await this.SendAsync<CallCancelmediaprocessingParameter, CallCancelmediaprocessingResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/call-cancelmediaprocessing?view=graph-rest-1.0
        /// </summary>
        public async Task<CallCancelmediaprocessingResponse> CallCancelmediaprocessingAsync(CallCancelmediaprocessingParameter parameter)
        {
            return await this.SendAsync<CallCancelmediaprocessingParameter, CallCancelmediaprocessingResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/call-cancelmediaprocessing?view=graph-rest-1.0
        /// </summary>
        public async Task<CallCancelmediaprocessingResponse> CallCancelmediaprocessingAsync(CallCancelmediaprocessingParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CallCancelmediaprocessingParameter, CallCancelmediaprocessingResponse>(parameter, cancellationToken);
        }
    }
}
