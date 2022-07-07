using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class OpenshiftchangerequestApproveParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Teams_Id_Schedule_OpenShiftChangeRequests_OpenShiftChangeRequestId_Approve,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Teams_Id_Schedule_OpenShiftChangeRequests_OpenShiftChangeRequestId_Approve: return $"/teams/{Id}/schedule/openShiftChangeRequests/{OpenShiftChangeRequestId}/approve";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Message { get; set; }
        public string Id { get; set; }
        public string OpenShiftChangeRequestId { get; set; }
    }
    public partial class OpenshiftchangerequestApproveResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/openshiftchangerequest-approve?view=graph-rest-1.0
        /// </summary>
        public async Task<OpenshiftchangerequestApproveResponse> OpenshiftchangerequestApproveAsync()
        {
            var p = new OpenshiftchangerequestApproveParameter();
            return await this.SendAsync<OpenshiftchangerequestApproveParameter, OpenshiftchangerequestApproveResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/openshiftchangerequest-approve?view=graph-rest-1.0
        /// </summary>
        public async Task<OpenshiftchangerequestApproveResponse> OpenshiftchangerequestApproveAsync(CancellationToken cancellationToken)
        {
            var p = new OpenshiftchangerequestApproveParameter();
            return await this.SendAsync<OpenshiftchangerequestApproveParameter, OpenshiftchangerequestApproveResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/openshiftchangerequest-approve?view=graph-rest-1.0
        /// </summary>
        public async Task<OpenshiftchangerequestApproveResponse> OpenshiftchangerequestApproveAsync(OpenshiftchangerequestApproveParameter parameter)
        {
            return await this.SendAsync<OpenshiftchangerequestApproveParameter, OpenshiftchangerequestApproveResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/openshiftchangerequest-approve?view=graph-rest-1.0
        /// </summary>
        public async Task<OpenshiftchangerequestApproveResponse> OpenshiftchangerequestApproveAsync(OpenshiftchangerequestApproveParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OpenshiftchangerequestApproveParameter, OpenshiftchangerequestApproveResponse>(parameter, cancellationToken);
        }
    }
}
