using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationclass-get?view=graph-rest-1.0
    /// </summary>
    public partial class EducationclassGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Education_Classes_Id: return $"/education/classes/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Education_Classes_Id,
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
    public partial class EducationclassGetResponse : RestApiResponse
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
    /// https://learn.microsoft.com/en-us/graph/api/educationclass-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationclass-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationclassGetResponse> EducationclassGetAsync()
        {
            var p = new EducationclassGetParameter();
            return await this.SendAsync<EducationclassGetParameter, EducationclassGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationclass-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationclassGetResponse> EducationclassGetAsync(CancellationToken cancellationToken)
        {
            var p = new EducationclassGetParameter();
            return await this.SendAsync<EducationclassGetParameter, EducationclassGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationclass-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationclassGetResponse> EducationclassGetAsync(EducationclassGetParameter parameter)
        {
            return await this.SendAsync<EducationclassGetParameter, EducationclassGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationclass-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationclassGetResponse> EducationclassGetAsync(EducationclassGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationclassGetParameter, EducationclassGetResponse>(parameter, cancellationToken);
        }
    }
}
