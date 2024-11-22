using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/team-list-installedapps?view=graph-rest-1.0
/// </summary>
public partial class TeamListInstalledappsParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? TeamId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Teams_TeamId_InstalledApps: return $"/teams/{TeamId}/installedApps";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Teams_TeamId_InstalledApps,
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
public partial class TeamListInstalledappsResponse : RestApiResponse<TeamsAppInstallation>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/team-list-installedapps?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/team-list-installedapps?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TeamListInstalledappsResponse> TeamListInstalledappsAsync()
    {
        var p = new TeamListInstalledappsParameter();
        return await this.SendAsync<TeamListInstalledappsParameter, TeamListInstalledappsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/team-list-installedapps?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TeamListInstalledappsResponse> TeamListInstalledappsAsync(CancellationToken cancellationToken)
    {
        var p = new TeamListInstalledappsParameter();
        return await this.SendAsync<TeamListInstalledappsParameter, TeamListInstalledappsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/team-list-installedapps?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TeamListInstalledappsResponse> TeamListInstalledappsAsync(TeamListInstalledappsParameter parameter)
    {
        return await this.SendAsync<TeamListInstalledappsParameter, TeamListInstalledappsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/team-list-installedapps?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TeamListInstalledappsResponse> TeamListInstalledappsAsync(TeamListInstalledappsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<TeamListInstalledappsParameter, TeamListInstalledappsResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/team-list-installedapps?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<TeamsAppInstallation> TeamListInstalledappsEnumerateAsync(TeamListInstalledappsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<TeamListInstalledappsParameter, TeamListInstalledappsResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<TeamsAppInstallation>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
