using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/sharedwithchannelteaminfo-delete?view=graph-rest-1.0
/// </summary>
public partial class SharedwithchannelteaminfoDeleteParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? TeamId { get; set; }
        public string? ChannelId { get; set; }
        public string? SharedWithChannelTeamInfoId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Teams_TeamId_Channels_ChannelId_SharedWithTeams_SharedWithChannelTeamInfoId: return $"/teams/{TeamId}/channels/{ChannelId}/sharedWithTeams/{SharedWithChannelTeamInfoId}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Teams_TeamId_Channels_ChannelId_SharedWithTeams_SharedWithChannelTeamInfoId,
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
public partial class SharedwithchannelteaminfoDeleteResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/sharedwithchannelteaminfo-delete?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/sharedwithchannelteaminfo-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SharedwithchannelteaminfoDeleteResponse> SharedwithchannelteaminfoDeleteAsync()
    {
        var p = new SharedwithchannelteaminfoDeleteParameter();
        return await this.SendAsync<SharedwithchannelteaminfoDeleteParameter, SharedwithchannelteaminfoDeleteResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/sharedwithchannelteaminfo-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SharedwithchannelteaminfoDeleteResponse> SharedwithchannelteaminfoDeleteAsync(CancellationToken cancellationToken)
    {
        var p = new SharedwithchannelteaminfoDeleteParameter();
        return await this.SendAsync<SharedwithchannelteaminfoDeleteParameter, SharedwithchannelteaminfoDeleteResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/sharedwithchannelteaminfo-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SharedwithchannelteaminfoDeleteResponse> SharedwithchannelteaminfoDeleteAsync(SharedwithchannelteaminfoDeleteParameter parameter)
    {
        return await this.SendAsync<SharedwithchannelteaminfoDeleteParameter, SharedwithchannelteaminfoDeleteResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/sharedwithchannelteaminfo-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SharedwithchannelteaminfoDeleteResponse> SharedwithchannelteaminfoDeleteAsync(SharedwithchannelteaminfoDeleteParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<SharedwithchannelteaminfoDeleteParameter, SharedwithchannelteaminfoDeleteResponse>(parameter, cancellationToken);
    }
}
