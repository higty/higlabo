using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/connectedorganization-delete?view=graph-rest-1.0
/// </summary>
public partial class ConnectedOrganizationDeleteParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? ConnectedOrganizationId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.IdentityGovernance_EntitlementManagement_ConnectedOrganizations_ConnectedOrganizationId: return $"/identityGovernance/entitlementManagement/connectedOrganizations/{ConnectedOrganizationId}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        IdentityGovernance_EntitlementManagement_ConnectedOrganizations_ConnectedOrganizationId,
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
public partial class ConnectedOrganizationDeleteResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/connectedorganization-delete?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/connectedorganization-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ConnectedOrganizationDeleteResponse> ConnectedOrganizationDeleteAsync()
    {
        var p = new ConnectedOrganizationDeleteParameter();
        return await this.SendAsync<ConnectedOrganizationDeleteParameter, ConnectedOrganizationDeleteResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/connectedorganization-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ConnectedOrganizationDeleteResponse> ConnectedOrganizationDeleteAsync(CancellationToken cancellationToken)
    {
        var p = new ConnectedOrganizationDeleteParameter();
        return await this.SendAsync<ConnectedOrganizationDeleteParameter, ConnectedOrganizationDeleteResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/connectedorganization-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ConnectedOrganizationDeleteResponse> ConnectedOrganizationDeleteAsync(ConnectedOrganizationDeleteParameter parameter)
    {
        return await this.SendAsync<ConnectedOrganizationDeleteParameter, ConnectedOrganizationDeleteResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/connectedorganization-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ConnectedOrganizationDeleteResponse> ConnectedOrganizationDeleteAsync(ConnectedOrganizationDeleteParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ConnectedOrganizationDeleteParameter, ConnectedOrganizationDeleteResponse>(parameter, cancellationToken);
    }
}
