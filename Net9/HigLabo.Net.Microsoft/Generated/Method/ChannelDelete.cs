using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/channel-delete?view=graph-rest-1.0
/// </summary>
public partial class ChannelDeleteParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? TeamId { get; set; }
        public string? ChannelId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Teams_TeamId_Channels_ChannelId: return $"/teams/{TeamId}/channels/{ChannelId}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Teams_TeamId_Channels_ChannelId,
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
public partial class ChannelDeleteResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/channel-delete?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/channel-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ChannelDeleteResponse> ChannelDeleteAsync()
    {
        var p = new ChannelDeleteParameter();
        return await this.SendAsync<ChannelDeleteParameter, ChannelDeleteResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/channel-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ChannelDeleteResponse> ChannelDeleteAsync(CancellationToken cancellationToken)
    {
        var p = new ChannelDeleteParameter();
        return await this.SendAsync<ChannelDeleteParameter, ChannelDeleteResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/channel-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ChannelDeleteResponse> ChannelDeleteAsync(ChannelDeleteParameter parameter)
    {
        return await this.SendAsync<ChannelDeleteParameter, ChannelDeleteResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/channel-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ChannelDeleteResponse> ChannelDeleteAsync(ChannelDeleteParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ChannelDeleteParameter, ChannelDeleteResponse>(parameter, cancellationToken);
    }
}
