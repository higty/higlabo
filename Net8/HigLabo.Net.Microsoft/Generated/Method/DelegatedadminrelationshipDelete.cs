using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/delegatedadminrelationship-delete?view=graph-rest-1.0
/// </summary>
public partial class DelegatedadminrelationshipDeleteParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? DelegatedAdminRelationshipId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.TenantRelationships_DelegatedAdminRelationships_DelegatedAdminRelationshipId: return $"/tenantRelationships/delegatedAdminRelationships/{DelegatedAdminRelationshipId}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        TenantRelationships_DelegatedAdminRelationships_DelegatedAdminRelationshipId,
    }

    public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
    string IRestApiParameter.ApiPath
    {
        get
        {
            return this.ApiPathSetting.GetApiPath();
        }
    }
    string IRestApiParameter.HttpMethod { get; } = "DELETE";
}
public partial class DelegatedadminrelationshipDeleteResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/delegatedadminrelationship-delete?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/delegatedadminrelationship-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DelegatedadminrelationshipDeleteResponse> DelegatedadminrelationshipDeleteAsync()
    {
        var p = new DelegatedadminrelationshipDeleteParameter();
        return await this.SendAsync<DelegatedadminrelationshipDeleteParameter, DelegatedadminrelationshipDeleteResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/delegatedadminrelationship-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DelegatedadminrelationshipDeleteResponse> DelegatedadminrelationshipDeleteAsync(CancellationToken cancellationToken)
    {
        var p = new DelegatedadminrelationshipDeleteParameter();
        return await this.SendAsync<DelegatedadminrelationshipDeleteParameter, DelegatedadminrelationshipDeleteResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/delegatedadminrelationship-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DelegatedadminrelationshipDeleteResponse> DelegatedadminrelationshipDeleteAsync(DelegatedadminrelationshipDeleteParameter parameter)
    {
        return await this.SendAsync<DelegatedadminrelationshipDeleteParameter, DelegatedadminrelationshipDeleteResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/delegatedadminrelationship-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DelegatedadminrelationshipDeleteResponse> DelegatedadminrelationshipDeleteAsync(DelegatedadminrelationshipDeleteParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<DelegatedadminrelationshipDeleteParameter, DelegatedadminrelationshipDeleteResponse>(parameter, cancellationToken);
    }
}
