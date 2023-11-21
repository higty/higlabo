using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    /// <summary>
    /// https://api.slack.com/methods/api.test
    /// </summary>
    public partial class ApiTestParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "api.test";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Error { get; set; }
    }
    public partial class ApiTestResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/api.test
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/api.test
        /// </summary>
        public async ValueTask<ApiTestResponse> ApiTestAsync()
        {
            var p = new ApiTestParameter();
            return await this.SendAsync<ApiTestParameter, ApiTestResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/api.test
        /// </summary>
        public async ValueTask<ApiTestResponse> ApiTestAsync(CancellationToken cancellationToken)
        {
            var p = new ApiTestParameter();
            return await this.SendAsync<ApiTestParameter, ApiTestResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/api.test
        /// </summary>
        public async ValueTask<ApiTestResponse> ApiTestAsync(ApiTestParameter parameter)
        {
            return await this.SendAsync<ApiTestParameter, ApiTestResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/api.test
        /// </summary>
        public async ValueTask<ApiTestResponse> ApiTestAsync(ApiTestParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ApiTestParameter, ApiTestResponse>(parameter, cancellationToken);
        }
    }
}
