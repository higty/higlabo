using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EducationsubmittedsubmissionresourceGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Education_Classes_Id_Assignments_Id_Submissions_Id_SubmittedResources_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Education_Classes_Id_Assignments_Id_Submissions_Id_SubmittedResources_Id: return $"/education/classes/{ClassesId}/assignments/{AssignmentsId}/submissions/{SubmissionsId}/submittedResources/{SubmittedResourcesId}";
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
        public string ClassesId { get; set; }
        public string AssignmentsId { get; set; }
        public string SubmissionsId { get; set; }
        public string SubmittedResourcesId { get; set; }
    }
    public partial class EducationsubmittedsubmissionresourceGetResponse : RestApiResponse
    {
        public string? AssignmentResourceUrl { get; set; }
        public string? Id { get; set; }
        public EducationResource? Resource { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationsubmittedsubmissionresource-get?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationsubmittedsubmissionresourceGetResponse> EducationsubmittedsubmissionresourceGetAsync()
        {
            var p = new EducationsubmittedsubmissionresourceGetParameter();
            return await this.SendAsync<EducationsubmittedsubmissionresourceGetParameter, EducationsubmittedsubmissionresourceGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationsubmittedsubmissionresource-get?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationsubmittedsubmissionresourceGetResponse> EducationsubmittedsubmissionresourceGetAsync(CancellationToken cancellationToken)
        {
            var p = new EducationsubmittedsubmissionresourceGetParameter();
            return await this.SendAsync<EducationsubmittedsubmissionresourceGetParameter, EducationsubmittedsubmissionresourceGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationsubmittedsubmissionresource-get?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationsubmittedsubmissionresourceGetResponse> EducationsubmittedsubmissionresourceGetAsync(EducationsubmittedsubmissionresourceGetParameter parameter)
        {
            return await this.SendAsync<EducationsubmittedsubmissionresourceGetParameter, EducationsubmittedsubmissionresourceGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationsubmittedsubmissionresource-get?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationsubmittedsubmissionresourceGetResponse> EducationsubmittedsubmissionresourceGetAsync(EducationsubmittedsubmissionresourceGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationsubmittedsubmissionresourceGetParameter, EducationsubmittedsubmissionresourceGetResponse>(parameter, cancellationToken);
        }
    }
}
