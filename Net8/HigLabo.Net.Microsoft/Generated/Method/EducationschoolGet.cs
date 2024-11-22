using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/educationschool-get?view=graph-rest-1.0
/// </summary>
public partial class EducationSchoolGetParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? EducationSchoolId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Education_Schools_EducationSchoolId: return $"/education/schools/{EducationSchoolId}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Education_Schools_EducationSchoolId,
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
public partial class EducationSchoolGetResponse : RestApiResponse
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
/// https://learn.microsoft.com/en-us/graph/api/educationschool-get?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationschool-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationSchoolGetResponse> EducationSchoolGetAsync()
    {
        var p = new EducationSchoolGetParameter();
        return await this.SendAsync<EducationSchoolGetParameter, EducationSchoolGetResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationschool-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationSchoolGetResponse> EducationSchoolGetAsync(CancellationToken cancellationToken)
    {
        var p = new EducationSchoolGetParameter();
        return await this.SendAsync<EducationSchoolGetParameter, EducationSchoolGetResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationschool-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationSchoolGetResponse> EducationSchoolGetAsync(EducationSchoolGetParameter parameter)
    {
        return await this.SendAsync<EducationSchoolGetParameter, EducationSchoolGetResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationschool-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationSchoolGetResponse> EducationSchoolGetAsync(EducationSchoolGetParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<EducationSchoolGetParameter, EducationSchoolGetResponse>(parameter, cancellationToken);
    }
}
