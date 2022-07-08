using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class OpenshiftchangerequestPostParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Teams_Id_Schedule_OpenShiftChangeRequests: return $"/teams/{Id}/schedule/openShiftChangeRequests";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Teams_Id_Schedule_OpenShiftChangeRequests,
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
        public string? OpenShiftId { get; set; }
    }
    public partial class OpenshiftchangerequestPostResponse : RestApiResponse
    {
        public string? OpenShiftId { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/openshiftchangerequest-post?view=graph-rest-1.0
        /// </summary>
        public async Task<OpenshiftchangerequestPostResponse> OpenshiftchangerequestPostAsync()
        {
            var p = new OpenshiftchangerequestPostParameter();
            return await this.SendAsync<OpenshiftchangerequestPostParameter, OpenshiftchangerequestPostResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/openshiftchangerequest-post?view=graph-rest-1.0
        /// </summary>
        public async Task<OpenshiftchangerequestPostResponse> OpenshiftchangerequestPostAsync(CancellationToken cancellationToken)
        {
            var p = new OpenshiftchangerequestPostParameter();
            return await this.SendAsync<OpenshiftchangerequestPostParameter, OpenshiftchangerequestPostResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/openshiftchangerequest-post?view=graph-rest-1.0
        /// </summary>
        public async Task<OpenshiftchangerequestPostResponse> OpenshiftchangerequestPostAsync(OpenshiftchangerequestPostParameter parameter)
        {
            return await this.SendAsync<OpenshiftchangerequestPostParameter, OpenshiftchangerequestPostResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/openshiftchangerequest-post?view=graph-rest-1.0
        /// </summary>
        public async Task<OpenshiftchangerequestPostResponse> OpenshiftchangerequestPostAsync(OpenshiftchangerequestPostParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OpenshiftchangerequestPostParameter, OpenshiftchangerequestPostResponse>(parameter, cancellationToken);
        }
    }
}
