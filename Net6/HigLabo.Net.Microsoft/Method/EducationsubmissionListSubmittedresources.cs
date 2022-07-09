using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EducationsubmissionListSubmittedResourcesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? ClassesId { get; set; }
            public string? AssignmentsId { get; set; }
            public string? SubmissionsId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Education_Classes_Id_Assignments_Id_Submissions_Id_SubmittedResources: return $"/education/classes/{ClassesId}/assignments/{AssignmentsId}/submissions/{SubmissionsId}/submittedResources";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Education_Classes_Id_Assignments_Id_Submissions_Id_SubmittedResources,
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
    public partial class EducationsubmissionListSubmittedResourcesResponse : RestApiResponse
    {
        public EducationSubmissionResource[]? Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationsubmission-list-submittedresources?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationsubmissionListSubmittedResourcesResponse> EducationsubmissionListSubmittedResourcesAsync()
        {
            var p = new EducationsubmissionListSubmittedResourcesParameter();
            return await this.SendAsync<EducationsubmissionListSubmittedResourcesParameter, EducationsubmissionListSubmittedResourcesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationsubmission-list-submittedresources?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationsubmissionListSubmittedResourcesResponse> EducationsubmissionListSubmittedResourcesAsync(CancellationToken cancellationToken)
        {
            var p = new EducationsubmissionListSubmittedResourcesParameter();
            return await this.SendAsync<EducationsubmissionListSubmittedResourcesParameter, EducationsubmissionListSubmittedResourcesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationsubmission-list-submittedresources?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationsubmissionListSubmittedResourcesResponse> EducationsubmissionListSubmittedResourcesAsync(EducationsubmissionListSubmittedResourcesParameter parameter)
        {
            return await this.SendAsync<EducationsubmissionListSubmittedResourcesParameter, EducationsubmissionListSubmittedResourcesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationsubmission-list-submittedresources?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationsubmissionListSubmittedResourcesResponse> EducationsubmissionListSubmittedResourcesAsync(EducationsubmissionListSubmittedResourcesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationsubmissionListSubmittedResourcesParameter, EducationsubmissionListSubmittedResourcesResponse>(parameter, cancellationToken);
        }
    }
}
