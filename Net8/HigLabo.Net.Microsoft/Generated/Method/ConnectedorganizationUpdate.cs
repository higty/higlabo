using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/connectedorganization-update?view=graph-rest-1.0
/// </summary>
public partial class ConnectedOrganizationUpdateParameter : IRestApiParameter
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

    public enum ConnectedOrganizationUpdateParameterConnectedOrganizationState
    {
        AllConfiguredConnectedOrganizationSubjects,
        Configured,
        Proposed,
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
    string IRestApiParameter.HttpMethod { get; } = "PATCH";
    public string? DisplayName { get; set; }
    public string? Description { get; set; }
    public IdentitySource[]? IdentitySources { get; set; }
    public ConnectedOrganizationUpdateParameterConnectedOrganizationState State { get; set; }
}
public partial class ConnectedOrganizationUpdateResponse : RestApiResponse
{
    public enum ConnectedOrganizationConnectedOrganizationState
    {
        AllConfiguredConnectedOrganizationSubjects,
        Configured,
        Proposed,
        UnknownFutureValue,
    }

    public DateTimeOffset? CreatedDateTime { get; set; }
    public string? Description { get; set; }
    public string? DisplayName { get; set; }
    public string? Id { get; set; }
    public IdentitySource[]? IdentitySources { get; set; }
    public DateTimeOffset? ModifiedDateTime { get; set; }
    public ConnectedOrganizationConnectedOrganizationState State { get; set; }
    public DirectoryObject[]? ExternalSponsors { get; set; }
    public DirectoryObject[]? InternalSponsors { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/connectedorganization-update?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/connectedorganization-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ConnectedOrganizationUpdateResponse> ConnectedOrganizationUpdateAsync()
    {
        var p = new ConnectedOrganizationUpdateParameter();
        return await this.SendAsync<ConnectedOrganizationUpdateParameter, ConnectedOrganizationUpdateResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/connectedorganization-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ConnectedOrganizationUpdateResponse> ConnectedOrganizationUpdateAsync(CancellationToken cancellationToken)
    {
        var p = new ConnectedOrganizationUpdateParameter();
        return await this.SendAsync<ConnectedOrganizationUpdateParameter, ConnectedOrganizationUpdateResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/connectedorganization-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ConnectedOrganizationUpdateResponse> ConnectedOrganizationUpdateAsync(ConnectedOrganizationUpdateParameter parameter)
    {
        return await this.SendAsync<ConnectedOrganizationUpdateParameter, ConnectedOrganizationUpdateResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/connectedorganization-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ConnectedOrganizationUpdateResponse> ConnectedOrganizationUpdateAsync(ConnectedOrganizationUpdateParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ConnectedOrganizationUpdateParameter, ConnectedOrganizationUpdateResponse>(parameter, cancellationToken);
    }
}
