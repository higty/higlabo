using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/channel-list-messages?view=graph-rest-1.0
/// </summary>
public partial class ChannelListMessagesParameter : IRestApiParameter, IQueryParameterProperty
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
                case ApiPath.Teams_TeamId_Channels_ChannelId_Messages: return $"/teams/{TeamId}/channels/{ChannelId}/messages";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Teams_TeamId_Channels_ChannelId_Messages,
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
public partial class ChannelListMessagesResponse : RestApiResponse<ChatMessage>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/channel-list-messages?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/channel-list-messages?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ChannelListMessagesResponse> ChannelListMessagesAsync()
    {
        var p = new ChannelListMessagesParameter();
        return await this.SendAsync<ChannelListMessagesParameter, ChannelListMessagesResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/channel-list-messages?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ChannelListMessagesResponse> ChannelListMessagesAsync(CancellationToken cancellationToken)
    {
        var p = new ChannelListMessagesParameter();
        return await this.SendAsync<ChannelListMessagesParameter, ChannelListMessagesResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/channel-list-messages?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ChannelListMessagesResponse> ChannelListMessagesAsync(ChannelListMessagesParameter parameter)
    {
        return await this.SendAsync<ChannelListMessagesParameter, ChannelListMessagesResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/channel-list-messages?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ChannelListMessagesResponse> ChannelListMessagesAsync(ChannelListMessagesParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ChannelListMessagesParameter, ChannelListMessagesResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/channel-list-messages?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<ChatMessage> ChannelListMessagesEnumerateAsync(ChannelListMessagesParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<ChannelListMessagesParameter, ChannelListMessagesResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<ChatMessage>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
