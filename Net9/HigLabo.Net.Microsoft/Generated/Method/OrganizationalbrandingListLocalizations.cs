using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/organizationalbranding-list-localizations?view=graph-rest-1.0
/// </summary>
public partial class OrganizationalBrandingListLocalizationsParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? OrganizationId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Organization_OrganizationId_Branding_Localizations: return $"/organization/{OrganizationId}/branding/localizations";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Organization_OrganizationId_Branding_Localizations,
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
public partial class OrganizationalBrandingListLocalizationsResponse : RestApiResponse<OrganizationalBrandingLocalization>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/organizationalbranding-list-localizations?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/organizationalbranding-list-localizations?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<OrganizationalBrandingListLocalizationsResponse> OrganizationalBrandingListLocalizationsAsync()
    {
        var p = new OrganizationalBrandingListLocalizationsParameter();
        return await this.SendAsync<OrganizationalBrandingListLocalizationsParameter, OrganizationalBrandingListLocalizationsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/organizationalbranding-list-localizations?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<OrganizationalBrandingListLocalizationsResponse> OrganizationalBrandingListLocalizationsAsync(CancellationToken cancellationToken)
    {
        var p = new OrganizationalBrandingListLocalizationsParameter();
        return await this.SendAsync<OrganizationalBrandingListLocalizationsParameter, OrganizationalBrandingListLocalizationsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/organizationalbranding-list-localizations?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<OrganizationalBrandingListLocalizationsResponse> OrganizationalBrandingListLocalizationsAsync(OrganizationalBrandingListLocalizationsParameter parameter)
    {
        return await this.SendAsync<OrganizationalBrandingListLocalizationsParameter, OrganizationalBrandingListLocalizationsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/organizationalbranding-list-localizations?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<OrganizationalBrandingListLocalizationsResponse> OrganizationalBrandingListLocalizationsAsync(OrganizationalBrandingListLocalizationsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<OrganizationalBrandingListLocalizationsParameter, OrganizationalBrandingListLocalizationsResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/organizationalbranding-list-localizations?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<OrganizationalBrandingLocalization> OrganizationalBrandingListLocalizationsEnumerateAsync(OrganizationalBrandingListLocalizationsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<OrganizationalBrandingListLocalizationsParameter, OrganizationalBrandingListLocalizationsResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<OrganizationalBrandingLocalization>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
