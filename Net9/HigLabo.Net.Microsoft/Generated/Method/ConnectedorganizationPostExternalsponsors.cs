using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/connectedorganization-post-externalsponsors?view=graph-rest-1.0
/// </summary>
public partial class ConnectedOrganizationPostExternalsponsorsParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.IdentityGovernance_EntitlementManagement_ConnectedOrganizations_Id_ExternalSponsors_ref: return $"/identityGovernance/entitlementManagement/connectedOrganizations/{Id}/externalSponsors/$ref";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        IdentityGovernance_EntitlementManagement_ConnectedOrganizations_Id_ExternalSponsors_ref,
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
public partial class ConnectedOrganizationPostExternalsponsorsResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/connectedorganization-post-externalsponsors?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/connectedorganization-post-externalsponsors?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ConnectedOrganizationPostExternalsponsorsResponse> ConnectedOrganizationPostExternalsponsorsAsync()
    {
        var p = new ConnectedOrganizationPostExternalsponsorsParameter();
        return await this.SendAsync<ConnectedOrganizationPostExternalsponsorsParameter, ConnectedOrganizationPostExternalsponsorsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/connectedorganization-post-externalsponsors?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ConnectedOrganizationPostExternalsponsorsResponse> ConnectedOrganizationPostExternalsponsorsAsync(CancellationToken cancellationToken)
    {
        var p = new ConnectedOrganizationPostExternalsponsorsParameter();
        return await this.SendAsync<ConnectedOrganizationPostExternalsponsorsParameter, ConnectedOrganizationPostExternalsponsorsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/connectedorganization-post-externalsponsors?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ConnectedOrganizationPostExternalsponsorsResponse> ConnectedOrganizationPostExternalsponsorsAsync(ConnectedOrganizationPostExternalsponsorsParameter parameter)
    {
        return await this.SendAsync<ConnectedOrganizationPostExternalsponsorsParameter, ConnectedOrganizationPostExternalsponsorsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/connectedorganization-post-externalsponsors?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ConnectedOrganizationPostExternalsponsorsResponse> ConnectedOrganizationPostExternalsponsorsAsync(ConnectedOrganizationPostExternalsponsorsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ConnectedOrganizationPostExternalsponsorsParameter, ConnectedOrganizationPostExternalsponsorsResponse>(parameter, cancellationToken);
    }
}
