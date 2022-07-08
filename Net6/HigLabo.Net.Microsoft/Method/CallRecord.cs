using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class CallRecordParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Communications_Calls_Id_RecordResponse: return $"/communications/calls/{Id}/recordResponse";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Communications_Calls_Id_RecordResponse,
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
        public MediaPrompt[]? Prompts { get; set; }
        public bool? BargeInAllowed { get; set; }
        public Int32? InitialSilenceTimeoutInSeconds { get; set; }
        public Int32? MaxSilenceTimeoutInSeconds { get; set; }
        public Int32? MaxRecordDurationInSeconds { get; set; }
        public bool? PlayBeep { get; set; }
        public String[]? StopTones { get; set; }
        public string? ClientContext { get; set; }
        public string? Id { get; set; }
        public string? RecordingAccessToken { get; set; }
        public string? RecordingLocation { get; set; }
        public ResultInfo? ResultInfo { get; set; }
        public string? Status { get; set; }
    }
    public partial class CallRecordResponse : RestApiResponse
    {
        public string? ClientContext { get; set; }
        public string? Id { get; set; }
        public string? RecordingAccessToken { get; set; }
        public string? RecordingLocation { get; set; }
        public ResultInfo? ResultInfo { get; set; }
        public string? Status { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/call-record?view=graph-rest-1.0
        /// </summary>
        public async Task<CallRecordResponse> CallRecordAsync()
        {
            var p = new CallRecordParameter();
            return await this.SendAsync<CallRecordParameter, CallRecordResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/call-record?view=graph-rest-1.0
        /// </summary>
        public async Task<CallRecordResponse> CallRecordAsync(CancellationToken cancellationToken)
        {
            var p = new CallRecordParameter();
            return await this.SendAsync<CallRecordParameter, CallRecordResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/call-record?view=graph-rest-1.0
        /// </summary>
        public async Task<CallRecordResponse> CallRecordAsync(CallRecordParameter parameter)
        {
            return await this.SendAsync<CallRecordParameter, CallRecordResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/call-record?view=graph-rest-1.0
        /// </summary>
        public async Task<CallRecordResponse> CallRecordAsync(CallRecordParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CallRecordParameter, CallRecordResponse>(parameter, cancellationToken);
        }
    }
}
