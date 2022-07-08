using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EducationAssignmentSettingsGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Education_Classes_Id_AssignmentSettings: return $"/education/classes/{Id}/assignmentSettings";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            Id,
            SubmissionAnimationDisabled,
        }
        public enum ApiPath
        {
            Education_Classes_Id_AssignmentSettings,
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
    public partial class EducationAssignmentSettingsGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public bool? SubmissionAnimationDisabled { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationassignmentsettings-get?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationAssignmentSettingsGetResponse> EducationAssignmentSettingsGetAsync()
        {
            var p = new EducationAssignmentSettingsGetParameter();
            return await this.SendAsync<EducationAssignmentSettingsGetParameter, EducationAssignmentSettingsGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationassignmentsettings-get?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationAssignmentSettingsGetResponse> EducationAssignmentSettingsGetAsync(CancellationToken cancellationToken)
        {
            var p = new EducationAssignmentSettingsGetParameter();
            return await this.SendAsync<EducationAssignmentSettingsGetParameter, EducationAssignmentSettingsGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationassignmentsettings-get?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationAssignmentSettingsGetResponse> EducationAssignmentSettingsGetAsync(EducationAssignmentSettingsGetParameter parameter)
        {
            return await this.SendAsync<EducationAssignmentSettingsGetParameter, EducationAssignmentSettingsGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationassignmentsettings-get?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationAssignmentSettingsGetResponse> EducationAssignmentSettingsGetAsync(EducationAssignmentSettingsGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationAssignmentSettingsGetParameter, EducationAssignmentSettingsGetResponse>(parameter, cancellationToken);
        }
    }
}
