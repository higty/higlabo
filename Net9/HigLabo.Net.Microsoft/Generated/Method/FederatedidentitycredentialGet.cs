using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/federatedidentitycredential-get?view=graph-rest-1.0
/// </summary>
public partial class FederatedidentitycredentialGetParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }
        public string? FederatedIdentityCredentialId { get; set; }
        public string? FederatedIdentityCredentialName { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Applications_Id_FederatedIdentityCredentials_FederatedIdentityCredentialId: return $"/applications/{Id}/federatedIdentityCredentials/{FederatedIdentityCredentialId}";
                case ApiPath.Applications_Id_FederatedIdentityCredentials_FederatedIdentityCredentialName: return $"/applications/{Id}/federatedIdentityCredentials/{FederatedIdentityCredentialName}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Applications_Id_FederatedIdentityCredentials_FederatedIdentityCredentialId,
        Applications_Id_FederatedIdentityCredentials_FederatedIdentityCredentialName,
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
public partial class FederatedidentitycredentialGetResponse : RestApiResponse
{
    public String[]? Audiences { get; set; }
    public string? Description { get; set; }
    public string? Id { get; set; }
    public string? Issuer { get; set; }
    public string? Name { get; set; }
    public string? Subject { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/federatedidentitycredential-get?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/federatedidentitycredential-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<FederatedidentitycredentialGetResponse> FederatedidentitycredentialGetAsync()
    {
        var p = new FederatedidentitycredentialGetParameter();
        return await this.SendAsync<FederatedidentitycredentialGetParameter, FederatedidentitycredentialGetResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/federatedidentitycredential-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<FederatedidentitycredentialGetResponse> FederatedidentitycredentialGetAsync(CancellationToken cancellationToken)
    {
        var p = new FederatedidentitycredentialGetParameter();
        return await this.SendAsync<FederatedidentitycredentialGetParameter, FederatedidentitycredentialGetResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/federatedidentitycredential-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<FederatedidentitycredentialGetResponse> FederatedidentitycredentialGetAsync(FederatedidentitycredentialGetParameter parameter)
    {
        return await this.SendAsync<FederatedidentitycredentialGetParameter, FederatedidentitycredentialGetResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/federatedidentitycredential-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<FederatedidentitycredentialGetResponse> FederatedidentitycredentialGetAsync(FederatedidentitycredentialGetParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<FederatedidentitycredentialGetParameter, FederatedidentitycredentialGetResponse>(parameter, cancellationToken);
    }
}
