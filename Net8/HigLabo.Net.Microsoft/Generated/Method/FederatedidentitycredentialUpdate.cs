using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/federatedidentitycredential-update?view=graph-rest-1.0
/// </summary>
public partial class FederatedidentitycredentialUpdateParameter : IRestApiParameter
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
    string IRestApiParameter.HttpMethod { get; } = "PATCH";
    public String[]? Audiences { get; set; }
    public string? Description { get; set; }
    public string? Issuer { get; set; }
    public string? Subject { get; set; }
}
public partial class FederatedidentitycredentialUpdateResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/federatedidentitycredential-update?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/federatedidentitycredential-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<FederatedidentitycredentialUpdateResponse> FederatedidentitycredentialUpdateAsync()
    {
        var p = new FederatedidentitycredentialUpdateParameter();
        return await this.SendAsync<FederatedidentitycredentialUpdateParameter, FederatedidentitycredentialUpdateResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/federatedidentitycredential-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<FederatedidentitycredentialUpdateResponse> FederatedidentitycredentialUpdateAsync(CancellationToken cancellationToken)
    {
        var p = new FederatedidentitycredentialUpdateParameter();
        return await this.SendAsync<FederatedidentitycredentialUpdateParameter, FederatedidentitycredentialUpdateResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/federatedidentitycredential-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<FederatedidentitycredentialUpdateResponse> FederatedidentitycredentialUpdateAsync(FederatedidentitycredentialUpdateParameter parameter)
    {
        return await this.SendAsync<FederatedidentitycredentialUpdateParameter, FederatedidentitycredentialUpdateResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/federatedidentitycredential-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<FederatedidentitycredentialUpdateResponse> FederatedidentitycredentialUpdateAsync(FederatedidentitycredentialUpdateParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<FederatedidentitycredentialUpdateParameter, FederatedidentitycredentialUpdateResponse>(parameter, cancellationToken);
    }
}
