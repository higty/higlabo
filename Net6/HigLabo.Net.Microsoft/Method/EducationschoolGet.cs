using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EducationschoolGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Education_Schools_EducationSchoolId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Education_Schools_EducationSchoolId: return $"/education/schools/{EducationSchoolId}";
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
        public string EducationSchoolId { get; set; }
    }
    public partial class EducationschoolGetResponse : RestApiResponse
    {
        public enum EducationSchoolEducationExternalSource
        {
            Sis,
            Manual,
        }

        public PhysicalAddress? Address { get; set; }
        public IdentitySet? CreatedBy { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public string? ExternalId { get; set; }
        public string? ExternalPrincipalId { get; set; }
        public EducationSchoolEducationExternalSource ExternalSource { get; set; }
        public string? ExternalSourceDetail { get; set; }
        public string? HighestGrade { get; set; }
        public string? Id { get; set; }
        public string? LowestGrade { get; set; }
        public string? Phone { get; set; }
        public string? PrincipalEmail { get; set; }
        public string? PrincipalName { get; set; }
        public string? SchoolNumber { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationschool-get?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationschoolGetResponse> EducationschoolGetAsync()
        {
            var p = new EducationschoolGetParameter();
            return await this.SendAsync<EducationschoolGetParameter, EducationschoolGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationschool-get?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationschoolGetResponse> EducationschoolGetAsync(CancellationToken cancellationToken)
        {
            var p = new EducationschoolGetParameter();
            return await this.SendAsync<EducationschoolGetParameter, EducationschoolGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationschool-get?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationschoolGetResponse> EducationschoolGetAsync(EducationschoolGetParameter parameter)
        {
            return await this.SendAsync<EducationschoolGetParameter, EducationschoolGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationschool-get?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationschoolGetResponse> EducationschoolGetAsync(EducationschoolGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationschoolGetParameter, EducationschoolGetResponse>(parameter, cancellationToken);
        }
    }
}
