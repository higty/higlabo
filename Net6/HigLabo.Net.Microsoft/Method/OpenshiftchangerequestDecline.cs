using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class OpenshiftchangerequestDeclineParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string Id { get; set; }
            public string OpenShiftChangeRequestId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Teams_Id_Schedule_OpenShiftChangeRequests_OpenShiftChangeRequestId_Decline: return $"/teams/{Id}/schedule/openShiftChangeRequests/{OpenShiftChangeRequestId}/decline";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Teams_Id_Schedule_OpenShiftChangeRequests_OpenShiftChangeRequestId_Decline,
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
        public string? Message { get; set; }
    }
    public partial class OpenshiftchangerequestDeclineResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/openshiftchangerequest-decline?view=graph-rest-1.0
        /// </summary>
        public async Task<OpenshiftchangerequestDeclineResponse> OpenshiftchangerequestDeclineAsync()
        {
            var p = new OpenshiftchangerequestDeclineParameter();
            return await this.SendAsync<OpenshiftchangerequestDeclineParameter, OpenshiftchangerequestDeclineResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/openshiftchangerequest-decline?view=graph-rest-1.0
        /// </summary>
        public async Task<OpenshiftchangerequestDeclineResponse> OpenshiftchangerequestDeclineAsync(CancellationToken cancellationToken)
        {
            var p = new OpenshiftchangerequestDeclineParameter();
            return await this.SendAsync<OpenshiftchangerequestDeclineParameter, OpenshiftchangerequestDeclineResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/openshiftchangerequest-decline?view=graph-rest-1.0
        /// </summary>
        public async Task<OpenshiftchangerequestDeclineResponse> OpenshiftchangerequestDeclineAsync(OpenshiftchangerequestDeclineParameter parameter)
        {
            return await this.SendAsync<OpenshiftchangerequestDeclineParameter, OpenshiftchangerequestDeclineResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/openshiftchangerequest-decline?view=graph-rest-1.0
        /// </summary>
        public async Task<OpenshiftchangerequestDeclineResponse> OpenshiftchangerequestDeclineAsync(OpenshiftchangerequestDeclineParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OpenshiftchangerequestDeclineParameter, OpenshiftchangerequestDeclineResponse>(parameter, cancellationToken);
        }
    }
}
