using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/identityproviderbase-get?view=graph-rest-1.0
/// </summary>
public partial class IdentityProviderbaseGetParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Identity_IdentityProviders_Id: return $"/identity/identityProviders/{Id}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Identity_IdentityProviders_Id,
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
public partial class IdentityProviderbaseGetResponse : RestApiResponse
{
    public string? ClientId { get; set; }
    public string? ClientSecret { get; set; }
    public string? DisplayName { get; set; }
    public string? Id { get; set; }
    public string? IdentityProviderType { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/identityproviderbase-get?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identityproviderbase-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<IdentityProviderbaseGetResponse> IdentityProviderbaseGetAsync()
    {
        var p = new IdentityProviderbaseGetParameter();
        return await this.SendAsync<IdentityProviderbaseGetParameter, IdentityProviderbaseGetResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identityproviderbase-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<IdentityProviderbaseGetResponse> IdentityProviderbaseGetAsync(CancellationToken cancellationToken)
    {
        var p = new IdentityProviderbaseGetParameter();
        return await this.SendAsync<IdentityProviderbaseGetParameter, IdentityProviderbaseGetResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identityproviderbase-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<IdentityProviderbaseGetResponse> IdentityProviderbaseGetAsync(IdentityProviderbaseGetParameter parameter)
    {
        return await this.SendAsync<IdentityProviderbaseGetParameter, IdentityProviderbaseGetResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identityproviderbase-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<IdentityProviderbaseGetResponse> IdentityProviderbaseGetAsync(IdentityProviderbaseGetParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<IdentityProviderbaseGetParameter, IdentityProviderbaseGetResponse>(parameter, cancellationToken);
    }
}
