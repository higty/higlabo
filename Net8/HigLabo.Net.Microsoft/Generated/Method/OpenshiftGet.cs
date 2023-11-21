using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/openshift-get?view=graph-rest-1.0
    /// </summary>
    public partial class OpenshiftGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }
            public string? OpenShiftId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Teams_Id_Schedule_OpenShifts_OpenShiftId: return $"/teams/{Id}/schedule/openShifts/{OpenShiftId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Teams_Id_Schedule_OpenShifts_OpenShiftId,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
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
    }
    public partial class OpenshiftGetResponse : RestApiResponse
    {
        public OpenShiftItem? DraftOpenShift { get; set; }
        public string? SchedulingGroupId { get; set; }
        public OpenShiftItem? SharedOpenShift { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/openshift-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/openshift-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OpenshiftGetResponse> OpenshiftGetAsync()
        {
            var p = new OpenshiftGetParameter();
            return await this.SendAsync<OpenshiftGetParameter, OpenshiftGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/openshift-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OpenshiftGetResponse> OpenshiftGetAsync(CancellationToken cancellationToken)
        {
            var p = new OpenshiftGetParameter();
            return await this.SendAsync<OpenshiftGetParameter, OpenshiftGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/openshift-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OpenshiftGetResponse> OpenshiftGetAsync(OpenshiftGetParameter parameter)
        {
            return await this.SendAsync<OpenshiftGetParameter, OpenshiftGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/openshift-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OpenshiftGetResponse> OpenshiftGetAsync(OpenshiftGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OpenshiftGetParameter, OpenshiftGetResponse>(parameter, cancellationToken);
        }
    }
}
