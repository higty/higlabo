using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class OpenshiftchangerequestDeclineParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Teams_Id_Schedule_OpenShiftChangeRequests_OpenShiftChangeRequestId_Decline,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Teams_Id_Schedule_OpenShiftChangeRequests_OpenShiftChangeRequestId_Decline: return $"/teams/{Id}/schedule/openShiftChangeRequests/{OpenShiftChangeRequestId}/decline";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Message { get; set; }
        public string Id { get; set; }
        public string OpenShiftChangeRequestId { get; set; }
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
