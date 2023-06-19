using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationclass-post-members?view=graph-rest-1.0
    /// </summary>
    public partial class EducationclassPostMembersParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Education_Classes_Id_Members_ref: return $"/education/classes/{Id}/members/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum EducationClassEducationExternalSource
        {
            Sis,
            Manual,
        }
        public enum ApiPath
        {
            Education_Classes_Id_Members_ref,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? ClassCode { get; set; }
        public IdentitySet? CreatedBy { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public string? ExternalId { get; set; }
        public EducationClassEducationExternalSource ExternalSource { get; set; }
        public string? ExternalSourceDetail { get; set; }
        public string? ExternalName { get; set; }
        public string? Grade { get; set; }
        public string? Id { get; set; }
        public string? MailNickname { get; set; }
        public EducationTerm? Term { get; set; }
        public EducationAssignment[]? Assignments { get; set; }
        public EducationCategory[]? AssignmentCategories { get; set; }
        public EducationAssignmentDefaults[]? AssignmentDefaults { get; set; }
        public EducationAssignmentSettings[]? AssignmentSettings { get; set; }
        public Group? Group { get; set; }
        public EducationUser[]? Members { get; set; }
        public EducationSchool[]? Schools { get; set; }
        public EducationUser[]? Teachers { get; set; }
    }
    public partial class EducationclassPostMembersResponse : RestApiResponse
    {
        public enum EducationClassEducationExternalSource
        {
            Sis,
            Manual,
        }

        public string? ClassCode { get; set; }
        public IdentitySet? CreatedBy { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public string? ExternalId { get; set; }
        public EducationClassEducationExternalSource ExternalSource { get; set; }
        public string? ExternalSourceDetail { get; set; }
        public string? ExternalName { get; set; }
        public string? Grade { get; set; }
        public string? Id { get; set; }
        public string? MailNickname { get; set; }
        public EducationTerm? Term { get; set; }
        public EducationAssignment[]? Assignments { get; set; }
        public EducationCategory[]? AssignmentCategories { get; set; }
        public EducationAssignmentDefaults[]? AssignmentDefaults { get; set; }
        public EducationAssignmentSettings[]? AssignmentSettings { get; set; }
        public Group? Group { get; set; }
        public EducationUser[]? Members { get; set; }
        public EducationSchool[]? Schools { get; set; }
        public EducationUser[]? Teachers { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationclass-post-members?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationclass-post-members?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationclassPostMembersResponse> EducationclassPostMembersAsync()
        {
            var p = new EducationclassPostMembersParameter();
            return await this.SendAsync<EducationclassPostMembersParameter, EducationclassPostMembersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationclass-post-members?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationclassPostMembersResponse> EducationclassPostMembersAsync(CancellationToken cancellationToken)
        {
            var p = new EducationclassPostMembersParameter();
            return await this.SendAsync<EducationclassPostMembersParameter, EducationclassPostMembersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationclass-post-members?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationclassPostMembersResponse> EducationclassPostMembersAsync(EducationclassPostMembersParameter parameter)
        {
            return await this.SendAsync<EducationclassPostMembersParameter, EducationclassPostMembersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationclass-post-members?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationclassPostMembersResponse> EducationclassPostMembersAsync(EducationclassPostMembersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationclassPostMembersParameter, EducationclassPostMembersResponse>(parameter, cancellationToken);
        }
    }
}
