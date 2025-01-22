using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/sharedwithchannelteaminfo-list-allowedmembers?view=graph-rest-1.0
/// </summary>
public partial class SharedwithchannelteaminfoListAllowedMembersParameter : IRestApiParameter, IQueryParameterProperty
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
                case ApiPath.Teams_TeamId_Channels_ChannelId_SharedWithTeams_SharedWithChannelTeamInfoId_AllowedMembers: return $"/teams/{TeamId}/channels/{ChannelId}/sharedWithTeams/{SharedWithChannelTeamInfoId}/allowedMembers";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Teams_TeamId_Channels_ChannelId_SharedWithTeams_SharedWithChannelTeamInfoId_AllowedMembers,
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
public partial class SharedwithchannelteaminfoListAllowedMembersResponse : RestApiResponse<ConversationMember>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/sharedwithchannelteaminfo-list-allowedmembers?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/sharedwithchannelteaminfo-list-allowedmembers?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SharedwithchannelteaminfoListAllowedMembersResponse> SharedwithchannelteaminfoListAllowedMembersAsync()
    {
        var p = new SharedwithchannelteaminfoListAllowedMembersParameter();
        return await this.SendAsync<SharedwithchannelteaminfoListAllowedMembersParameter, SharedwithchannelteaminfoListAllowedMembersResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/sharedwithchannelteaminfo-list-allowedmembers?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SharedwithchannelteaminfoListAllowedMembersResponse> SharedwithchannelteaminfoListAllowedMembersAsync(CancellationToken cancellationToken)
    {
        var p = new SharedwithchannelteaminfoListAllowedMembersParameter();
        return await this.SendAsync<SharedwithchannelteaminfoListAllowedMembersParameter, SharedwithchannelteaminfoListAllowedMembersResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/sharedwithchannelteaminfo-list-allowedmembers?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SharedwithchannelteaminfoListAllowedMembersResponse> SharedwithchannelteaminfoListAllowedMembersAsync(SharedwithchannelteaminfoListAllowedMembersParameter parameter)
    {
        return await this.SendAsync<SharedwithchannelteaminfoListAllowedMembersParameter, SharedwithchannelteaminfoListAllowedMembersResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/sharedwithchannelteaminfo-list-allowedmembers?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SharedwithchannelteaminfoListAllowedMembersResponse> SharedwithchannelteaminfoListAllowedMembersAsync(SharedwithchannelteaminfoListAllowedMembersParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<SharedwithchannelteaminfoListAllowedMembersParameter, SharedwithchannelteaminfoListAllowedMembersResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/sharedwithchannelteaminfo-list-allowedmembers?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<ConversationMember> SharedwithchannelteaminfoListAllowedMembersEnumerateAsync(SharedwithchannelteaminfoListAllowedMembersParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<SharedwithchannelteaminfoListAllowedMembersParameter, SharedwithchannelteaminfoListAllowedMembersResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<ConversationMember>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
