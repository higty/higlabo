using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/educationschool-post?view=graph-rest-1.0
/// </summary>
public partial class EducationSchoolPostParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Education_Schools: return $"/education/schools";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum EducationSchoolPostParameterEducationExternalSource
    {
        Sis,
    }
    public enum EducationSchoolEducationExternalSource
    {
        Sis,
        Manual,
    }
    public enum ApiPath
    {
        Education_Schools,
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
    public string? DisplayName { get; set; }
    public string? Description { get; set; }
    public EducationSchoolPostParameterEducationExternalSource ExternalSource { get; set; }
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
    public string? Id { get; set; }
    public AdministrativeUnit? AdministrativeUnit { get; set; }
    public EducationClass[]? Classes { get; set; }
    public EducationUser[]? Users { get; set; }
}
public partial class EducationSchoolPostResponse : RestApiResponse
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
/// https://learn.microsoft.com/en-us/graph/api/educationschool-post?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationschool-post?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationSchoolPostResponse> EducationSchoolPostAsync()
    {
        var p = new EducationSchoolPostParameter();
        return await this.SendAsync<EducationSchoolPostParameter, EducationSchoolPostResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationschool-post?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationSchoolPostResponse> EducationSchoolPostAsync(CancellationToken cancellationToken)
    {
        var p = new EducationSchoolPostParameter();
        return await this.SendAsync<EducationSchoolPostParameter, EducationSchoolPostResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationschool-post?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationSchoolPostResponse> EducationSchoolPostAsync(EducationSchoolPostParameter parameter)
    {
        return await this.SendAsync<EducationSchoolPostParameter, EducationSchoolPostResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationschool-post?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationSchoolPostResponse> EducationSchoolPostAsync(EducationSchoolPostParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<EducationSchoolPostParameter, EducationSchoolPostResponse>(parameter, cancellationToken);
    }
}
