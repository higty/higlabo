using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/sharedwithchannelteaminfo-list?view=graph-rest-1.0
/// </summary>
public partial class SharedwithchannelteaminfoListParameter : IRestApiParameter, IQueryParameterProperty
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
                case ApiPath.Teams_TeamId_Channels_ChannelId_SharedWithTeams: return $"/teams/{TeamId}/channels/{ChannelId}/sharedWithTeams";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Teams_TeamId_Channels_ChannelId_SharedWithTeams,
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
public partial class SharedwithchannelteaminfoListResponse : RestApiResponse<SharedWithChannelTeamInfo>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/sharedwithchannelteaminfo-list?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/sharedwithchannelteaminfo-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SharedwithchannelteaminfoListResponse> SharedwithchannelteaminfoListAsync()
    {
        var p = new SharedwithchannelteaminfoListParameter();
        return await this.SendAsync<SharedwithchannelteaminfoListParameter, SharedwithchannelteaminfoListResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/sharedwithchannelteaminfo-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SharedwithchannelteaminfoListResponse> SharedwithchannelteaminfoListAsync(CancellationToken cancellationToken)
    {
        var p = new SharedwithchannelteaminfoListParameter();
        return await this.SendAsync<SharedwithchannelteaminfoListParameter, SharedwithchannelteaminfoListResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/sharedwithchannelteaminfo-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SharedwithchannelteaminfoListResponse> SharedwithchannelteaminfoListAsync(SharedwithchannelteaminfoListParameter parameter)
    {
        return await this.SendAsync<SharedwithchannelteaminfoListParameter, SharedwithchannelteaminfoListResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/sharedwithchannelteaminfo-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SharedwithchannelteaminfoListResponse> SharedwithchannelteaminfoListAsync(SharedwithchannelteaminfoListParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<SharedwithchannelteaminfoListParameter, SharedwithchannelteaminfoListResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/sharedwithchannelteaminfo-list?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<SharedWithChannelTeamInfo> SharedwithchannelteaminfoListEnumerateAsync(SharedwithchannelteaminfoListParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<SharedwithchannelteaminfoListParameter, SharedwithchannelteaminfoListResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<SharedWithChannelTeamInfo>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
