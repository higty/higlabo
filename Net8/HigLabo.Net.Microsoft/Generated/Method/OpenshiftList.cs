using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/openshift-list?view=graph-rest-1.0
    /// </summary>
    public partial class OpenShiftListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Teams_Id_Schedule_OpenShifts: return $"/teams/{Id}/schedule/openShifts";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Teams_Id_Schedule_OpenShifts,
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
    public partial class OpenShiftListResponse : RestApiResponse
    {
        public OpenShiftItem? DraftOpenShift { get; set; }
        public string? SchedulingGroupId { get; set; }
        public OpenShiftItem? SharedOpenShift { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/openshift-list?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/openshift-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OpenShiftListResponse> OpenShiftListAsync()
        {
            var p = new OpenShiftListParameter();
            return await this.SendAsync<OpenShiftListParameter, OpenShiftListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/openshift-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OpenShiftListResponse> OpenShiftListAsync(CancellationToken cancellationToken)
        {
            var p = new OpenShiftListParameter();
            return await this.SendAsync<OpenShiftListParameter, OpenShiftListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/openshift-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OpenShiftListResponse> OpenShiftListAsync(OpenShiftListParameter parameter)
        {
            return await this.SendAsync<OpenShiftListParameter, OpenShiftListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/openshift-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OpenShiftListResponse> OpenShiftListAsync(OpenShiftListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OpenShiftListParameter, OpenShiftListResponse>(parameter, cancellationToken);
        }
    }
}
