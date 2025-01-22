using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/organizationalbrandinglocalization-get?view=graph-rest-1.0
/// </summary>
public partial class OrganizationalBrandinglocalizationGetParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? OrganizationId { get; set; }
        public string? OrganizationalBrandingLocalizationId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Organization_OrganizationId_Branding_Localizations_OrganizationalBrandingLocalizationId: return $"/organization/{OrganizationId}/branding/localizations/{OrganizationalBrandingLocalizationId}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Organization_OrganizationId_Branding_Localizations_OrganizationalBrandingLocalizationId,
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
public partial class OrganizationalBrandinglocalizationGetResponse : RestApiResponse
{
    public string? BackgroundColor { get; set; }
    public Stream? BackgroundImage { get; set; }
    public string? BackgroundImageRelativeUrl { get; set; }
    public Stream? BannerLogo { get; set; }
    public string? BannerLogoRelativeUrl { get; set; }
    public String[]? CdnList { get; set; }
    public string? Id { get; set; }
    public string? SignInPageText { get; set; }
    public Stream? SquareLogo { get; set; }
    public string? SquareLogoRelativeUrl { get; set; }
    public string? UsernameHintText { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/organizationalbrandinglocalization-get?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/organizationalbrandinglocalization-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<OrganizationalBrandinglocalizationGetResponse> OrganizationalBrandinglocalizationGetAsync()
    {
        var p = new OrganizationalBrandinglocalizationGetParameter();
        return await this.SendAsync<OrganizationalBrandinglocalizationGetParameter, OrganizationalBrandinglocalizationGetResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/organizationalbrandinglocalization-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<OrganizationalBrandinglocalizationGetResponse> OrganizationalBrandinglocalizationGetAsync(CancellationToken cancellationToken)
    {
        var p = new OrganizationalBrandinglocalizationGetParameter();
        return await this.SendAsync<OrganizationalBrandinglocalizationGetParameter, OrganizationalBrandinglocalizationGetResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/organizationalbrandinglocalization-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<OrganizationalBrandinglocalizationGetResponse> OrganizationalBrandinglocalizationGetAsync(OrganizationalBrandinglocalizationGetParameter parameter)
    {
        return await this.SendAsync<OrganizationalBrandinglocalizationGetParameter, OrganizationalBrandinglocalizationGetResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/organizationalbrandinglocalization-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<OrganizationalBrandinglocalizationGetResponse> OrganizationalBrandinglocalizationGetAsync(OrganizationalBrandinglocalizationGetParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<OrganizationalBrandinglocalizationGetParameter, OrganizationalBrandinglocalizationGetResponse>(parameter, cancellationToken);
    }
}
