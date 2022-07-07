using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class OpenshiftListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Teams_Id_Schedule_OpenShifts,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Teams_Id_Schedule_OpenShifts: return $"/teams/{Id}/schedule/openShifts";
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
    public partial class OpenshiftListResponse : RestApiResponse
    {
        public OpenShiftItem? DraftOpenShift { get; set; }
        public string? SchedulingGroupId { get; set; }
        public OpenShiftItem? SharedOpenShift { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/openshift-list?view=graph-rest-1.0
        /// </summary>
        public async Task<OpenshiftListResponse> OpenshiftListAsync()
        {
            var p = new OpenshiftListParameter();
            return await this.SendAsync<OpenshiftListParameter, OpenshiftListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/openshift-list?view=graph-rest-1.0
        /// </summary>
        public async Task<OpenshiftListResponse> OpenshiftListAsync(CancellationToken cancellationToken)
        {
            var p = new OpenshiftListParameter();
            return await this.SendAsync<OpenshiftListParameter, OpenshiftListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/openshift-list?view=graph-rest-1.0
        /// </summary>
        public async Task<OpenshiftListResponse> OpenshiftListAsync(OpenshiftListParameter parameter)
        {
            return await this.SendAsync<OpenshiftListParameter, OpenshiftListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/openshift-list?view=graph-rest-1.0
        /// </summary>
        public async Task<OpenshiftListResponse> OpenshiftListAsync(OpenshiftListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OpenshiftListParameter, OpenshiftListResponse>(parameter, cancellationToken);
        }
    }
}
