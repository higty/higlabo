using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/plannerplandetails-get?view=graph-rest-1.0
    /// </summary>
    public partial class PlannerplandetailsGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Planner_Plans_Id_Details: return $"/planner/plans/{Id}/details";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Planner_Plans_Id_Details,
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
    public partial class PlannerplandetailsGetResponse : RestApiResponse
    {
        public PlannerCategoryDescriptions? CategoryDescriptions { get; set; }
        public string? Id { get; set; }
        public PlannerUserIds? SharedWith { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/plannerplandetails-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/plannerplandetails-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PlannerplandetailsGetResponse> PlannerplandetailsGetAsync()
        {
            var p = new PlannerplandetailsGetParameter();
            return await this.SendAsync<PlannerplandetailsGetParameter, PlannerplandetailsGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/plannerplandetails-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PlannerplandetailsGetResponse> PlannerplandetailsGetAsync(CancellationToken cancellationToken)
        {
            var p = new PlannerplandetailsGetParameter();
            return await this.SendAsync<PlannerplandetailsGetParameter, PlannerplandetailsGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/plannerplandetails-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PlannerplandetailsGetResponse> PlannerplandetailsGetAsync(PlannerplandetailsGetParameter parameter)
        {
            return await this.SendAsync<PlannerplandetailsGetParameter, PlannerplandetailsGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/plannerplandetails-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PlannerplandetailsGetResponse> PlannerplandetailsGetAsync(PlannerplandetailsGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PlannerplandetailsGetParameter, PlannerplandetailsGetResponse>(parameter, cancellationToken);
        }
    }
}
