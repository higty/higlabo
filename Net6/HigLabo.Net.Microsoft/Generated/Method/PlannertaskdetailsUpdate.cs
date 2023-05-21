using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/plannertaskdetails-update?view=graph-rest-1.0
    /// </summary>
    public partial class PlannertaskdetailsUpdateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Planner_Tasks_Id_Details: return $"/planner/tasks/{Id}/details";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum PlannertaskdetailsUpdateParameterstring
        {
            Automatic,
            NoPreview,
            Checklist,
            Description,
            Reference,
        }
        public enum ApiPath
        {
            Planner_Tasks_Id_Details,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
        public PlannerChecklistItems? Checklist { get; set; }
        public string? Description { get; set; }
        public PlannertaskdetailsUpdateParameterstring PreviewType { get; set; }
        public PlannerExternalReferences? References { get; set; }
    }
    public partial class PlannertaskdetailsUpdateResponse : RestApiResponse
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
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/plannertaskdetails-update?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/plannertaskdetails-update?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannertaskdetailsUpdateResponse> PlannertaskdetailsUpdateAsync()
        {
            var p = new PlannertaskdetailsUpdateParameter();
            return await this.SendAsync<PlannertaskdetailsUpdateParameter, PlannertaskdetailsUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/plannertaskdetails-update?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannertaskdetailsUpdateResponse> PlannertaskdetailsUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new PlannertaskdetailsUpdateParameter();
            return await this.SendAsync<PlannertaskdetailsUpdateParameter, PlannertaskdetailsUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/plannertaskdetails-update?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannertaskdetailsUpdateResponse> PlannertaskdetailsUpdateAsync(PlannertaskdetailsUpdateParameter parameter)
        {
            return await this.SendAsync<PlannertaskdetailsUpdateParameter, PlannertaskdetailsUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/plannertaskdetails-update?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannertaskdetailsUpdateResponse> PlannertaskdetailsUpdateAsync(PlannertaskdetailsUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PlannertaskdetailsUpdateParameter, PlannertaskdetailsUpdateResponse>(parameter, cancellationToken);
        }
    }
}
