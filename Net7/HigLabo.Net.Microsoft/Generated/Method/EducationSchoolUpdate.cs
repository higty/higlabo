using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationschool-update?view=graph-rest-1.0
    /// </summary>
    public partial class EducationSchoolUpdateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Education_Schools_Id: return $"/education/schools/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum EducationSchoolUpdateParameterEducationExternalSource
        {
            Sis,
            Manual,
        }
        public enum ApiPath
        {
            Education_Schools_Id,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public EducationSchoolUpdateParameterEducationExternalSource ExternalSource { get; set; }
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
    public partial class EducationSchoolUpdateResponse : RestApiResponse
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
        public AdministrativeUnit? AdministrativeUnit { get; set; }
        public EducationClass[]? Classes { get; set; }
        public EducationUser[]? Users { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationschool-update?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationschool-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationSchoolUpdateResponse> EducationSchoolUpdateAsync()
        {
            var p = new EducationSchoolUpdateParameter();
            return await this.SendAsync<EducationSchoolUpdateParameter, EducationSchoolUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationschool-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationSchoolUpdateResponse> EducationSchoolUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new EducationSchoolUpdateParameter();
            return await this.SendAsync<EducationSchoolUpdateParameter, EducationSchoolUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationschool-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationSchoolUpdateResponse> EducationSchoolUpdateAsync(EducationSchoolUpdateParameter parameter)
        {
            return await this.SendAsync<EducationSchoolUpdateParameter, EducationSchoolUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationschool-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationSchoolUpdateResponse> EducationSchoolUpdateAsync(EducationSchoolUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationSchoolUpdateParameter, EducationSchoolUpdateResponse>(parameter, cancellationToken);
        }
    }
}
