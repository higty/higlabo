using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class CallAnswerParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Communications_Calls_Id_Answer: return $"/communications/calls/{Id}/answer";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum CallAnswerParameterString
        {
            Audio,
            Video,
            VideoBasedScreenSharing,
        }
        public enum ApiPath
        {
            Communications_Calls_Id_Answer,
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
        public string? CallbackUri { get; set; }
        public CallAnswerParameterString AcceptedModalities { get; set; }
        public AppHostedMediaConfig? MediaConfig { get; set; }
        public int? ParticipantCapacity { get; set; }
    }
    public partial class CallAnswerResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/call-answer?view=graph-rest-1.0
        /// </summary>
        public async Task<CallAnswerResponse> CallAnswerAsync()
        {
            var p = new CallAnswerParameter();
            return await this.SendAsync<CallAnswerParameter, CallAnswerResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/call-answer?view=graph-rest-1.0
        /// </summary>
        public async Task<CallAnswerResponse> CallAnswerAsync(CancellationToken cancellationToken)
        {
            var p = new CallAnswerParameter();
            return await this.SendAsync<CallAnswerParameter, CallAnswerResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/call-answer?view=graph-rest-1.0
        /// </summary>
        public async Task<CallAnswerResponse> CallAnswerAsync(CallAnswerParameter parameter)
        {
            return await this.SendAsync<CallAnswerParameter, CallAnswerResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/call-answer?view=graph-rest-1.0
        /// </summary>
        public async Task<CallAnswerResponse> CallAnswerAsync(CallAnswerParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CallAnswerParameter, CallAnswerResponse>(parameter, cancellationToken);
        }
    }
}
