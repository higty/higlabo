using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/connectedorganization-post-internalsponsors?view=graph-rest-1.0
/// </summary>
public partial class ConnectedOrganizationPostInternalsponsorsParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.IdentityGovernance_EntitlementManagement_ConnectedOrganizations_Id_InternalSponsors_ref: return $"/identityGovernance/entitlementManagement/connectedOrganizations/{Id}/internalSponsors/$ref";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        IdentityGovernance_EntitlementManagement_ConnectedOrganizations_Id_InternalSponsors_ref,
    }

    public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
    string IRestApiParameter.ApiPath
    {
        get
        {
            return this.ApiPathSetting.GetApiPath();
        }
    }
    string IRestApiParameter.HttpMethod { get; } = "POST";
}
public partial class ConnectedOrganizationPostInternalsponsorsResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/connectedorganization-post-internalsponsors?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/connectedorganization-post-internalsponsors?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ConnectedOrganizationPostInternalsponsorsResponse> ConnectedOrganizationPostInternalsponsorsAsync()
    {
        var p = new ConnectedOrganizationPostInternalsponsorsParameter();
        return await this.SendAsync<ConnectedOrganizationPostInternalsponsorsParameter, ConnectedOrganizationPostInternalsponsorsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/connectedorganization-post-internalsponsors?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ConnectedOrganizationPostInternalsponsorsResponse> ConnectedOrganizationPostInternalsponsorsAsync(CancellationToken cancellationToken)
    {
        var p = new ConnectedOrganizationPostInternalsponsorsParameter();
        return await this.SendAsync<ConnectedOrganizationPostInternalsponsorsParameter, ConnectedOrganizationPostInternalsponsorsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/connectedorganization-post-internalsponsors?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ConnectedOrganizationPostInternalsponsorsResponse> ConnectedOrganizationPostInternalsponsorsAsync(ConnectedOrganizationPostInternalsponsorsParameter parameter)
    {
        return await this.SendAsync<ConnectedOrganizationPostInternalsponsorsParameter, ConnectedOrganizationPostInternalsponsorsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/connectedorganization-post-internalsponsors?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ConnectedOrganizationPostInternalsponsorsResponse> ConnectedOrganizationPostInternalsponsorsAsync(ConnectedOrganizationPostInternalsponsorsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ConnectedOrganizationPostInternalsponsorsParameter, ConnectedOrganizationPostInternalsponsorsResponse>(parameter, cancellationToken);
    }
}
