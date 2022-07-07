using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class OpenshiftchangerequestListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Teams_Id_Schedule_OpenShiftChangeRequests,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Teams_Id_Schedule_OpenShiftChangeRequests: return $"/teams/{Id}/schedule/openShiftChangeRequests";
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
    }
    public partial class OpenshiftchangerequestListResponse : RestApiResponse
    {
        public string? OpenShiftId { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/openshiftchangerequest-list?view=graph-rest-1.0
        /// </summary>
        public async Task<OpenshiftchangerequestListResponse> OpenshiftchangerequestListAsync()
        {
            var p = new OpenshiftchangerequestListParameter();
            return await this.SendAsync<OpenshiftchangerequestListParameter, OpenshiftchangerequestListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/openshiftchangerequest-list?view=graph-rest-1.0
        /// </summary>
        public async Task<OpenshiftchangerequestListResponse> OpenshiftchangerequestListAsync(CancellationToken cancellationToken)
        {
            var p = new OpenshiftchangerequestListParameter();
            return await this.SendAsync<OpenshiftchangerequestListParameter, OpenshiftchangerequestListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/openshiftchangerequest-list?view=graph-rest-1.0
        /// </summary>
        public async Task<OpenshiftchangerequestListResponse> OpenshiftchangerequestListAsync(OpenshiftchangerequestListParameter parameter)
        {
            return await this.SendAsync<OpenshiftchangerequestListParameter, OpenshiftchangerequestListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/openshiftchangerequest-list?view=graph-rest-1.0
        /// </summary>
        public async Task<OpenshiftchangerequestListResponse> OpenshiftchangerequestListAsync(OpenshiftchangerequestListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OpenshiftchangerequestListParameter, OpenshiftchangerequestListResponse>(parameter, cancellationToken);
        }
    }
}
