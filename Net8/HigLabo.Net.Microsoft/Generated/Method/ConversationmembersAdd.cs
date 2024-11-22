using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/conversationmembers-add?view=graph-rest-1.0
/// </summary>
public partial class ConversationMembersAddParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? TeamId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Teams_TeamId_Members_Add: return $"/teams/{TeamId}/members/add";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Teams_TeamId_Members_Add,
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
    public ConversationMember[]? Values { get; set; }
}
public partial class ConversationMembersAddResponse : RestApiResponse<ActionResultPart>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/conversationmembers-add?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/conversationmembers-add?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ConversationMembersAddResponse> ConversationMembersAddAsync()
    {
        var p = new ConversationMembersAddParameter();
        return await this.SendAsync<ConversationMembersAddParameter, ConversationMembersAddResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/conversationmembers-add?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ConversationMembersAddResponse> ConversationMembersAddAsync(CancellationToken cancellationToken)
    {
        var p = new ConversationMembersAddParameter();
        return await this.SendAsync<ConversationMembersAddParameter, ConversationMembersAddResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/conversationmembers-add?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ConversationMembersAddResponse> ConversationMembersAddAsync(ConversationMembersAddParameter parameter)
    {
        return await this.SendAsync<ConversationMembersAddParameter, ConversationMembersAddResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/conversationmembers-add?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ConversationMembersAddResponse> ConversationMembersAddAsync(ConversationMembersAddParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ConversationMembersAddParameter, ConversationMembersAddResponse>(parameter, cancellationToken);
    }
}
