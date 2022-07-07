using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PlannertaskdetailsGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Planner_Tasks_Id_Details,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Planner_Tasks_Id_Details: return $"/planner/tasks/{Id}/details";
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
    public partial class PlannertaskdetailsGetResponse : RestApiResponse
    {
        public enum PlannerTaskDetailsstring
        {
            Automatic,
            NoPreview,
            Checklist,
            Description,
            Reference,
        }

        public PlannerChecklistItems? Checklist { get; set; }
        public string? Description { get; set; }
        public string? Id { get; set; }
        public PlannerTaskDetailsstring PreviewType { get; set; }
        public PlannerExternalReferences? References { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/plannertaskdetails-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannertaskdetailsGetResponse> PlannertaskdetailsGetAsync()
        {
            var p = new PlannertaskdetailsGetParameter();
            return await this.SendAsync<PlannertaskdetailsGetParameter, PlannertaskdetailsGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/plannertaskdetails-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannertaskdetailsGetResponse> PlannertaskdetailsGetAsync(CancellationToken cancellationToken)
        {
            var p = new PlannertaskdetailsGetParameter();
            return await this.SendAsync<PlannertaskdetailsGetParameter, PlannertaskdetailsGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/plannertaskdetails-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannertaskdetailsGetResponse> PlannertaskdetailsGetAsync(PlannertaskdetailsGetParameter parameter)
        {
            return await this.SendAsync<PlannertaskdetailsGetParameter, PlannertaskdetailsGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/plannertaskdetails-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannertaskdetailsGetResponse> PlannertaskdetailsGetAsync(PlannertaskdetailsGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PlannertaskdetailsGetParameter, PlannertaskdetailsGetResponse>(parameter, cancellationToken);
        }
    }
}
