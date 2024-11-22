using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/connectedorganization-get?view=graph-rest-1.0
/// </summary>
public partial class ConnectedOrganizationGetParameter : IRestApiParameter, IQueryParameterProperty
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

    public enum Field
    {
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
public partial class ConnectedOrganizationGetResponse : RestApiResponse
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
/// https://learn.microsoft.com/en-us/graph/api/connectedorganization-get?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/connectedorganization-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ConnectedOrganizationGetResponse> ConnectedOrganizationGetAsync()
    {
        var p = new ConnectedOrganizationGetParameter();
        return await this.SendAsync<ConnectedOrganizationGetParameter, ConnectedOrganizationGetResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/connectedorganization-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ConnectedOrganizationGetResponse> ConnectedOrganizationGetAsync(CancellationToken cancellationToken)
    {
        var p = new ConnectedOrganizationGetParameter();
        return await this.SendAsync<ConnectedOrganizationGetParameter, ConnectedOrganizationGetResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/connectedorganization-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ConnectedOrganizationGetResponse> ConnectedOrganizationGetAsync(ConnectedOrganizationGetParameter parameter)
    {
        return await this.SendAsync<ConnectedOrganizationGetParameter, ConnectedOrganizationGetResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/connectedorganization-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ConnectedOrganizationGetResponse> ConnectedOrganizationGetAsync(ConnectedOrganizationGetParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ConnectedOrganizationGetParameter, ConnectedOrganizationGetResponse>(parameter, cancellationToken);
    }
}
