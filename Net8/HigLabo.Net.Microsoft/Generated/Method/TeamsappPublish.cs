using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/teamsapp-publish?view=graph-rest-1.0
/// </summary>
public partial class TeamsappPublishParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.AppCatalogs_TeamsApps: return $"/appCatalogs/teamsApps";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        AppCatalogs_TeamsApps,
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
    public string? DisplayName { get; set; }
    public TeamsAppDistributionMethod? DistributionMethod { get; set; }
    public string? ExternalId { get; set; }
    public string? Id { get; set; }
    public TeamsAppDefinition[]? AppDefinitions { get; set; }
}
public partial class TeamsappPublishResponse : RestApiResponse
{
    public string? DisplayName { get; set; }
    public TeamsAppDistributionMethod? DistributionMethod { get; set; }
    public string? ExternalId { get; set; }
    public string? Id { get; set; }
    public TeamsAppDefinition[]? AppDefinitions { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/teamsapp-publish?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/teamsapp-publish?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TeamsappPublishResponse> TeamsappPublishAsync()
    {
        var p = new TeamsappPublishParameter();
        return await this.SendAsync<TeamsappPublishParameter, TeamsappPublishResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/teamsapp-publish?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TeamsappPublishResponse> TeamsappPublishAsync(CancellationToken cancellationToken)
    {
        var p = new TeamsappPublishParameter();
        return await this.SendAsync<TeamsappPublishParameter, TeamsappPublishResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/teamsapp-publish?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TeamsappPublishResponse> TeamsappPublishAsync(TeamsappPublishParameter parameter)
    {
        return await this.SendAsync<TeamsappPublishParameter, TeamsappPublishResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/teamsapp-publish?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TeamsappPublishResponse> TeamsappPublishAsync(TeamsappPublishParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<TeamsappPublishParameter, TeamsappPublishResponse>(parameter, cancellationToken);
    }
}
