using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class CallMuteParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Communications_Calls_Id_Mute: return $"/communications/calls/{Id}/mute";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Communications_Calls_Id_Mute,
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
    public partial class CallMuteResponse : RestApiResponse
    {
        public string? ClientContext { get; set; }
        public string? Id { get; set; }
        public ResultInfo? ResultInfo { get; set; }
        public string? Status { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/call-mute?view=graph-rest-1.0
        /// </summary>
        public async Task<CallMuteResponse> CallMuteAsync()
        {
            var p = new CallMuteParameter();
            return await this.SendAsync<CallMuteParameter, CallMuteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/call-mute?view=graph-rest-1.0
        /// </summary>
        public async Task<CallMuteResponse> CallMuteAsync(CancellationToken cancellationToken)
        {
            var p = new CallMuteParameter();
            return await this.SendAsync<CallMuteParameter, CallMuteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/call-mute?view=graph-rest-1.0
        /// </summary>
        public async Task<CallMuteResponse> CallMuteAsync(CallMuteParameter parameter)
        {
            return await this.SendAsync<CallMuteParameter, CallMuteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/call-mute?view=graph-rest-1.0
        /// </summary>
        public async Task<CallMuteResponse> CallMuteAsync(CallMuteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CallMuteParameter, CallMuteResponse>(parameter, cancellationToken);
        }
    }
}
