using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class OpenshiftchangerequestGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Teams_Id_Schedule_OpenShiftChangeRequests_OpenShiftsChangeRequestId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Teams_Id_Schedule_OpenShiftChangeRequests_OpenShiftsChangeRequestId: return $"/teams/{Id}/schedule/openShiftChangeRequests/{OpenShiftsChangeRequestId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
        public string Id { get; set; }
        public string OpenShiftsChangeRequestId { get; set; }
    }
    public partial class OpenshiftchangerequestGetResponse : RestApiResponse
    {
        public string? OpenShiftId { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/openshiftchangerequest-get?view=graph-rest-1.0
        /// </summary>
        public async Task<OpenshiftchangerequestGetResponse> OpenshiftchangerequestGetAsync()
        {
            var p = new OpenshiftchangerequestGetParameter();
            return await this.SendAsync<OpenshiftchangerequestGetParameter, OpenshiftchangerequestGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/openshiftchangerequest-get?view=graph-rest-1.0
        /// </summary>
        public async Task<OpenshiftchangerequestGetResponse> OpenshiftchangerequestGetAsync(CancellationToken cancellationToken)
        {
            var p = new OpenshiftchangerequestGetParameter();
            return await this.SendAsync<OpenshiftchangerequestGetParameter, OpenshiftchangerequestGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/openshiftchangerequest-get?view=graph-rest-1.0
        /// </summary>
        public async Task<OpenshiftchangerequestGetResponse> OpenshiftchangerequestGetAsync(OpenshiftchangerequestGetParameter parameter)
        {
            return await this.SendAsync<OpenshiftchangerequestGetParameter, OpenshiftchangerequestGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/openshiftchangerequest-get?view=graph-rest-1.0
        /// </summary>
        public async Task<OpenshiftchangerequestGetResponse> OpenshiftchangerequestGetAsync(OpenshiftchangerequestGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OpenshiftchangerequestGetParameter, OpenshiftchangerequestGetResponse>(parameter, cancellationToken);
        }
    }
}
