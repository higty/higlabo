using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EducationschoolPostParameter : IRestApiParameter
    {
        public enum EducationschoolPostParameterEducationExternalSource
        {
            Sis,
        }
        public enum ApiPath
        {
            Education_Schools,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Education_Schools: return $"/education/schools";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public EducationschoolPostParameterEducationExternalSource ExternalSource { get; set; }
        public string? ExternalSourceDetail { get; set; }
        public string? PrincipalEmail { get; set; }
        public string? PrincipalName { get; set; }
        public string? ExternalPrincipalId { get; set; }
        public string? HighestGrade { get; set; }
        public string? LowestGrade { get; set; }
        public string? SchoolNumber { get; set; }
        public string? ExternalId { get; set; }
        public string? Phone { get; set; }
        public string? Fax { get; set; }
        public IdentitySet? CreatedBy { get; set; }
        public PhysicalAddress? Address { get; set; }
    }
    public partial class EducationschoolPostResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/educationschool-post?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationschoolPostResponse> EducationschoolPostAsync()
        {
            var p = new EducationschoolPostParameter();
            return await this.SendAsync<EducationschoolPostParameter, EducationschoolPostResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationschool-post?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationschoolPostResponse> EducationschoolPostAsync(CancellationToken cancellationToken)
        {
            var p = new EducationschoolPostParameter();
            return await this.SendAsync<EducationschoolPostParameter, EducationschoolPostResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationschool-post?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationschoolPostResponse> EducationschoolPostAsync(EducationschoolPostParameter parameter)
        {
            return await this.SendAsync<EducationschoolPostParameter, EducationschoolPostResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationschool-post?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationschoolPostResponse> EducationschoolPostAsync(EducationschoolPostParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationschoolPostParameter, EducationschoolPostResponse>(parameter, cancellationToken);
        }
    }
}
