
namespace HigLabo.Net.Slack
{
    public class ApiTestParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "api.test";
        public string HttpMethod { get; private set; } = "POST";
        public string Error { get; set; } = "";
    }
    public partial class ApiTestResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<ApiTestResponse> ApiTestAsync()
        {
            var p = new ApiTestParameter();
            return await this.SendAsync<ApiTestParameter, ApiTestResponse>(p, CancellationToken.None);
        }
        public async Task<ApiTestResponse> ApiTestAsync(CancellationToken cancellationToken)
        {
            var p = new ApiTestParameter();
            return await this.SendAsync<ApiTestParameter, ApiTestResponse>(p, cancellationToken);
        }
        public async Task<ApiTestResponse> ApiTestAsync(ApiTestParameter parameter)
        {
            return await this.SendAsync<ApiTestParameter, ApiTestResponse>(parameter, CancellationToken.None);
        }
        public async Task<ApiTestResponse> ApiTestAsync(ApiTestParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ApiTestParameter, ApiTestResponse>(parameter, cancellationToken);
        }
    }
}
