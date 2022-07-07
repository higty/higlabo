using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class CallLogteleconferencedevicequalityParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Communications_Calls_LogTeleconferenceDeviceQuality,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Communications_Calls_LogTeleconferenceDeviceQuality: return $"/communications/calls/logTeleconferenceDeviceQuality";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public TeleconferenceDeviceQuality? Quality { get; set; }
    }
    public partial class CallLogteleconferencedevicequalityResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/call-logteleconferencedevicequality?view=graph-rest-1.0
        /// </summary>
        public async Task<CallLogteleconferencedevicequalityResponse> CallLogteleconferencedevicequalityAsync()
        {
            var p = new CallLogteleconferencedevicequalityParameter();
            return await this.SendAsync<CallLogteleconferencedevicequalityParameter, CallLogteleconferencedevicequalityResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/call-logteleconferencedevicequality?view=graph-rest-1.0
        /// </summary>
        public async Task<CallLogteleconferencedevicequalityResponse> CallLogteleconferencedevicequalityAsync(CancellationToken cancellationToken)
        {
            var p = new CallLogteleconferencedevicequalityParameter();
            return await this.SendAsync<CallLogteleconferencedevicequalityParameter, CallLogteleconferencedevicequalityResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/call-logteleconferencedevicequality?view=graph-rest-1.0
        /// </summary>
        public async Task<CallLogteleconferencedevicequalityResponse> CallLogteleconferencedevicequalityAsync(CallLogteleconferencedevicequalityParameter parameter)
        {
            return await this.SendAsync<CallLogteleconferencedevicequalityParameter, CallLogteleconferencedevicequalityResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/call-logteleconferencedevicequality?view=graph-rest-1.0
        /// </summary>
        public async Task<CallLogteleconferencedevicequalityResponse> CallLogteleconferencedevicequalityAsync(CallLogteleconferencedevicequalityParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CallLogteleconferencedevicequalityParameter, CallLogteleconferencedevicequalityResponse>(parameter, cancellationToken);
        }
    }
}
