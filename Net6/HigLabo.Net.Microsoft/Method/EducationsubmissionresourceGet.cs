using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EducationsubmissionResourceGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? ClassId { get; set; }
            public string? AssignmentId { get; set; }
            public string? SubmissionId { get; set; }
            public string? ResourceId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Education_Classes_ClassId_Assignments_AssignmentId_Submissions_SubmissionId_Resources_ResourceId: return $"/education/classes/{ClassId}/assignments/{AssignmentId}/submissions/{SubmissionId}/resources/{ResourceId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Education_Classes_ClassId_Assignments_AssignmentId_Submissions_SubmissionId_Resources_ResourceId,
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
    public partial class EducationsubmissionResourceGetResponse : RestApiResponse
    {
        public string? AssignmentResourceUrl { get; set; }
        public string? Id { get; set; }
        public EducationResource? Resource { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationsubmissionresource-get?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationsubmissionResourceGetResponse> EducationsubmissionResourceGetAsync()
        {
            var p = new EducationsubmissionResourceGetParameter();
            return await this.SendAsync<EducationsubmissionResourceGetParameter, EducationsubmissionResourceGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationsubmissionresource-get?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationsubmissionResourceGetResponse> EducationsubmissionResourceGetAsync(CancellationToken cancellationToken)
        {
            var p = new EducationsubmissionResourceGetParameter();
            return await this.SendAsync<EducationsubmissionResourceGetParameter, EducationsubmissionResourceGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationsubmissionresource-get?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationsubmissionResourceGetResponse> EducationsubmissionResourceGetAsync(EducationsubmissionResourceGetParameter parameter)
        {
            return await this.SendAsync<EducationsubmissionResourceGetParameter, EducationsubmissionResourceGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationsubmissionresource-get?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationsubmissionResourceGetResponse> EducationsubmissionResourceGetAsync(EducationsubmissionResourceGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationsubmissionResourceGetParameter, EducationsubmissionResourceGetResponse>(parameter, cancellationToken);
        }
    }
}
