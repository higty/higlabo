using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/administrativeunit-get?view=graph-rest-1.0
/// </summary>
public partial class AdministrativeunitGetParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Directory_AdministrativeUnits_Id: return $"/directory/administrativeUnits/{Id}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Directory_AdministrativeUnits_Id,
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
public partial class AdministrativeunitGetResponse : RestApiResponse
{
    public string? Description { get; set; }
    public string? DisplayName { get; set; }
    public string? Id { get; set; }
    public string? Visibility { get; set; }
    public DirectoryObject[]? Members { get; set; }
    public Extension[]? Extensions { get; set; }
    public ScopedRoleMembership[]? ScopedRoleMembers { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/administrativeunit-get?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/administrativeunit-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AdministrativeunitGetResponse> AdministrativeunitGetAsync()
    {
        var p = new AdministrativeunitGetParameter();
        return await this.SendAsync<AdministrativeunitGetParameter, AdministrativeunitGetResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/administrativeunit-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AdministrativeunitGetResponse> AdministrativeunitGetAsync(CancellationToken cancellationToken)
    {
        var p = new AdministrativeunitGetParameter();
        return await this.SendAsync<AdministrativeunitGetParameter, AdministrativeunitGetResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/administrativeunit-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AdministrativeunitGetResponse> AdministrativeunitGetAsync(AdministrativeunitGetParameter parameter)
    {
        return await this.SendAsync<AdministrativeunitGetParameter, AdministrativeunitGetResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/administrativeunit-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AdministrativeunitGetResponse> AdministrativeunitGetAsync(AdministrativeunitGetParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<AdministrativeunitGetParameter, AdministrativeunitGetResponse>(parameter, cancellationToken);
    }
}
