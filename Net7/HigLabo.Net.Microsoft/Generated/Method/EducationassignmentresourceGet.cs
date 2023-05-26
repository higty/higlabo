using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationassignmentresource-get?view=graph-rest-1.0
    /// </summary>
    public partial class EducationAssignmentResourceGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? ClassId { get; set; }
            public string? AssignmentId { get; set; }
            public string? ResourceId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Education_Classes_ClassId_Assignments_AssignmentId_Resources_ResourceId: return $"/education/classes/{ClassId}/assignments/{AssignmentId}/resources/{ResourceId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Education_Classes_ClassId_Assignments_AssignmentId_Resources_ResourceId,
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
    public partial class EducationAssignmentResourceGetResponse : RestApiResponse
    {
        public bool? DistributeForStudentWork { get; set; }
        public string? Id { get; set; }
        public EducationResource? Resource { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationassignmentresource-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationassignmentresource-get?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationAssignmentResourceGetResponse> EducationAssignmentResourceGetAsync()
        {
            var p = new EducationAssignmentResourceGetParameter();
            return await this.SendAsync<EducationAssignmentResourceGetParameter, EducationAssignmentResourceGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationassignmentresource-get?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationAssignmentResourceGetResponse> EducationAssignmentResourceGetAsync(CancellationToken cancellationToken)
        {
            var p = new EducationAssignmentResourceGetParameter();
            return await this.SendAsync<EducationAssignmentResourceGetParameter, EducationAssignmentResourceGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationassignmentresource-get?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationAssignmentResourceGetResponse> EducationAssignmentResourceGetAsync(EducationAssignmentResourceGetParameter parameter)
        {
            return await this.SendAsync<EducationAssignmentResourceGetParameter, EducationAssignmentResourceGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationassignmentresource-get?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationAssignmentResourceGetResponse> EducationAssignmentResourceGetAsync(EducationAssignmentResourceGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationAssignmentResourceGetParameter, EducationAssignmentResourceGetResponse>(parameter, cancellationToken);
        }
    }
}
