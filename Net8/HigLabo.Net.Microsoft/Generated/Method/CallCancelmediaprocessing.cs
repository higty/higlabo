using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/call-cancelmediaprocessing?view=graph-rest-1.0
    /// </summary>
    public partial class CallCancelmediaprocessingParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Communications_Calls_Id_CancelMediaProcessing: return $"/communications/calls/{Id}/cancelMediaProcessing";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Communications_Calls_Id_CancelMediaProcessing,
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
        public string? Id { get; set; }
        public ResultInfo? ResultInfo { get; set; }
        public string? Status { get; set; }
    }
    public partial class CallCancelmediaprocessingResponse : RestApiResponse
    {
        public string? ClientContext { get; set; }
        public string? Id { get; set; }
        public ResultInfo? ResultInfo { get; set; }
        public string? Status { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/call-cancelmediaprocessing?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/call-cancelmediaprocessing?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<CallCancelmediaprocessingResponse> CallCancelmediaprocessingAsync()
        {
            var p = new CallCancelmediaprocessingParameter();
            return await this.SendAsync<CallCancelmediaprocessingParameter, CallCancelmediaprocessingResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/call-cancelmediaprocessing?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<CallCancelmediaprocessingResponse> CallCancelmediaprocessingAsync(CancellationToken cancellationToken)
        {
            var p = new CallCancelmediaprocessingParameter();
            return await this.SendAsync<CallCancelmediaprocessingParameter, CallCancelmediaprocessingResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/call-cancelmediaprocessing?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<CallCancelmediaprocessingResponse> CallCancelmediaprocessingAsync(CallCancelmediaprocessingParameter parameter)
        {
            return await this.SendAsync<CallCancelmediaprocessingParameter, CallCancelmediaprocessingResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/call-cancelmediaprocessing?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<CallCancelmediaprocessingResponse> CallCancelmediaprocessingAsync(CallCancelmediaprocessingParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CallCancelmediaprocessingParameter, CallCancelmediaprocessingResponse>(parameter, cancellationToken);
        }
    }
}
