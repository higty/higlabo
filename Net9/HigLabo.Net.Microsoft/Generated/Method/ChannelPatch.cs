using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/channel-patch?view=graph-rest-1.0
/// </summary>
public partial class ChannelPatchParameter : IRestApiParameter
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
    string IRestApiParameter.HttpMethod { get; } = "PATCH";
}
public partial class ChannelPatchResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/channel-patch?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/channel-patch?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ChannelPatchResponse> ChannelPatchAsync()
    {
        var p = new ChannelPatchParameter();
        return await this.SendAsync<ChannelPatchParameter, ChannelPatchResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/channel-patch?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ChannelPatchResponse> ChannelPatchAsync(CancellationToken cancellationToken)
    {
        var p = new ChannelPatchParameter();
        return await this.SendAsync<ChannelPatchParameter, ChannelPatchResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/channel-patch?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ChannelPatchResponse> ChannelPatchAsync(ChannelPatchParameter parameter)
    {
        return await this.SendAsync<ChannelPatchParameter, ChannelPatchResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/channel-patch?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ChannelPatchResponse> ChannelPatchAsync(ChannelPatchParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ChannelPatchParameter, ChannelPatchResponse>(parameter, cancellationToken);
    }
}
