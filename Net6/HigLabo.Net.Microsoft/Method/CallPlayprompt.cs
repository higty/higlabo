using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class CallPlaypromptParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Communications_Calls_Id_PlayPrompt: return $"/communications/calls/{Id}/playPrompt";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Communications_Calls_Id_PlayPrompt,
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
        public string? ClientContext { get; set; }
        public string? Id { get; set; }
        public ResultInfo? ResultInfo { get; set; }
        public string? Status { get; set; }
    }
    public partial class CallPlaypromptResponse : RestApiResponse
    {
        public string? ClientContext { get; set; }
        public string? Id { get; set; }
        public ResultInfo? ResultInfo { get; set; }
        public string? Status { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/call-playprompt?view=graph-rest-1.0
        /// </summary>
        public async Task<CallPlaypromptResponse> CallPlaypromptAsync()
        {
            var p = new CallPlaypromptParameter();
            return await this.SendAsync<CallPlaypromptParameter, CallPlaypromptResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/call-playprompt?view=graph-rest-1.0
        /// </summary>
        public async Task<CallPlaypromptResponse> CallPlaypromptAsync(CancellationToken cancellationToken)
        {
            var p = new CallPlaypromptParameter();
            return await this.SendAsync<CallPlaypromptParameter, CallPlaypromptResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/call-playprompt?view=graph-rest-1.0
        /// </summary>
        public async Task<CallPlaypromptResponse> CallPlaypromptAsync(CallPlaypromptParameter parameter)
        {
            return await this.SendAsync<CallPlaypromptParameter, CallPlaypromptResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/call-playprompt?view=graph-rest-1.0
        /// </summary>
        public async Task<CallPlaypromptResponse> CallPlaypromptAsync(CallPlaypromptParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CallPlaypromptParameter, CallPlaypromptResponse>(parameter, cancellationToken);
        }
    }
}
