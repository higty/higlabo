using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/call-logteleconferencedevicequality?view=graph-rest-1.0
    /// </summary>
    public partial class CallLogteleconferencedevicequalityParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Communications_Calls_LogTeleconferenceDeviceQuality: return $"/communications/calls/logTeleconferenceDeviceQuality";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Communications_Calls_LogTeleconferenceDeviceQuality,
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
        public TeleconferenceDeviceQuality? Quality { get; set; }
    }
    public partial class CallLogteleconferencedevicequalityResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/call-logteleconferencedevicequality?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/call-logteleconferencedevicequality?view=graph-rest-1.0
        /// </summary>
        public async Task<CallLogteleconferencedevicequalityResponse> CallLogteleconferencedevicequalityAsync()
        {
            var p = new CallLogteleconferencedevicequalityParameter();
            return await this.SendAsync<CallLogteleconferencedevicequalityParameter, CallLogteleconferencedevicequalityResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/call-logteleconferencedevicequality?view=graph-rest-1.0
        /// </summary>
        public async Task<CallLogteleconferencedevicequalityResponse> CallLogteleconferencedevicequalityAsync(CancellationToken cancellationToken)
        {
            var p = new CallLogteleconferencedevicequalityParameter();
            return await this.SendAsync<CallLogteleconferencedevicequalityParameter, CallLogteleconferencedevicequalityResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/call-logteleconferencedevicequality?view=graph-rest-1.0
        /// </summary>
        public async Task<CallLogteleconferencedevicequalityResponse> CallLogteleconferencedevicequalityAsync(CallLogteleconferencedevicequalityParameter parameter)
        {
            return await this.SendAsync<CallLogteleconferencedevicequalityParameter, CallLogteleconferencedevicequalityResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/call-logteleconferencedevicequality?view=graph-rest-1.0
        /// </summary>
        public async Task<CallLogteleconferencedevicequalityResponse> CallLogteleconferencedevicequalityAsync(CallLogteleconferencedevicequalityParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CallLogteleconferencedevicequalityParameter, CallLogteleconferencedevicequalityResponse>(parameter, cancellationToken);
        }
    }
}
