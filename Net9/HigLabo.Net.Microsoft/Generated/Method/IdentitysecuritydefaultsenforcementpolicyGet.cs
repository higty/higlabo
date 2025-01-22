using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/identitysecuritydefaultsenforcementpolicy-get?view=graph-rest-1.0
/// </summary>
public partial class IdentitysecuritydefaultsenforcementPolicyGetParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Policies_IdentitySecurityDefaultsEnforcementPolicy: return $"/policies/identitySecurityDefaultsEnforcementPolicy";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Policies_IdentitySecurityDefaultsEnforcementPolicy,
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
public partial class IdentitysecuritydefaultsenforcementPolicyGetResponse : RestApiResponse
{
    public string? Description { get; set; }
    public string? DisplayName { get; set; }
    public string? Id { get; set; }
    public bool? IsEnabled { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/identitysecuritydefaultsenforcementpolicy-get?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identitysecuritydefaultsenforcementpolicy-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<IdentitysecuritydefaultsenforcementPolicyGetResponse> IdentitysecuritydefaultsenforcementPolicyGetAsync()
    {
        var p = new IdentitysecuritydefaultsenforcementPolicyGetParameter();
        return await this.SendAsync<IdentitysecuritydefaultsenforcementPolicyGetParameter, IdentitysecuritydefaultsenforcementPolicyGetResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identitysecuritydefaultsenforcementpolicy-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<IdentitysecuritydefaultsenforcementPolicyGetResponse> IdentitysecuritydefaultsenforcementPolicyGetAsync(CancellationToken cancellationToken)
    {
        var p = new IdentitysecuritydefaultsenforcementPolicyGetParameter();
        return await this.SendAsync<IdentitysecuritydefaultsenforcementPolicyGetParameter, IdentitysecuritydefaultsenforcementPolicyGetResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identitysecuritydefaultsenforcementpolicy-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<IdentitysecuritydefaultsenforcementPolicyGetResponse> IdentitysecuritydefaultsenforcementPolicyGetAsync(IdentitysecuritydefaultsenforcementPolicyGetParameter parameter)
    {
        return await this.SendAsync<IdentitysecuritydefaultsenforcementPolicyGetParameter, IdentitysecuritydefaultsenforcementPolicyGetResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identitysecuritydefaultsenforcementpolicy-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<IdentitysecuritydefaultsenforcementPolicyGetResponse> IdentitysecuritydefaultsenforcementPolicyGetAsync(IdentitysecuritydefaultsenforcementPolicyGetParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<IdentitysecuritydefaultsenforcementPolicyGetParameter, IdentitysecuritydefaultsenforcementPolicyGetResponse>(parameter, cancellationToken);
    }
}
