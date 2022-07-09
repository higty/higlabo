using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class CallUpdaterecordingStatusParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Communications_Calls_Id_UpdateRecordingStatus: return $"/communications/calls/{Id}/updateRecordingStatus";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Communications_Calls_Id_UpdateRecordingStatus,
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
        public string? Status { get; set; }
        public string? Id { get; set; }
        public ResultInfo? ResultInfo { get; set; }
    }
    public partial class CallUpdaterecordingStatusResponse : RestApiResponse
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
        public async Task<CallUpdaterecordingStatusResponse> CallUpdaterecordingStatusAsync()
        {
            var p = new CallUpdaterecordingStatusParameter();
            return await this.SendAsync<CallUpdaterecordingStatusParameter, CallUpdaterecordingStatusResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/call-updaterecordingstatus?view=graph-rest-1.0
        /// </summary>
        public async Task<CallUpdaterecordingStatusResponse> CallUpdaterecordingStatusAsync(CancellationToken cancellationToken)
        {
            var p = new CallUpdaterecordingStatusParameter();
            return await this.SendAsync<CallUpdaterecordingStatusParameter, CallUpdaterecordingStatusResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/call-updaterecordingstatus?view=graph-rest-1.0
        /// </summary>
        public async Task<CallUpdaterecordingStatusResponse> CallUpdaterecordingStatusAsync(CallUpdaterecordingStatusParameter parameter)
        {
            return await this.SendAsync<CallUpdaterecordingStatusParameter, CallUpdaterecordingStatusResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/call-updaterecordingstatus?view=graph-rest-1.0
        /// </summary>
        public async Task<CallUpdaterecordingStatusResponse> CallUpdaterecordingStatusAsync(CallUpdaterecordingStatusParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CallUpdaterecordingStatusParameter, CallUpdaterecordingStatusResponse>(parameter, cancellationToken);
        }
    }
}
