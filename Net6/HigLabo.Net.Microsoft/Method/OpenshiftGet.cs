using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class OpenshiftGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Teams_Id_Schedule_OpenShifts_OpenShiftId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Teams_Id_Schedule_OpenShifts_OpenShiftId: return $"/teams/{Id}/schedule/openShifts/{OpenShiftId}";
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
        public string OpenShiftId { get; set; }
    }
    public partial class OpenshiftGetResponse : RestApiResponse
    {
        public OpenShiftItem? DraftOpenShift { get; set; }
        public string? SchedulingGroupId { get; set; }
        public OpenShiftItem? SharedOpenShift { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/openshift-get?view=graph-rest-1.0
        /// </summary>
        public async Task<OpenshiftGetResponse> OpenshiftGetAsync()
        {
            var p = new OpenshiftGetParameter();
            return await this.SendAsync<OpenshiftGetParameter, OpenshiftGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/openshift-get?view=graph-rest-1.0
        /// </summary>
        public async Task<OpenshiftGetResponse> OpenshiftGetAsync(CancellationToken cancellationToken)
        {
            var p = new OpenshiftGetParameter();
            return await this.SendAsync<OpenshiftGetParameter, OpenshiftGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/openshift-get?view=graph-rest-1.0
        /// </summary>
        public async Task<OpenshiftGetResponse> OpenshiftGetAsync(OpenshiftGetParameter parameter)
        {
            return await this.SendAsync<OpenshiftGetParameter, OpenshiftGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/openshift-get?view=graph-rest-1.0
        /// </summary>
        public async Task<OpenshiftGetResponse> OpenshiftGetAsync(OpenshiftGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OpenshiftGetParameter, OpenshiftGetResponse>(parameter, cancellationToken);
        }
    }
}
