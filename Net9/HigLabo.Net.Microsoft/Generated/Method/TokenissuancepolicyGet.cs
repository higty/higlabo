using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/tokenissuancepolicy-get?view=graph-rest-1.0
/// </summary>
public partial class TokenissuancePolicyGetParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Policies_TokenIssuancePolicies_Id: return $"/policies/tokenIssuancePolicies/{Id}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Policies_TokenIssuancePolicies_Id,
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
public partial class TokenissuancePolicyGetResponse : RestApiResponse
{
    public String[]? Definition { get; set; }
    public string? Description { get; set; }
    public string? DisplayName { get; set; }
    public string? Id { get; set; }
    public bool? IsOrganizationDefault { get; set; }
    public DirectoryObject[]? AppliesTo { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/tokenissuancepolicy-get?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/tokenissuancepolicy-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TokenissuancePolicyGetResponse> TokenissuancePolicyGetAsync()
    {
        var p = new TokenissuancePolicyGetParameter();
        return await this.SendAsync<TokenissuancePolicyGetParameter, TokenissuancePolicyGetResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/tokenissuancepolicy-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TokenissuancePolicyGetResponse> TokenissuancePolicyGetAsync(CancellationToken cancellationToken)
    {
        var p = new TokenissuancePolicyGetParameter();
        return await this.SendAsync<TokenissuancePolicyGetParameter, TokenissuancePolicyGetResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/tokenissuancepolicy-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TokenissuancePolicyGetResponse> TokenissuancePolicyGetAsync(TokenissuancePolicyGetParameter parameter)
    {
        return await this.SendAsync<TokenissuancePolicyGetParameter, TokenissuancePolicyGetResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/tokenissuancepolicy-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TokenissuancePolicyGetResponse> TokenissuancePolicyGetAsync(TokenissuancePolicyGetParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<TokenissuancePolicyGetParameter, TokenissuancePolicyGetResponse>(parameter, cancellationToken);
    }
}
