using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EducationassignmentsettingsGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Education_Classes_Id_AssignmentSettings,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Education_Classes_Id_AssignmentSettings: return $"/education/classes/{Id}/assignmentSettings";
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
    public partial class EducationassignmentsettingsGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public bool? SubmissionAnimationDisabled { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationassignmentsettings-get?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationassignmentsettingsGetResponse> EducationassignmentsettingsGetAsync()
        {
            var p = new EducationassignmentsettingsGetParameter();
            return await this.SendAsync<EducationassignmentsettingsGetParameter, EducationassignmentsettingsGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationassignmentsettings-get?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationassignmentsettingsGetResponse> EducationassignmentsettingsGetAsync(CancellationToken cancellationToken)
        {
            var p = new EducationassignmentsettingsGetParameter();
            return await this.SendAsync<EducationassignmentsettingsGetParameter, EducationassignmentsettingsGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationassignmentsettings-get?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationassignmentsettingsGetResponse> EducationassignmentsettingsGetAsync(EducationassignmentsettingsGetParameter parameter)
        {
            return await this.SendAsync<EducationassignmentsettingsGetParameter, EducationassignmentsettingsGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationassignmentsettings-get?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationassignmentsettingsGetResponse> EducationassignmentsettingsGetAsync(EducationassignmentsettingsGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationassignmentsettingsGetParameter, EducationassignmentsettingsGetResponse>(parameter, cancellationToken);
        }
    }
}
